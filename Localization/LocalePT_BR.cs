// File: Localization/LocalePT_BR.cs
// Portuguese (pt-BR)

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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Self Manage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Power User" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia Total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** mantém a cidade inteira limpa.\n\n" +
                    "Enquanto **Magia Total** estiver ON:\n" +
                    "- Controle do Lixo é forçado para OFF.\n" +
                    "- Os sliders de Controle do Lixo não são aplicados (os valores ficam salvos para depois).\n" +
                    "- Alguns caminhões ainda podem circular por causa do timing de dispatch vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Controle do Lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Permite gerenciar o sistema de lixo diretamente; a lógica de lixo vanilla continua rodando.\n\n" +
                    "- Quando **Controle do Lixo estiver ON [ ✓ ]**, Magia Total é forçada para OFF.\n" +
                    "- Os sliders só se aplicam quando Controle do Lixo está ativado.\n" +
                    "- Magia Total e Controle do Lixo podem ficar **OFF** ao mesmo tempo se a ideia for usar só o **relatório de status**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidade dos caminhões" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão pode carregar.**\n" +
                    "**100% = valor normal** do jogo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Armazenamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação pode armazenar.**\n" +
                    "**100% = armazenamento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidade de processamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**A velocidade com que as instalações processam o lixo que entra.**\n" +
                    "**100% = velocidade vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Frota da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode despachar.**\n" +
                    "**100% = quantidade vanilla** de caminhões.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opções avançadas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**Ajuste avançado opcional para limites + felicidade ligada ao lixo.**\n" +
                    "Quando estiver **OFF**, os limites de coleta/solicitação e a felicidade do lixo **continuam vanilla**.\n" +
                    "Quando estiver **ON**, aparecem os **sliders avançados**.\n\n" +
                    "<--- Exemplos de felicidade do lixo --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalidade em <165>.\n" +
                    " - <Recomendado> 550/150 = 1ª penalidade em <700>.\n" +
                    " - <Bem suave> 950/200 = 1ª penalidade de lixo em <1150>.\n" +
                    "Conveniência: os últimos valores dos sliders ficam salvos mesmo quando esta opção está OFF."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Limite de solicitação de dispatch" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantidade de lixo em um prédio antes de criar ou manter uma solicitação de envio de caminhão.**\n" +
                    "Vanilla = **100** unidades de lixo.\n" +
                    "**100 unidades de lixo = 0.1t**\n" +
                    "**1.000 unidades de lixo = 1t**\n" +
                    "Mantenha isso no mesmo nível ou acima do limite de coleta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Limite de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantidade mínima de lixo em um prédio antes que um caminhão possa coletar.**\n" +
                    "Vanilla = **20** unidades de lixo.\n" +
                    "O limite de coleta nunca pode ser maior que o limite de solicitação de dispatch.\n" +
                    "Mantenha o limite de solicitação de dispatch no mesmo nível ou acima do valor válido de coleta para evitar lógica quebrada;" +
                    " se um caminhão for enviado para um prédio e o valor de coleta for mais alto, ele pode não conseguir coletar nada (a taxa de acúmulo também entra nisso).\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica os valores padrão **recomendados** de Controle do Lixo.\n" +
                    "Não altera as configurações das Opções avançadas."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Volta os sliders de Controle do Lixo para os **valores vanilla**.\n" +
                    "Não altera <not> as configurações das Opções avançadas.\n" +
                    "**Vanilla:**\n" +
                    "- Os sliders em % voltam para **100%**.\n" +
                    "- O limite de solicitação de dispatch volta para **100 units**.\n" +
                    "- O limite de coleta volta para **20 units**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base da felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nível de lixo em um prédio antes de começar a penalidade de saúde + felicidade.**\n" +
                    "**Vanilla = 100** unidades de lixo.\n" +
                    "Base maior = os prédios aguentam mais lixo antes da penalidade.\n" +
                    "100 unidades de lixo = 0.1t\n" +
                    "Resumo:\n" +
                    "- <Limite> = ponto em que o comportamento do sistema entra em ação\n" +
                    "- <Base> = ponto inicial da fórmula da penalidade\n" +
                    "- <Step> = tamanho do incremento na fórmula, ou seja, a velocidade com que a penalidade cresce"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Step da felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Lixo extra acima da base que faz começar uma penalidade de -1.**\n" +
                    "Vanilla = **65** unidades de lixo.\n" +
                    "Step maior = crescimento mais lento da penalidade.\n" +
                    "O jogo limita a penalidade de lixo em **-10**.\n" +
                    "A primeira penalidade vanilla <-1 penalty> acontece em **165 de lixo** (100 baseline + 65 step)\n" +
                    "Se mexer nos limites, ajuste também os sliders de felicidade ou as penalidades podem ficar mais fortes que o normal."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica os valores **recomendados** das Opções avançadas.\n" +
                    "Liga as Opções avançadas.\n" +
                    "A primeira penalidade de lixo começa em **700** de lixo (550 baseline + 150 step)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Volta os valores das Opções avançadas para **vanilla**.\n" +
                    "Coloca **Opções avançadas em OFF**."
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
                    "<Estado auto clean>\n" +
                    "  * Magia Total ON  = **[ ✓ ]**\n" +
                    "  * O lixo é removido automaticamente - pronto.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado self manage>\n" +
                    "  * Controle do Lixo = **[ ✓ ]**\n" +
                    "  * Ajuste os sliders como quiser.\n" +
                    "  * Opcional: ligue as Opções avançadas para limites + felicidade do lixo.\n" +
                    "  * Mesmo sistema de lixo do jogo; caminhões/instalações melhor gerenciados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado status / vanilla>\n" +
                    "  * Magia Total = OFF\n" +
                    "  * Controle do Lixo = OFF\n" +
                    "  * Só relatório de status.\n" +
                    "  * O sistema de lixo vanilla fica inalterado."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Lixo/mês" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra a quantidade atual de lixo na cidade toda e a taxa total de processamento.\n" +
                    "Aumente o processamento se o lixo produzido por mês estiver muito acima.\n" +
                    "**Produzido** e **Processado** usam toneladas por mês.\n" +
                    "<Hora da atualização = última atualização.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitações de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendentes** = solicitações ativas de coleta ainda não atribuídas a um caminhão ou rota.\n" +
                    "**Despachadas** = solicitações ativas de coleta já atribuídas.\n" +
                    "**Total** = conta as entidades de solicitação **ativas** atuais (na cadeia do lixo).\n\n" +
                    "Nota técnica: isso é diferente de <Acima do limite de solicitação>. Aqui conta <solicitações>, não prédios.\n" +
                    "Algumas pendentes serão atribuídas depois; outras também podem sumir se a revalidação vanilla decidir que o alvo já não precisa do serviço."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Prédios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tem lixo** = prédios que atualmente têm lixo.\n" +
                    "**Total** = todos os prédios produtores de lixo da cidade.\n" +
                    "**Acima do limite de solicitação** = quantidade atual de **prédios** com lixo suficiente para criar uma solicitação de coleta.\n" +
                    "No vanilla, o limite de solicitação é **100** unidades internas de lixo.\n" +
                    "As Opções avançadas podem sobrescrever o limite de solicitação e o limite de coleta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumo das instalações de lixo contadas.\n" +
                    "**Instalações** = prédios de lixo contados.\n" +
                    "**Caminhões de lixo** = caminhões normais de coleta. Em instalações de lixo industrial, eles coletam lixo industrial em vez de lixo comum.\n" +
                    "**Dump trucks** = transferências de lixo entre instalações.\n" +
                    "**Máx. trabalhadores** = capacidade total de trabalhadores dessas mesmas instalações."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Caminhões" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Em movimento** = caminhões que estão rodando pela cidade agora.\n" +
                    "**Retornando** = parte dos caminhões em movimento que estão voltando para a instalação.\n" +
                    "**Estacionados** = caminhões estacionados em uma instalação.\n" +
                    "**Total** = quantidade de todos os caminhões de lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Status detalhado no log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envia um relatório mais detalhado de lixo para **Logs/MagicGarbage.log**.\n" +
                    "Inclui uma legenda curta, valores de referência vanilla e várias estatísticas reais da cidade."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre a pasta Logs/.. do jogo."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nenhuma cidade carregada ainda." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produzidas | {1:N0} t processadas | atual. {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pendentes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} têm lixo | {2:N0} acima do limite de solicitação" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalações | {1:N0} caminhões de lixo | {2:N0} dump trucks | {3:N0} máx. trabalhadores" },
                { "MG.Status.Row.Trucks", "{1:N0} em movimento ({3:N0} retornando) | {2:N0} estacionados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Ainda não há dados de instalações." },

                // Log strings
                { "MG.Status.Log.Title", "Status do lixo ({0})" },
                { "MG.Status.Log.City", "Cidade: {0}" },
                { "MG.Status.Log.Mode", "Modo: Magia Total={0}, Controle do Lixo={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produzido/Processado usa toneladas por mês.\n" +
                    "- Os limites abaixo usam unidades internas de lixo, não toneladas.\n" +
                    "- Para o jogador, o jogo converte 100 unidades = 0.1t e 1.000 unidades = 1t.\n" +
                    "Sliders de limite:\n" +
                    "  - Limite de coleta = lixo mínimo antes que um caminhão colete em um prédio.\n" +
                    "  - Limite de solicitação = lixo mínimo antes que o jogo crie ou mantenha uma solicitação de coleta.\n" +
                    "- Ícone de aviso = quantidade de lixo que faz aparecer um aviso em cima de um prédio.\n" +
                    "- Limite máximo = quantidade máxima de lixo que um prédio pode acumular.\n" +
                    "- Pendentes = solicitações ativas ainda não atribuídas a um caminhão ou rota.\n" +
                    "- Algumas pendentes serão atribuídas depois; outras também podem sumir se a revalidação vanilla decidir que o alvo já não precisa do serviço.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Limites do jogo (unidades internas de lixo): coleta={1:N0}, solicitação={0:N0}, ícone de aviso={2:N0}, limite máximo={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Limites: <GarbageParameterData indisponível>" },
                { "MG.Status.Log.GarbageProcessing", "Lixo: {0:N0} t/mês | Processamento: {1:N0} t/mês" },
                { "MG.Status.Log.Requests", "Solicitações de coleta: pendentes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Maior alvo pendente: {0:N0} ({1:N1}t) em {2}" },
                { "MG.Status.Log.Producers", "Prédios: {0:N0} total | {1:N0} têm lixo | {2:N0} acima do limite de solicitação | {3:N0} em nível de aviso" },
                { "MG.Status.Log.ProducerGarbageStats", "Lixo nos prédios (só acima de zero): média={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máximo={4:N0} ({5:N1}t) em {6}" },
                { "MG.Status.Log.NearWarning75", "Prédios perto do aviso (pelo menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalações: {0:N0} total | {1:N0} caminhões de lixo | {2:N0} dump trucks ({3:N0} em movimento) | {4:N0} trabalhadores" },
                { "MG.Status.Log.Trucks", "Caminhões de lixo: {2:N0} em movimento ({3:N0} retornando) | {1:N0} estacionados | {4:N0} desativados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumo das instalações" },
                { "MG.Status.Log.FacilityLine", "- Instalação {0}: lixo={1:N0} ({2:N0} em movimento, {3:N0} estacionados) | dump={4:N0} ({5:N0} em movimento) | máx. trabalhadores={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
