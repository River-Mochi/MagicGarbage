// File: Locale/LocaleKO.cs
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "작업" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "정보" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "자동 청소" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "직접 관리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "상태" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용 메모" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**활성 [ ✓ ]** 시 도시 전체를 깨끗하게 유지합니다.\n\n" +
                    "**Total Magic** 이 ON 인 동안:\n" +
                    "- Trash Boss 는 강제로 OFF 됩니다.\n" +
                    "- Trash Boss 슬라이더는 적용되지 않습니다 (값은 저장 유지).\n" +
                    "- 바닐라 배차 로직 타이밍 때문에 일부 트럭은 아직 움직일 수 있습니다."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "바닐라 쓰레기 로직은 유지한 채로 쓰레기 시스템을 직접 조정합니다.\n\n" +
                    "- **Trash Boss 가 ON [ ✓ ]** 이면 Total Magic 은 강제로 OFF 됩니다.\n" +
                    "- 슬라이더는 Trash Boss 가 켜져 있을 때만 적용됩니다.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "트럭 적재량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**각 트럭이 운반할 수 있는 쓰레기 양입니다.**\n" +
                    "100% = 게임 기본값.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 들어오는 쓰레기를 처리하는 속도입니다.**\n" +
                    "100% = 바닐라 속도.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "시설 저장 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 저장할 수 있는 쓰레기 양입니다.**\n" +
                    "100% = 바닐라 용량.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "시설 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**각 시설이 내보낼 수 있는 트럭 수입니다.**\n" +
                    "100% = 바닐라 트럭 수.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "추천" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "추천 Trash Boss 값을 적용합니다:\n" +
                    "- 트럭 적재량: **200%**\n" +
                    "- 처리 속도: **200%**\n" +
                    "- 저장 용량: **160%**\n" +
                    "- 시설 트럭 수: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "모든 슬라이더를 **100%** 로 되돌립니다 (바닐라 값)."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "현재 모드 버전입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "브라우저에서 Discord 초대를 엽니다." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<자동 청소 상태>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * 쓰레기를 거의 즉시 제거\n" +
                    " <-------------------------------------->\n\n" +
                    "<직접 관리 상태>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 슬라이더를 원하는 대로 조정\n" +
                    "  * 바닐라 쓰레기 로직 유지 + 트럭/시설 관리 강화\n" +
                    " <-------------------------------------->\n\n" +
                    "<일반 바닐라 상태>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * **[게임 기본값]** 클릭\n" +
                    "  * 모든 슬라이더 100% (바닐라)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "도시 전체의 현재 쓰레기량과 총 처리량을 표시합니다.\n" +
                    "월 Produced 값이 훨씬 높다면 처리량을 올리세요.\n" +
                    "**Produced** 와 **Processed** 는 월간 톤 기준입니다.\n" +
                    "업데이트 시간 = 마지막 갱신 시각."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "수거 요청" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 아직 트럭이나 경로가 배정되지 않은 활성 수거 요청.\n" +
                    "**Dispatched** = 이미 배정된 활성 수거 요청.\n" +
                    "**Total** = 현재 활성 쓰레기 수거 요청 전체.\n" +
                    "오래된 요청은 나중에 게임 재검증으로 정리되기 때문에, 이 수치는 일시적으로 **Above request threshold** 보다 높을 수 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 현재 쓰레기를 가지고 있는 건물.\n" +
                    "**Total** = 도시의 전체 쓰레기 발생 건물 수.\n" +
                    "**Above request threshold** = 수거 요청을 만들 만큼 쓰레기가 쌓인 건물.\n" +
                    "바닐라 기준으로는 보통 <100> 쓰레기 유닛 초과입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "집계된 쓰레기 시설 요약입니다.\n" +
                    "**Facilities** = 집계된 쓰레기 시설 수.\n" +
                    "**Trucks total** = 그 시설들이 보유한 전체 쓰레기 트럭 수.\n" +
                    "**Max workers** = 같은 시설들의 총 최대 노동자 수용량."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 현재 도시 안에서 움직이는 트럭.\n" +
                    "**Returning** = Moving 중 시설로 복귀 중인 트럭.\n" +
                    "**Parked** = 시설에 주차된 트럭.\n" +
                    "**Total** = 전체 쓰레기 트럭 수."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "상세 상태를 로그로" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "**Logs/MagicGarbage.log** 에 자세한 쓰레기 보고서를 기록합니다.\n" +
                    "짧은 범례, 현재 임계값, 비활성 트럭, 시설별 최대 작업자 수를 포함합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Logs/ 폴더를 엽니다."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "아직 도시가 로드되지 않았습니다." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 생성 | {1:N0} t 처리 | 업데이트 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 대기 | {2:N0} 배정됨 | 총 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 쓰레기 있음 | {2:N0} 요청 임계값 초과" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 시설 | 트럭 총 {1:N0} | 최대 작업자 {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} 운행 중 ({3:N0} 복귀 중) | {2:N0} 주차 | 총 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "시설 데이터가 아직 없습니다." },

                // Log strings
                { "MG.Status.Log.Title", "쓰레기 상태 ({0})" },
                { "MG.Status.Log.City", "도시: {0}" },
                { "MG.Status.Log.Mode", "모드: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "범례:\n" +
                    "- Produced/Processed 는 월간 톤 기준입니다.\n" +
                    "- 아래 임계값은 톤이 아니라 내부 쓰레기 유닛입니다.\n" +
                    "- 수거 임계값 = 트럭이 건물에서 수거를 시작하는 최소 쓰레기량.\n" +
                    "- 요청 임계값 = 게임이 수거 요청을 만들거나 유지하는 최소 쓰레기량.\n" +
                    "- 경고 임계값 = 건물 위에 경고 아이콘이 뜰 수 있는 쓰레기량.\n" +
                    "- 상한 = 건물이 누적할 수 있는 최대 쓰레기량.\n" +
                    "- 복귀 중 = 운행 중 트럭의 일부입니다.\n" +
                    "- 활성 요청 수는 오래된 요청이 나중에 바닐라 재검증으로 정리되기 때문에, 일시적으로 요청 임계값 초과 건물 수보다 많을 수 있습니다.\n" +
                    "- 아래 작업자 수치는 현재 각 시설의 **최대 작업자 수** 를 보여줍니다."
                },
                { "MG.Status.Log.Thresholds",
                    "임계값 (내부 쓰레기 유닛): 수거={1:N0}, 요청={0:N0}, 경고={2:N0}, 상한={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "임계값: <GarbageParameterData 사용 불가>" },
                { "MG.Status.Log.GarbageProcessing", "쓰레기: {0:N0} t/월 | 처리: {1:N0} t/월" },
                { "MG.Status.Log.Requests", "수거 요청: 대기={1:N0}, 배정됨={2:N0}, 총={0:N0}" },
                { "MG.Status.Log.Producers", "건물: 총={0:N0} | 쓰레기 있음={1:N0} | 요청 임계값 초과={2:N0} | 경고 레벨={3:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "시설: 총={0:N0} | 트럭 총={1:N0} | 최대 작업자={2:N0}" },
                { "MG.Status.Log.Trucks", "쓰레기 트럭: 운행 중={2:N0} ({3:N0} 복귀 중) | 주차={1:N0} | 비활성={4:N0} | 총={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "시설 요약" },
                { "MG.Status.Log.FacilityLine", "- 시설 {0}: 운행 중={2:N0}, 주차={3:N0}, 총={1:N0}, 최대 작업자={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
