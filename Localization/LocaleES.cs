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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Usuario avanzado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Estado" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** mantiene limpia toda la ciudad.\n\n" +
                    "Mientras **Magia total** esté ON:\n" +
                    "- Trash Boss se fuerza a OFF.\n" +
                    "- Los deslizadores de Trash Boss no se aplican (los valores se guardan para más tarde).\n" +
                    "- Algunos camiones aún pueden moverse por el tiempo de la lógica vanilla de despacho."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestiona directamente los sistemas de basura; deja funcionando la lógica vanilla de basura.\n\n" +
                    "- Cuando **Trash Boss** está ON [ ✓ ], Magia total se fuerza a OFF.\n" +
                    "- Los deslizadores solo se aplican cuando Trash Boss está activado.\n" +
                    "- Tanto Magia total como Trash Boss pueden estar en **OFF** para volver a ajustes vanilla,\n" +
                    "  y aun así se puede ver el **informe de estado**, que se actualiza solo al abrir el menú de Opciones (ligero)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "Asistencia de prioridad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                    "Ayuda para objetivos de basura (edificios) muy sobrecargados.\n" +
                    "Cuando está **ON**, comprueba si algún objetivo de solicitud activo alcanza **7000+** (**7t**) de basura.\n" +
                    "Objetivo: reduce trabajos extra de recogida lateral cuando hace falta, para que los camiones lleguen antes a los peores objetivos.\n" +
                    "Es una ayuda, no una sustitución dura y completa de la lógica vanilla de rutas.\n" +
                    "Ligero, sin parche Harmony."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidad de carga" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede transportar cada camión.**\n" +
                    "**100% = valor normal** del juego (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Almacenamiento de instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "**100% = almacenamiento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidad de procesado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan las instalaciones la basura entrante.**\n" +
                    "**100% = velocidad de procesado vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota de instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede despachar cada instalación.**\n" +
                    "**100% = número vanilla** de camiones.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica los valores estándar **recomendados** de Trash Boss.\n" +
                    "No cambia la configuración de Usuario avanzado (separada)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Devuelve los deslizadores de Trash Boss a los **valores vanilla**.\n" +
                    "No cambia la configuración de Usuario avanzado.\n" +
                    "**Vanilla:**\n" +
                    "- Los deslizadores en porcentaje vuelven a **100%**.\n" +
                    "- El Umbral de solicitud de despacho vuelve a **100 unidades**.\n" +
                    "- El Umbral de recogida vuelve a **20 unidades**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opciones avanzadas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Configuración avanzada opcional\n" +
                    "<Advertencia: NO es necesaria> para un buen servicio; está aquí para jugadores que quieran experimentar o entender mejor cómo funciona el sistema.\n" +
                    "Cuando está **OFF**, los elementos de Usuario avanzado se comportan como el juego **vanilla** normal.\n" +
                    "Cuando está **ON**, los **deslizadores avanzados aparecen**.\n\n" +
                    "<--- Ejemplos de felicidad --->\n" +
                    " - <Vanilla> 100/65 = 1.ª penalización en <165>.\n" +
                    " - Pulsa <Recomendado> para 550/150 = 1.ª penalización en <700>.\n" +
                    " - <Muy suave> 950/200 = 1.ª penalización de basura en <1150>.\n" +
                    "Comodidad: los últimos valores de los deslizadores se guardan cuando esta opción está en OFF (por si se activan más tarde)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Umbral de solicitud de despacho" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Basura necesaria en un edificio antes de que se cree o mantenga una solicitud de despacho de camión.**\n" +
                    "Vanilla = **100** unidades de basura.\n" +
                    "**100 unidades de basura = 0.1t**\n" +
                    "**1.000 unidades de basura = 1t**\n" +
                    "Mantén este valor igual o por encima del Umbral de recogida.\n" +
                    "Esto suele aumentar cuántos camiones se usan frente a cuántos quedan aparcados."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Umbral de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Basura mínima en un edificio antes de que un camión pueda recogerla.**\n" +
                    "Vanilla = **20** unidades de basura.\n" +
                    "El deslizador de recogida <no puede> ser más alto que la Solicitud de despacho (DR); se limita para evitar problemas de lógica.\n" +
                    "Si un camión es enviado a un edificio y el valor de recogida es más alto que el de DR, a veces el camión puede no ser capaz de recoger de ese edificio (la tasa de acumulación también influye).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nivel de basura en un edificio antes de que empiece a causar penalización de salud + felicidad.**\n" +
                    "**Vanilla = 100** unidades de basura.\n" +
                    "Una base más alta = los edificios pueden aguantar más basura antes de que empiece la penalización.\n" +
                    "100 unidades de basura = 0.1t\n" +
                    "Resumen:\n" +
                    "- <Umbral> = punto de activación del comportamiento del sistema\n" +
                    "- <Base> = punto de inicio de la fórmula de penalización\n" +
                    "- <Paso> = tamaño del incremento en la fórmula, o qué tan rápido sube la penalización después de empezar"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Paso de felicidad por basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Cantidad extra de basura por encima de la base que hace que empiece una penalización de -1.**\n" +
                    "Vanilla = **65** unidades de basura.\n" +
                    "Paso más alto = crecimiento más lento de la penalización.\n" +
                    "El juego limita la penalización por basura a **-10**.\n" +
                    "La primera <penalización de -1> vanilla ocurre en **165 de basura** (100 base + 65 paso)\n" +
                    "Cambiar los umbrales sin ajustar los deslizadores de felicidad puede provocar penalizaciones más fuertes de lo normal."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tasa de acumulación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Escala los valores de fuente de basura de los edificios compatibles.**\n" +
                    "Cuidado: esta es una palanca fuerte y cambiar la tasa afecta muchas cosas.\n" +
                    "Es posible tener un buen sistema sin usar esto.\n\n" +
                    "**100% = tasa de acumulación vanilla**.\n" +
                    "**20%** = acumulación mucho más lenta.\n" +
                    "**200%** = el doble de tasa: muchísima basura.\n" +
                    "Con 20%, claramente todos los cims están haciendo compost, así que la acumulación de basura es mucho menor ;)\n\n" +
                    "Nota técnica: el juego añade basura gradualmente a lo largo del día, no toda de golpe."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica los valores **recomendados** de Usuario avanzado.\n" +
                    "Activa Usuario avanzado.\n" +
                    "La primera penalización de basura empieza en **700** de basura (550 base + 150 paso).\n" +
                    "La Tasa de acumulación de basura se queda en **100%** vanilla salvo cambio manual."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Devuelve todos los valores de Usuario avanzado **a vanilla**.\n" +
                    "Pone **Usuario avanzado** en OFF.\n"
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
                    "<Estado de limpieza auto>\n" +
                    "  * Magia total ON = **[ ✓ ]**\n" +
                    "  * La basura se elimina automáticamente - hecho.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de gestión directa>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajusta los deslizadores como se quiera.\n" +
                    "  * Opcional: activar los deslizadores avanzados (no es obligatorio).\n" +
                    "  * La misma basura del juego; mejores camiones/instalaciones autogestionados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de estado / vanilla>\n" +
                    "  * Magia total = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Solo informe de estado.\n" +
                    "  * La basura vanilla del juego no cambia."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Valoración del servicio de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Valoración simple de felicidad de basura del juego.\n" +
                    "**0 = Excelente**\n" +
                    "**-1 **= Necesita un pequeño ajuste. El juego suele moverse entre 0 y -1 y se puede ignorar (el número está redondeado).\n" +
                    "**-2 a -4** = Un poco maloliente\n" +
                    "**-5 a -10** = Problema de basura\n" +
                    "**Mandos indirectos:** usa los <deslizadores de basura> para mejorar esto con el tiempo reduciendo la acumulación de basura.\n" +
                    "**Mandos directos:** Base de felicidad por basura + Paso de felicidad por basura cambian <lo que toleran los cims> antes de estar descontentos.\n" +
                    "**Tasa de acumulación de basura**: cambia la velocidad a la que los edificios compatibles producen basura. Úsala con cuidado porque el equilibrio importa. La mayoría de jugadores nunca necesita tocar esto.\n" +
                    "<Hora de actualización = último refresco.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Edificios 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Cantidad de edificios productores de basura con **7t / 7000** de basura o más.\n" +
                    "Son edificios muy sobrecargados; activa [x] Sistema de prioridad para priorizarlos mejor.\n" +
                    "Usa el botón Estado a log si se necesitan los números de ID de entidad para inspección."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Basura/mes" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Muestra la cantidad actual de basura de toda la ciudad y la tasa total de procesamiento de basura.\n" +
                    "Aumenta el procesamiento si la basura producida por mes es mucho mayor.\n" +
                    "**Producido** y **Procesado** usan toneladas por mes."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitudes de recogida" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendientes** = solicitudes activas de recogida que todavía no están asignadas a un camión o ruta.\n" +
                    "**Despachadas** = solicitudes activas de recogida ya asignadas.\n" +
                    "**Total** = cuenta la entidad de solicitud **activa** actual (en la cadena de basura).\n\n" +
                    "Nota técnica: esto es distinto de <Por encima del umbral de solicitud>. Aquí se cuentan <solicitudes>, no edificios.\n" +
                    "Algunas solicitudes pendientes se asignarán más tarde; otras también pueden desaparecer más tarde si la revalidación vanilla decide que el objetivo ya no necesita servicio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edificios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tiene basura** = edificios que actualmente tienen cualquier cantidad de basura.\n" +
                    "**Total** = todos los edificios productores de basura de la ciudad.\n" +
                    "**Por encima del umbral de solicitud** = cantidad actual de **edificios** con suficiente basura para crear una solicitud de recogida.\n" +
                    "En vanilla, el umbral de solicitud es **100** unidades internas de basura.\n" +
                    "Las Opciones avanzadas pueden reemplazar los umbrales de solicitud y recogida.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalaciones" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumen de las instalaciones de basura contadas.\n" +
                    "**Instalaciones** = edificios de basura contados.\n" +
                    "**Camiones de basura** = camiones normales de recogida. En instalaciones de residuos industriales, recogen residuos industriales en lugar de basura normal.\n" +
                    "**Dump trucks** = transferencias de basura entre instalaciones.\n" +
                    "**Trabajadores máx.** = capacidad total de trabajadores en esas mismas instalaciones."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camiones de basura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En movimiento** = camiones que ahora mismo están fuera en la ciudad.\n" +
                    "**Regresando** = subconjunto de camiones en movimiento marcados para volver a su instalación.\n" +
                    "**Aparcados** = camiones aparcados en una instalación.\n" +
                    "**Total** = cantidad de todos los camiones de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Estado detallado al log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envía un informe de basura más detallado a **Logs/MagicGarbage.log**.\n" +
                    "Incluye estadísticas organizadas de la basura de la ciudad"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre la carpeta del juego Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Todavía no hay ninguna ciudad cargada." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Necesita un pequeño ajuste ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Un poco maloliente ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de basura ({0:N0}) | actualizado {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} por encima de 7t" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t producidas | {1:N0} t procesadas" },
                { "MG.Status.Row.Requests", "{1:N0} pendientes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tiene basura | {2:N0} por encima del umbral de solicitud" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalaciones | {1:N0}/{2:N0} camiones basura/dump trucks | {3:N0} trabajadores" },
                { "MG.Status.Row.Trucks", "{1:N0} en movimiento ({3:N0} regresando) | {2:N0} aparcados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Aún no hay datos de instalaciones." },

                // Log strings
                { "MG.Status.Log.Title", "Estado de basura ({0})" },
                { "MG.Status.Log.City", "Ciudad: {0}" },
                { "MG.Status.Log.Mode", "Modo: Magia total={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Configuración actual del mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Deslizadores de Trash Boss (guardados): carga del camión={0:N0}% | almacenamiento de instalación={1:N0}% | procesado de instalación={2:N0}% | flota de instalación={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "Usuario avanzado (guardado): activado={0} | solicitud={1:N0} | recogida={2:N0} | base de felicidad={3:N0} | paso de felicidad={4:N0} | tasa de acumulación={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Leyenda:\n" +
                    "- Producido/Procesado usa toneladas por mes.\n" +
                    "- Los valores de umbral de abajo usan unidades internas de basura, no toneladas.\n" +
                    "- Para el jugador, el juego convierte 100 unidades = 0.1t y 1.000 unidades = 1t.\n" +
                    "- Valoración del servicio de basura = factor de felicidad de basura de la ciudad en el juego.\n" +
                    "  - 0 = Excelente\n" +
                    "  - -1 = Necesita un pequeño ajuste, o ignorar\n" +
                    "  - -2 a -4 = Un poco maloliente\n" +
                    "  - -5 a -10 = Problema de basura\n" +
                    "Deslizadores de umbral:\n" +
                    "  - Umbral de recogida = basura mínima antes de que un camión recoja de un edificio.\n" +
                    "  - Umbral de solicitud = basura mínima antes de que el juego cree o mantenga una solicitud de recogida.\n" +
                    "- Icono de advertencia = cantidad de basura que hace aparecer un icono de advertencia sobre un edificio.\n" +
                    "- Límite duro = cantidad máxima de basura que un edificio puede acumular.\n" +
                    "- Pendientes = solicitudes activas no asignadas actualmente a un camión o ruta.\n" +
                    "- Algunas solicitudes pendientes se asignarán más tarde; otras también pueden desaparecer más tarde si la revalidación vanilla decide que el objetivo ya no necesita servicio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Umbrales del juego (unidades internas de basura): recogida={1:N0}, solicitud={0:N0}, icono de advertencia={2:N0}, límite duro={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Umbrales: <GarbageParameterData no disponible>" },
                { "MG.Status.Log.GarbageProcessing", "Basura: {0:N0} t/mes | Procesado: {1:N0} t/mes" },
                { "MG.Status.Log.GarbageServiceRating", "Valoración del servicio de basura: {0} | bruto={1:N2} | redondeado={2:N0}" },
                { "MG.Status.Log.Requests", "Solicitudes de recogida: pendientes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Objetivo pendiente más alto: {0:N0} ({1:N1}t) en {2}" },
                { "MG.Status.Log.PendingPeakNone", "Objetivo pendiente más alto: ninguno" },
                { "MG.Status.Log.Producers", "Edificios: {0:N0} iconos de advertencia | {1:N0} total | {2:N0} tiene basura | {3:N0} por encima del umbral de solicitud " },
                { "MG.Status.Log.ProducerGarbageStats", "Basura de edificios (solo no cero): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) en {6}" },
                { "MG.Status.Log.NearWarning75", "Edificios cerca del icono de advertencia (al menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalaciones: {0:N0} total | {1:N0} camiones de basura | {2:N0} dump trucks ({3:N0} en movimiento) | {4:N0} trabajadores" },
                { "MG.Status.Log.Trucks", "Camiones de basura: {2:N0} en movimiento ({3:N0} regresando) | {1:N0} aparcados | {4:N0} deshabilitados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumen de instalaciones" },
                { "MG.Status.Log.FacilityLine", "- Instalación {0}: camiones de basura={1:N0} ({2:N0} en movimiento, {3:N0} aparcados) | dump trucks={4:N0} ({5:N0} en movimiento) | trabajadores máx={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Necesita un pequeño ajuste" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Un poco maloliente" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de basura" },

                { "MG.Status.Log.ThresholdsHeader", "Umbrales + servicio" },
                { "MG.Status.Log.RequestsHeader", "Solicitudes" },
                { "MG.Status.Log.BuildingsHeader", "Edificios" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Edificios críticos por encima de 7t" },

                { "MG.Status.Log.TransferProbeHeader", "Sonda de transferencia de basura" },
                { "MG.Status.Log.TransferProbeNone", "No se encontraron instalaciones de transferencia/almacenamiento de basura." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | almacenado={1,7:N0} ({2,4:N1}t) | cap={3,7:N0} ({4,4:N1}t) | export={5,7:N0} ({6,4:N1}t) | bajo={7,7:N0} ({8,4:N1}t) | mín={9,7:N0} ({10,4:N1}t) | sal/ent={11,6:N0}/{12,6:N0} | activo={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "Camiones" },

                { "MG.Status.Log.SettingsPriority",
                    "Sistema de prioridad (guardado): activado={0} | disparador={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "Asistencia de prioridad" },
                { "MG.Status.Log.PriorityState",
                    "Asistencia de prioridad activa={0} | intervalo={1:N0} frames | últimas solicitudes escaneadas={2:N0} | objetivos críticos de solicitud activos={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "Pasadas de prioridad: elevadas={0:N0} | normales={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "Objetivo crítico activo más alto: ninguno" },
                { "MG.Status.Log.PriorityPeak",
                    "Objetivo crítico activo más alto: {0:N0} ({1:N1}t) | {2} | {3}"
                },
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
