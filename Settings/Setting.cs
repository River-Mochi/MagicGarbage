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
        AboutLinksGrp)]
    [SettingsUIShowGroupName(
        TotalMagicGrp,
        SemiMagicGrp,
        //   AboutInfoGrp,  // AboutInfoGrp left out on purpose no header
        AboutLinksGrp)]
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

        // ---- External links ----
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/kimosabe1?orderBy=desc&sortBy=popularity";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        public Setting(IMod mod) : base(mod)
        {

            SetDefaults();
        }

        // ---- TOTAL MAGIC ----------------------------------------------------

        [SettingsUISection(ActionsTab, TotalMagicGrp)]
        public bool MagicGarbage { get; set; } = true;

        // ---- SEMI-MAGIC (TRUCKS) -------------------------------------------

        [SettingsUISlider(min = 100, max = 500, step = 50,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, SemiMagicGrp)]
        public int GarbageTruckCapacityMultiplier { get; set; } = 100;

        // ---- ABOUT TAB ------------------------------------------------------

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutName => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGrp)]
        public string AboutVersion => Mod.VersionShort;

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

        public override void SetDefaults()
        {
            MagicGarbage = true;
            GarbageTruckCapacityMultiplier = 100; // 100% = vanilla
        }

        public override void Apply()
        {
            base.Apply();

            var world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
                return;

            var capacitySystem = world.GetExistingSystemManaged<GarbageTruckCapacitySystem>();
            if (capacitySystem != null)
            {
                capacitySystem.Enabled = true;
            }
        }
    }
}
