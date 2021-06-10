using BepInEx;
using HarmonyLib;
using UnityEngine;
using System;
using Photon.Pun;
using System.Reflection;
using HarmonyLib.Tools;

namespace W_jump
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInProcess("Rounds.exe")]
    [BepInPlugin("uniquename.rounds.w-jump", "W-jump", "0.0.0.0")]
    public class W_Jump : BaseUnityPlugin
    {

        public void Awake()
        {
            var harmony = new Harmony("uniquename.rounds.w-jump");
            harmony.PatchAll();
        }

        public const string modID = "uniquename.rounds.w-jump";
        public const string modName = "W-jump";
    }

    [HarmonyPatch(typeof(GeneralInput), "Update")]
    public class W_Jump_Patch : MonoBehaviour
    {
        [HarmonyPostfix]
        private static void update_patch(GeneralInput __instance)
        {
            if (Input.GetKey("w"))
            {
                __instance.jumpIsPressed = true;
            }
            if (Input.GetKey("w"))
            {
                __instance.jumpWasPressed = true;
            }
        }
    }
}