// File: Localization/LocaleIT.cs
// Italian (it-IT)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info"   },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Pulizia automatica" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Gestione manuale"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info mod"           },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link"               },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTE D’USO"         },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivato [ ✓ ]** rimuove istantaneamente tutta la spazzatura della città.\n\n" +

                    "Quando **Magia totale** è ATTIVA:\n" +
                    "- La Semi-magia viene forzata su OFF.\n" +
                    "- Gli slider della Semi-magia **non vengono applicati** (i tuoi valori restano salvati).\n" +
                    "- Alcuni camion possono ancora girare per la logica di dispatch del gioco (di solito vuoti)."
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gestisci direttamente i sistemi dei rifiuti; la logica vanilla resta attiva.\n\n" +
                    "- Quando **Semi-magia è ATTIVA [ ✓ ]**, Magia totale si spegne automaticamente.\n" +
                    "- Gli slider si applicano solo se Semi-magia è attiva [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacità di carico del camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanta spazzatura può trasportare ogni camion.**\n" +
                    "100% = valore normale del gioco.\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocità di lavorazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente gli impianti lavorano i rifiuti.**\n" +
                    "100% = velocità vanilla.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacità di stoccaggio dell’impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanta spazzatura può contenere un impianto.**\n" +
                    "100% = stoccaggio vanilla.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Camion per impianto"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion può inviare ogni impianto.**\n" +
                    "100% = numero vanilla.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Applica i valori consigliati per la Semi-magia:\n" +
                    "- Capacità di carico del camion: **200%**\n" +
                    "- Velocità di lavorazione: **200%**\n" +
                    "- Capacità di stoccaggio: **160%**\n" +
                    "- Camion per impianto: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Riporta tutti gli slider a **100%** (valori vanilla).\n" +
                    "Ripristina il comportamento normale del gioco."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nome visualizzato di questa mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Versione attuale della mod."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Apri la pagina **Paradox Mods** con le mod dell’autore."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Apri **Discord** nel browser per il modding di CS2."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato: Pulizia automatica>\n" +
                    "  * Magia totale ATTIVA = **[ ✓ ]**\n" +
                    "  * Tutta la spazzatura viene rimossa subito\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato: Gestione manuale>\n" +
                    "  * Attiva Semi-magia = **[ ✓ ]**\n" +
                    "  * Regola gli slider come vuoi.\n" +
                    "  * Logica vanilla con camion/impianti migliorati.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Gioco vanilla normale>\n" +
                    "  * Attiva Semi-magia = **[ ✓ ]**\n" +
                    "  * Clicca **[Valori di gioco]**\n" +
                    "  * Tutti gli slider a 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)),
                    string.Empty
                },
            };
        }

        public void Unload()
        {
        }
    }
}
