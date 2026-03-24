// File: Locale/LocaleIT.cs
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
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Pulizia automatica" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestione manuale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Stato" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTE D'USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivato [ ✓ ]** mantiene pulita tutta la città.\n\n" +
                    "Quando **Total Magic** è ON:\n" +
                    "- Trash Boss viene forzato su OFF.\n" +
                    "- Gli slider di Trash Boss non vengono applicati (i valori restano salvati).\n"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestisce direttamente il sistema rifiuti mantenendo attiva la logica vanilla.\n\n" +
                    "- Quando **Trash Boss è ON [ ✓ ]**, Total Magic viene forzato su OFF.\n" +
                    "- Gli slider si applicano solo quando Trash Boss è attivo.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacità di carico dei camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanti rifiuti può trasportare ogni camion.**\n" +
                    "100% = valore normale del gioco.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocità di lavorazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente gli impianti lavorano i rifiuti in entrata.**\n" +
                    "100% = velocità vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Capacità di stoccaggio impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanti rifiuti può immagazzinare un impianto.**\n" +
                    "100% = stoccaggio vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotta impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion ogni impianto può inviare.**\n" +
                    "100% = numero vanilla di camion.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applica i valori consigliati di Trash Boss:\n" +
                    "- Capacità di carico dei camion: **200%**\n" +
                    "- Velocità di lavorazione: **200%**\n" +
                    "- Capacità di stoccaggio: **160%**\n" +
                    "- Numero di camion per impianto: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Riporta tutti gli slider a **100%** (valori vanilla)."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome mostrato di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versione attuale della mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Apre la pagina Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Apre l'invito Discord nel browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Modalità pulizia automatica>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Tutti i rifiuti vengono rimossi all'istante\n" +
                    " <-------------------------------------->\n\n" +
                    "<Modalità gestione manuale>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Regola gli slider come vuoi.\n" +
                    "  * Logica rifiuti vanilla con gestione migliore di camion/impianti.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Gioco vanilla normale>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Clicca **[Valori di gioco]**\n" +
                    "  * Tutti gli slider al 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rifiuti/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la quantità attuale di rifiuti in tutta la città e il tasso totale di lavorazione.\n" +
                    "Aumenta la lavorazione se i rifiuti prodotti al mese sono molto più alti.\n" +
                    "**Produced** e **Processed** usano tonnellate al mese.\n" +
                    "Ora aggiornamento = ultimo refresh."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Richieste di raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = richieste di raccolta attive non ancora assegnate a un camion o a un percorso.\n" +
                    "**Dispatched** = richieste di raccolta attive già assegnate.\n" +
                    "**Total** = tutte le richieste di raccolta rifiuti attive.\n" +
                    "Questo numero può essere temporaneamente più alto di **Above request threshold** perché le vecchie richieste vengono pulite più tardi dalla rivalidazione del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edifici" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = edifici che al momento hanno rifiuti.\n" +
                    "**Total** = tutti gli edifici che producono rifiuti in città.\n" +
                    "**Above request threshold** = edifici con abbastanza rifiuti da creare una richiesta di raccolta.\n" +
                    "Di solito questo significa più di <100> unità di rifiuti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Impianti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Riepilogo degli impianti rifiuti conteggiati.\n" +
                    "**Facilities** = edifici rifiuti conteggiati.\n" +
                    "**Trucks total** = camion dei rifiuti posseduti da quegli impianti.\n" +
                    "**Max workers** = capacità totale di lavoratori degli stessi impianti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = camion attualmente in giro per la città.\n" +
                    "**Returning** = sottoinsieme dei camion in movimento che stanno tornando all'impianto.\n" +
                    "**Parked** = camion parcheggiati in un impianto.\n" +
                    "**Total** = numero totale di camion dei rifiuti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Stato dettagliato nel log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Scrive un rapporto dettagliato sui rifiuti in **Logs/MagicGarbage.log**.\n" +
                    "Include una piccola legenda, soglie live, camion disabilitati e lavoratori massimi per impianto."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apre la cartella Logs/."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città caricata." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotte | {1:N0} t lavorate | aggiornato {2}" },
                { "MG.Status.Row.Requests", "{1:N0} in attesa | {2:N0} assegnate | {0:N0} totale" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} hanno rifiuti | {2:N0} sopra la soglia richiesta" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} impianti | {1:N0} camion totali | {2:N0} lavoratori max" },
                { "MG.Status.Row.Trucks", "{1:N0} in movimento ({3:N0} ritorno) | {2:N0} parcheggiati | {0:N0} totale" },
                { "MG.Status.Row.FacilitiesNone", "Nessun dato impianto per ora." },

                // Log strings
                { "MG.Status.Log.Title", "Stato rifiuti ({0})" },
                { "MG.Status.Log.City", "Città: {0}" },
                { "MG.Status.Log.Mode", "Modalità: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produced/Processed usa tonnellate al mese.\n" +
                    "- Le soglie qui sotto usano unità interne di rifiuti, non tonnellate.\n" +
                    "- Pickup threshold = quantità minima di rifiuti prima che un camion raccolga da un edificio.\n" +
                    "- Request threshold = quantità minima di rifiuti prima che il gioco crei o mantenga una richiesta di raccolta.\n" +
                    "- Warning threshold = quantità di rifiuti alla quale può comparire l'icona di avviso sopra un edificio.\n" +
                    "- Hard cap = quantità massima di rifiuti che un edificio può accumulare.\n" +
                    "- Returning = sottoinsieme dei camion in movimento.\n" +
                    "- Il numero di richieste attive può temporaneamente superare il numero di edifici sopra la soglia perché le vecchie richieste vengono pulite più tardi dalla rivalidazione vanilla.\n" +
                    "- I numeri dei lavoratori qui sotto mostrano attualmente i **lavoratori massimi** per ogni impianto."
                },
                { "MG.Status.Log.Thresholds",
                    "Soglie (unità interne di rifiuti): raccolta={1:N0}, richiesta={0:N0}, avviso={2:N0}, limite massimo={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Soglie: <GarbageParameterData non disponibile>" },
                { "MG.Status.Log.GarbageProcessing", "Rifiuti: {0:N0} t/mese | Lavorazione: {1:N0} t/mese" },
                { "MG.Status.Log.Requests", "Richieste di raccolta: in attesa={1:N0}, assegnate={2:N0}, totale={0:N0}" },
                { "MG.Status.Log.Producers", "Edifici: {0:N0} totale | {1:N0} hanno rifiuti | {2:N0} sopra la soglia richiesta | {3:N0} livello avviso" },
                { "MG.Status.Log.FacilitiesSummary", "Impianti: {0:N0} totale | {1:N0} camion totali | {2:N0} lavoratori max" },
                { "MG.Status.Log.Trucks", "Camion rifiuti: {2:N0} in movimento ({3:N0} ritorno) | {1:N0} parcheggiati | {4:N0} disabilitati | {0:N0} totale" },
                { "MG.Status.Log.FacilitiesHeader", "Riepilogo impianti" },
                { "MG.Status.Log.FacilityLine", "- Impianto {0}: moving={2:N0}, parked={3:N0}, total={1:N0}, max workers={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
