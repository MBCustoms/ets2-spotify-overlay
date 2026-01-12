using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ETS2_Spotify_Overlay
{
    public class SimpleHTTPServer
    {
        private readonly string[] _indexFiles =
        {
            "index.html",
            "index.htm",
            "default.html",
            "default.htm"
        };

        private static IDictionary<string, string> _mimeTypeMappings =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            {".html", "text/html"},
            {".htm", "text/html"},
            {".css", "text/css"},
            {".js", "application/javascript"},
            {".json", "application/json"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"},
            {".ico", "image/x-icon"},
            {".mp3", "audio/mpeg"},
            {".txt", "text/plain"}
        };

        private Thread _serverThread;
        private string _rootDirectory;
        private HttpListener _listener;
        private int _port;

        public int Port => _port;

        public SimpleHTTPServer(string path, int port)
        {
            Initialize(path, port);
        }

        public SimpleHTTPServer(string path)
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();

            Initialize(path, port);
        }

        public void Stop()
        {
            try
            {
                if (_listener != null && _listener.IsListening)
                {
                    _listener.Stop();
                }
            }
            catch (Exception ex)
            {
                Log.Write("Error stopping HTTP listener: " + ex.ToString());
            }
            
            try
            {
                if (_serverThread != null && _serverThread.IsAlive)
                {
                    _serverThread.Abort();
                }
            }
            catch (Exception ex)
            {
                Log.Write("Error aborting server thread: " + ex.ToString());
            }
        }

        private void Initialize(string path, int port)
        {
            _rootDirectory = path;
            _port = port;
            _serverThread = new Thread(Listen);
            _serverThread.Start();
        }

        private void Listen()
        {
            try
            {
                _listener = new HttpListener();
                _listener.Prefixes.Add($"http://+:{_port}/");
                _listener.Start();

                while (_listener.IsListening)
                {
                    try
                    {
                        var context = _listener.GetContext();
                        Task.Run(() => Process(context));
                    }
                    catch (HttpListenerException ex)
                    {
                        // Listener was stopped
                        if (!_listener.IsListening)
                            break;
                        Log.Write("HttpListener error: " + ex.ToString());
                    }
                    catch (Exception ex)
                    {
                        Log.Write("Error getting context: " + ex.ToString());
                    }
                }
            }
            catch (HttpListenerException ex)
            {
                Log.Write("Failed to start HTTP server. Port may be in use or admin rights required: " + ex.Message);
            }
            catch (Exception ex)
            {
                Log.Write("HTTP server error: " + ex.ToString());
            }
        }

        private void Process(HttpListenerContext context)
        {
            context.Response.AddHeader("Cache-Control", "no-store, must-revalidate");
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");

            string path = WebUtility.UrlDecode(context.Request.Url.AbsolutePath);

            /* ============================
             * SPOTIFY API
             * ============================ */
            if (path == "/spotify" || path == "/api/spotify/")
            {
                HandleSpotify(context);
                return;
            }

            /* ============================
             * ETS2 DATA API
             * ============================ */
            if (path == "/api/")
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(Main.ets2data);
                WriteJson(context, json);
                return;
            }

            /* ============================
             * STATIC FILE SERVER
             * ============================ */
            ServeFile(context);
        }

        private void HandleSpotify(HttpListenerContext context)
        {
            string json = "{\"connected\":false}";

            if (Main.spotifyManager != null && Main.spotifyManager.IsConnected)
            {
                var track = Main.spotifyManager.GetCurrentTrack();
                if (track != null)
                {
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        connected = true,
                        isConnected = true,
                        track = track.TrackName,
                        artist = track.Artists,
                        album = track.Album,
                        coverUrl = track.AlbumCoverUrl,
                        isPlaying = track.IsPlaying,
                        progressMs = track.ProgressMs,
                        durationMs = track.DurationMs
                    });
                }
                else
                {
                    json = "{\"connected\":true,\"isConnected\":true,\"track\":null}";
                }
            }

            WriteJson(context, json);
        }

        private void WriteJson(HttpListenerContext context, string json)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            context.Response.ContentType = "application/json";
            context.Response.ContentLength64 = buffer.Length;
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();
        }

        private void ServeFile(HttpListenerContext context)
        {
            string filename = context.Request.Url.AbsolutePath.TrimStart('/');
            filename = filename.Replace("/", "\\");

            if (string.IsNullOrEmpty(filename))
            {
                foreach (var index in _indexFiles)
                {
                    if (File.Exists(Path.Combine(_rootDirectory, index)))
                    {
                        filename = index;
                        break;
                    }
                }
            }

            filename = Path.Combine(_rootDirectory, filename);

            if (!File.Exists(filename))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.OutputStream.Close();
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    string mime = _mimeTypeMappings.TryGetValue(
                        Path.GetExtension(filename),
                        out string m
                    ) ? m : "application/octet-stream";

                    context.Response.ContentType = mime;
                    context.Response.ContentLength64 = fs.Length;

                    fs.CopyTo(context.Response.OutputStream);
                }

                context.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                Log.Write(ex.ToString());
            }
            finally
            {
                context.Response.OutputStream.Close();
            }
        }
    }
}
