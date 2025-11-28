// Locale/LocaleEN.cs
// English (en-US)

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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Enabled [X]** instantly removes all city garbage.\n" +
                    "Garbage buildings and trucks become mostly visual decoration.\n\n" +

                    "While **Total Magic** is ON:\n" +
                    "- Semi-Magic is forced OFF.\n" +
                    "- All Semi-Magic sliders are ignored.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Enable tuned-up but still \"normal\" garbage gameplay.\n" +
                    "- Uses stronger trucks and facilities instead of full magic.\n" +
                    "- When Semi-Magic is ON, Total Magic is automatically turned OFF.\n" +
                    "- Sliders below only matter when Semi-Magic is enabled.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Truck load capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**How much garbage each truck can carry.**\n" +
                    "- 100% = vanilla load per truck.\n" +
                    "- Higher values = fewer trips needed.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Facility truck count" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**How many trucks each facility can dispatch.**\n" +
                    "- 100% = vanilla number of trucks.\n" +
                    "- Up to 400% = +300% more trucks available.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Processing speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**How fast facilities process incoming garbage.**\n" +
                    "- 100% = vanilla processing speed.\n" +
                    "- Higher values = garbage gets burned / recycled faster.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Facility storage capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**How much garbage a facility can store before it is \"full\".**\n" +
                    "- 100% = vanilla storage.\n" +
                    "- Higher values = facility can hold more before showing full.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Game defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Set all Semi-Magic sliders back to **100%** (vanilla values).\n" +
                    "Use this if you want the mod installed but garbage service stats untouched."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Apply recommended Semi-Magic values:\n" +
                    "- Truck load capacity: **200%**\n" +
                    "- Facility truck count: **150%**\n" +
                    "- Processing speed: **200%**\n" +
                    "- Storage capacity: **200%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Display name of this mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Current mod version." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Open Paradox Mods webpage to the author's mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Open the CS2 modding Discord in your browser."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Default recommended state>\n" +
                    "  * Total Magic ON  = **[X]**\n" +
                    "  * All garbage is instantly removed\n" +
                    " <-------------------------------------->\n\n" +
                    "<Semi-Magic super trucks state>\n" +
                    "  * Total Magic OFF = **[ ]**\n" +
                    "  * Enable Semi-Magic = **[X]** and set sliders [100 >> 500] / [100 >> 400] as you like.\n" +
                    "  * Vanilla-style garbage with better trucks and stronger facilities.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Full vanilla game>\n" +
                    "  * Total Magic OFF = **[ ]**\n" +
                    "  * Semi-Magic = **[X]** (click Game defaults)\n" +
                    "  * All sliders at 100% (vanilla limits)\n" +
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
