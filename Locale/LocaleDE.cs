// LocaleDE.cs
// German (de-DE)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

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
            return new Dictionary<string, string>
            {
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Über"     },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Totale Magie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-Magie"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod-Infos"    },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links"        },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NUTZUNGSHINWEISE" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Totale Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [X]** entfernt sofort allen Müll in der Stadt.\n" +
                    "Müllgebäude und Müllfahrzeuge sind dann fast nur noch Dekoration.\n\n" +

                    "Solange **Totale Magie** AN ist:\n" +
                    "- Semi-Magie wird automatisch AUS geschaltet.\n" +
                    "- Alle Semi-Magie-Schieberegler werden ignoriert.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "Semi-Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "Aktiviert ein verstärktes, aber weiterhin normales Müllsystem.\n" +
                    "- Nutzt stärkere Lkw und Anlagen statt kompletter Magie.\n" +
                    "- Wenn Semi-Magie AN ist, wird Totale Magie automatisch AUS geschaltet.\n" +
                    "- Die Regler unten wirken nur, wenn Semi-Magie aktiviert ist.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Ladekapazität der Lkw" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder Lkw transportieren kann.**\n" +
                    "- 100 % = Standardladung pro Lkw.\n" +
                    "- Höhere Werte = weniger Fahrten nötig.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Anzahl der Anlagen-Lkw" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele Lkw jede Anlage aussenden kann.**\n" +
                    "- 100 % = Standardanzahl an Lkw.\n" +
                    "- Bis 400 % = bis zu 300 % mehr Lkw verfügbar.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Verarbeitungsgeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "- 100 % = Standardgeschwindigkeit.\n" +
                    "- Höhere Werte = Müll wird schneller verbrannt / recycelt.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Speicherkapazität der Anlage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann, bevor sie voll ist.**\n" +
                    "- 100 % = Standardspeicher.\n" +
                    "- Höhere Werte = Anlage kann mehr aufnehmen, bevor sie als voll gilt.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Standardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Setzt alle Semi-Magie-Regler auf **100 %** (Standardwerte) zurück.\n" +
                    "Nutze dies, wenn der Mod installiert bleiben soll, aber die Müllwerte unverändert bleiben sollen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Wendet empfohlene Semi-Magie-Werte an:\n" +
                    "- Lkw-Ladekapazität: **200 %**\n" +
                    "- Anzahl der Anlagen-Lkw: **150 %**\n" +
                    "- Verarbeitungsgeschwindigkeit: **200 %**\n" +
                    "- Speicherkapazität: **200 %**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Anzeigename dieses Mods."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktuelle Mod-Version." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Öffnet die Paradox-Mods-Seite mit den Mods des Autors."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Öffnet den CS2-Modding-Discord im Browser."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Empfohlener Standardzustand>\n" +
                    "  * Totale Magie AN  = **[X]**\n" +
                    "  * Aller Müll wird sofort entfernt\n" +
                    " <-------------------------------------->\n\n" +
                    "<Semi-Magie Super-Lkw-Zustand>\n" +
                    "  * Totale Magie AUS = **[ ]**\n" +
                    "  * Semi-Magie AKTIV = **[X]** und Regler nach Wunsch [100 >> 500] / [100 >> 400] einstellen.\n" +
                    "  * Normales Müllsystem mit stärkeren Lkw und Anlagen.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Völlig vanilla>\n" +
                    "  * Totale Magie AUS = **[ ]**\n" +
                    "  * Semi-Magie = **[X]** (klicke auf Standardwerte)\n" +
                    "  * Alle Regler auf 100 % (Vanilla-Grenzen)\n" +
                    "  * Exakt normales Gameplay.\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)),
                    string.Empty
                },
            };
        }

        public void Unload()
        {
        }
    }
}
