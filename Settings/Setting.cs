// File: Settings/Setting.cs
// Options UI + settings for Magic Garbage.
// Main settings file. Status UI members live in Setting.Status.cs.

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using System;
    using System.IO;
    using Unity.Entities;
    using Unity.Mathematics;
    using UnityEngine;

    [FileLocation("ModsSettings/MagicGarbage/MagicGarbage")]
    [SettingsUITabOrder(ActionsTab, AboutTab)]
    [SettingsUIGroupOrder(
        TotalMagicGrp, TrashBossGrp, PowerUserGrp, StatusGrp,
        AboutInfoGrp, AboutLinksGrp, AboutUsageGrp)]
    [SettingsUIShowGroupName(
        TotalMagicGrp, TrashBossGrp, PowerUserGrp, StatusGrp,
        AboutLinksGrp, AboutUsageGrp)]
    public sealed partial class Setting : ModSetting
    {
        // ---- TABS ----
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ---- GROUPS ----
        public const string TotalMagicGrp = "TotalMagic";
        public const string TrashBossGrp = "TrashBoss";
        public const string PowerUserGrp = "PowerUser";
        public const string StatusGrp = "Status";
        public const string AboutInfoGrp = "AboutInfo";
        public const string AboutLinksGrp = "AboutLinks";
        public const string AboutUsageGrp = "AboutUsage";

        // ---- ROW GROUPS (button rows) ----
        private const string TrashBossButtonsRow = "TrashBossButtonsRow";
        private const string PowerUserButtonsRow = "PowerUserButtonsRow";
        private const string StatusButtonsRow = "StatusButtonsRow";
        private const string AboutLinksRow = "AboutLinksRow";

        // ---- TUNING LIMITS (source of truth for UI + runtime) ----
        internal const int VanillaDispatchRequestThreshold = 100;
        internal const int VanillaPickupThreshold = 20;
        internal const int MaxDispatchRequestThreshold = 2000;
        internal const int MaxPickupThreshold = 1000;

        internal const int VanillaGarbageHappinessBaseline = 100;
        internal const int VanillaGarbageHappinessStep = 65;
        internal const int MinGarbageHappinessBaseline = 100;
        internal const int MaxGarbageHappinessBaseline = 2000;
        internal const int MinGarbageHappinessStep = 65;
        internal const int MaxGarbageHappinessStep = 1000;

        // ---- RECOMMENDED VALUES ----
        internal const int RecommendedTruckCapacityMultiplier = 250;
        internal const int RecommendedFacilityStorageMultiplier = 150;
        internal const int RecommendedFacilityProcessingMultiplier = 250;
        internal const int RecommendedFacilityVehicleMultiplier = 100;

        internal const int RecommendedDispatchRequestThreshold = 500;
        internal const int RecommendedPickupThreshold = 300;
        internal const int RecommendedGarbageHappinessBaseline = 550;
        internal const int RecommendedGarbageHappinessStep = 150;

        internal const int VanillaGarbageAccumulationRate = 100;
        internal const int MinGarbageAccumulationRate = 20;
        internal const int MaxGarbageAccumulationRate = 200;

        // ---- EXTERNAL LINKS ----
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        // ---- BACKING FIELDS ----
        private bool m_TotalMagic = true;
        private bool m_TrashBossEnabled;
        private bool m_PowerUserOptions;
        private int m_GarbageDispatchRequestThreshold = VanillaDispatchRequestThreshold;
        private int m_GarbagePickupThreshold = VanillaPickupThreshold;
        private int m_GarbageHappinessBaseline = VanillaGarbageHappinessBaseline;
        private int m_GarbageHappinessStep = VanillaGarbageHappinessStep;
        private int m_GarbageAccumulationRate = VanillaGarbageAccumulationRate;

        // Power User sliders only show when both Trash Boss and Power User are enabled.
        private bool ShowPowerUsers => m_TrashBossEnabled && m_PowerUserOptions;

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

        [SettingsUISlider(min = 100, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
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

                EnableTuningSystemsOnce();
                Apply();
            }
        }

        // --------------------------------------------------------
        // POWER USER
        // --------------------------------------------------------

        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnThresholdOptionsChanged))]
        public bool PowerUserOptions
        {
            get => m_PowerUserOptions;
            set
            {
                if (m_PowerUserOptions == value)
                {
                    return;
                }

                m_PowerUserOptions = value;
                Apply();
            }
        }

        [SettingsUISlider(min = VanillaDispatchRequestThreshold, max = MaxDispatchRequestThreshold, step = 100, scalarMultiplier = 1)]
        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowPowerUsers), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnThresholdSliderChanged))]
        public int GarbageDispatchRequestThreshold
        {
            get => m_GarbageDispatchRequestThreshold;
            set
            {
                int clamped = math.clamp(value, VanillaDispatchRequestThreshold, MaxDispatchRequestThreshold);
                m_GarbageDispatchRequestThreshold = clamped;

                // Pickup can never exceed dispatch request threshold.
                if (m_GarbagePickupThreshold > m_GarbageDispatchRequestThreshold)
                {
                    m_GarbagePickupThreshold = m_GarbageDispatchRequestThreshold;
                }
            }
        }

        [SettingsUISlider(min = VanillaPickupThreshold, max = MaxPickupThreshold, step = 20, scalarMultiplier = 1)]
        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowPowerUsers), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnThresholdSliderChanged))]
        public int GarbagePickupThreshold
        {
            get => m_GarbagePickupThreshold;
            set
            {
                int clamped = math.clamp(value, VanillaPickupThreshold, MaxPickupThreshold);

                // Clamp again against the current dispatch threshold.
                if (clamped > m_GarbageDispatchRequestThreshold)
                {
                    clamped = m_GarbageDispatchRequestThreshold;
                }

                m_GarbagePickupThreshold = clamped;
            }
        }

        [SettingsUISlider(min = MinGarbageHappinessBaseline, max = MaxGarbageHappinessBaseline, step = 50, scalarMultiplier = 1)]
        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowPowerUsers), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnThresholdSliderChanged))]
        public int GarbageHappinessBaseline
        {
            get => m_GarbageHappinessBaseline;
            set
            {
                m_GarbageHappinessBaseline = math.clamp(
                    value,
                    MinGarbageHappinessBaseline,
                    MaxGarbageHappinessBaseline);
            }
        }

        [SettingsUISlider(min = MinGarbageHappinessStep, max = MaxGarbageHappinessStep, step = 5, scalarMultiplier = 1)]
        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowPowerUsers), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnThresholdSliderChanged))]
        public int GarbageHappinessStep
        {
            get => m_GarbageHappinessStep;
            set
            {
                m_GarbageHappinessStep = math.clamp(
                    value,
                    MinGarbageHappinessStep,
                    MaxGarbageHappinessStep);
            }
        }

        [SettingsUISlider(min = MinGarbageAccumulationRate, max = MaxGarbageAccumulationRate, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowPowerUsers), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnAccumulationSliderChanged))]
        public int GarbageAccumulationRate
        {
            get => m_GarbageAccumulationRate;
            set
            {
                m_GarbageAccumulationRate = math.clamp(
                    value,
                    MinGarbageAccumulationRate,
                    MaxGarbageAccumulationRate);
            }
        }


        // -----------------------------------------
        // POWER USER PRESET BUTTONS
        // -----------------------------------------

        [SettingsUIButton]
        [SettingsUIButtonGroup(PowerUserButtonsRow)]
        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowPowerUsers), true)]
        public bool PowerUserRecommended
        {
            set
            {
                if (!value)
                {
                    return;
                }

                PowerUserOptions = true;
                GarbageDispatchRequestThreshold = RecommendedDispatchRequestThreshold;
                GarbagePickupThreshold = RecommendedPickupThreshold;
                GarbageHappinessBaseline = RecommendedGarbageHappinessBaseline;
                GarbageHappinessStep = RecommendedGarbageHappinessStep;
                GarbageAccumulationRate = VanillaGarbageAccumulationRate;

                EnableTuningSystemsOnce();
                Apply();
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(PowerUserButtonsRow)]
        [SettingsUISection(ActionsTab, PowerUserGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(ShowPowerUsers), true)]
        public bool PowerUserDefaults
        {
            set
            {
                if (!value)
                {
                    return;
                }

                PowerUserOptions = false;
                GarbageDispatchRequestThreshold = VanillaDispatchRequestThreshold;
                GarbagePickupThreshold = VanillaPickupThreshold;
                GarbageHappinessBaseline = VanillaGarbageHappinessBaseline;
                GarbageHappinessStep = VanillaGarbageHappinessStep;
                GarbageAccumulationRate = VanillaGarbageAccumulationRate;

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
            m_PowerUserOptions = false;

            GarbageTruckCapacityMultiplier = 100;
            GarbageFacilityVehicleMultiplier = 100;
            GarbageFacilityProcessingMultiplier = 100;
            GarbageFacilityStorageMultiplier = 100;
            GarbageDispatchRequestThreshold = VanillaDispatchRequestThreshold;
            GarbagePickupThreshold = VanillaPickupThreshold;
            GarbageHappinessBaseline = VanillaGarbageHappinessBaseline;
            GarbageHappinessStep = VanillaGarbageHappinessStep;
            GarbageAccumulationRate = VanillaGarbageAccumulationRate;

            GarbageStatus.ResetUi();
        }

        // --------------------------------------------
        // SettingsUISetter callbacks
        // --------------------------------------------

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

            GarbageThresholdSystem thresholdSys = world.GetExistingSystemManaged<GarbageThresholdSystem>();
            if (thresholdSys != null)
            {
                thresholdSys.Enabled = true;
            }

            GarbageFacilityCapacitySystem facSys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facSys != null)
            {
                facSys.Enabled = true;
            }


            GarbageAccumulationRateSystem accumulationSys = world.GetExistingSystemManaged<GarbageAccumulationRateSystem>();
            if (accumulationSys != null)
            {
                accumulationSys.Enabled = true;
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

        private void OnThresholdOptionsChanged(bool _)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            GarbageThresholdSystem thresholdSys = world.GetExistingSystemManaged<GarbageThresholdSystem>();
            if (thresholdSys != null)
            {
                thresholdSys.Enabled = true;
            }

            // Power User ON/OFF also controls whether accumulation rate should revert to vanilla.
            GarbageAccumulationRateSystem accumulationSys = world.GetExistingSystemManaged<GarbageAccumulationRateSystem>();
            if (accumulationSys != null)
            {
                accumulationSys.Enabled = true;
            }
        }


        private void OnThresholdSliderChanged(int _)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            GarbageThresholdSystem sys = world.GetExistingSystemManaged<GarbageThresholdSystem>();
            if (sys != null)
            {
                sys.Enabled = true;
            }
        }

        private void OnAccumulationSliderChanged(int _)
        {
            if (!TryGetWorld(out World world))
            {
                return;
            }

            GarbageAccumulationRateSystem sys = world.GetExistingSystemManaged<GarbageAccumulationRateSystem>();
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

            GarbageThresholdSystem thresholdSys = world.GetExistingSystemManaged<GarbageThresholdSystem>();
            if (thresholdSys != null)
            {
                thresholdSys.Enabled = true;
            }

            GarbageFacilityCapacitySystem facSys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facSys != null)
            {
                facSys.Enabled = true;
            }

            GarbageAccumulationRateSystem accumulationSys = world.GetExistingSystemManaged<GarbageAccumulationRateSystem>();
            if (accumulationSys != null)
            {
                accumulationSys.Enabled = true;
            }

        }

        private static void OpenLogFolder()
        {
            try
            {
                string consoleLogPath = Application.consoleLogPath;
                if (string.IsNullOrEmpty(consoleLogPath))
                {
                    return;
                }

                string rootFolder = Path.GetDirectoryName(consoleLogPath);
                if (string.IsNullOrEmpty(rootFolder))
                {
                    return;
                }

                string logsFolder = Path.Combine(rootFolder, "Logs");
                string targetFolder = Directory.Exists(logsFolder) ? logsFolder : rootFolder;

                string targetUri = new Uri(targetFolder + Path.DirectorySeparatorChar).AbsoluteUri;
                Application.OpenURL(targetUri);
            }
            catch (Exception ex)
            {
                Mod.Log.Warn($"{Mod.ModTag} OpenLog failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        private static bool TryGetWorld(out World world)
        {
            world = World.DefaultGameObjectInjectionWorld;
            return world != null && world.IsCreated;
        }
    }
}
