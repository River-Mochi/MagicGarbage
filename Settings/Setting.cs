// Settings/Setting.cs
// Options UI + settings for Magic Garbage Truck [MGT].

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;
    using UnityEngine; // Application.OpenURL

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
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/kimosabe1?orderBy=desc&sortBy=popularity";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        public Setting(IMod mod) : base(mod)
        {
        }

        // ---- TOTAL MAGIC ----

        // Checkbox: full Magic Garbage (no garbage gameplay, just visuals)
        [SettingsUISection(ActionsTab, TotalMagicGrp)]
        public bool MagicGarbage { get; set; } = true;

        // ---- SEMI-MAGIC (TRUCKS) ----

        // Slider: garbage truck capacity (100–500%)
        [SettingsUISlider(min = 100, max = 500, step = 50,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        public int GarbageTruckCapacityMultiplier { get; set; } = 100;

        // ---- ABOUT TAB – INFO ----

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutName => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutVersion => Mod.ModVersion;

        // ---- ABOUT TAB – LINKS ----

        [SettingsUIButton]
        [SettingsUIButtonGroup(AboutLinksGrp)]
        [SettingsUISection(AboutTab, AboutLinksGrp)]
        public bool OpenParadoxPage
        {
            set
            {
                if (!value)
                    return;

                Application.OpenURL(UrlParadox);
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
                    return;

                Application.OpenURL(UrlDiscord);
            }
        }

        // ---- ABOUT TAB – USAGE NOTES ----

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, AboutUsageGrp)]
        public string UsageNotes => string.Empty; // Text comes from Locale files

        // ---- DEFAULTS & APPLY ----

        public override void SetDefaults()
        {
            // First-time defaults: MagicGarbage = ON, Slider = 100% (vanilla)
            MagicGarbage = true;
            GarbageTruckCapacityMultiplier = 100; // 100% = vanilla
        }

        public override void Apply()
        {
            base.Apply();

            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
                return;

            // Recalculate truck capacity once when the slider value changes.
            GarbageTruckCapacitySystem capacitySystem = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (capacitySystem != null)
            {
                capacitySystem.Enabled = true;
            }
        }
    }
}
