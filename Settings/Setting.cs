// <copyright file="Setting.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Settings/Setting.cs
// Options UI + settings for Magic Garbage.
// Main settings file. Status UI members live in Setting.Status.cs.

namespace MagicGarbage
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Colossal.IO.AssetDatabase;
    using CS2Shared.RiverMochi;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;
    using Unity.Mathematics;
    using UnityEngine;

    [FileLocation("ModsSettings/MagicGarbage/MagicGarbage")]
    [SettingsUITabOrder(ActionsTab, AboutTab)]
    [SettingsUIGroupOrder(
        TotalMagicGrp, TrashBossGrp, StatusGrp,
        AboutInfoGrp, AboutLinksGrp, AboutUsageGrp)]
    [SettingsUIShowGroupName(
        TotalMagicGrp, TrashBossGrp, StatusGrp,
        AboutLinksGrp, AboutUsageGrp)]
    public sealed partial class Setting : ModSetting
    {
        // ---- TABS ----
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ---- GROUPS ----
        public const string TotalMagicGrp = "TotalMagic";
        public const string TrashBossGrp = "TrashBoss";
        public const string StatusGrp = "Status";
        public const string AboutInfoGrp = "AboutInfo";
        public const string AboutLinksGrp = "AboutLinks";
        public const string AboutUsageGrp = "AboutUsage";

        // ---- ROW GROUPS (button rows) ----
        private const string TrashBossButtonsRow = "TrashBossButtonsRow";
        private const string StatusButtonsRow = "StatusButtonsRow";
        private const string AboutLinksRow = "AboutLinksRow";

        // ---- TUNING LIMITS (source of truth for UI + runtime) ----
        internal const int StartingAdaptiveReservationMargin = 10;
        internal const int MinAdaptiveReservationMargin = 10;
        internal const int MaxAdaptiveReservationMargin = 25;
        internal const int RecommendedAdaptiveReservationMargin = 15;

        // ---- RECOMMENDED VALUES ----
        internal const int RecommendedTruckCapacityMultiplier = 200;
        internal const int RecommendedFacilityStorageMultiplier = 150;
        internal const int RecommendedFacilityProcessingMultiplier = 250;
        internal const int RecommendedFacilityVehicleMultiplier = 100;

        // ---- EXTERNAL LINKS ----
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const string UrlDiscord =
            "https://discord.gg/gwXgvtyhjc";

        // ---- BACKING FIELDS ----
        private bool m_TotalMagic = true;
        private bool m_TrashBossEnabled;
        private int m_AdaptiveReservationMargin = StartingAdaptiveReservationMargin;

        private bool ShowAdaptiveReservation => m_TrashBossEnabled;

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        // --------------------------------------------------------------------------
        // TOTAL MAGIC vs TRASH BOSS (Both can be off to just use STATUS)
        // --------------------------------------------------------------------------

        [SettingsUISection(ActionsTab, TotalMagicGrp)]
        [SettingsUISetter(typeof(Setting), nameof(OnModeToggleChanged))]
        public bool TotalMagic
        {
            get => m_TotalMagic;
            set
            {
                if (m_TotalMagic == value)
                {
                    return;
                }

                m_TotalMagic = value;

                // Total Magic takes priority over Trash Boss when enabled.
                if (m_TotalMagic)
                {
                    m_TrashBossEnabled = false;
                }

                Apply();
            }
        }

        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUISetter(typeof(Setting), nameof(OnModeToggleChanged))]
        public bool TrashBossEnabled
        {
            get => m_TrashBossEnabled;
            set
            {
                if (m_TrashBossEnabled == value)
                {
                    return;
                }

                m_TrashBossEnabled = value;

                // Trash Boss takes priority over Total Magic when enabled.
                if (m_TrashBossEnabled)
                {
                    m_TotalMagic = false;
                }

                Apply();
            }
        }

        // --------------------------------------------------------
        // TRASH BOSS STANDARD SLIDERS
        // --------------------------------------------------------

        [SettingsUISlider(min = 100, max = 1000, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnTruckSliderChanged))]
        public int GarbageTruckCapacityMultiplier { get; set; } = 100;

        [SettingsUISlider(min = 100, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnFacilitySliderChanged))]
        public int GarbageFacilityStorageMultiplier { get; set; } = 100;

        [SettingsUISlider(min = 100, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnFacilitySliderChanged))]
        public int GarbageFacilityProcessingMultiplier { get; set; } = 100;

        [SettingsUISlider(min = 100, max = 400, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnFacilitySliderChanged))]
        public int GarbageFacilityVehicleMultiplier { get; set; } = 100;

        [SettingsUISlider(
            min = MinAdaptiveReservationMargin,
            max = MaxAdaptiveReservationMargin,
            step = 1,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowAdaptiveReservation), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnAdaptiveReservationChanged))]
        public int AdaptiveReservationMargin
        {
            get => m_AdaptiveReservationMargin;
            set
            {
                m_AdaptiveReservationMargin = math.clamp(
                    value,
                    MinAdaptiveReservationMargin,
                    MaxAdaptiveReservationMargin);
            }
        }

        // -----------------------------------------
        // TRASH BOSS STANDARD PRESET BUTTONS
        // -----------------------------------------

        [SettingsUIButton]
        [SettingsUIButtonGroup(TrashBossButtonsRow)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        public bool TrashBossRecommended
        {
            set
            {
                if (!value)
                {
                    return;
                }

                GarbageTruckCapacityMultiplier = RecommendedTruckCapacityMultiplier;
                GarbageFacilityStorageMultiplier = RecommendedFacilityStorageMultiplier;
                GarbageFacilityProcessingMultiplier = RecommendedFacilityProcessingMultiplier;
                GarbageFacilityVehicleMultiplier = RecommendedFacilityVehicleMultiplier;
                AdaptiveReservationMargin = RecommendedAdaptiveReservationMargin;

                EnableTuningSystemsOnce();
                Apply();
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(TrashBossButtonsRow)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        public bool TrashBossDefaults
        {
            set
            {
                if (!value)
                {
                    return;
                }

                GarbageTruckCapacityMultiplier = 100;
                GarbageFacilityVehicleMultiplier = 100;
                GarbageFacilityProcessingMultiplier = 100;
                GarbageFacilityStorageMultiplier = 100;
                AdaptiveReservationMargin = StartingAdaptiveReservationMargin;

                EnableTuningSystemsOnce();
                Apply();
            }
        }

        // ------------------------------------
        // ABOUT
        // ------------------------------------

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutName => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutVersion => Mod.ModVersion;

        [SettingsUIButton]
        [SettingsUIButtonGroup(AboutLinksRow)]
        [SettingsUISection(AboutTab, AboutLinksGrp)]
        public bool OpenParadoxPage
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlParadox);
                }
                catch (Exception)
                {
                }
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(AboutLinksRow)]
        [SettingsUISection(AboutTab, AboutLinksGrp)]
        public bool OpenDiscord
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlDiscord);
                }
                catch (Exception)
                {
                }
            }
        }

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, AboutUsageGrp)]
        public string UsageNotes => string.Empty;

        // ---------------------------------
        // DEFAULTS
        // ---------------------------------

        public override void SetDefaults()
        {
            m_TotalMagic = true;
            m_TrashBossEnabled = false;

            GarbageTruckCapacityMultiplier = 100;
            GarbageFacilityVehicleMultiplier = 100;
            GarbageFacilityProcessingMultiplier = 100;
            GarbageFacilityStorageMultiplier = 100;
            AdaptiveReservationMargin = StartingAdaptiveReservationMargin;

            GarbageStatus.ResetUi();
        }

        // --------------------------------------------
        // SettingsUISetter callbacks
        // --------------------------------------------

        // Callback to update live city immediately when main toggles are flipped.
        private void OnModeToggleChanged(bool _)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            TotalMagicSystem tm = world.GetExistingSystemManaged<TotalMagicSystem>();
            if (tm != null)
            {
                tm.Enabled = true;
            }

            GarbageTruckCapacitySystem truckSys = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (truckSys != null)
            {
                truckSys.Enabled = true;
            }

            GarbageFacilityCapacitySystem facSys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facSys != null)
            {
                facSys.Enabled = true;
            }

            GarbageRoutingSystem routingSys = world.GetExistingSystemManaged<GarbageRoutingSystem>();
            if (routingSys != null)
            {
                routingSys.Enabled = true;
            }
        }

        private void OnTruckSliderChanged(int _)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            GarbageTruckCapacitySystem sys = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (sys != null)
            {
                sys.Enabled = true;
            }
        }

        private void OnFacilitySliderChanged(int _)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            GarbageFacilityCapacitySystem sys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (sys != null)
            {
                sys.Enabled = true;
            }
        }

        private void OnAdaptiveReservationChanged(int _)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            GarbageRoutingSystem sys = world.GetExistingSystemManaged<GarbageRoutingSystem>();
            if (sys != null)
            {
                sys.Enabled = true;
            }
        }

        // ----------------------
        // Helpers
        // ----------------------

        private void EnableTuningSystemsOnce()
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            // Wake all tuning systems once after preset changes.
            GarbageTruckCapacitySystem truckSys = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (truckSys != null)
            {
                truckSys.Enabled = true;
            }

            GarbageFacilityCapacitySystem facSys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facSys != null)
            {
                facSys.Enabled = true;
            }

            GarbageRoutingSystem routingSys = world.GetExistingSystemManaged<GarbageRoutingSystem>();
            if (routingSys != null)
            {
                routingSys.Enabled = true;
            }
        }

        private static void OpenLogFolder()
        {
            string logsFolder = ShellOpen.GetLogsFolder();
            if (string.IsNullOrEmpty(logsFolder))
            {
                LogUtils.Warn($"{Mod.ModTag} Logs folder not found.");
                return;
            }

            string logPath = Path.Combine(logsFolder, Mod.ModId + ".log");
            if (File.Exists(logPath))
            {
                try
                {
                    if (Application.platform == RuntimePlatform.WindowsPlayer ||
                        Application.platform == RuntimePlatform.WindowsEditor)
                    {
                        // Opening the file can fail even when it exists, so fall back to Logs.
                        Process? process = Process.Start(new ProcessStartInfo(logPath)
                        {
                            UseShellExecute = true,
                            Verb = "open",
                        });
                        if (process != null)
                        {
                            process.Dispose();
                            return;
                        }
                    }

                    ShellOpen.OpenFile(logPath);
                    return;
                }
                catch (Exception ex)
                {
                    LogUtils.Warn($"{Mod.ModTag} Could not open log file: {ex.Message}");
                }
            }

            ShellOpen.OpenFolder(logsFolder);
        }

        private static bool TryGetWorld(out World world)
        {
            world = World.DefaultGameObjectInjectionWorld;
            return world != null && world.IsCreated;
        }
    }
}
