// LocaleIT.cs
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
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Informazioni" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Magia totale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-magia"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info mod"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link"         },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTE D'USO"   },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivato [X]** rimuove all'istante tutta l'immondizia della città.\n" +
                    "Edifici e camion dei rifiuti diventano quasi solo decorazione.\n\n" +

                    "Finché **Magia totale** è ATTIVA:\n" +
                    "- Semi-magia viene forzata su SPENTA.\n" +
                    "- Tutti gli slider di Semi-magia vengono ignorati.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "Semi-magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "Attiva un sistema rifiuti potenziato ma ancora in stile normale.\n" +
                    "- Usa camion e impianti più forti al posto della magia totale.\n" +
                    "- Quando Semi-magia è ATTIVA, Magia totale viene spenta automaticamente.\n" +
                    "- Gli slider qui sotto hanno effetto solo con Semi-magia attiva.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Carico per camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto rifiuto può trasportare ogni camion.**\n" +
                    "- 100 % = carico standard.\n" +
                    "- Valori più alti = servono meno viaggi.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Numero di camion per impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion può inviare ogni impianto.**\n" +
                    "- 100 % = numero standard di camion.\n" +
                    "- Fino a 400 % = fino al 300 % di camion in più.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocità di elaborazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente gli impianti trattano i rifiuti.**\n" +
                    "- 100 % = velocità standard.\n" +
                    "- Valori più alti = i rifiuti vengono bruciati / riciclati più in fretta.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacità di stoccaggio" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanti rifiuti può contenere un impianto prima di essere pieno.**\n" +
                    "- 100 % = capacità standard.\n" +
                    "- Valori più alti = l'impianto può accumulare più rifiuti prima di risultare pieno.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Valori predefiniti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Reimposta tutti gli slider di Semi-magia a **100 %** (valori vanilla).\n" +
                    "Usalo se vuoi tenere il mod installato senza cambiare le statistiche del servizio rifiuti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Applica i valori Semi-magia consigliati:\n" +
                    "- Carico per camion: **200 %**\n" +
                    "- Camion per impianto: **150 %**\n" +
                    "- Velocità di elaborazione: **200 %**\n" +
                    "- Capacità di stoccaggio: **200 %**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nome visualizzato di questo mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versione attuale del mod." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Apre la pagina Paradox Mods con i mod dell'autore."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Apre il Discord di modding di CS2 nel browser."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato predefinito consigliato>\n" +
                    "  * Magia totale ATTIVA = **[X]**\n" +
                    "  * Tutti i rifiuti vengono rimossi all'istante\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato Semi-magia con super camion>\n" +
                    "  * Magia totale SPENTA = **[ ]**\n" +
                    "  * Semi-magia ATTIVA = **[X]** e regola gli slider [100 >> 500] / [100 >> 400] a piacere.\n" +
                    "  * Gameplay in stile vanilla con camion e impianti potenziati.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Gioco completamente vanilla>\n" +
                    "  * Magia totale SPENTA = **[ ]**\n" +
                    "  * Semi-magia = **[X]** (clicca Valori predefiniti)\n" +
                    "  * Tutti gli slider a 100 % (limiti vanilla)\n" +
                    "  * Gameplay esattamente standard.\n"
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
