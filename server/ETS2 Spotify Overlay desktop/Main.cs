using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETS2_Spotify_Overlay.Properties;
using Gma.System.MouseKeyHook;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCSSdkClient;
using SCSSdkClient.Object;

namespace ETS2_Spotify_Overlay
{
    public partial class Main : Form
    {
        public SCSSdkTelemetry Telemetry;

        public SimpleHTTPServer myServer;

        private IKeyboardMouseEvents m_GlobalHook;
        private SimpleJoystick joystick;
        private bool[] previousState;

        public int amount = 0;

        public static Coordinates coordinates;

        public static SCSTelemetry ets2data;
        public static Commands commandsData;
        public static SpotifyData spotifyData = new SpotifyData();
        public static SpotifyManager spotifyManager;

        public static string simulatorNotRunning = "Simulator not yet running";
        public static string simulatorNotDriving = "Simulator running, let's get driving!";
        public static string simulatorRunning = "Simulator running!";

        public static string installOverlay =
            "Do you want to install the in-game overlay?\n(This will overwrite an already existing d3d9.dll, and it may in rare cases cause the game to crash when exiting the game)";

        public static string removeOverlay =
            "Do you want to remove the in-game overlay?\n(This will remove any existing d3d9.dll)";

        public static string currentGame = "none";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Log.Clear();
            Settings.Load();

            //Global keyboard hook logic by https://github.com/gmamaladze/globalmousekeyhook/blob/vNext/Demo/Main.cs
            Subscribe();

            //Add Firewall exception
            //AddException();

            //Check plugins:
            CheckPlugins();

            //Initialize Spotify Manager:
            spotifyManager = new SpotifyManager();
            spotifyManager.StatusChanged += SpotifyManager_StatusChanged;
            spotifyManager.TrackChanged += SpotifyManager_TrackChanged;

            //Load favourites
            Favourites.Load();

            //Start telemetry grabbing:
            Telemetry = new SCSSdkTelemetry(250);
            Telemetry.Data += Telemetry_Data;

            if (Telemetry.Error != null)
            {
                MessageBox.Show(
                    "General info:\r\nFailed to open memory map " + Telemetry.Map +
                        " - on some systems you need to run the client (this app) with elevated permissions, because e.g. you're running Steam/ETS2 with elevated permissions as well. .NET reported the following Exception:\r\n" +
                        Telemetry.Error.Message + "\r\n\r\nStacktrace:\r\n" + Telemetry.Error.StackTrace);
            }

            //Open server:
            myServer = new SimpleHTTPServer(Directory.GetCurrentDirectory() + "\\web", Settings.Port);
            writeFile("none", "0", "0");   

            currentGameTimer.Start();
        }

        private void CheckPlugins()
        {
            if (PluginExists("ats"))
            {
                installAtsButton.Image = Resources.check;
            }
            else
            {
                installAtsButton.Image = null;
            }
            if (PluginExists("ets2"))
            {
                installEts2Button.Image = Resources.check;
            }
            else
            {
                installEts2Button.Image = null;
            }
            if (!PluginExists("ats") && !PluginExists("ets2"))
            {
                groupInfo.Enabled = false;
            }
            else
            {
                groupInfo.Enabled = true;
            }
        }

        private bool PluginExists(string game)
        {
            string folder = "";
            if (game == "ets2")
            {
                folder = Settings.Ets2Folder;
            }
            if (game == "ats")
            {
                folder = Settings.AtsFolder;
            }
            try
            {
                if (folder != null)
                {
                    if (Directory.Exists(folder + @"\bin\win_x64\plugins"))
                    {
                        if (File.Exists(folder + @"\bin\win_x64\plugins\mbcustoms-spotify.dll"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool ChooseFolder(string game)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DialogResult result = DialogResult.No;
                        //MessageBox.Show(installOverlay, "ETS2 Spotify Overlay server",
                        //MessageBoxButtons.YesNoCancel,
                        //MessageBoxIcon.Question);

                    if (result != DialogResult.Cancel)
                    {
                        string folder = folderDialog.SelectedPath;
                        Directory.CreateDirectory(folder + @"\bin\win_x64\plugins");

                        File.Copy(Directory.GetCurrentDirectory() + @"\plugins\bin\win_x64\plugins\mbcustoms-spotify.dll",
                            folder + @"\bin\win_x64\plugins\mbcustoms-spotify.dll", true);

                        if (game == "ets2")
                        {
                            Settings.Ets2Folder = folder;
                        }
                        if (game == "ats")
                        {
                            Settings.AtsFolder = folder;
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool AttachJoystick()
        {
            try
            {
                //Initialise joystick:
                string name = null;
                if (Settings.Controller != null)
                {
                    name = Settings.Controller;
                }
                joystick = new SimpleJoystick(name);

                //Start joystick input timer:
                joystickTimer.Start();
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex.ToString());
                return false;
            }
        }

        private void Telemetry_Data(SCSTelemetry data, bool updated)
        {
            if (!updated)
            {
                return;
            }
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new TelemetryData(Telemetry_Data), data, updated);
                    return;
                }

                ets2data = data;
                coordinates = new Coordinates(data.TruckValues.Positioning.HeadPositionInWorldSpace.X, data.TruckValues.Positioning.HeadPositionInWorldSpace.Y, data.TruckValues.Positioning.HeadPositionInWorldSpace.Z);

                if (data.SdkActive == false)
                {
                    statusLabel.Text = simulatorNotRunning;
                    statusLabel.ForeColor = Color.Red;
                }
                else if (data.Timestamp == 0)
                {
                    statusLabel.Text = simulatorNotDriving;
                    statusLabel.ForeColor = Color.DarkOrange;
                }
                else
                {
                    statusLabel.Text = simulatorRunning;
                    statusLabel.ForeColor = Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        //private static void DeleteException()
        //{
        //    Process netsh = new Process();
        //    string arguments = "advfirewall firewall delete rule name=\"ETS2 Spotify Overlay\" dir=in protocol=TCP localport=" + Settings.Port;
        //    netsh.StartInfo.FileName = "netsh";
        //    netsh.StartInfo.Arguments = arguments;
        //    netsh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //    netsh.Start();
        //}

        //private static void AddException()
        //{
        //    DeleteException();
        //    // to prevent duplicates

        //    Process netsh = new Process();
        //    string arguments = "advfirewall firewall add rule name=\"ETS2 Spotify Overlay\" dir=in action=allow protocol=TCP localport=" + Settings.Port;
        //    netsh.StartInfo.FileName = "netsh";
        //    netsh.StartInfo.Arguments = arguments;
        //    netsh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //    netsh.Start();
        //}

        private void Main_FormClosing(object sender, EventArgs e)
        {
            try
            {
                //Global keyboard hook logic by https://github.com/gmamaladze/globalmousekeyhook/blob/vNext/Demo/Main.cs
                Settings.Save();
                Unsubscribe();
                myServer.Stop();
                writeFile("none", "0", "0");
                //DeleteException();
                joystickTimer.Stop();
                spotifyManager?.Stop();
            }
            catch (Exception ex)
            {
                Log.Write(ex.ToString());
            }
            finally
            {
                Application.Exit();
            }
        }

        public void Subscribe()
        {
            try
            {
                // Note: for the application hook, use the Hook.AppEvents() instead
                m_GlobalHook = Hook.GlobalEvents();
            } catch (Exception ex)
            {
                Log.Write(ex.ToString());
            }
        }

        public void Unsubscribe()
        {
            //It is recommened to dispose it
            if (m_GlobalHook != null)
            {
                m_GlobalHook.Dispose();
                m_GlobalHook = null;
            }
        }
        private void keyTimeout_Tick(object sender, EventArgs e)
        {
            keyTimeout.Stop();
            writeFile("next", amount.ToString());
            amount = 0;
            Console.WriteLine(amount);
        }

        private void writeFile(string action, string amount, string id = null)
        {
            if (id == null)
            {
                id = Guid.NewGuid().ToString("n");
            }

            Commands command = new Commands(id, action, amount, Settings.Language);
            commandsData = command;
        }

        /*
        public static void SaveAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                Console.WriteLine(configFile.FilePath);
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine("Error writing app settings");
                Log.Write(ex.ToString());
            }
        }
        */

        private void keyInput(object sender, KeyEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            e.Handled = true;
            e.SuppressKeyPress = true;
            txtBox.Text = e.KeyCode.ToString();
        }
        private void removeBinding(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back)
            {
                TextBox txtBox = (TextBox)sender;
                e.Handled = true;
                e.SuppressKeyPress = true;
                txtBox.Clear();
            }
        }

        private void Koenvh_Click(object sender, EventArgs e)
        {
            Process.Start("http://koenvh.nl");
        }

        private void MBCustoms_Click(object sender, EventArgs e)
        {
            Process.Start("https://metehanbilal.com");
        }

        private void currentGameTimer_Tick(object sender, EventArgs e)
        {
            bool ets2Found = false;
            bool atsFound = false;

            if (Process.GetProcessesByName("eurotrucks2").Length > 0)
            {
                if (currentGame != "ets2")
                {
                    currentGame = "ets2";
                    gameLabel.Text = "Euro Truck Simulator 2";
                    writeFile("game", "0", "0");
                    //Station.AttachProcess("eurotrucks2");
                }
                ets2Found = true;
            }
            if (Process.GetProcessesByName("amtrucks").Length > 0)
            {
                if (currentGame != "ats")
                {
                    currentGame = "ats";
                    gameLabel.Text = "American Truck Simulator";
                    writeFile("game", "0", "0");
                    //Station.AttachProcess("amtrucks");
                }
                atsFound = true;
            }

            if (!ets2Found && !atsFound)
            {
                currentGame = "none";
            }
        }

        private void SpotifyManager_StatusChanged(object sender, string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, string>(SpotifyManager_StatusChanged), sender, status);
                return;
            }

            Log.Write("Spotify: " + status);

            if (spotifyStatusLabel != null)
            {
                spotifyStatusLabel.Text = status;
                if (status == "Connected" || status == "Reconnected")
                {
                    spotifyStatusLabel.ForeColor = Color.Green;
                    spotifyConnectButton.Enabled = true;
                    spotifyConnectButton.Text = "Disconnect from Spotify";
                }
                else if (status == "Connecting...")
                {
                    spotifyStatusLabel.ForeColor = Color.Orange;
                    spotifyConnectButton.Enabled = false;
                }
                else if (status.Contains("failed") || status == "Auth failed")
                {
                    spotifyStatusLabel.ForeColor = Color.Red;
                    spotifyConnectButton.Enabled = true;
                    spotifyConnectButton.Text = "Connect to Spotify";
                }
                else if (status == "Disconnected")
                {
                    spotifyStatusLabel.ForeColor = Color.Gray;
                    spotifyStatusLabel.Text = "Not connected";
                    spotifyConnectButton.Enabled = true;
                    spotifyConnectButton.Text = "Connect to Spotify";
                }
                else
                {
                    spotifyStatusLabel.ForeColor = Color.Black;
                }
            }
        }

        private void SpotifyManager_TrackChanged(object sender, SpotifyManager.TrackInfo trackInfo)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, SpotifyManager.TrackInfo>(SpotifyManager_TrackChanged), sender, trackInfo);
                return;
            }
            // Update overlay when Spotify track changes
            if (trackInfo != null && spotifyManager != null && spotifyManager.IsConnected)
            {
                Station.SetSpotifyTrack(trackInfo);
                
                // Update UI
                spotifyTrackLabel.Text = string.IsNullOrEmpty(trackInfo.TrackName) ? "-" : trackInfo.TrackName;
                spotifyArtistLabel.Text = string.IsNullOrEmpty(trackInfo.Artists) ? "-" : trackInfo.Artists;
            }
        }

        private void UpdateSpotifyUI(bool isConnected, dynamic data)
        {
            try
            {
                if (isConnected && data != null)
                {
                    spotifyStatusLabel.Text = "Connected" + (data.IsPlaying == true ? " (Playing)" : " (Paused)");
                    spotifyStatusLabel.ForeColor = Color.DarkGreen;
                    
                    string track = data.Track ?? "";
                    string artist = data.Artist ?? "";
                    
                    spotifyTrackLabel.Text = string.IsNullOrEmpty(track) ? "-" : track;
                    spotifyArtistLabel.Text = string.IsNullOrEmpty(artist) ? "-" : artist;
                }
                else
                {
                    spotifyStatusLabel.Text = "Not Connected";
                    spotifyStatusLabel.ForeColor = Color.Red;
                    spotifyTrackLabel.Text = "-";
                    spotifyArtistLabel.Text = "-";
                }

                // Update button text based on connection status
                if (spotifyManager != null && spotifyManager.IsConnected)
                {
                    spotifyConnectButton.Text = "Disconnect from Spotify";
                }
                else
                {
                    spotifyConnectButton.Text = "Connect to Spotify";
                }
            }
            catch (Exception ex)
            {
                Log.Write("UpdateSpotifyUI error: " + ex.ToString());
            }
        }

        private void installAtsButton_Click(object sender, EventArgs e)
        {
            if (ChooseFolder("ats"))
            {
                installAtsButton.Image = Resources.check;
                groupInfo.Enabled = true;
            }
        }

        private void installEts2Button_Click(object sender, EventArgs e)
        {
            if (ChooseFolder("ets2"))
            {
                installEts2Button.Image = Resources.check;
                groupInfo.Enabled = true;
            }
        }

        private void removePluginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    var folder = folderDialog.SelectedPath;
                    File.Delete(folder + @"\bin\win_x64\plugins\mbcustoms-spotify.dll");

                }
                CheckPlugins();
            }
            catch (Exception ex)
            {
                Log.Write(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private async void spotifyConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (spotifyManager != null && spotifyManager.IsConnected)
                {
                    // Disconnect
                    spotifyManager.Stop();
                    return;
                }

                MessageBox.Show("The application will open your browser to connect to the Spotify API", "Spotify Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await spotifyManager.ConnectAsync();
            }
            catch (Exception ex)
            {
                Log.Write("Spotify connection error: " + ex.ToString());
                MessageBox.Show("Failed to connect to Spotify: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void folderDialog_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
