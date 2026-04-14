// File: Systems/GarbageStatus.cs
// Purpose: FastBikes-style Options UI status cache.
// Behavior:
// - Refresh runs only when Options UI reads status properties.
// - Button forces refresh and writes full report to MagicGarbage.log.
// - No per-frame simulation work.

namespace MagicGarbage
{
    using Game;
    using Game.SceneFlow;
    using System;
    using System.Text;
    using Unity.Entities;
    using UnityEngine;

    internal static class GarbageStatus
    {
        private const int AutoRefreshSeconds = 10;

        private static int s_LastUiFrame = -1;
        private static long s_LastRefreshUtcTicks;
        private static bool s_WasInGame;

        private static string s_UiGarbageServiceRating = "-";
        private static string s_UiGarbageProcessing = "-";
        private static string s_UiProducers = "-";
        private static string s_UiRequests = "-";
        private static string s_UiFacilities = "-";
        private static string s_UiTrucks = "-";
        private static string s_UiCriticalBuildings = "-";

        public static void ResetUi()
        {
            s_LastUiFrame = -1;
            s_LastRefreshUtcTicks = 0;
            s_WasInGame = false;

            s_UiGarbageServiceRating = "-";
            s_UiGarbageProcessing = "-";
            s_UiProducers = "-";
            s_UiRequests = "-";
            s_UiTrucks = "-";
            s_UiFacilities = "-";
            s_UiCriticalBuildings = "-";
        }

        public static void RefreshIfNeeded()
        {
            int frame = Time.frameCount;
            if (frame == s_LastUiFrame)
            {
                return;
            }

            s_LastUiFrame = frame;

            bool isGame = IsGameMode();
            if (!isGame)
            {
                s_WasInGame = false;
                SetNoCityUi();
                return;
            }

            if (!s_WasInGame)
            {
                s_WasInGame = true;
                RefreshNow(writeToLog: false);
                return;
            }

            long nowUtc = DateTime.UtcNow.Ticks;
            if (s_LastRefreshUtcTicks > 0)
            {
                long ageTicks = nowUtc - s_LastRefreshUtcTicks;
                long minTicks = AutoRefreshSeconds * TimeSpan.TicksPerSecond;
                if (ageTicks < minTicks)
                {
                    return;
                }
            }

            RefreshNow(writeToLog: false);
        }

        public static void RefreshNow(bool writeToLog)
        {
            if (!IsGameMode())
            {
                SetNoCityUi();

                if (writeToLog)
                {
                    Mod.Log.Info($"{Mod.ModTag} {Mod.L("MG.Status.NoCity")}");
                }

                return;
            }

            if (!TryGetWorld(out World world))
            {
                SetNoCityUi();

                if (writeToLog)
                {
                    Mod.Log.Info($"{Mod.ModTag} {Mod.L("MG.Status.NoCity")}");
                }

                return;
            }

            GarbageStatusSystem sys = world.GetOrCreateSystemManaged<GarbageStatusSystem>();
            GarbageStatusSystem.Snapshot snap = sys.BuildSnapshot();

            if (!snap.InGame)
            {
                SetNoCityUi();

                if (writeToLog)
                {
                    Mod.Log.Info($"{Mod.ModTag} {Mod.L("MG.Status.NoCity")}");
                }

                return;
            }

            GarbageStatusSystem.CriticalBuildingEntry[] criticalBuildings = sys.GetCriticalBuildings();
            ApplySnapshotToUi(snap, criticalBuildings.Length);

            s_LastRefreshUtcTicks = DateTime.UtcNow.Ticks;

            if (writeToLog)
            {
                string logText = BuildLogText(snap, criticalBuildings);
                Mod.Log.Info($"{Mod.ModTag} {logText}");
            }
        }

        public static string GetUiGarbageServiceRating()
        {
            return string.IsNullOrEmpty(s_UiGarbageServiceRating) ? "-" : s_UiGarbageServiceRating;
        }

        public static string GetUiGarbageProcessing()
        {
            return string.IsNullOrEmpty(s_UiGarbageProcessing) ? "-" : s_UiGarbageProcessing;
        }

        public static string GetUiProducers()
        {
            return string.IsNullOrEmpty(s_UiProducers) ? "-" : s_UiProducers;
        }

        public static string GetUiRequests()
        {
            return string.IsNullOrEmpty(s_UiRequests) ? "-" : s_UiRequests;
        }

        public static string GetUiTrucks()
        {
            return string.IsNullOrEmpty(s_UiTrucks) ? "-" : s_UiTrucks;
        }

        public static string GetUiFacilities()
        {
            return string.IsNullOrEmpty(s_UiFacilities) ? "-" : s_UiFacilities;
        }

        public static string GetUiCriticalBuildings()
        {
            return string.IsNullOrEmpty(s_UiCriticalBuildings) ? "-" : s_UiCriticalBuildings;
        }

        private static void ApplySnapshotToUi(GarbageStatusSystem.Snapshot snap, int criticalBuildings)
        {
            string updatedAt = DateTime.Now.ToString("HH:mm:ss");

            s_UiGarbageServiceRating = BuildGarbageServiceRatingUi(
                snap.GarbageServiceRatingRounded,
                updatedAt);

            s_UiGarbageProcessing = Mod.LF(
                "MG.Status.Row.GarbageProcessing",
                snap.GarbageTonsPerMonth,
                snap.ProcessingTonsPerMonth);

            s_UiRequests = Mod.LF(
                "MG.Status.Row.Requests",
                snap.RequestTotal,
                snap.RequestPending,
                snap.RequestDispatched);

            s_UiProducers = Mod.LF(
                "MG.Status.Row.Producers",
                snap.ProducerGarbageGt0,
                snap.ProducerTotal,
                snap.ProducerOverRequest);

            s_UiCriticalBuildings = Mod.LF(
                "MG.Status.Row.CriticalBuildings",
                criticalBuildings);

            s_UiFacilities = BuildFacilitiesSummary(snap);

            s_UiTrucks = Mod.LF(
                "MG.Status.Row.Trucks",
                snap.TruckTotal,
                snap.TruckMoving,
                snap.TruckParked,
                snap.TruckReturning);
        }

        private static string BuildFacilitiesSummary(GarbageStatusSystem.Snapshot snap)
        {
            if (snap.FacilityTotal <= 0)
            {
                return Mod.L("MG.Status.Row.FacilitiesNone");
            }

            return Mod.LF(
                "MG.Status.Row.FacilitiesSummary",
                snap.FacilityTotal,
                snap.FacilityGarbageTruckTotal,
                snap.FacilityDumpTruckTotal,
                snap.FacilityMaxWorkers);
        }

        // Simple player-facing comments based on rounded city garbage happiness factor.
        private static string BuildGarbageServiceRatingUi(int rounded, string updatedAt)
        {
            if (rounded >= 0)
            {
                return Mod.LF("MG.Status.Row.GarbageServiceRating.Excellent", rounded, updatedAt);
            }

            if (rounded == -1)
            {
                return Mod.LF("MG.Status.Row.GarbageServiceRating.Minor", rounded, updatedAt);
            }

            if (rounded >= -4)
            {
                return Mod.LF("MG.Status.Row.GarbageServiceRating.Stinky", rounded, updatedAt);
            }

            return Mod.LF("MG.Status.Row.GarbageServiceRating.Problem", rounded, updatedAt);
        }

        // Same rating bands as Options UI, but returned as plain labels for detailed log button.
        private static string BuildGarbageServiceRatingLabel(int rounded)
        {
            if (rounded >= 0)
            {
                return Mod.L("MG.Status.Log.GarbageServiceRating.Excellent");
            }

            if (rounded == -1)
            {
                return Mod.L("MG.Status.Log.GarbageServiceRating.Minor");
            }

            if (rounded >= -4)
            {
                return Mod.L("MG.Status.Log.GarbageServiceRating.Stinky");
            }

            return Mod.L("MG.Status.Log.GarbageServiceRating.Problem");
        }

        private static string BuildLogText(
            GarbageStatusSystem.Snapshot snap,
            GarbageStatusSystem.CriticalBuildingEntry[] criticalBuildings)
        {
            string nowText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            StringBuilder log = new StringBuilder(5200);

            log.AppendLine(Mod.LF("MG.Status.Log.Title", nowText));
            log.AppendLine(Mod.LF("MG.Status.Log.City", Fmt(snap.City)));
            log.AppendLine(Mod.LF("MG.Status.Log.Mode", snap.TotalMagic, snap.TrashBoss));
            log.AppendLine();

            AppendSettingsBlock(log);

            AppendSectionHeader(log, Mod.L("MG.Status.Log.ThresholdsHeader"));

            if (snap.HaveParams)
            {
                log.AppendLine(Mod.LF(
                    "MG.Status.Log.Thresholds",
                    snap.RequestLimit,
                    snap.CollectLimit,
                    snap.WarningLimit,
                    snap.MaxAccumulation));
            }
            else
            {
                log.AppendLine(Mod.L("MG.Status.Log.ThresholdsMissing"));
            }

            log.AppendLine(Mod.LF(
                "MG.Status.Log.GarbageProcessing",
                snap.GarbageTonsPerMonth,
                snap.ProcessingTonsPerMonth));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.GarbageServiceRating",
                BuildGarbageServiceRatingLabel(snap.GarbageServiceRatingRounded),
                snap.GarbageServiceRatingRaw,
                snap.GarbageServiceRatingRounded));

            AppendSectionHeader(log, Mod.L("MG.Status.Log.RequestsHeader"));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.Requests",
                snap.RequestTotal,
                snap.RequestPending,
                snap.RequestDispatched));

            if (snap.PendingMaxTargetGarbage <= 0 || snap.PendingMaxTargetEntity == Entity.Null)
            {
                log.AppendLine(Mod.L("MG.Status.Log.PendingPeakNone"));
            }
            else
            {
                log.AppendLine(Mod.LF(
                    "MG.Status.Log.PendingPeak",
                    snap.PendingMaxTargetGarbage,
                    ToTons(snap.PendingMaxTargetGarbage),
                    Fmt(snap.PendingMaxTargetEntity)));
            }

            AppendPriorityAssistBlock(log);

            AppendSectionHeader(log, Mod.L("MG.Status.Log.BuildingsHeader"));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.Producers",
                snap.ProducerOverWarning,
                snap.ProducerTotal,
                snap.ProducerGarbageGt0,
                snap.ProducerOverRequest));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.ProducerGarbageStats",
                snap.ProducerAverageGarbage,
                ToTons(snap.ProducerAverageGarbage),
                snap.ProducerMedianGarbage,
                ToTons(snap.ProducerMedianGarbage),
                snap.ProducerMaxGarbage,
                ToTons(snap.ProducerMaxGarbage),
                Fmt(snap.ProducerMaxGarbageEntity)));

            int nearWarningUnits = snap.HaveParams ? (int)Math.Ceiling(snap.WarningLimit * 0.75d) : 0;

            log.AppendLine(Mod.LF(
                "MG.Status.Log.NearWarning75",
                snap.ProducerNearWarning75,
                nearWarningUnits,
                ToTons(nearWarningUnits)));

            AppendSectionHeader(log, Mod.L("MG.Status.Log.CriticalBuildingsHeader"));

            if (criticalBuildings == null || criticalBuildings.Length == 0)
            {
                log.AppendLine(Mod.L("MG.Status.Log.CriticalBuildingsNone"));
            }
            else
            {
                for (int i = 0; i < criticalBuildings.Length; i++)
                {
                    GarbageStatusSystem.CriticalBuildingEntry entry = criticalBuildings[i];

                    log.AppendLine(Mod.LF(
                        "MG.Status.Log.CriticalBuildingLine",
                        Fmt(entry.Building),
                        entry.Garbage,
                        ToTons(entry.Garbage),
                        entry.PrefabName));
                }
            }

            AppendSectionHeader(log, Mod.L("MG.Status.Log.FacilitiesHeader"));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.FacilitiesSummary",
                snap.FacilityTotal,
                snap.FacilityGarbageTruckTotal,
                snap.FacilityDumpTruckTotal,
                snap.FacilityDumpTruckMoving,
                snap.FacilityMaxWorkers));

            if (snap.Facilities != null && snap.Facilities.Length > 0)
            {
                for (int i = 0; i < snap.Facilities.Length; i++)
                {
                    GarbageStatusSystem.FacilityEntry f = snap.Facilities[i];
                    log.AppendLine(Mod.LF(
                        "MG.Status.Log.FacilityLine",
                        Fmt(f.Facility),
                        f.GarbageTruckTotal,
                        f.GarbageTruckMoving,
                        f.GarbageTruckParked,
                        f.DumpTruckTotal,
                        f.DumpTruckMoving,
                        f.MaxWorkers));
                }
            }

            AppendSectionHeader(log, Mod.L("MG.Status.Log.TrucksHeader"));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.Trucks",
                snap.TruckTotal,
                snap.TruckParked,
                snap.TruckMoving,
                snap.TruckReturning,
                snap.TruckDisabled));

            return log.ToString().TrimEnd();
        }

        // -------- Helpers --------

        private static void AppendPriorityAssistBlock(StringBuilder log)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            GarbagePriorityAssistSystem sys = world.GetExistingSystemManaged<GarbagePriorityAssistSystem>();
            if (sys == null)
            {
                return;
            }

            AppendSectionHeader(log, Mod.L("MG.Status.Log.PriorityHeader"));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.PriorityState",
                sys.IsPriorityAssistLive,
                GarbagePriorityAssistSystem.UpdateIntervalFrames,
                sys.LastScannedRequests,
                sys.LastCriticalRequestTargets));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.PriorityPasses",
                sys.RaisedPassCount,
                sys.NormalPassCount));

            if (sys.HighestCriticalTargetGarbage <= 0 || sys.HighestCriticalTargetEntity == Entity.Null)
            {
                log.AppendLine(Mod.L("MG.Status.Log.PriorityPeakNone"));
            }
            else
            {
                string state = sys.HighestCriticalTargetDispatched
                    ? Mod.L("MG.Status.Log.PriorityPeakState.Dispatched")
                    : Mod.L("MG.Status.Log.PriorityPeakState.Pending");

                log.AppendLine(Mod.LF(
                    "MG.Status.Log.PriorityPeak",
                    sys.HighestCriticalTargetGarbage,
                    ToTons(sys.HighestCriticalTargetGarbage),
                    Fmt(sys.HighestCriticalTargetEntity),
                    state));
            }

#if DEBUG
            log.AppendLine(Mod.LF(
                "MG.Status.Log.PriorityPerf",
                sys.LastElapsedMs));
#endif
        }

        private static void AppendSettingsBlock(StringBuilder log)
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return;
            }

            AppendSectionHeader(log, Mod.L("MG.Status.Log.SettingsHeader"));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.SettingsTrashBoss",
                setting.GarbageTruckCapacityMultiplier,
                setting.GarbageFacilityStorageMultiplier,
                setting.GarbageFacilityProcessingMultiplier,
                setting.GarbageFacilityVehicleMultiplier));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.SettingsPowerUser",
                setting.PowerUserOptions,
                setting.GarbageDispatchRequestThreshold,
                setting.GarbagePickupThreshold,
                setting.GarbageHappinessBaseline,
                setting.GarbageHappinessStep,
                setting.GarbageAccumulationRate));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.SettingsPriority",
                setting.PrioritySystemEnabled,
                Setting.PriorityCriticalGarbage,
                ToTons(Setting.PriorityCriticalGarbage)));

            log.AppendLine();
        }

        private static void SetNoCityUi()
        {
            string msg = Mod.L("MG.Status.NoCity");

            s_UiGarbageServiceRating = "-";
            s_UiGarbageProcessing = msg;
            s_UiProducers = "-";
            s_UiRequests = "-";
            s_UiTrucks = "-";
            s_UiFacilities = "-";
            s_UiCriticalBuildings = "-";
        }

        private static bool IsGameMode()
        {
            GameManager gm = GameManager.instance;
            return gm != null && gm.gameMode.IsGame();
        }

        private static bool TryGetWorld(out World world)
        {
            world = World.DefaultGameObjectInjectionWorld;
            return world != null && world.IsCreated;
        }

        private static string Fmt(Entity e)
        {
            return e == Entity.Null ? "Entity.Null" : $"Entity({e.Index}:{e.Version})";
        }

        private static double ToTons(int garbageUnits)
        {
            return garbageUnits / 1000.0;
        }

        private static void AppendSectionHeader(StringBuilder log, string title)
        {
            log.AppendLine("================================");
            log.AppendLine(title);
            log.AppendLine("================================");
        }
    }
}
