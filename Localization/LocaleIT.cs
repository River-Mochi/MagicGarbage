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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Informazioni" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Pulizia automatica" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestione manuale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Esperto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Stato" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivo [ ✓ ]** mantiene pulita tutta la città.\n\n" +
                    "Quando **Magia totale** è ON:\n" +
                    "- Gestore rifiuti viene forzato su OFF.\n" +
                    "- I cursori di Gestore rifiuti non vengono applicati (i valori restano salvati per dopo).\n" +
                    "- Alcuni camion possono ancora muoversi per via dei tempi della logica vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Gestore rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestisce direttamente i sistemi dei rifiuti; la logica vanilla continua a funzionare.\n\n" +
                    "- Quando **Gestore rifiuti è ON [ ✓ ]**, Magia totale viene forzata su OFF.\n" +
                    "- I cursori si applicano solo quando Gestore rifiuti è attivo.\n" +
                    "- Sia Magia totale che Gestore rifiuti possono essere **OFF** se serve solo il **rapporto di stato**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacità carico camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanti rifiuti può trasportare ogni camion.**\n" +
                    "**100% = normale** valore predefinito del gioco.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stoccaggio struttura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanti rifiuti può immagazzinare una struttura.**\n" +
                    "**100% = stoccaggio vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocità elaborazione struttura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente le strutture elaborano i rifiuti in ingresso.**\n" +
                    "**100% = velocità di elaborazione vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotta struttura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion può inviare ogni struttura.**\n" +
                    "**100% = numero vanilla** di camion.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applica i valori standard **consigliati** di Gestore rifiuti.\n" +
                    "Non cambia le impostazioni di Esperto (separate)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Riporta i cursori di Gestore rifiuti ai **valori vanilla**.\n" +
                    "<Non> cambia le impostazioni di Esperto.\n" +
                    "**Vanilla:**\n" +
                    "- I cursori percentuali tornano a **100%**.\n" +
                    "- Dispatch Request Threshold torna a **100 unità**.\n" +
                    "- Pickup Threshold torna a **20 unità**.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opzioni Esperto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Impostazioni avanzate opzionali\n" +
                    "<Attenzione: NON necessarie> per un buon servizio; sono pensate per chi vuole sperimentare o capire meglio come funzionano i sistemi.\n" +
                    "Quando **OFF**, tutte le impostazioni di Esperto **restano vanilla**.\n" +
                    "Quando **ON**, i **cursori avanzati** compaiono.\n\n" +
                    "<--- Esempi felicità --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalità a <165>.\n" +
                    " - Fai clic su <Consigliato> per 550/150 = 1ª penalità a <700>.\n" +
                    " - <Molto morbido> 950/200 = 1ª penalità rifiuti a <1150>.\n" +
                    "Comodità: gli ultimi valori dei cursori vengono salvati quando questa opzione è OFF (nel caso si voglia riattivarla più tardi)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Soglia richiesta invio" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantità di rifiuti in un edificio necessaria prima che venga creata o mantenuta una richiesta di invio camion.**\n" +
                    "Vanilla = **100** unità di rifiuti.\n" +
                    "**100 unità di rifiuti = 0.1t**\n" +
                    "**1.000 unità di rifiuti = 1t**\n" +
                    "Mantieni questo valore uguale o superiore alla Soglia raccolta.\n" +
                    "Di solito questo aumenta quanti camion vengono usati invece di restare parcheggiati."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Soglia raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantità minima di rifiuti in un edificio prima che un camion possa raccoglierli.**\n" +
                    "Vanilla = **20** unità di rifiuti.\n" +
                    "Il cursore di raccolta <non può> essere più alto di Dispatch Request (DR); viene limitato per evitare problemi di logica.\n" +
                    "Se un camion viene inviato a un edificio e il valore di raccolta è più alto del DR, a volte il camion potrebbe non riuscire a raccogliere dall'edificio (anche il tasso di accumulo influisce).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Livello di rifiuti di un edificio prima che inizi a causare penalità a salute + felicità.**\n" +
                    "**Vanilla = 100** unità di rifiuti.\n" +
                    "Base più alta = gli edifici possono trattenere più rifiuti prima che inizi la penalità.\n" +
                    "100 unità di rifiuti = 0.1t\n" +
                    "Panoramica:\n" +
                    "- <Threshold> = punto di attivazione del comportamento del sistema\n" +
                    "- <Baseline> = punto iniziale della formula di penalità\n" +
                    "- <Step> = dimensione dell'incremento nella formula, cioè quanto velocemente cresce la penalità dopo l'inizio"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Passo felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Quantità extra di rifiuti sopra la base che fa partire una penalità di -1.**\n" +
                    "Vanilla = **65** unità di rifiuti.\n" +
                    "Passo più alto = crescita più lenta della penalità.\n" +
                    "Il gioco limita la penalità rifiuti a **-10**.\n" +
                    "La prima penalità vanilla <-1 penalty> scatta a **165 rifiuti** (100 base + 65 passo)\n" +
                    "Bilancia le modifiche delle soglie con i cursori della felicità o rischi penalità più pesanti del normale."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tasso accumulo rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Scala i valori di fonte dei rifiuti degli edifici supportati.**\n" +
                    "È una leva forte e cambiare questo tasso influisce su molte cose.\n" +
                    "È possibile ottenere un buon sistema anche senza usarlo.\n\n" +
                    "**100% = accumulo vanilla**.\n" +
                    "**20%** = accumulo molto più lento.\n" +
                    "**200%** = doppio ritmo - davvero tantissimi rifiuti.\n" +
                    "Al 20%, è ovvio che tutti i Cims stanno facendo compostaggio, quindi l'accumulo di rifiuti è più basso ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Applica i valori **consigliati** di Esperto.\n" +
                    "Attiva Esperto.\n" +
                    "La prima penalità rifiuti parte a **700** rifiuti (550 base + 150 passo).\n" +
                    "Il Tasso accumulo rifiuti resta a **100%** vanilla finché non viene cambiato manualmente."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Riporta i valori di Esperto **a vanilla**.\n" +
                    "Mette **Esperto su OFF**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome visualizzato di questo mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versione attuale del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Apre la pagina Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Apre l'invito Discord nel browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato pulizia automatica>\n" +
                    "  * Magia totale ON = **[ ✓ ]**\n" +
                    "  * I rifiuti vengono rimossi automaticamente - fatto.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato gestione manuale>\n" +
                    "  * Gestore rifiuti = **[ ✓ ]**\n" +
                    "  * Imposta i cursori come preferisci.\n" +
                    "  * Facoltativo: attiva per usare i cursori avanzati (non richiesto).\n" +
                    "  * Stessi rifiuti del gioco; camion/strutture gestiti meglio.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato stato / vanilla>\n" +
                    "  * Magia totale = OFF\n" +
                    "  * Gestore rifiuti = OFF\n" +
                    "  * Solo rapporto di stato.\n" +
                    "  * Il sistema rifiuti vanilla del gioco resta invariato."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Valutazione servizio rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Semplice valutazione cittadina della felicità rifiuti dal gioco.\n" +
                    "**0 = Eccellente**\n" +
                    "**-1 = Serve un piccolo ritocco** il gioco può oscillare spesso tra 0 e -1, e si può anche ignorare.\n" +
                    "**-2 a -4 = Un po' puzzolente**\n" +
                    "**-5 a -10 = Problema rifiuti**\n" +
                    "**Leve indirette:** i cursori di camion/strutture/soglie possono migliorarlo nel tempo riducendo il reale accumulo di rifiuti.\n" +
                    "**Leve dirette:** <Base felicità rifiuti> + <Passo felicità rifiuti> cambiano quanto i cims tollerano prima di diventare infelici.\n" +
                    "**Leva tasso fonte:** <Tasso accumulo rifiuti> cambia quanto velocemente gli edifici supportati producono rifiuti.\n" +
                    "<Ora aggiornamento = ultimo aggiornamento.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rifiuti/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la quantità attuale di rifiuti in tutta la città e il tasso totale di elaborazione.\n" +
                    "Aumenta l'elaborazione se i rifiuti prodotti al mese sono molto più alti.\n" +
                    "**Prodotti** e **Elaborati** usano tonnellate al mese.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Richieste raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**In attesa** = richieste di raccolta attive non ancora assegnate a un camion o a un percorso.\n" +
                    "**Inviate** = richieste di raccolta attive già assegnate.\n" +
                    "**Totale** = conta l'entità richiesta **attiva** corrente (nella pipeline dei rifiuti).\n\n" +
                    "Nota tecnica: è diverso da <Sopra soglia richiesta>. Qui si contano le <richieste>, non gli edifici.\n" +
                    "Alcune richieste in attesa verranno assegnate più tardi; altre possono anche sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno del servizio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edifici" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ha rifiuti** = edifici che al momento contengono rifiuti.\n" +
                    "**Totale** = tutti gli edifici cittadini che producono rifiuti.\n" +
                    "**Sopra soglia richiesta** = numero attuale di **edifici** con abbastanza rifiuti da creare una richiesta di raccolta.\n" +
                    "In vanilla, la soglia richiesta è **100** unità interne di rifiuti.\n" +
                    "Le Opzioni Esperto possono sostituire le soglie di richiesta e raccolta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Strutture" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Riepilogo delle strutture rifiuti conteggiate.\n" +
                    "**Strutture** = edifici rifiuti conteggiati.\n" +
                    "**Camion rifiuti** = normali camion di raccolta. Nelle strutture di rifiuti industriali raccolgono rifiuti industriali invece dei normali rifiuti.\n" +
                    "**Dump truck** = trasferimenti di rifiuti tra strutture.\n" +
                    "**Lavoratori max** = capacità totale di lavoratori nelle stesse strutture."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camion rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**In movimento** = camion attualmente in giro per la città.\n" +
                    "**Rientro** = sottoinsieme dei camion in movimento contrassegnati per tornare alla propria struttura.\n" +
                    "**Parcheggiati** = camion parcheggiati presso una struttura.\n" +
                    "**Totale** = numero di tutti i camion rifiuti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Stato dettagliato nel log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Invia un rapporto rifiuti più dettagliato in **Logs/MagicGarbage.log**.\n" +
                    "Include una breve legenda, valori vanilla di riferimento e molte statistiche extra reali della città."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apre la cartella Logs/.. del gioco."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città caricata." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Eccellente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Serve un piccolo ritocco ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Un po' puzzolente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema di rifiuti ({0:N0}) | aggiornato {1}" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotte | {1:N0} t lavorate" },
                { "MG.Status.Row.Requests", "{1:N0} in attesa | {2:N0} assegnate | {0:N0} totale" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} hanno rifiuti | {2:N0} sopra la soglia" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} impianti | {1:N0}/{2:N0} rifiuti/Dump camion | {3:N0} lavoratori" },
                { "MG.Status.Row.Trucks", "{1:N0} in movimento ({3:N0} rientro) | {2:N0} parcheggiati | {0:N0} totale" },
                { "MG.Status.Row.FacilitiesNone", "Nessun dato sugli impianti per ora." },

                // Log strings
                { "MG.Status.Log.Title", "Stato rifiuti ({0})" },
                { "MG.Status.Log.City", "Città: {0}" },
                { "MG.Status.Log.Mode", "Modalità: Magia totale={0}, Gestore rifiuti={1}" },
                { "MG.Status.Log.SettingsHeader", "Impostazioni mod correnti" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Cursori Gestore rifiuti (salvati): carico camion={0:N0}% | stoccaggio struttura={1:N0}% | elaborazione struttura={2:N0}% | flotta struttura={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "Esperto (salvato): attivo={0} | richiesta={1:N0} | raccolta={2:N0} | base felicità={3:N0} | passo felicità={4:N0} | tasso accumulo={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Prodotti/Elaborati usa tonnellate al mese.\n" +
                    "- I valori soglia qui sotto usano unità interne di rifiuti, non tonnellate.\n" +
                    "- Per il giocatore, il gioco converte 100 unità = 0.1t e 1.000 unità = 1t.\n" +
                    "- Valutazione servizio rifiuti = fattore di felicità rifiuti della città nel gioco.\n" +
                    "  - 0 = Eccellente\n" +
                    "  - -1 = Serve un piccolo ritocco, o si può ignorare\n" +
                    "  - -2 a -4 = Un po' puzzolente\n" +
                    "  - -5 a -10 = Problema rifiuti\n" +
                    "Cursori soglia:\n" +
                    "  - Soglia raccolta = rifiuti minimi prima che un camion raccolga da un edificio.\n" +
                    "  - Soglia richiesta = rifiuti minimi prima che il gioco crei o mantenga una richiesta di raccolta.\n" +
                    "- Icona avviso = quantità di rifiuti che fa apparire un'icona di avviso sopra un edificio.\n" +
                    "- Limite massimo = quantità massima di rifiuti che un edificio può accumulare.\n" +
                    "- In attesa = richieste attive non assegnate a un camion o a un percorso.\n" +
                    "- Alcune richieste in attesa verranno assegnate più tardi; altre possono anche sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno del servizio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Soglie di gioco (unità interne di rifiuti): raccolta={1:N0}, richiesta={0:N0}, icona avviso={2:N0}, limite massimo={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Soglie: <GarbageParameterData non disponibile>" },
                { "MG.Status.Log.GarbageProcessing", "Rifiuti: {0:N0} t/mese | Elaborazione: {1:N0} t/mese" },
                { "MG.Status.Log.GarbageServiceRating", "Valutazione servizio rifiuti: {0} | grezzo={1:N2} | arrotondato={2:N0}" },
                { "MG.Status.Log.Requests", "Richieste raccolta: in attesa={1:N0}, inviate={2:N0}, totale={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Bersaglio in attesa con più rifiuti: {0:N0} ({1:N1}t) a {2}" },
                { "MG.Status.Log.PendingPeakNone", "Bersaglio in attesa con più rifiuti: nessuno" },
                { "MG.Status.Log.Producers", "Edifici: {0:N0} icone avviso | {1:N0} totale | {2:N0} hanno rifiuti | {3:N0} sopra soglia richiesta " },
                { "MG.Status.Log.ProducerGarbageStats", "Rifiuti edifici (solo non zero): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) a {6}" },
                { "MG.Status.Log.NearWarning75", "Edifici vicini all'icona avviso (almeno {1:N0} unità / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Strutture: {0:N0} totali | {1:N0} camion rifiuti | {2:N0} dump truck ({3:N0} in movimento) | {4:N0} lavoratori" },
                { "MG.Status.Log.Trucks", "Camion rifiuti: {2:N0} in movimento ({3:N0} rientro) | {1:N0} parcheggiati | {4:N0} disattivati | {0:N0} totale" },
                { "MG.Status.Log.FacilitiesHeader", "Riepilogo strutture" },
                { "MG.Status.Log.FacilityLine", "- Struttura {0}: camion rifiuti={1:N0} ({2:N0} in movimento, {3:N0} parcheggiati) | dump truck={4:N0} ({5:N0} in movimento) | lavoratori max={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Eccellente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Serve un piccolo ritocco" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Un po' puzzolente" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema rifiuti" },
            };
        }

        public void Unload()
        {
        }
    }
}
