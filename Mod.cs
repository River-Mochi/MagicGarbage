// Mod.cs
// Entry point for MGT

namespace MagicGarbage
{
    using System.Reflection;
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Colossal.Localization;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----
        public const string ModName = "Magic Garbage Truck";
        public const string ModId = "MagicGarbageTruck";
        public const string ModTag = "[MGT]";

        /// <summary>
        /// Read Version from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        private static bool s_BannerLogged;

        public static readonly ILog Log =
            LogManager.GetLogger("MagicGarbage").SetShowsErrorsInUI(false);

        // Shared setting instance (nullable because cleared on dispose)
        public static Setting? Setting
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {

            // One-time load banner
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                Log.Info($"{ModTag} {ModName} v{ModVersion} OnLoad");
            }

            var setting = new Setting(this);
            Setting = setting;

            LocalizationManager? lm = GameManager.instance?.localizationManager;
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
                lm.AddSource("ja-JP", new LocaleJA(setting));
                lm.AddSource("ko-KR", new LocaleKO(setting));
                lm.AddSource("pt-BR", new LocalePT_BR(setting));
                lm.AddSource("tr-TR", new LocaleTR(setting));
                lm.AddSource("zh-HANS", new LocaleZH_CN(setting));   // Simplified Chinese
                lm.AddSource("zh-HANT", new LocaleZH_HANT(setting)); // Traditional Chinese
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
