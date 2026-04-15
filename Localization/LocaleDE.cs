// File: Localization/LocaleDE.cs
// German (de-DE)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto-Reinigung" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Direkte Steuerung" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Profi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NUTZUNG" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Totale Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** hält die ganze Stadt sauber.\n\n" +
                    "Während **Totale Magie** auf ON steht:\n" +
                    "- Trash Boss wird auf OFF erzwungen.\n" +
                    "- Trash-Boss-Schieberegler werden nicht angewendet (Werte werden für später gespeichert).\n" +
                    "- Einige Lkw können sich wegen des Timings der Vanilla-Dispatch-Logik trotzdem noch bewegen."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Steuert Müllsysteme direkt; die Vanilla-Mülllogik bleibt aktiv.\n\n" +
                    "- Wenn **Trash Boss** auf ON [ ✓ ] steht, wird Totale Magie auf OFF erzwungen.\n" +
                    "- Schieberegler wirken nur, wenn Trash Boss aktiviert ist.\n" +
                    "- Totale Magie + Trash Boss können beide auf **OFF** stehen, um Vanilla-Einstellungen zu erhalten,\n" +
                    "  und der **Statusbericht** bleibt weiterhin sichtbar und aktualisiert sich nur beim Öffnen des Optionsmenüs (leichtgewichtig)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "Prioritätshilfe" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                    "Hilfe für stark überlastete Müllziele (Gebäude).\n" +
                    "Wenn **ON**, wird geprüft, ob ein aktives Anforderungsziel **7000+** (**7t**) Müll erreicht.\n" +
                    "Ziel: reduziert bei Bedarf zusätzliche Nebenabholungen, damit Lkw problematische Ziele schneller erreichen.\n" +
                    "Das ist ein Anstoß, keine harte, vollständige Überschreibung der Vanilla-Routenlogik.\n" +
                    "Leichtgewichtig, ohne Harmony-Patch."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Lkw-Ladekapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder Lkw transportieren kann.**\n" +
                    "**100% = normaler** Spielstandard (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Anlagenlagerung" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann.**\n" +
                    "**100% = Vanilla**-Lagerung.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Verarbeitungsgeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "**100% = Vanilla**-Verarbeitungsgeschwindigkeit.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Anlagenflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele Lkw jede Anlage entsenden kann.**\n" +
                    "**100% = Vanilla**-Anzahl an Lkw.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**Empfohlene** Standardwerte für Trash Boss anwenden.\n" +
                    "Ändert Profi-Einstellungen nicht (separat)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Setzt die Trash-Boss-Schieberegler zurück auf **Vanilla-Werte**.\n" +
                    "Ändert Profi-Einstellungen <nicht>.\n" +
                    "**Vanilla:**\n" +
                    "- Prozent-Schieberegler gehen zurück auf **100%**.\n" +
                    "- Der Dispatch-Anforderungsschwellenwert geht zurück auf **100 Einheiten**.\n" +
                    "- Der Abholschwellenwert geht zurück auf **20 Einheiten**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Profi-Optionen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Optionale erweiterte Einstellungen\n" +
                    "<Warnung: NICHT nötig> für guten Service; gedacht für Spieler, die experimentieren oder besser verstehen möchten, wie das System funktioniert.\n" +
                    "Wenn **OFF**, verhalten sich Profi-Elemente wie im normalen **Vanilla**-Spiel.\n" +
                    "Wenn **ON**, werden die erweiterten **Schieberegler sichtbar**.\n\n" +
                    "<--- Zufriedenheitsbeispiele --->\n" +
                    " - <Vanilla> 100/65 = 1. Malus bei <165>.\n" +
                    " - Klick auf <Empfohlen> für 550/150 = 1. Malus bei <700>.\n" +
                    " - <Sehr weich> 950/200 = 1. Müllmalus bei <1150>.\n" +
                    "Praktisch: Die letzten Schiebereglerwerte bleiben gespeichert, wenn diese Option auf OFF steht (falls später wieder aktiviert wird)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch-Anforderungsschwellenwert" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Gebäudemüllmenge, bevor eine Lkw-Dispatch-Anforderung erstellt oder beibehalten wird.**\n" +
                    "Vanilla = **100** Mülleinheiten.\n" +
                    "**100 Mülleinheiten = 0.1t**\n" +
                    "**1.000 Mülleinheiten = 1t**\n" +
                    "Diesen Wert auf oder über dem Abholschwellenwert halten.\n" +
                    "Das erhöht meist die Zahl der genutzten statt geparkten Lkw."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Abholschwellenwert" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimale Gebäudemüllmenge, bevor ein Lkw dort sammeln kann.**\n" +
                    "Vanilla = **20** Mülleinheiten.\n" +
                    "Der Abholregler <kann nicht> höher sein als die Dispatch-Anforderung (DR); er wird begrenzt, um Logikfehler zu verhindern.\n" +
                    "Wird ein Lkw zu einem Gebäude geschickt und der Abholwert ist höher als DR, kann der Lkw dort manchmal nichts einsammeln (die Ansammlungsrate wirkt ebenfalls mit).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Müll-Zufriedenheitsbasis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Gebäudemüllstand, bevor Gesundheits- + Zufriedenheitsmalus beginnt.**\n" +
                    "**Vanilla = 100** Mülleinheiten.\n" +
                    "Höhere Basis = Gebäude können mehr Müll halten, bevor der Malus beginnt.\n" +
                    "100 Mülleinheiten = 0.1t\n" +
                    "Überblick:\n" +
                    "- <Schwellenwert> = Auslösepunkt für Systemverhalten\n" +
                    "- <Basis> = Startpunkt der Malusformel\n" +
                    "- <Schritt> = Inkrementgröße in der Formel, also wie schnell der Malus nach Beginn ansteigt"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Müll-Zufriedenheitsschritt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Zusätzlicher Müll über der Basis, der einen -1-Malus auslöst.**\n" +
                    "Vanilla = **65** Mülleinheiten.\n" +
                    "Höherer Schritt = langsameres Anwachsen des Malus.\n" +
                    "Das Spiel begrenzt den Müllmalus auf **-10**.\n" +
                    "Der erste Vanilla-< -1-Malus > tritt bei **165 Müll** auf (100 Basis + 65 Schritt)\n" +
                    "Werden Schwellenwerte geändert, ohne die Zufriedenheitsschieberegler anzupassen, können stärkere als normale Mali entstehen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Ansammlungsrate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Skaliert unterstützte Müllquellwerte von Gebäuden.**\n" +
                    "Vorsicht: Das ist ein starker Hebel, und Änderungen an der Rate beeinflussen viele Dinge.\n" +
                    "Ein gutes System ist auch ohne diese Einstellung möglich.\n\n" +
                    "**100% = Vanilla**-Ansammlungsrate.\n" +
                    "**20%** = viel langsamerer Aufbau.\n" +
                    "**200%** = doppelte Rate - sehr viel Müll.\n" +
                    "Bei 20% kompostieren offensichtlich alle Cims, daher eine viel niedrigere Müllansammlungsrate ;)\n\n" +
                    "Technischer Hinweis: Das Spiel fügt Müll schrittweise über den Tag hinzu, nicht alles auf einmal."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "**Empfohlene** Profi-Werte anwenden.\n" +
                    "Schaltet Profi auf ON.\n" +
                    "Der erste Müllmalus beginnt bei **700** Müll (550 Basis + 150 Schritt).\n" +
                    "Die Müll-Ansammlungsrate bleibt auf **100%** Vanilla, sofern nicht manuell geändert."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Setzt alle Profi-Werte **zurück auf Vanilla**.\n" +
                    "Schaltet **Profi** auf OFF.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktuelle Mod-Version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Öffnet die Paradox-Mods-Seite." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Öffnet die Discord-Einladung im Browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Auto-Reinigungszustand>\n" +
                    "  * Totale Magie ON = **[ ✓ ]**\n" +
                    "  * Müll wird automatisch entfernt - fertig.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Direkter Steuerungszustand>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Schieberegler wie gewünscht einstellen.\n" +
                    "  * Optional: für erweiterte Schieberegler einschalten (nicht erforderlich).\n" +
                    "  * Derselbe Spielmüll; besser selbst verwaltete Lkw/Anlagen.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Status- / Vanilla-Zustand>\n" +
                    "  * Totale Magie = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Nur Statusbericht.\n" +
                    "  * Das Vanilla-Müllspiel bleibt unverändert."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Nutzung" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Müll-Servicebewertung" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Einfache Müll-Zufriedenheitsbewertung aus dem Spiel.\n" +
                    "**0 = Exzellent**\n" +
                    "**-1 **= Kleine Anpassung nötig. Das Spiel pendelt oft zwischen 0 und -1; das kann ignoriert werden (Zahl ist gerundet).\n" +
                    "**-2 bis -4** = Leicht müffelig\n" +
                    "**-5 bis -10** = Müllproblem\n" +
                    "**Indirekte Stellschrauben:** Mit <Müll-Schiebereglern> lässt sich dies mit der Zeit verbessern, indem der Müllaufbau reduziert wird.\n" +
                    "**Direkte Stellschrauben:** Müll-Zufriedenheitsbasis + Müll-Zufriedenheitsschritt ändern <was Cims tolerieren>, bevor sie unzufrieden werden.\n" +
                    "**Müll-Ansammlungsrate**: ändert, wie schnell unterstützte Gebäude Müll produzieren. Vorsichtig einsetzen, da Balance wichtig ist. Die meisten Spieler müssen das nie anpassen.\n" +
                    "<Aktualisierungszeit = zuletzt aktualisiert.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+-Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Anzahl der müllproduzierenden Gebäude mit **7t / 7000** Müll oder mehr.\n" +
                    "Das sind stark überlastete Gebäude; [x] Prioritätssystem aktivieren, um sie besser zu priorisieren.\n" +
                    "Den Status-zu-Log-Button verwenden, wenn die Entitäts-ID-Nummern zur Prüfung benötigt werden."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Müll/Monat" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Zeigt die aktuelle stadtweite Müllmenge und die gesamte Müllverarbeitungsrate.\n" +
                    "Verarbeitung erhöhen, wenn der monatlich produzierte Müll deutlich höher ist.\n" +
                    "**Produziert** und **Verarbeitet** verwenden Tonnen pro Monat."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Sammelanfragen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Ausstehend** = aktive Sammelanfragen, die aktuell keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "**Entsandt** = aktive Sammelanfragen, die bereits zugewiesen sind.\n" +
                    "**Gesamt** = zählt die aktuell **aktive** Anfrage-Entität (in der Müll-Pipeline).\n\n" +
                    "Technischer Hinweis: Das ist etwas anderes als <Über dem Anforderungsschwellenwert>. Hier werden <Anfragen> gezählt, nicht Gebäude.\n" +
                    "Einige ausstehende Anfragen werden später zugewiesen; andere können später auch wieder verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr braucht."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Hat Müll** = Gebäude, die aktuell irgendeine Menge Müll enthalten.\n" +
                    "**Gesamt** = alle müllproduzierenden Gebäude der Stadt.\n" +
                    "**Über dem Anforderungsschwellenwert** = aktuelle Anzahl von **Gebäuden** mit genug Müll, um eine Sammelanfrage zu erzeugen.\n" +
                    "In Vanilla liegt der Anforderungsschwellenwert bei **100** internen Mülleinheiten.\n" +
                    "Profi-Optionen können Anforderungs- und Abholschwellenwerte überschreiben.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Anlagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Zusammenfassung der gezählten Müllanlagen.\n" +
                    "**Anlagen** = gezählte Müllgebäude.\n" +
                    "**Müllwagen** = normale Sammelfahrzeuge. In Industrieabfallanlagen sammeln sie Industrieabfall statt normalen Müll.\n" +
                    "**Dump trucks** = Mülltransfers zwischen Anlagen.\n" +
                    "**Max. Arbeiter** = gesamte Arbeiterkapazität über dieselben Anlagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Müllwagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Unterwegs** = Lkw, die aktuell in der Stadt unterwegs sind.\n" +
                    "**Rückkehrend** = Teilmenge der fahrenden Lkw, die zur Rückkehr zur Anlage markiert sind.\n" +
                    "**Geparkt** = Lkw, die in einer Anlage geparkt sind.\n" +
                    "**Gesamt** = Anzahl aller Müllwagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detaillierten Status ins Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Sendet einen detaillierteren Müllbericht in **Logs/MagicGarbage.log**.\n" +
                    "Enthält geordnete Stadt-Müllstatistiken"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet den Spielordner Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Noch keine Stadt geladen." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Exzellent ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Kleine Anpassung nötig ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Leicht müffelig ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Müllproblem ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} über 7t" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produziert | {1:N0} t verarbeitet" },
                { "MG.Status.Row.Requests", "{1:N0} ausstehend | {2:N0} entsandt | {0:N0} gesamt" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} hat Müll | {2:N0} über Anforderungsschwellenwert" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} Anlagen | {1:N0}/{2:N0} Müllwagen/dump trucks | {3:N0} Arbeiter" },
                { "MG.Status.Row.Trucks", "{1:N0} unterwegs ({3:N0} rückkehrend) | {2:N0} geparkt | {0:N0} gesamt" },
                { "MG.Status.Row.FacilitiesNone", "Noch keine Anlagendaten." },

                // Log strings
                { "MG.Status.Log.Title", "Müllstatus ({0})" },
                { "MG.Status.Log.City", "Stadt: {0}" },
                { "MG.Status.Log.Mode", "Modus: Totale Magie={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Aktuelle Mod-Einstellungen" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash-Boss-Schieberegler (gespeichert): Lkw-Ladung={0:N0}% | Anlagenlagerung={1:N0}% | Anlagenverarbeitung={2:N0}% | Anlagenflotte={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "Profi (gespeichert): aktiviert={0} | Anforderung={1:N0} | Abholung={2:N0} | Zufriedenheitsbasis={3:N0} | Zufriedenheitsschritt={4:N0} | Ansammlungsrate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legende:\n" +
                    "- Produziert/Verarbeitet verwendet Tonnen pro Monat.\n" +
                    "- Die Schwellenwerte unten verwenden interne Mülleinheiten, keine Tonnen.\n" +
                    "- Für die spielerseitige Anzeige rechnet das Spiel 100 Einheiten = 0.1t und 1.000 Einheiten = 1t um.\n" +
                    "- Müll-Servicebewertung = städtischer Müll-Zufriedenheitsfaktor im Spiel.\n" +
                    "  - 0 = Exzellent\n" +
                    "  - -1 = Kleine Anpassung nötig, oder ignorieren\n" +
                    "  - -2 bis -4 = Leicht müffelig\n" +
                    "  - -5 bis -10 = Müllproblem\n" +
                    "Schwellenwert-Schieberegler:\n" +
                    "  - Abholschwellenwert = Mindestmüll, bevor ein Lkw bei einem Gebäude sammelt.\n" +
                    "  - Anforderungsschwellenwert = Mindestmüll, bevor das Spiel eine Sammelanfrage erstellt oder beibehält.\n" +
                    "- Warnsymbol = Müllmenge, bei der über einem Gebäude ein Warnsymbol erscheint.\n" +
                    "- Harte Obergrenze = maximale Müllmenge, die ein Gebäude ansammeln kann.\n" +
                    "- Ausstehend = aktive Anfragen, die aktuell keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "- Einige ausstehende Anfragen werden später zugewiesen; andere können später auch wieder verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr braucht.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Spielschwellenwerte (interne Mülleinheiten): Abholung={1:N0}, Anforderung={0:N0}, Warnsymbol={2:N0}, harte Obergrenze={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Schwellenwerte: <GarbageParameterData nicht verfügbar>" },
                { "MG.Status.Log.GarbageProcessing", "Müll: {0:N0} t/Monat | Verarbeitung: {1:N0} t/Monat" },
                { "MG.Status.Log.GarbageServiceRating", "Müll-Servicebewertung: {0} | roh={1:N2} | gerundet={2:N0}" },
                { "MG.Status.Log.Requests", "Sammelanfragen: ausstehend={1:N0}, entsandt={2:N0}, gesamt={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Höchstes ausstehendes Ziel: {0:N0} ({1:N1}t) bei {2}" },
                { "MG.Status.Log.PendingPeakNone", "Höchstes ausstehendes Ziel: keines" },
                { "MG.Status.Log.Producers", "Gebäude: {0:N0} Warnsymbole | {1:N0} gesamt | {2:N0} hat Müll | {3:N0} über Anforderungsschwellenwert " },
                { "MG.Status.Log.ProducerGarbageStats", "Gebäudemüll (nur > 0): Durchschnitt={0:N0} ({1:N1}t) | Median={2:N0} ({3:N1}t) | Max={4:N0} ({5:N1}t) bei {6}" },
                { "MG.Status.Log.NearWarning75", "Gebäude nahe Warnsymbol (mindestens {1:N0} Einheiten / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Anlagen: {0:N0} gesamt | {1:N0} Müllwagen | {2:N0} dump trucks ({3:N0} unterwegs) | {4:N0} Arbeiter" },
                { "MG.Status.Log.Trucks", "Müllwagen: {2:N0} unterwegs ({3:N0} rückkehrend) | {1:N0} geparkt | {4:N0} deaktiviert | {0:N0} gesamt" },
                { "MG.Status.Log.FacilitiesHeader", "Anlagenübersicht" },
                { "MG.Status.Log.FacilityLine", "- Anlage {0}: Müllwagen={1:N0} ({2:N0} unterwegs, {3:N0} geparkt) | dump trucks={4:N0} ({5:N0} unterwegs) | max. Arbeiter={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Exzellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Kleine Anpassung nötig" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Leicht müffelig" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Müllproblem" },

                { "MG.Status.Log.ThresholdsHeader", "Schwellenwerte + Service" },
                { "MG.Status.Log.RequestsHeader", "Anfragen" },
                { "MG.Status.Log.BuildingsHeader", "Gebäude" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Kritische Gebäude über 7t" },

                { "MG.Status.Log.TransferProbeHeader", "Mülltransfer-Sonde" },
                { "MG.Status.Log.TransferProbeNone", "Keine Müll-Lager-/Transferanlagen gefunden." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | gelagert={1,7:N0} ({2,4:N1}t) | Kap={3,7:N0} ({4,4:N1}t) | Export={5,7:N0} ({6,4:N1}t) | niedrig={7,7:N0} ({8,4:N1}t) | min={9,7:N0} ({10,4:N1}t) | raus/rein={11,6:N0}/{12,6:N0} | aktiv={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "Lkw" },

                { "MG.Status.Log.SettingsPriority",
                    "Prioritätssystem (gespeichert): aktiviert={0} | Auslöser={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "Prioritätshilfe" },
                { "MG.Status.Log.PriorityState",
                    "Prioritätshilfe live={0} | Intervall={1:N0} Frames | zuletzt gescannte Anfragen={2:N0} | aktive kritische Anforderungsziele={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "Prioritätsdurchläufe: angehoben={0:N0} | normal={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "Höchstes aktives kritisches Ziel: keines" },
                { "MG.Status.Log.PriorityPeak",
                    "Höchstes aktives kritisches Ziel: {0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "ausstehend" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "entsandt" },

#if DEBUG
{ "MG.Status.Log.PriorityPerf", "Prioritätshilfe letzte Scanzeit={0:N3} ms" },
#endif


                { "MG.Status.Log.CriticalBuildingsNone", "keines" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },
            };
        }

        public void Unload()
        {
        }
    }
}
