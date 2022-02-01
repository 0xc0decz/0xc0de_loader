﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using _0xc0de_library;
using UnityEngine;

namespace _0xc0de_MGT_Mod
{
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.0xc0de.MGT_Mod");
       
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch]
        public static class Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch(typeof(mainScript), "Update")]
            public static void Update()
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Application.Quit();
                }
            }


        }
    }
}
