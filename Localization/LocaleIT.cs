// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Utente avanzato" },
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "Assistenza prioritaria" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "Assistenza per bersagli dei rifiuti molto sovraccarichi (edifici).\n" +
                    "Quando **ATTIVA**, controlla se un bersaglio di richiesta attivo raggiunge **7000+** (**7t**) di rifiuti.\n" +
                    "Obiettivo: riduce le raccolte secondarie extra quando serve, così i camion raggiungono prima i bersagli peggiori.\n" +
                    "È una spinta, non una sostituzione rigida e completa della logica di percorso vanilla.\n" +
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

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applica i valori standard **consigliati** di Trash Boss.\n" +
                    "Non cambia le impostazioni Power User (separate)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Riporta gli slider di Trash Boss ai **valori vanilla**.\n" +
                    "<Non> cambia le impostazioni Power User.\n" +
                    "**Vanilla:**\n" +
                    "- Gli slider percentuali tornano a **100%**.\n" +
                    "- La soglia di richiesta invio torna a **100 unità**.\n" +
                    "- La soglia di raccolta torna a **20 unità**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opzioni Power User" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Impostazioni avanzate facoltative\n" +
                    "<Avviso: NON necessario> per un buon servizio; disponibile per i giocatori che vogliono sperimentare o capire meglio come funzionano i sistemi.\n" +
                    "Quando **OFF**, gli elementi Power User si comportano come il normale gioco **vanilla**.\n" +
                    "Quando **ON**, appaiono gli **slider avanzati**.\n" +
                    "\n" +
                    "<--- Esempi di felicità --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalità a <165>.\n" +
                    " - Clicca <Consigliato> per 550/150 = 1ª penalità a <700>.\n" +
                    " - <Molto morbido> 950/200 = 1ª penalità rifiuti a <1150>.\n" +
                    "Comodità: gli ultimi valori degli slider vengono salvati quando questa opzione è OFF (nel caso tu voglia riattivarla dopo)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Soglia richiesta invio" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Rifiuti dell’edificio necessari prima che una richiesta di invio camion venga creata o mantenuta.**\n" +
                    "Vanilla = **100** unità di rifiuti.\n" +
                    "**100 unità di rifiuti = 0.1t**\n" +
                    "**1,000 unità di rifiuti = 1t**\n" +
                    "Mantieni questo valore uguale o superiore alla soglia di raccolta.\n" +
                    "Di solito aumenta quanti camion vengono usati invece di restare parcheggiati."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Soglia di raccolta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Rifiuti minimi dell’edificio prima che un camion possa raccoglierli.**\n" +
                    "Vanilla = **20** unità di rifiuti.\n" +
                    "Lo slider di raccolta <non può> essere più alto della richiesta invio (DR); viene limitato per prevenire problemi di logica.\n" +
                    "Se un camion viene inviato a un edificio e il valore di raccolta è più alto di DR, a volte il camion potrebbe non riuscire a raccogliere dall’edificio (anche il tasso di accumulo influisce).\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Livello di rifiuti dell’edificio prima che inizi la penalità a salute + felicità.**\n" +
                    "**Vanilla = 100** unità di rifiuti.\n" +
                    "Base più alta = gli edifici possono contenere più rifiuti prima della penalità.\n" +
                    "100 unità di rifiuti = 0.1t\n" +
                    "Panoramica:\n" +
                    "- <Soglia> = punto di attivazione del comportamento del sistema\n" +
                    "- <Base> = punto di partenza della formula di penalità\n" +
                    "- <Passo> = dimensione dell’incremento nella formula, cioè quanto velocemente aumenta la penalità dopo l’inizio"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Passo felicità rifiuti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Rifiuti extra oltre la base che fanno iniziare una penalità di -1.**\n" +
                    "Vanilla = **65** unità di rifiuti.\n" +
                    "Passo più alto = crescita più lenta della penalità.\n" +
                    "Il gioco limita la penalità rifiuti a **-10**.\n" +
                    "La prima penalità vanilla <-1> avviene a **165 rifiuti** (100 base + 65 passo)\n" +
                    "Cambiare le soglie con gli slider di felicità può causare penalità più pesanti del normale."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tasso di accumulo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Scala i valori sorgente dei rifiuti degli edifici supportati.**\n" +
                    "Attenzione: è una leva forte e cambiare il tasso influisce su molte cose.\n" +
                    "È possibile ottenere un buon sistema senza usarlo.\n" +
                    "\n" +
                    "**100% = tasso di accumulo vanilla**.\n" +
                    "**20%** = accumulo molto più lento.\n" +
                    "**200%** = tasso doppio - tantissimi rifiuti.\n" +
                    "Al 20%, tutti i Cims stanno ovviamente compostando, quindi il tasso di accumulo è molto più basso ;)\n" +
                    "\n" +
                    "Nota tecnica: il gioco aggiunge rifiuti gradualmente durante il giorno, non tutti insieme."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Consigliato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Applica i valori Power User **consigliati**.\n" +
                    "Attiva Power User.\n" +
                    "La prima penalità rifiuti inizia a **700** rifiuti (550 base + 150 passo).\n" +
                    "Il tasso di accumulo rifiuti resta a **100%** vanilla se non viene modificato manualmente."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valori di gioco" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Riporta tutti i valori Power User **a vanilla**.\n" +
                    "Disattiva **Power User**.\n"
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Edifici 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Numero di edifici produttori di rifiuti pari o superiori a **7t / 7000** rifiuti.\n" +
                    "Sono edifici molto sovraccarichi; attiva [x] Assistenza prioritaria per priorizzarli meglio.\n" +
                    "Usa il pulsante Stato nel log se vuoi i numeri ID Entity da ispezionare."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rifiuti/mese" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra la quantità attuale di rifiuti della città e il tasso totale di trattamento rifiuti.\n" +
                    "Aumenta il trattamento se i rifiuti prodotti mensilmente sono molto più alti.\n" +
                    "**Prodotti** e **Trattati** usano tonnellate al mese."
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
                    "In vanilla, la soglia richiesta è **100** unità interne di rifiuti.\n" +
                    "Le opzioni Power User possono sovrascrivere soglie di richiesta e raccolta.\n"
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
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Apri la cartella Logs/.. del gioco." },

                // Runtime status strings
                { "MG.Status.NoCity", "Nessuna città ancora caricata." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Eccellente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Serve piccolo aggiustamento ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Un po’ puzzolente ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema rifiuti ({0:N0}) | aggiornato {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} sopra 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t prodotti | {1:N0} t trattati" },
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
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User (salvato): attivo={0} | richiesta={1:N0} | raccolta={2:N0} | base felicità={3:N0} | passo felicità={4:N0} | tasso accumulo={5:N0}%"
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
                { "MG.Status.Log.GarbageProcessing", "Rifiuti: {0:N0} t/mese | Trattamento: {1:N0} t/mese" },
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

                { "MG.Status.Log.CriticalBuildingsHeader", "Edifici critici sopra 7t" },
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
                { "MG.Status.Log.SettingsPriority", "Sistema priorità (salvato): attivo={0} | trigger={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState",
                    "Assistenza prioritaria attiva={0} | intervallo={1:N0} frame | ultimi edifici scansionati={2:N0} | edifici critici={3:N0}"
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
