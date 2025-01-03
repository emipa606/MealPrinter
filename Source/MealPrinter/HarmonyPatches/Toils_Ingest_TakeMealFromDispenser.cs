﻿using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace MealPrinter.HarmonyPatches;

[HarmonyPatch(typeof(Toils_Ingest), nameof(Toils_Ingest.TakeMealFromDispenser))]
public static class Toils_Ingest_TakeMealFromDispenser
{
    private static bool Prefix(ref TargetIndex ind, ref Pawn eater, ref Toil __result)
    {
        if (eater.jobs.curJob.GetTarget(ind).Thing is not Building_MealPrinter)
        {
            return true;
        }

        if (eater.DevelopmentalStage.Baby())
        {
            return true;
        }

        var windex = ind;
        var toil = new Toil();
        toil.initAction = delegate
        {
            var actor = toil.actor;
            var curJob = actor.jobs.curJob;
            var printer = (Building_MealPrinter)curJob.GetTarget(windex).Thing;

            var thing = printer.TryDispenseFood();
            if (thing == null)
            {
                actor.jobs.curDriver.EndJobWith(JobCondition.Incompletable);
                return;
            }

            actor.carryTracker.TryStartCarry(thing);
            actor.CurJob.SetTarget(windex, actor.carryTracker.CarriedThing);
        };
        toil.FailOnCannotTouch(ind, PathEndMode.Touch);
        toil.defaultCompleteMode = ToilCompleteMode.Delay;
        toil.defaultDuration = Building_NutrientPasteDispenser.CollectDuration;
        __result = toil;
        return false;
    }
}