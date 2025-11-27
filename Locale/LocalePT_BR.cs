// LocalePT_BR.cs
// Portuguese (pt-BR)

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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Magia total" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-mágica" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO"},

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [X]** remove instantaneamente todo o lixo da cidade.\n" +
                    "Os prédios de coleta e caminhões de lixo viram praticamente decoração.\n\n" +

                    "Enquanto **Magia total** estiver ATIVADA:\n" +
                    "- A opção Semi-mágica é automaticamente desativada.\n" +
                    "- Todos os controles deslizantes da Semi-mágica são ignorados.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "Semi-mágica" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "Ativa um serviço de lixo turbinado, mas ainda no estilo normal.\n" +
                    "- Usa caminhões e instalações mais fortes em vez de magia total.\n" +
                    "- Quando a Semi-mágica está ATIVADA, a Magia total é desligada automaticamente.\n" +
                    "- Os sliders abaixo só têm efeito com a Semi-mágica ativada.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Carga por caminhão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão consegue transportar.**\n" +
                    "- 100% = carga padrão.\n" +
                    "- Valores maiores = menos viagens necessárias.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Caminhões por instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode enviar.**\n" +
                    "- 100% = número padrão de caminhões.\n" +
                    "- Até 400% = até 300% mais caminhões disponíveis.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocidade de processamento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo.**\n" +
                    "- 100% = velocidade padrão.\n" +
                    "- Valores maiores = o lixo é queimado/reciclado mais rápido.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacidade de armazenamento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação consegue armazenar antes de ficar cheia.**\n" +
                    "- 100% = capacidade padrão.\n" +
                    "- Valores maiores = a instalação aguenta mais antes de marcar \"cheia\".\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Padrão do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Define todos os sliders da Semi-mágica de volta para **100%** (valores vanilla).\n" +
                    "Use se quiser manter o mod instalado sem mexer nas estatísticas do serviço de lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Aplica os valores Semi-mágica recomendados:\n" +
                    "- Carga por caminhão: **200%**\n" +
                    "- Caminhões por instalação: **150%**\n" +
                    "- Velocidade de processamento: **200%**\n" +
                    "- Capacidade de armazenamento: **200%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nome exibido deste mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versão atual do mod." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Abre a página do Paradox Mods com os mods do autor."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre o Discord de modding de CS2 no navegador."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado padrão recomendado>\n" +
                    "  * Magia total LIGADA = **[X]**\n" +
                    "  * Todo o lixo é removido instantaneamente\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de caminhões super Semi-mágica>\n" +
                    "  * Magia total DESLIGADA = **[ ]**\n" +
                    "  * Semi-mágica LIGADA = **[X]** e ajuste os sliders [100 >> 500] / [100 >> 400] como preferir.\n" +
                    "  * Jogabilidade estilo vanilla, mas com caminhões e instalações mais fortes.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jogo totalmente vanilla>\n" +
                    "  * Magia total DESLIGADA = **[ ]**\n" +
                    "  * Semi-mágica = **[X]** (clique em \"Padrão do jogo\")\n" +
                    "  * Todos os sliders em 100% (limites vanilla)\n" +
                    "  * Experiência exatamente padrão.\n"
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
