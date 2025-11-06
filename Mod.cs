// Mod.cs
// Entry point for "Magic Garbage Truck [MGT]".

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        public const string ModName = "Magic Garbage Truck [MGT]";
        public const string VersionShort = "1.0.0";

        // Log file: MagicGarbage.log
        public static readonly ILog Log =
            LogManager.GetLogger("MagicGarbage").SetShowsErrorsInUI(false);

        // Shared settings instance (nullable because we clear it on dispose)
        public static Setting? Setting
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            Log.Info($"[MGT] {ModName} v{VersionShort} OnLoad");

            if (GameManager.instance?.modManager != null &&
                GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
            {
                Log.Info("[MGT] Current mod asset at " + asset.path);
            }

            var setting = new Setting(this);
            Setting = setting;

            // Localization
            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("[MGT] LocalizationManager is null; skipping locale registration.");
            }
            else
            {
                lm.AddSource("en-US", new LocaleEN(setting));
            }

            // Load + register in Options UI
            AssetDatabase.global.LoadSettings("MagicGarbage", setting, new Setting(this));
            setting.RegisterInOptionsUI();

            // Systems in the main simulation phase:
            // - MagicGarbageSystem: wipes garbage + requests when MagicGarbage is ON
            // - GarbageNotificationRemoverSystem: hides/shows problem icons
            // - GarbageTruckCapacitySystem: adjusts truck capacity & unload rate
            updateSystem.UpdateAfter<MagicGarbageSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageNotificationRemoverSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageTruckCapacitySystem>(SystemUpdatePhase.GameSimulation);

            Log.Info("[MGT] Systems scheduled (GameSimulation only).");
        }

        public void OnDispose()
        {
            if (Setting != null)
            {
                Setting.UnregisterInOptionsUI();
                Setting = null;
            }

#if DEBUG
            Log.Info("[MGT] OnDispose");
#endif
        }
    }
}
