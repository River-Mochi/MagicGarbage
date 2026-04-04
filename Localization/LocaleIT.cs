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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Self Manage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Power User" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia Totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Attivo [ ✓ ]** tiene pulita tutta la città.\n\n" +
                    "Quando **Magia Totale** è ON:\n" +
                    "- Gestione Rifiuti viene forzata su OFF.\n" +
                    "- Gli slider di Gestione Rifiuti non vengono applicati (i valori restano salvati per dopo).\n" +
                    "- Alcuni camion possono comunque muoversi per via del timing di dispatch vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Gestione Rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gestisce direttamente il sistema rifiuti; la logica vanilla continua a funzionare.\n\n" +
                    "- Quando **Gestione Rifiuti è ON [ ✓ ]**, Magia Totale viene forzata su OFF.\n" +
                    "- Gli slider si applicano solo quando Gestione Rifiuti è attiva.\n" +
                    "- Sia Magia Totale che Gestione Rifiuti possono essere **OFF** se serve solo il **report di stato**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacità camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanti rifiuti può trasportare ogni camion.**\n" +
                    "**100% = valore normale** del gioco.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stoccaggio impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanti rifiuti può immagazzinare un impianto.**\n" +
                    "**100% = stoccaggio vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocità processo impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quanto velocemente gli impianti trattano i rifiuti in arrivo.**\n" +
                    "**100% = velocità vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotta impianto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quanti camion può inviare ogni impianto.**\n" +
                    "**100% = numero vanilla** di camion.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opzioni avanzate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**Regolazione avanzata opzionale per soglie + felicità legata ai rifiuti.**\n" +
                    "Quando è **OFF**, soglie di raccolta/richiesta e felicità rifiuti **restano vanilla**.\n" +
                    "Quando è **ON**, compaiono gli **slider avanzati**.\n\n" +
                    "<--- Esempi felicità rifiuti --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalità a <165>.\n" +
                    " - <Consigliato> 550/150 = 1ª penalità a <700>.\n" +
                    " - <Molto soft> 950/200 = 1ª penalità rifiuti a <1150>.\n" +
                    "Comodità: gli ultimi valori degli slider restano salvati quando questa opzione è OFF."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Soglia richiesta dispatch" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Rifiuti necessari in un edificio prima che venga creata o mantenuta una richiesta di invio camion.**\n" +
                    "Vanilla = **100** unità rifiuti.\n" +
                    "**100 unità rifiuti = 0.1t**\n" +
                    "**1.000 unità rifiuti = 1t**\n" +
                    "Tieni questo valore uguale o superiore alla soglia di raccolta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Soglia raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Rifiuti minimi in un edificio prima che un camion possa raccoglierli.**\n" +
                    "Vanilla = **20** unità rifiuti.\n" +
                    "La soglia di raccolta non può mai essere superiore alla soglia di richiesta dispatch.\n" +
                    "Tieni la soglia di richiesta dispatch uguale o superiore al valore valido di raccolta per evitare problemi di logica;" +
                    " se un camion viene inviato a un edificio e il valore di raccolta è più alto, potrebbe non riuscire a raccogliere (conta anche il ritmo di accumulo).\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applicati i valori standard **consigliati** di Gestione Rifiuti.\n" +
                    "Non cambia le impostazioni delle Opzioni avanzate."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Riporta gli slider di Gestione Rifiuti ai **valori vanilla**.\n" +
                    "Non cambia <not> le impostazioni delle Opzioni avanzate.\n" +
                    "**Vanilla:**\n" +
                    "- Gli slider percentuali tornano a **100%**.\n" +
                    "- La soglia richiesta dispatch torna a **100 units**.\n" +
                    "- La soglia raccolta torna a **20 units**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Livello di rifiuti in un edificio prima che inizi la penalità a salute + felicità.**\n" +
                    "**Vanilla = 100** unità rifiuti.\n" +
                    "Base più alta = gli edifici possono accumulare più rifiuti prima della penalità.\n" +
                    "100 unità rifiuti = 0.1t\n" +
                    "Panoramica:\n" +
                    "- <Soglia> = punto di attivazione del comportamento di sistema\n" +
                    "- <Base> = punto di partenza della formula penalità\n" +
                    "- <Step> = grandezza dell’incremento nella formula, cioè quanto velocemente cresce la penalità"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Step felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Rifiuti extra sopra la base che fanno iniziare una penalità di -1.**\n" +
                    "Vanilla = **65** unità rifiuti.\n" +
                    "Step più alto = crescita più lenta della penalità.\n" +
                    "Il gioco limita la penalità rifiuti a **-10**.\n" +
                    "La prima penalità vanilla <-1 penalty> arriva a **165 rifiuti** (100 baseline + 65 step)\n" +
                    "Bilancia le modifiche alle soglie con gli slider della felicità oppure avrai penalità più pesanti del normale."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Applica i valori **consigliati** delle Opzioni avanzate.\n" +
                    "Attiva le Opzioni avanzate.\n" +
                    "La prima penalità rifiuti parte da **700** rifiuti (550 baseline + 150 step)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Riporta i valori delle Opzioni avanzate a **vanilla**.\n" +
                    "Mette **Opzioni avanzate su OFF**."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome visualizzato di questo mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versione attuale del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Apre la pagina Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Apre l’invito Discord nel browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stato pulizia auto>\n" +
                    "  * Magia Totale ON  = **[ ✓ ]**\n" +
                    "  * I rifiuti vengono rimossi automaticamente - fatto.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato gestione manuale>\n" +
                    "  * Gestione Rifiuti = **[ ✓ ]**\n" +
                    "  * Regola gli slider come vuoi.\n" +
                    "  * Facoltativo: attiva Opzioni avanzate per soglie + felicità rifiuti.\n" +
                    "  * Stesso sistema rifiuti del gioco; camion/impianti gestiti meglio.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stato stato / vanilla>\n" +
                    "  * Magia Totale = OFF\n" +
                    "  * Gestione Rifiuti = OFF\n" +
                    "  * Solo report di stato.\n" +
                    "  * Il sistema rifiuti vanilla resta invariato."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rifiuti/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la quantità attuale di rifiuti in tutta la città e il tasso totale di trattamento.\n" +
                    "Aumenta il trattamento se i rifiuti prodotti al mese sono molto più alti.\n" +
                    "**Prodotti** e **Trattati** usano tonnellate al mese.\n" +
                    "<Ora aggiornamento = ultimo refresh.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Richieste raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**In attesa** = richieste attive di raccolta non ancora assegnate a un camion o percorso.\n" +
                    "**Assegnate** = richieste attive di raccolta già assegnate.\n" +
                    "**Totale** = conta le entità richiesta **attive** attuali (nella pipeline rifiuti).\n\n" +
                    "Nota tecnica: è diverso da <Sopra la soglia richiesta>. Qui si contano le <richieste>, non gli edifici.\n" +
                    "Alcune richieste in attesa verranno assegnate più tardi; altre possono sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno del servizio."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edifici" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ha rifiuti** = edifici che al momento hanno rifiuti.\n" +
                    "**Totale** = tutti gli edifici che producono rifiuti nella città.\n" +
                    "**Sopra la soglia richiesta** = numero attuale di **edifici** con abbastanza rifiuti da creare una richiesta di raccolta.\n" +
                    "In vanilla, la soglia richiesta è **100** unità interne di rifiuti.\n" +
                    "Le Opzioni avanzate possono sovrascrivere soglia richiesta e soglia raccolta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Impianti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Riepilogo degli impianti rifiuti conteggiati.\n" +
                    "**Impianti** = edifici rifiuti conteggiati.\n" +
                    "**Camioni rifiuti** = normali camion di raccolta. Negli impianti di rifiuti industriali raccolgono rifiuti industriali invece dei rifiuti normali.\n" +
                    "**Dump trucks** = trasferimenti di rifiuti tra impianti.\n" +
                    "**Lavoratori max** = capacità totale lavoratori degli stessi impianti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camioni" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**In movimento** = camion attualmente in giro per la città.\n" +
                    "**Rientro** = sottoinsieme dei camion in movimento che stanno tornando all’impianto.\n" +
                    "**Parcheggiati** = camion parcheggiati in un impianto.\n" +
                    "**Totale** = numero di tutti i camion rifiuti."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Stato dettagliato nel log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Invia un report rifiuti più dettagliato in **Logs/MagicGarbage.log**.\n" +
                    "Include una breve legenda, valori di riferimento vanilla e molte altre statistiche reali della città."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Apre la cartella Logs/.. del gioco."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città caricata." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotte | {1:N0} t trattate | agg. {2}" },
                { "MG.Status.Row.Requests", "{1:N0} in attesa | {2:N0} assegnate | {0:N0} totale" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} hanno rifiuti | {2:N0} sopra soglia richiesta" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} impianti | {1:N0} camion rifiuti | {2:N0} dump trucks | {3:N0} lavoratori max" },
                { "MG.Status.Row.Trucks", "{1:N0} in movimento ({3:N0} rientro) | {2:N0} parcheggiati | {0:N0} totale" },
                { "MG.Status.Row.FacilitiesNone", "Nessun dato impianto ancora." },

                // Log strings
                { "MG.Status.Log.Title", "Stato rifiuti ({0})" },
                { "MG.Status.Log.City", "Città: {0}" },
                { "MG.Status.Log.Mode", "Modalità: Magia Totale={0}, Gestione Rifiuti={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Prodotti/Trattati usa tonnellate al mese.\n" +
                    "- Le soglie sotto usano unità interne di rifiuti, non tonnellate.\n" +
                    "- Per il giocatore, il gioco converte 100 unità = 0.1t e 1.000 unità = 1t.\n" +
                    "Slider soglie:\n" +
                    "  - Soglia di raccolta = rifiuti minimi prima che un camion raccolga da un edificio.\n" +
                    "  - Soglia di richiesta = rifiuti minimi prima che il gioco crei o mantenga una richiesta di raccolta.\n" +
                    "- Icona di avviso = quantità di rifiuti che fa apparire un’icona di avviso sopra un edificio.\n" +
                    "- Limite massimo = quantità massima di rifiuti che un edificio può accumulare.\n" +
                    "- In attesa = richieste attive non ancora assegnate a un camion o percorso.\n" +
                    "- Alcune richieste in attesa verranno assegnate più tardi; altre possono sparire se la rivalidazione vanilla decide che il bersaglio non ha più bisogno del servizio.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Soglie del gioco (unità interne rifiuti): raccolta={1:N0}, richiesta={0:N0}, icona di avviso={2:N0}, limite massimo={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Soglie: <GarbageParameterData non disponibile>" },
                { "MG.Status.Log.GarbageProcessing", "Rifiuti: {0:N0} t/mese | Trattamento: {1:N0} t/mese" },
                { "MG.Status.Log.Requests", "Richieste raccolta: in attesa={1:N0}, assegnate={2:N0}, totale={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Bersaglio in attesa più alto: {0:N0} ({1:N1}t) presso {2}" },
                { "MG.Status.Log.Producers", "Edifici: {0:N0} totale | {1:N0} hanno rifiuti | {2:N0} sopra soglia richiesta | {3:N0} livello avviso" },
                { "MG.Status.Log.ProducerGarbageStats", "Rifiuti edifici (solo non zero): media={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | massimo={4:N0} ({5:N1}t) presso {6}" },
                { "MG.Status.Log.NearWarning75", "Edifici vicini all’avviso (almeno {1:N0} unità / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Impianti: {0:N0} totale | {1:N0} camion rifiuti | {2:N0} dump trucks ({3:N0} in movimento) | {4:N0} lavoratori" },
                { "MG.Status.Log.Trucks", "Camioni rifiuti: {2:N0} in movimento ({3:N0} rientro) | {1:N0} parcheggiati | {4:N0} disabilitati | {0:N0} totale" },
                { "MG.Status.Log.FacilitiesHeader", "Riepilogo impianti" },
                { "MG.Status.Log.FacilityLine", "- Impianto {0}: rifiuti={1:N0} ({2:N0} in movimento, {3:N0} parcheggiati) | dump={4:N0} ({5:N0} in movimento) | lavoratori max={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
