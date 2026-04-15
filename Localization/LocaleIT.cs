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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Pulizia auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestione diretta" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Esperto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Stato" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Link" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivato [ ✓ ]** mantiene pulita tutta la città.\n\n" +
                    "Quando **Magia totale** è ON:\n" +
                    "- Trash Boss viene forzato su OFF.\n" +
                    "- Gli slider di Trash Boss non vengono applicati (i valori restano salvati per dopo).\n" +
                    "- Alcuni camion possono ancora muoversi a causa del timing della logica vanilla di dispatch."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestisce direttamente i sistemi dei rifiuti; la logica vanilla dei rifiuti continua a funzionare.\n\n" +
                    "- Quando **Trash Boss** è ON [ ✓ ], Magia totale viene forzata su OFF.\n" +
                    "- Gli slider si applicano solo quando Trash Boss è attivo.\n" +
                    "- Sia Magia totale che Trash Boss possono essere **OFF** per tornare ai valori vanilla,\n" +
                    "  continuando comunque a vedere il **report di stato**, che si aggiorna solo entrando nel menu Opzioni (leggero)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "Assistenza priorità" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                    "Aiuto per bersagli dei rifiuti (edifici) gravemente sovraccarichi.\n" +
                    "Quando è **ON**, controlla se un bersaglio di richiesta attivo raggiunge **7000+** (**7t**) di rifiuti.\n" +
                    "Obiettivo: riduce, quando serve, i lavori extra di raccolta laterale così i camion raggiungono prima i bersagli peggiori.\n" +
                    "È una spinta, non una sostituzione rigida e completa della logica vanilla dei percorsi.\n" +
                    "Leggero, nessuna patch Harmony."
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

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocità di lavorazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente le strutture trattano i rifiuti in arrivo.**\n" +
                    "**100% = velocità di lavorazione vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotta struttura" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion ogni struttura può inviare.**\n" +
                    "**100% = numero vanilla** di camion.\n"
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applica i valori standard **consigliati** di Trash Boss.\n" +
                    "Non cambia le impostazioni Esperto (separate)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Riporta gli slider di Trash Boss ai **valori vanilla**.\n" +
                    "Non cambia le impostazioni Esperto.\n" +
                    "**Vanilla:**\n" +
                    "- Gli slider percentuali tornano a **100%**.\n" +
                    "- La Soglia richiesta dispatch torna a **100 unità**.\n" +
                    "- La Soglia raccolta torna a **20 unità**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opzioni Esperto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Impostazioni avanzate opzionali\n" +
                    "<Avviso: NON necessarie> per un buon servizio; pensate per i giocatori che vogliono sperimentare o capire meglio come funzionano i sistemi.\n" +
                    "Quando è **OFF**, gli elementi Esperto si comportano come il normale gioco **vanilla**.\n" +
                    "Quando è **ON**, compaiono gli **slider avanzati**.\n\n" +
                    "<--- Esempi felicità --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalità a <165>.\n" +
                    " - Clicca <Consigliato> per 550/150 = 1ª penalità a <700>.\n" +
                    " - <Molto morbido> 950/200 = 1ª penalità rifiuti a <1150>.\n" +
                    "Comodità: gli ultimi valori degli slider restano salvati quando questa opzione è OFF (nel caso venga riattivata più tardi)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Soglia richiesta dispatch" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantità di rifiuti richiesta in un edificio prima che venga creata o mantenuta una richiesta di invio camion.**\n" +
                    "Vanilla = **100** unità rifiuti.\n" +
                    "**100 unità rifiuti = 0.1t**\n" +
                    "**1.000 unità rifiuti = 1t**\n" +
                    "Mantieni questo valore uguale o superiore alla Soglia raccolta.\n" +
                    "Di solito questo aumenta quanti camion vengono usati invece di restare parcheggiati."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Soglia raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantità minima di rifiuti in un edificio prima che un camion possa raccoglierli.**\n" +
                    "Vanilla = **20** unità rifiuti.\n" +
                    "Lo slider raccolta <non può> essere più alto della Richiesta dispatch (DR); viene limitato per evitare problemi di logica.\n" +
                    "Se un camion viene inviato a un edificio e il valore di raccolta è più alto della DR, a volte il camion potrebbe non riuscire a raccogliere da quell'edificio (influisce anche il tasso di accumulo).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Livello di rifiuti di un edificio prima che inizi a causare penalità a salute + felicità.**\n" +
                    "**Vanilla = 100** unità rifiuti.\n" +
                    "Base più alta = gli edifici possono contenere più rifiuti prima che inizi la penalità.\n" +
                    "100 unità rifiuti = 0.1t\n" +
                    "Panoramica:\n" +
                    "- <Soglia> = punto di attivazione del comportamento del sistema\n" +
                    "- <Base> = punto di partenza della formula della penalità\n" +
                    "- <Step> = dimensione dell'incremento nella formula, cioè quanto velocemente cresce la penalità dopo l'inizio"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Step felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Rifiuti extra sopra la base che fanno partire una penalità di -1.**\n" +
                    "Vanilla = **65** unità rifiuti.\n" +
                    "Step più alto = crescita più lenta della penalità.\n" +
                    "Il gioco limita la penalità rifiuti a **-10**.\n" +
                    "La prima <penalità -1> vanilla avviene a **165 rifiuti** (100 base + 65 step)\n" +
                    "Cambiare le soglie senza regolare gli slider della felicità può portare a penalità più pesanti del normale."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tasso di accumulo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Scala i valori di origine dei rifiuti degli edifici supportati.**\n" +
                    "Attenzione: è una leva forte e cambiare questo tasso influenza molte cose.\n" +
                    "È possibile avere un buon sistema anche senza usarlo.\n\n" +
                    "**100% = tasso di accumulo vanilla**.\n" +
                    "**20%** = accumulo molto più lento.\n" +
                    "**200%** = tasso doppio - tantissimi rifiuti.\n" +
                    "Al 20%, chiaramente tutti i cims stanno facendo compost, quindi il tasso di accumulo dei rifiuti è molto più basso ;)\n\n" +
                    "Nota tecnica: il gioco aggiunge i rifiuti gradualmente durante la giornata, non tutti insieme."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Applica i valori **consigliati** Esperto.\n" +
                    "Attiva Esperto.\n" +
                    "La prima penalità rifiuti inizia a **700** rifiuti (550 base + 150 step).\n" +
                    "Il Tasso di accumulo rifiuti resta a **100%** vanilla a meno di modifica manuale."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Riporta tutti i valori Esperto **a vanilla**.\n" +
                    "Imposta **Esperto** su OFF.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome visualizzato di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versione attuale della mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Apre la pagina Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Apre l'invito Discord nel browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato pulizia auto>\n" +
                    "  * Magia totale ON = **[ ✓ ]**\n" +
                    "  * I rifiuti vengono rimossi automaticamente - fatto.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato gestione diretta>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Imposta gli slider come desiderato.\n" +
                    "  * Opzionale: attiva gli slider avanzati (non richiesto).\n" +
                    "  * Stessi rifiuti del gioco; migliori camion/strutture gestiti direttamente.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato report / vanilla>\n" +
                    "  * Magia totale = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Solo report di stato.\n" +
                    "  * Il gioco vanilla dei rifiuti resta invariato."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Valutazione servizio rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Semplice valutazione della felicità rifiuti dal gioco.\n" +
                    "**0 = Eccellente**\n" +
                    "**-1 **= Serve un piccolo ritocco. Il gioco passa spesso da 0 a -1 e si può ignorare (numero arrotondato).\n" +
                    "**-2 a -4** = Leggermente puzzolente\n" +
                    "**-5 a -10** = Problema rifiuti\n" +
                    "**Controlli indiretti:** usa gli <slider rifiuti> per migliorarlo nel tempo riducendo l'accumulo dei rifiuti.\n" +
                    "**Controlli diretti:** Base felicità rifiuti + Step felicità rifiuti cambiano <ciò che i cims tollerano> prima di diventare infelici.\n" +
                    "**Tasso di accumulo rifiuti**: cambia quanto velocemente gli edifici supportati producono rifiuti. Usare con cautela perché il bilanciamento è importante. La maggior parte dei giocatori non deve mai toccarlo.\n" +
                    "<Ora aggiornamento = ultimo refresh.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Edifici 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Numero di edifici che producono rifiuti con **7t / 7000** rifiuti o più.\n" +
                    "Questi edifici sono gravemente sovraccarichi; abilita [x] Sistema priorità per dare loro priorità migliore.\n" +
                    "Usa il pulsante Stato su log se servono i numeri ID entità per ispezione."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rifiuti/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la quantità attuale di rifiuti in tutta la città e il tasso totale di lavorazione dei rifiuti.\n" +
                    "Aumenta la lavorazione se i rifiuti prodotti al mese sono molto più alti.\n" +
                    "**Prodotti** e **Lavorati** usano tonnellate al mese."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Richieste raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**In attesa** = richieste di raccolta attive non ancora assegnate a un camion o a un percorso.\n" +
                    "**Inviate** = richieste di raccolta attive già assegnate.\n" +
                    "**Totale** = conta le attuali entità richiesta **attive** (nella pipeline dei rifiuti).\n\n" +
                    "Nota tecnica: è diverso da <Sopra soglia richiesta>. Qui si contano le <richieste>, non gli edifici.\n" +
                    "Alcune richieste in attesa verranno assegnate più tardi; altre potranno anche sparire più tardi se la rivalidazione vanilla decide che il bersaglio non ha più bisogno di servizio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edifici" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ha rifiuti** = edifici che attualmente contengono rifiuti.\n" +
                    "**Totale** = tutti gli edifici che producono rifiuti nella città.\n" +
                    "**Sopra soglia richiesta** = numero attuale di **edifici** con abbastanza rifiuti da creare una richiesta di raccolta.\n" +
                    "In vanilla, la soglia richiesta è **100** unità interne di rifiuti.\n" +
                    "Le Opzioni Esperto possono sostituire le soglie di richiesta e raccolta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Strutture" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Riepilogo delle strutture rifiuti conteggiate.\n" +
                    "**Strutture** = edifici rifiuti conteggiati.\n" +
                    "**Camion rifiuti** = normali camion di raccolta. Nelle strutture di rifiuti industriali raccolgono rifiuti industriali invece dei rifiuti normali.\n" +
                    "**Dump trucks** = trasferimenti di rifiuti tra strutture.\n" +
                    "**Lavoratori max** = capacità totale lavoratori in quelle stesse strutture."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camion rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**In movimento** = camion attualmente in giro per la città.\n" +
                    "**Rientro** = sottoinsieme dei camion in movimento contrassegnati per tornare alla propria struttura.\n" +
                    "**Parcheggiati** = camion parcheggiati presso una struttura.\n" +
                    "**Totale** = numero di tutti i camion rifiuti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Stato dettagliato su log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Invia un report rifiuti più dettagliato in **Logs/MagicGarbage.log**.\n" +
                    "Include statistiche organizzate sui rifiuti della città"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apre la cartella del gioco Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città caricata al momento." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Eccellente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Serve un piccolo ritocco ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Leggermente puzzolente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema rifiuti ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} oltre 7t" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotte | {1:N0} t lavorate" },
                { "MG.Status.Row.Requests", "{1:N0} in attesa | {2:N0} inviate | {0:N0} totale" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ha rifiuti | {2:N0} sopra soglia richiesta" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} strutture | {1:N0}/{2:N0} camion rifiuti/dump trucks | {3:N0} lavoratori" },
                { "MG.Status.Row.Trucks", "{1:N0} in movimento ({3:N0} in rientro) | {2:N0} parcheggiati | {0:N0} totale" },
                { "MG.Status.Row.FacilitiesNone", "Ancora nessun dato strutture." },

                // Log strings
                { "MG.Status.Log.Title", "Stato rifiuti ({0})" },
                { "MG.Status.Log.City", "Città: {0}" },
                { "MG.Status.Log.Mode", "Modalità: Magia totale={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Impostazioni attuali mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Slider Trash Boss (salvati): carico camion={0:N0}% | stoccaggio struttura={1:N0}% | lavorazione struttura={2:N0}% | flotta struttura={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "Esperto (salvato): abilitato={0} | richiesta={1:N0} | raccolta={2:N0} | base felicità={3:N0} | step felicità={4:N0} | tasso accumulo={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Prodotti/Lavorati usa tonnellate al mese.\n" +
                    "- I valori soglia sotto usano unità interne rifiuti, non tonnellate.\n" +
                    "- Per il giocatore, il gioco converte 100 unità = 0.1t e 1.000 unità = 1t.\n" +
                    "- Valutazione servizio rifiuti = fattore felicità rifiuti cittadino del gioco.\n" +
                    "  - 0 = Eccellente\n" +
                    "  - -1 = Serve un piccolo ritocco, o ignorare\n" +
                    "  - -2 a -4 = Leggermente puzzolente\n" +
                    "  - -5 a -10 = Problema rifiuti\n" +
                    "Slider soglia:\n" +
                    "  - Soglia raccolta = rifiuti minimi prima che un camion raccolga da un edificio.\n" +
                    "  - Soglia richiesta = rifiuti minimi prima che il gioco crei o mantenga una richiesta di raccolta.\n" +
                    "- Icona avviso = quantità di rifiuti che fa apparire un'icona di avviso sopra un edificio.\n" +
                    "- Limite rigido = quantità massima di rifiuti che un edificio può accumulare.\n" +
                    "- In attesa = richieste attive non assegnate al momento a un camion o a un percorso.\n" +
                    "- Alcune richieste in attesa verranno assegnate più tardi; altre potranno anche sparire più tardi se la rivalidazione vanilla decide che il bersaglio non ha più bisogno di servizio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Soglie gioco (unità interne rifiuti): raccolta={1:N0}, richiesta={0:N0}, icona avviso={2:N0}, limite rigido={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Soglie: <GarbageParameterData non disponibile>" },
                { "MG.Status.Log.GarbageProcessing", "Rifiuti: {0:N0} t/mese | Lavorazione: {1:N0} t/mese" },
                { "MG.Status.Log.GarbageServiceRating", "Valutazione servizio rifiuti: {0} | grezzo={1:N2} | arrotondato={2:N0}" },
                { "MG.Status.Log.Requests", "Richieste raccolta: in attesa={1:N0}, inviate={2:N0}, totale={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Bersaglio in attesa più alto: {0:N0} ({1:N1}t) a {2}" },
                { "MG.Status.Log.PendingPeakNone", "Bersaglio in attesa più alto: nessuno" },
                { "MG.Status.Log.Producers", "Edifici: {0:N0} icone avviso | {1:N0} totale | {2:N0} ha rifiuti | {3:N0} sopra soglia richiesta " },
                { "MG.Status.Log.ProducerGarbageStats", "Rifiuti edifici (solo > 0): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) a {6}" },
                { "MG.Status.Log.NearWarning75", "Edifici vicini all'icona avviso (almeno {1:N0} unità / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Strutture: {0:N0} totale | {1:N0} camion rifiuti | {2:N0} dump trucks ({3:N0} in movimento) | {4:N0} lavoratori" },
                { "MG.Status.Log.Trucks", "Camion rifiuti: {2:N0} in movimento ({3:N0} in rientro) | {1:N0} parcheggiati | {4:N0} disabilitati | {0:N0} totale" },
                { "MG.Status.Log.FacilitiesHeader", "Riepilogo strutture" },
                { "MG.Status.Log.FacilityLine", "- Struttura {0}: camion rifiuti={1:N0} ({2:N0} in movimento, {3:N0} parcheggiati) | dump trucks={4:N0} ({5:N0} in movimento) | lavoratori max={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Eccellente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Serve un piccolo ritocco" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Leggermente puzzolente" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema rifiuti" },

                { "MG.Status.Log.ThresholdsHeader", "Soglie + servizio" },
                { "MG.Status.Log.RequestsHeader", "Richieste" },
                { "MG.Status.Log.BuildingsHeader", "Edifici" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Edifici critici oltre 7t" },

                { "MG.Status.Log.TransferProbeHeader", "Sonda trasferimento rifiuti" },
                { "MG.Status.Log.TransferProbeNone", "Nessuna struttura di trasferimento/stoccaggio rifiuti trovata." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stoccato={1,7:N0} ({2,4:N1}t) | cap={3,7:N0} ({4,4:N1}t) | export={5,7:N0} ({6,4:N1}t) | basso={7,7:N0} ({8,4:N1}t) | min={9,7:N0} ({10,4:N1}t) | out/in={11,6:N0}/{12,6:N0} | attivo={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "Camion" },

                { "MG.Status.Log.SettingsPriority",
                    "Sistema priorità (salvato): abilitato={0} | trigger={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "Assistenza priorità" },
                { "MG.Status.Log.PriorityState",
                    "Assistenza priorità live={0} | intervallo={1:N0} frame | ultime richieste analizzate={2:N0} | bersagli critici di richiesta attivi={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "Passaggi priorità: alzati={0:N0} | normali={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "Bersaglio critico attivo più alto: nessuno" },
                { "MG.Status.Log.PriorityPeak",
                    "Bersaglio critico attivo più alto: {0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "in attesa" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "inviata" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Tempo ultima scansione assistenza priorità={0:N3} ms" },
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
