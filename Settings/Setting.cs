// Settings/Setting.cs

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;

    [FileLocation("ModsSettings/MagicGarbage/MagicGarbage")]
    public sealed class Setting : ModSetting
    {
        public const string MainTab = "Main";
        public const string TotalMagicGrp = "TotalMagic";
        public const string SemiMagicGrp = "SemiMagic";

        public Setting(IMod mod) : base(mod)
        {
            // brand new file? set sane defaults
            if (GarbageTruckCapacityMultiplier == 0)
            {
                SetDefaults();
            }
            else if (GarbageTruckCapacityMultiplier > 0 && GarbageTruckCapacityMultiplier < 10)
            {
                // 100–500%
                GarbageTruckCapacityMultiplier *= 100;
            }
        }

        // ---- TOTAL MAGIC ----------------------------------------------------

        // Checkbox: full Magic Garbage (no garbage gameplay, just visuals)
        [SettingsUISection(MainTab, TotalMagicGrp)]
        public bool MagicGarbage { get; set; } = true;

        // ---- SEMI-MAGIC (TRUCKS) --------------------------------------------

        // Checkbox: hide vanilla garbage notifications when *not* in full magic.
        [SettingsUISection(MainTab, SemiMagicGrp)]
        public bool HideGarbageNotifications { get; set; } = true;

        // Slider: garbage truck capacity (100–500%)
        [SettingsUISlider(min = 100, max = 500, step = 50,
                          scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(MainTab, SemiMagicGrp)]
        public int GarbageTruckCapacityMultiplier { get; set; } = 100;

        public override void SetDefaults()
        {
            MagicGarbage = true;
            HideGarbageNotifications = true;
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
            // - MagicGarbageSystem reads Setting.MagicGarbage every frame
            // - GarbageNotificationRemoverSystem uses MagicGarbage + HideGarbageNotifications
        }
    }
}
