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
#if DEBUG
            Log.Info($"[MGT] {ModName} v{VersionShort} OnLoad");

            if (GameManager.instance?.modManager != null &&
                GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
            {
                Log.Info("[MGT] Current mod asset at " + asset.path);
            }
#endif

            var setting = new Setting(this);
            Setting = setting;

            // Localization
            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
#if DEBUG
                Log.Warn("[MGT] LocalizationManager is null; skipping locale registration.");
#endif
            }
            else
            {
                lm.AddSource("en-US", new LocaleEN(setting));
                // Add other locales here later if you want:
                // lm.AddSource("fr-FR", new LocaleFR(setting));
                // lm.AddSource("de-DE", new LocaleDE(setting));
                // etc.
            }

            // Load + register in Options UI
            AssetDatabase.global.LoadSettings("MagicGarbage", setting, new Setting(this));
            setting.RegisterInOptionsUI();

            // Systems in the main simulation phase:
            // - MagicGarbageSystem: wipes garbage + requests when Magic Garbage is ON
            // - GarbageNotificationRemoverSystem: hides garbage warning icons while Magic Garbage is ON
            // - GarbageTruckCapacitySystem: adjusts truck capacity & unload rate for Semi-Magic
            updateSystem.UpdateAfter<MagicGarbageSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageNotificationRemoverSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageTruckCapacitySystem>(SystemUpdatePhase.GameSimulation);

#if DEBUG
            Log.Info("[MGT] Systems scheduled (GameSimulation only).");
#endif
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
