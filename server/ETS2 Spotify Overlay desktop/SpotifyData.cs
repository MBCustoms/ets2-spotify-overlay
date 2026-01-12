using System;

namespace ETS2_Spotify_Overlay
{
    public class SpotifyData
    {
        public string Track { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string CoverUrl { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsConnected { get; set; }
        public int ProgressMs { get; set; }
        public int DurationMs { get; set; }

        public SpotifyData()
        {
            Track = "";
            Artist = "";
            Album = "";
            CoverUrl = "";
            IsPlaying = false;
            IsConnected = false;
            ProgressMs = 0;
            DurationMs = 0;
        }
    }
}
