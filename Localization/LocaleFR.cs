// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Utilisateur avancé" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "État" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UTILISATION" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** garde toute la ville propre.\n" +
                    "\n" +
                    "Quand **Total Magic** est activé :\n" +
                    "- Trash Boss est forcé désactivé.\n" +
                    "- Les curseurs de Trash Boss ne sont pas appliqués (les valeurs sont gardées pour plus tard).\n" +
                    "- Quelques camions peuvent encore circuler à cause du timing de la logique vanilla des envois."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gère directement les systèmes de déchets tout en laissant tourner la logique vanilla des déchets.\n" +
                    "\n" +
                    "- Quand **Trash Boss est activé [ ✓ ]**, Total Magic est forcé désactivé.\n" +
                    "- Les curseurs ne s’appliquent que lorsque Trash Boss est activé.\n" +
                    "- Total Magic + Trash Boss peuvent tous deux être **désactivés** pour retrouver les réglages vanilla,\n" +
                    "  tout en gardant le **rapport d’état**, qui se met à jour seulement quand tu ouvres le menu Options (léger)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "Assistance prioritaire" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "Assistance pour les cibles de déchets très surchargées (bâtiments).\n" +
                    "Quand **activé**, vérifie si une cible de demande active atteint **7000+** (**7t**) de déchets.\n" +
                    "Objectif : réduit les collectes secondaires si nécessaire pour que les camions atteignent plus vite les mauvaises cibles.\n" +
                    "C’est une aide légère, pas un remplacement dur et complet de la logique de trajet vanilla.\n" +
                    "Léger, sans patch Harmony."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacité de chargement des camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "**100% = valeur normale** du jeu (20t).\n"
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

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applique les valeurs standard **recommandées** de Trash Boss.\n" +
                    "Ne modifie pas les paramètres Power User (séparés)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Remet les curseurs de Trash Boss aux **valeurs vanilla**.\n" +
                    "Ne modifie <pas> les paramètres Power User.\n" +
                    "**Vanilla :**\n" +
                    "- Les curseurs en pourcentage reviennent à **100%**.\n" +
                    "- Le seuil de demande d’envoi revient à **100 unités**.\n" +
                    "- Le seuil de collecte revient à **20 unités**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Options Power User" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Paramètres avancés facultatifs\n" +
                    "<Avertissement : PAS nécessaire> pour un bon service ; fournis pour les joueurs qui veulent expérimenter ou mieux comprendre le fonctionnement des systèmes.\n" +
                    "Quand **désactivé**, les éléments Power User se comportent comme le jeu **vanilla** normal.\n" +
                    "Quand **activé**, les **curseurs avancés apparaissent**.\n" +
                    "\n" +
                    "<--- Exemples de bonheur --->\n" +
                    " - <Vanilla> 100/65 = 1ère pénalité à <165>.\n" +
                    " - Clique sur <Recommandé> pour 550/150 = 1ère pénalité à <700>.\n" +
                    " - <Très doux> 950/200 = 1ère pénalité de déchets à <1150>.\n" +
                    "Pratique : les dernières valeurs des curseurs sont sauvegardées quand cette option est désactivée (au cas où tu veux la réactiver plus tard)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Seuil de demande d’envoi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantité de déchets du bâtiment nécessaire avant qu’une demande d’envoi de camion soit créée ou conservée.**\n" +
                    "Vanilla = **100** unités de déchets.\n" +
                    "**100 unités de déchets = 0.1t**\n" +
                    "**1,000 unités de déchets = 1t**\n" +
                    "Garde cette valeur égale ou supérieure au seuil de collecte.\n" +
                    "Cela augmente généralement le nombre de camions utilisés plutôt que garés."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Seuil de collecte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantité minimale de déchets du bâtiment avant qu’un camion puisse collecter.**\n" +
                    "Vanilla = **20** unités de déchets.\n" +
                    "Le curseur de collecte <ne peut pas> être supérieur à la demande d’envoi (DR) ; il est limité pour éviter un problème de logique.\n" +
                    "Si un camion est envoyé vers un bâtiment et que la valeur de collecte est supérieure à DR, le camion peut parfois ne pas pouvoir collecter dans ce bâtiment (le taux d’accumulation joue aussi).\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de bonheur des déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Niveau de déchets du bâtiment avant le début de la pénalité de santé + bonheur.**\n" +
                    "**Vanilla = 100** unités de déchets.\n" +
                    "Une base plus haute = les bâtiments peuvent contenir plus de déchets avant la pénalité.\n" +
                    "100 unités de déchets = 0.1t\n" +
                    "Aperçu :\n" +
                    "- <Seuil> = point de déclenchement du comportement du système\n" +
                    "- <Base> = point de départ de la formule de pénalité\n" +
                    "- <Étape> = taille de l’incrément dans la formule, donc vitesse de montée de la pénalité après son début"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Étape de bonheur des déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Déchets supplémentaires au-dessus de la base qui déclenchent le début d’une pénalité de -1.**\n" +
                    "Vanilla = **65** unités de déchets.\n" +
                    "Une étape plus haute = croissance plus lente de la pénalité.\n" +
                    "Le jeu limite la pénalité de déchets à **-10**.\n" +
                    "La première pénalité vanilla <-1> arrive à **165 déchets** (100 base + 65 étape)\n" +
                    "Modifier les seuils avec les curseurs de bonheur peut entraîner des pénalités plus fortes que la normale."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Taux d’accumulation" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Met à l’échelle les valeurs source de déchets des bâtiments pris en charge.**\n" +
                    "Attention : c’est un levier puissant et le changement du taux affecte beaucoup de choses.\n" +
                    "Il est possible d’obtenir un bon système sans l’utiliser.\n" +
                    "\n" +
                    "**100% = taux d’accumulation vanilla**.\n" +
                    "**20%** = accumulation beaucoup plus lente.\n" +
                    "**200%** = taux doublé - énormément de déchets.\n" +
                    "À 20%, tous les Cims compostent évidemment, donc un taux d’accumulation bien plus bas ;)\n" +
                    "\n" +
                    "Note technique : le jeu ajoute les déchets progressivement au fil de la journée, pas tout d’un coup."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Applique les valeurs Power User **recommandées**.\n" +
                    "Active Power User.\n" +
                    "La première pénalité de déchets commence à **700** déchets (550 base + 150 étape).\n" +
                    "Le taux d’accumulation des déchets reste à **100%** vanilla sauf modification manuelle."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Remet toutes les valeurs Power User **aux valeurs vanilla**.\n" +
                    "Désactive **Power User**.\n"
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
                    "  * Total Magic activé = **[ ✓ ]**\n" +
                    "  * Les déchets sont supprimés automatiquement - terminé.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<État Gestion manuelle>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Règle les curseurs comme souhaité.\n" +
                    "  * Facultatif : active les curseurs avancés (pas obligatoire).\n" +
                    "  * Même système de déchets du jeu ; camions/installations mieux gérés manuellement.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<État / vanilla>\n" +
                    "  * Total Magic = désactivé\n" +
                    "  * Trash Boss = désactivé\n" +
                    "  * Rapport d’état seulement.\n" +
                    "  * Le jeu vanilla des déchets reste inchangé."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Utilisation" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Note du service déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Note simple de bonheur liée aux déchets, venant du jeu.\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= Petit ajustement utile. Le jeu oscille souvent entre 0 et -1 et cela peut être ignoré (nombre arrondi).\n" +
                    "**-2 à -4** = Légèrement nauséabond\n" +
                    "**-5 à -10** = Problème de déchets\n" +
                    "**Réglages indirects :** utilise les <curseurs de déchets> pour améliorer cela avec le temps en réduisant l’accumulation.\n" +
                    "**Réglages directs :** la base de bonheur des déchets + l’étape de bonheur des déchets modifient <ce que les cims tolèrent> avant d’être mécontents.\n" +
                    "**Taux d’accumulation des déchets** : change la vitesse à laquelle les bâtiments pris en charge produisent des déchets. À utiliser avec prudence, l’équilibre est important. La plupart des joueurs n’ont jamais besoin d’y toucher.\n" +
                    "<Heure de mise à jour = dernier rafraîchissement.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Bâtiments 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Nombre de bâtiments producteurs de déchets à **7t / 7000** déchets ou plus.\n" +
                    "Ce sont des bâtiments très surchargés ; active [x] Assistance prioritaire pour mieux les prioriser.\n" +
                    "Utilise le bouton d’état vers le log si tu veux les numéros d’ID d’entité pour inspecter."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Déchets/mois" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Affiche la quantité actuelle de déchets de la ville et le taux total de traitement des déchets.\n" +
                    "Augmente le traitement si les déchets produits mensuellement sont beaucoup plus élevés.\n" +
                    "**Produit** et **Traité** utilisent les tonnes par mois."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Demandes de collecte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**En attente** = demandes de collecte actives non assignées à un camion ou à un chemin.\n" +
                    "**Envoyées** = demandes de collecte actives déjà assignées.\n" +
                    "**Total** = compte les entités de demande **actives** actuelles (dans la chaîne des déchets).\n" +
                    "\n" +
                    "Note technique : c’est différent de <Au-dessus du seuil de demande>. Cela compte les <demandes>, pas les bâtiments.\n" +
                    "Certaines demandes en attente seront assignées plus tard ; certaines peuvent aussi disparaître si la revalidation vanilla décide que la cible n’a plus besoin de service."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Bâtiments" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**A des déchets** = bâtiments contenant actuellement des déchets.\n" +
                    "**Total** = tous les bâtiments producteurs de déchets dans la ville.\n" +
                    "**Au-dessus du seuil de demande** = nombre actuel de **bâtiments** avec assez de déchets pour créer une demande de collecte.\n" +
                    "En vanilla, le seuil de demande est de **100** unités internes de déchets.\n" +
                    "Les options Power User peuvent remplacer les seuils de demande et de collecte.\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Résumé des installations de déchets comptées.\n" +
                    "**Installations** = bâtiments de déchets comptés.\n" +
                    "**Camions poubelles** = camions de collecte normaux. Dans les installations de déchets industriels, ils collectent les déchets industriels au lieu des déchets ordinaires.\n" +
                    "**Dump trucks** = transferts inter-installations de déchets.\n" +
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
                    "Inclut des statistiques organisées sur les déchets de la ville"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Ouvre le dossier Logs/.. du jeu." },

                // Runtime status strings
                { "MG.Status.NoCity", "Aucune ville chargée pour le moment." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Petit ajustement utile ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Légèrement nauséabond ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problème de déchets ({0:N0}) | mis à jour {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} au-dessus de 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produites | {1:N0} t traitées" },
                { "MG.Status.Row.Requests", "{1:N0} en attente | {2:N0} envoyées | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ont des déchets | {2:N0} au-dessus du seuil de demande" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} installations | {1:N0}/{2:N0} camions poubelles/dump trucks | {3:N0} travailleurs" },
                { "MG.Status.Row.Trucks", "{1:N0} en circulation ({3:N0} retour) | {2:N0} garés | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Pas encore de données d’installation." },

                // Log strings
                { "MG.Status.Log.Title", "État des déchets ({0})" },
                { "MG.Status.Log.City", "Ville : {0}" },
                { "MG.Status.Log.Mode", "Mode : Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Paramètres actuels du mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Curseurs Trash Boss (sauvegardés) : charge camion={0:N0}% | stockage installation={1:N0}% | traitement installation={2:N0}% | flotte installation={3:N0}%"
                },
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User (sauvegardé) : activé={0} | demande={1:N0} | collecte={2:N0} | base bonheur={3:N0} | étape bonheur={4:N0} | taux d’accumulation={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Légende :\n" +
                    "- Produit/Traité utilise les tonnes par mois.\n" +
                    "- Les valeurs de seuil ci-dessous utilisent les unités internes de déchets, pas les tonnes.\n" +
                    "- Pour l’affichage joueur, le jeu convertit 100 unités = 0.1t et 1,000 unités = 1t.\n" +
                    "- Note du service déchets = facteur de bonheur des déchets de la ville.\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = Petit ajustement utile, ou ignorer\n" +
                    "  - -2 à -4 = Légèrement nauséabond\n" +
                    "  - -5 à -10 = Problème de déchets\n" +
                    "Curseurs de seuil :\n" +
                    "  - Seuil de collecte = déchets minimum avant qu’un camion collecte dans un bâtiment.\n" +
                    "  - Seuil de demande = déchets minimum avant que le jeu crée ou conserve une demande de collecte.\n" +
                    "- Icône d’avertissement = quantité de déchets qui affiche une icône au-dessus d’un bâtiment.\n" +
                    "- Plafond dur = maximum de déchets qu’un bâtiment peut accumuler.\n" +
                    "- En attente = demandes actives non assignées à un camion ou à un chemin.\n" +
                    "- Certaines demandes en attente seront assignées plus tard ; certaines peuvent aussi disparaître si la revalidation vanilla décide que la cible n’a plus besoin de service.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Seuils du jeu (unités internes de déchets) : collecte={1:N0}, demande={0:N0}, icône d’avertissement={2:N0}, plafond dur={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Seuils : <GarbageParameterData indisponible>" },
                { "MG.Status.Log.GarbageProcessing", "Déchets : {0:N0} t/mois | Traitement : {1:N0} t/mois" },
                { "MG.Status.Log.GarbageServiceRating", "Note du service déchets : {0} | brut={1:N2} | arrondi={2:N0}" },
                { "MG.Status.Log.Requests", "Demandes de collecte : en attente={1:N0}, envoyées={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Cible en attente la plus élevée : {0:N0} ({1:N1}t) à {2}" },
                { "MG.Status.Log.PendingPeakNone", "Cible en attente la plus élevée : aucune" },
                { "MG.Status.Log.Producers",
                    "Bâtiments : {0:N0} icônes d’avertissement | {1:N0} total | {2:N0} ont des déchets | {3:N0} au-dessus du seuil de demande "
                },
                { "MG.Status.Log.ProducerGarbageStats",
                    "Déchets des bâtiments (non nuls seulement) : moy={0:N0} ({1:N1}t) | médiane={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) à {6}"
                },
                { "MG.Status.Log.NearWarning75", "Bâtiments proches de l’icône d’avertissement (au moins {1:N0} unités / {2:N1}t) : {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary",
                    "Installations : {0:N0} total | {1:N0} camions poubelles | {2:N0} dump trucks ({3:N0} en circulation) | {4:N0} travailleurs"
                },
                { "MG.Status.Log.Trucks", "Camions poubelles : {2:N0} en circulation ({3:N0} retour) | {1:N0} garés | {4:N0} désactivés | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Résumé des installations" },
                { "MG.Status.Log.FacilityLine",
                    "- Installation {0} : camions poubelles={1:N0} ({2:N0} en circulation, {3:N0} garés) | dump trucks={4:N0} ({5:N0} en circulation) | travailleurs max={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Petit ajustement utile" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Légèrement nauséabond" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problème de déchets" },

                { "MG.Status.Log.ThresholdsHeader", "Seuils + service" },
                { "MG.Status.Log.RequestsHeader", "Demandes" },
                { "MG.Status.Log.BuildingsHeader", "Bâtiments" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Bâtiments critiques au-dessus de 7t" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonde de transfert local des déchets" },
                { "MG.Status.Log.LocalTransferProbeNone", "Aucune installation locale de déchets trouvée." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonde de transfert des déchets de connexion extérieure" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Aucune installation de déchets de connexion extérieure trouvée." },

                { "MG.Status.Log.TransferProbeHeader", "Sonde de transfert de déchets" },
                { "MG.Status.Log.TransferProbeNone", "Aucune installation de transfert-stockage de déchets trouvée." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stocké={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accepte={5:N2} | envoie={6:N2} | reqEntrée={7} | reqSortie={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "Camions" },
                { "MG.Status.Log.SettingsPriority", "Système de priorité (sauvegardé) : activé={0} | déclencheur={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState",
                    "Assistance prioritaire active={0} | intervalle={1:N0} frames | derniers bâtiments scannés={2:N0} | bâtiments critiques={3:N0}"
                },
                { "MG.Status.Log.PriorityPeak", "Bâtiment critique le plus élevé : {0:N0} ({1:N1}t) | {2} | demande={3}" },

                { "MG.Status.Log.PriorityHeader", "Assistance prioritaire" },
                { "MG.Status.Log.PriorityPasses", "Passes de priorité : relevées={0:N0} | normales={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "Bâtiment critique actif le plus élevé : aucun" },
                { "MG.Status.Log.PriorityPeakState.Pending", "en attente" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "envoyée" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Temps du dernier scan d’assistance prioritaire={0:N3} ms" },
#endif
                { "MG.Status.Log.CriticalBuildingsNone", "aucun" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
