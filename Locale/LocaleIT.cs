// Locale/LocaleIT.cs
// Italian (it-IT)

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
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Informazioni" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Pulizia automatica" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Gestione manuale"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info mod"          },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link"              },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTE D’USO"        },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivato [ ✓ ]** rimuove istantaneamente tutta l’immondizia della città.\n" +
                    "Gli edifici e i camion della nettezza diventano principalmente decorativi.\n\n" +

                    "Quando **Magia totale** è ATTIVA:\n" +
                    "- La Semi-magia viene disattivata automaticamente.\n" +
                    "- Tutti gli slider della Semi-magia vengono ignorati.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gestisci direttamente i sistemi di raccolta rifiuti; la logica vanilla resta attiva.\n\n" +
                    "- Quando **Semi-magia è ATTIVA [ ✓ ]**, Magia totale viene disattivata automaticamente.\n" +
                    "- Regola tutti i camion e gli edifici per la raccolta rifiuti.\n" +
                    "- Gli slider hanno effetto solo quando la Semi-magia è attiva [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacità di carico dei camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanta immondizia può trasportare ogni camion.**\n" +
                    "100% = valore predefinito del gioco.\n" +
                    "<100% = 20 t>\n" +
                    "<500% = 100 t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Numero di camion per impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion può inviare ogni impianto.**\n" +
                    "100% = numero di camion standard.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocità di elaborazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente gli impianti elaborano i rifiuti in ingresso.**\n" +
                    "100% = velocità di elaborazione standard.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacità di stoccaggio dell’impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanti rifiuti può immagazzinare un impianto.**\n" +
                    "100% = capacità di stoccaggio standard.\n" +
                    "Valori più alti = l’impianto può contenere più rifiuti.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Valori predefiniti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Reimposta tutti gli slider a **100%** (valori vanilla).\n" +
                    "Ripristina il comportamento normale del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Applica i valori consigliati per la Semi-magia:\n" +
                    "- Capacità di carico dei camion: **200%**\n" +
                    "- Numero di camion per impianto: **150%**\n" +
                    "- Velocità di elaborazione: **200%**\n" +
                    "- Capacità di stoccaggio: **150%**\n"
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
                    "Apre la pagina **Paradox Mods** con le mod dell’autore."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Apre **Discord** nel browser per il modding di CS2."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato di pulizia automatica>\n" +
                    "  * Magia totale ATTIVA = **[ ✓ ]**\n" +
                    "  * Tutti i rifiuti vengono rimossi all’istante\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato di auto-gestione>\n" +
                    "  * Attiva Semi-magia = **[ ✓ ]**\n" +
                    "  * Imposta gli slider [100 >> 500] come preferisci.\n" +
                    "  * Simulazione vanilla con camion e impianti potenziati e regolabili.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Gioco vanilla normale>\n" +
                    "  * Semi-magia = **[ ✓ ]**\n" +
                    "  * Clicca su **[Valori predefiniti]**\n" +
                    "  * Tutti gli slider a 100% (vanilla)\n" +
                    "  * Gioco standard.\n"
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
