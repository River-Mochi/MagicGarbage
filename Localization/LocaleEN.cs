// File: Locale/LocaleEN.cs
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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Self Manage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod info" },
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

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility Fleet" },
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

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Open the Paradox Mods page." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Open Discord invite in your browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Auto Clean state>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * All garbage is instantly removed\n" +
                    " <-------------------------------------->\n\n" +
                    "<Self-Manage state>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Set sliders as desired.\n" +
                    "  * Vanilla garbage logic with better managed trucks/facilities.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normal vanilla game>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * All sliders at 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Producers" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Collect Requests" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "Request = garbage amount where a building starts qualifying for collection\n" +
                    "Collect = collection-side threshold used by the simulation\n" +
                    "Warning = garbage level for the warning state/icon.\n" +
                    "Max = hard cap on garbage accumulation."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Facilities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)), string.Empty },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Send Status to Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Write a detailed garbage report into **Logs/MagicGarbage.log**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Open the Log folder."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "No city loaded yet." },

                { "MG.Status.Row.GarbageProcessing", "Garbage: {0:N0} t/mo | Processing: {1:N0} t/mo | updated {2}" },
                { "MG.Status.Row.Producers", "Buildings with garbage: {0:N0} / {1:N0} | Already requested: {2:N0}" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total " },
                { "MG.Status.Row.Trucks", "{1:N0} moving | {2:N0} parked | {3:N0} returning | {0:N0} total" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} facilities: {1:N0} moving trucks | {2:N0} total trucks" },
                { "MG.Status.Row.FacilitiesNone", "No facility truck data yet." },

                // Log strings
                { "MG.Status.Log.Title", "Garbage Status ({0})" },
                { "MG.Status.Log.City", "City: {0}" },
                { "MG.Status.Log.Mode", "Mode: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Thresholds", "Thresholds: request starts at {0:N0}, dispatch target {1:N0}, warning icon at {2:N0}, hard cap {3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData not available>" },
                { "MG.Status.Log.GarbageProcessing", "Garbage: {0:N0} t/mo | Processing: {1:N0} t/mo" },
                { "MG.Status.Log.Producers", "Buildings: total={0:N0}, with garbage={1:N0}, above request threshold={2:N0}, warning-level={3:N0}, already linked to a request={4:N0}" },
                { "MG.Status.Log.Requests", "Collect Requests: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.Trucks", "Garbage trucks: parked={1:N0}, moving={2:N0}, returning={3:N0}, disabled={4:N0}, total={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "Facility Summary" },
                { "MG.Status.Log.FacilityLine", "- Facility {0}: , moving={2:N0}, parked={3:N0}, total={1:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
