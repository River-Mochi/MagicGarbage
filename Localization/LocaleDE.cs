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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Selbst steuern" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Expertenmodus" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NUTZUNG" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Totale Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** hält die ganze Stadt sauber.\n\n" +
                    "Während **Totale Magie** ON ist:\n" +
                    "- Müllsteuerung wird auf OFF gezwungen.\n" +
                    "- Die Regler der Müllsteuerung werden nicht angewendet (Werte werden für später gespeichert).\n" +
                    "- Einige Fahrzeuge können sich wegen des vanilla-Dispatch-Timings trotzdem noch bewegen."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Müllsteuerung" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Steuert die Müllsysteme direkt; die vanilla-Mülllogik bleibt aktiv.\n\n" +
                    "- Wenn **Müllsteuerung** ON [ ✓ ] ist, wird Totale Magie auf OFF gezwungen.\n" +
                    "- Die Regler wirken nur, wenn Müllsteuerung aktiviert ist.\n" +
                    "- Totale Magie + Müllsteuerung können beide **OFF** sein, wenn nur der **Statusbericht** gebraucht wird.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ladekapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jedes Fahrzeug transportieren kann.**\n" +
                    "**100% = normaler** Spielstandard.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Anlagenspeicher" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann.**\n" +
                    "**100% = vanilla** Speicher.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Verarbeitungstempo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "**100% = vanilla** Verarbeitungstempo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Anlagenflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele Fahrzeuge jede Anlage losschicken kann.**\n" +
                    "**100% = vanilla** Anzahl an Fahrzeugen.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**Empfohlen**: wendet die Standardwerte der Müllsteuerung an.\n" +
                    "Ändert die Einstellungen des Expertenmodus nicht (separat)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Setzt die Regler der Müllsteuerung auf **vanilla-Werte** zurück.\n" +
                    "Ändert die Einstellungen des Expertenmodus <nicht>.\n" +
                    "**Vanilla:**\n" +
                    "- Prozent-Regler gehen auf **100%** zurück.\n" +
                    "- Der Dispatch-Anfrage-Schwellenwert geht auf **100 Einheiten** zurück.\n" +
                    "- Der Abhol-Schwellenwert geht auf **20 Einheiten** zurück.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Optionen für Experten" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Optionale erweiterte Einstellungen\n" +
                    "<Warnung: NICHT nötig> für guten Service; gedacht für Spieler, die experimentieren oder das System besser verstehen wollen.\n" +
                    "Wenn **OFF**, bleiben alle Einstellungen des Expertenmodus **vanilla**.\n" +
                    "Wenn **ON**, erscheinen die **erweiterten Regler**.\n\n" +
                    "<--- Glücklichkeitsbeispiele --->\n" +
                    " - <Vanilla> 100/65 = 1. Malus bei <165>.\n" +
                    " - Klicke auf <Empfohlen> für 550/150 = 1. Malus bei <700>.\n" +
                    " - <Sehr weich> 950/200 = 1. Müll-Malus bei <1150>.\n" +
                    "Praktisch: Die letzten Reglerwerte werden gespeichert, wenn diese Option OFF ist (falls später wieder aktiviert werden soll)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch-Anfrage-Schwellenwert" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Müllmenge in einem Gebäude, bevor eine Fahrzeug-Anfrage erstellt oder behalten wird.**\n" +
                    "Vanilla = **100** Mülleinheiten.\n" +
                    "**100 Mülleinheiten = 0.1t**\n" +
                    "**1.000 Mülleinheiten = 1t**\n" +
                    "Diesen Wert auf Höhe des Abhol-Schwellenwerts oder darüber halten.\n" +
                    "Das erhöht oft die Zahl genutzter statt geparkter Fahrzeuge."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Abhol-Schwellenwert" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimale Müllmenge in einem Gebäude, bevor ein Fahrzeug dort abholen kann.**\n" +
                    "Vanilla = **20** Mülleinheiten.\n" +
                    "Der Abhol-Regler <kann nicht> höher sein als die Dispatch-Anfrage (DR); er wird begrenzt, um Logikfehler zu vermeiden.\n" +
                    "Wenn ein Fahrzeug zu einem Gebäude geschickt wird und der Abholwert höher als die DR ist, kann es manchmal sein, dass das Fahrzeug dort nicht abholen kann (die Akkumulationsrate spielt ebenfalls mit hinein).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Müll-Glücklichkeitsbasis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Müllstand eines Gebäudes, bevor Gesundheits- + Glücklichkeitsmalus beginnen.**\n" +
                    "**Vanilla = 100** Mülleinheiten.\n" +
                    "Höhere Basis = Gebäude können mehr Müll halten, bevor der Malus startet.\n" +
                    "100 Mülleinheiten = 0.1t\n" +
                    "Überblick:\n" +
                    "- <Threshold> = Auslösepunkt für Systemverhalten\n" +
                    "- <Baseline> = Startpunkt der Malusformel\n" +
                    "- <Step> = Schrittgröße der Formel, also wie schnell der Malus nach dem Start ansteigt"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Müll-Glücklichkeitsschritt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Zusätzliche Müllmenge über der Basis, ab der ein -1-Malus beginnt.**\n" +
                    "Vanilla = **65** Mülleinheiten.\n" +
                    "Höherer Schritt = langsameres Anwachsen des Malus.\n" +
                    "Das Spiel begrenzt den Müll-Malus auf **-10**.\n" +
                    "Der erste vanilla-Malus <-1 penalty> passiert bei **165 Müll** (100 Basis + 65 Schritt)\n" +
                    "Wenn Schwellenwerte geändert werden, sollten die Glücklichkeitsregler mit angepasst werden, sonst können stärkere Malusse als normal entstehen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Müll-Akkumulationsrate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Skaliert die Müllquellenwerte unterstützter Gebäude.**\n" +
                    "Das ist ein starker Hebel und beeinflusst viele Dinge.\n" +
                    "Ein gutes System ist auch ohne diese Einstellung möglich.\n\n" +
                    "**100% = vanilla** Akkumulation.\n" +
                    "**20%** = viel langsamerer Aufbau.\n" +
                    "**200%** = doppelte Rate - eine ganze Menge Müll.\n" +
                    "Bei 20% kompostieren offenbar alle Cims, daher die niedrigere Müllrate ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Wendet die **empfohlenen** Werte des Expertenmodus an.\n" +
                    "Schaltet den Expertenmodus ein.\n" +
                    "Der erste Müll-Malus beginnt bei **700** Müll (550 Basis + 150 Schritt).\n" +
                    "Die Müll-Akkumulationsrate bleibt bei **100%** vanilla, außer sie wird manuell geändert."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Setzt die Werte des Expertenmodus **auf vanilla** zurück.\n" +
                    "Schaltet den **Expertenmodus** auf OFF.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Angezeigter Name dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktuelle Mod-Version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Öffnet die Paradox-Mods-Seite." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Öffnet die Discord-Einladung im Browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Auto-Reinigungsstatus>\n" +
                    "  * Totale Magie ON = **[ ✓ ]**\n" +
                    "  * Müll wird automatisch entfernt - fertig.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Status Selbststeuerung>\n" +
                    "  * Müllsteuerung = **[ ✓ ]**\n" +
                    "  * Regler wie gewünscht einstellen.\n" +
                    "  * Optional: erweiterte Regler einschalten (nicht erforderlich).\n" +
                    "  * Gleiches Müllspiel; Fahrzeuge/Anlagen besser selbst gesteuert.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Status / vanilla>\n" +
                    "  * Totale Magie = OFF\n" +
                    "  * Müllsteuerung = OFF\n" +
                    "  * Nur Statusbericht.\n" +
                    "  * Das vanilla-Müllsystem bleibt unverändert."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Nutzung" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Müllservice-Wertung" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Einfache stadtweite Müll-Glücklichkeitswertung aus dem Spiel.\n" +
                    "**0 = Exzellent**\n" +
                    "**-1 = Kleine Anpassung nötig** das Spiel kann oft zwischen 0 und -1 schwanken und das kann ignoriert werden.\n" +
                    "**-2 bis -4 = Etwas müffelig**\n" +
                    "**-5 bis -10 = Müllproblem**\n" +
                    "**Indirekte Regler:** Fahrzeug-/Anlagen-/Schwellenwertregler können das mit der Zeit verbessern, indem sie den tatsächlichen Müllaufbau senken.\n" +
                    "**Direkte Regler:** <Müll-Glücklichkeitsbasis> + <Müll-Glücklichkeitsschritt> ändern, was Cims tolerieren, bevor sie unglücklich werden.\n" +
                    "**Quellen-Regler:** <Müll-Akkumulationsrate> ändert, wie schnell unterstützte Gebäude Müll produzieren.\n" +
                    "<Aktualisierungszeit = zuletzt aktualisiert.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Müll/Monat" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Zeigt die aktuelle stadtweite Müllmenge und die gesamte Verarbeitungsrate.\n" +
                    "Verarbeitung erhöhen, wenn der monatlich produzierte Müll deutlich höher ist.\n" +
                    "**Produziert** und **Verarbeitet** verwenden Tonnen pro Monat.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Abholanfragen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Ausstehend** = aktive Abholanfragen, die aktuell keinem Fahrzeug oder Pfad zugewiesen sind.\n" +
                    "**Zugewiesen** = aktive Abholanfragen, die bereits zugewiesen sind.\n" +
                    "**Gesamt** = zählt die aktuell **aktive** Anfrage-Entität (in der Müll-Pipeline).\n\n" +
                    "Technischer Hinweis: Das ist etwas anderes als <Über Anfrage-Schwellenwert>. Hier werden <Anfragen> gezählt, nicht Gebäude.\n" +
                    "Einige ausstehende Anfragen werden später zugewiesen; andere können auch später verschwinden, wenn die vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr braucht."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Hat Müll** = Gebäude, die aktuell Müll enthalten.\n" +
                    "**Gesamt** = alle müllproduzierenden Gebäude der Stadt.\n" +
                    "**Über Anfrage-Schwellenwert** = aktuelle Anzahl an **Gebäuden** mit genug Müll, um eine Abholanfrage zu erzeugen.\n" +
                    "In vanilla liegt der Anfrage-Schwellenwert bei **100** internen Mülleinheiten.\n" +
                    "Die Optionen für Experten können Anfrage- und Abhol-Schwellenwerte überschreiben.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Anlagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Zusammenfassung der gezählten Müllanlagen.\n" +
                    "**Anlagen** = gezählte Müllgebäude.\n" +
                    "**Müllfahrzeuge** = normale Sammelfahrzeuge. Bei Industrieabfall-Anlagen sammeln sie Industrieabfall statt normalen Müll.\n" +
                    "**Kipper** = Mülltransfers zwischen Anlagen.\n" +
                    "**Max. Arbeiter** = gesamte Arbeiterkapazität dieser Anlagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Müllfahrzeuge" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Unterwegs** = Fahrzeuge, die aktuell in der Stadt unterwegs sind.\n" +
                    "**Rückfahrt** = Teilmenge der unterwegs befindlichen Fahrzeuge, die zur Anlage zurückfahren.\n" +
                    "**Geparkt** = Fahrzeuge, die an einer Anlage geparkt sind.\n" +
                    "**Gesamt** = Anzahl aller Müllfahrzeuge."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detaillierten Status ins Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Schreibt einen ausführlicheren Müllbericht in **Logs/MagicGarbage.log**.\n" +
                    "Enthält eine kurze Legende, vanilla-Referenzwerte und viele zusätzliche echte Stadtstatistiken."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet den Logs/..-Ordner des Spiels."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Noch keine Stadt geladen." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Ausgezeichnet ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Kleine Anpassung empfohlen ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Etwas müffelig ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Müllproblem ({0:N0}) | aktualisiert {1}" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produziert | {1:N0} t verarbeitet" },
                { "MG.Status.Row.Requests", "{1:N0} ausstehend | {2:N0} zugewiesen | {0:N0} gesamt" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} haben Müll | {2:N0} über Anforderungsschwelle" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} Anlagen | {1:N0}/{2:N0} Müll/Dump-Lkw | {3:N0} Arbeiter" },
                { "MG.Status.Row.Trucks", "{1:N0} unterwegs ({3:N0} Rückfahrt) | {2:N0} geparkt | {0:N0} gesamt" },
                { "MG.Status.Row.FacilitiesNone", "Noch keine Anlagendaten." },

                // Log strings
                { "MG.Status.Log.Title", "Müllstatus ({0})" },
                { "MG.Status.Log.City", "Stadt: {0}" },
                { "MG.Status.Log.Mode", "Modus: Totale Magie={0}, Müllsteuerung={1}" },
                { "MG.Status.Log.SettingsHeader", "Aktuelle Mod-Einstellungen" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Regler der Müllsteuerung (gespeichert): Fahrzeugladung={0:N0}% | Anlagenspeicher={1:N0}% | Anlagenverarbeitung={2:N0}% | Anlagenflotte={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "Expertenmodus (gespeichert): aktiviert={0} | Anfrage={1:N0} | Abholung={2:N0} | Glücklichkeitsbasis={3:N0} | Glücklichkeitsschritt={4:N0} | Akkumulationsrate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legende:\n" +
                    "- Produziert/Verarbeitet verwendet Tonnen pro Monat.\n" +
                    "- Die Schwellenwerte unten verwenden interne Mülleinheiten, keine Tonnen.\n" +
                    "- Für Spieler rechnet das Spiel 100 Einheiten = 0.1t und 1.000 Einheiten = 1t um.\n" +
                    "- Müllservice-Wertung = Müll-Glücklichkeitsfaktor der Stadt im Spiel.\n" +
                    "  - 0 = Exzellent\n" +
                    "  - -1 = Kleine Anpassung nötig, oder ignorieren\n" +
                    "  - -2 bis -4 = Etwas müffelig\n" +
                    "  - -5 bis -10 = Müllproblem\n" +
                    "Schwellenwert-Regler:\n" +
                    "  - Abhol-Schwellenwert = minimale Müllmenge, bevor ein Fahrzeug bei einem Gebäude abholt.\n" +
                    "  - Anfrage-Schwellenwert = minimale Müllmenge, bevor das Spiel eine Abholanfrage erstellt oder behält.\n" +
                    "- Warnsymbol = Müllmenge, bei der über einem Gebäude ein Warnsymbol erscheint.\n" +
                    "- Harte Obergrenze = maximale Müllmenge, die ein Gebäude ansammeln kann.\n" +
                    "- Ausstehend = aktive Anfragen, die aktuell keinem Fahrzeug oder Pfad zugewiesen sind.\n" +
                    "- Einige ausstehende Anfragen werden später zugewiesen; andere können auch später verschwinden, wenn die vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr braucht.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Spiel-Schwellenwerte (interne Mülleinheiten): Abholung={1:N0}, Anfrage={0:N0}, Warnsymbol={2:N0}, harte Obergrenze={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Schwellenwerte: <GarbageParameterData nicht verfügbar>" },
                { "MG.Status.Log.GarbageProcessing", "Müll: {0:N0} t/Monat | Verarbeitung: {1:N0} t/Monat" },
                { "MG.Status.Log.GarbageServiceRating", "Müllservice-Wertung: {0} | roh={1:N2} | gerundet={2:N0}" },
                { "MG.Status.Log.Requests", "Abholanfragen: ausstehend={1:N0}, zugewiesen={2:N0}, gesamt={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Größtes ausstehendes Müllziel: {0:N0} ({1:N1}t) bei {2}" },
                { "MG.Status.Log.PendingPeakNone", "Größtes ausstehendes Müllziel: keines" },
                { "MG.Status.Log.Producers", "Gebäude: {0:N0} Warnsymbole | {1:N0} gesamt | {2:N0} haben Müll | {3:N0} über Anfrage-Schwellenwert " },
                { "MG.Status.Log.ProducerGarbageStats", "Gebäudemüll (nur positive Werte): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) bei {6}" },
                { "MG.Status.Log.NearWarning75", "Gebäude nahe Warnsymbol (mindestens {1:N0} Einheiten / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Anlagen: {0:N0} gesamt | {1:N0} Müllfahrzeuge | {2:N0} Kipper ({3:N0} unterwegs) | {4:N0} Arbeiter" },
                { "MG.Status.Log.Trucks", "Müllfahrzeuge: {2:N0} unterwegs ({3:N0} Rückfahrt) | {1:N0} geparkt | {4:N0} deaktiviert | {0:N0} gesamt" },
                { "MG.Status.Log.FacilitiesHeader", "Anlagenübersicht" },
                { "MG.Status.Log.FacilityLine", "- Anlage {0}: Müllfahrzeuge={1:N0} ({2:N0} unterwegs, {3:N0} geparkt) | Kipper={4:N0} ({5:N0} unterwegs) | max. Arbeiter={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Exzellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Kleine Anpassung nötig" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Etwas müffelig" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Müllproblem" },
            };
        }

        public void Unload()
        {
        }
    }
}
