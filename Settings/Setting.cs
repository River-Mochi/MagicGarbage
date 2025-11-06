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
        // AboutInfoGrp header intentionally omitted
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
        public const string AboutUsageGrp = "AboutUsage";

        // ---- External links ----
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/kimosabe1?orderBy=desc&sortBy=popularity";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        public Setting(IMod mod) : base(mod)
        {
            // brand new file? set sane defaults
            if (GarbageTruckCapacityMultiplier == 0)
            {
                SetDefaults();
            }
            else if (GarbageTruckCapacityMultiplier > 0 && GarbageTruckCapacityMultiplier < 10)
            {
                // Old saves where slider was 1–5: convert to 100–500%.
                GarbageTruckCapacityMultiplier *= 100;
            }
        }

        // ---- TOTAL MAGIC ----------------------------------------------------

        // Checkbox: full Magic Garbage (no garbage gameplay, just visuals)
        [SettingsUISection(ActionsTab, TotalMagicGrp)]
        public bool MagicGarbage { get; set; } = true;

        // ---- SEMI-MAGIC (TRUCKS) -------------------------------------------

        // Slider: garbage truck capacity (100–500%)
        [SettingsUISlider(min = 100, max = 500, step = 50,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        public int GarbageTruckCapacityMultiplier { get; set; } = 100;

        // ---- ABOUT TAB ------------------------------------------------------

        // Info row: name + version
        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutName => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutVersion => Mod.VersionShort;

        // Links row: Paradox Mods button
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

        // Links row: Discord button
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

        // About tab: USAGE NOTES (multiline text block)
        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, AboutUsageGrp)]
        public string UsageNotes => string.Empty;

        // ---- ModSetting overrides ------------------------------------------

        public override void SetDefaults()
        {
            // Your requested defaults:
            // - TOTAL Magic Garbage = ON
            // - Slider = 100% (vanilla)
            MagicGarbage = true;
            GarbageTruckCapacityMultiplier = 100; // 100% (vanilla)
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
                // runs once, then sets Enabled = false in its OnUpdate
                capacitySystem.Enabled = true;
            }

            // NOTE:
            // - MagicGarbageSystem reads Setting.MagicGarbage every frame.
            // - Notification icons now follow vanilla behaviour; we no longer
            //   toggle the global garbage icon prefab in this mod.
        }
    }
}
