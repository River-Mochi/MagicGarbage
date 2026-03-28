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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto-Reinigung" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Selbst verwalten" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod-Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** hält die ganze Stadt sauber.\n\n" +
                    "Wenn **Total Magic** aktiv ist:\n" +
                    "- Trash Boss wird auf OFF erzwungen.\n" +
                    "- Die Trash-Boss-Regler werden nicht angewendet (Werte werden für später gespeichert).\n" +
                    "- Einige LKW können sich wegen des Vanilla-Dispatch-Timings trotzdem noch bewegen."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Verwaltet die Müllsysteme direkt; die Vanilla-Mülllogik bleibt aktiv.\n\n" +
                    "- Wenn **Trash Boss AN [ ✓ ]** ist, wird Total Magic auf OFF erzwungen.\n" +
                    "- Regler gelten nur, wenn Trash Boss aktiviert ist.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ladekapazität der LKW" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder LKW transportieren kann.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Anlagenlager" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Anlagen-Verarbeitungstempo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility Fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele LKW jede Anlage aussenden kann.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "Gebäudeschwellen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "Optional: erhöht die **Schwellenwerte**, die ein Gebäude für die Müllabholung erreichen muss. \n" +
                    "Das kann helfen, den Müll-LKW-Verkehr zu reduzieren; zu hoch senkt aber die Abholfahrten.\n" +
                    "Die meisten Leute müssen das <nicht> anpassen. Der Mod lief schon gut, bevor diese Option hinzugefügt wurde; das ist nur ein Bonus für Experimente.\n"+
                    "--------------------------------\n" +
                    "- **Dispatch-Anfrageschwelle (R)** = Gebäudemüll, der nötig ist, um eine <LKW-Dispatch-Anfrage> auszulösen.\n" +
                    "- **Abholschwelle (P)** = Mindestmenge Müll, bevor ein LKW dort abholen kann.\n" +
                    "**1x** = Vanilla (100 R, 20 P). Hinweis: **1.000** Mülleinheiten sind meistens **1t**.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "Bei **20x** muss das **R** des Gebäudes >= **2.000 (2t)** Einheiten erreichen, bevor ein LKW eine <Dispatch-Anfrage> bekommt;\n" +
                    "Das Vanilla-Spiel lässt LKW auch auf dem Weg zum/vom <Dispatch>-Gebäude an Gebäuden halten, wenn der LKW nicht leer ist; bei 20x brauchen Gebäude auf der Route mehr als **400 Müll** (20 x Vanilla-P = 20).\n" +
                    "Balance-Tipp: Schau beim Anpassen häufig in den detaillierten Log-Bericht.\n" +
                    "Möglicherweise musst du die LKW-Kapazität erhöhen, wenn du den Schwellenwert hoch setzt, weil Häuser den Müll viel länger halten, bevor sie einen LKW rufen."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Empfohlene Trash-Boss-Werte anwenden:\n" +
                    "- LKW-Ladekapazität: **200%**\n" +
                    "- Dispatch-Schwelle: **5x**\n" +
                    "- Verarbeitungstempo: **200%**\n" +
                    "- Lagerkapazität: **150%**\n" +
                    "- Anlagen-LKW-Anzahl: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Spiel-Standard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Setzt alle Trash-Boss-Regler auf Vanilla-Werte zurück.\n" +
                    "- Prozent-Regler gehen zurück auf **100%**.\n" +
                    "- Dispatch-Schwelle geht zurück auf **1x**."
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
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Müll wird automatisch entfernt - Fertig.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Selbstverwaltungs-Zustand>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Regler nach Wunsch einstellen.\n" +
                    "  * Gleicher Spielmüll; bessere selbstverwaltete LKW/Anlagen.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normales Vanilla-Spiel>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * Alle Regler auf Vanilla-Werte\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Nutzung" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Müll/Monat" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Zeigt die aktuelle stadtweite Müllmenge und die gesamte Verarbeitungsrate.\n" +
                    "Erhöhe die Verarbeitung, wenn der monatlich produzierte Müll deutlich höher ist.\n" +
                    "**Produziert** und **Verarbeitet** verwenden Tonnen pro Monat.\n" +
                    "<Aktualisiert um = letzte Aktualisierung.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Abholanfragen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Wartend** = aktive Abholanfragen, die aktuell keinem LKW oder Pfad zugewiesen sind.\n" +
                    "**Dispatcht** = aktive Abholanfragen, die bereits zugewiesen sind.\n" +
                    "**Gesamt** = zählt die aktuell **aktive** Anfrage-Entität (in der Müll-Pipeline).\n\n" +
                    "Technischer Hinweis: Das ist etwas anderes als <Über der Anfrageschwelle>. Hier werden <Anfragen> gezählt, nicht Gebäude.\n" +
                    "Einige wartende Anfragen werden später zugewiesen; andere können auch später verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Dienst mehr braucht."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Hat Müll** = Gebäude, die aktuell Müll halten.\n" +
                    "**Gesamt** = alle müllerzeugenden Gebäude in der Stadt.\n" +
                    "**Über der Anfrageschwelle** = aktuelle Anzahl an **Gebäuden** mit genug Müll, um eine Abholanfrage zu erzeugen.\n" +
                    "In Vanilla liegt die Anfrageschwelle bei **100** internen Mülleinheiten.\n" +
                    "Die Trash-Boss-**Dispatch-Schwelle** erhöht Abhol- und Anfrageschwelle gemeinsam.\n" +
                    "Dadurch sinkt der Müll-LKW-Verkehr, weil die Zahl der Gebäude <über der Anfrageschwelle> und die Zahl <dispatchter> Anfragen sinkt."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Facilities" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Zusammenfassung der gezählten Müllanlagen.\n" +
                    "**Anlagen** = gezählte Müllgebäude.\n" +
                    "**LKW gesamt** = Müll-LKW, die diesen Anlagen gehören.\n" +
                    "**Max. Arbeiter** = gesamte Arbeitskapazität dieser Anlagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Unterwegs** = LKW, die aktuell in der Stadt unterwegs sind.\n" +
                    "**Rückkehrend** = Teilmenge der fahrenden LKW, die zur Anlage zurückkehren.\n" +
                    "**Geparkt** = LKW, die an einer Anlage geparkt sind.\n" +
                    "**Gesamt** = Anzahl aller Müll-LKW."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detaillierten Status ins Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Schreibt einen detaillierteren Müllbericht in **Logs/MagicGarbage.log**.\n" +
                    "Enthält eine kurze Legende, Vanilla-Referenzwerte und viele zusätzliche echte Stadt-Müllstatistiken."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet den Logs/..-Ordner des Spiels."
                },

        // Runtime status strings
        { "MG.Status.NoCity", "Noch keine Stadt geladen." },

        { "MG.Status.Row.GarbageProcessing", "{0:N0} t erzeugt | {1:N0} t verarbeitet | aktualisiert {2}" },
        { "MG.Status.Row.Requests", "{1:N0} ausstehend | {2:N0} zugewiesen | {0:N0} gesamt" },
        { "MG.Status.Row.Producers", "{0:N0} / {1:N0} haben Müll | {2:N0} über dem Anforderungsschwellenwert" },
        { "MG.Status.Row.FacilitiesSummary", "{0:N0} Anlagen | {1:N0} Lkw gesamt | {2:N0} max. Arbeiter" },
        { "MG.Status.Row.Trucks", "{1:N0} unterwegs ({3:N0} auf Rückfahrt) | {2:N0} geparkt | {0:N0} gesamt" },
        { "MG.Status.Row.FacilitiesNone", "Noch keine Anlagendaten vorhanden." },

        // Log strings
        { "MG.Status.Log.Title", "Müllstatus ({0})" },
        { "MG.Status.Log.City", "Stadt: {0}" },
        { "MG.Status.Log.Mode", "Modus: Total Magic={0}, Trash Boss={1}" },
        { "MG.Status.Log.Legend",
            "Legende:\n" +
            "- Erzeugt/Verarbeitet verwendet Tonnen pro Monat.\n" +
            "- Die Schwellenwerte unten verwenden interne Mülleinheiten, keine Tonnen.\n" +
            "- Für die Spielanzeige rechnet das Spiel 1.000 Einheiten = 1t um.\n" +
            "Schieberegler für Dispatch-Schwelle:\n" +
            "  - Abholschwelle = minimale Müllmenge, bevor ein Lkw an einem Gebäude sammelt.\n" +
            "  - Anforderungsschwelle = minimale Müllmenge, bevor das Spiel eine Abholanforderung erstellt oder beibehält.\n" +
            "- Warnsymbol = Müllmenge, bei der über einem Gebäude ein Warnsymbol erscheinen kann.\n" +
            "- Hartes Limit = maximale Müllmenge, die ein Gebäude ansammeln kann.\n" +
            "- Ausstehend = aktive Anforderungen, die derzeit keinem Lkw oder Pfad zugewiesen sind.\n" +
            "- Einige ausstehende Anforderungen werden später zugewiesen; andere können später ebenfalls verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr braucht.\n" +
            "-----------------------------------------------------------------------------\n"
        },
        { "MG.Status.Log.Thresholds",
            "Spiel-Schwellenwerte (interne Mülleinheiten): Abholung={1:N0}, Anforderung={0:N0}, Warnsymbol={2:N0}, hartes Limit={3:N0}"
        },

        { "MG.Status.Log.ThresholdsMissing", "Schwellenwerte: <GarbageParameterData nicht verfügbar>" },
        { "MG.Status.Log.GarbageProcessing", "Müll: {0:N0} t/Monat | Verarbeitung: {1:N0} t/Monat" },
        { "MG.Status.Log.Requests", "Abholanforderungen: ausstehend={1:N0}, zugewiesen={2:N0}, gesamt={0:N0}" },
        { "MG.Status.Log.PendingPeak", "Höchstes ausstehendes Ziel mit Müll: {0:N0} ({1:N1}t) bei {2}" },
        { "MG.Status.Log.Producers", "Gebäude: {0:N0} gesamt | {1:N0} haben Müll | {2:N0} über Anforderungsschwelle | {3:N0} auf Warnstufe" },
        { "MG.Status.Log.ProducerGarbageStats", "Gebäudemüll (nur >0): Ø={0:N0} ({1:N1}t) | Median={2:N0} ({3:N1}t) | Max={4:N0} ({5:N1}t) bei {6}" },
        { "MG.Status.Log.NearWarning75", "Gebäude nahe Warnstufe (>= {1:N0} Einheiten / {2:N1}t): {0:N0}" },
        { "MG.Status.Log.FacilitiesSummary", "Anlagen: {0:N0} gesamt | {1:N0} Lkw gesamt | {2:N0} max. Arbeiter" },
        { "MG.Status.Log.Trucks", "Müll-Lkw: {2:N0} unterwegs ({3:N0} auf Rückfahrt) | {1:N0} geparkt | {4:N0} deaktiviert | {0:N0} gesamt" },
        { "MG.Status.Log.FacilitiesHeader", "Anlagenübersicht" },
        { "MG.Status.Log.FacilityLine", "- Anlage {0}: unterwegs={2:N0}, geparkt={3:N0}, gesamt={1:N0}, max. Arbeiter={4:N0}" },

            };
        }

        public void Unload()
        {
        }
    }
}
