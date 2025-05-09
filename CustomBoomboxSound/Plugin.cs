using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;

namespace CustomBoomboxSound
{
    [BepInPlugin("com.masterxolos.customboomboxsound", "Custom Boombox Sound", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Logger;
        internal static AudioClip customClip;

        private void Awake()
        {
            Logger = base.Logger;
            Logger.LogInfo("Custom Boombox Sound plugin loaded!");

            string pluginDir = Path.GetDirectoryName(Info.Location);
            string clipPath = Path.Combine(pluginDir, "custom.ogg");

            if (!File.Exists(clipPath))
            {
                Logger.LogError("custom.ogg not found in plugin folder! Please add your .ogg file.");
                return;
            }

            UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + clipPath, AudioType.OGGVORBIS);
            var request = www.SendWebRequest();
            while (!request.isDone) {}

            if (www.result == UnityWebRequest.Result.Success)
            {
                customClip = DownloadHandlerAudioClip.GetContent(www);
                Logger.LogInfo("Successfully loaded custom.ogg");

                Harmony harmony = new Harmony("com.masterxolos.customboomboxsound");
                harmony.PatchAll();
            }
            else
            {
                Logger.LogError("Failed to load custom.ogg");
            }
        }

        [HarmonyPatch(typeof(ValuableBoombox), "Start")]
        public class PatchBoomboxStart
        {
            static void Postfix(ValuableBoombox __instance)
            {
                if (__instance.soundBoomboxMusic != null && customClip != null)
                {
                    __instance.soundBoomboxMusic.Sounds = new AudioClip[] { customClip };
                    __instance.soundBoomboxMusic.Stop();
                    __instance.soundBoomboxMusic.Play(__instance.transform.position);
                    Logger.LogInfo("Replaced boombox music with custom sound!");
                }
                else
                {
                    Logger.LogWarning("Failed to replace boombox music: missing reference.");
                }
            }
        }
    }
}
