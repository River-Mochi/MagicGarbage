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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "동작" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "정보" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "자동 청소" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "직접 관리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "상태" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용법" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**활성화 [ ✓ ]** 하면 도시 전체가 깨끗하게 유지됩니다.\n\n" +
                    "**Total Magic** 가 ON 인 동안:\n" +
                    "- Trash Boss 는 OFF 로 강제됩니다.\n" +
                    "- Trash Boss 슬라이더는 적용되지 않습니다(값은 나중을 위해 저장됨).\n" +
                    "- 바닐라 배차 타이밍 때문에 일부 트럭은 여전히 움직일 수 있습니다."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "쓰레기 시스템을 직접 관리합니다. 바닐라 쓰레기 로직은 그대로 유지됩니다.\n\n" +
                    "- **Trash Boss 가 ON [ ✓ ]** 이면 Total Magic 은 OFF 로 강제됩니다.\n" +
                    "- 슬라이더는 Trash Boss 가 켜졌을 때만 적용됩니다.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "트럭 적재량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**각 트럭이 운반할 수 있는 쓰레기 양.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "시설 저장량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 저장할 수 있는 쓰레기 양.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "시설 처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 들어온 쓰레기를 처리하는 속도.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "시설 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**각 시설이 내보낼 수 있는 트럭 수.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "건물 임계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "선택 사항: 건물이 쓰레기 수거를 받기 위해 필요한 **임계값**을 올립니다. \n" +
                    "이 값을 올리면 쓰레기 트럭 교통을 줄이는 데 도움이 될 수 있지만, 너무 높으면 수거 횟수가 줄어듭니다.\n" +
                    "대부분의 사람은 이 값을 조정할 필요가 <없습니다>. 이 옵션이 추가되기 전에도 모드는 잘 작동했고, 이건 실험용 보너스입니다.\n"+
                    "--------------------------------\n" +
                    "- **배차 요청 임계값 (R)** = <트럭 배차 요청>을 부르기 위해 필요한 건물 쓰레기 양.\n" +
                    "- **수거 임계값 (P)** = 트럭이 해당 건물에서 수거할 수 있는 최소 쓰레기 양.\n" +
                    "**1x** = 바닐라 (R 100, P 20). 참고: **1,000** 쓰레기 유닛은 보통 **1t** 입니다.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "슬라이더가 **20x** 일 때, 건물의 **R** 은 트럭이 <배차 요청>을 받기 전에 **2,000 (2t)** 유닛 이상이어야 합니다.\n" +
                    "바닐라 게임에서도 트럭이 비어 있지 않으면 <dispatch> 건물로 가거나 돌아오는 길에 다른 건물에 정차합니다. 20x 에서는 경로상의 건물이 **400 쓰레기** 이상이어야 합니다 (20 x 바닐라 P = 20).\n" +
                    "밸런스 팁: 이 값을 조정할 때는 상세 로그 리포트 버튼을 자주 확인하세요.\n" +
                    "임계값을 높이면 집이 트럭을 부르기 전까지 쓰레기를 더 오래 쌓아 두게 되므로, 트럭 적재량도 올려야 할 수 있습니다."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "추천" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "추천 Trash Boss 값 적용:\n" +
                    "- 트럭 적재량: **200%**\n" +
                    "- 배차 임계값: **5x**\n" +
                    "- 처리 속도: **200%**\n" +
                    "- 저장 용량: **150%**\n" +
                    "- 시설 트럭 수: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "모든 Trash Boss 슬라이더를 바닐라 값으로 되돌립니다.\n" +
                    "- 퍼센트 슬라이더는 **100%** 로 돌아갑니다.\n" +
                    "- 배차 임계값은 **1x** 로 돌아갑니다."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "현재 모드 버전입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "브라우저에서 Discord 초대를 엽니다." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<자동 청소 상태>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * 쓰레기가 자동 제거됨 - 끝.\n" +
                    " <-------------------------------------->\n\n" +
                    "<직접 관리 상태>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 원하는 대로 슬라이더 조정.\n" +
                    "  * 게임의 쓰레기 시스템은 같고, 트럭/시설만 더 잘 직접 관리됨.\n" +
                    " <-------------------------------------->\n\n" +
                    "<일반 바닐라 게임>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * 모든 슬라이더가 바닐라 값\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "사용법" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "현재 도시 전체 쓰레기 양과 총 처리 속도를 보여줍니다.\n" +
                    "월간 생산 쓰레기가 훨씬 많다면 처리량을 올리세요.\n" +
                    "**Produced** 와 **Processed** 는 월간 톤 단위입니다.\n" +
                    "<업데이트 시간 = 마지막 새로고침.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "수거 요청" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 현재 트럭이나 경로에 배정되지 않은 활성 수거 요청.\n" +
                    "**Dispatched** = 이미 배정된 활성 수거 요청.\n" +
                    "**Total** = 현재 **활성** 요청 엔티티 수(쓰레기 파이프라인 안).\n\n" +
                    "기술 메모: 이것은 <요청 임계값 초과> 와 다릅니다. 여기서는 건물이 아니라 <요청> 을 셉니다.\n" +
                    "일부 Pending 요청은 나중에 배정되고, 바닐라 재검증에서 대상이 더 이상 서비스가 필요 없다고 판단되면 나중에 사라질 수도 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**쓰레기 있음** = 현재 쓰레기를 들고 있는 건물.\n" +
                    "**Total** = 도시의 모든 쓰레기 생산 건물.\n" +
                    "**요청 임계값 초과** = 수거 요청을 만들 만큼 쓰레기가 있는 **건물** 수.\n" +
                    "바닐라에서 요청 임계값은 내부 쓰레기 유닛 **100** 입니다.\n" +
                    "Trash Boss **배차 임계값** 은 수거/요청 임계값을 함께 올립니다.\n" +
                    "이렇게 하면 <요청 임계값 초과> 건물 수와 <배차됨> 총량이 줄어들어 쓰레기 트럭 교통이 감소합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "집계된 쓰레기 시설 요약.\n" +
                    "**Facilities** = 집계된 쓰레기 건물.\n" +
                    "**Trucks total** = 해당 시설이 보유한 쓰레기 트럭 수.\n" +
                    "**Max workers** = 같은 시설들의 최대 노동자 수 총합."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 현재 도시 안을 움직이는 트럭.\n" +
                    "**Returning** = 시설로 돌아가도록 표시된 이동 중 트럭의 부분집합.\n" +
                    "**Parked** = 시설에 주차된 트럭.\n" +
                    "**Total** = 모든 쓰레기 트럭 수."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "상세 상태를 로그로" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "더 자세한 쓰레기 리포트를 **Logs/MagicGarbage.log** 로 보냅니다.\n" +
                    "짧은 범례, 바닐라 기준값, 실제 도시 쓰레기 통계를 많이 포함합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "게임의 Logs/.. 폴더를 엽니다."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "아직 불러온 도시가 없습니다." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0}t 배출 | {1:N0}t 처리 | 갱신 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 대기 | {2:N0} 배차됨 | 총 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 건물에 쓰레기 있음 | {2:N0}개가 요청 임계치 초과" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0}개 시설 | 트럭 총 {1:N0}대 | 최대 작업자 {2:N0}명" },
                { "MG.Status.Row.Trucks", "{1:N0}대 이동 중 ({3:N0}대 복귀 중) | {2:N0}대 주차됨 | 총 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "아직 시설 데이터가 없습니다." },

                // Log strings
                { "MG.Status.Log.Title", "쓰레기 상태 ({0})" },
                { "MG.Status.Log.City", "도시: {0}" },
                { "MG.Status.Log.Mode", "모드: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "범례:\n" +
                    "- 배출/처리는 월당 톤 단위를 사용합니다.\n" +
                    "- 아래 임계값은 톤이 아니라 내부 쓰레기 유닛을 사용합니다.\n" +
                    "- 플레이어 표시용으로 게임은 1,000 유닛 = 1t로 변환합니다.\n" +
                    "배차 임계값 슬라이더:\n" +
                    "  - 수거 임계값 = 트럭이 건물에서 수거할 수 있는 최소 쓰레기량.\n" +
                    "  - 요청 임계값 = 게임이 수거 요청을 생성하거나 유지하는 최소 쓰레기량.\n" +
                    "- 경고 아이콘 = 건물 위에 경고 아이콘이 나타나는 쓰레기량.\n" +
                    "- 하드 캡 = 건물이 누적할 수 있는 최대 쓰레기량.\n" +
                    "- 대기 = 현재 트럭이나 경로에 배정되지 않은 활성 요청.\n" +
                    "- 일부 대기 요청은 나중에 배정되고, 다른 일부는 vanilla 재검증에서 대상에 더 이상 서비스가 필요 없다고 판단하면 나중에 사라질 수도 있습니다.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "게임 임계값 (내부 쓰레기 유닛): 수거={1:N0}, 요청={0:N0}, 경고 아이콘={2:N0}, 하드 캡={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "임계값: <GarbageParameterData 사용 불가>" },
                { "MG.Status.Log.GarbageProcessing", "쓰레기: {0:N0}t/월 | 처리: {1:N0}t/월" },
                { "MG.Status.Log.Requests", "수거 요청: 대기={1:N0}, 배차됨={2:N0}, 총={0:N0}" },
                { "MG.Status.Log.PendingPeak", "가장 큰 대기 대상 쓰레기: {0:N0} ({1:N1}t) 위치 {2}" },
                { "MG.Status.Log.Producers", "건물: 총 {0:N0} | 쓰레기 있음 {1:N0} | 요청 임계치 초과 {2:N0} | 경고 레벨 {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "건물 쓰레기 (0 초과만): 평균={0:N0} ({1:N1}t) | 중앙값={2:N0} ({3:N1}t) | 최대={4:N0} ({5:N1}t) 위치 {6}" },
                { "MG.Status.Log.NearWarning75", "경고 근접 건물 (>= {1:N0} 유닛 / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "시설: 총 {0:N0} | 트럭 총 {1:N0}대 | 최대 작업자 {2:N0}명" },
                { "MG.Status.Log.Trucks", "쓰레기 트럭: 이동 중 {2:N0}대 ({3:N0}대 복귀 중) | 주차됨 {1:N0}대 | 비활성 {4:N0}대 | 총 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "시설 요약" },
                { "MG.Status.Log.FacilityLine", "- 시설 {0}: 이동 중={2:N0}, 주차됨={3:N0}, 총={1:N0}, 최대 작업자={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
