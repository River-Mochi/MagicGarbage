// Mod.cs
// Entry point for MGT

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
        public const string VersionShort = "1.0.1";

        public static readonly ILog Log =
            LogManager.GetLogger("MagicGarbage").SetShowsErrorsInUI(false);

        // Shared settings instance (nullable because cleared on dispose)
        public static Setting? Setting
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            // One-time load banner
            Log.Info($"[MGT] {ModName} v{VersionShort} OnLoad");

            var setting = new Setting(this);
            Setting = setting;

            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("[MGT] LocalizationManager is null; skipping locale registration.");
            }
            else
            {
                // Register all supported locales once
                lm.AddSource("en-US", new LocaleEN(setting));
                lm.AddSource("fr-FR", new LocaleFR(setting));
                lm.AddSource("es-ES", new LocaleES(setting));
                lm.AddSource("de-DE", new LocaleDE(setting));
                lm.AddSource("it-IT", new LocaleIT(setting));
                lm.AddSource("zh-HANS", new LocaleZH_CN(setting));
            }

            // Load + register in Options UI
            AssetDatabase.global.LoadSettings("MagicGarbage", setting, new Setting(this));
            setting.RegisterInOptionsUI();

            // main simulation phase:
            // - MagicGarbageSystem: clears garbage and requests when MagicGarbage is ON
            // - GarbageTruckCapacitySystem: adjusts truck capacity and unload rate for Semi-Magic
            updateSystem.UpdateAfter<MagicGarbageSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageTruckCapacitySystem>(SystemUpdatePhase.GameSimulation);

#if DEBUG
            Log.Info("[MGT] All systems are now hooked into the main GameSimulation phase.");
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
