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
                    "- Total Magic + Trash Boss possono essere entrambi **OFF** per usare le impostazioni vanilla,\n" +
                    "  e puoi comunque vedere il **report di stato**, che si aggiorna solo quando apri il menu Opzioni (leggero)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacità di carico camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanti rifiuti può trasportare ogni camion.**\n" +
                    "**100% = capacità vanilla** del camion (20t).\n"
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

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Riserva destinazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Stabilisce quanto presto i camion diventano selettivi con i ritiri opzionali mentre vanno all’edificio assegnato.**\n" +
                    "**10% è il valore vanilla della versione 1.6.2.**\n" +
                    "Per un normale camion da 20t:\n" +
                    "- 10% inizia a proteggere la fermata assegnata 2t prima.\n" +
                    "- 15% inizia 3t prima.\n" +
                    "- 25% inizia 5t prima.\n" +
                    "Valori più alti danno un margine di sicurezza maggiore. I camion saltano prima i piccoli ritiri, lasciando più spazio per l’edificio assegnato."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applica valori bilanciati per città molto attive.\n" +
                    "Carico camion **200%** | stoccaggio **150%** | lavorazione **250%**\n" +
                    "Flotta **100%** | riserva destinazione **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Reimposta slider" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Reimposta gli slider standard di Trash Boss.\n" +
                    "- Gli slider percentuali tornano a **100%**.\n" +
                    "- La riserva destinazione torna al valore **vanilla del 10%**.\n"
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
                    "L’effetto medio cittadino della felicità legata ai rifiuti nel gioco.\n" +
                    "Una buona valutazione generale può comunque includere alcuni edifici problematici, quindi controlla anche gli **edifici con 7t+**.\n" +
                    "**0 = Eccellente nel complesso**\n" +
                    "**-1 = Serve un piccolo aggiustamento**\n" +
                    "**-2 a -4 = Un po’ puzzolente**\n" +
                    "**-5 o meno = Problema rifiuti**\n" +
                    "\n" +
                    "Migliora il servizio con gli slider di camion e strutture, poi lascia scorrere la città prima di controllare di nuovo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Edifici con 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Numero di edifici che producono rifiuti con almeno **7000 / 7t**.\n" +
                    "Questo indicatore fisso di preallarme aiuta a decidere se aumentare il servizio prima che gli edifici raggiungano il livello dell’icona di avviso del gioco.\n" +
                    "Usa Stato dettagliato nel log per elencare i loro ID Entity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rifiuti/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la produzione di rifiuti cittadina, la lavorazione corrente e la capacità di lavorazione disponibile delle strutture.\n" +
                    "Aumenta la lavorazione se la produzione mensile supera la capacità.\n" +
                    "Tutti i valori usano tonnellate al mese."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Richieste di raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**In attesa** = richieste di raccolta attive non attualmente assegnate a un camion o percorso.\n" +
                    "**Inviate** = richieste di raccolta attive già assegnate.\n" +
                    "**Totale** = tutte le richieste **attive** correnti nella pipeline dei rifiuti.\n" +
                    "\n" +
                    "È diverso da **Sopra soglia richiesta**, che conta gli edifici invece delle richieste.\n" +
                    "Alcune richieste in attesa verranno assegnate più tardi; altre possono anche sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno di servizio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edifici" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ha rifiuti** = edifici che attualmente contengono rifiuti.\n" +
                    "**Totale** = tutti gli edifici produttori di rifiuti in città.\n" +
                    "**Sopra soglia richiesta** = conteggio attuale di **edifici** con abbastanza rifiuti per creare una richiesta di raccolta.\n" +
                    "Lo stato dettagliato nel log mostra la soglia richiesta attiva corrente del gioco.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Strutture" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Riepilogo delle strutture rifiuti conteggiate.\n" +
                    "**Strutture** = edifici rifiuti conteggiati.\n" +
                    "**Camion rifiuti** = normali camion di raccolta. Nelle strutture di rifiuti industriali raccolgono rifiuti industriali invece di rifiuti normali.\n" +
                    "**Autocarri ribaltabili** = trasferimenti di rifiuti tra strutture.\n" +
                    "**Lavoratori max** = capacità totale di lavoratori in quelle stesse strutture."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camion rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**In movimento** = camion attualmente in giro per la città.\n" +
                    "**Di ritorno** = sottoinsieme dei camion in movimento contrassegnati per tornare alla struttura.\n" +
                    "**Parcheggiati** = camion parcheggiati presso una struttura.\n" +
                    "**Totale** = conteggio di tutti i camion rifiuti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Stato dettagliato nel log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Invia un report rifiuti più dettagliato in **Logs/MagicGarbage.log**.\n" +
                    "Include statistiche organizzate sui rifiuti della città."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Apre **MagicGarbage.log**. Se manca o non può essere aperto, apre invece la cartella Logs del gioco." },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città ancora caricata." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Eccellente nel complesso ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Serve un piccolo aggiustamento ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Un po’ puzzolente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema rifiuti ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} edifici con 7t+" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotte | {2:N0} t lavorate | {1:N0} t capacità" },
                { "MG.Status.Row.Requests", "{1:N0} in attesa | {2:N0} inviate | {0:N0} totale" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ha rifiuti | {2:N0} sopra soglia richiesta" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} strutture | {1:N0}/{2:N0} camion rifiuti/ribaltabili | {3:N0} lavoratori" },
                { "MG.Status.Row.Trucks", "{1:N0} in movimento ({3:N0} di ritorno) | {2:N0} parcheggiati | {0:N0} totale" },
                { "MG.Status.Row.FacilitiesNone", "Nessun dato sulle strutture per ora." },

                // Log strings
                { "MG.Status.Log.Title", "Stato rifiuti ({0})" },
                { "MG.Status.Log.City", "Città: {0}" },
                { "MG.Status.Log.Mode", "Modalità: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Impostazioni attuali della mod" },
                { "MG.Status.Log.SettingsTrashBoss", "Slider Trash Boss (salvati): carico camion={0:N0}% | stoccaggio struttura={1:N0}% | lavorazione struttura={2:N0}% | flotta struttura={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produzione, lavorazione corrente e capacità usano tonnellate al mese.\n" +
                    "- I valori di soglia sotto usano unità interne dei rifiuti, non tonnellate.\n" +
                    "- Per la visualizzazione al giocatore, il gioco converte 100 unità = 0.1t e 1,000 unità = 1t.\n" +
                    "- Valutazione servizio rifiuti = fattore di felicità cittadino legato ai rifiuti nel gioco.\n" +
                    "  - 0 = Eccellente nel complesso\n" +
                    "  - -1 = Serve un piccolo aggiustamento\n" +
                    "  - -2 a -4 = Un po’ puzzolente\n" +
                    "  - -5 a -10 = Problema rifiuti\n" +
                    "Valori di instradamento:\n" +
                    "  - La soglia di raccolta è il minimo vanilla; l’instradamento consapevole della destinazione può aumentarla per camion per proteggere capacità per la destinazione.\n" +
                    "  - La soglia di richiesta è la quantità minima di rifiuti prima che il gioco crei o mantenga una richiesta di raccolta.\n" +
                    "- L’icona di avviso appare quando i rifiuti dell’edificio superano il livello di avviso attivo.\n" +
                    "- Limite massimo = quantità massima di rifiuti che un edificio può accumulare.\n" +
                    "- In attesa = richieste attive non attualmente assegnate a un camion o percorso.\n" +
                    "- Alcune richieste in attesa verranno assegnate più tardi; altre possono anche sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno di servizio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Soglie di gioco (unità interne dei rifiuti): raccolta={1:N0}, richiesta={0:N0}, icona avviso={2:N0}, limite massimo={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Soglie: <GarbageParameterData non disponibile>" },
                { "MG.Status.Log.AdaptiveMargin", "Riserva destinazione: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Riserva destinazione: attuale={0:N0}% | valore base del gioco al caricamento={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Produzione rifiuti: {0:N0} t/mese | Lavorazione corrente: {2:N0} t/mese | Capacità di lavorazione: {1:N0} t/mese" },
                { "MG.Status.Log.GarbageServiceRating", "Valutazione servizio rifiuti: {0} | grezzo={1:N2} | arrotondato={2:N0}" },
                { "MG.Status.Log.Requests", "Richieste di raccolta: in attesa={1:N0}, inviate={2:N0}, totale={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Massima quantità di rifiuti su un bersaglio in attesa: {0:N0} ({1:N1}t) presso {2}" },
                { "MG.Status.Log.PendingPeakNone", "Massima quantità di rifiuti su un bersaglio in attesa: nessuna" },
                { "MG.Status.Log.Producers", "Edifici: {0:N0} sopra il livello di avviso | {1:N0} totale | {2:N0} ha rifiuti | {3:N0} sopra soglia richiesta" },
                { "MG.Status.Log.ProducerGarbageStats", "Rifiuti degli edifici (solo valori non zero): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) presso {6}" },
                { "MG.Status.Log.NearWarning75", "Edifici vicini all’icona di avviso (almeno {1:N0} unità / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Strutture: {0:N0} totale | {1:N0} camion rifiuti | {2:N0} autocarri ribaltabili ({3:N0} in movimento) | {4:N0} lavoratori" },
                { "MG.Status.Log.Trucks", "Camion rifiuti: {2:N0} in movimento ({3:N0} di ritorno) | {1:N0} parcheggiati | {4:N0} disattivati | {0:N0} totale" },
                { "MG.Status.Log.FacilitiesHeader", "Riepilogo strutture" },
                { "MG.Status.Log.FacilityLine", "- Struttura {0}: camion rifiuti={1:N0} ({2:N0} in movimento, {3:N0} parcheggiati) | autocarri ribaltabili={4:N0} ({5:N0} in movimento) | lavoratori max={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Eccellente nel complesso" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Serve un piccolo aggiustamento" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Un po’ puzzolente" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema rifiuti" },

                { "MG.Status.Log.ThresholdsHeader", "Soglie + servizio" },
                { "MG.Status.Log.RequestsHeader", "Richieste" },
                { "MG.Status.Log.BuildingsHeader", "Edifici" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Edifici con 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonda locale trasferimento rifiuti" },
                { "MG.Status.Log.LocalTransferProbeNone", "Nessuna struttura locale dei rifiuti trovata." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda trasferimento rifiuti connessione esterna" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Nessuna struttura rifiuti di connessione esterna trovata." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda trasferimento rifiuti" },
                { "MG.Status.Log.TransferProbeNone", "Nessuna struttura di stoccaggio-trasferimento rifiuti trovata." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | stoccato={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accetta={5:N2} | invia={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Camion" },

                { "MG.Status.Log.CriticalBuildingsNone", "nessuno" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
