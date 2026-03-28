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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Sobre" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpeza auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gerenciar manualmente" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info do mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** mantém a cidade inteira limpa.\n\n" +
                    "Enquanto **Total Magic** estiver ON:\n" +
                    "- Trash Boss é forçado para OFF.\n" +
                    "- Os controles do Trash Boss não são aplicados (os valores ficam salvos para depois).\n" +
                    "- Alguns caminhões ainda podem se mover por causa do timing de despacho vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gerencia diretamente os sistemas de lixo; a lógica vanilla continua rodando.\n\n" +
                    "- Quando **Trash Boss está ON [ ✓ ]**, Total Magic é forçado para OFF.\n" +
                    "- Os controles só se aplicam quando Trash Boss está ativado.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidade de carga" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão pode carregar.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Armazenamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação pode armazenar.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidade de processamento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo recebido.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Frota da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode despachar.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "Limites dos edifícios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "Opcional: aumenta os **limites** que um edifício precisa atingir para receber coleta de lixo. \n" +
                    "Aumentar isso pode ajudar a reduzir o tráfego dos caminhões de lixo; mas alto demais reduz as viagens de coleta.\n" +
                    "A maioria das pessoas <não> precisa ajustar isso. O mod já funcionava bem antes dessa opção; é só um bônus para experimentos.\n"+
                    "--------------------------------\n" +
                    "- **Limite de solicitação de despacho (R)** = lixo do edifício necessário para chamar uma <solicitação de despacho de caminhão>.\n" +
                    "- **Limite de coleta (P)** = quantidade mínima de lixo antes que um caminhão possa coletar no edifício.\n" +
                    "**1x** = vanilla (100 R, 20 P). Nota: **1.000** unidades de lixo normalmente são **1t**.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "Com o controle em **20x**, o **R** do edifício precisa chegar a >= **2.000 (2t)** unidades antes que um caminhão receba uma <solicitação de despacho>;\n" +
                    "O jogo vanilla também faz caminhões pararem em edifícios no caminho de ida/volta do edifício de <dispatch> se o caminhão não estiver vazio; em 20x, os edifícios na rota precisam ter mais de **400 de lixo** (20 x P vanilla = 20).\n" +
                    "Dica de equilíbrio: olhe com frequência o botão do relatório detalhado no log enquanto ajusta isso.\n" +
                    "Talvez seja necessário aumentar a capacidade dos caminhões se você subir muito esse limite, porque as casas vão segurar o lixo por muito mais tempo antes de chamar um caminhão."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplicar valores recomendados do Trash Boss:\n" +
                    "- Capacidade de carga: **200%**\n" +
                    "- Limite de despacho: **5x**\n" +
                    "- Velocidade de processamento: **200%**\n" +
                    "- Capacidade de armazenamento: **150%**\n" +
                    "- Quantidade de caminhões da instalação: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Define todos os controles do Trash Boss de volta para os valores vanilla.\n" +
                    "- Os controles em porcentagem voltam para **100%**.\n" +
                    "- O limite de despacho volta para **1x**."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome exibido deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versão atual do mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abrir a página do Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abrir o convite do Discord no navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado Auto Clean>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * O lixo é removido automaticamente - Pronto.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de gerenciamento manual>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajuste os controles como quiser.\n" +
                    "  * Mesmo lixo do jogo; caminhões/instalações autogerenciados melhores.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jogo vanilla normal>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * Todos os controles em valores vanilla\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Lixo/mês" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra a quantidade atual de lixo na cidade inteira e a taxa total de processamento.\n" +
                    "Aumente o processamento se o lixo produzido por mês for muito maior.\n" +
                    "**Produced** e **Processed** usam toneladas por mês.\n" +
                    "<Hora de atualização = última atualização.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Solicitações de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = solicitações de coleta ativas que no momento não estão atribuídas a um caminhão ou rota.\n" +
                    "**Dispatched** = solicitações de coleta ativas já atribuídas.\n" +
                    "**Total** = conta a entidade de solicitação **ativa** atual (na cadeia do lixo).\n\n" +
                    "Nota técnica: isso é diferente de <Acima do limite de solicitação>. Aqui conta <solicitações>, não edifícios.\n" +
                    "Algumas solicitações Pending serão atribuídas depois; outras também podem ser limpas depois se a revalidação vanilla decidir que o alvo não precisa mais de serviço."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Edifícios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tem lixo** = edifícios que atualmente estão segurando lixo.\n" +
                    "**Total** = todos os edifícios que produzem lixo na cidade.\n" +
                    "**Acima do limite de solicitação** = contagem atual de **edifícios** com lixo suficiente para criar uma solicitação de coleta.\n" +
                    "No vanilla, o limite de solicitação é **100** unidades internas de lixo.\n" +
                    "O **limite de despacho** do Trash Boss aumenta juntos os limites de coleta e solicitação.\n" +
                    "Isso reduz o tráfego de caminhões de lixo porque diminui o total de edifícios <acima do limite de solicitação> e o total <dispatched>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumo das instalações de lixo contadas.\n" +
                    "**Facilities** = edifícios de lixo contados.\n" +
                    "**Trucks total** = caminhões de lixo pertencentes a essas instalações.\n" +
                    "**Max workers** = capacidade total de trabalhadores nessas mesmas instalações."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Caminhões" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = caminhões atualmente na cidade.\n" +
                    "**Returning** = subconjunto dos caminhões em movimento marcados para voltar à instalação.\n" +
                    "**Parked** = caminhões estacionados em uma instalação.\n" +
                    "**Total** = quantidade de todos os caminhões de lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Status detalhado no log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envia um relatório mais detalhado do lixo para **Logs/MagicGarbage.log**.\n" +
                    "Inclui uma legenda curta, valores de referência vanilla e muitas estatísticas extras reais do lixo atual da cidade."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abrir a pasta Logs/.. do jogo."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nenhuma cidade carregada ainda." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produzidas | {1:N0} t processadas | atualizado {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pendentes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} têm lixo | {2:N0} acima do limite de solicitação" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalações | {1:N0} caminhões no total | {2:N0} trabalhadores máx." },
                { "MG.Status.Row.Trucks", "{1:N0} em movimento ({3:N0} retornando) | {2:N0} estacionados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Ainda não há dados de instalações." },

                // Log strings
                { "MG.Status.Log.Title", "Status do lixo ({0})" },
                { "MG.Status.Log.City", "Cidade: {0}" },
                { "MG.Status.Log.Mode", "Modo: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produzido/Processado usa toneladas por mês.\n" +
                    "- Os valores de limite abaixo usam unidades internas de lixo, não toneladas.\n" +
                    "- Para o jogador, o jogo converte 1.000 unidades = 1t.\n" +
                    "Controle deslizante de limite de despacho:\n" +
                    "  - Limite de coleta = lixo mínimo antes que um caminhão colete de um prédio.\n" +
                    "  - Limite de solicitação = lixo mínimo antes que o jogo crie ou mantenha uma solicitação de coleta.\n" +
                    "- Ícone de aviso = quantidade de lixo que faz um ícone de aviso aparecer acima de um prédio.\n" +
                    "- Limite máximo = quantidade máxima de lixo que um prédio pode acumular.\n" +
                    "- Pendente = solicitações ativas que atualmente não estão atribuídas a um caminhão nem a um caminho.\n" +
                    "- Algumas solicitações pendentes serão atribuídas depois; outras também podem ser limpas depois se a revalidação vanilla decidir que o alvo não precisa mais de serviço.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Limites do jogo (unidades internas de lixo): coleta={1:N0}, solicitação={0:N0}, ícone de aviso={2:N0}, limite máximo={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Limites: <GarbageParameterData indisponível>" },
                { "MG.Status.Log.GarbageProcessing", "Lixo: {0:N0} t/mês | Processamento: {1:N0} t/mês" },
                { "MG.Status.Log.Requests", "Solicitações de coleta: pendentes={1:N0}, despachadas={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Maior alvo pendente de lixo: {0:N0} ({1:N1}t) em {2}" },
                { "MG.Status.Log.Producers", "Prédios: {0:N0} total | {1:N0} têm lixo | {2:N0} acima do limite de solicitação | {3:N0} em nível de aviso" },
                { "MG.Status.Log.ProducerGarbageStats", "Lixo dos prédios (somente não zero): média={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) em {6}" },
                { "MG.Status.Log.NearWarning75", "Prédios perto do aviso (>= {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalações: {0:N0} total | {1:N0} caminhões no total | {2:N0} trabalhadores máx." },
                { "MG.Status.Log.Trucks", "Caminhões de lixo: {2:N0} em movimento ({3:N0} retornando) | {1:N0} estacionados | {4:N0} desativados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumo das instalações" },
                { "MG.Status.Log.FacilityLine", "- Instalação {0}: em movimento={2:N0}, estacionados={3:N0}, total={1:N0}, trabalhadores máx.={4:N0}" },

            };
        }

        public void Unload()
        {
        }
    }
}
