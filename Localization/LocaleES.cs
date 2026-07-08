// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Acerca de" },
                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpieza automática" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestión manual" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Usuario avanzado" },
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
                    "- Total Magic + Trash Boss pueden estar **desactivados** para obtener ajustes vanilla,\n" +
                    "  y aun así puedes ver el **informe de estado**, que se actualiza solo al entrar al menú Opciones (ligero)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "Asistencia de prioridad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "Ayuda para objetivos de basura muy sobrecargados (edificios).\n" +
                    "Cuando está **activada**, revisa si algún objetivo de solicitud activo alcanza **7000+** (**7t**) de basura.\n" +
                    "Objetivo: reduce trabajos extra de recogida lateral cuando hace falta para que los camiones lleguen antes a los peores objetivos.\n" +
                    "Es un empujón, no una anulación dura y completa de la lógica de rutas vanilla.\n" +
                    "Ligero, sin parche Harmony."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidad de carga del camión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede llevar cada camión.**\n" +
                    "**100% = valor normal** del juego (20t).\n"
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

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Se aplican los valores estándar **recomendados** de Trash Boss.\n" +
                    "No cambia los ajustes de Power User (separados)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Devuelve los deslizadores de Trash Boss a los **valores vanilla**.\n" +
                    "<No> cambia los ajustes de Power User.\n" +
                    "**Vanilla:**\n" +
                    "- Los deslizadores de porcentaje vuelven a **100%**.\n" +
                    "- El umbral de solicitud de despacho vuelve a **100 unidades**.\n" +
                    "- El umbral de recogida vuelve a **20 unidades**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opciones Power User" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Ajustes avanzados opcionales\n" +
                    "<Advertencia: NO necesario> para un buen servicio; disponible para jugadores que quieran experimentar o aprender mejor cómo funcionan los sistemas.\n" +
                    "Cuando está **desactivado**, los elementos Power User se comportan como el juego **vanilla** normal.\n" +
                    "Cuando está **activado**, aparecen los **deslizadores avanzados**.\n" +
                    "\n" +
                    "<--- Ejemplos de felicidad --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalización en <165>.\n" +
                    " - Pulsa <Recomendado> para 550/150 = 1ª penalización en <700>.\n" +
                    " - <Muy suave> 950/200 = 1ª penalización de basura en <1150>.\n" +
                    "Comodidad: los últimos valores de los deslizadores se guardan cuando esta opción está desactivada (por si quieres activarla después)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Umbral de solicitud de despacho" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Basura del edificio necesaria antes de que se cree o se mantenga una solicitud de despacho de camión.**\n" +
                    "Vanilla = **100** unidades de basura.\n" +
                    "**100 unidades de basura = 0.1t**\n" +
                    "**1,000 unidades de basura = 1t**\n" +
                    "Mantén esto igual o por encima del umbral de recogida.\n" +
                    "Normalmente aumenta cuántos camiones se usan en vez de estar aparcados."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Umbral de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Basura mínima del edificio antes de que un camión pueda recogerla.**\n" +
                    "Vanilla = **20** unidades de basura.\n" +
                    "El deslizador de recogida <no puede> ser mayor que la solicitud de despacho (DR); se limita para evitar problemas de lógica.\n" +
                    "Si un camión se despacha a un edificio y el valor de recogida es mayor que DR, a veces el camión puede no poder recoger en ese edificio (la tasa de acumulación también influye).\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nivel de basura del edificio antes de que empiece la penalización de salud + felicidad.**\n" +
                    "**Vanilla = 100** unidades de basura.\n" +
                    "Una base más alta = los edificios pueden guardar más basura antes de que empiece la penalización.\n" +
                    "100 unidades de basura = 0.1t\n" +
                    "Resumen:\n" +
                    "- <Umbral> = punto de activación del comportamiento del sistema\n" +
                    "- <Base> = punto inicial de la fórmula de penalización\n" +
                    "- <Paso> = tamaño del incremento en la fórmula, qué tan rápido sube la penalización después de empezar"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Paso de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Basura extra sobre la base que hace que empiece una penalización de -1.**\n" +
                    "Vanilla = **65** unidades de basura.\n" +
                    "Un paso más alto = crecimiento más lento de la penalización.\n" +
                    "El juego limita la penalización de basura a **-10**.\n" +
                    "La primera penalización vanilla <-1> ocurre con **165 de basura** (100 base + 65 paso)\n" +
                    "Cambiar umbrales con los deslizadores de felicidad puede causar penalizaciones más fuertes de lo normal."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tasa de acumulación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Escala los valores fuente de basura de edificios compatibles.**\n" +
                    "Cuidado: es una palanca fuerte y cambiar la tasa afecta muchas cosas.\n" +
                    "Se puede lograr un buen sistema sin usar esto.\n" +
                    "\n" +
                    "**100% = tasa de acumulación vanilla**.\n" +
                    "**20%** = acumulación mucho más lenta.\n" +
                    "**200%** = tasa doble - muchísima basura.\n" +
                    "Al 20%, obviamente todos los Cims hacen compost, por eso la tasa de acumulación es mucho menor ;)\n" +
                    "\n" +
                    "Nota técnica: el juego añade basura gradualmente durante el día, no toda de golpe."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica los valores Power User **recomendados**.\n" +
                    "Activa Power User.\n" +
                    "La primera penalización de basura empieza en **700** de basura (550 base + 150 paso).\n" +
                    "La tasa de acumulación de basura permanece en **100%** vanilla salvo que se cambie manualmente."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Devuelve todos los valores de Power User **a vanilla**.\n" +
                    "Desactiva **Power User**.\n"
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
                    "  * Opcional: activa los deslizadores avanzados (no requerido).\n" +
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
                    "Calificación simple de felicidad por basura del juego.\n" +
                    "**0 = Excelente**\n" +
                    "**-1 **= Necesita pequeño ajuste. El juego suele variar entre 0 y -1 y se puede ignorar (el número está redondeado).\n" +
                    "**-2 a -4** = Algo apestoso\n" +
                    "**-5 a -10** = Problema de basura\n" +
                    "**Ajustes indirectos:** usa los <deslizadores de basura> para mejorar esto con el tiempo reduciendo la acumulación.\n" +
                    "**Ajustes directos:** Base de felicidad por basura + Paso de felicidad por basura cambian <lo que toleran los cims> antes de estar descontentos.\n" +
                    "**Tasa de acumulación de basura**: cambia qué tan rápido los edificios compatibles producen basura. Úsalo con cuidado porque el equilibrio importa. La mayoría de jugadores nunca necesita tocar esto.\n" +
                    "<Hora de actualización = último refresco.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Edificios 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Cantidad de edificios productores de basura en o por encima de **7t / 7000** de basura.\n" +
                    "Son edificios muy sobrecargados; activa [x] Asistencia de prioridad para priorizarlos mejor.\n" +
                    "Usa el botón de estado al log si quieres los números de ID de entidad para inspeccionar."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Basura/mes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Muestra la cantidad actual de basura de la ciudad y la tasa total de procesamiento de basura.\n" +
                    "Aumenta el procesamiento si la basura mensual producida es mucho mayor.\n" +
                    "**Producida** y **Procesada** usan toneladas por mes."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitudes de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendientes** = solicitudes de recogida activas que aún no están asignadas a un camión o ruta.\n" +
                    "**Despachadas** = solicitudes de recogida activas ya asignadas.\n" +
                    "**Total** = cuenta la entidad de solicitud **activa** actual (en la cadena de basura).\n" +
                    "\n" +
                    "Nota técnica: esto es distinto de <Por encima del umbral de solicitud>. Esto cuenta <solicitudes>, no edificios.\n" +
                    "Algunas solicitudes pendientes se asignarán más tarde; otras también pueden limpiarse si la revalidación vanilla decide que el objetivo ya no necesita servicio."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edificios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tiene basura** = edificios que actualmente contienen basura.\n" +
                    "**Total** = todos los edificios productores de basura de la ciudad.\n" +
                    "**Por encima del umbral de solicitud** = cantidad actual de **edificios** con suficiente basura para crear una solicitud de recogida.\n" +
                    "En vanilla, el umbral de solicitud es **100** unidades internas de basura.\n" +
                    "Las opciones Power User pueden sobrescribir los umbrales de solicitud y recogida.\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumen de instalaciones de basura contadas.\n" +
                    "**Instalaciones** = edificios de basura contados.\n" +
                    "**Camiones de basura** = camiones normales de recogida. En instalaciones de residuos industriales, recogen residuos industriales en lugar de basura.\n" +
                    "**Dump trucks** = transferencias de basura entre instalaciones.\n" +
                    "**Trabajadores máx.** = capacidad total de trabajadores en esas mismas instalaciones."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camiones de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moviéndose** = camiones actualmente en la ciudad.\n" +
                    "**Volviendo** = subconjunto de camiones en movimiento marcados para regresar a su instalación.\n" +
                    "**Aparcados** = camiones aparcados en una instalación.\n" +
                    "**Total** = cantidad de todos los camiones de basura."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Estado detallado al log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envía un informe de basura más detallado a **Logs/MagicGarbage.log**.\n" +
                    "Incluye estadísticas organizadas de basura de la ciudad"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre la carpeta Logs/.. del juego." },

                // Runtime status strings
                { "MG.Status.NoCity", "Aún no hay ciudad cargada." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Necesita pequeño ajuste ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Algo apestoso ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de basura ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} sobre 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t producidas | {1:N0} t procesadas" },
                { "MG.Status.Row.Requests", "{1:N0} pendientes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tiene basura | {2:N0} sobre el umbral de solicitud" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalaciones | {1:N0}/{2:N0} camiones basura/dump trucks | {3:N0} trabajadores" },
                { "MG.Status.Row.Trucks", "{1:N0} moviéndose ({3:N0} volviendo) | {2:N0} aparcados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Aún no hay datos de instalaciones." },

                // Log strings
                { "MG.Status.Log.Title", "Estado de basura ({0})" },
                { "MG.Status.Log.City", "Ciudad: {0}" },
                { "MG.Status.Log.Mode", "Modo: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Ajustes actuales del mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Deslizadores Trash Boss (guardados): carga camión={0:N0}% | almacenamiento instalación={1:N0}% | procesamiento instalación={2:N0}% | flota instalación={3:N0}%"
                },
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User (guardado): activado={0} | solicitud={1:N0} | recogida={2:N0} | base felicidad={3:N0} | paso felicidad={4:N0} | tasa acumulación={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Leyenda:\n" +
                    "- Producida/Procesada usa toneladas por mes.\n" +
                    "- Los valores de umbral de abajo usan unidades internas de basura, no toneladas.\n" +
                    "- Para mostrarlo al jugador, el juego convierte 100 unidades = 0.1t y 1,000 unidades = 1t.\n" +
                    "- Calificación del servicio de basura = factor de felicidad por basura de la ciudad.\n" +
                    "  - 0 = Excelente\n" +
                    "  - -1 = Necesita pequeño ajuste, o ignorar\n" +
                    "  - -2 a -4 = Algo apestoso\n" +
                    "  - -5 a -10 = Problema de basura\n" +
                    "Deslizadores de umbral:\n" +
                    "  - Umbral de recogida = basura mínima antes de que un camión recoja de un edificio.\n" +
                    "  - Umbral de solicitud = basura mínima antes de que el juego cree o mantenga una solicitud de recogida.\n" +
                    "- Icono de advertencia = cantidad de basura que provoca un icono de advertencia sobre un edificio.\n" +
                    "- Límite duro = máximo de basura que un edificio puede acumular.\n" +
                    "- Pendiente = solicitudes activas no asignadas actualmente a un camión o ruta.\n" +
                    "- Algunas solicitudes pendientes se asignarán más tarde; otras también pueden limpiarse si la revalidación vanilla decide que el objetivo ya no necesita servicio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Umbrales del juego (unidades internas de basura): recogida={1:N0}, solicitud={0:N0}, icono de advertencia={2:N0}, límite duro={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Umbrales: <GarbageParameterData no disponible>" },
                { "MG.Status.Log.GarbageProcessing", "Basura: {0:N0} t/mes | Procesamiento: {1:N0} t/mes" },
                { "MG.Status.Log.GarbageServiceRating", "Calificación del servicio de basura: {0} | bruto={1:N2} | redondeado={2:N0}" },
                { "MG.Status.Log.Requests", "Solicitudes de recogida: pendientes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Objetivo pendiente más alto: {0:N0} ({1:N1}t) en {2}" },
                { "MG.Status.Log.PendingPeakNone", "Objetivo pendiente más alto: ninguno" },
                { "MG.Status.Log.Producers", "Edificios: {0:N0} iconos de advertencia | {1:N0} total | {2:N0} tiene basura | {3:N0} sobre el umbral de solicitud " },
                { "MG.Status.Log.ProducerGarbageStats", "Basura de edificios (solo no cero): prom={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) en {6}" },
                { "MG.Status.Log.NearWarning75", "Edificios cerca del icono de advertencia (al menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalaciones: {0:N0} total | {1:N0} camiones de basura | {2:N0} dump trucks ({3:N0} moviéndose) | {4:N0} trabajadores" },
                { "MG.Status.Log.Trucks", "Camiones de basura: {2:N0} moviéndose ({3:N0} volviendo) | {1:N0} aparcados | {4:N0} desactivados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumen de instalaciones" },
                { "MG.Status.Log.FacilityLine",
                    "- Instalación {0}: camiones de basura={1:N0} ({2:N0} moviéndose, {3:N0} aparcados) | dump trucks={4:N0} ({5:N0} moviéndose) | trabajadores máx={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Necesita pequeño ajuste" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Algo apestoso" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de basura" },

                { "MG.Status.Log.ThresholdsHeader", "Umbrales + servicio" },
                { "MG.Status.Log.RequestsHeader", "Solicitudes" },
                { "MG.Status.Log.BuildingsHeader", "Edificios" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Edificios críticos sobre 7t" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonda local de transferencia de basura" },
                { "MG.Status.Log.LocalTransferProbeNone", "No se encontraron instalaciones locales de basura." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda de transferencia de basura de conexión exterior" },
                { "MG.Status.Log.OutsideTransferProbeNone", "No se encontraron instalaciones de basura de conexión exterior." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda de transferencia de basura" },
                { "MG.Status.Log.TransferProbeNone", "No se encontraron instalaciones de almacenamiento-transferencia de basura." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | almacenado={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | acepta={5:N2} | envía={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "Camiones" },
                { "MG.Status.Log.SettingsPriority", "Sistema de prioridad (guardado): activado={0} | disparador={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState",
                    "Asistencia de prioridad activa={0} | intervalo={1:N0} frames | últimos edificios escaneados={2:N0} | edificios críticos={3:N0}"
                },
                { "MG.Status.Log.PriorityPeak", "Edificio crítico más alto: {0:N0} ({1:N1}t) | {2} | solicitud={3}" },

                { "MG.Status.Log.PriorityHeader", "Asistencia de prioridad" },
                { "MG.Status.Log.PriorityPasses", "Pasadas de prioridad: elevadas={0:N0} | normales={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "Edificio crítico activo más alto: ninguno" },
                { "MG.Status.Log.PriorityPeakState.Pending", "pendiente" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "despachada" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Tiempo del último escaneo de asistencia de prioridad={0:N3} ms" },
#endif
                { "MG.Status.Log.CriticalBuildingsNone", "ninguno" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
