// Locale/LocaleZH_HANT.cs
// Chinese (Traditional) (zh-HANT)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_HANT(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "關於" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "完全魔法" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "半魔法模式" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用說明" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)), "魔法垃圾" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**啟用 [X]** 後，城市內的所有垃圾將會立即清除。\n" +
                    "除非單純作為視覺擺設，否則不再需要垃圾處理建築。\n\n" +
                    "僅使用 **完全魔法**（選項 1）或下方 **半魔法模式**（選項 2）之一；同時啟用不會有額外效果。"
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "垃圾車容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**半魔法模式**：高容量垃圾車。\n" +
                    "若只想降低難度而非完全移除機制：\n" +
                    "- 將「魔法垃圾」設為 **關閉** [ ]\n" +
                    "- 使用滑桿 **[100 >> 500]** 提升每車容量\n\n" +
                    "**---------------------------------------**\n" +
                    " 滑桿依相對於原版數值進行倍率調整。\n" +
                    "**100% = 每車 20 噸**（原版）\n" +
                    "**500% = 每車 100 噸**\n\n" +
                    "**---------------------------------------**\n\n" +
                    "若要恢復原版行為：關閉魔法垃圾並將滑桿調回 100%。"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模組於選單中的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "目前的模組版本。" },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "開啟作者在 Paradox Mods 的頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在瀏覽器中開啟 CS2 模組 Discord 伺服器。" },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<建議的預設狀態>\n" +
                    "  * 完全魔法 = **[ON]**\n" +
                    "  * 滑桿 = 100%\n" +
                    "  * 全城垃圾立即清除\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<半魔法（高容量垃圾車）>\n" +
                    "  * 魔法垃圾 = **[OFF]**\n" +
                    "  * 滑桿 100–500% 提升容量\n" +
                    "  * 維持原版模擬、所需車輛更少\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<完全原版>\n" +
                    "  * 魔法垃圾 = **[OFF]**\n" +
                    "  * 滑桿 = 100%（原版限制）\n" +
                    "  * 與標準遊玩一致。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },
            };
        }

        public void Unload()
        {
        }
    }
}
