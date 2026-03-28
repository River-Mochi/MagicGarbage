// File: Localization/LocaleES.cs
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Acerca de" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpieza auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestión manual" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** mantiene toda la ciudad limpia.\n\n" +
                    "Mientras **Total Magic** está activado:\n" +
                    "- Trash Boss se fuerza a OFF.\n" +
                    "- Los controles de Trash Boss no se aplican (los valores se guardan para después).\n" +
                    "- Algunos camiones aún pueden moverse por el tiempo de despacho vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestiona directamente los sistemas de basura; deja funcionando la lógica vanilla.\n\n" +
                    "- Cuando **Trash Boss está activado [ ✓ ]**, Total Magic se fuerza a OFF.\n" +
                    "- Los controles solo se aplican cuando Trash Boss está activado.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidad de carga" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede llevar cada camión.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Almacenamiento de instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidad de proceso" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan la basura entrante las instalaciones.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility Fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede enviar cada instalación.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "Umbrales de edificios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "Opcional: sube los **umbrales** que un edificio necesita para recibir recogida de basura. \n" +
                    "Aumentar esto puede ayudar a reducir el tráfico de camiones de basura; pero demasiado alto reduce los viajes de recogida.\n" +
                    "La mayoría de la gente <no> necesita ajustar esto. El mod ya funcionaba bien antes de esta opción; es solo un extra para experimentar.\n"+
                    "--------------------------------\n" +
                    "- **Umbral de solicitud de despacho (R)** = basura del edificio necesaria para llamar una <solicitud de despacho de camión>.\n" +
                    "- **Umbral de recogida (P)** = basura mínima del edificio antes de que un camión pueda recogerla.\n" +
                    "**1x** = vanilla (100 R, 20 P). Nota: **1.000** unidades de basura suelen ser **1t**.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "Con el control en **20x**, la **R** del edificio debe llegar a >= **2.000 (2t)** unidades antes de que un camión reciba una <solicitud de despacho>;\n" +
                    "El juego vanilla también hace que los camiones paren en edificios de ida/vuelta al edificio de <dispatch> si el camión no está vacío; a 20x, los edificios de la ruta necesitan más de **400 de basura** (20 x P vanilla = 20).\n" +
                    "Consejo de equilibrio: mira el botón del informe detallado en el log con frecuencia mientras ajustas esto.\n" +
                    "Puede que necesites aumentar la capacidad de los camiones si subes mucho el umbral, porque las casas mantendrán la basura mucho más tiempo antes de llamar a un camión."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica los valores recomendados de Trash Boss:\n" +
                    "- Capacidad de carga: **200%**\n" +
                    "- Umbral de despacho: **5x**\n" +
                    "- Velocidad de proceso: **200%**\n" +
                    "- Capacidad de almacenamiento: **150%**\n" +
                    "- Cantidad de camiones de la instalación: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Devuelve todos los controles de Trash Boss a los valores vanilla.\n" +
                    "- Los controles porcentuales vuelven a **100%**.\n" +
                    "- El umbral de despacho vuelve a **1x**."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nombre mostrado de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versión actual del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abre la página de Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre la invitación de Discord en tu navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado Auto Clean>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * La basura se elimina automáticamente - Listo.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado gestión manual>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajusta los controles a tu gusto.\n" +
                    "  * Misma basura del juego; mejores camiones/instalaciones autogestionados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Juego vanilla normal>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * Todos los controles en valores vanilla\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Basura/mes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Muestra la cantidad actual de basura en toda la ciudad y la tasa total de procesamiento.\n" +
                    "Aumenta el procesamiento si la basura producida al mes es mucho mayor.\n" +
                    "**Producido** y **Procesado** usan toneladas por mes.\n" +
                    "<Hora de actualización = última actualización.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitudes de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendientes** = solicitudes de recogida activas que no están asignadas actualmente a un camión o ruta.\n" +
                    "**Despachadas** = solicitudes de recogida activas ya asignadas.\n" +
                    "**Total** = cuenta la entidad de solicitud **activa** actual (en la cadena de basura).\n\n" +
                    "Nota técnica: esto es diferente de <Por encima del umbral de solicitud>. Esto cuenta <solicitudes>, no edificios.\n" +
                    "Algunas solicitudes pendientes se asignarán después; otras también pueden borrarse más tarde si la revalidación vanilla decide que el objetivo ya no necesita servicio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tiene basura** = edificios que actualmente guardan basura.\n" +
                    "**Total** = todos los edificios productores de basura de la ciudad.\n" +
                    "**Por encima del umbral de solicitud** = cantidad actual de **edificios** con basura suficiente para crear una solicitud de recogida.\n" +
                    "En vanilla, el umbral de solicitud es **100** unidades internas de basura.\n" +
                    "El **umbral de despacho** de Trash Boss sube juntos los umbrales de recogida y solicitud.\n" +
                    "Esto reduce el tráfico de camiones de basura porque baja el total de edificios <por encima del umbral de solicitud> y el total <despachado>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Facilities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumen de las instalaciones de basura contadas.\n" +
                    "**Instalaciones** = edificios de basura contados.\n" +
                    "**Camiones totales** = camiones de basura propiedad de esas instalaciones.\n" +
                    "**Trabajadores máx.** = capacidad total de trabajadores en esas mismas instalaciones."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En movimiento** = camiones actualmente por la ciudad.\n" +
                    "**Regresando** = subconjunto de camiones en movimiento marcados para volver a su instalación.\n" +
                    "**Aparcados** = camiones aparcados en una instalación.\n" +
                    "**Total** = cantidad de todos los camiones de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Estado detallado al log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envía un informe de basura más detallado a **Logs/MagicGarbage.log**.\n" +
                    "Incluye una leyenda corta, valores de referencia vanilla y muchas estadísticas extra reales de basura de la ciudad."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre la carpeta Logs/.. del juego."
                },

            // Runtime status strings
            { "MG.Status.NoCity", "Todavía no hay ninguna ciudad cargada." },

            { "MG.Status.Row.GarbageProcessing", "{0:N0} t producidas | {1:N0} t procesadas | act. {2}" },
            { "MG.Status.Row.Requests", "{1:N0} pendientes | {2:N0} despachadas | {0:N0} total" },
            { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tienen basura | {2:N0} por encima del umbral de solicitud" },
            { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalaciones | {1:N0} camiones totales | {2:N0} trabajadores máx." },
            { "MG.Status.Row.Trucks", "{1:N0} en movimiento ({3:N0} regresando) | {2:N0} aparcados | {0:N0} total" },
            { "MG.Status.Row.FacilitiesNone", "Todavía no hay datos de instalaciones." },

            // Log strings
            { "MG.Status.Log.Title", "Estado de basura ({0})" },
            { "MG.Status.Log.City", "Ciudad: {0}" },
            { "MG.Status.Log.Mode", "Modo: Total Magic={0}, Trash Boss={1}" },
            { "MG.Status.Log.Legend",
                "Leyenda:\n" +
                "- Producida/Procesada usa toneladas por mes.\n" +
                "- Los valores de umbral de abajo usan unidades internas de basura, no toneladas.\n" +
                "- Para el jugador, el juego convierte 1.000 unidades = 1t.\n" +
                "Control deslizante de umbral de despacho:\n" +
                "  - Umbral de recogida = basura mínima antes de que un camión recoja en un edificio.\n" +
                "  - Umbral de solicitud = basura mínima antes de que el juego cree o mantenga una solicitud de recogida.\n" +
                "- Icono de aviso = cantidad de basura que hace aparecer un icono de aviso sobre un edificio.\n" +
                "- Límite máximo = cantidad máxima de basura que un edificio puede acumular.\n" +
                "- Pendiente = solicitudes activas que actualmente no están asignadas a un camión ni a una ruta.\n" +
                "- Algunas solicitudes pendientes se asignarán más tarde; otras también pueden desaparecer después si la revalidación vanilla decide que el objetivo ya no necesita servicio.\n" +
                "-----------------------------------------------------------------------------\n"
            },
            { "MG.Status.Log.Thresholds",
                "Umbrales del juego (unidades internas de basura): recogida={1:N0}, solicitud={0:N0}, icono de aviso={2:N0}, límite máximo={3:N0}"
            },

            { "MG.Status.Log.ThresholdsMissing", "Umbrales: <GarbageParameterData no disponible>" },
            { "MG.Status.Log.GarbageProcessing", "Basura: {0:N0} t/mes | Procesamiento: {1:N0} t/mes" },
            { "MG.Status.Log.Requests", "Solicitudes de recogida: pendientes={1:N0}, despachadas={2:N0}, total={0:N0}" },
            { "MG.Status.Log.PendingPeak", "Objetivo pendiente con más basura: {0:N0} ({1:N1}t) en {2}" },
            { "MG.Status.Log.Producers", "Edificios: {0:N0} total | {1:N0} tienen basura | {2:N0} por encima del umbral de solicitud | {3:N0} a nivel de aviso" },
            { "MG.Status.Log.ProducerGarbageStats", "Basura en edificios (solo no cero): prom={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) en {6}" },
            { "MG.Status.Log.NearWarning75", "Edificios cerca del aviso (>= {1:N0} unidades / {2:N1}t): {0:N0}" },
            { "MG.Status.Log.FacilitiesSummary", "Instalaciones: {0:N0} total | {1:N0} camiones totales | {2:N0} trabajadores máx." },
            { "MG.Status.Log.Trucks", "Camiones de basura: {2:N0} en movimiento ({3:N0} regresando) | {1:N0} aparcados | {4:N0} deshabilitados | {0:N0} total" },
            { "MG.Status.Log.FacilitiesHeader", "Resumen de instalaciones" },
            { "MG.Status.Log.FacilityLine", "- Instalación {0}: en movimiento={2:N0}, aparcados={3:N0}, total={1:N0}, trabajadores máx.={4:N0}" },


            };
        }

        public void Unload()
        {
        }
    }
}
