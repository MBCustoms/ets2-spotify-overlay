# **ETS2/ATS Spotify Overlay**

ETS2/ATS Spotify Overlay is a Windows application that displays Spotify music information as an in-game overlay for Euro Truck Simulator 2 (ETS2) and American Truck Simulator (ATS). It displays the currently playing track, artist, and album art directly on the game screen.

## **Features**

* 🎵 **Spotify Integration**: Real-time song information via Spotify Web API.  
* 🎮 **In-game Overlay**: Visual information display on the game screen using DirectX hooks.  
* 🎯 **Auto-Detection**: Automatically detects both ETS2 and ATS games.

## **Requirements**

* Windows 10 or later  
* .NET Framework 4.8  
* Visual C++ 2010 Redistributable (for SlimDX)  
* Spotify account (for Web API access)  
* Euro Truck Simulator 2 or American Truck Simulator

## **Installation**

1. Clone or download the project:  
   git clone [https://github.com/MBCustoms/ets2-spotify-overlay.git](https://github.com/MBCustoms/ets2-spotify-overlay.git)
   cd ets2-spotify-overlay

2. Open the server/ETS2 Spotify Overlay.sln file with Visual Studio 2019 or later.  
3. Restore NuGet packages:  
   * In Visual Studio: Tools \> NuGet Package Manager \> Restore NuGet Packages  
   * Or via command line: nuget restore  
4. Build the project (Release or Debug).  
5. Run ETS2 Spotify Overlay.exe.  
6. Click the "Install plugin" button to install the game plugin.  
7. Click the "Connect to Spotify" button to link your account.

## **Usage**

### **Initial Setup**

1. Launch the application.  
2. Click the "Install plugin for Euro Truck Simulator 2" or "Install plugin for American Truck Simulator" button.  
3. Select your game installation folder (e.g., C:\\Program Files (x86)\\Steam\\steamapps\\common\\Euro Truck Simulator 2).  
4. Click the "Connect to Spotify" button.  
5. Your browser will open the Spotify authorization page; log in and grant permissions.

## **Development**

### **Requirements**

* Visual Studio 2019 or later  
* .NET Framework 4.8 SDK  
* Windows SDK

### **Build Process**

1. Open the solution file in Visual Studio.  
2. Go to Build \> Build Solution (Ctrl+Shift+B).  
3. Compile in Release or Debug mode.

### **Dependencies**

Main NuGet packages used:

* SpotifyAPI.Web (4.0.0)  
* Newtonsoft.Json (13.0.4)  
* EmbedIO (2.2.7)  
* SlimDX (4.0.13.44)  
* SharpDX (4.2.0)  
* EasyHook (2.7.7097)  
* MouseKeyHook (5.7.1)

## **Troubleshooting**

### **Overlay is not appearing**

* Ensure the game is running in DirectX mode.  
* Check if the overlay is enabled in the settings (overlay: true).  
* Try restarting the game.

### **Cannot connect to Spotify**

* Make sure your Spotify account is active.  
* Check your internet connection.  
* Ensure your firewall is not blocking the application.

### **Game is not detected**

* Ensure the game is actually running.  
* Verify the plugin is installed correctly (bin\\win\_x64\\plugins\\mbcustoms-spotify.dll).  
* Try running the game as an administrator.

### **Port Error**

* The default port (8330) might be used by another application.  
* Try a different port number in the settings.json file.

## **Contributing**

Contributions are welcome\! Please:

1. Fork the project.  
2. Create a feature branch (git checkout \-b feature/amazing-feature).  
3. Commit your changes (git commit \-m 'Add some amazing feature').  
4. Push to the branch (git push origin feature/amazing-feature).  
5. Open a Pull Request.

## **Credits**

* RenCloud \- For the ETS2 SDK plugin.  
* Koenvh1 \- For the ETS2 Local Radio Application.  
* All contributors and users.

## **Contact**

For questions or suggestions, please open an [Issue](https://github.com/MBCustoms/ets2-spotify-overlay/issues).

**Note**: This project was inspired by the ETS2 Local Radio project by Koenvh1 and has been adapted for Spotify integration.
