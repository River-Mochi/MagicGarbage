// Locale/LocaleKO.cs
// Korean (ko-KR)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "동작" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "정보" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "자동 정리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "직접 관리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용 노트" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "토탈 매직" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**켜짐 [ ✓ ]** 으로 설정하면 도시 전체의 쓰레기가 즉시 모두 제거됩니다.\n" +
                    "쓰레기 처리 건물과 차량은 사실상 장식용이 됩니다.\n\n" +

                    "**토탈 매직** 이 켜져 있는 동안:\n" +
                    "- 세미 매직은 자동으로 꺼집니다.\n" +
                    "- 세미 매직 슬라이더는 모두 무시됩니다.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "세미 매직" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "쓰레기 시스템을 직접 조절하지만, 바닐라 쓰레기 로직은 그대로 유지됩니다.\n\n" +
                    "- **세미 매직이 켜짐 [ ✓ ]** 상태이면 토탈 매직은 자동으로 꺼집니다.\n" +
                    "- 모든 쓰레기 트럭과 시설의 성능을 조정할 수 있습니다.\n" +
                    "- 세미 매직이 활성화 [ ✓ ] 되었을 때만 슬라이더 값이 적용됩니다.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "트럭 적재 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**각 쓰레기 트럭이 운반할 수 있는 쓰레기 양입니다.**\n" +
                    "100% = 기본 게임 설정.\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "시설 트럭 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**각 시설에서 출동시킬 수 있는 트럭 수입니다.**\n" +
                    "100% = 바닐라 기본 트럭 수.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 유입되는 쓰레기를 처리하는 속도입니다.**\n" +
                    "100% = 바닐라 처리 속도.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "시설 저장 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 저장할 수 있는 쓰레기 양입니다.**\n" +
                    "100% = 바닐라 저장 용량.\n" +
                    "값을 올리면 더 많은 쓰레기를 저장할 수 있습니다.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "모든 슬라이더를 **100%** (바닐라 값)으로 되돌립니다.\n" +
                    "기본 게임 동작으로 초기화합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "추천 설정" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "추천 세미 매직 값 적용:\n" +
                    "- 트럭 적재 용량: **200%**\n" +
                    "- 시설 트럭 수: **150%**\n" +
                    "- 처리 속도: **200%**\n" +
                    "- 저장 용량: **150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "이 Mod의 표시 이름입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "현재 Mod 버전입니다."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "작성자의 Mod가 있는 **Paradox Mods** 페이지를 엽니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "브라우저에서 **Discord**(CS2 모딩 서버)를 엽니다."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<자동 정리 상태>\n" +
                    "  * 토탈 매직 ON = **[ ✓ ]**\n" +
                    "  * 모든 쓰레기가 즉시 제거됩니다\n" +
                    " <-------------------------------------->\n\n" +
                    "<직접 관리 상태>\n" +
                    "  * 세미 매직 활성화 = **[ ✓ ]**\n" +
                    "  * 슬라이더 [100 >> 500]를 원하는 대로 조정합니다.\n" +
                    "  * 바닐라 스타일의 쓰레기 시스템에, 조절 가능한 강력한 차량과 시설을 더합니다.\n" +
                    " <-------------------------------------->\n\n" +
                    "<순수 바닐라 게임>\n" +
                    "  * 세미 매직 = **[ ✓ ]**\n" +
                    "  * **[게임 기본값]** 버튼 클릭\n" +
                    "  * 모든 슬라이더 100% (바닐라)\n" +
                    "  * 완전히 기본 게임 플레이.\n"
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
