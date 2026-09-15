// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

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
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivo [ ✓ ]** mantiene pulita tutta la città.\n" +
                    "\n" +
                    "Quando **Total Magic** è ATTIVO:\n" +
                    "- Trash Boss viene forzato su OFF.\n" +
                    "- Gli slider di Trash Boss non vengono applicati (i valori restano salvati per dopo).\n" +
                    "- Alcuni camion possono ancora muoversi per il timing della logica di invio vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestisce direttamente i sistemi dei rifiuti; lascia in esecuzione la logica vanilla dei rifiuti.\n" +
                    "\n" +
                    "- Quando **Trash Boss è ATTIVO [ ✓ ]**, Total Magic viene forzato su OFF.\n" +
                    "- Gli slider si applicano solo quando Trash Boss è attivo.\n" +
                    "- Total Magic + Trash Boss possono essere entrambi **OFF** per ottenere impostazioni vanilla,\n" +
                    "  e puoi comunque vedere il **report di stato**, che si aggiorna solo quando apri il menu Opzioni (leggero)."
                },
                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacità di carico camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanti rifiuti può trasportare ogni camion.**\n" +
                    "**100% = valore normale** del gioco (20t).\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stoccaggio struttura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanti rifiuti può immagazzinare una struttura.**\n" +
                    "**100% = stoccaggio vanilla**.\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocità di lavorazione struttura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente le strutture trattano i rifiuti in arrivo.**\n" +
                    "**100% = velocità di lavorazione vanilla**.\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotta struttura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion ogni struttura può inviare.**\n" +
                    "**100% = numero vanilla** di camion.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Riserva capacità per la destinazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Controlla quando i camion diventano più selettivi con i ritiri opzionali prima della destinazione.**\n" +
                    "È una protezione flessibile, non spazio garantito. Predefinito = **10%**; intervallo sicuro = 10–25%."
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Valori bilanciati: camion **200%**, protezione destinazione **15%**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Riporta Trash Boss al **comportamento vanilla**.\n" +
                    "**Vanilla:**\n" +
                    "- Gli slider percentuali tornano a **100%**.\n" +
                    "- La protezione della destinazione torna al **10%**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome visualizzato di questa mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versione attuale della mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Apri la pagina Paradox Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Apri l’invito Discord nel browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato Pulizia automatica>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * I rifiuti vengono rimossi automaticamente - fatto.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Stato Gestione manuale>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Imposta gli slider come desideri.\n" +
                    "  * Facoltativo: attiva gli slider avanzati (non richiesto).\n" +
                    "  * Stesso sistema rifiuti del gioco; camion/strutture meglio gestiti manualmente.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Stato / vanilla>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Solo report di stato.\n" +
                    "  * Gioco vanilla dei rifiuti invariato."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Valutazione servizio rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Semplice valutazione della felicità rifiuti dal gioco.\n" +
                    "**0 = Eccellente**\n" +
                    "**-1 **= Serve piccolo aggiustamento. Il gioco passa spesso tra 0 e -1 e può essere ignorato (numero arrotondato).\n" +
                    "**-2 a -4** = Un po’ puzzolente\n" +
                    "**-5 a -10** = Problema rifiuti\n" +
                    "**Regolazioni indirette:** usa gli <slider dei rifiuti> per migliorare nel tempo riducendo l’accumulo.\n" +
                    "**Regolazioni dirette:** Base felicità rifiuti + Passo felicità rifiuti cambiano <ciò che i cims tollerano> prima di diventare scontenti.\n" +
                    "**Tasso di accumulo rifiuti**: cambia quanto velocemente gli edifici supportati producono rifiuti. Usa con cautela perché il bilanciamento è importante. La maggior parte dei giocatori non deve mai toccarlo.\n" +
                    "<Ora aggiornamento = ultimo aggiornamento.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Edifici con 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Numero di edifici che producono rifiuti con **7000 / 7t** o più.\n" +
                    "Questo indicatore fisso aiuta a pianificare il servizio prima delle icone di avviso.\n" +
                    "Lo stato dettagliato nel log elenca gli ID Entity."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rifiuti/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la produzione di rifiuti della città e la capacità di trattamento disponibile.\n" +
                    "Aumenta il trattamento se la produzione mensile supera la capacità.\n" +
                    "Entrambi i valori usano tonnellate al mese."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Richieste di raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**In attesa** = richieste di raccolta attive non ancora assegnate a un camion o percorso.\n" +
                    "**Inviate** = richieste di raccolta attive già assegnate.\n" +
                    "**Totale** = conta le entità richiesta **attive** correnti (nella pipeline dei rifiuti).\n" +
                    "\n" +
                    "Nota tecnica: è diverso da <Sopra soglia richiesta>. Conta le <richieste>, non gli edifici.\n" +
                    "Alcune richieste in attesa verranno assegnate dopo; altre possono anche sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno di servizio."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edifici" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ha rifiuti** = edifici che attualmente contengono rifiuti.\n" +
                    "**Totale** = tutti gli edifici produttori di rifiuti in città.\n" +
                    "**Sopra soglia richiesta** = conteggio attuale di **edifici** con abbastanza rifiuti per creare una richiesta di raccolta.\n" +
                    "Lo stato dettagliato nel log mostra la soglia richiesta attuale del gioco.\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Strutture" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Riepilogo delle strutture rifiuti contate.\n" +
                    "**Strutture** = edifici rifiuti contati.\n" +
                    "**Camion rifiuti** = normali camion di raccolta. Nelle strutture di rifiuti industriali raccolgono rifiuti industriali invece di rifiuti normali.\n" +
                    "**Dump trucks** = trasferimenti di rifiuti tra strutture.\n" +
                    "**Lavoratori max** = capacità totale di lavoratori in quelle stesse strutture."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camion rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**In movimento** = camion attualmente in città.\n" +
                    "**Di ritorno** = sottoinsieme dei camion in movimento indicati per tornare alla struttura.\n" +
                    "**Parcheggiati** = camion parcheggiati presso una struttura.\n" +
                    "**Totale** = conteggio di tutti i camion rifiuti."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Stato dettagliato nel log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Invia un report rifiuti più dettagliato in **Logs/MagicGarbage.log**.\n" +
                    "Include statistiche organizzate sui rifiuti della città"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Apre **MagicGarbage.log**; se il file non esiste ancora, apre la cartella Logs." },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città ancora caricata." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Eccellente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Serve piccolo aggiustamento ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Un po’ puzzolente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema rifiuti ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} edifici con 7t+" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotti | {1:N0} t capacità" },
                { "MG.Status.Row.Requests", "{1:N0} in attesa | {2:N0} inviate | {0:N0} totale" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ha rifiuti | {2:N0} sopra soglia richiesta" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} strutture | {1:N0}/{2:N0} camion rifiuti/dump trucks | {3:N0} lavoratori" },
                { "MG.Status.Row.Trucks", "{1:N0} in movimento ({3:N0} di ritorno) | {2:N0} parcheggiati | {0:N0} totale" },
                { "MG.Status.Row.FacilitiesNone", "Nessun dato struttura ancora." },

                // Log strings
                { "MG.Status.Log.Title", "Stato rifiuti ({0})" },
                { "MG.Status.Log.City", "Città: {0}" },
                { "MG.Status.Log.Mode", "Modalità: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Impostazioni mod attuali" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Slider Trash Boss (salvati): carico camion={0:N0}% | stoccaggio struttura={1:N0}% | trattamento struttura={2:N0}% | flotta struttura={3:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Prodotti/Trattati usa tonnellate al mese.\n" +
                    "- I valori di soglia sotto usano unità interne di rifiuti, non tonnellate.\n" +
                    "- Per l’interfaccia giocatore, il gioco converte 100 unità = 0.1t e 1,000 unità = 1t.\n" +
                    "- Valutazione servizio rifiuti = fattore felicità rifiuti della città.\n" +
                    "  - 0 = Eccellente\n" +
                    "  - -1 = Serve piccolo aggiustamento, oppure ignorare\n" +
                    "  - -2 a -4 = Un po’ puzzolente\n" +
                    "  - -5 a -10 = Problema rifiuti\n" +
                    "Slider soglie:\n" +
                    "  - Soglia raccolta = rifiuti minimi prima che un camion raccolga da un edificio.\n" +
                    "  - Soglia richiesta = rifiuti minimi prima che il gioco crei o mantenga una richiesta di raccolta.\n" +
                    "- Icona avviso = quantità di rifiuti che mostra un’icona di avviso sopra un edificio.\n" +
                    "- Limite rigido = rifiuti massimi che un edificio può accumulare.\n" +
                    "- In attesa = richieste attive non assegnate attualmente a un camion o percorso.\n" +
                    "- Alcune richieste in attesa verranno assegnate dopo; altre possono sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno di servizio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Soglie del gioco (unità interne di rifiuti): raccolta={1:N0}, richiesta={0:N0}, icona avviso={2:N0}, limite rigido={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Soglie: <GarbageParameterData non disponibile>" },
                { "MG.Status.Log.AdaptiveMargin", "Protezione destinazione: {0:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Produzione rifiuti: {0:N0} t/mese | Capacità di trattamento: {1:N0} t/mese" },
                { "MG.Status.Log.GarbageServiceRating", "Valutazione servizio rifiuti: {0} | grezzo={1:N2} | arrotondato={2:N0}" },
                { "MG.Status.Log.Requests", "Richieste di raccolta: in attesa={1:N0}, inviate={2:N0}, totale={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Bersaglio in attesa più alto: {0:N0} ({1:N1}t) presso {2}" },
                { "MG.Status.Log.PendingPeakNone", "Bersaglio in attesa più alto: nessuno" },
                { "MG.Status.Log.Producers", "Edifici: {0:N0} icone avviso | {1:N0} totale | {2:N0} ha rifiuti | {3:N0} sopra soglia richiesta " },
                { "MG.Status.Log.ProducerGarbageStats", "Rifiuti edifici (solo non-zero): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) presso {6}" },
                { "MG.Status.Log.NearWarning75", "Edifici vicini all’icona avviso (almeno {1:N0} unità / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Strutture: {0:N0} totale | {1:N0} camion rifiuti | {2:N0} dump trucks ({3:N0} in movimento) | {4:N0} lavoratori" },
                { "MG.Status.Log.Trucks", "Camion rifiuti: {2:N0} in movimento ({3:N0} di ritorno) | {1:N0} parcheggiati | {4:N0} disabilitati | {0:N0} totale" },
                { "MG.Status.Log.FacilitiesHeader", "Riepilogo strutture" },
                { "MG.Status.Log.FacilityLine",
                    "- Struttura {0}: camion rifiuti={1:N0} ({2:N0} in movimento, {3:N0} parcheggiati) | dump trucks={4:N0} ({5:N0} in movimento) | lavoratori max={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Eccellente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Serve piccolo aggiustamento" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Un po’ puzzolente" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema rifiuti" },

                { "MG.Status.Log.ThresholdsHeader", "Soglie + servizio" },
                { "MG.Status.Log.RequestsHeader", "Richieste" },
                { "MG.Status.Log.BuildingsHeader", "Edifici" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Edifici con 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonda trasferimento locale rifiuti" },
                { "MG.Status.Log.LocalTransferProbeNone", "Nessuna struttura locale rifiuti trovata." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda trasferimento rifiuti connessione esterna" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Nessuna struttura rifiuti di connessione esterna trovata." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda trasferimento rifiuti" },
                { "MG.Status.Log.TransferProbeNone", "Nessuna struttura di stoccaggio-trasferimento rifiuti trovata." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stoccati={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accetta={5:N2} | invia={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "Camion" },
                { "MG.Status.Log.SettingsPriority", "Percorsi adattivi (salvati): assistenza={0} | riserva normale={1:N0}% | emergenza={2:N0}%" },

                { "MG.Status.Log.PriorityState",
                    "Assistenza attiva={0} | intervallo={1:N0} frame | richieste controllate={2:N0} | destinazioni critiche={3:N0} | riserva={4:N0}% -> {5:N0}%"
                },
                { "MG.Status.Log.PriorityPeak", "Edificio critico più alto: {0:N0} ({1:N1}t) | {2} | richiesta={3}" },

                { "MG.Status.Log.PriorityHeader", "Assistenza prioritaria" },
                { "MG.Status.Log.PriorityPasses", "Passaggi priorità: aumentati={0:N0} | normali={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "Edificio critico attivo più alto: nessuno" },
                { "MG.Status.Log.PriorityPeakState.Pending", "in attesa" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "inviata" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Tempo ultima scansione assistenza prioritaria={0:N3} ms" },
#endif
                { "MG.Status.Log.CriticalBuildingsNone", "nessuno" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
