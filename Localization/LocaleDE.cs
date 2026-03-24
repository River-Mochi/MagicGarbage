// File: Locale/LocaleDE.cs
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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Automatische Reinigung" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Selbst verwalten" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "HINWEISE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** hält die ganze Stadt sauber.\n\n" +
                    "Wenn **Total Magic** AN ist:\n" +
                    "- Trash Boss wird auf AUS gesetzt.\n" +
                    "- Trash-Boss-Regler werden nicht angewendet (Werte bleiben gespeichert).\n" +
                    "- Einige LKW können sich wegen des Timings der Vanilla-Dispatch-Logik weiterhin bewegen."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Verwaltet das Müllsystem direkt, während die Vanilla-Logik aktiv bleibt.\n\n" +
                    "- Wenn **Trash Boss AN [ ✓ ]** ist, wird Total Magic auf AUS gesetzt.\n" +
                    "- Regler gelten nur, wenn Trash Boss aktiviert ist.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ladekapazität der LKW" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder LKW transportieren kann.**\n" +
                    "100% = normaler Spielwert.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Verarbeitungsgeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "100% = Vanilla-Geschwindigkeit.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Lagerkapazität der Anlage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann.**\n" +
                    "100% = Vanilla-Lagerung.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Anlagenflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele LKW jede Anlage losschicken kann.**\n" +
                    "100% = Vanilla-Anzahl an LKW.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Wendet empfohlene Trash-Boss-Werte an:\n" +
                    "- Ladekapazität der LKW: **200%**\n" +
                    "- Verarbeitungsgeschwindigkeit: **200%**\n" +
                    "- Lagerkapazität: **160%**\n" +
                    "- Anzahl LKW pro Anlage: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Setzt alle Regler auf **100%** zurück (Vanilla-Werte)."
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
                    "<Auto-Clean-Modus>\n" +
                    "  * Total Magic AN  = **[ ✓ ]**\n" +
                    "  * Der gesamte Müll wird sofort entfernt\n" +
                    " <-------------------------------------->\n\n" +
                    "<Selbst verwalten>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Regler nach Wunsch einstellen.\n" +
                    "  * Vanilla-Mülllogik mit besser verwalteten LKW/Anlagen.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normales Vanilla-Spiel>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Klicke auf **[Spielstandard]**\n" +
                    "  * Alle Regler auf 100% (Vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Müll/Monat" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Zeigt die aktuelle stadtweite Müllmenge und die gesamte Verarbeitungsrate.\n" +
                    "Erhöhe die Verarbeitung, wenn pro Monat deutlich mehr Müll produziert wird.\n" +
                    "**Produced** und **Processed** verwenden Tonnen pro Monat.\n" +
                    "Aktualisierungszeit = zuletzt aktualisiert."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Abholanfragen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = aktive Abholanfragen, denen noch kein LKW oder Pfad zugewiesen wurde.\n" +
                    "**Dispatched** = aktive Abholanfragen, die bereits zugewiesen wurden.\n" +
                    "**Total** = alle aktiven Müllabholanfragen.\n" +
                    "Dieser Wert kann vorübergehend höher sein als **Above request threshold**, weil alte Anfragen erst später durch die Spiel-Revalidierung entfernt werden."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = Gebäude, die aktuell Müll haben.\n" +
                    "**Total** = alle müllproduzierenden Gebäude der Stadt.\n" +
                    "**Above request threshold** = Gebäude mit genug Müll, um eine Abholanfrage zu erzeugen.\n" +
                    "Das bedeutet meistens mehr als <100> Mülleinheiten."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Anlagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Zusammenfassung der gezählten Müllanlagen.\n" +
                    "**Facilities** = gezählte Müllgebäude.\n" +
                    "**Trucks total** = Müllfahrzeuge, die diesen Anlagen gehören.\n" +
                    "**Max workers** = gesamte Arbeiterkapazität dieser Anlagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "LKW" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = LKW, die aktuell in der Stadt unterwegs sind.\n" +
                    "**Returning** = Teilmenge der fahrenden LKW, die zu ihrer Anlage zurückkehren.\n" +
                    "**Parked** = LKW, die an einer Anlage geparkt sind.\n" +
                    "**Total** = Gesamtzahl aller Müllfahrzeuge."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detaillierten Status ins Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Schreibt einen detaillierten Müllbericht in **Logs/MagicGarbage.log**.\n" +
                    "Enthält eine kurze Legende, Live-Schwellenwerte, deaktivierte LKW und maximale Arbeiter pro Anlage."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Öffnet den Logs/-Ordner."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Noch keine Stadt geladen." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produziert | {1:N0} t verarbeitet | aktualisiert {2}" },
                { "MG.Status.Row.Requests", "{1:N0} offen | {2:N0} zugewiesen | {0:N0} gesamt" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} haben Müll | {2:N0} über Anfrageschwelle" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} Anlagen | {1:N0} LKW gesamt | {2:N0} max. Arbeiter" },
                { "MG.Status.Row.Trucks", "{1:N0} unterwegs ({3:N0} zurückkehrend) | {2:N0} geparkt | {0:N0} gesamt" },
                { "MG.Status.Row.FacilitiesNone", "Noch keine Anlagendaten vorhanden." },

                // Log strings
                { "MG.Status.Log.Title", "Müllstatus ({0})" },
                { "MG.Status.Log.City", "Stadt: {0}" },
                { "MG.Status.Log.Mode", "Modus: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legende:\n" +
                    "- Produced/Processed verwendet Tonnen pro Monat.\n" +
                    "- Die Schwellenwerte unten nutzen interne Mülleinheiten, keine Tonnen.\n" +
                    "- Pickup threshold = minimale Müllmenge, bevor ein LKW bei einem Gebäude abholt.\n" +
                    "- Request threshold = minimale Müllmenge, bevor das Spiel eine Abholanfrage erstellt oder behält.\n" +
                    "- Warning threshold = Müllmenge, ab der das Warnsymbol über einem Gebäude erscheinen kann.\n" +
                    "- Hard cap = maximale Müllmenge, die ein Gebäude ansammeln kann.\n" +
                    "- Returning = Teilmenge der fahrenden LKW.\n" +
                    "- Die Anzahl aktiver Anfragen kann vorübergehend höher sein als die Zahl der Gebäude über der Anfrageschwelle, weil alte Anfragen später durch Vanilla-Revalidierung entfernt werden.\n" +
                    "- Die Arbeiterzahlen unten zeigen aktuell die **maximalen Arbeiter** pro Anlage."
                },
                { "MG.Status.Log.Thresholds",
                    "Schwellenwerte (interne Mülleinheiten): Abholung={1:N0}, Anfrage={0:N0}, Warnung={2:N0}, Obergrenze={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Schwellenwerte: <GarbageParameterData nicht verfügbar>" },
                { "MG.Status.Log.GarbageProcessing", "Müll: {0:N0} t/Monat | Verarbeitung: {1:N0} t/Monat" },
                { "MG.Status.Log.Requests", "Abholanfragen: offen={1:N0}, zugewiesen={2:N0}, gesamt={0:N0}" },
                { "MG.Status.Log.Producers", "Gebäude: {0:N0} gesamt | {1:N0} haben Müll | {2:N0} über Anfrageschwelle | {3:N0} Warnstufe" },
                { "MG.Status.Log.FacilitiesSummary", "Anlagen: {0:N0} gesamt | {1:N0} LKW gesamt | {2:N0} max. Arbeiter" },
                { "MG.Status.Log.Trucks", "Müllfahrzeuge: {2:N0} unterwegs ({3:N0} zurückkehrend) | {1:N0} geparkt | {4:N0} deaktiviert | {0:N0} gesamt" },
                { "MG.Status.Log.FacilitiesHeader", "Anlagenübersicht" },
                { "MG.Status.Log.FacilityLine", "- Anlage {0}: moving={2:N0}, parked={3:N0}, total={1:N0}, max workers={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
