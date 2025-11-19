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
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "동작" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "정보" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "완전 매직" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "세미 매직" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod 정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용 안내" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)), "매직 쓰레기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**사용 [X]** 시 도시의 모든 쓰레기가 즉시 제거된다.\n" +
                    "외형을 즐기는 목적이 아니라면 쓰레기 처리 건물은 필요하지 않다.\n\n" +
                    "**완전 매직**(선택지 1) 또는 아래 **세미 매직**(선택지 2) 중 하나만 사용한다. 두 옵션을 동시에 켜도 추가 효과는 없다."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "쓰레기차 적재 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**세미 매직**: 고용량 트럭 모드.\n" +
                    "완전 제거가 아니라 난이도만 낮추려면:\n" +
                    "- 매직 쓰레기를 **비활성화** [ ]\n" +
                    "- 슬라이더 **[100 >> 500]** 로 트럭 용량 확대\n\n" +
                    "**---------------------------------------**\n" +
                    " 슬라이더는 바닐라 값 대비 배율 조정.\n" +
                    "**100% = 트럭당 20톤**(바닐라)\n" +
                    "**500% = 트럭당 100톤**\n\n" +
                    "**---------------------------------------**\n\n" +
                    "바닐라로 되돌리려면 매직 쓰레기 [OFF], 슬라이더 100%."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "이 Mod의 표시 이름." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "현재 Mod 버전." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "작성자의 Paradox Mods 페이지 열기." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "CS2 모딩 Discord를 브라우저에서 열기." },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<기본 권장 상태>\n" +
                    "  * 완전 매직 = **[X]**\n" +
                    "  * 슬라이더 = 100%\n" +
                    "  * 모든 쓰레기 즉시 제거\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<세미 매직(고용량 트럭)>\n" +
                    "  * 매직 쓰레기 = **[ ]**\n" +
                    "  * 슬라이더 100–500%로 용량 조정\n" +
                    "  * 바닐라 시뮬레이션 유지, 필요한 트럭 수 감소\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<완전 바닐라>\n" +
                    "  * 매직 쓰레기 = **[ ]**\n" +
                    "  * 슬라이더 = 100% (바닐라)\n" +
                    "  * 표준 게임플레이와 동일."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },
            };
        }

        public void Unload()
        {
        }
    }
}
