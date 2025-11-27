// LocaleES.cs
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
            return new Dictionary<string, string>
            {
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Acerca de" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Magia total" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-magia"  },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Información del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [X]** elimina al instante toda la basura de la ciudad.\n" +
                    "Los edificios y camiones de basura quedan casi solo como decoración visual.\n\n" +

                    "Mientras **Magia total** esté ACTIVADA:\n" +
                    "- Semi-magia se fuerza a APAGADA.\n" +
                    "- Todos los deslizadores de Semi-magia se ignoran.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "Semi-magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "Activa un servicio de basura mejorado pero aún normal.\n" +
                    "- Usa camiones y plantas más potentes en lugar de magia total.\n" +
                    "- Cuando Semi-magia está ACTIVADA, Magia total se apaga automáticamente.\n" +
                    "- Los deslizadores de abajo solo tienen efecto con Semi-magia activada.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Carga por camión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede llevar cada camión.**\n" +
                    "- 100 % = carga estándar.\n" +
                    "- Valores más altos = se necesitan menos viajes.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Número de camiones de la planta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede enviar cada planta.**\n" +
                    "- 100 % = número estándar de camiones.\n" +
                    "- Hasta 400 % = hasta un 300 % más de camiones disponibles.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocidad de procesamiento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan basura las plantas.**\n" +
                    "- 100 % = velocidad estándar.\n" +
                    "- Valores más altos = la basura se quema / recicla más rápido.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacidad de almacenamiento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una planta antes de estar llena.**\n" +
                    "- 100 % = almacenamiento estándar.\n" +
                    "- Valores más altos = la planta aguanta más antes de marcarse como llena.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Valores por defecto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Restablece todos los deslizadores de Semi-magia a **100 %** (valores vanilla).\n" +
                    "Úsalo si quieres tener el mod instalado pero sin tocar las estadísticas de servicio de basura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Aplica los valores Semi-magia recomendados:\n" +
                    "- Carga por camión: **200 %**\n" +
                    "- Camiones de la planta: **150 %**\n" +
                    "- Velocidad de procesamiento: **200 %**\n" +
                    "- Capacidad de almacenamiento: **200 %**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nombre visible de este mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versión actual del mod." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Abre la página de Paradox Mods con los mods del autor."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre el Discord de modding de CS2 en el navegador."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado recomendado por defecto>\n" +
                    "  * Magia total ACTIVADA = **[X]**\n" +
                    "  * Toda la basura se elimina al instante\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de camiones super Semi-magia>\n" +
                    "  * Magia total APAGADA = **[ ]**\n" +
                    "  * Semi-magia ACTIVADA = **[X]** y ajusta los deslizadores [100 >> 500] / [100 >> 400] a tu gusto.\n" +
                    "  * Juego estilo vanilla pero con camiones y plantas mejorados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Juego totalmente vanilla>\n" +
                    "  * Magia total APAGADA = **[ ]**\n" +
                    "  * Semi-magia = **[X]** (haz clic en Valores por defecto)\n" +
                    "  * Todos los deslizadores en 100 % (límites vanilla)\n" +
                    "  * Jugabilidad exactamente estándar.\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)),
                    string.Empty
                },
            };
        }

        public void Unload()
        {
        }
    }
}
