using HarmonyLib;
using System;
using System.Reflection;
using System.Collections.Generic;
using Verse;

namespace RunAndGunCEFix
{
    [StaticConstructorOnStartup]
    public static class RunAndGunCEFix
    {
        static RunAndGunCEFix()
        {
            try
            {
                Log.Message("[RunAndGunCEFix] Iniciando parche de compatibilidad...");
                
                var harmony = new Harmony("YourName.RunAndGunCEFix");
                PatchCECompatibility(harmony);
                
                Log.Message("[RunAndGunCEFix] Parche aplicado exitosamente");
            }
            catch (Exception ex)
            {
                Log.Error($"[RunAndGunCEFix] Error: {ex}");
            }
        }

        private static void PatchCECompatibility(Harmony harmony)
        {
            try
            {
                Type ceCompatType = AccessTools.TypeByName("CombatExtended.HarmonyCE.Compatibility.Harmony_Compat_RunAndGun");
                
                if (ceCompatType != null)
                {
                    MethodInfo targetMethod = AccessTools.Method(ceCompatType, "TargetMethod");
                    if (targetMethod != null)
                    {
                        harmony.Patch(targetMethod,
                            prefix: new HarmonyMethod(typeof(RunAndGunCEFix), nameof(TargetMethodPrefix)));
                    }

                    MethodInfo transpilerMethod = AccessTools.Method(ceCompatType, "Transpiler");
                    if (transpilerMethod != null)
                    {
                        harmony.Patch(transpilerMethod,
                            prefix: new HarmonyMethod(typeof(RunAndGunCEFix), nameof(TranspilerPrefix)));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Warning($"[RunAndGunCEFix] Error en compatibilidad: {ex}");
            }
        }

        public static bool TargetMethodPrefix(ref bool __result)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Log.Warning($"[RunAndGunCEFix] Error en TargetMethod: {ex}");
                __result = false;
                return false;
            }
        }

        public static bool TranspilerPrefix(ref IEnumerable<CodeInstruction> __result)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Log.Warning($"[RunAndGunCEFix] Transpiler falló: {ex}");
                __result = new List<CodeInstruction>();
                return false;
            }
        }
    }
}
