// File: Localization/LocaleKO.cs
// Korean (ko-KR)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "완전 자동 청소" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**활성화 [ ✓ ]** 하면 도시 전체를 깨끗하게 유지합니다.\n\n" +
                    "**완전 자동 청소** 가 ON 인 동안:\n" +
                    "- 쓰레기 관리 는 강제로 OFF 됩니다.\n" +
                    "- 쓰레기 관리 슬라이더는 적용되지 않습니다 (값은 나중에 다시 쓰도록 저장됨).\n" +
                    "- vanilla 배차 타이밍 때문에 일부 차량은 여전히 움직일 수 있습니다."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "쓰레기 관리" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "쓰레기 시스템을 직접 조절합니다. vanilla 쓰레기 로직은 그대로 돌아갑니다.\n\n" +
                    "- **쓰레기 관리 가 ON [ ✓ ]** 이면 완전 자동 청소 는 강제로 OFF 됩니다.\n" +
                    "- 슬라이더는 쓰레기 관리 가 켜져 있을 때만 적용됩니다.\n" +
                    "- **상태 보고서** 만 필요하면 완전 자동 청소 와 쓰레기 관리 를 둘 다 **OFF** 로 둘 수 있습니다.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "트럭 적재량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**각 트럭이 운반할 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = 기본** 게임 값입니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "시설 저장량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 저장할 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = vanilla** 저장량입니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "시설 처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 들어온 쓰레기를 처리하는 속도입니다.**\n" +
                    "**100% = vanilla** 처리 속도입니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "시설 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**각 시설이 출동시킬 수 있는 트럭 수입니다.**\n" +
                    "**100% = vanilla** 트럭 수입니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "고급 설정" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**임계값 + 쓰레기 행복도용 선택형 고급 튜닝입니다.**\n" +
                    "**OFF** 이면 수거/요청 임계값과 쓰레기 행복도는 **vanilla 그대로** 유지됩니다.\n" +
                    "**ON** 이면 고급 **슬라이더가 표시** 됩니다.\n\n" +
                    "<--- 쓰레기 행복도 예시 --->\n" +
                    " - <Vanilla> 100/65 = 첫 패널티가 <165>.\n" +
                    " - <추천> 550/150 = 첫 패널티가 <700>.\n" +
                    " - <매우 완화> 950/200 = 첫 쓰레기 패널티가 <1150>.\n" +
                    "편의 기능: 이 옵션이 OFF 여도 마지막 슬라이더 값은 저장됩니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "배차 요청 임계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**건물 쓰레기가 이 수치 이상이면 트럭 배차 요청이 생성되거나 유지됩니다.**\n" +
                    "Vanilla = **100** 쓰레기 유닛.\n" +
                    "**100 쓰레기 유닛 = 0.1t**\n" +
                    "**1,000 쓰레기 유닛 = 1t**\n" +
                    "이 값은 수거 임계값 이상으로 유지하세요.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "수거 임계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**트럭이 수거할 수 있게 되는 최소 건물 쓰레기량입니다.**\n" +
                    "Vanilla = **20** 쓰레기 유닛.\n" +
                    "수거 임계값은 배차 요청 임계값보다 높을 수 없습니다.\n" +
                    "로직 꼬임을 막으려면 배차 요청 임계값을 항상 수거 가능 값 이상으로 유지하세요;" +
                    " 트럭이 건물로 dispatch 됐는데 수거 값이 더 높으면 실제로 수거를 못 할 수도 있습니다 (축적 속도도 영향).\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "추천" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**추천** 표준 쓰레기 관리 값을 적용합니다.\n" +
                    "고급 설정 값은 바꾸지 않습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "쓰레기 관리 슬라이더를 **vanilla 값** 으로 되돌립니다.\n" +
                    "고급 설정 값은 <not> 바꾸지 않습니다.\n" +
                    "**Vanilla:**\n" +
                    "- 퍼센트 슬라이더는 **100%** 로 돌아갑니다.\n" +
                    "- 배차 요청 임계값은 **100 units** 로 돌아갑니다.\n" +
                    "- 수거 임계값은 **20 units** 로 돌아갑니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "쓰레기 행복도 기준값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**건물 쓰레기가 건강 + 행복도 페널티를 받기 시작하기 전의 기준값입니다.**\n" +
                    "**Vanilla = 100** 쓰레기 유닛.\n" +
                    "기준값이 높을수록 패널티 시작 전까지 건물이 더 많은 쓰레기를 버틸 수 있습니다.\n" +
                    "100 쓰레기 유닛 = 0.1t\n" +
                    "개요:\n" +
                    "- <임계값> = 시스템 동작이 시작되는 지점\n" +
                    "- <기준값> = 페널티 계산식의 시작점\n" +
                    "- <단계값> = 계산식 증가폭, 즉 페널티가 얼마나 빨리 커지는지"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "쓰레기 행복도 단계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**기준값을 넘은 추가 쓰레기량이 -1 패널티를 시작하게 만듭니다.**\n" +
                    "Vanilla = **65** 쓰레기 유닛.\n" +
                    "단계값이 높을수록 패널티 증가가 느려집니다.\n" +
                    "게임의 쓰레기 패널티는 **-10** 까지만 적용됩니다.\n" +
                    "vanilla 첫 <-1 penalty> 는 **165 쓰레기** 에서 발생합니다 (100 baseline + 65 step)\n" +
                    "임계값을 바꿨다면 행복도 슬라이더도 같이 조절하지 않으면 평소보다 더 큰 패널티가 생길 수 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "추천" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "**추천** 고급 설정 값을 적용합니다.\n" +
                    "고급 설정 을 ON 으로 바꿉니다.\n" +
                    "첫 쓰레기 패널티는 **700** 쓰레기에서 시작합니다 (550 baseline + 150 step)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "고급 설정 값을 **vanilla** 로 되돌립니다.\n" +
                    "**고급 설정 을 OFF** 로 바꿉니다."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "현재 모드 버전입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "브라우저에서 Discord 초대 링크를 엽니다." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<자동 청소 상태>\n" +
                    "  * 완전 자동 청소 ON  = **[ ✓ ]**\n" +
                    "  * 쓰레기 자동 제거 - 끝.\n" +
                    " <-------------------------------------->\n\n" +
                    "<직접 관리 상태>\n" +
                    "  * 쓰레기 관리 = **[ ✓ ]**\n" +
                    "  * 원하는 대로 슬라이더를 조절하세요.\n" +
                    "  * 필요하면 고급 설정 을 켜서 임계값 + 쓰레기 행복도를 조절하세요.\n" +
                    "  * 게임 원래 쓰레기 시스템은 그대로, 트럭/시설만 더 잘 관리합니다.\n" +
                    " <-------------------------------------->\n\n" +
                    "<상태 / vanilla 상태>\n" +
                    "  * 완전 자동 청소 = OFF\n" +
                    "  * 쓰레기 관리 = OFF\n" +
                    "  * 상태 보고서만 사용.\n" +
                    "  * vanilla 쓰레기 게임은 그대로 유지됩니다."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "사용법" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "현재 도시 전체 쓰레기량과 총 처리량을 보여줍니다.\n" +
                    "월간 생산량이 훨씬 높다면 처리량을 올리세요.\n" +
                    "**Produced** 와 **Processed** 는 월당 톤 기준입니다.\n" +
                    "<업데이트 시간 = 마지막 새로고침 시각.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "수거 요청" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**대기 중** = 아직 트럭이나 경로에 배정되지 않은 활성 수거 요청입니다.\n" +
                    "**배차됨** = 이미 배정된 활성 수거 요청입니다.\n" +
                    "**합계** = 현재 **활성** 요청 엔티티 수입니다 (쓰레기 파이프라인 기준).\n\n" +
                    "기술 메모: 이것은 <요청 임계값 초과> 와 다릅니다. 여기서는 건물이 아니라 <요청> 을 셉니다.\n" +
                    "일부 대기 중 요청은 나중에 배정되고, vanilla 재검증에서 대상이 더 이상 필요 없다고 판단되면 사라질 수도 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**쓰레기 있음** = 현재 쓰레기를 가지고 있는 건물입니다.\n" +
                    "**합계** = 도시의 모든 쓰레기 생산 건물 수입니다.\n" +
                    "**요청 임계값 초과** = 수거 요청을 만들 만큼 쓰레기가 쌓인 **건물** 수입니다.\n" +
                    "vanilla 에서 요청 임계값은 내부 쓰레기 유닛 **100** 입니다.\n" +
                    "고급 설정 으로 요청/수거 임계값을 덮어쓸 수 있습니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "집계된 쓰레기 시설 요약입니다.\n" +
                    "**시설** = 집계된 쓰레기 시설 수입니다.\n" +
                    "**쓰레기 트럭** = 일반 수거 트럭입니다. 산업폐기물 시설에서는 일반 쓰레기 대신 산업폐기물을 수거합니다.\n" +
                    "**Dump trucks** = 시설 간 쓰레기 이동입니다.\n" +
                    "**최대 노동자 수** = 같은 시설들의 총 최대 노동자 수입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**이동 중** = 현재 도시에서 움직이고 있는 트럭입니다.\n" +
                    "**복귀 중** = 움직이는 트럭 중 시설로 돌아가는 차량입니다.\n" +
                    "**주차 중** = 시설에 주차된 트럭입니다.\n" +
                    "**합계** = 전체 쓰레기 트럭 수입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "상세 상태를 로그로" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "더 자세한 쓰레기 보고서를 **Logs/MagicGarbage.log** 에 기록합니다.\n" +
                    "짧은 범례, vanilla 기준값, 실제 도시 통계 여러 가지가 들어갑니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "게임 Logs/.. 폴더를 엽니다."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "아직 도시가 로드되지 않았습니다." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 생산 | {1:N0} t 처리 | 갱신 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 대기 중 | {2:N0} 배차됨 | {0:N0} 합계" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 쓰레기 있음 | {2:N0} 요청 임계값 초과" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 시설 | {1:N0} 쓰레기 트럭 | {2:N0} dump trucks | {3:N0} 최대 노동자" },
                { "MG.Status.Row.Trucks", "{1:N0} 이동 중 ({3:N0} 복귀 중) | {2:N0} 주차 중 | {0:N0} 합계" },
                { "MG.Status.Row.FacilitiesNone", "아직 시설 데이터가 없습니다." },

                // Log strings
                { "MG.Status.Log.Title", "쓰레기 상태 ({0})" },
                { "MG.Status.Log.City", "도시: {0}" },
                { "MG.Status.Log.Mode", "모드: 완전 자동 청소={0}, 쓰레기 관리={1}" },
                { "MG.Status.Log.Legend",
                    "범례:\n" +
                    "- Produced/Processed 는 월당 톤 기준입니다.\n" +
                    "- 아래 임계값은 톤이 아니라 내부 쓰레기 유닛을 사용합니다.\n" +
                    "- 플레이어 표시 기준으로 게임은 100 units = 0.1t, 1,000 units = 1t 로 변환합니다.\n" +
                    "임계값 슬라이더:\n" +
                    "  - 수거 임계값 = 건물에서 트럭이 수거할 수 있게 되는 최소 쓰레기량.\n" +
                    "  - 요청 임계값 = 게임이 수거 요청을 생성하거나 유지하는 최소 쓰레기량.\n" +
                    "- 경고 아이콘 = 건물 위에 경고 아이콘이 뜨는 쓰레기량.\n" +
                    "- 최대 한도 = 건물이 쌓을 수 있는 최대 쓰레기량.\n" +
                    "- 대기 중 = 아직 트럭이나 경로에 배정되지 않은 활성 요청.\n" +
                    "- 일부 대기 중 요청은 나중에 배정되고, vanilla 재검증에서 대상이 더 이상 필요 없다고 판단되면 사라질 수도 있습니다.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "게임 임계값 (내부 쓰레기 유닛): 수거={1:N0}, 요청={0:N0}, 경고 아이콘={2:N0}, 최대 한도={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "임계값: <GarbageParameterData 없음>" },
                { "MG.Status.Log.GarbageProcessing", "쓰레기: {0:N0} t/월 | 처리: {1:N0} t/월" },
                { "MG.Status.Log.Requests", "수거 요청: 대기 중={1:N0}, 배차됨={2:N0}, 합계={0:N0}" },
                { "MG.Status.Log.PendingPeak", "가장 높은 대기 중 대상: {0:N0} ({1:N1}t) 위치 {2}" },
                { "MG.Status.Log.Producers", "건물: {0:N0} 합계 | {1:N0} 쓰레기 있음 | {2:N0} 요청 임계값 초과 | {3:N0} 경고 레벨" },
                { "MG.Status.Log.ProducerGarbageStats", "건물 쓰레기 (0 초과만): 평균={0:N0} ({1:N1}t) | 중앙값={2:N0} ({3:N1}t) | 최대={4:N0} ({5:N1}t) 위치 {6}" },
                { "MG.Status.Log.NearWarning75", "경고 근처 건물 (최소 {1:N0} 유닛 / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "시설: {0:N0} 합계 | {1:N0} 쓰레기 트럭 | {2:N0} dump trucks ({3:N0} 이동 중) | {4:N0} 노동자" },
                { "MG.Status.Log.Trucks", "쓰레기 트럭: {2:N0} 이동 중 ({3:N0} 복귀 중) | {1:N0} 주차 중 | {4:N0} 비활성 | {0:N0} 합계" },
                { "MG.Status.Log.FacilitiesHeader", "시설 요약" },
                { "MG.Status.Log.FacilityLine", "- 시설 {0}: 쓰레기={1:N0} ({2:N0} 이동 중, {3:N0} 주차 중) | dump={4:N0} ({5:N0} 이동 중) | 최대 노동자={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
