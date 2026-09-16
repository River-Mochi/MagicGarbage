// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// Spanish (es-ES)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Información del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** mantiene limpia toda la ciudad.\n" +
                    "\n" +
                    "Mientras **Total Magic** está activado:\n" +
                    "- Trash Boss se fuerza a desactivado.\n" +
                    "- Los deslizadores de Trash Boss no se aplican (los valores se guardan para después).\n" +
                    "- Algunos camiones aún pueden moverse por el timing de la lógica vanilla de despacho."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestiona directamente los sistemas de basura; deja funcionando la lógica vanilla de basura.\n" +
                    "\n" +
                    "- Cuando **Trash Boss está activado [ ✓ ]**, Total Magic se fuerza a desactivado.\n" +
                    "- Los deslizadores solo se aplican cuando Trash Boss está activado.\n" +
                    "- Total Magic + Trash Boss pueden estar **desactivados** para usar los ajustes vanilla,\n" +
                    "  y aun así puedes ver el **informe de estado**, que se actualiza solo al entrar en el menú Opciones (ligero)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidad de carga del camión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede llevar cada camión.**\n" +
                    "**100% = capacidad vanilla** del camión (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Almacenamiento de instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "**100% = almacenamiento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidad de procesamiento de instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan las instalaciones la basura entrante.**\n" +
                    "**100% = velocidad de procesamiento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota de instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede despachar cada instalación.**\n" +
                    "**100% = número vanilla** de camiones.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Reserva para el destino" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Indica con cuánta antelación los camiones se vuelven selectivos con las recogidas opcionales camino al edificio asignado.**\n" +
                    "**10% es el valor vanilla de la versión 1.6.2.**\n" +
                    "Para un camión normal de 20t:\n" +
                    "- 10% empieza a proteger su parada asignada 2t antes.\n" +
                    "- 15% empieza 3t antes.\n" +
                    "- 25% empieza 5t antes.\n" +
                    "Los valores más altos dan un mayor margen de seguridad. Los camiones omiten antes las recogidas pequeñas y dejan más espacio para el edificio asignado."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica valores equilibrados para ciudades con mucha actividad.\n" +
                    "Carga del camión **200%** | almacenamiento **150%** | procesamiento **250%**\n" +
                    "Flota **100%** | reserva para el destino **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Restablecer deslizadores" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Restablece los deslizadores estándar de Trash Boss.\n" +
                    "- Los deslizadores de porcentaje vuelven a **100%**.\n" +
                    "- La reserva para el destino vuelve al valor **vanilla del 10%**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nombre visible de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versión actual del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abrir la página de Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abrir la invitación de Discord en un navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado Limpieza automática>\n" +
                    "  * Total Magic activado = **[ ✓ ]**\n" +
                    "  * La basura se elimina automáticamente - listo.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Estado Gestión manual>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajusta los deslizadores como quieras.\n" +
                    "  * La misma basura del juego; camiones/instalaciones mejor gestionados manualmente.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Estado / vanilla>\n" +
                    "  * Total Magic = desactivado\n" +
                    "  * Trash Boss = desactivado\n" +
                    "  * Solo informe de estado.\n" +
                    "  * El juego vanilla de basura queda sin cambios."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Calificación del servicio de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "El efecto medio de felicidad por basura de toda la ciudad según el juego.\n" +
                    "Una buena calificación general aún puede incluir algunos edificios problemáticos, así que revisa también los **edificios con 7t+**.\n" +
                    "**0 = Excelente en general**\n" +
                    "**-1 = Necesita un pequeño ajuste**\n" +
                    "**-2 a -4 = Algo apestoso**\n" +
                    "**-5 o menos = Problema de basura**\n" +
                    "\n" +
                    "Mejora el servicio con los deslizadores de camiones e instalaciones y deja correr la ciudad antes de volver a comprobarlo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Edificios con 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Cantidad de edificios productores de basura con **7000 / 7t** o más.\n" +
                    "Este indicador fijo de alerta temprana te ayuda a decidir si debes aumentar el servicio antes de que los edificios alcancen el nivel del icono de advertencia del juego.\n" +
                    "Usa Estado detallado al log para listar sus ID de entidad."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Basura/mes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Muestra la producción de basura de toda la ciudad, el procesamiento actual y la capacidad de procesamiento disponible de las instalaciones.\n" +
                    "Aumenta el procesamiento si la producción mensual supera la capacidad.\n" +
                    "Todos los valores usan toneladas por mes."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitudes de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendientes** = solicitudes de recogida activas que actualmente no están asignadas a un camión o ruta.\n" +
                    "**Despachadas** = solicitudes de recogida activas ya asignadas.\n" +
                    "**Total** = todas las solicitudes **activas** actuales en la cadena de basura.\n" +
                    "\n" +
                    "Esto es distinto de **Por encima del umbral de solicitud**, que cuenta edificios en vez de solicitudes.\n" +
                    "Algunas solicitudes pendientes se asignarán más tarde; otras también pueden desaparecer si la revalidación vanilla decide que el objetivo ya no necesita servicio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edificios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tiene basura** = edificios que actualmente contienen basura.\n" +
                    "**Total** = todos los edificios productores de basura de la ciudad.\n" +
                    "**Por encima del umbral de solicitud** = cantidad actual de **edificios** con suficiente basura para crear una solicitud de recogida.\n" +
                    "El estado detallado del log muestra el umbral de solicitud activo actual del juego.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumen de las instalaciones de basura contadas.\n" +
                    "**Instalaciones** = edificios de basura contados.\n" +
                    "**Camiones de basura** = camiones normales de recogida. En instalaciones de residuos industriales, recogen residuos industriales en lugar de basura.\n" +
                    "**Camiones volquete** = transferencias de basura entre instalaciones.\n" +
                    "**Trabajadores máx.** = capacidad total de trabajadores de esas mismas instalaciones."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camiones de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En movimiento** = camiones que actualmente están fuera por la ciudad.\n" +
                    "**Volviendo** = subconjunto de camiones en movimiento marcados para regresar a su instalación.\n" +
                    "**Aparcados** = camiones aparcados en una instalación.\n" +
                    "**Total** = cantidad de todos los camiones de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Estado detallado al log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envía un informe de basura más detallado a **Logs/MagicGarbage.log**.\n" +
                    "Incluye estadísticas organizadas de la basura de la ciudad."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre **MagicGarbage.log**. Si falta o no se puede abrir, abre en su lugar la carpeta Logs del juego." },

                // Runtime status strings
                { "MG.Status.NoCity", "Aún no hay una ciudad cargada." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente en general ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Necesita un pequeño ajuste ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Algo apestoso ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de basura ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} edificios con 7t+" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t producidas | {2:N0} t procesadas | {1:N0} t de capacidad" },
                { "MG.Status.Row.Requests", "{1:N0} pendientes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tiene basura | {2:N0} sobre el umbral de solicitud" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalaciones | {1:N0}/{2:N0} camiones basura/volquete | {3:N0} trabajadores" },
                { "MG.Status.Row.Trucks", "{1:N0} en movimiento ({3:N0} volviendo) | {2:N0} aparcados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Aún no hay datos de instalaciones." },

                // Log strings
                { "MG.Status.Log.Title", "Estado de basura ({0})" },
                { "MG.Status.Log.City", "Ciudad: {0}" },
                { "MG.Status.Log.Mode", "Modo: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Ajustes actuales del mod" },
                { "MG.Status.Log.SettingsTrashBoss", "Deslizadores de Trash Boss (guardados): carga camión={0:N0}% | almacenamiento instalación={1:N0}% | procesamiento instalación={2:N0}% | flota instalación={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "Leyenda:\n" +
                    "- La producción, el procesamiento actual y la capacidad usan toneladas por mes.\n" +
                    "- Los valores de umbral de abajo usan unidades internas de basura, no toneladas.\n" +
                    "- Para mostrarlos al jugador, el juego convierte 100 unidades = 0.1t y 1,000 unidades = 1t.\n" +
                    "- Calificación del servicio de basura = factor de felicidad por basura de la ciudad del juego.\n" +
                    "  - 0 = Excelente en general\n" +
                    "  - -1 = Necesita un pequeño ajuste\n" +
                    "  - -2 a -4 = Algo apestoso\n" +
                    "  - -5 a -10 = Problema de basura\n" +
                    "Valores de enrutamiento:\n" +
                    "  - El umbral de recogida es el mínimo vanilla; el enrutamiento que tiene en cuenta el destino puede elevarlo por camión para proteger capacidad para su destino.\n" +
                    "  - El umbral de solicitud es la cantidad mínima de basura antes de que el juego cree o mantenga una solicitud de recogida.\n" +
                    "- El icono de advertencia aparece cuando la basura del edificio supera el nivel de advertencia activo.\n" +
                    "- Límite duro = máximo de basura que un edificio puede acumular.\n" +
                    "- Pendiente = solicitudes activas que actualmente no están asignadas a un camión o ruta.\n" +
                    "- Algunas solicitudes pendientes se asignarán más tarde; otras también pueden desaparecer si la revalidación vanilla decide que el objetivo ya no necesita servicio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Umbrales del juego (unidades internas de basura): recogida={1:N0}, solicitud={0:N0}, icono de advertencia={2:N0}, límite duro={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Umbrales: <GarbageParameterData no disponible>" },
                { "MG.Status.Log.AdaptiveMargin", "Reserva para el destino: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Reserva para el destino: actual={0:N0}% | valor base del juego al cargar={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Producción de basura: {0:N0} t/mes | Procesamiento actual: {2:N0} t/mes | Capacidad de procesamiento: {1:N0} t/mes" },
                { "MG.Status.Log.GarbageServiceRating", "Calificación del servicio de basura: {0} | bruto={1:N2} | redondeado={2:N0}" },
                { "MG.Status.Log.Requests", "Solicitudes de recogida: pendientes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Mayor cantidad de basura en un objetivo pendiente: {0:N0} ({1:N1}t) en {2}" },
                { "MG.Status.Log.PendingPeakNone", "Mayor cantidad de basura en un objetivo pendiente: ninguna" },
                { "MG.Status.Log.Producers", "Edificios: {0:N0} sobre el nivel de advertencia | {1:N0} total | {2:N0} tiene basura | {3:N0} sobre el umbral de solicitud" },
                { "MG.Status.Log.ProducerGarbageStats", "Basura de edificios (solo valores distintos de cero): prom={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) en {6}" },
                { "MG.Status.Log.NearWarning75", "Edificios cerca del icono de advertencia (al menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalaciones: {0:N0} total | {1:N0} camiones de basura | {2:N0} camiones volquete ({3:N0} en movimiento) | {4:N0} trabajadores" },
                { "MG.Status.Log.Trucks", "Camiones de basura: {2:N0} en movimiento ({3:N0} volviendo) | {1:N0} aparcados | {4:N0} desactivados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumen de instalaciones" },
                { "MG.Status.Log.FacilityLine", "- Instalación {0}: camiones de basura={1:N0} ({2:N0} en movimiento, {3:N0} aparcados) | camiones volquete={4:N0} ({5:N0} en movimiento) | trabajadores máx={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente en general" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Necesita un pequeño ajuste" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Algo apestoso" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de basura" },

                { "MG.Status.Log.ThresholdsHeader", "Umbrales + servicio" },
                { "MG.Status.Log.RequestsHeader", "Solicitudes" },
                { "MG.Status.Log.BuildingsHeader", "Edificios" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Edificios con 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonda local de transferencia de basura" },
                { "MG.Status.Log.LocalTransferProbeNone", "No se encontraron instalaciones locales de basura." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda de transferencia de basura de conexión exterior" },
                { "MG.Status.Log.OutsideTransferProbeNone", "No se encontraron instalaciones de basura de conexión exterior." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda de transferencia de basura" },
                { "MG.Status.Log.TransferProbeNone", "No se encontraron instalaciones de almacenamiento-transferencia de basura." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | almacenado={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | acepta={5:N2} | envía={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Camiones" },

                { "MG.Status.Log.CriticalBuildingsNone", "ninguno" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
