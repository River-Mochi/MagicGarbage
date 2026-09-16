// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
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
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "État" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UTILISATION" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magie sur toute la ville" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** garde toute la ville propre.\n" +
                    "\n" +
                    "Quand **Magie sur toute la ville** est activée :\n" +
                    "- Chef des déchets est forcé sur OFF.\n" +
                    "- Les curseurs de Chef des déchets ne sont pas appliqués (les valeurs sont conservées pour plus tard).\n" +
                    "- Quelques camions peuvent encore circuler à cause du timing de la logique vanilla d’envoi."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Chef des déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gère directement les systèmes de déchets tout en laissant fonctionner la logique vanilla des déchets.\n" +
                    "\n" +
                    "- Quand **Chef des déchets est activé [ ✓ ]**, Magie sur toute la ville est forcée sur OFF.\n" +
                    "- Les curseurs ne s’appliquent que lorsque Chef des déchets est activé.\n" +
                    "- Magie sur toute la ville + Chef des déchets peuvent tous deux être **OFF** pour retrouver les réglages vanilla,\n" +
                    "  tout en gardant le **rapport d’état**, qui se met à jour seulement quand tu ouvres le menu Options (léger)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacité de chargement des camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "**100% = capacité vanilla** du camion (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stockage des installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu’une installation peut stocker.**\n" +
                    "**100% = stockage vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Vitesse de traitement des installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse à laquelle les installations traitent les déchets entrants.**\n" +
                    "**100% = vitesse de traitement vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotte des installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque installation peut envoyer.**\n" +
                    "**100% = nombre vanilla** de camions.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Réserve pour la cible" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Détermine à quel moment les camions deviennent plus sélectifs avec les collectes facultatives en route vers le bâtiment qui leur est assigné.**\n" +
                    "**10% est la valeur vanilla de la version 1.6.2.**\n" +
                    "Pour un camion normal de 20t :\n" +
                    "- 10% commence à protéger son arrêt assigné 2t plus tôt.\n" +
                    "- 15% commence 3t plus tôt.\n" +
                    "- 25% commence 5t plus tôt.\n" +
                    "Des valeurs plus élevées donnent une plus grande marge de sécurité. Les camions ignorent plus tôt les petites collectes, laissant davantage de place pour le bâtiment assigné."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applique des valeurs équilibrées pour les villes très actives.\n" +
                    "Charge camion **200%** | stockage **150%** | traitement **250%**\n" +
                    "Flotte **100%** | réserve cible **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Réinitialiser les curseurs" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Réinitialise les curseurs standard de Chef des déchets.\n" +
                    "- Les curseurs en pourcentage reviennent à **100%**.\n" +
                    "- La réserve cible revient à la valeur **vanilla de 10%**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nom d’affichage de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Version actuelle du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Ouvrir la page Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Ouvrir l’invitation Discord dans un navigateur." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<État Nettoyage auto>\n" +
                    "  * Magie sur toute la ville activée = **[ ✓ ]**\n" +
                    "  * Les déchets sont supprimés automatiquement - terminé.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<État Gestion manuelle>\n" +
                    "  * Chef des déchets = **[ ✓ ]**\n" +
                    "  * Règle les curseurs comme souhaité.\n" +
                    "  * Même système de déchets du jeu ; camions/installations mieux gérés manuellement.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<État / vanilla>\n" +
                    "  * Magie sur toute la ville = OFF\n" +
                    "  * Chef des déchets = OFF\n" +
                    "  * Rapport d’état seulement.\n" +
                    "  * Le jeu vanilla des déchets reste inchangé."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Utilisation" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Note du service déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "L’effet moyen de bonheur lié aux déchets à l’échelle de toute la ville, selon le jeu.\n" +
                    "Une bonne note globale peut quand même inclure quelques bâtiments problématiques ; vérifie donc aussi les **bâtiments à 7t+**.\n" +
                    "**0 = Excellent dans l’ensemble**\n" +
                    "**-1 = Petit ajustement utile**\n" +
                    "**-2 à -4 = Légèrement nauséabond**\n" +
                    "**-5 ou moins = Problème de déchets**\n" +
                    "\n" +
                    "Améliore le service avec les curseurs des camions et des installations, puis laisse tourner la ville avant de vérifier à nouveau."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Bâtiments à 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Nombre de bâtiments producteurs de déchets à **7000 / 7t** ou plus.\n" +
                    "Cet indicateur fixe d’alerte précoce t’aide à décider s’il faut augmenter le service avant que les bâtiments n’atteignent le niveau de l’icône d’avertissement du jeu.\n" +
                    "Utilise État détaillé vers le log pour lister leurs ID d’entité."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Déchets/mois" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Affiche la production de déchets de toute la ville, le traitement actuel et la capacité de traitement disponible des installations.\n" +
                    "Augmente le traitement si la production mensuelle dépasse la capacité.\n" +
                    "Toutes les valeurs sont en tonnes par mois."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Demandes de collecte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**En attente** = demandes de collecte actives qui ne sont actuellement assignées à aucun camion ni chemin.\n" +
                    "**Envoyées** = demandes de collecte actives déjà assignées.\n" +
                    "**Total** = toutes les demandes **actives** actuelles dans la chaîne des déchets.\n" +
                    "\n" +
                    "Cela diffère de **Au-dessus du seuil de demande**, qui compte des bâtiments plutôt que des demandes.\n" +
                    "Certaines demandes en attente seront assignées plus tard ; certaines peuvent aussi disparaître si la revalidation vanilla décide que la cible n’a plus besoin de service."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Bâtiments" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**A des déchets** = bâtiments contenant actuellement des déchets.\n" +
                    "**Total** = tous les bâtiments producteurs de déchets dans la ville.\n" +
                    "**Au-dessus du seuil de demande** = nombre actuel de **bâtiments** avec assez de déchets pour créer une demande de collecte.\n" +
                    "Le statut détaillé dans le log affiche le seuil de demande actif actuel du jeu.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Résumé des installations de déchets comptées.\n" +
                    "**Installations** = bâtiments de déchets comptés.\n" +
                    "**Camions poubelles** = camions de collecte normaux. Dans les installations de déchets industriels, ils collectent les déchets industriels au lieu des déchets ordinaires.\n" +
                    "**Camions-bennes** = transferts de déchets entre installations.\n" +
                    "**Travailleurs max** = capacité totale de travailleurs dans ces mêmes installations."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camions poubelles" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En circulation** = camions actuellement en ville.\n" +
                    "**Retour** = sous-ensemble des camions en circulation marqués pour retourner à leur installation.\n" +
                    "**Garés** = camions garés dans une installation.\n" +
                    "**Total** = nombre de tous les camions poubelles."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "État détaillé vers le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envoie un rapport de déchets plus détaillé dans **Logs/MagicGarbage.log**.\n" +
                    "Inclut des statistiques organisées sur les déchets de la ville."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Ouvre **MagicGarbage.log**. S’il est absent ou ne peut pas être ouvert, ouvre à la place le dossier Logs du jeu." },

                // Runtime status strings
                { "MG.Status.NoCity", "Aucune ville chargée pour le moment." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent dans l’ensemble ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Petit ajustement utile ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Légèrement nauséabond ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problème de déchets ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} bâtiments à 7t+" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produites | {2:N0} t traitées | {1:N0} t de capacité" },
                { "MG.Status.Row.Requests", "{1:N0} en attente | {2:N0} envoyées | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} a des déchets | {2:N0} au-dessus du seuil de demande" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} installations | {1:N0}/{2:N0} camions poubelles/bennes | {3:N0} travailleurs" },
                { "MG.Status.Row.Trucks", "{1:N0} en circulation ({3:N0} en retour) | {2:N0} garés | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Aucune donnée d’installation pour le moment." },

                // Log strings
                { "MG.Status.Log.Title", "État des déchets ({0})" },
                { "MG.Status.Log.City", "Ville : {0}" },
                { "MG.Status.Log.Mode", "Mode : Magie sur toute la ville={0}, Chef des déchets={1}" },
                { "MG.Status.Log.SettingsHeader", "Réglages actuels du mod" },
                { "MG.Status.Log.SettingsTrashBoss", "Curseurs Chef des déchets (enregistrés) : charge camion={0:N0}% | stockage installation={1:N0}% | traitement installation={2:N0}% | flotte installation={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "Légende :\n" +
                    "- La production, le traitement actuel et la capacité utilisent des tonnes par mois.\n" +
                    "- Les valeurs de seuil ci-dessous utilisent des unités internes de déchets, pas des tonnes.\n" +
                    "- Pour l’affichage joueur, le jeu convertit 100 unités = 0.1t et 1,000 unités = 1t.\n" +
                    "- Note du service déchets = facteur de bonheur lié aux déchets de la ville dans le jeu.\n" +
                    "  - 0 = Excellent dans l’ensemble\n" +
                    "  - -1 = Petit ajustement utile\n" +
                    "  - -2 à -4 = Légèrement nauséabond\n" +
                    "  - -5 à -10 = Problème de déchets\n" +
                    "Valeurs de routage :\n" +
                    "  - Le seuil de collecte est le minimum vanilla ; le routage tenant compte de la cible peut l’augmenter par camion afin de protéger de la capacité pour sa destination.\n" +
                    "  - Le seuil de demande est la quantité minimale de déchets avant que le jeu crée ou conserve une demande de collecte.\n" +
                    "- L’icône d’avertissement apparaît lorsque les déchets du bâtiment dépassent le niveau d’avertissement actif.\n" +
                    "- Limite stricte = quantité maximale de déchets qu’un bâtiment peut accumuler.\n" +
                    "- En attente = demandes actives qui ne sont actuellement assignées à aucun camion ni chemin.\n" +
                    "- Certaines demandes en attente seront assignées plus tard ; certaines peuvent aussi disparaître si la revalidation vanilla décide que la cible n’a plus besoin de service.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Seuils du jeu (unités internes de déchets) : collecte={1:N0}, demande={0:N0}, icône d’avertissement={2:N0}, limite stricte={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Seuils : <GarbageParameterData indisponible>" },
                { "MG.Status.Log.AdaptiveMargin", "Réserve cible : {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Réserve cible : actuelle={0:N0}% | valeur de base du jeu au chargement={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Production de déchets : {0:N0} t/mois | Traitement actuel : {2:N0} t/mois | Capacité de traitement : {1:N0} t/mois" },
                { "MG.Status.Log.GarbageServiceRating", "Note du service déchets : {0} | brut={1:N2} | arrondi={2:N0}" },
                { "MG.Status.Log.Requests", "Demandes de collecte : en attente={1:N0}, envoyées={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Plus grande quantité de déchets sur une cible en attente : {0:N0} ({1:N1}t) à {2}" },
                { "MG.Status.Log.PendingPeakNone", "Plus grande quantité de déchets sur une cible en attente : aucune" },
                { "MG.Status.Log.Producers", "Bâtiments : {0:N0} au-dessus du niveau d’avertissement | {1:N0} total | {2:N0} a des déchets | {3:N0} au-dessus du seuil de demande" },
                { "MG.Status.Log.ProducerGarbageStats", "Déchets des bâtiments (valeurs non nulles uniquement) : moy={0:N0} ({1:N1}t) | médiane={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) à {6}" },
                { "MG.Status.Log.NearWarning75", "Bâtiments proches de l’icône d’avertissement (au moins {1:N0} unités / {2:N1}t) : {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Installations : {0:N0} total | {1:N0} camions poubelles | {2:N0} camions-bennes ({3:N0} en circulation) | {4:N0} travailleurs" },
                { "MG.Status.Log.Trucks", "Camions poubelles : {2:N0} en circulation ({3:N0} en retour) | {1:N0} garés | {4:N0} désactivés | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Résumé des installations" },
                { "MG.Status.Log.FacilityLine", "- Installation {0} : camions poubelles={1:N0} ({2:N0} en circulation, {3:N0} garés) | camions-bennes={4:N0} ({5:N0} en circulation) | travailleurs max={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent dans l’ensemble" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Petit ajustement utile" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Légèrement nauséabond" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problème de déchets" },

                { "MG.Status.Log.ThresholdsHeader", "Seuils + service" },
                { "MG.Status.Log.RequestsHeader", "Demandes" },
                { "MG.Status.Log.BuildingsHeader", "Bâtiments" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Bâtiments à 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonde locale de transfert de déchets" },
                { "MG.Status.Log.LocalTransferProbeNone", "Aucune installation locale de déchets trouvée." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonde de transfert de déchets des connexions extérieures" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Aucune installation de déchets de connexion extérieure trouvée." },

                { "MG.Status.Log.TransferProbeHeader", "Sonde de transfert de déchets" },
                { "MG.Status.Log.TransferProbeNone", "Aucune installation de stockage-transfert de déchets trouvée." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | stocké={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accepte={5:N2} | envoie={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Camions" },

                { "MG.Status.Log.CriticalBuildingsNone", "aucun" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
