using System.Collections.Generic;
using System.Linq;
using _WorldGenStateCapture;
using Database;
using FMODUnity;
using HarmonyLib;
using Klei.AI;
using STRINGS;
using UnityEngine;
using Patches = _WorldGenStateCapture.Patches;

namespace MapsNotIncluded_WorldParser;

public class PersonalPatches
{
    [HarmonyPatch(typeof(Patches.AutoLaunchParser), nameof(Patches.AutoLaunchParser.InitAutoStart))]
    public static class SmallResolution
    {
        public static void Prefix()
        {
            // no enough GPU power on my headless server 😅
            // (and I mean NO gpu power, the game is being rendered entirely on the CPU, so saving on resolution saves on Loading Time)
            Screen.SetResolution(128, 72,  FullScreenMode.Windowed, Screen.resolutions.First().refreshRateRatio);
        }
    }
    
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnSpawn))]
    public static class BigResolution
    {
        public static void Prefix()
        {
            Screen.SetResolution(1280, 720, FullScreenMode.Windowed, Screen.resolutions.First().refreshRateRatio);
        }
    }
    
    
}