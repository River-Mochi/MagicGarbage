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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto sauber" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Selbst verwalten" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Erweitert" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NUTZUNG" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** hält die ganze Stadt sauber.\n\n" +
                    "Wenn **Total Magic** AN ist:\n" +
                    "- Trash Boss wird auf AUS erzwungen.\n" +
                    "- Trash-Boss-Regler werden nicht angewendet (Werte bleiben für später gespeichert).\n" +
                    "- Einige Lkw können wegen des vanilla Dispatch-Timings trotzdem noch fahren."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Verwaltet das Müllsystem direkt; die vanilla Müll-Logik läuft weiter.\n\n" +
                    "- Wenn **Trash Boss AN [ ✓ ]** ist, wird Total Magic auf AUS erzwungen.\n" +
                    "- Regler wirken nur, wenn Trash Boss aktiviert ist.\n" +
                    "- Total Magic + Trash Boss können beide **AUS** sein, wenn nur der **Statusbericht** gebraucht wird.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ladekapazität Lkw" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder Lkw tragen kann.**\n" +
                    "**100% = normaler** Spielstandard.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Anlagenlager" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann.**\n" +
                    "**100% = vanilla** Lagerung.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Verarbeitungstempo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "**100% = vanilla** Verarbeitungstempo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Anlagenflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele Lkw jede Anlage losschicken kann.**\n" +
                    "**100% = vanilla** Anzahl an Lkw.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Power-User-Optionen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**Optionale erweiterte Abstimmung für Schwellen + Müll-Zufriedenheit.**\n" +
                    "Wenn **AUS**, bleiben Abhol-/Anforderungsschwellen und Müll-Zufriedenheit **vanilla**.\n" +
                    "Wenn **AN**, erscheinen die erweiterten **Regler**.\n\n" +
                    "<--- Beispiele Müll-Zufriedenheit --->\n"+
                    " - <Vanilla> 100/65 = 1. Malus bei <165>.\n" +
                    " - <Empfohlen> 550/150 = 1. Malus bei <700>.\n" +
                    " - <Sehr weich> 950/200 = 1. Müll-Malus bei <1150>.\n" +
                    "Praktisch: Die letzten Reglerwerte bleiben gespeichert, wenn diese Option AUS ist."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Anforderungsschwelle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Gebäudemüllmenge, bevor eine Lkw-Anforderung erstellt oder beibehalten wird.**\n" +
                    "Vanilla = **100** Mülleinheiten.\n" +
                    "**100 Mülleinheiten = 0.1t**\n" +
                    "**1.000 Mülleinheiten = 1t**\n" +
                    "Diesen Wert immer mindestens so hoch wie die Abholschwelle halten.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Abholschwelle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimale Gebäudemüllmenge, bevor ein Lkw einsammeln kann.**\n" +
                    "Vanilla = **20** Mülleinheiten.\n" +
                    "Die Abholschwelle darf nie höher sein als die Anforderungsschwelle.\n" +
                    "Die Anforderungsschwelle immer mindestens auf Höhe der Abholschwelle halten, um Logikfehler zu vermeiden;" +
                    " wenn ein Lkw zu einem Gebäude geschickt wird und die Abholschwelle höher ist, kann er eventuell nicht sammeln (Ansammlungsrate spielt auch mit rein).\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**Empfohlene** Standardwerte für Trash Boss angewendet.\n" +
                    "Power-User-Einstellungen bleiben unverändert."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Setzt die Trash-Boss-Regler auf **vanilla Werte** zurück.\n" +
                    "Ändert die Power-User-Einstellungen <nicht>.\n" +
                    "**Vanilla:**\n" +
                    "- Prozent-Regler zurück auf **100%**.\n" +
                    "- Anforderungsschwelle zurück auf **100 Einheiten**.\n" +
                    "- Abholschwelle zurück auf **20 Einheiten**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Müll-Zufriedenheitsbasis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Gebäudemüllmenge, bevor Gesundheits- + Zufriedenheitsmalus startet.**\n" +
                    "**Vanilla = 100** Mülleinheiten.\n" +
                    "Höhere Basis = Gebäude können mehr Müll halten, bevor der Malus beginnt.\n" +
                    "100 Mülleinheiten = 0.1t\n" +
                    "Übersicht:\n" +
                    "- <Schwelle> = Auslöser für Systemverhalten\n" +
                    "- <Basis> = Startpunkt der Malus-Formel\n"+
                    "- <Schritt> = Schrittgröße der Formel, also wie schnell der Malus ansteigt"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Müll-Zufriedenheitsschritt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Zusätzlicher Müll über der Basis, der einen -1-Malus startet.**\n" +
                    "Vanilla = **65** Mülleinheiten.\n" +
                    "Höherer Schritt = langsameres Anwachsen des Malus.\n" +
                    "Der Spiel-Müllmalus ist bei **-10** gedeckelt.\n" +
                    "Der erste vanilla <-1 penalty> passiert bei **165 Müll** (100 Basis + 65 Schritt)\n" +
                    "Schwellenänderungen mit Zufriedenheitsreglern ausbalancieren, sonst werden die Mali stärker als normal."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Wendet **empfohlene** Power-User-Werte an.\n" +
                    "Schaltet Power User AN.\n" +
                    "Der erste Müll-Malus startet bei **700** Müll (550 Basis + 150 Schritt)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Setzt Power-User-Werte auf **vanilla** zurück.\n" +
                    "Schaltet **Power User AUS**."
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
                    "<Auto-Clean-Zustand>\n" +
                    "  * Total Magic AN  = **[ ✓ ]**\n" +
                    "  * Müll wird automatisch entfernt - fertig.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Selbstverwaltungs-Zustand>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Regler nach Wunsch einstellen.\n" +
                    "  * Optional: Power User für Schwellen + Müll-Zufriedenheit einschalten.\n" +
                    "  * Gleiches Müllsystem im Spiel; besser selbst verwaltete Lkw/Anlagen.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Status / Vanilla-Zustand>\n" +
                    "  * Total Magic = AUS\n" +
                    "  * Trash Boss = AUS\n" +
                    "  * Nur Statusbericht.\n" +
                    "  * Vanilla-Müllsystem bleibt unverändert."

                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Nutzung" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Müll/Monat" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Zeigt die aktuelle stadtweite Müllmenge und die gesamte Verarbeitungsrate.\n" +
                    "Verarbeitung erhöhen, wenn monatlich deutlich mehr Müll produziert wird.\n" +
                    "**Produziert** und **Verarbeitet** sind Tonnen pro Monat.\n" +
                    "<Update-Zeit = letzte Aktualisierung.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Abholanfragen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Ausstehend** = aktive Abholanfragen, die noch keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "**Verschickt** = aktive Abholanfragen, die schon zugewiesen wurden.\n" +
                    "**Gesamt** = zählt aktuell **aktive** Anfrage-Entitäten (in der Müll-Pipeline).\n\n" +
                    "Technik-Hinweis: Das ist etwas anderes als <Über Anforderungsschwelle>. Hier werden <Anfragen> gezählt, nicht Gebäude.\n" +
                    "Einige ausstehende Anfragen werden später zugewiesen; andere können verschwinden, wenn die vanilla Neubewertung entscheidet, dass das Ziel den Dienst nicht mehr braucht."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Hat Müll** = Gebäude, die aktuell Müll lagern.\n" +
                    "**Gesamt** = alle müllproduzierenden Gebäude in der Stadt.\n" +
                    "**Über Anforderungsschwelle** = aktuelle Anzahl **Gebäude** mit genug Müll für eine Abholanfrage.\n" +
                    "In vanilla liegt die Anforderungsschwelle bei **100** internen Mülleinheiten.\n" +
                    "Power User kann Anforderungs- und Abholschwelle überschreiben.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Anlagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Zusammenfassung der gezählten Müllanlagen.\n" +
                    "**Anlagen** = gezählte Müllgebäude.\n" +
                    "**Müllwagen** = normale Sammelfahrzeuge. In Industrieabfall-Anlagen sammeln sie Industrieabfall statt normalen Müll.\n" +
                    "**Dump trucks** = Mülltransfers zwischen Anlagen.\n" +
                    "**Max Arbeiter** = gesamte Arbeiterkapazität dieser Anlagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Lkw" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Unterwegs** = Lkw, die gerade in der Stadt unterwegs sind.\n" +
                    "**Rückkehr** = Teilmenge der fahrenden Lkw, die zur Anlage zurückfahren.\n" +
                    "**Geparkt** = Lkw, die an einer Anlage geparkt sind.\n" +
                    "**Gesamt** = Anzahl aller Müllwagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detaillierten Status ins Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Schreibt einen ausführlicheren Müll-Bericht in **Logs/MagicGarbage.log**.\n" +
                    "Enthält eine kurze Legende, vanilla Referenzwerte und viele weitere Echtzeit-Statistiken aus der Stadt."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet den Logs/..-Ordner des Spiels."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Noch keine Stadt geladen." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produziert | {1:N0} t verarbeitet | update {2}" },
                { "MG.Status.Row.Requests", "{1:N0} ausstehend | {2:N0} verschickt | {0:N0} gesamt" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} haben Müll | {2:N0} über Anforderungsschwelle" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} Anlagen | {1:N0} Müllwagen | {2:N0} dump trucks | {3:N0} max Arbeiter" },
                { "MG.Status.Row.Trucks", "{1:N0} unterwegs ({3:N0} Rückkehr) | {2:N0} geparkt | {0:N0} gesamt" },
                { "MG.Status.Row.FacilitiesNone", "Noch keine Anlagendaten." },

                // Log strings
                { "MG.Status.Log.Title", "Müll-Status ({0})" },
                { "MG.Status.Log.City", "Stadt: {0}" },
                { "MG.Status.Log.Mode", "Modus: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legende:\n" +
                    "- Produziert/Verarbeitet nutzt Tonnen pro Monat.\n" +
                    "- Die Schwellen unten nutzen interne Mülleinheiten, nicht Tonnen.\n" +
                    "- Für Spieler rechnet das Spiel 100 Einheiten = 0.1t und 1.000 Einheiten = 1t.\n" +
                    "Schwellen-Regler:\n" +
                    "  - Abholschwelle = Mindestmüll, bevor ein Lkw von einem Gebäude abholt.\n" +
                    "  - Anforderungsschwelle = Mindestmüll, bevor das Spiel eine Abholanfrage erstellt oder behält.\n" +
                    "- Warnsymbol = Müllmenge, ab der über einem Gebäude ein Warnsymbol erscheint.\n" +
                    "- Hartes Limit = maximale Müllmenge, die ein Gebäude ansammeln kann.\n" +
                    "- Ausstehend = aktive Anfragen, die noch keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "- Einige ausstehende Anfragen werden später zugewiesen; andere können verschwinden, wenn die vanilla Neubewertung entscheidet, dass das Ziel den Dienst nicht mehr braucht.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Spiel-Schwellen (interne Mülleinheiten): Abholung={1:N0}, Anfrage={0:N0}, Warnsymbol={2:N0}, hartes Limit={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Schwellen: <GarbageParameterData nicht verfügbar>" },
                { "MG.Status.Log.GarbageProcessing", "Müll: {0:N0} t/Monat | Verarbeitung: {1:N0} t/Monat" },
                { "MG.Status.Log.Requests", "Abholanfragen: ausstehend={1:N0}, verschickt={2:N0}, gesamt={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Höchstes ausstehendes Ziel: {0:N0} ({1:N1}t) bei {2}" },
                { "MG.Status.Log.Producers", "Gebäude: {0:N0} gesamt | {1:N0} haben Müll | {2:N0} über Anforderungsschwelle | {3:N0} Warnstufe" },
                { "MG.Status.Log.ProducerGarbageStats", "Gebäudemüll (nur >0): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) bei {6}" },
                { "MG.Status.Log.NearWarning75", "Gebäude nahe Warnung (mindestens {1:N0} Einheiten / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Anlagen: {0:N0} gesamt | {1:N0} Müllwagen | {2:N0} dump trucks ({3:N0} unterwegs) | {4:N0} Arbeiter" },
                { "MG.Status.Log.Trucks", "Müllwagen: {2:N0} unterwegs ({3:N0} Rückkehr) | {1:N0} geparkt | {4:N0} deaktiviert | {0:N0} gesamt" },
                { "MG.Status.Log.FacilitiesHeader", "Anlagenübersicht" },
                { "MG.Status.Log.FacilityLine", "- Anlage {0}: garbage={1:N0} ({2:N0} unterwegs, {3:N0} geparkt) | dump={4:N0} ({5:N0} unterwegs) | max Arbeiter={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
