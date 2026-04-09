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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpieza auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestión directa" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Modo experto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Estado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** mantiene limpia toda la ciudad.\n\n" +
                    "Mientras **Magia total** está ON:\n" +
                    "- Gestión de basura se fuerza a OFF.\n" +
                    "- Los deslizadores de Gestión de basura no se aplican (los valores se guardan para después).\n" +
                    "- Algunos camiones aún pueden moverse por el timing de despacho vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Gestión de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestiona directamente los sistemas de basura; la lógica vanilla sigue funcionando.\n\n" +
                    "- Cuando **Gestión de basura** está ON [ ✓ ], Magia total se fuerza a OFF.\n" +
                    "- Los deslizadores solo se aplican cuando Gestión de basura está activada.\n" +
                    "- Magia total + Gestión de basura pueden estar en **OFF** si solo se necesita el **informe de estado**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidad de carga" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede llevar cada camión.**\n" +
                    "**100% = valor normal** del juego.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Almacenamiento de instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "**100% = almacenamiento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidad de procesamiento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan la basura entrante las instalaciones.**\n" +
                    "**100% = velocidad de procesamiento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota de instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede enviar cada instalación.**\n" +
                    "**100% = cantidad vanilla** de camiones.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**Recomendado**: aplica los valores estándar de Gestión de basura.\n" +
                    "No cambia los ajustes del modo experto (separados)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Devuelve los deslizadores de Gestión de basura a los **valores vanilla**.\n" +
                    "No cambia <los ajustes del modo experto>.\n" +
                    "**Vanilla:**\n" +
                    "- Los deslizadores porcentuales vuelven a **100%**.\n" +
                    "- El Umbral de solicitud de despacho vuelve a **100 unidades**.\n" +
                    "- El Umbral de recogida vuelve a **20 unidades**.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opciones del modo experto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Ajustes avanzados opcionales\n" +
                    "<Aviso: NO hacen falta> para un buen servicio; están para jugadores que quieran probar o entender mejor cómo funciona el sistema.\n" +
                    "Cuando está en **OFF**, todos los ajustes del modo experto **se quedan vanilla**.\n" +
                    "Cuando está en **ON**, **aparecen los deslizadores avanzados**.\n\n" +
                    "<--- Ejemplos de felicidad --->\n" +
                    " - <Vanilla> 100/65 = 1.ª penalización en <165>.\n" +
                    " - Pulsa <Recomendado> para 550/150 = 1.ª penalización en <700>.\n" +
                    " - <Muy suave> 950/200 = 1.ª penalización por basura en <1150>.\n" +
                    "Comodidad: los últimos valores de los deslizadores se guardan cuando esta opción está en OFF (por si luego se quiere activar)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Umbral de solicitud de despacho" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Basura que necesita un edificio antes de que se cree o mantenga una solicitud de despacho de camión.**\n" +
                    "Vanilla = **100** unidades de basura.\n" +
                    "**100 unidades de basura = 0.1t**\n" +
                    "**1.000 unidades de basura = 1t**\n" +
                    "Mantén este valor igual o por encima del Umbral de recogida.\n" +
                    "Esto suele aumentar cuántos camiones se usan frente a los que quedan aparcados."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Umbral de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Basura mínima en un edificio antes de que un camión pueda recogerla.**\n" +
                    "Vanilla = **20** unidades de basura.\n" +
                    "El deslizador de recogida <no puede> ser mayor que la Solicitud de despacho (DR); se limita para evitar fallos de lógica.\n" +
                    "Si se envía un camión a un edificio y el valor de recogida es mayor que la DR, a veces el camión puede no llegar a recoger en ese edificio (la tasa de acumulación también influye).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nivel de basura de un edificio antes de que empiece a causar penalización de salud + felicidad.**\n" +
                    "**Vanilla = 100** unidades de basura.\n" +
                    "Base más alta = los edificios pueden aguantar más basura antes de que empiece la penalización.\n" +
                    "100 unidades de basura = 0.1t\n" +
                    "Resumen:\n" +
                    "- <Threshold> = punto de activación del sistema\n" +
                    "- <Baseline> = punto de inicio de la fórmula de penalización\n" +
                    "- <Step> = tamaño del incremento en la fórmula; qué tan rápido sube la penalización después de empezar"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Paso de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Basura extra por encima de la base que hace que empiece una penalización de -1.**\n" +
                    "Vanilla = **65** unidades de basura.\n" +
                    "Paso más alto = crecimiento más lento de la penalización.\n" +
                    "El juego limita la penalización por basura a **-10**.\n" +
                    "La primera penalización vanilla <-1 penalty> ocurre con **165 de basura** (100 de base + 65 de paso)\n" +
                    "Cambiar los umbrales sin equilibrar los deslizadores de felicidad puede provocar penalizaciones más duras de lo normal."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tasa de acumulación de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Escala los valores de fuente de basura de los edificios compatibles.**\n" +
                    "Es una palanca fuerte y cambiar esta tasa afecta a muchas cosas.\n" +
                    "Se puede conseguir un buen sistema sin usarla.\n\n" +
                    "**100% = acumulación vanilla**.\n" +
                    "**20%** = acumulación mucho más lenta.\n" +
                    "**200%** = doble de ritmo; un montón de basura.\n" +
                    "Con 20%, está clarísimo que todos los cims están compostando, así que la basura se acumula menos ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica los valores **recomendados** del modo experto.\n" +
                    "Activa el modo experto.\n" +
                    "La primera penalización por basura empieza con **700** de basura (550 de base + 150 de paso).\n" +
                    "La Tasa de acumulación de basura se queda en **100%** vanilla salvo que se cambie manualmente."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Devuelve los valores del modo experto **a vanilla**.\n" +
                    "Pone el **modo experto** en OFF.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nombre mostrado de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versión actual del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abre la página de Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre la invitación de Discord en un navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado de autolimpieza>\n" +
                    "  * Magia total ON = **[ ✓ ]**\n" +
                    "  * La basura se elimina automáticamente - listo.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de gestión directa>\n" +
                    "  * Gestión de basura = **[ ✓ ]**\n" +
                    "  * Ajusta los deslizadores como quieras.\n" +
                    "  * Opcional: activa los deslizadores avanzados (no es obligatorio).\n" +
                    "  * Misma basura del juego; camiones/instalaciones mejor gestionados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de estado / vanilla>\n" +
                    "  * Magia total = OFF\n" +
                    "  * Gestión de basura = OFF\n" +
                    "  * Solo informe de estado.\n" +
                    "  * El sistema de basura vanilla no cambia."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Valoración del servicio de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Valor simple de felicidad por basura de toda la ciudad según el juego.\n" +
                    "**0 = Excelente**\n" +
                    "**-1 = Necesita un retoque menor** el juego puede moverse bastante entre 0 y -1, y se puede ignorar.\n" +
                    "**-2 a -4 = Un poco pestilente**\n" +
                    "**-5 a -10 = Problema de basura**\n" +
                    "**Ajustes indirectos:** los deslizadores de camiones/instalaciones/umbrales pueden mejorar esto con el tiempo reduciendo la acumulación real de basura.\n" +
                    "**Ajustes directos:** <Base de felicidad por basura> + <Paso de felicidad por basura> cambian lo que los cims toleran antes de enfadarse.\n" +
                    "**Ajuste del ritmo fuente:** <Tasa de acumulación de basura> cambia la velocidad a la que los edificios compatibles producen basura."
                },

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
                    "**Total** = cuenta la solicitud **activa** actual (en la cadena de basura).\n\n" +
                    "Nota técnica: esto es diferente de <Por encima del umbral de solicitud>. Esto cuenta <solicitudes>, no edificios.\n" +
                    "Algunas solicitudes pendientes se asignarán después; otras también pueden borrarse más tarde si la revalidación vanilla decide que el objetivo ya no necesita servicio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edificios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tiene basura** = edificios que actualmente guardan basura.\n" +
                    "**Total** = todos los edificios productores de basura de la ciudad.\n" +
                    "**Por encima del umbral de solicitud** = cantidad actual de **edificios** con basura suficiente para crear una solicitud de recogida.\n" +
                    "En vanilla, el umbral de solicitud es **100** unidades internas de basura.\n" +
                    "Las opciones del modo experto pueden reemplazar los umbrales de solicitud y recogida.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumen de las instalaciones de basura contadas.\n" +
                    "**Instalaciones** = edificios de basura contados.\n" +
                    "**Camiones de basura** = camiones de recogida normales. En instalaciones de residuos industriales, recogen residuos industriales en lugar de basura normal.\n" +
                    "**Camiones volquete** = transferencias de basura entre instalaciones.\n" +
                    "**Trabajadores máx.** = capacidad total de trabajadores en esas mismas instalaciones."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camiones de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En movimiento** = camiones actualmente por la ciudad.\n" +
                    "**Regresando** = subconjunto de camiones en movimiento marcados para volver a su instalación.\n" +
                    "**Aparcados** = camiones aparcados en una instalación.\n" +
                    "**Total** = cantidad de todos los camiones de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Estado detallado en el log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envía un informe de basura más detallado a **Logs/MagicGarbage.log**.\n" +
                    "Incluye una leyenda corta, valores de referencia vanilla y muchas estadísticas extra reales de la ciudad."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre la carpeta Logs/.. del juego."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Todavía no hay ninguna ciudad cargada." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Necesita un retoque menor ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Un poco pestilente ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de basura ({0:N0})" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t producidas | {1:N0} t procesadas | act. {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pendientes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tienen basura | {2:N0} por encima del umbral de solicitud" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalaciones | {1:N0} camiones de basura | {2:N0} camiones volquete | {3:N0} trabajadores máx." },
                { "MG.Status.Row.Trucks", "{1:N0} en movimiento ({3:N0} regresando) | {2:N0} aparcados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Todavía no hay datos de instalaciones." },

                // Log strings
                { "MG.Status.Log.Title", "Estado de basura ({0})" },
                { "MG.Status.Log.City", "Ciudad: {0}" },
                { "MG.Status.Log.Mode", "Modo: Magia total={0}, Gestión de basura={1}" },
                { "MG.Status.Log.SettingsHeader", "Ajustes actuales del mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Deslizadores de Gestión de basura (guardados): carga del camión={0:N0}% | almacenamiento de instalación={1:N0}% | procesamiento de instalación={2:N0}% | flota de instalación={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "Modo experto (guardado): activado={0} | solicitud={1:N0} | recogida={2:N0} | base de felicidad={3:N0} | paso de felicidad={4:N0} | tasa de acumulación={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Leyenda:\n" +
                    "- Producido/Procesado usa toneladas por mes.\n" +
                    "- Los valores de umbral de abajo usan unidades internas de basura, no toneladas.\n" +
                    "- Para el jugador, el juego convierte 100 unidades = 0.1t y 1.000 unidades = 1t.\n" +
                    "- Valoración del servicio de basura = factor de felicidad por basura de la ciudad según el juego.\n" +
                    "  - 0 = Excelente\n" +
                    "  - -1 = Necesita un retoque menor, o se puede ignorar\n" +
                    "  - -2 a -4 = Un poco pestilente\n" +
                    "  - -5 a -10 = Problema de basura\n" +
                    "Deslizadores de umbral:\n" +
                    "  - Umbral de recogida = basura mínima antes de que un camión recoja en un edificio.\n" +
                    "  - Umbral de solicitud = basura mínima antes de que el juego cree o mantenga una solicitud de recogida.\n" +
                    "- Icono de aviso = cantidad de basura que hace aparecer un icono de aviso sobre un edificio.\n" +
                    "- Límite duro = cantidad máxima de basura que un edificio puede acumular.\n" +
                    "- Pendiente = solicitudes activas que no están asignadas actualmente a un camión o ruta.\n" +
                    "- Algunas solicitudes pendientes se asignarán más tarde; otras también pueden borrarse después si la revalidación vanilla decide que el objetivo ya no necesita servicio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Umbrales del juego (unidades internas de basura): recogida={1:N0}, solicitud={0:N0}, icono de aviso={2:N0}, límite duro={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Umbrales: <GarbageParameterData no disponible>" },
                { "MG.Status.Log.GarbageProcessing", "Basura: {0:N0} t/mes | Procesamiento: {1:N0} t/mes" },
                { "MG.Status.Log.GarbageServiceRating", "Valoración del servicio de basura: {0} | bruto={1:N2} | redondeado={2:N0}" },
                { "MG.Status.Log.Requests", "Solicitudes de recogida: pendientes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Objetivo pendiente con más basura: {0:N0} ({1:N1}t) en {2}" },
                { "MG.Status.Log.PendingPeakNone", "Objetivo pendiente con más basura: ninguno" },
                { "MG.Status.Log.Producers", "Edificios: {0:N0} iconos de aviso | {1:N0} total | {2:N0} tienen basura | {3:N0} por encima del umbral de solicitud " },
                { "MG.Status.Log.ProducerGarbageStats", "Basura en edificios (solo no cero): prom={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) en {6}" },
                { "MG.Status.Log.NearWarning75", "Edificios cerca del icono de aviso (al menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalaciones: {0:N0} total | {1:N0} camiones de basura | {2:N0} camiones volquete ({3:N0} en movimiento) | {4:N0} trabajadores" },
                { "MG.Status.Log.Trucks", "Camiones de basura: {2:N0} en movimiento ({3:N0} regresando) | {1:N0} aparcados | {4:N0} deshabilitados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumen de instalaciones" },
                { "MG.Status.Log.FacilityLine", "- Instalación {0}: camiones de basura={1:N0} ({2:N0} en movimiento, {3:N0} aparcados) | camiones volquete={4:N0} ({5:N0} en movimiento) | trabajadores máx.={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Necesita un retoque menor" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Un poco pestilente" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de basura" },
            };
        }

        public void Unload()
        {
        }
    }
}
