// File: Locale/LocaleES.cs
// Spanish (es-ES)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Acerca de" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpieza automática" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestión manual" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Estado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** mantiene limpia toda la ciudad.\n\n" +
                    "Mientras **Total Magic** esté ON:\n" +
                    "- Trash Boss se fuerza a OFF.\n" +
                    "- Los deslizadores de Trash Boss no se aplican (los valores se guardan para después).\n" +
                    "- Algunos camiones aún pueden moverse debido al timing de la lógica de despacho vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Permite gestionar directamente el sistema de basura manteniendo la lógica vanilla.\n\n" +
                    "- Cuando **Trash Boss está ON [ ✓ ]**, Total Magic se fuerza a OFF.\n" +
                    "- Los deslizadores solo se aplican cuando Trash Boss está activado.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidad de carga de camiones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede transportar cada camión.**\n" +
                    "100% = valor normal del juego.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidad de procesamiento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido las instalaciones procesan la basura entrante.**\n" +
                    "100% = velocidad vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Capacidad de almacenamiento de la instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "100% = almacenamiento vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota de la instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede enviar cada instalación.**\n" +
                    "100% = número vanilla de camiones.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica los valores recomendados de Trash Boss:\n" +
                    "- Capacidad de carga de camiones: **200%**\n" +
                    "- Velocidad de procesamiento: **200%**\n" +
                    "- Capacidad de almacenamiento: **160%**\n" +
                    "- Cantidad de camiones por instalación: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Vuelve todos los deslizadores a **100%** (valores vanilla)."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nombre mostrado de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versión actual del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abre la página de Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre la invitación de Discord en el navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Modo limpieza automática>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Toda la basura se elimina al instante\n" +
                    " <-------------------------------------->\n\n" +
                    "<Modo gestión manual>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajusta los deslizadores como quieras.\n" +
                    "  * Lógica vanilla de basura con mejor gestión de camiones/instalaciones.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Juego vanilla normal>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Haz clic en **[Valores del juego]**\n" +
                    "  * Todos los deslizadores a 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Basura/mes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Muestra la cantidad actual de basura en toda la ciudad y la tasa total de procesamiento.\n" +
                    "Aumenta el procesamiento si la basura producida por mes es mucho mayor.\n" +
                    "**Produced** y **Processed** usan toneladas por mes.\n" +
                    "Hora de actualización = última actualización."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitudes de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = solicitudes activas de recogida que aún no tienen camión o ruta asignada.\n" +
                    "**Dispatched** = solicitudes activas de recogida ya asignadas.\n" +
                    "**Total** = todas las solicitudes activas de recogida de basura.\n" +
                    "Esto puede ser temporalmente mayor que **Above request threshold** porque las solicitudes antiguas se limpian más tarde con la revalidación del juego."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edificios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = edificios que actualmente tienen basura.\n" +
                    "**Total** = todos los edificios que producen basura en la ciudad.\n" +
                    "**Above request threshold** = edificios con suficiente basura para crear una solicitud de recogida.\n" +
                    "Normalmente esto significa más de <100> unidades de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumen de las instalaciones de basura contadas.\n" +
                    "**Facilities** = edificios de basura contados.\n" +
                    "**Trucks total** = camiones de basura propiedad de esas instalaciones.\n" +
                    "**Max workers** = capacidad total de trabajadores de esas mismas instalaciones."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camiones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = camiones circulando actualmente por la ciudad.\n" +
                    "**Returning** = subconjunto de camiones en movimiento que vuelven a su instalación.\n" +
                    "**Parked** = camiones aparcados en una instalación.\n" +
                    "**Total** = cantidad total de camiones de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Estado detallado al log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Escribe un informe detallado de basura en **Logs/MagicGarbage.log**.\n" +
                    "Incluye una leyenda corta, umbrales en vivo, camiones desactivados y el máximo de trabajadores por instalación."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre la carpeta Logs/."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Todavía no hay ciudad cargada." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t producidas | {1:N0} t procesadas | actualizado {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pendientes | {2:N0} asignadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tienen basura | {2:N0} por encima del umbral de solicitud" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalaciones | {1:N0} camiones en total | {2:N0} trabajadores máx." },
                { "MG.Status.Row.Trucks", "{1:N0} moviéndose ({3:N0} regresando) | {2:N0} aparcados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Todavía no hay datos de instalaciones." },

                // Log strings
                { "MG.Status.Log.Title", "Estado de basura ({0})" },
                { "MG.Status.Log.City", "Ciudad: {0}" },
                { "MG.Status.Log.Mode", "Modo: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Leyenda:\n" +
                    "- Produced/Processed usa toneladas por mes.\n" +
                    "- Los valores de umbral de abajo usan unidades internas de basura, no toneladas.\n" +
                    "- Pickup threshold = basura mínima antes de que un camión recoja en un edificio.\n" +
                    "- Request threshold = basura mínima antes de que el juego cree o mantenga una solicitud de recogida.\n" +
                    "- Warning threshold = cantidad de basura a partir de la cual puede aparecer el icono de advertencia sobre un edificio.\n" +
                    "- Hard cap = cantidad máxima de basura que puede acumular un edificio.\n" +
                    "- Returning = subconjunto de camiones en movimiento.\n" +
                    "- El número de solicitudes activas puede superar temporalmente a los edificios por encima del umbral porque las solicitudes antiguas se limpian más tarde con la revalidación vanilla.\n" +
                    "- Los números de trabajadores de abajo muestran actualmente los **trabajadores máximos** de cada instalación."
                },
                { "MG.Status.Log.Thresholds",
                    "Umbrales (unidades internas de basura): recogida={1:N0}, solicitud={0:N0}, advertencia={2:N0}, límite duro={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Umbrales: <GarbageParameterData no disponible>" },
                { "MG.Status.Log.GarbageProcessing", "Basura: {0:N0} t/mes | Procesamiento: {1:N0} t/mes" },
                { "MG.Status.Log.Requests", "Solicitudes de recogida: pendientes={1:N0}, asignadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.Producers", "Edificios: {0:N0} total | {1:N0} tienen basura | {2:N0} por encima del umbral de solicitud | {3:N0} nivel de advertencia" },
                { "MG.Status.Log.FacilitiesSummary", "Instalaciones: {0:N0} total | {1:N0} camiones total | {2:N0} trabajadores máx." },
                { "MG.Status.Log.Trucks", "Camiones de basura: {2:N0} moviéndose ({3:N0} regresando) | {1:N0} aparcados | {4:N0} desactivados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumen de instalaciones" },
                { "MG.Status.Log.FacilityLine", "- Instalación {0}: moving={2:N0}, parked={3:N0}, total={1:N0}, max workers={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
