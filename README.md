# Custom Boombox Sound

This mod replaces the in-game boombox music with a custom royalty-free track:  
**"Susan - Royalty Free Instrumental Disco-House Music Loop (125 bpm)"**.

Place your `custom.ogg` in the plugin folder if you'd like to change the music.

---

## Credits
Music by [The Loop Lady](https://thelooplady.bandcamp.com/track/susan-royalty-free-instrumental-disco-house-music-loop-125-bpm) – used under royalty-free license.

##How to Build (Compile) the Mod
To compile this plugin from source, follow these steps:

📦 Requirements
.NET Framework 4.7.2 Developer Pack
Visual Studio 2019 or later
BepInEx 5.x
The game installed (to reference its DLLs)

📁 Folder Structure
Make sure your folder structure looks like this:

CustomBoomboxSound/
├── CustomBoomboxSound.csproj
├── Plugin.cs
├── custom.ogg (optional, for testing)
🧷 References to Add (DLLs)
In your project file (.csproj), you need to reference these assemblies:

UnityEngine.dll
UnityEngine.CoreModule.dll
UnityEngine.Networking.dll
BepInEx.dll
0Harmony.dll

