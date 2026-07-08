// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// Portuguese (Brazil) (pt-BR)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpeza auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gerenciar manualmente" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Especialista" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info do mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** mantém a cidade inteira limpa.\n" +
                    "\n" +
                    "Enquanto **Magia total** estiver ON:\n" +
                    "- Trash Boss fica forçado para OFF.\n" +
                    "- Os sliders do Trash Boss não são aplicados (os valores ficam salvos para depois).\n" +
                    "- Alguns caminhões ainda podem se mover por causa do timing da lógica vanilla de despacho."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gerencia diretamente os sistemas de lixo; a lógica vanilla de lixo continua rodando.\n" +
                    "\n" +
                    "- Quando **Trash Boss está ON [ ✓ ]**, Magia total fica forçada para OFF.\n" +
                    "- Os sliders só se aplicam quando Trash Boss está ativado.\n" +
                    "- Magia total + Trash Boss podem ficar **OFF** para usar configurações vanilla,\n" +
                    "  e você ainda pode ver o **relatório de Status**, que só atualiza ao entrar no menu de Opções (leve)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "Assistência de prioridade" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "Ajuda para alvos de lixo (prédios) muito sobrecarregados.\n" +
                    "Quando estiver **ON**, verifica se algum alvo de pedido ativo chegou a **7000+** (**7t**) de lixo.\n" +
                    "Objetivo: reduz coletas laterais extras quando necessário para que os caminhões cheguem mais rápido aos piores alvos.\n" +
                    "Isto é uma ajuda leve, não uma substituição rígida e completa da lógica vanilla de rotas.\n" +
                    "Leve, sem patch Harmony."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidade de carga do caminhão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão pode carregar.**\n" +
                    "**100% = normal** padrão do jogo (20t).\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Armazenamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação pode armazenar.**\n" +
                    "**100% = armazenamento vanilla**.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidade de processamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo recebido.**\n" +
                    "**100% = velocidade de processamento vanilla**.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Frota da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode despachar.**\n" +
                    "**100% = número vanilla** de caminhões.\n" +
                    ""
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Valores padrão **recomendados** do Trash Boss aplicados.\n" +
                    "Não muda as configurações de Especialista (separadas)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Retorna os sliders do Trash Boss para os **valores vanilla**.\n" +
                    "<Não> muda as configurações de Especialista.\n" +
                    "**Vanilla:**\n" +
                    "- Os sliders de porcentagem voltam para **100%**.\n" +
                    "- Dispatch Request Threshold volta para **100 units**.\n" +
                    "- Pickup Threshold volta para **20 units**.\n" +
                    ""
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opções de especialista" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Configurações avançadas opcionais\n" +
                    "<Aviso: NÃO é necessário> para um bom serviço; existe para jogadores que querem experimentar ou aprender melhor como os sistemas funcionam.\n" +
                    "Quando estiver **OFF**, os itens de Especialista se comportam como o jogo **vanilla** normal.\n" +
                    "Quando estiver **ON**, os **sliders avançados aparecem**.\n" +
                    "\n" +
                    "<--- Exemplos de felicidade --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalidade em <165>.\n" +
                    " - Clique em <Recomendado> para 550/150 = 1ª penalidade em <700>.\n" +
                    " - <Muito suave> 950/200 = 1ª penalidade de lixo em <1150>.\n" +
                    "Conveniência: os últimos valores dos sliders são salvos quando esta opção fica OFF (caso queira ativar depois)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantidade de lixo no prédio necessária antes que um pedido de despacho de caminhão seja criado ou mantido.**\n" +
                    "Vanilla = **100** garbage units.\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "Mantenha isto igual ou acima do Pickup Threshold.\n" +
                    "Normalmente isso aumenta quantos caminhões ficam em uso em vez de estacionados."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantidade mínima de lixo no prédio antes que um caminhão possa coletar.**\n" +
                    "Vanilla = **20** garbage units.\n" +
                    "O slider de Pickup <não pode> ser maior que Dispatch Request (DR); ele é limitado para evitar problema de lógica.\n" +
                    "Se um caminhão for despachado para um prédio e o valor de pickup for maior que DR, às vezes ele pode não conseguir coletar do prédio (a taxa de acúmulo também afeta isso).\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nível de lixo do prédio antes de começar a causar penalidade de saúde + felicidade.**\n" +
                    "**Vanilla = 100** garbage units.\n" +
                    "Base mais alta = prédios podem segurar mais lixo antes de a penalidade começar.\n" +
                    "100 garbage units = 0.1t\n" +
                    "Resumo:\n" +
                    "- <Threshold> = ponto de disparo do comportamento do sistema\n" +
                    "- <Baseline> = ponto inicial da fórmula de penalidade\n" +
                    "- <Step> = tamanho do incremento na fórmula, ou quão rápido a penalidade aumenta depois de começar"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Passo de felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Lixo extra acima da base que faz a penalidade -1 começar.**\n" +
                    "Vanilla = **65** garbage units.\n" +
                    "Step maior = crescimento mais lento da penalidade.\n" +
                    "O jogo limita a penalidade de lixo em **-10**.\n" +
                    "A primeira penalidade vanilla <-1 penalty> acontece em **165 garbage** (100 baseline + 65 step)\n" +
                    "Alterar threshold sem ajustar os sliders de felicidade pode causar penalidades mais pesadas que o normal."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Taxa de acúmulo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Escala os valores de origem de lixo dos prédios compatíveis.**\n" +
                    "Cuidado: isso é uma alavanca forte e mudar a taxa afeta muitas coisas.\n" +
                    "É possível ter um bom sistema sem usar isso.\n" +
                    "\n" +
                    "**100% = vanilla** accumulation rate.\n" +
                    "**20%** = acúmulo muito mais lento.\n" +
                    "**200%** = taxa dobrada - muito lixo.\n" +
                    "Com 20%, todos os Cims claramente estão compostando, então a taxa de acúmulo de lixo fica muito menor ;)\n" +
                    "\n" +
                    "Nota técnica: o jogo adiciona lixo gradualmente ao longo do dia, não tudo de uma vez."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica os valores **recomendados** de Especialista.\n" +
                    "Liga o Especialista.\n" +
                    "A primeira penalidade de lixo começa em **700** garbage (550 baseline + 150 step).\n" +
                    "Garbage Accumulation Rate fica em **100%** vanilla, a menos que seja alterada manualmente."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Coloca todos os valores de Especialista **de volta em vanilla**.\n" +
                    "Desliga o **Especialista**.\n" +
                    ""
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome exibido deste mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versão atual do mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abre a página do Paradox Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre o convite do Discord no navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado de Limpeza auto>\n" +
                    "  * Magia total ON = **[ ✓ ]**\n" +
                    "  * O lixo é removido automaticamente - pronto.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Estado de Gerenciar manualmente>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajuste os sliders como desejar.\n" +
                    "  * Opcional: ative para sliders avançados (não obrigatório).\n" +
                    "  * Mesmo lixo do jogo; caminhões/instalações melhor gerenciados.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Estado Status / vanilla>\n" +
                    "  * Magia total = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Apenas relatório de status.\n" +
                    "  * Jogo vanilla de lixo sem mudanças."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Avaliação do serviço de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Avaliação simples de felicidade do lixo vinda do jogo.\n" +
                    "**0 = Excelente**\n" +
                    "**-1 **= Precisa de pequeno ajuste. O jogo costuma ficar entre 0 e -1 e isso pode ser ignorado (número arredondado).\n" +
                    "**-2 to -4** = Levemente fedido\n" +
                    "**-5 to -10** = Problema de lixo\n" +
                    "**Ajustes indiretos:** Use <trash sliders> para melhorar isso com o tempo reduzindo o acúmulo de lixo.\n" +
                    "**Ajustes diretos:** Garbage Happiness Baseline + Garbage Happiness Step mudam <o que os cims toleram> antes de ficarem infelizes.\n" +
                    "**Garbage Accumulation Rate**: muda a velocidade com que prédios compatíveis produzem lixo. Use com cuidado porque o equilíbrio é importante. A maioria dos jogadores nunca precisa mexer nisso.\n" +
                    "<Update time = última atualização.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Prédios 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Contagem de prédios produtores de lixo com **7t / 7000** de lixo ou mais.\n" +
                    "São prédios muito sobrecarregados; ative [x] Priority Assist para priorizar melhor.\n" +
                    "Use o botão Status to log se quiser os números de Entity ID para inspecionar."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Lixo/mês" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra a quantidade atual de lixo da cidade e a taxa total de processamento de lixo.\n" +
                    "Aumente o processamento se o lixo produzido por mês for muito maior.\n" +
                    "**Produced** e **Processed** usam toneladas por mês."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Pedidos de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = pedidos de coleta ativos ainda não atribuídos a um caminhão ou caminho.\n" +
                    "**Dispatched** = pedidos de coleta ativos já atribuídos.\n" +
                    "**Total** = conta a entidade de pedido **active** atual (no pipeline de lixo).\n" +
                    "\n" +
                    "Nota técnica: isto é diferente de <Above request threshold>. Isto conta <requests>, não prédios.\n" +
                    "Alguns pedidos pending serão atribuídos depois; alguns também podem desaparecer se a revalidação vanilla decidir que o alvo não precisa mais de serviço."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Prédios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = prédios que atualmente têm algum lixo.\n" +
                    "**Total** = todos os prédios produtores de lixo na cidade.\n" +
                    "**Above request threshold** = contagem atual de **buildings** com lixo suficiente para criar um pedido de coleta.\n" +
                    "No vanilla, request threshold é **100** internal garbage units.\n" +
                    "Power User Options pode substituir request e pickup thresholds.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumo das instalações de lixo contadas.\n" +
                    "**Facilities** = prédios de lixo contados.\n" +
                    "**Garbage trucks** = caminhões normais de coleta. Em instalações de Industrial Waste, eles coletam resíduo industrial em vez de lixo.\n" +
                    "**Dump trucks** = transferências de lixo entre instalações.\n" +
                    "**Max workers** = capacidade total de trabalhadores nessas mesmas instalações."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Caminhões de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = caminhões atualmente fora na cidade.\n" +
                    "**Returning** = subconjunto de moving trucks marcado para voltar à instalação.\n" +
                    "**Parked** = caminhões estacionados em uma instalação.\n" +
                    "**Total** = contagem de todos os caminhões de lixo."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Status detalhado para log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envia um relatório de lixo mais detalhado para **Logs/MagicGarbage.log**.\n" +
                    "Inclui estatísticas organizadas do lixo da cidade"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre a pasta Logs/.. do jogo." },

                // Runtime status strings
                { "MG.Status.NoCity", "Nenhuma cidade carregada ainda." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Precisa de pequeno ajuste ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Levemente fedido ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de lixo ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} acima de 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produzido | {1:N0} t Processado" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalações | {1:N0}/{2:N0} caminhões lixo/dump | {3:N0} trabalhadores" },
                { "MG.Status.Row.Trucks", "{1:N0} em movimento ({3:N0} retornando) | {2:N0} estacionados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Sem dados de instalação ainda." },

                // Log strings
                { "MG.Status.Log.Title", "Status do lixo ({0})" },
                { "MG.Status.Log.City", "Cidade: {0}" },
                { "MG.Status.Log.Mode", "Modo: Magia total={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Configurações atuais do mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Sliders do Trash Boss (salvos): truck load={0:N0}% | facility storage={1:N0}% | facility process={2:N0}% | facility fleet={3:N0}%"
                },
                { "MG.Status.Log.SettingsPowerUser",
                    "Especialista (salvo): enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produced/Processed usa toneladas por mês.\n" +
                    "- Os valores de threshold abaixo usam internal garbage units, não toneladas.\n" +
                    "- Para exibição ao jogador, o jogo converte 100 units = 0.1t e 1,000 units = 1t.\n" +
                    "- Garbage Service Rating = fator de felicidade de lixo da cidade.\n" +
                    "  - 0 = Excelente\n" +
                    "  - -1 = precisa de pequeno ajuste, ou ignore\n" +
                    "  - -2 to -4 = levemente fedido\n" +
                    "  - -5 to -10 = problema de lixo\n" +
                    "Threshold sliders:\n" +
                    "  - Pickup threshold = lixo mínimo antes de um caminhão coletar de um prédio.\n" +
                    "  - Request threshold = lixo mínimo antes de o jogo criar ou manter um pedido de coleta.\n" +
                    "- Warning icon = quantidade de lixo que faz aparecer um ícone de aviso acima de um prédio.\n" +
                    "- Hard cap = quantidade máxima de lixo que um prédio pode acumular.\n" +
                    "- Pending = pedidos ativos ainda não atribuídos a caminhão ou caminho.\n" +
                    "- Alguns pedidos pending serão atribuídos depois; alguns também podem desaparecer se a revalidação vanilla decidir que o alvo não precisa mais de serviço.\n" +
                    "-----------------------------------------------------------------------------\n" +
                    ""
                },

                { "MG.Status.Log.Thresholds", "Thresholds do jogo (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData não disponível>" },
                { "MG.Status.Log.GarbageProcessing", "Lixo: {0:N0} t/mês | Processamento: {1:N0} t/mês" },
                { "MG.Status.Log.GarbageServiceRating", "Avaliação do serviço de lixo: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "Pedidos de coleta: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Maior alvo pending de lixo: {0:N0} ({1:N1}t) em {2}" },
                { "MG.Status.Log.PendingPeakNone", "Maior alvo pending de lixo: nenhum" },
                { "MG.Status.Log.Producers", "Prédios: {0:N0} warning icons | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold " },
                { "MG.Status.Log.ProducerGarbageStats", "Lixo dos prédios (apenas não-zero): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) em {6}" },
                { "MG.Status.Log.NearWarning75", "Prédios perto do warning icon (pelo menos {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalações: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Caminhões de lixo: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumo das instalações" },
                { "MG.Status.Log.FacilityLine",
                    "- Instalação {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Precisa de pequeno ajuste" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Levemente fedido" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de lixo" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + Serviço" },
                { "MG.Status.Log.RequestsHeader", "Pedidos" },
                { "MG.Status.Log.BuildingsHeader", "Prédios" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Prédios críticos acima de 7t" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonda local de transferência de lixo" },
                { "MG.Status.Log.LocalTransferProbeNone", "Nenhuma instalação local de lixo encontrada." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda de transferência de lixo da conexão externa" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Nenhuma instalação de lixo de conexão externa encontrada." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda de transferência de lixo" },
                { "MG.Status.Log.TransferProbeNone", "Nenhuma instalação de armazenamento-transferência de lixo encontrada." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accept={5:N2} | send={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "Caminhões" },
                { "MG.Status.Log.SettingsPriority", "Sistema de prioridade (salvo): enabled={0} | trigger={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState",
                    "Assistência de prioridade live={0} | interval={1:N0} frames | last scanned buildings={2:N0} | critical buildings={3:N0}"
                },
                { "MG.Status.Log.PriorityPeak", "Prédio crítico mais alto: {0:N0} ({1:N1}t) | {2} | request={3}" },

                { "MG.Status.Log.PriorityHeader", "Assistência de prioridade" },
                { "MG.Status.Log.PriorityPasses", "Passes de prioridade: raised={0:N0} | normal={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "Maior prédio crítico ativo: nenhum" },
                { "MG.Status.Log.PriorityPeakState.Pending", "pending" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "dispatched" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Último tempo de varredura da assistência de prioridade={0:N3} ms" },
#endif
                { "MG.Status.Log.CriticalBuildingsNone", "nenhum" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
