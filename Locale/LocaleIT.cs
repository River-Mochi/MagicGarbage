// Locale/LocaleFR.cs

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleIT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Magia totale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Modalità semi-magica" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Spazzatura magica"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Abilitato [x]** rimuove istantaneamente tutta la spazzatura della città.\n" +
                    "- Gli edifici di gestione rifiuti non sono più necessari, a meno che ti piaccia averli solo per l’estetica.\n\n" +

                    "<Usa **Magia totale** oppure l’opzione **Semi-magica** qui sotto — non entrambe.>\n" +
                    "- Non succede nulla di grave se le attivi entrambe, ma non otterrai alcun effetto aggiuntivo."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacità dei camion della spazzatura"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Modalità **semi-magica** con super-camion della spazzatura.\n" +
                    "- Se vuoi solo semplificare la gestione rifiuti senza eliminarla del tutto:\n" +
                    "- Spazzatura magica = **[OFF]**\n" +
                    "- Poi usa questo cursore **[100 >> 500]** per aumentare la capacità dei camion.\n\n" +

                    "**---------------------------------------**\n" +
                    " Il cursore regola la capacità rispetto al valore del gioco base.\n" +
                    "**100% = 20 tonnellate per camion** — valore predefinito\n" +
                    "**500% = 100 tonnellate per camion**\n\n" +
                    " Bonus: la velocità di scarico scala con la capacità, così gli impianti non si intasano.\n\n" +
                    "**---------------------------------------**\n\n" +
                    "Se vuoi tornare al gioco completamente vanilla, imposta Spazzatura magica su [OFF] e il cursore su 100%."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),
                    "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nome del mod mostrato nel menu."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)),
                    "Versione"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Versione attuale del mod."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Pagina Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Apri la pagina Paradox Mods di Magic Garbage Truck nel browser."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Apri il Discord di modding di CS2 nel browser."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
