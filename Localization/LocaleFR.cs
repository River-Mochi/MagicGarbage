// File: Locale/LocaleFR.cs
// French (fr-FR)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "À propos" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Nettoyage auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestion manuelle" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Statut" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTES D'USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** garde toute la ville propre.\n\n" +
                    "Quand **Total Magic** est ON :\n" +
                    "- Trash Boss est forcé sur OFF.\n" +
                    "- Les curseurs Trash Boss ne sont pas appliqués (les valeurs restent sauvegardées).\n" +
                    "- Quelques camions peuvent encore circuler à cause du timing de la logique de dispatch vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Permet de gérer directement le système des déchets tout en gardant la logique vanilla.\n\n" +
                    "- Quand **Trash Boss est ON [ ✓ ]**, Total Magic est forcé sur OFF.\n" +
                    "- Les curseurs s'appliquent seulement quand Trash Boss est activé.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacité de charge des camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "100% = valeur normale du jeu.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Vitesse de traitement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse à laquelle les installations traitent les déchets entrants.**\n" +
                    "100% = vitesse vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Capacité de stockage des installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu'une installation peut stocker.**\n" +
                    "100% = stockage vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotte des installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque installation peut envoyer.**\n" +
                    "100% = nombre vanilla de camions.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applique les valeurs Trash Boss recommandées :\n" +
                    "- Capacité de charge des camions : **200%**\n" +
                    "- Vitesse de traitement : **200%**\n" +
                    "- Capacité de stockage : **160%**\n" +
                    "- Nombre de camions des installations : **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Remet tous les curseurs à **100%** (valeurs vanilla)."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nom affiché de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Version actuelle du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Ouvre la page Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Ouvre l'invitation Discord dans le navigateur." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Mode nettoyage auto>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Tous les déchets sont supprimés instantanément\n" +
                    " <-------------------------------------->\n\n" +
                    "<Mode gestion manuelle>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Réglez les curseurs comme voulu.\n" +
                    "  * Logique vanilla des déchets avec meilleure gestion des camions/installations.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jeu vanilla normal>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Cliquez sur **[Valeurs du jeu]**\n" +
                    "  * Tous les curseurs à 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Déchets/mois" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Affiche la quantité actuelle de déchets pour toute la ville et le taux total de traitement.\n" +
                    "Augmentez le traitement si les déchets produits par mois sont beaucoup plus élevés.\n" +
                    "**Produced** et **Processed** utilisent des tonnes par mois.\n" +
                    "Heure de mise à jour = dernière actualisation."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Demandes de collecte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = demandes de collecte actives pas encore assignées à un camion ou à un trajet.\n" +
                    "**Dispatched** = demandes de collecte actives déjà assignées.\n" +
                    "**Total** = toutes les demandes de collecte actives.\n" +
                    "Ce nombre peut être temporairement plus élevé que **Above request threshold** car les anciennes demandes sont nettoyées plus tard par la revalidation du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Bâtiments" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = bâtiments qui ont actuellement des déchets.\n" +
                    "**Total** = tous les bâtiments producteurs de déchets dans la ville.\n" +
                    "**Above request threshold** = bâtiments ayant assez de déchets pour créer une demande de collecte.\n" +
                    "En général, cela veut dire plus de <100> unités de déchets."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Résumé des installations de déchets comptées.\n" +
                    "**Facilities** = bâtiments de déchets comptés.\n" +
                    "**Trucks total** = camions à ordures possédés par ces installations.\n" +
                    "**Max workers** = capacité totale de travailleurs de ces mêmes installations."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = camions actuellement en circulation dans la ville.\n" +
                    "**Returning** = sous-ensemble des camions en mouvement qui retournent à leur installation.\n" +
                    "**Parked** = camions garés dans une installation.\n" +
                    "**Total** = nombre total de camions à ordures."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Statut détaillé vers le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Écrit un rapport détaillé sur les déchets dans **Logs/MagicGarbage.log**.\n" +
                    "Inclut une petite légende, les seuils en direct, les camions désactivés et le nombre max de travailleurs par installation."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Ouvre le dossier Logs/."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Aucune ville chargée." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produites | {1:N0} t traitées | maj {2}" },
                { "MG.Status.Row.Requests", "{1:N0} en attente | {2:N0} assignées | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ont des déchets | {2:N0} au-dessus du seuil de demande" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} installations | {1:N0} camions au total | {2:N0} travailleurs max" },
                { "MG.Status.Row.Trucks", "{1:N0} en mouvement ({3:N0} retour) | {2:N0} garés | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Aucune donnée d'installation pour le moment." },

                // Log strings
                { "MG.Status.Log.Title", "Statut des déchets ({0})" },
                { "MG.Status.Log.City", "Ville : {0}" },
                { "MG.Status.Log.Mode", "Mode : Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Légende :\n" +
                    "- Produced/Processed utilise des tonnes par mois.\n" +
                    "- Les seuils ci-dessous utilisent des unités internes de déchets, pas des tonnes.\n" +
                    "- Pickup threshold = minimum de déchets avant qu'un camion collecte dans un bâtiment.\n" +
                    "- Request threshold = minimum de déchets avant que le jeu crée ou garde une demande de collecte.\n" +
                    "- Warning threshold = quantité de déchets où l'icône d'avertissement peut apparaître au-dessus d'un bâtiment.\n" +
                    "- Hard cap = quantité maximale de déchets qu'un bâtiment peut accumuler.\n" +
                    "- Returning = sous-ensemble des camions en mouvement.\n" +
                    "- Le nombre de demandes actives peut temporairement dépasser le nombre de bâtiments actuellement au-dessus du seuil, car les anciennes demandes sont nettoyées plus tard par la revalidation vanilla.\n" +
                    "- Les nombres de travailleurs affichés ci-dessous montrent actuellement les **travailleurs max** pour chaque installation."
                },
                { "MG.Status.Log.Thresholds",
                    "Seuils (unités internes de déchets) : collecte={1:N0}, demande={0:N0}, avertissement={2:N0}, cap max={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Seuils : <GarbageParameterData indisponible>" },
                { "MG.Status.Log.GarbageProcessing", "Déchets : {0:N0} t/mo | Traitement : {1:N0} t/mo" },
                { "MG.Status.Log.Requests", "Demandes de collecte : en attente={1:N0}, assignées={2:N0}, total={0:N0}" },
                { "MG.Status.Log.Producers", "Bâtiments : {0:N0} total | {1:N0} ont des déchets | {2:N0} au-dessus du seuil de demande | {3:N0} niveau avertissement" },
                { "MG.Status.Log.FacilitiesSummary", "Installations : {0:N0} total | {1:N0} camions total | {2:N0} travailleurs max" },
                { "MG.Status.Log.Trucks", "Camions à ordures : {2:N0} en mouvement ({3:N0} retour) | {1:N0} garés | {4:N0} désactivés | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Résumé des installations" },
                { "MG.Status.Log.FacilityLine", "- Installation {0} : moving={2:N0}, parked={3:N0}, total={1:N0}, max workers={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
