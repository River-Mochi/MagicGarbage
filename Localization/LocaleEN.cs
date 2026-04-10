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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Power User" },
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
                    "- Both Total Magic + Trash Boss can be **OFF** if only **Status report** is needed.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Truck load capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**How much garbage each truck can carry.**\n" +
                    "**100% = normal** game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Facility storage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**How much garbage a facility can store.**\n" +
                    "**100% = vanilla** storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Facility Processing speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**How fast facilities process incoming garbage.**\n" +
                    "**100% = vanilla** processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility Fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**How many trucks each facility can dispatch.**\n" +
                    "**100% = vanilla** number of trucks.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**Recommended** standard Trash Boss values applied.\n" +
                    "Does not change Power User settings (separate)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Game Defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Set Trash Boss sliders back to **vanilla values**.\n" +
                    "Does <not> change Power User settings.\n" +
                    "**Vanilla:**\n" +
                    "- Percent sliders return to **100%**.\n" +
                    "- Dispatch Request Threshold returns to **100 units**.\n" +
                    "- Pickup Threshold returns to **20 units**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Power User Options" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Optional Advanced Settings\n" +
                    "<Warning: NOT needed> for good service; provided for players who want to experiment or learn more how systems work.\n" +
                    "When **OFF**, Power User items behave like normal **vanilla** game.\n" +
                    "When **ON**, the advanced **sliders appear**.\n\n" +
                    "<--- Happiness examples --->\n" +
                    " - <Vanilla> 100/65 = 1st penalty at <165>.\n" +
                    " - Click <Recommended> for 550/150 = 1st penalty at <700>.\n" +
                    " - <Very soft> 950/200 = 1st garbage penalty at <1150>.\n" +
                    "Convenience: last slider values are saved when this option is OFF (in case you want to enable later)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Building garbage needed before a truck dispatch request is created or kept.**\n" +
                    "Vanilla = **100** garbage units.\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "Keep this at or above the Pickup Threshold.\n" +
                    "This usually increases how many trucks are used vs parked."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimum building garbage before a truck can collect from it.**\n" +
                    "Vanilla = **20** garbage units.\n" +
                    "Pickup slider <cannot> be higher than Dispatch Request (DR); it's clamped to prevent logic mishap.\n" +
                    "If a truck is dispatched to a building and the pickup value is higher than DR, the truck may sometimes not be able to collect from the building (accumulation rate also affects this).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Garbage Happiness Baseline" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Building garbage level before it starts causing health + happiness penalty.**\n" +
                    "**Vanilla = 100** garbage units.\n" +
                    "Higher baseline = buildings can hold more garbage before penalty starts.\n" +
                    "100 garbage units = 0.1t\n" +
                    "Overview:\n" +
                    "- <Threshold> = trigger point for system behavior\n" +
                    "- <Baseline> = start point for penalty formula\n" +
                    "- <Step> = increment size in the formula, how fast penalty ramps after it starts"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Garbage Happiness Step" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Extra garbage over baseline amount that causes -1 penalty to start.**\n" +
                    "Vanilla = **65** garbage units.\n" +
                    "Higher step = slower penalty growth.\n" +
                    "Game caps garbage penalty at **-10**.\n" +
                    "Vanilla first <-1 penalty> happens at **165 garbage** (100 baseline + 65 step)\n" +
                    "Balance threshold changes with happiness sliders or incur heavier than normal penalties."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Accumulation Rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Scales supported building garbage source values.**\n" +
                    "Caution: this is a strong lever and changing the rate affects many things.\n" +
                    "It is possible to get a good system without using this.\n\n" +
                    "**100% = vanilla** accumulation rate.\n" +
                    "**20%** = much slower buildup.\n" +
                    "**200%** = double rate - a whole lot of garbage.\n" +
                    "At 20%, all Cims are obviously composting, thus a much lower garbage accumulation rate ;)\n\n" +
                    "Tech note: game adds garbage gradually across the day, not all at once."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recommended" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Apply **recommended** Power User values.\n" +
                    "Turns Power User ON.\n" +
                    "First garbage penalty starts at **700** garbage (550 baseline + 150 step).\n" +
                    "Garbage Accumulation Rate stays at **100%** vanilla unless changed manually."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Game Defaults" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Sets all Power User values **back to vanilla**.\n" +
                    "Turns **Power User OFF**.\n"
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
                    "  * Optional: turn on for advanced sliders (not required).\n" +
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
                    "Simple garbage Happiness rating from the game.\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= Needs minor tweak. Game goes between 0 to -1 often and could be ignored (number is rounded).\n" +
                    "**-2 to -4** = Slightly stinky\n" +
                    "**-5 to -10** = Garbage problem\n" +
                    "**Indirect knobs:** Use trash <sliders> to improve this over time by reducing actual garbage buildup.\n" +
                    "**Direct knobs:** <Garbage Happiness Baseline> + <Garbage Happiness Step> change what cims tolerate before they are unhappy.\n" +
                    "**Garbage Accumulation Rate**: changes how fast supported buildings produce garbage. Use with caution as balance is important. Most players never need to tweak this.\n" +
                    "<Update time = last refreshed.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Garbage/mo." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Shows the current citywide garbage amount and the total garbage processing rate.\n" +
                    "Increase processing if the monthly garbage produced is much higher.\n" +
                    "**Produced** and **Processed** use tons per month."
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
                    "Power User Options can override request and pickup thresholds.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Facilities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Summary of counted garbage facilities.\n" +
                    "**Facilities** = counted garbage buildings.\n" +
                    "**Garbage trucks** = normal collection trucks. At Industrial Waste facilities, they collect industrial waste instead of garbage.\n" +
                    "**Dump trucks** = inter-facility transfers of garbage.\n" +
                    "**Max workers** = total worker capacity across those same facilities."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Garbage Trucks" },
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

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | updated {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Needs minor tweak ({0:N0}) | updated {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Slightly stinky ({0:N0}) | updated {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Garbage problem ({0:N0}) | updated {1}" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed" },
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
                
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User (saved): enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legend:\n" +
                    "- Produced/Processed uses tons per month.\n" +
                    "- Threshold values below use internal garbage units, not tons.\n" +
                    "- For player-facing, the game converts 100 units = 0.1t and 1,000 units = 1t.\n" +
                    "- Garbage Service Rating = game city garbage happiness factor.\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = Needs minor tweak, or ignore\n" +
                    "  - -2 to -4 = Slightly stinky\n" +
                    "  - -5 to -10 = Garbage problem\n" +
                    "Threshold sliders:\n" +
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
                { "MG.Status.Log.GarbageServiceRating", "Garbage Service Rating: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "Collect Requests: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Highest pending target garbage: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.PendingPeakNone", "Highest pending target garbage: none" },
                { "MG.Status.Log.Producers", "Buildings: {0:N0} warning icons | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold " },
                { "MG.Status.Log.ProducerGarbageStats", "Building garbage (non-zero only): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "Buildings near warning icon (at least {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Facilities: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Garbage trucks: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Facility Summary" },
                { "MG.Status.Log.FacilityLine", "- Facility {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Needs minor tweak" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Slightly stinky" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Garbage problem" },
            };
        }

        public void Unload()
        {
        }
    }
}
