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
            // Title (keep exact logic)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "About"   },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp),  "Self Manage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp),     "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE NOTES" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Enabled [ ✓ ]** keeps the whole city clean.\n\n" +
                    "While **Total Magic** is ON:\n" +
                    "- Trash Boss is forced OFF.\n" +
                    "- Trash Boss sliders are not applied (values are saved for later).\n"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Directly manage garbage systems; leaves vanilla garbage logic running.\n\n" +
                    "- When Trash Boss is ON [ ✓ ], Total Magic is forced OFF.\n" +
                    "- Sliders only apply when Trash Boss is enabled.\n"
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Apply recommended Trash Boss values:\n" +
                    "- Truck load capacity: **200%**\n" +
                    "- Processing speed: **200%**\n" +
                    "- Storage capacity: **160%**\n" +
                    "- Facility truck count: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Game Defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Set all sliders back to **100%** (vanilla values)."
                },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RefreshGarbageStatus)), "Refresh status now" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RefreshGarbageStatus)),
                    "Refreshes the Status lines below.\n\n" +
                    "Also writes the full detailed report into **MagicGarbage.log**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRates)), "Rates" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRates)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Producers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Requests" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility1)), "Facility #1" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility1)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility2)), "Facility #2" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility2)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility3)), "Facility #3" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility3)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility4)), "Facility #4" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility4)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility5)), "Facility #5" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility5)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility6)), "Facility #6" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility6)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility7)), "Facility #7" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility7)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility8)), "Facility #8" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility8)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility9)), "Facility #9" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility9)), string.Empty },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacility10)), "Facility #10" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacility10)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusLastUpdate)), "Snapshot" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusLastUpdate)), string.Empty },

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
                    "  * Enable Trash Boss = **[ ✓ ]**\n" +
                    "  * Set sliders as desired.\n" +
                    "  * Vanilla garbage logic with better managed trucks/facilities.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normal vanilla game>\n" +
                    "  * Enable Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * All sliders at 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // -----------------------------------------------------------------
                // Status runtime strings (used by GarbageStatusSystem)
                // Prefix changed: MGT.Status.* -> MG.Status.*
                // -----------------------------------------------------------------
                { "MG.Status.Running", "Running…" },
                { "MG.Status.NoCity", "No city loaded yet." },

                { "MG.Status.Title", "Garbage Status ({0})" },

                { "MG.Status.Mode", "Mode" },
                { "MG.Status.Mode.TotalMagic", "Total Magic" },
                { "MG.Status.Mode.TrashBoss", "Trash Boss" },

                { "MG.Status.Params", "Limits: Request={0}, Collect={1}, Warning={2}, Max={3}" },
                { "MG.Status.Params.Missing", "Limits: <GarbageParameterData not available>" },

                { "MG.Status.Rates", "Garbage: {0} t/mo | Processing: {1} t/mo" },

                { "MG.Status.Line.Producers", "Producers: {0:N0} (garbage>0: {1:N0}, >Req: {2:N0}, >Warn: {3:N0}, hasPtr: {4:N0})" },
                { "MG.Status.Line.Requests", "Collect requests: total={0:N0}, pending={1:N0}, dispatched={2:N0}" },
                { "MG.Status.Line.Trucks", "Garbage trucks: total={0:N0}, parked={1:N0}, moving={2:N0}, returning={3:N0}, disabled={4:N0}" },

                { "MG.Status.TopFacilities.Line", "Facility {0}: total={1:N0}, moving={2:N0}, parked={3:N0}" },

                { "MG.Status.LastUpdate", "Last update: {0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
