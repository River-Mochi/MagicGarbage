// Settings/Setting.cs
// Options UI + settings for Magic Garbage Truck [MGT].

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;
    using UnityEngine;  // Application.OpenURL

    [FileLocation("ModsSettings/MagicGarbage/MagicGarbage")]
    [SettingsUITabOrder(ActionsTab, AboutTab)] // Actions then About tab
    [SettingsUIGroupOrder(
        TotalMagicGrp,
        SemiMagicGrp,
        AboutInfoGrp,
        AboutLinksGrp,
        AboutUsageGrp)]
    [SettingsUIShowGroupName(
        TotalMagicGrp,
        SemiMagicGrp,
        // AboutInfoGrp is intentionally omitted so it has no header
        AboutLinksGrp,
        AboutUsageGrp)]
    public sealed class Setting : ModSetting
    {
        // ---- TABS ----
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ---- GROUPS ----
        public const string TotalMagicGrp = "TotalMagic";
        public const string SemiMagicGrp = "SemiMagic";
        public const string AboutInfoGrp = "AboutInfo";
        public const string AboutLinksGrp = "AboutLinks";
        public const string AboutUsageGrp = "AboutUsage";  // USAGE NOTES group on About tab

        // ---- EXTERNAL LINKS ----
        private const string kUrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const string kUrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        // ---- BACKING FIELDS FOR MUTUAL EXCLUSION ----
        private bool m_TotalMagic = true;
        private bool m_SemiMagicEnabled; // default OFF

        public Setting(IMod mod)
            : base(mod)
        {
        }

        // --------------------------------------------------------------------
        // TOTAL MAGIC vs SEMI-MAGIC (mutually exclusive)
        // --------------------------------------------------------------------

        /// <summary>
        /// Full Magic Garbage (no garbage gameplay, just visuals).
        /// UI label: "Total Magic".
        /// </summary>
        [SettingsUISection(ActionsTab, TotalMagicGrp)]
        public bool TotalMagic
        {
            get => m_TotalMagic;
            set
            {
                if (m_TotalMagic == value)
                {
                    return;
                }

                // Do not allow both toggles to be OFF.
                if (!value && !m_SemiMagicEnabled)
                {
                    return;
                }

                m_TotalMagic = value;

                if (m_TotalMagic)
                {
                    // Total Magic ON => Semi-Magic OFF.
                    m_SemiMagicEnabled = false;
                }

                // Re-apply so systems can react.
                Apply();
            }
        }

        /// <summary>
        /// Semi-Magic tuning (sliders below). Mutually exclusive with TotalMagic.
        /// UI label: "Semi-Magic".
        /// </summary>
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        public bool SemiMagicEnabled
        {
            get => m_SemiMagicEnabled;
            set
            {
                if (m_SemiMagicEnabled == value)
                {
                    return;
                }

                // Do not allow both toggles to be OFF.
                if (!value && !m_TotalMagic)
                {
                    return;
                }

                m_SemiMagicEnabled = value;

                if (m_SemiMagicEnabled)
                {
                    // Semi-Magic ON => Total Magic OFF.
                    m_TotalMagic = false;
                }

                // Re-apply so systems can react.
                Apply();
            }
        }

        // --------------------------------------------------------------------
        // SEMI-MAGIC SLIDERS (truck + facility tuning)
        // All are hidden when Semi-Magic is disabled.
        // --------------------------------------------------------------------

        // Slider: garbage truck capacity (100–500%)
        [SettingsUISlider(min = 100, max = 500, step = 20,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(SemiMagicEnabled), true)]
        public int GarbageTruckCapacityMultiplier
        {
            get;
            set;
        } = 100;

        // Slider: facility garbage processing speed (100–500%)
        [SettingsUISlider(min = 100, max = 500, step = 20,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(SemiMagicEnabled), true)]
        public int GarbageFacilityProcessingMultiplier
        {
            get;
            set;
        } = 100;

        // Slider: facility garbage storage capacity (100–500%)
        [SettingsUISlider(min = 100, max = 500, step = 20,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(SemiMagicEnabled), true)]
        public int GarbageFacilityStorageMultiplier
        {
            get;
            set;
        } = 100;

        // Slider: number of facility trucks (vehicles) (100–400%)
        // 100% = vanilla number of trucks, 400% = +300% more.
        [SettingsUISlider(min = 100, max = 400, step = 20,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(SemiMagicEnabled), true)]
        public int GarbageFacilityVehicleMultiplier
        {
            get;
            set;
        } = 100;

        // --------------------------------------------------------------------
        // SEMI-MAGIC PRESET BUTTONS (same row)
        // --------------------------------------------------------------------

        private const string kSemiMagicButtonsRow = "SemiMagicButtonsRow";

        // Button: Recommended preset (preferred values).
        [SettingsUIButton]
        [SettingsUIButtonGroup(kSemiMagicButtonsRow)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(SemiMagicEnabled), true)]
        public bool SemiMagicRecommended
        {
            set
            {
                if (!value)
                {
                    return;
                }

                // Recommended:
                // 200% truck load, 140% facility trucks,
                // 200% process speed, 160% facility storage.
                GarbageTruckCapacityMultiplier = 200;
                GarbageFacilityProcessingMultiplier = 200;
                GarbageFacilityStorageMultiplier = 160;
                GarbageFacilityVehicleMultiplier = 140;

                Apply();
            }
        }

        // Button: Game defaults (all sliders back to 100%).
        [SettingsUIButton]
        [SettingsUIButtonGroup(kSemiMagicButtonsRow)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(SemiMagicEnabled), true)]
        public bool SemiMagicDefaults
        {
            set
            {
                if (!value)
                {
                    return;
                }

                // Vanilla settings.
                GarbageTruckCapacityMultiplier = 100;
                GarbageFacilityVehicleMultiplier = 100;
                GarbageFacilityProcessingMultiplier = 100;
                GarbageFacilityStorageMultiplier = 100;

                Apply();
            }
        }

        // --------------------------------------------------------------------
        // ABOUT TAB – INFO
        // --------------------------------------------------------------------

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutName => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutVersion => Mod.ModVersion;

        // --------------------------------------------------------------------
        // ABOUT TAB – LINKS
        // --------------------------------------------------------------------

        [SettingsUIButton]
        [SettingsUIButtonGroup(AboutLinksGrp)]
        [SettingsUISection(AboutTab, AboutLinksGrp)]
        public bool OpenParadoxPage
        {
            set
            {
                if (!value)
                {
                    return;
                }

                Application.OpenURL(kUrlParadox);
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(AboutLinksGrp)]
        [SettingsUISection(AboutTab, AboutLinksGrp)]
        public bool OpenDiscord
        {
            set
            {
                if (!value)
                {
                    return;
                }

                Application.OpenURL(kUrlDiscord);
            }
        }

        // --------------------------------------------------------------------
        // ABOUT TAB – USAGE NOTES
        // --------------------------------------------------------------------

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, AboutUsageGrp)]
        public string UsageNotes => string.Empty; // Text comes from Locale files.

        // --------------------------------------------------------------------
        // DEFAULTS & APPLY
        // --------------------------------------------------------------------

        public override void SetDefaults()
        {
            // First-time defaults:
            // - Total Magic ON
            // - Semi-Magic OFF
            // - All sliders at 100% (vanilla)
            m_TotalMagic = true;
            m_SemiMagicEnabled = false;

            GarbageTruckCapacityMultiplier = 100;
            GarbageFacilityVehicleMultiplier = 100;
            GarbageFacilityProcessingMultiplier = 100;
            GarbageFacilityStorageMultiplier = 100;
        }

        public override void Apply()
        {
            base.Apply();

            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                return;
            }

            // Recalculate truck stats when sliders/toggles change.
            GarbageTruckCapacitySystem truckSystem =
                world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (truckSystem != null)
            {
                truckSystem.Enabled = true;
            }

            // Recalculate facility stats when sliders/toggles change.
            GarbageFacilityCapacitySystem facilitySystem =
                world.GetExistingSystemManaged<GarbageFacilityCapacitySystem>();
            if (facilitySystem != null)
            {
                facilitySystem.Enabled = true;
            }

        }
    }
}
