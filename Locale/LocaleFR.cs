// LocaleFR.cs
// French (fr-FR)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "À propos" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Magie totale" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-magie"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens"        },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTES D'UTILISATION" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magie totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [X]** supprime instantanément tous les déchets de la ville.\n" +
                    "Les bâtiments et camions de collecte deviennent presque purement décoratifs.\n\n" +

                    "Tant que **Magie totale** est ACTIVÉE :\n" +
                    "- La Semi-magie est automatiquement désactivée.\n" +
                    "- Tous les curseurs de Semi-magie sont ignorés.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "Semi-magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "Active un service des déchets amélioré mais toujours classique.\n" +
                    "- Utilise des camions et installations plus puissants au lieu de la magie totale.\n" +
                    "- Quand la Semi-magie est ACTIVÉE, la Magie totale est désactivée automatiquement.\n" +
                    "- Les curseurs ci-dessous n'ont d'effet que si la Semi-magie est activée.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Charge par camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "- 100 % = charge standard.\n" +
                    "- Valeurs plus élevées = moins d'allers-retours nécessaires.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Nombre de camions par installation" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque installation peut envoyer.**\n" +
                    "- 100 % = nombre standard.\n" +
                    "- Jusqu'à 400 % = jusqu'à 300 % de camions en plus.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Vitesse de traitement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse à laquelle les installations traitent les déchets.**\n" +
                    "- 100 % = vitesse standard.\n" +
                    "- Valeurs plus élevées = les déchets sont brûlés / recyclés plus vite.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacité de stockage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu'une installation peut stocker avant d'être pleine.**\n" +
                    "- 100 % = stockage standard.\n" +
                    "- Valeurs plus élevées = l'installation peut stocker davantage avant d'être saturée.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Valeurs par défaut" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Réinitialise tous les curseurs de Semi-magie à **100 %** (valeurs vanilla).\n" +
                    "À utiliser si vous souhaitez garder le mod installé sans modifier les statistiques du service des déchets."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Applique les valeurs Semi-magie recommandées :\n" +
                    "- Charge par camion : **200 %**\n" +
                    "- Camions par installation : **150 %**\n" +
                    "- Vitesse de traitement : **200 %**\n" +
                    "- Capacité de stockage : **200 %**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nom d'affichage de ce mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Version actuelle du mod." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Ouvre la page Paradox Mods avec les mods de l'auteur."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Ouvre le Discord de modding CS2 dans votre navigateur."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<État par défaut recommandé>\n" +
                    "  * Magie totale ACTIVÉE = **[X]**\n" +
                    "  * Tous les déchets sont supprimés instantanément\n" +
                    " <-------------------------------------->\n\n" +
                    "<État Semi-magie super camions>\n" +
                    "  * Magie totale DÉSACTIVÉE = **[ ]**\n" +
                    "  * Semi-magie ACTIVÉE = **[X]** et réglez les curseurs [100 >> 500] / [100 >> 400] à votre goût.\n" +
                    "  * Gameplay de style vanilla avec camions et installations renforcés.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jeu totalement vanilla>\n" +
                    "  * Magie totale DÉSACTIVÉE = **[ ]**\n" +
                    "  * Semi-magie = **[X]** (cliquez sur Valeurs par défaut)\n" +
                    "  * Tous les curseurs à 100 % (limites vanilla)\n" +
                    "  * Gameplay strictement standard.\n"
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
