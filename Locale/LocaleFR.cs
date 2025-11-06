// Locale/LocaleFR.cs

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
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Mode semi-magique" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Informations du mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Ordures magiques"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Activé [x]** supprime instantanément toutes les ordures de la ville.\n" +
                    "- Les bâtiments de gestion des déchets ne sont plus nécessaires, sauf si vous aimez simplement les voir.\n\n" +

                    "<Utilisez soit cette option de **Magie totale**, soit l’option **Semi-magique** ci-dessous — pas les deux.>\n" +
                    "- Rien de grave si les deux sont cochées, mais cela n’apporte rien de plus."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacité des camions-poubelles"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Mode **semi-magique** avec camions surpuissants.\n" +
                    "- Si vous voulez seulement faciliter la gestion des déchets sans les supprimer :\n" +
                    "- Ordures magiques = **[OFF]**\n" +
                    "- Puis utilisez ce curseur **[100 >> 500]** pour augmenter la capacité des camions.\n\n" +

                    "**---------------------------------------**\n" +
                    " Le curseur ajuste la capacité par rapport à la valeur du jeu de base.\n" +
                    "**100 % = 20 tonnes par camion** — valeur par défaut\n" +
                    "**500 % = 100 tonnes par camion**\n\n" +
                    " Bonus : la vitesse de déchargement est mise à l’échelle avec la capacité, donc les camions ne mettent pas plus de temps à se vider dans les installations de traitement.\n\n" +
                    "**---------------------------------------**\n\n" +
                    "Si vous voulez revenir au jeu vanilla complet, mettez Ordures magiques sur [OFF] et le curseur à 100 % pour un comportement normal."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),
                    "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nom affiché de ce mod."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)),
                    "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Version actuelle du mod."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Page Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Ouvrir la page Paradox Mods de Magic Garbage Truck."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Ouvrir le Discord de modding CS2 dans votre navigateur."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
