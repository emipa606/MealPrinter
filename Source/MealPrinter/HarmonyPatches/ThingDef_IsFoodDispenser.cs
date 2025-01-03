﻿using HarmonyLib;
using Verse;

namespace MealPrinter.HarmonyPatches;

[HarmonyPatch(typeof(ThingDef), nameof(ThingDef.IsFoodDispenser), MethodType.Getter)]
public static class ThingDef_IsFoodDispenser
{
    // stop need hoppers alert

    private static bool Prefix(ThingDef __instance, ref bool __result)
    {
        if (__instance.thingClass != typeof(Building_MealPrinter))
        {
            return true;
        }

        __result = false;
        return false;
    }
}