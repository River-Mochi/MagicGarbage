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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestión manual" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Avanzado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Estado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** mantiene limpia toda la ciudad.\n\n" +
                    "Mientras **Total Magic** está ON:\n" +
                    "- Trash Boss se fuerza a OFF.\n" +
                    "- Los deslizadores de Trash Boss no se aplican (los valores quedan guardados para después).\n" +
                    "- Aún pueden circular algunos camiones por el timing de envío vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestiona directamente el sistema de basura; la lógica vanilla sigue activa.\n\n" +
                    "- Cuando **Trash Boss está ON [ ✓ ]**, Total Magic se fuerza a OFF.\n" +
                    "- Los deslizadores solo se aplican si Trash Boss está activado.\n" +
                    "- Total Magic + Trash Boss pueden estar ambos en **OFF** si solo hace falta el **reporte de estado**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidad de carga" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede llevar cada camión.**\n" +
                    "**100% = valor normal** del juego.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Almacenamiento del sitio" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "**100% = almacenamiento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidad de proceso" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan la basura entrante las instalaciones.**\n" +
                    "**100% = velocidad vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota del sitio" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede despachar cada instalación.**\n" +
                    "**100% = cantidad vanilla** de camiones.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opciones avanzadas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**Ajuste avanzado opcional para umbrales + felicidad por basura.**\n" +
                    "Cuando está **OFF**, los umbrales de recogida/solicitud y la felicidad por basura **siguen en vanilla**.\n" +
                    "Cuando está **ON**, aparecen los **deslizadores avanzados**.\n\n" +
                    "<--- Ejemplos de felicidad por basura --->\n"+
                    " - <Vanilla> 100/65 = 1.ª penalización en <165>.\n" +
                    " - <Recomendado> 550/150 = 1.ª penalización en <700>.\n" +
                    " - <Muy suave> 950/200 = 1.ª penalización por basura en <1150>.\n" +
                    "Comodidad: los últimos valores se guardan cuando esta opción está OFF."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Umbral de solicitud" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Basura necesaria en un edificio antes de crear o mantener una solicitud de despacho de camión.**\n" +
                    "Vanilla = **100** unidades de basura.\n" +
                    "**100 unidades de basura = 0.1t**\n" +
                    "**1.000 unidades de basura = 1t**\n" +
                    "Mantén esto al mismo nivel o por encima del umbral de recogida.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Umbral de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Basura mínima en un edificio antes de que un camión pueda recogerla.**\n" +
                    "Vanilla = **20** unidades de basura.\n" +
                    "La recogida nunca puede ser mayor que la solicitud.\n" +
                    "Mantén la solicitud al mismo nivel o por encima del valor de recogida para evitar fallos de lógica;" +
                    " si se envía un camión a un edificio y el valor de recogida es más alto, podría no poder recoger (también influye la tasa de acumulación).\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Se aplicaron los valores estándar **recomendados** de Trash Boss.\n" +
                    "No cambia la configuración de Power User."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Devuelve los deslizadores de Trash Boss a los **valores vanilla**.\n" +
                    "No cambia <no> la configuración de Power User.\n" +
                    "**Vanilla:**\n" +
                    "- Los deslizadores en % vuelven a **100%**.\n" +
                    "- El umbral de solicitud vuelve a **100 unidades**.\n" +
                    "- El umbral de recogida vuelve a **20 unidades**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nivel de basura de un edificio antes de empezar la penalización a salud + felicidad.**\n" +
                    "**Vanilla = 100** unidades de basura.\n" +
                    "Base más alta = los edificios pueden aguantar más basura antes de la penalización.\n" +
                    "100 unidades de basura = 0.1t\n" +
                    "Resumen:\n" +
                    "- <Umbral> = punto de activación del sistema\n" +
                    "- <Base> = punto inicial de la fórmula de penalización\n"+
                    "- <Paso> = tamaño del incremento en la fórmula, o sea la rapidez con la que sube la penalización"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Paso de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Basura extra por encima de la base que hace empezar una penalización de -1.**\n" +
                    "Vanilla = **65** unidades de basura.\n" +
                    "Paso más alto = crecimiento más lento de la penalización.\n" +
                    "El juego limita la penalización por basura a **-10**.\n" +
                    "La primera penalización vanilla <-1 penalty> pasa a **165 de basura** (100 base + 65 paso)\n" +
                    "Equilibra los cambios de umbral con los deslizadores de felicidad o tendrás penalizaciones más fuertes de lo normal."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica los valores **recomendados** de Power User.\n" +
                    "Activa Power User.\n" +
                    "La primera penalización por basura empieza en **700** de basura (550 base + 150 paso)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Devuelve los valores de Power User a **vanilla**.\n" +
                    "Pone **Power User en OFF**."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nombre visible de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versión actual del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abre la página de Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre la invitación de Discord en el navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado auto limpieza>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * La basura se elimina sola - listo.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado gestión manual>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajusta los deslizadores a tu gusto.\n" +
                    "  * Opcional: activa Power User para umbrales + felicidad por basura.\n" +
                    "  * Mismo sistema de basura del juego; camiones/instalaciones mejor gestionados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado estado / vanilla>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Solo reporte de estado.\n" +
                    "  * El juego vanilla de basura no cambia."

                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Basura/mes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Muestra la cantidad actual de basura de toda la ciudad y la tasa total de procesamiento.\n" +
                    "Sube el procesamiento si la basura producida al mes es mucho mayor.\n" +
                    "**Producida** y **Procesada** usan toneladas por mes.\n" +
                    "<Hora de actualización = última vez que se refrescó.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitudes de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendientes** = solicitudes activas de recogida todavía no asignadas a un camión o ruta.\n" +
                    "**Despachadas** = solicitudes activas de recogida ya asignadas.\n" +
                    "**Total** = cuenta las entidades de solicitud **activas** actuales (en la cadena de basura).\n\n" +
                    "Nota técnica: esto es distinto de <Por encima del umbral de solicitud>. Aquí se cuentan <solicitudes>, no edificios.\n" +
                    "Algunas solicitudes pendientes se asignarán después; otras también pueden limpiarse si la revalidación vanilla decide que el objetivo ya no necesita servicio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edificios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tiene basura** = edificios que ahora mismo guardan basura.\n" +
                    "**Total** = todos los edificios productores de basura de la ciudad.\n" +
                    "**Por encima del umbral de solicitud** = cantidad actual de **edificios** con basura suficiente para crear una solicitud de recogida.\n" +
                    "En vanilla, el umbral de solicitud es **100** unidades internas de basura.\n" +
                    "Power User puede cambiar los umbrales de solicitud y recogida.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumen de las instalaciones de basura contadas.\n" +
                    "**Instalaciones** = edificios de basura contados.\n" +
                    "**Camiones de basura** = camiones normales de recogida. En instalaciones de residuos industriales, recogen residuos industriales en vez de basura normal.\n" +
                    "**Dump trucks** = transferencias de basura entre instalaciones.\n" +
                    "**Trabajadores máx.** = capacidad total de trabajadores de esas mismas instalaciones."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camiones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En marcha** = camiones que ahora mismo están fuera por la ciudad.\n" +
                    "**Regresando** = parte de los camiones en marcha que vuelven a su instalación.\n" +
                    "**Aparcados** = camiones aparcados en una instalación.\n" +
                    "**Total** = número de todos los camiones de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Estado detallado al log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envía un informe más detallado de basura a **Logs/MagicGarbage.log**.\n" +
                    "Incluye una leyenda corta, valores vanilla de referencia y muchas estadísticas reales extra de la ciudad."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre la carpeta Logs/.. del juego."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Todavía no hay ciudad cargada." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t producidas | {1:N0} t procesadas | act. {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pendientes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tienen basura | {2:N0} sobre el umbral" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalaciones | {1:N0} camiones de basura | {2:N0} dump trucks | {3:N0} trabajadores máx." },
                { "MG.Status.Row.Trucks", "{1:N0} en marcha ({3:N0} regresando) | {2:N0} aparcados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Aún no hay datos de instalaciones." },

                // Log strings
                { "MG.Status.Log.Title", "Estado de basura ({0})" },
                { "MG.Status.Log.City", "Ciudad: {0}" },
                { "MG.Status.Log.Mode", "Modo: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Leyenda:\n" +
                    "- Producida/Procesada usa toneladas por mes.\n" +
                    "- Los umbrales de abajo usan unidades internas de basura, no toneladas.\n" +
                    "- Para el jugador, el juego convierte 100 unidades = 0.1t y 1.000 unidades = 1t.\n" +
                    "Deslizadores de umbral:\n" +
                    "  - Umbral de recogida = basura mínima antes de que un camión pueda recoger de un edificio.\n" +
                    "  - Umbral de solicitud = basura mínima antes de que el juego cree o mantenga una solicitud de recogida.\n" +
                    "- Icono de aviso = cantidad de basura que hace aparecer un aviso sobre un edificio.\n" +
                    "- Límite duro = basura máxima que puede acumular un edificio.\n" +
                    "- Pendientes = solicitudes activas todavía no asignadas a un camión o ruta.\n" +
                    "- Algunas pendientes se asignarán más tarde; otras también pueden limpiarse si la revalidación vanilla decide que el objetivo ya no necesita servicio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Umbrales del juego (unidades internas de basura): recogida={1:N0}, solicitud={0:N0}, icono de aviso={2:N0}, límite duro={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Umbrales: <GarbageParameterData no disponible>" },
                { "MG.Status.Log.GarbageProcessing", "Basura: {0:N0} t/mes | Procesamiento: {1:N0} t/mes" },
                { "MG.Status.Log.Requests", "Solicitudes de recogida: pendientes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Objetivo pendiente más alto: {0:N0} ({1:N1}t) en {2}" },
                { "MG.Status.Log.Producers", "Edificios: {0:N0} total | {1:N0} tienen basura | {2:N0} sobre el umbral | {3:N0} nivel aviso" },
                { "MG.Status.Log.ProducerGarbageStats", "Basura en edificios (solo no cero): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) en {6}" },
                { "MG.Status.Log.NearWarning75", "Edificios cerca del aviso (al menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalaciones: {0:N0} total | {1:N0} camiones de basura | {2:N0} dump trucks ({3:N0} en marcha) | {4:N0} trabajadores" },
                { "MG.Status.Log.Trucks", "Camiones de basura: {2:N0} en marcha ({3:N0} regresando) | {1:N0} aparcados | {4:N0} desactivados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumen de instalaciones" },
                { "MG.Status.Log.FacilityLine", "- Instalación {0}: garbage={1:N0} ({2:N0} en marcha, {3:N0} aparcados) | dump={4:N0} ({5:N0} en marcha) | trabajadores máx={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
