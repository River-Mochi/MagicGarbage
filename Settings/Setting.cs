// File: Settings/Setting.cs
// Options UI + settings for Magic Garbage Truck [MG].
// Status auto-refreshes once per Options-open and can be forced by button.

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.UI;
    using System;
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
        private const string AboutLinksRow = "AboutLinksRow";

        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        private bool m_TotalMagic = true;
        private bool m_TrashBossEnabled;

        public Setting(IMod mod) : base(mod)
        {
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
                    return;

                if (!value && !m_TrashBossEnabled)
                    return;

                m_TotalMagic = value;

                if (m_TotalMagic)
                    m_TrashBossEnabled = false;

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
                    return;

                if (!value && !m_TotalMagic)
                    return;

                m_TrashBossEnabled = value;

                if (m_TrashBossEnabled)
                    m_TotalMagic = false;

                Apply();
            }
        }

        // --------------------------------------------------------------------
        // TRASH BOSS SLIDERS (hidden when Trash Boss is disabled)
        // --------------------------------------------------------------------

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

        // --------------------------------------------------------------------
        // TRASH BOSS PRESET BUTTONS
        // --------------------------------------------------------------------

        [SettingsUIButton]
        [SettingsUIButtonGroup(TrashBossButtonsRow)]
        [SettingsUISection(ActionsTab, TrashBossGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(TrashBossEnabled), true)]
        public bool TrashBossRecommended
        {
            set
            {
                if (!value)
                    return;

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
                    return;

                GarbageTruckCapacityMultiplier = 100;
                GarbageFacilityVehicleMultiplier = 100;
                GarbageFacilityProcessingMultiplier = 100;
                GarbageFacilityStorageMultiplier = 100;

                EnableTuningSystemsOnce();
                Apply();
            }
        }

        // --------------------------------------------------------------------
        // ACTIONS TAB – STATUS
        // --------------------------------------------------------------------

        [SettingsUIButton]
        [SettingsUISection(ActionsTab, StatusGrp)]
        public bool RefreshGarbageStatus
        {
            set
            {
                if (!value)
                    return;

#if DEBUG
                Mod.Log.Info($"{Mod.ModTag} [DEBUG] GarbageStatus button clicked");
#endif

                GameManager gm = GameManager.instance;
                if (gm == null || !gm.gameMode.IsGame())
                {
#if DEBUG
                    Mod.Log.Info($"{Mod.ModTag} [DEBUG] NoCity: GameManager null or not IsGame()");
#endif
                    GarbageStatusSystem.SetUiNoCity();
                    Apply();
                    return;
                }

                GarbageStatusSystem.SetUiRunning();
                Apply();

                GarbageStatusSystem.RunNow(writeToLog: true);

                Apply();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusRates
        {
            get
            {
                GarbageStatusSystem.AutoRefreshOnOptionsRead();
                return GarbageStatusSystem.GetRates();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusProducers
        {
            get
            {
                GarbageStatusSystem.AutoRefreshOnOptionsRead();
                return GarbageStatusSystem.GetProducers();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusRequests
        {
            get
            {
                GarbageStatusSystem.AutoRefreshOnOptionsRead();
                return GarbageStatusSystem.GetRequests();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusTrucks
        {
            get
            {
                GarbageStatusSystem.AutoRefreshOnOptionsRead();
                return GarbageStatusSystem.GetTrucks();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility1 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(0); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility2 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(1); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility3 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(2); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility4 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(3); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility5 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(4); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility6 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(5); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility7 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(6); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility8 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(7); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility9 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(8); } }
        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacility10 { get { GarbageStatusSystem.AutoRefreshOnOptionsRead(); return GarbageStatusSystem.GetFacility(9); } }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusLastUpdate
        {
            get
            {
                GarbageStatusSystem.AutoRefreshOnOptionsRead();
                return GarbageStatusSystem.GetLastUpdate();
            }
        }

        // --------------------------------------------------------------------
        // ABOUT TAB
        // --------------------------------------------------------------------

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
                if (value)
                    Application.OpenURL(UrlParadox);
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(AboutLinksRow)]
        [SettingsUISection(AboutTab, AboutLinksGrp)]
        public bool OpenDiscord
        {
            set
            {
                if (value)
                    Application.OpenURL(UrlDiscord);
            }
        }

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, AboutUsageGrp)]
        public string UsageNotes => string.Empty;

        // --------------------------------------------------------------------
        // DEFAULTS
        // --------------------------------------------------------------------

        public override void SetDefaults()
        {
            m_TotalMagic = true;
            m_TrashBossEnabled = false;

            GarbageTruckCapacityMultiplier = 100;
            GarbageFacilityVehicleMultiplier = 100;
            GarbageFacilityProcessingMultiplier = 100;
            GarbageFacilityStorageMultiplier = 100;

            GarbageStatusSystem.ResetUi();
        }

        // --------------------------------------------------------------------
        // SettingsUISetter callbacks
        // --------------------------------------------------------------------

        private void OnModeToggleChanged(bool _)
        {
            if (!TryGetWorld(out World world))
                return;

            TotalMagicSystem tm = world.GetExistingSystemManaged<TotalMagicSystem>();
            if (tm != null)
                tm.Enabled = true;

            GarbageTruckCapacitySystem truckSys = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (truckSys != null)
                truckSys.Enabled = true;

            GarbageFacilityCapacitySystem facSys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facSys != null)
                facSys.Enabled = true;
        }

        private void OnTruckSliderChanged(int _)
        {
            if (!TryGetWorld(out World world))
                return;

            GarbageTruckCapacitySystem sys = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (sys != null)
                sys.Enabled = true;
        }

        private void OnFacilitySliderChanged(int _)
        {
            if (!TryGetWorld(out World world))
                return;

            GarbageFacilityCapacitySystem sys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (sys != null)
                sys.Enabled = true;
        }

        // --------------------------------------------------------------------
        // Helpers (bottom)
        // --------------------------------------------------------------------

        private void EnableTuningSystemsOnce()
        {
            if (!TryGetWorld(out World world))
                return;

            GarbageTruckCapacitySystem truckSys = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (truckSys != null)
                truckSys.Enabled = true;

            GarbageFacilityCapacitySystem facSys = world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facSys != null)
                facSys.Enabled = true;
        }

        private static bool TryGetWorld(out World world)
        {
            world = World.DefaultGameObjectInjectionWorld;
            return world != null && world.IsCreated;
        }
    }
}
