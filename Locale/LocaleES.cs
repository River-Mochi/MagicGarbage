// Locale/LocaleES.cs
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
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Acerca de" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpieza automática" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Gestión manual"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Información de la mod"},
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces"              },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO"         },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** elimina al instante toda la basura de la ciudad.\n" +
                    "Los edificios y camiones de basura pasan a ser solo decoración.\n\n" +

                    "Mientras **Magia total** está ACTIVADA:\n" +
                    "- La Semi-magia se desactiva automáticamente.\n" +
                    "- Todos los deslizadores de Semi-magia se ignoran.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gestiona directamente los sistemas de basura; la lógica vanilla sigue funcionando.\n\n" +
                    "- Cuando **Semi-magia está ACTIVADA [ ✓ ]**, Magia total se apaga automáticamente.\n" +
                    "- Ajusta todos los camiones e instalaciones de basura.\n" +
                    "- Los deslizadores solo tienen efecto si Semi-magia está activada [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacidad de carga del camión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede transportar cada camión.**\n" +
                    "100% = valor predeterminado del juego.\n" +
                    "<100% = 20 t>\n" +
                    "<500% = 100 t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Número de camiones por instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede enviar cada instalación.**\n" +
                    "100% = número de camiones estándar.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocidad de procesamiento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan la basura las instalaciones.**\n" +
                    "100% = velocidad de procesamiento estándar.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacidad de almacenamiento de la instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "100% = almacenamiento estándar.\n" +
                    "Valores más altos = la instalación puede almacenar más basura.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Valores por defecto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Restablece todos los deslizadores a **100%** (valores vanilla).\n" +
                    "Devuelve el comportamiento normal del juego."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Aplica los valores recomendados de Semi-magia:\n" +
                    "- Capacidad de carga del camión: **200%**\n" +
                    "- Número de camiones por instalación: **150%**\n" +
                    "- Velocidad de procesamiento: **200%**\n" +
                    "- Capacidad de almacenamiento: **150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nombre que se muestra para esta mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Versión actual de la mod."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Abre la página de **Paradox Mods** con las mods del autor."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre **Discord** en tu navegador para el modding de CS2."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Modo de limpieza automática>\n" +
                    "  * Magia total ACTIVADA = **[ ✓ ]**\n" +
                    "  * Toda la basura se elimina al instante\n" +
                    " <-------------------------------------->\n\n" +
                    "<Modo de gestión manual>\n" +
                    "  * Activar Semi-magia = **[ ✓ ]**\n" +
                    "  * Ajusta los deslizadores [100 >> 500] como quieras.\n" +
                    "  * Simulación vanilla con camiones e instalaciones mejorados y configurables.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Juego vanilla normal>\n" +
                    "  * Semi-magia = **[ ✓ ]**\n" +
                    "  * Haz clic en **[Valores por defecto]**\n" +
                    "  * Todos los deslizadores a 100% (vanilla)\n" +
                    "  * Comportamiento estándar del juego.\n"
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
