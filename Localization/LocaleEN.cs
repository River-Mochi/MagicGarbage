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
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Enabled [ ✓ ]** keeps the whole city clean.\n\n" +
                    "While **Total Magic** is ON:\n" +
                    "- Trash Boss is forced OFF.\n" +
                    "- Trash Boss sliders are not applied (values are saved for later).\n" +
                    "- A few trucks may still move due to vanilla dispatch logic timing."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Directly manage garbage systems; leaves vanilla garbage logic running.\n\n" +
                    "- When **Trash Boss is ON [ ✓ ]**, Total Magic is forced OFF.\n" +
                    "- Sliders only apply when Trash Boss is enabled.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Truck load capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**How much garbage each truck can carry.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Facility storage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**How much garbage a facility can store.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Facility Process speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**How fast facilities process incoming garbage.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility Fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**How many trucks each facility can dispatch.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "Building thresholds" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "Optional: raises **thresholds** a building needs to get garbage collection. \n" +
                    "Increasing this could help reduce garbage truck traffic; but too high reduces trips to get garbage.\n" +
                    "Most people <do not> need to adjust this. Mod worked fine before this option was added, it's just bonus for experiments.\n"+
                    "--------------------------------\n" +
                    "- **Dispatch Request threshold (R)** = building garbage needed to call a <truck dispatch request>.\n" +
                    "- **Pickup threshold (P)** = minimum building garbage before a truck can collect from it.\n" +
                    "**1x** = vanilla (100 R, 20 P). Note: **1,000** garbage units is usually **1t**.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "At **20x** slider, the building's **R** must reach >= **2,000 (2t)** units before a truck gets a <dispatch request>;\n" +
                    "Vanilla game also has trucks stop at buildings to/from the <dispatch> building if the truck is not empty; at 20x, buildings en route need more than **400 garbage** (20 x vanilla P = 20).\n" +
                    "Balance advised: look at the detailed log report button frequently while adjusting this.\n" +
                    "You might need to increase truck capacity if you make threshold high because it means houses hold garbage a lot longer before calling for a truck."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Apply recommended Trash Boss values:\n" +
                    "- Truck load capacity: **200%**\n" +
                    "- Dispatch threshold: **5x**\n" +
                    "- Processing speed: **200%**\n" +
                    "- Storage capacity: **150%**\n" +
                    "- Facility truck count: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Game Defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Set all Trash Boss sliders back to vanilla values.\n" +
                    "- Percent sliders return to **100%**.\n" +
                    "- Dispatch threshold returns to **1x**."
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
                    "  * Garbage is auto removed - Done.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Self-Manage state>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Set sliders as desired.\n" +
                    "  * Same game garbage; better self-managed trucks/facilities.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normal vanilla game>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * All sliders at vanilla values\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Usage" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Garbage/mo." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Shows the current citywide garbage amount and the total garbage processing rate.\n" +
                    "Increase processing if the monthly garbage produced is much higher.\n" +
                    "**Produced** and **Processed** use tons per month.\n" +
                    "<Update time = last refreshed.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Collect requests" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = active collection requests not currently assigned to a truck or path.\n" +
                    "**Dispatched** = active collection requests already assigned.\n" +
                    "**Total** = counts current **active** request entity (in the garbage pipeline).\n\n" +
                    "Tech note: This is different from <Above request threshold>. This counts <requests>, not buildings.\n" +
                    "Some pending requests will be assigned later; some can also clear later if vanilla revalidation decides the target no longer needs service."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = buildings currently holding any garbage.\n" +
                    "**Total** = all garbage-producing buildings in the city.\n" +
                    "**Above request threshold** = current count of **buildings** with enough garbage to create a collect request.\n" +
                    "In vanilla, request threshold is **100** internal garbage units.\n" +
                    "Trash Boss **Dispatch threshold** raises both pickup and request thresholds together.\n" +
                    "This reduces garbage truck traffic because it lowers the total buildings with <above request threshold> and <dispatched> totals."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Facilities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Summary of counted garbage facilities.\n" +
                    "**Facilities** = counted garbage buildings.\n" +
                    "**Trucks total** = garbage trucks owned by those facilities.\n" +
                    "**Max workers** = total worker capacity across those same facilities."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = trucks currently out in the city.\n" +
                    "**Returning** = subset of moving trucks flagged to go back to their facility.\n" +
                    "**Parked** = trucks parked at a facility.\n" +
                    "**Total** = count of all garbage trucks."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detailed Status to Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Send a more detailed garbage report into **Logs/MagicGarbage.log**.\n" +
                    "Includes a short legend, vanilla reference values, and many extra real city current garbage statistics."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Open the game Logs/.. folder."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "No city loaded yet." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed | updated {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} facilities | {1:N0} trucks total | {2:N0} max workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "No facility data yet." },

                // Log strings
                { "MG.Status.Log.Title", "Garbage Status ({0})" },
                { "MG.Status.Log.City", "City: {0}" },
                { "MG.Status.Log.Mode", "Mode: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legend:\n" +
                    "- Produced/Processed uses tons per month.\n" +
                    "- Threshold values below use internal garbage units, not tons.\n" +
                    "- For player-facing, the game converts 1,000 units = 1t.\n" +
                    "Dispatch threshold slider:\n" +
                    "  - Pickup threshold = minimum garbage before a truck will collect from a building.\n" +
                    "  - Request threshold = minimum garbage before the game creates or keeps a collect request.\n" +
                    "- Warning icon = garbage amount that causes a warning icon to appear above a building.\n" +
                    "- Hard cap = maximum garbage a building can accumulate.\n" +
                    "- Pending = active requests not currently assigned to a truck or path.\n" +
                    "- Some pending requests will be assigned later; some can also clear later if vanilla revalidation decides the target no longer needs service.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Game Thresholds (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData not available>" },
                { "MG.Status.Log.GarbageProcessing", "Garbage: {0:N0} t/mo | Processing: {1:N0} t/mo" },
                { "MG.Status.Log.Requests", "Collect Requests: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Highest pending target garbage: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.Producers", "Buildings: {0:N0} total | {1:N0} has garbage | {2:N0} above request threshold | {3:N0} warning-level" },
                { "MG.Status.Log.ProducerGarbageStats", "Building garbage (non-zero only): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "Buildings near warning (>= {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Facilities: {0:N0} total | {1:N0} trucks total | {2:N0} max workers" },
                { "MG.Status.Log.Trucks", "Garbage trucks: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Facility Summary" },
                { "MG.Status.Log.FacilityLine", "- Facility {0}: moving={2:N0}, parked={3:N0}, total={1:N0}, max workers={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
