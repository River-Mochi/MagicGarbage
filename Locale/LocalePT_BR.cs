// Locale/LocalePT_BR.cs
// Portuguese (Brazil) (pt-BR)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT_BR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Sobre" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Magia Total" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-Mágico" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Informações do Mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)), "Lixo Mágico" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Ativado [X]** remove instantaneamente todo o lixo da cidade.\n" +
                    "Edifícios de gestão de resíduos deixam de ser necessários, salvo por estética.\n\n" +
                    "Usar apenas uma das opções: **Magia Total** (1) ou **Semi-Mágico** (2).\n" +
                    "Ativar ambas não gera efeito adicional."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidade do Caminhão de Lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Modo **Semi-Mágico** com caminhões de alta capacidade.\n" +
                    "Para facilitar sem eliminar a mecânica:\n" +
                    "- Definir Lixo Mágico como **desativado** [ ]\n" +
                    "- Usar o controle **[100 >> 500]** para aumentar a capacidade por caminhão\n\n" +
                    "**---------------------------------------**\n" +
                    " O controle ajusta a capacidade em relação ao valor da versão base.\n" +
                    "**100% = 20 t por caminhão** (padrão)\n" +
                    "**500% = 100 t por caminhão**\n\n" +
                    "**---------------------------------------**\n\n" +
                    "Para retornar ao comportamento vanilla: Lixo Mágico [OFF] e controle em 100%."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome exibido deste Mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versão atual do Mod." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abrir a página do autor no Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abrir o Discord de modding de CS2 no navegador." },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado padrão recomendado>\n" +
                    "  * Magia Total = **[X]**\n" +
                    "  * Controle = 100%\n" +
                    "  * Todo o lixo é removido instantaneamente\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<Semi-Mágico (caminhões de alta capacidade)>\n" +
                    "  * Lixo Mágico = **[ ]**\n" +
                    "  * Ajuste entre 100–500% para mais capacidade\n" +
                    "  * Mantém a simulação vanilla com menos caminhões\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jogo totalmente vanilla>\n" +
                    "  * Lixo Mágico = **[ ]**\n" +
                    "  * Controle = 100% (limites vanilla)\n" +
                    "  * Jogabilidade padrão."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },
            };
        }

        public void Unload()
        {
        }
    }
}
