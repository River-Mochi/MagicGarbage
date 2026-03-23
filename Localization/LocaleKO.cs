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
            return new Dictionary<string, string>
            {
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "작업" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "정보" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "자동 청소" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "수동 관리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크"      },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용법"    },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "토탈 매직" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**활성 [ ✓ ]** 시 도시의 모든 쓰레기를 즉시 제거합니다.\n\n" +

                    "**토탈 매직** 이 ON인 동안:\n" +
                    "- 세미 매직은 강제로 OFF 됩니다.\n" +
                    "- 세미 매직 슬라이더는 **적용되지 않습니다** (값은 나중을 위해 저장됩니다).\n" +
                    "- 게임의 배차 로직 때문에 소수의 트럭이 돌아다닐 수 있습니다 (대부분 비어 있음)."
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "세미 매직" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "쓰레기 시스템을 직접 조정합니다 (바닐라 쓰레기 로직은 계속 실행).\n\n" +
                    "- **세미 매직 ON [ ✓ ]** 이면 토탈 매직은 자동으로 OFF 됩니다.\n" +
                    "- 슬라이더는 세미 매직이 ON일 때만 적용됩니다 [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "트럭 적재 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**트럭 1대가 운반할 수 있는 쓰레기 양.**\n" +
                    "100% = 게임 기본값.\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 쓰레기를 처리하는 속도.**\n" +
                    "100% = 바닐라 처리 속도.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "시설 저장 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 저장할 수 있는 쓰레기 양.**\n" +
                    "100% = 바닐라 용량.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "시설 트럭 수"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**시설이 출동시킬 수 있는 트럭 수.**\n" +
                    "100% = 바닐라 트럭 수.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "추천" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "추천 세미 매직 값 적용:\n" +
                    "- 트럭 적재 용량: **200%**\n" +
                    "- 처리 속도: **200%**\n" +
                    "- 저장 용량: **160%**\n" +
                    "- 시설 트럭 수: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "모든 슬라이더를 **100%**(바닐라 값)로 되돌립니다.\n" +
                    "기본 게임 동작으로 복원합니다."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "이 모드의 표시 이름."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "현재 모드 버전."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "작성자 모드의 **Paradox Mods** 페이지를 엽니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "CS2 모딩 **Discord** 를 브라우저에서 엽니다."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<자동 청소 상태>\n" +
                    "  * 토탈 매직 ON = **[ ✓ ]**\n" +
                    "  * 모든 쓰레기 즉시 제거\n" +
                    " <-------------------------------------->\n\n" +
                    "<수동 관리 상태>\n" +
                    "  * 세미 매직 ON = **[ ✓ ]**\n" +
                    "  * 슬라이더를 원하는 대로 조정.\n" +
                    "  * 바닐라 쓰레기 로직 + 조정된 트럭/시설.\n" +
                    " <-------------------------------------->\n\n" +
                    "<일반 바닐라 게임>\n" +
                    "  * 세미 매직 ON = **[ ✓ ]**\n" +
                    "  * **[게임 기본값]** 클릭\n" +
                    "  * 모든 슬라이더 100% (바닐라)\n"
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
