// Locale/LocaleEN.cs
// English (en-US) localization for "Magic Garbage Truck [MGT]".

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "About"   },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Total Magic" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-Magic"  },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod info"    },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE NOTES" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Magic Garbage"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Enabled [X]** removes all city garbage instantly.\n" +
                    "Garbage buildings are no longer needed unless you like seeing them.\n\n" +

                    "<Use either this **Total Magic** or\n" +
                    "the **Semi-Magic** option below — not both.>\n" +
                    "- No harm, but nothing extra happens."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Garbage Truck Capacity"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Semi-Magic** super trucks mode.\n" +
                    "If you just want easier garbage but not eliminate it: \n" +
                    "- Magic Garbage = **[OFF]**\n" +
                    "- Then use this slider **[100 >> 500]** to increase truck holding capacity.\n\n" +

                    "**---------------------------------------**\n" +
                    " Slider adjust capacity relative to vanilla game value.\n" +
                    "**100% = 20  tons per truck** - game default\n" +
                    "**500% = 100 tons per truck**\n\n" +

                    "**---------------------------------------**\n\n" +
                    "If you want full vanilla back, then Magic Garbage [OFF] and slider = 100% is normal gameplay.\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),
                    "Mod"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Display name of this mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)),
                    "Version"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Current mod version."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Paradox Mods page"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Open the Magic Garbage Truck page on Paradox Mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Open the CS2 modding Discord in your browser."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Default recommended state>\n" +
                    "  * Total Magic Garbage = **[ON]**\n" +
                    "  * Slider = 100%\n" +
                    "  * All garbage is instantly removed\n" +

                    " <-------------------------------------->\n\n" +

                    "<Semi-Magic super trucks state>\n" +
                    "  * Turn Magic Garbage = **[OFF]**\n" +
                    "  * Set slider [100 >> 500] to get super-size capacity.\n" +
                    "  * Vanilla garbage with better trucks, fewer needed.\n" +

                    " <-------------------------------------->\n\n" +

                    "<Full vanilla game>\n" +
                    "  * Magic Garbage = **[OFF]**\n" +
                    "  * Slider = 100% (vanilla truck limits)\n" +
                    "  * Exactly standard gameplay.\n"
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
