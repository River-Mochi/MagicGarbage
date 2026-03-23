// File: Localization/LocaleEN.cs
// English (en-US)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "About"   },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Self Manage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp),     "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE NOTES" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Enabled [ ✓ ]** keeps the whole city clean.\n\n" +
                    "While **Total Magic** is ON:\n" +
                    "- Semi-Magic is forced OFF.\n" +
                    "- Semi-Magic sliders are not applied (your values are saved for later).\n"
                },

                // Semi-Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Directly manage garbage systems; leaves vanilla garbage logic running.\n\n" +
                    "- When Semi-Magic is ON [ ✓ ], Total Magic is forced OFF.\n" +
                    "- Sliders only apply when Semi-Magic is enabled.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Truck load capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**How much garbage each truck can carry.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Processing speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**How fast facilities process incoming garbage.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Facility storage capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**How much garbage a facility can store.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility truck count" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**How many trucks each facility can dispatch.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Apply recommended Semi-Magic values:\n" +
                    "- Truck load capacity: **200%**\n" +
                    "- Processing speed: **200%**\n" +
                    "- Storage capacity: **160%**\n" +
                    "- Facility truck count: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "Game Defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Set all sliders back to **100%** (vanilla values)."
                },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageCheck)), "Garbage Check" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageCheck)),
                    "Runs a one-time snapshot (producers, requests, trucks, and current limits).\n" +
                    "Writes results into the Status section below."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusSummary)), "Summary" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusSummary)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusDetails)), "Details" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusDetails)), string.Empty },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Open the Paradox Mods page." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Open Discord invite in your browser." },

                // Usage block (label-as-text pattern)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Auto Clean state>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * All garbage is instantly removed\n" +
                    " <-------------------------------------->\n\n" +
                    "<Self-Manage state>\n" +
                    "  * Enable Semi-Magic = **[ ✓ ]**\n" +
                    "  * Set sliders as you like.\n" +
                    "  * Vanilla garbage logic with better managed trucks/facilities.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normal vanilla game>\n" +
                    "  * Enable Semi-Magic = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * All sliders at 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },


                                // Status (button + fields)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusSummary)), "Status" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusSummary)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusDetails)), "Details" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusDetails)), string.Empty },

                // -----------------------------------------------------------------
                // Status runtime strings (used by GarbageStatusSystem)
                // -----------------------------------------------------------------
                { "MGT.Status.Running", "Running…" },
                { "MGT.Status.NoCity", "No city loaded yet." },

                { "MGT.Status.Title", "Garbage Status ({0})" },
                { "MGT.Status.City", "City" },
                { "MGT.Status.Frame", "Frame" },

                { "MGT.Status.Mode", "Mode" },
                { "MGT.Status.Mode.TotalMagic", "Total Magic" },
                { "MGT.Status.Mode.SemiMagic", "Semi-Magic" },

                { "MGT.Status.Params", "Limits: Request={0}, Collect={1}, Warning={2}, Max={3}" },
                { "MGT.Status.Params.Missing", "Limits: <GarbageParameterData not available>" },

                { "MGT.Status.Line.Producers", "Producers: total={0}, garbage>0={1}, >Request={2}, >Warning={3}, hasRequestPtr={4}" },
                { "MGT.Status.Line.Requests", "Collect requests: total={0}, pending={1}, dispatched={2}" },
                { "MGT.Status.Line.Trucks", "Garbage trucks: total={0}, parked={1}, moving={2}, returning={3}, disabled={4}" },

                { "MGT.Status.TopFacilities.Header", "Facilities (most moving trucks)" },
                { "MGT.Status.TopFacilities.Line", "- Facility {0}: total={1}, moving={2}, parked={3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
