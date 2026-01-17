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
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info de la mod"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces"              },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO"         },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activado [ ✓ ]** elimina al instante toda la basura de la ciudad.\n\n" +

                    "Mientras **Magia total** está ACTIVADA:\n" +
                    "- Semi-magia se fuerza a estar DESACTIVADA.\n" +
                    "- Los deslizadores de Semi-magia **no se aplican** (tus valores se guardan para más tarde).\n" +
                    "- Algunos camiones pueden seguir circulando por la lógica de despacho del juego (normalmente vacíos)."
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gestiona directamente los sistemas de basura; la lógica vanilla sigue funcionando.\n\n" +
                    "- Cuando **Semi-magia está ACTIVADA [ ✓ ]**, Magia total se apaga automáticamente.\n" +
                    "- Los deslizadores solo se aplican si Semi-magia está activada [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacidad de carga del camión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Cuánta basura puede llevar cada camión.**\n" +
                    "100% = valor normal del juego.\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocidad de procesamiento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Qué tan rápido procesan la basura las instalaciones.**\n" +
                    "100% = velocidad vanilla.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacidad de almacenamiento de la instalación" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Cuánta basura puede almacenar una instalación.**\n" +
                    "100% = almacenamiento vanilla.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Camiones por instalación"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Cuántos camiones puede enviar cada instalación.**\n" +
                    "100% = cantidad vanilla.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Aplica valores recomendados de Semi-magia:\n" +
                    "- Capacidad de carga del camión: **200%**\n" +
                    "- Velocidad de procesamiento: **200%**\n" +
                    "- Capacidad de almacenamiento: **160%**\n" +
                    "- Camiones por instalación: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "Valores del juego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Pone todos los deslizadores en **100%** (valores vanilla).\n" +
                    "Vuelve al comportamiento normal del juego."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nombre visible de esta mod."
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
                    "<Estado: Limpieza automática>\n" +
                    "  * Magia total ACTIVADA = **[ ✓ ]**\n" +
                    "  * Toda la basura se elimina al instante\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado: Gestión manual>\n" +
                    "  * Activar Semi-magia = **[ ✓ ]**\n" +
                    "  * Ajusta los deslizadores como quieras.\n" +
                    "  * Lógica vanilla con camiones/instalaciones mejorados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Juego vanilla normal>\n" +
                    "  * Activar Semi-magia = **[ ✓ ]**\n" +
                    "  * Haz clic en **[Valores del juego]**\n" +
                    "  * Todos los deslizadores a 100% (vanilla)\n"
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
