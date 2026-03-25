// File: Settings/Setting.cs
// Options UI + settings for Magic Garbage.
// Status is pull-based and only refreshes while Options UI is open.

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using System;
    using System.IO;
    using Unity.Entities;
    using UnityEngine;

    [FileLocation("ModsSettings/MagicGarbage/MagicGarbage")]
    [SettingsUITabOrder(ActionsTab, AboutTab)]
    [SettingsUIGroupOrder(
        TotalMagicGrp, TrashBossGrp, StatusGrp,
        AboutInfoGrp, AboutLinksGrp, AboutUsageGrp)]
    [SettingsUIShowGroupName(
        TotalMagicGrp, TrashBossGrp, StatusGrp,
        AboutLinksGrp, AboutUsageGrp)]
    public sealed class Setting : ModSetting
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

        // ---- EXTERNAL LINKS ----
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        // ---- BACKING FIELDS ----
        private bool m_TotalMagic = true;
        private bool m_TrashBossEnabled;

        // Compatibility alias for older saved settings files.
        // Old versions saved TrashBoss toggle as "SemiMagicEnabled".
        // Let old saves map into TrashBossEnabled.
        public bool SemiMagicEnabled
        {
            get => TrashBossEnabled;
            set => TrashBossEnabled = value;
        }


        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        // --------------------------------------------------------------------
        // TOTAL MAGIC vs TRASH BOSS (mutually exclusive)
        // --------------------------------------------------------------------

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

                if (!value && !m_TrashBossEnabled)
                {
                    return;
                }

                m_TotalMagic = value;

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

                if (!value && !m_TotalMagic)
                {
                    return;
                }

                m_TrashBossEnabled = value;

                if (m_TrashBossEnabled)
                {
                    m_TotalMagic = false;
                }

                Apply();
            }
        }

        // --------------------------------------------------------
        // TRASH BOSS SLIDERS (hidden when Trash Boss is OFF)
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
        public int GarbageFacilityProcessingMultiplier { get; set; } = 100;

        [SettingsUISlider(min = 100, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnFacilitySliderChanged))]
        public int GarbageFacilityStorageMultiplier { get; set; } = 100;

        [SettingsUISlider(min = 100, max = 400, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        [SettingsUISetter(typeof(Setting), nameof(OnFacilitySliderChanged))]
        public int GarbageFacilityVehicleMultiplier { get; set; } = 100;

        // -----------------------------------------
        // TRASH BOSS PRESET BUTTONS
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

                GarbageTruckCapacityMultiplier = 200;
                GarbageFacilityProcessingMultiplier = 200;
                GarbageFacilityStorageMultiplier = 160;
                GarbageFacilityVehicleMultiplier = 140;

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

        // ------------------------------------------------------
        // STATUS (auto-refresh while Options is open)
        // ------------------------------------------------------

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusGarbageProcessing
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiGarbageProcessing();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusRequests
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiRequests();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusProducers
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiProducers();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacilities
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiFacilities();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusTrucks
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiTrucks();
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(StatusButtonsRow)]
        [SettingsUISection(ActionsTab, StatusGrp)]
        public bool GarbageStatusLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

#if DEBUG
                Mod.Log.Info($"{Mod.ModTag} [DEBUG] GarbageStatusLog clicked");
#endif
                GarbageStatus.RefreshNow(writeToLog: true);
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(StatusButtonsRow)]
        [SettingsUISection(ActionsTab, StatusGrp)]
        public bool OpenLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

                OpenLogFolder();
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

            GarbageFacilityCapacitySystem facSys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facSys != null)
            {
                facSys.Enabled = true;
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

        // ----------------------
        // Helpers
        // ----------------------

        private void EnableTuningSystemsOnce()
        {
            if (!TryGetWorld(out World world))
            {
                return;
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
