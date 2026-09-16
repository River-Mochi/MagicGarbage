// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Sobre" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpeza automática" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gerenciar manualmente" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Informações do mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia na cidade inteira" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** mantém a cidade inteira limpa.\n" +
                    "\n" +
                    "Enquanto a **Magia na cidade inteira** estiver LIGADA:\n" +
                    "- Chefe do lixo é forçado a DESLIGADO.\n" +
                    "- Os controles do Chefe do lixo não são aplicados (os valores ficam salvos para depois).\n" +
                    "- Alguns caminhões ainda podem se mover por causa do tempo da lógica vanilla de despacho."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Chefe do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gerencia diretamente os sistemas de lixo; mantém a lógica vanilla de lixo funcionando.\n" +
                    "\n" +
                    "- Quando o **Chefe do lixo está LIGADO [ ✓ ]**, Magia na cidade inteira é forçada a DESLIGADA.\n" +
                    "- Os controles só se aplicam quando o Chefe do lixo está ativado.\n" +
                    "- Magia na cidade inteira + Chefe do lixo podem ficar ambos **DESLIGADOS** para usar as configurações vanilla,\n" +
                    "  e você ainda pode ver o **relatório de status**, que só atualiza ao entrar no menu Opções (leve)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidade de carga do caminhão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão pode transportar.**\n" +
                    "**100% = capacidade vanilla** do caminhão (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Armazenamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação pode armazenar.**\n" +
                    "**100% = armazenamento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidade de processamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo recebido.**\n" +
                    "**100% = velocidade de processamento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Frota da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode despachar.**\n" +
                    "**100% = quantidade vanilla** de caminhões.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Reserva para o destino" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Define com que antecedência os caminhões ficam seletivos com coletas opcionais no caminho para o prédio atribuído.**\n" +
                    "**10% é o valor vanilla da versão 1.6.2.**\n" +
                    "Para um caminhão normal de 20t:\n" +
                    "- 10% começa a proteger a parada atribuída 2t antes.\n" +
                    "- 15% começa 3t antes.\n" +
                    "- 25% começa 5t antes.\n" +
                    "Valores maiores dão uma margem de segurança maior. Os caminhões ignoram coletas pequenas mais cedo, ajudando a deixar mais espaço para o prédio atribuído."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica valores equilibrados para cidades movimentadas.\n" +
                    "Carga do caminhão **200%** | armazenamento **150%** | processamento **250%**\n" +
                    "Frota **100%** | reserva para o destino **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Redefinir controles" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Redefine os controles padrão do Chefe do lixo.\n" +
                    "- Os controles percentuais voltam para **100%**.\n" +
                    "- A reserva para o destino volta ao valor **vanilla de 10%**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome de exibição deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versão atual do mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abrir a página do Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abrir o convite do Discord no navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado Limpeza automática>\n" +
                    "  * Magia na cidade inteira LIGADA = **[ ✓ ]**\n" +
                    "  * O lixo é removido automaticamente - pronto.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Estado Gerenciar manualmente>\n" +
                    "  * Chefe do lixo = **[ ✓ ]**\n" +
                    "  * Ajuste os controles como quiser.\n" +
                    "  * O mesmo lixo do jogo; caminhões/instalações melhor gerenciados manualmente.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Estado / vanilla>\n" +
                    "  * Magia na cidade inteira = DESLIGADA\n" +
                    "  * Chefe do lixo = DESLIGADO\n" +
                    "  * Apenas relatório de status.\n" +
                    "  * O sistema vanilla de lixo permanece inalterado."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Avaliação do serviço de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "O efeito médio de felicidade relacionado ao lixo em toda a cidade, conforme o jogo.\n" +
                    "Uma boa avaliação geral ainda pode incluir alguns prédios problemáticos, então confira também os **prédios com 7t+**.\n" +
                    "**0 = Excelente no geral**\n" +
                    "**-1 = Precisa de um pequeno ajuste**\n" +
                    "**-2 a -4 = Um pouco fedido**\n" +
                    "**-5 ou menos = Problema de lixo**\n" +
                    "\n" +
                    "Melhore o serviço com os controles de caminhões e instalações e deixe a cidade rodar antes de verificar novamente."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Prédios com 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Quantidade de prédios que produzem lixo com **7000 / 7t** ou mais.\n" +
                    "Esse indicador fixo de alerta antecipado ajuda a decidir se é preciso aumentar o serviço antes que os prédios atinjam o nível do ícone de aviso do jogo.\n" +
                    "Use Status detalhado no log para listar os Entity IDs."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Lixo/mês" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra a produção de lixo da cidade, o processamento atual e a capacidade de processamento disponível das instalações.\n" +
                    "Aumente o processamento se a produção mensal for maior que a capacidade.\n" +
                    "Todos os valores usam toneladas por mês."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitações de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendentes** = solicitações de coleta ativas que não estão atualmente atribuídas a um caminhão ou caminho.\n" +
                    "**Despachadas** = solicitações de coleta ativas já atribuídas.\n" +
                    "**Total** = todas as solicitações **ativas** atuais no fluxo de lixo.\n" +
                    "\n" +
                    "Isso é diferente de **Acima do limite de solicitação**, que conta prédios em vez de solicitações.\n" +
                    "Algumas solicitações pendentes serão atribuídas depois; outras também podem desaparecer se a revalidação vanilla decidir que o alvo não precisa mais de serviço."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Prédios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tem lixo** = prédios que atualmente contêm algum lixo.\n" +
                    "**Total** = todos os prédios que produzem lixo na cidade.\n" +
                    "**Acima do limite de solicitação** = quantidade atual de **prédios** com lixo suficiente para criar uma solicitação de coleta.\n" +
                    "O Status detalhado no log mostra o limite de solicitação ativo atual do jogo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumo das instalações de lixo contabilizadas.\n" +
                    "**Instalações** = prédios de lixo contabilizados.\n" +
                    "**Caminhões de lixo** = caminhões normais de coleta. Em instalações de Resíduos Industriais, eles coletam resíduos industriais em vez de lixo comum.\n" +
                    "**Caminhões basculantes** = transferências de lixo entre instalações.\n" +
                    "**Máx. de trabalhadores** = capacidade total de trabalhadores nessas mesmas instalações."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Caminhões de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Em movimento** = caminhões atualmente circulando pela cidade.\n" +
                    "**Retornando** = subconjunto dos caminhões em movimento marcados para voltar à instalação.\n" +
                    "**Estacionados** = caminhões estacionados em uma instalação.\n" +
                    "**Total** = quantidade de todos os caminhões de lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Status detalhado no log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envia um relatório de lixo mais detalhado para **Logs/MagicGarbage.log**.\n" +
                    "Inclui estatísticas organizadas do lixo da cidade."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre **MagicGarbage.log**. Se o arquivo estiver ausente ou não puder ser aberto, abre a pasta Logs do jogo." },

                // Runtime status strings
                { "MG.Status.NoCity", "Nenhuma cidade carregada ainda." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente no geral ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Precisa de um pequeno ajuste ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Um pouco fedido ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de lixo ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} prédios com 7t+" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produzidas | {2:N0} t processadas | {1:N0} t de capacidade" },
                { "MG.Status.Row.Requests", "{1:N0} pendentes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} tem lixo | {2:N0} acima do limite de solicitação" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalações | {1:N0}/{2:N0} caminhões de lixo/basculantes | {3:N0} trabalhadores" },
                { "MG.Status.Row.Trucks", "{1:N0} em movimento ({3:N0} retornando) | {2:N0} estacionados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Ainda não há dados das instalações." },

                // Log strings
                { "MG.Status.Log.Title", "Status do lixo ({0})" },
                { "MG.Status.Log.City", "Cidade: {0}" },
                { "MG.Status.Log.Mode", "Modo: Magia na cidade inteira={0}, Chefe do lixo={1}" },
                { "MG.Status.Log.SettingsHeader", "Configurações atuais do mod" },
                { "MG.Status.Log.SettingsTrashBoss", "Controles do Chefe do lixo (salvos): carga caminhão={0:N0}% | armazenamento instalação={1:N0}% | processamento instalação={2:N0}% | frota instalação={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produção, processamento atual e capacidade usam toneladas por mês.\n" +
                    "- Os valores de limite abaixo usam unidades internas de lixo, não toneladas.\n" +
                    "- Para exibição ao jogador, o jogo converte 100 unidades = 0.1t e 1,000 unidades = 1t.\n" +
                    "- Avaliação do serviço de lixo = fator de felicidade da cidade relacionado ao lixo no jogo.\n" +
                    "  - 0 = Excelente no geral\n" +
                    "  - -1 = Precisa de um pequeno ajuste\n" +
                    "  - -2 a -4 = Um pouco fedido\n" +
                    "  - -5 a -10 = Problema de lixo\n" +
                    "Valores de roteamento:\n" +
                    "  - O limite de coleta é o mínimo vanilla; o roteamento que considera o destino pode aumentá-lo por caminhão para proteger capacidade para o destino.\n" +
                    "  - O limite de solicitação é a quantidade mínima de lixo antes de o jogo criar ou manter uma solicitação de coleta.\n" +
                    "- O ícone de aviso aparece quando o lixo do prédio ultrapassa o nível de aviso ativo.\n" +
                    "- Limite máximo = quantidade máxima de lixo que um prédio pode acumular.\n" +
                    "- Pendente = solicitações ativas que não estão atualmente atribuídas a um caminhão ou caminho.\n" +
                    "- Algumas solicitações pendentes serão atribuídas depois; outras também podem desaparecer se a revalidação vanilla decidir que o alvo não precisa mais de serviço.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Limites do jogo (unidades internas de lixo): coleta={1:N0}, solicitação={0:N0}, ícone de aviso={2:N0}, limite máximo={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Limites: <GarbageParameterData indisponível>" },
                { "MG.Status.Log.AdaptiveMargin", "Reserva para o destino: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Reserva para o destino: atual={0:N0}% | valor base do jogo ao carregar={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Produção de lixo: {0:N0} t/mês | Processamento atual: {2:N0} t/mês | Capacidade de processamento: {1:N0} t/mês" },
                { "MG.Status.Log.GarbageServiceRating", "Avaliação do serviço de lixo: {0} | bruto={1:N2} | arredondado={2:N0}" },
                { "MG.Status.Log.Requests", "Solicitações de coleta: pendentes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Maior quantidade de lixo em alvo pendente: {0:N0} ({1:N1}t) em {2}" },
                { "MG.Status.Log.PendingPeakNone", "Maior quantidade de lixo em alvo pendente: nenhuma" },
                { "MG.Status.Log.Producers", "Prédios: {0:N0} acima do nível de aviso | {1:N0} total | {2:N0} tem lixo | {3:N0} acima do limite de solicitação" },
                { "MG.Status.Log.ProducerGarbageStats", "Lixo dos prédios (somente valores acima de zero): média={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) em {6}" },
                { "MG.Status.Log.NearWarning75", "Prédios perto do ícone de aviso (pelo menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalações: {0:N0} total | {1:N0} caminhões de lixo | {2:N0} caminhões basculantes ({3:N0} em movimento) | {4:N0} trabalhadores" },
                { "MG.Status.Log.Trucks", "Caminhões de lixo: {2:N0} em movimento ({3:N0} retornando) | {1:N0} estacionados | {4:N0} desativados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumo das instalações" },
                { "MG.Status.Log.FacilityLine", "- Instalação {0}: caminhões de lixo={1:N0} ({2:N0} em movimento, {3:N0} estacionados) | caminhões basculantes={4:N0} ({5:N0} em movimento) | máx. trabalhadores={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente no geral" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Precisa de um pequeno ajuste" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Um pouco fedido" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de lixo" },

                { "MG.Status.Log.ThresholdsHeader", "Limites + serviço" },
                { "MG.Status.Log.RequestsHeader", "Solicitações" },
                { "MG.Status.Log.BuildingsHeader", "Prédios" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Prédios com 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonda local de transferência de lixo" },
                { "MG.Status.Log.LocalTransferProbeNone", "Nenhuma instalação local de lixo encontrada." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda de transferência de lixo da conexão externa" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Nenhuma instalação de lixo de conexão externa encontrada." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda de transferência de lixo" },
                { "MG.Status.Log.TransferProbeNone", "Nenhuma instalação de armazenamento-transferência de lixo encontrada." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | armazenado={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | aceita={5:N2} | envia={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Caminhões" },

                { "MG.Status.Log.CriticalBuildingsNone", "nenhum" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
