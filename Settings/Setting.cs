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
    [SettingsUITabOrder(ActionsTab, AboutTab)] // Actions first, About second
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
        // ---- Tabs ----
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ---- Groups (row headers) ----
        public const string TotalMagicGrp = "TotalMagic";
        public const string SemiMagicGrp = "SemiMagic";
        public const string AboutInfoGrp = "AboutInfo";
        public const string AboutLinksGrp = "AboutLinks";
        public const string AboutUsageGrp = "AboutUsage";  // USAGE NOTES group on About tab

        // ---- External links ----
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/kimosabe1?orderBy=desc&sortBy=popularity";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        public Setting(IMod mod) : base(mod) { }

        // ---- Total Magic ----

        // Checkbox: full Magic Garbage (no garbage gameplay, just visuals)
        [SettingsUISection(ActionsTab, TotalMagicGrp)]
        public bool MagicGarbage { get; set; } = true;

        // ---- Semi-Magic (Trucks) ----

        // Slider: garbage truck capacity (100–500%)
        [SettingsUISlider(min = 100, max = 500, step = 50,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        public int GarbageTruckCapacityMultiplier { get; set; } = 100;

        // ---- About Tab — Info ----

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutName => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutVersion => Mod.VersionShort;

        // ---- About Tab — Links ----

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

        // ---- About Tab — Usage Notes ----

        // Multiline notes block; actual text comes from Locale files.
        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, AboutUsageGrp)]
        public string UsageNotes => string.Empty;

        // ---- Defaults & Apply ----

        public override void SetDefaults()
        {
            // First-time defaults:
            // - TOTAL Magic Garbage = ON, Slider = 100% (vanilla)
            MagicGarbage = true;
            GarbageTruckCapacityMultiplier = 100; // 100% = vanilla, not relevant when MagicGarbage = ON
        }

        public override void Apply()
        {
            base.Apply();

            var world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
                return;

            // Re-apply truck capacity once when slider changes
            var capacitySystem = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (capacitySystem != null)
            {
                // Runs once, then sets Enabled = false in its OnUpdate
                capacitySystem.Enabled = true;
            }

            // Note:
            // - MagicGarbageSystem reads Setting.MagicGarbage every frame.
            // - GarbageNotificationRemoverSystem hides the garbage icon prefab
            //   while MagicGarbage is ON so new icons won’t spawn.
        }
    }
}
