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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Pulizia auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestione manuale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivato [ ✓ ]** mantiene pulita tutta la città.\n\n" +
                    "Quando **Total Magic** è attivo:\n" +
                    "- Trash Boss viene forzato su OFF.\n" +
                    "- Gli slider di Trash Boss non vengono applicati (i valori restano salvati per dopo).\n" +
                    "- Alcuni camion possono ancora muoversi per il timing di dispatch vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestisce direttamente i sistemi della spazzatura; lascia attiva la logica vanilla.\n\n" +
                    "- Quando **Trash Boss è ON [ ✓ ]**, Total Magic viene forzato su OFF.\n" +
                    "- Gli slider si applicano solo quando Trash Boss è attivo.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacità di carico camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanta spazzatura può trasportare ogni camion.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stoccaggio impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanta spazzatura può immagazzinare un impianto.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocità processo impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente gli impianti processano la spazzatura in arrivo.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility Fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion può inviare ogni impianto.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "Soglie edifici" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "Opzionale: alza le **soglie** che un edificio deve raggiungere per ottenere la raccolta rifiuti. \n" +
                    "Aumentarlo può aiutare a ridurre il traffico dei camion della spazzatura; ma troppo alto riduce i viaggi di raccolta.\n" +
                    "La maggior parte delle persone <non> ha bisogno di toccarlo. Il mod funzionava bene anche prima di questa opzione; è solo un extra per fare esperimenti.\n"+
                    "--------------------------------\n" +
                    "- **Soglia richiesta dispatch (R)** = spazzatura dell'edificio necessaria per chiamare una <richiesta di dispatch camion>.\n" +
                    "- **Soglia raccolta (P)** = quantità minima di spazzatura prima che un camion possa raccoglierla.\n" +
                    "**1x** = vanilla (100 R, 20 P). Nota: **1.000** unità di spazzatura di solito sono **1t**.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "Con lo slider a **20x**, la **R** dell'edificio deve raggiungere >= **2.000 (2t)** unità prima che un camion riceva una <richiesta di dispatch>;\n" +
                    "Il gioco vanilla fa anche fermare i camion agli edifici andando/ritornando dall'edificio di <dispatch> se il camion non è vuoto; a 20x, gli edifici lungo il percorso devono avere più di **400 spazzatura** (20 x P vanilla = 20).\n" +
                    "Consiglio di bilanciamento: guarda spesso il pulsante del rapporto dettagliato nel log mentre regoli questo valore.\n" +
                    "Potresti dover aumentare la capacità dei camion se alzi molto la soglia, perché le case terranno la spazzatura molto più a lungo prima di chiamare un camion."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applica i valori consigliati di Trash Boss:\n" +
                    "- Capacità di carico camion: **200%**\n" +
                    "- Soglia dispatch: **5x**\n" +
                    "- Velocità di processo: **200%**\n" +
                    "- Capacità di stoccaggio: **150%**\n" +
                    "- Numero camion impianto: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valori del gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Riporta tutti gli slider di Trash Boss ai valori vanilla.\n" +
                    "- Gli slider percentuali tornano a **100%**.\n" +
                    "- La soglia dispatch torna a **1x**."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome mostrato di questo mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versione attuale del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Apri la pagina Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Apri l'invito Discord nel browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato Auto Clean>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * La spazzatura viene rimossa automaticamente - Fatto.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato gestione manuale>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Imposta gli slider come preferisci.\n" +
                    "  * Stessa spazzatura del gioco; camion/impianti autogestiti migliori.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Gioco vanilla normale>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * Tutti gli slider ai valori vanilla\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Spazzatura/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la quantità attuale di spazzatura in tutta la città e il tasso totale di processo.\n" +
                    "Aumenta il processo se la spazzatura prodotta al mese è molto più alta.\n" +
                    "**Prodotta** e **Processata** usano tonnellate al mese.\n" +
                    "<Ora aggiornamento = ultimo refresh.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Richieste raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**In attesa** = richieste di raccolta attive non assegnate al momento a un camion o percorso.\n" +
                    "**Dispatchate** = richieste di raccolta attive già assegnate.\n" +
                    "**Totale** = conta l'entità richiesta **attiva** corrente (nella pipeline rifiuti).\n\n" +
                    "Nota tecnica: è diverso da <Sopra la soglia richiesta>. Qui si contano le <richieste>, non gli edifici.\n" +
                    "Alcune richieste in attesa verranno assegnate più tardi; altre possono anche sparire dopo se la rivalutazione vanilla decide che il bersaglio non ha più bisogno del servizio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ha spazzatura** = edifici che al momento contengono spazzatura.\n" +
                    "**Totale** = tutti gli edifici che producono spazzatura in città.\n" +
                    "**Sopra la soglia richiesta** = numero attuale di **edifici** con abbastanza spazzatura da creare una richiesta di raccolta.\n" +
                    "In vanilla, la soglia richiesta è **100** unità interne di spazzatura.\n" +
                    "La **soglia dispatch** di Trash Boss alza insieme soglia raccolta e soglia richiesta.\n" +
                    "Questo riduce il traffico dei camion della spazzatura perché abbassa il totale degli edifici <sopra la soglia richiesta> e il totale <dispatchato>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Facilities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Riepilogo degli impianti di spazzatura conteggiati.\n" +
                    "**Impianti** = edifici dei rifiuti conteggiati.\n" +
                    "**Camion totali** = camion della spazzatura posseduti da quegli impianti.\n" +
                    "**Lavoratori max** = capacità totale lavoratori su quegli stessi impianti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**In movimento** = camion attualmente in città.\n" +
                    "**Rientro** = sottoinsieme dei camion in movimento contrassegnati per tornare al loro impianto.\n" +
                    "**Parcheggiati** = camion parcheggiati presso un impianto.\n" +
                    "**Totale** = numero di tutti i camion della spazzatura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Stato dettagliato nel log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Invia un rapporto più dettagliato sulla spazzatura in **Logs/MagicGarbage.log**.\n" +
                    "Include una breve legenda, valori di riferimento vanilla e molte statistiche extra reali sulla spazzatura cittadina."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apri la cartella Logs/.. del gioco."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città caricata al momento." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotte | {1:N0} t trattate | agg. {2}" },
                { "MG.Status.Row.Requests", "{1:N0} in attesa | {2:N0} assegnate | {0:N0} totale" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} hanno rifiuti | {2:N0} sopra la soglia di richiesta" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} impianti | {1:N0} camion totali | {2:N0} lavoratori max" },
                { "MG.Status.Row.Trucks", "{1:N0} in movimento ({3:N0} in ritorno) | {2:N0} parcheggiati | {0:N0} totale" },
                { "MG.Status.Row.FacilitiesNone", "Nessun dato impianto disponibile al momento." },

                // Log strings
                { "MG.Status.Log.Title", "Stato rifiuti ({0})" },
                { "MG.Status.Log.City", "Città: {0}" },
                { "MG.Status.Log.Mode", "Modalità: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Prodotto/Trattato usa tonnellate al mese.\n" +
                    "- I valori di soglia qui sotto usano unità interne di rifiuti, non tonnellate.\n" +
                    "- Per il giocatore, il gioco converte 1.000 unità = 1t.\n" +
                    "Cursore soglia di dispatch:\n" +
                    "  - Soglia di raccolta = rifiuti minimi prima che un camion raccolga da un edificio.\n" +
                    "  - Soglia di richiesta = rifiuti minimi prima che il gioco crei o mantenga una richiesta di raccolta.\n" +
                    "- Icona di avviso = quantità di rifiuti che fa apparire un'icona di avviso sopra un edificio.\n" +
                    "- Limite massimo = quantità massima di rifiuti che un edificio può accumulare.\n" +
                    "- In attesa = richieste attive non attualmente assegnate a un camion o a un percorso.\n" +
                    "- Alcune richieste in attesa verranno assegnate più tardi; altre potranno anche sparire più tardi se la rivalidazione vanilla decide che il bersaglio non ha più bisogno di servizio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Soglie del gioco (unità interne di rifiuti): raccolta={1:N0}, richiesta={0:N0}, icona di avviso={2:N0}, limite massimo={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Soglie: <GarbageParameterData non disponibile>" },
                { "MG.Status.Log.GarbageProcessing", "Rifiuti: {0:N0} t/mese | Trattamento: {1:N0} t/mese" },
                { "MG.Status.Log.Requests", "Richieste di raccolta: in attesa={1:N0}, assegnate={2:N0}, totale={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Bersaglio in attesa con più rifiuti: {0:N0} ({1:N1}t) a {2}" },
                { "MG.Status.Log.Producers", "Edifici: {0:N0} totale | {1:N0} hanno rifiuti | {2:N0} sopra la soglia di richiesta | {3:N0} a livello avviso" },
                { "MG.Status.Log.ProducerGarbageStats", "Rifiuti edifici (solo non zero): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) a {6}" },
                { "MG.Status.Log.NearWarning75", "Edifici vicini all'avviso (>= {1:N0} unità / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Impianti: {0:N0} totale | {1:N0} camion totali | {2:N0} lavoratori max" },
                { "MG.Status.Log.Trucks", "Camion dei rifiuti: {2:N0} in movimento ({3:N0} in ritorno) | {1:N0} parcheggiati | {4:N0} disabilitati | {0:N0} totale" },
                { "MG.Status.Log.FacilitiesHeader", "Riepilogo impianti" },
                { "MG.Status.Log.FacilityLine", "- Impianto {0}: in movimento={2:N0}, parcheggiati={3:N0}, totale={1:N0}, lavoratori max={4:N0}" },


            };
        }

        public void Unload()
        {
        }
    }
}
