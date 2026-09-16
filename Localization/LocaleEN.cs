// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
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
                    "- Sliders only apply when Trash Boss is enabled.\n" +
                    "- Both Total Magic + Trash Boss can be **OFF** to get vanilla settings,\n" +
                    "  and you can still see **Status report** which updates only when you enter Options menu (lightweight)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Truck load capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**How much garbage each truck can carry.**\n" +
                    "**100% = vanilla** truck capacity (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Facility storage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**How much garbage a facility can store.**\n" +
                    "**100% = vanilla** storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Facility processing speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**How fast facilities process incoming garbage.**\n" +
                    "**100% = vanilla** processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**How many trucks each facility can dispatch.**\n" +
                    "**100% = vanilla** number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Target reserve" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**How early trucks become selective about pickups on the way to their assigned building.**\n" +
                    "**10% is the vanilla 1.6.2 value.**\n" +
                    "For a normal 20t truck:\n" +
                    "- 10% starts protecting its assigned stop 2t earlier.\n" +
                    "- 15% starts 3t earlier.\n" +
                    "- 25% starts 5t earlier.\n" +
                    "Higher values give a bigger safety margin. Trucks skip small pickups sooner, helping leave more room for the assigned building."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applies balanced values for busy cities.\n" +
                    "Truck load **200%** | storage **150%** | processing **250%**\n" +
                    "Fleet **100%** | target reserve **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Reset Sliders" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Resets the standard Trash Boss sliders.\n" +
                    "- Percent sliders return to **100%**.\n" +
                    "- Target reserve returns to the **10% vanilla** value.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Open the Paradox Mods page." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Open Discord invite in a browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Auto Clean state>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * Garbage is auto removed - Done.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Self-Manage state>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Set sliders as desired.\n" +
                    "  * Same game garbage; better self-managed trucks/facilities.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Status / vanilla state>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Status report only.\n" +
                    "  * Vanilla garbage game unchanged."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Usage" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Garbage Service Rating" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "The game's citywide average garbage happiness effect.\n" +
                    "A good overall rating can still include a few problem buildings, so check **7t+ buildings** too.\n" +
                    "**0 = Excellent overall**\n" +
                    "**-1 = Needs a minor tweak**\n" +
                    "**-2 to -4 = Slightly stinky**\n" +
                    "**-5 or lower = Garbage problem**\n\n" +
                    "Improve service with the truck and facility sliders, then let the city run before checking again."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Count of garbage-producing buildings at or above **7000 / 7t**.\n" +
                    "This fixed early-warning indicator helps you decide whether to increase service before buildings reach the game's warning-icon level.\n" +
                    "Use Detailed Status to Log to list their Entity IDs."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Garbage/mo." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Shows citywide garbage production, current processing, and available facility processing capacity.\n" +
                    "Increase processing if monthly production is higher than capacity.\n" +
                    "All values use tons per month."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Collect requests" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = active collection requests not currently assigned to a truck or path.\n" +
                    "**Dispatched** = active collection requests already assigned.\n" +
                    "**Total** = all current **active** requests in the garbage pipeline.\n\n" +
                    "This differs from **Above request threshold**, which counts buildings instead of requests.\n" +
                    "Some pending requests will be assigned later; some can also clear later if vanilla revalidation decides the target no longer needs service."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = buildings currently holding any garbage.\n" +
                    "**Total** = all garbage-producing buildings in the city.\n" +
                    "**Above request threshold** = current count of **buildings** with enough garbage to create a collect request.\n" +
                    "The Detailed Status log shows the game's current live request threshold.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Facilities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Summary of counted garbage facilities.\n" +
                    "**Facilities** = counted garbage buildings.\n" +
                    "**Garbage trucks** = normal collection trucks. At Industrial Waste facilities, they collect industrial waste instead of garbage.\n" +
                    "**Dump trucks** = inter-facility transfers of garbage.\n" +
                    "**Max workers** = total worker capacity across those same facilities."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Garbage trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = trucks currently out in the city.\n" +
                    "**Returning** = subset of moving trucks flagged to go back to their facility.\n" +
                    "**Parked** = trucks parked at a facility.\n" +
                    "**Total** = count of all garbage trucks."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detailed Status to Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Send a more detailed garbage report into **Logs/MagicGarbage.log**.\n" +
                    "Includes organized city garbage statistics."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens **MagicGarbage.log**. If it is missing or cannot be opened, opens the game Logs folder instead."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "No city loaded yet." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent overall ({0:N0}) | updated {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Needs a minor tweak ({0:N0}) | updated {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Slightly stinky ({0:N0}) | updated {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Garbage problem ({0:N0}) | updated {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} buildings at 7t+" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {2:N0} t Processing | {1:N0} t Capacity" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} facilities | {1:N0}/{2:N0} garbage/dump trucks | {3:N0} workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "No facility data yet." },

                // Log strings
                { "MG.Status.Log.Title", "Garbage Status ({0})" },
                { "MG.Status.Log.City", "City: {0}" },
                { "MG.Status.Log.Mode", "Mode: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Current mod settings" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash Boss sliders (saved): truck load={0:N0}% | facility storage={1:N0}% | facility process={2:N0}% | facility fleet={3:N0}%"
                },
                
                { "MG.Status.Log.Legend",
                    "Legend:\n" +
                    "- Production, current processing, and capacity use tons per month.\n" +
                    "- Threshold values below use internal garbage units, not tons.\n" +
                    "- For player-facing, the game converts 100 units = 0.1t and 1,000 units = 1t.\n" +
                    "- Garbage Service Rating = game city garbage happiness factor.\n" +
                    "  - 0 = Excellent overall\n" +
                    "  - -1 = Needs a minor tweak\n" +
                    "  - -2 to -4 = Slightly stinky\n" +
                    "  - -5 to -10 = Garbage problem\n" +
                    "Routing values:\n" +
                    "  - Pickup threshold is the vanilla minimum; target-aware routing can raise it per truck to protect capacity for its destination.\n" +
                    "  - Request threshold is the minimum garbage before the game creates or keeps a collect request.\n" +
                    "- Warning icon appears when building garbage exceeds the live warning level.\n" +
                    "- Hard cap = maximum garbage a building can accumulate.\n" +
                    "- Pending = active requests not currently assigned to a truck or path.\n" +
                    "- Some pending requests will be assigned later; some can also clear later if vanilla revalidation decides the target no longer needs service.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Game Thresholds (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData not available>" },
                { "MG.Status.Log.AdaptiveMargin", "Target reserve: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Target reserve: current={0:N0}% | game baseline at load={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Garbage production: {0:N0} t/mo | Current processing: {2:N0} t/mo | Processing capacity: {1:N0} t/mo" },
                { "MG.Status.Log.GarbageServiceRating", "Garbage Service Rating: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "Collect Requests: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Highest pending target garbage: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.PendingPeakNone", "Highest pending target garbage: none" },
                { "MG.Status.Log.Producers", "Buildings: {0:N0} above warning level | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold" },
                { "MG.Status.Log.ProducerGarbageStats", "Building garbage (non-zero only): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "Buildings near warning icon (at least {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Facilities: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Garbage trucks: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Facility Summary" },
                { "MG.Status.Log.FacilityLine", "- Facility {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent overall" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Needs a minor tweak" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Slightly stinky" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Garbage problem" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + Service" },
                { "MG.Status.Log.RequestsHeader", "Requests" },
                { "MG.Status.Log.BuildingsHeader", "Buildings" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Buildings at 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Local Garbage Transfer Probe" },
                { "MG.Status.Log.LocalTransferProbeNone", "No local garbage facilities found." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Outside Connection Garbage Transfer Probe" },
                { "MG.Status.Log.OutsideTransferProbeNone", "No outside-connection garbage facilities found." },

                { "MG.Status.Log.TransferProbeHeader", "Garbage Transfer Probe" },
                { "MG.Status.Log.TransferProbeNone", "No garbage storage-transfer facilities found." },

                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accept={5:N2} | send={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "Trucks" },

                { "MG.Status.Log.CriticalBuildingsNone", "none" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
