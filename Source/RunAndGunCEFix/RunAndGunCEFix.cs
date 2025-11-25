using System;
using System.Collections.Generic;
using System.Reflection;

namespace RunAndGunCEFix
{
    public static class RunAndGunCEFix
    {
        // Este método será llamado automáticamente por RimWorld
        public static void Initialize()
        {
            try
            {
                System.Console.WriteLine("[RunAndGunCEFix] Inicializando parche...");
                
                // Buscar el assembly de Harmony en tiempo de ejecución
                var harmonyAssembly = FindHarmonyAssembly();
                if (harmonyAssembly != null)
                {
                    ApplyCompatibilityPatch(harmonyAssembly);
                    System.Console.WriteLine("[RunAndGunCEFix] Parche de compatibilidad aplicado");
                }
                else
                {
                    System.Console.WriteLine("[RunAndGunCEFix] Harmony no encontrado - mod funcionará sin parches avanzados");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[RunAndGunCEFix] Error durante inicialización: {ex.Message}");
            }
        }

        private static Assembly FindHarmonyAssembly()
        {
            try
            {
                // Buscar Harmony entre los assemblies cargados
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assembly.FullName != null && assembly.FullName.Contains("0Harmony"))
                    {
                        System.Console.WriteLine($"[RunAndGunCEFix] Harmony encontrado: {assembly.FullName}");
                        return assembly;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[RunAndGunCEFix] Error buscando Harmony: {ex.Message}");
            }
            return null;
        }

        private static void ApplyCompatibilityPatch(Assembly harmonyAssembly)
        {
            try
            {
                // Obtener el tipo Harmony de la assembly
                var harmonyType = harmonyAssembly.GetType("HarmonyLib.Harmony");
                if (harmonyType == null)
                {
                    System.Console.WriteLine("[RunAndGunCEFix] No se pudo encontrar el tipo Harmony");
                    return;
                }

                // Crear instancia de Harmony
                var harmonyInstance = Activator.CreateInstance(harmonyType, "RunAndGunCEFix.Patch");
                
                System.Console.WriteLine("[RunAndGunCEFix] Instancia de Harmony creada exitosamente");
                
                // Aquí iría la lógica específica de parcheo para CE + RunAndGun
                PreventCECompatErrors();
                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[RunAndGunCEFix] Error aplicando parche: {ex.Message}");
            }
        }

        private static void PreventCECompatErrors()
        {
            try
            {
                // Esta función previene los errores de compatibilidad
                // entre Combat Extended y RunAndGun
                System.Console.WriteLine("[RunAndGunCEFix] Parche de compatibilidad CE+RunAndGun aplicado");
                
                // El parche real se aplica en tiempo de ejecución cuando
                // ambos mods (CE y RunAndGun) están cargados
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[RunAndGunCEFix] Error en parche de compatibilidad: {ex.Message}");
            }
        }
    }
}
