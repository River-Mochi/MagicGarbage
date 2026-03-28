// File: Localization/LocaleZH_HANT.cs
// Chinese Traditional (zh-HANT)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "關於" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自動清理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "手動管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "狀態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "用法" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**啟用 [ ✓ ]** 可讓整座城市保持乾淨。\n\n" +
                    "當 **Total Magic** 為 ON 時：\n" +
                    "- Trash Boss 會被強制設為 OFF。\n" +
                    "- Trash Boss 滑桿不會生效（數值會保留下來，之後再用）。\n" +
                    "- 由於原版調度時機，一些卡車仍可能會移動。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系統；原版垃圾邏輯仍會繼續運作。\n\n" +
                    "- 當 **Trash Boss 為 ON [ ✓ ]** 時，Total Magic 會被強制設為 OFF。\n" +
                    "- 滑桿只有在啟用 Trash Boss 時才會生效。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡車載重" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛卡車能運多少垃圾。**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "設施儲存量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**設施能儲存多少垃圾。**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "設施處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**設施處理流入垃圾的速度。**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "設施車隊" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個設施能派出多少輛卡車。**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "建築門檻" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "可選：提高建築取得垃圾收集服務所需達到的**門檻**。 \n" +
                    "提高它可以減少垃圾車交通；但太高會減少收運次數。\n" +
                    "大多數人<不>需要調整這個。在加入此選項之前模組就已經運作良好，這只是做實驗用的額外選項。\n"+
                    "--------------------------------\n" +
                    "- **派車請求門檻 (R)** = 建築需要達到的垃圾量，才能觸發 <卡車派車請求>。\n" +
                    "- **拾取門檻 (P)** = 卡車能從建築收集垃圾前所需的最低垃圾量。\n" +
                    "**1x** = 原版 (100 R, 20 P)。注意：**1,000** 垃圾單位通常等於 **1t**。\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "當滑桿為 **20x** 時，建築的 **R** 必須達到 >= **2,000 (2t)** 單位，卡車才會收到 <派車請求>；\n" +
                    "原版遊戲中，如果卡車不是空的，它在前往/返回 <dispatch> 建築途中也會在其他建築停靠；在 20x 時，沿途建築需要超過 **400 垃圾**（20 x 原版 P = 20）。\n" +
                    "平衡建議：調整此值時，請經常查看詳細日誌報告按鈕。\n" +
                    "如果把門檻調得很高，房屋會在呼叫卡車前囤積垃圾更久，因此可能也需要提高卡車容量。"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "套用推薦的 Trash Boss 數值：\n" +
                    "- 卡車載重：**200%**\n" +
                    "- 派車門檻：**5x**\n" +
                    "- 處理速度：**200%**\n" +
                    "- 儲存容量：**150%**\n" +
                    "- 設施卡車數量：**140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "遊戲預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "將所有 Trash Boss 滑桿恢復為原版數值。\n" +
                    "- 百分比滑桿恢復到 **100%**。\n" +
                    "- 派車門檻恢復到 **1x**。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "目前模組版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "開啟 Paradox Mods 頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在瀏覽器中開啟 Discord 邀請。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動清理狀態>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * 垃圾會自動清除 - 完成。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理狀態>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 依照需要設定滑桿。\n" +
                    "  * 遊戲垃圾機制不變；只是更適合手動管理的卡車/設施。\n" +
                    " <-------------------------------------->\n\n" +
                    "<一般原版遊戲>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * 所有滑桿都為原版數值\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "顯示目前全城垃圾量與總處理速率。\n" +
                    "如果每月產生的垃圾明顯更高，請提高處理能力。\n" +
                    "**Produced** 和 **Processed** 使用每月噸數。\n" +
                    "<更新時間 = 上次重新整理。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集請求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 目前尚未分配給卡車或路徑的有效收集請求。\n" +
                    "**Dispatched** = 已經分配的有效收集請求。\n" +
                    "**Total** = 目前**有效**請求實體總數（在垃圾流程中）。\n\n" +
                    "技術說明：這和 <超過請求門檻> 不同。這裡統計的是 <請求>，不是建築。\n" +
                    "一些 Pending 請求之後會被分配；如果原版重新驗證後認為目標已不再需要服務，也有一些會在之後被清除。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 目前持有垃圾的建築。\n" +
                    "**Total** = 城市中所有會產生垃圾的建築。\n" +
                    "**超過請求門檻** = 目前垃圾足夠產生收集請求的**建築**數量。\n" +
                    "原版中，請求門檻為 **100** 內部垃圾單位。\n" +
                    "Trash Boss 的 **派車門檻** 會同時提高拾取門檻與請求門檻。\n" +
                    "這會降低垃圾車交通，因為 <超過請求門檻> 的建築數量與 <已派發> 總量都會下降。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已統計垃圾設施的摘要。\n" +
                    "**Facilities** = 已統計的垃圾建築。\n" +
                    "**Trucks total** = 這些設施擁有的垃圾車總數。\n" +
                    "**Max workers** = 這些設施的總最大工人數。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 目前在城市中行駛的卡車。\n" +
                    "**Returning** = 正在移動且被標記為返回設施的卡車子集。\n" +
                    "**Parked** = 停在設施中的卡車。\n" +
                    "**Total** = 所有垃圾車總數。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "將詳細狀態寫入日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "把更詳細的垃圾報告寫入 **Logs/MagicGarbage.log**。\n" +
                    "包括簡短圖例、原版參考值，以及很多目前城市垃圾統計資料。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "開啟遊戲的 Logs/.. 資料夾。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未載入城市。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} 噸已產生 | {1:N0} 噸已處理 | 更新於 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 個待處理 | {2:N0} 個已派遣 | 共 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高於請求門檻" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 座設施 | 卡車總數 {1:N0} | 最大工人人數 {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} 輛移動中（{3:N0} 輛返程中） | {2:N0} 輛已停放 | 共 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "目前沒有設施資料。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾狀態 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "說明：\n" +
                    "- 產生/處理 使用每月噸數。\n" +
                    "- 下方門檻值使用內部垃圾單位，而不是噸。\n" +
                    "- 面向玩家顯示時，遊戲會把 1,000 單位換算為 1t。\n" +
                    "派遣門檻滑桿：\n" +
                    "  - 收集門檻 = 卡車可以從建築收集垃圾前所需的最小垃圾量。\n" +
                    "  - 請求門檻 = 遊戲建立或保留收集請求前所需的最小垃圾量。\n" +
                    "- 警告圖示 = 會讓建築上方出現警告圖示的垃圾量。\n" +
                    "- 硬上限 = 建築可累積的最大垃圾量。\n" +
                    "- 待處理 = 目前尚未指派給卡車或路徑的有效請求。\n" +
                    "- 有些待處理請求之後會被指派；如果 vanilla 重新驗證後判定目標不再需要服務，另一些之後也可能被清除。\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "遊戲門檻（內部垃圾單位）：收集={1:N0}、請求={0:N0}、警告圖示={2:N0}、硬上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "門檻：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 處理：{1:N0} t/月" },
                { "MG.Status.Log.Requests", "收集請求：待處理={1:N0}、已派遣={2:N0}、總計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待處理目標最高垃圾量：{0:N0}（{1:N1}t）位置 {2}" },
                { "MG.Status.Log.Producers", "建築：總計 {0:N0} | 有垃圾 {1:N0} | 高於請求門檻 {2:N0} | 警告等級 {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "建築垃圾（僅非零）：平均={0:N0}（{1:N1}t） | 中位數={2:N0}（{3:N1}t） | 最大={4:N0}（{5:N1}t）位置 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告的建築（>= {1:N0} 單位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "設施：總計 {0:N0} | 卡車總數 {1:N0} | 最大工人人數 {2:N0}" },
                { "MG.Status.Log.Trucks", "垃圾卡車：移動中 {2:N0}（返程中 {3:N0}） | 已停放 {1:N0} | 已停用 {4:N0} | 總計 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "設施摘要" },
                { "MG.Status.Log.FacilityLine", "- 設施 {0}：移動中={2:N0}、已停放={3:N0}、總計={1:N0}、最大工人人數={4:N0}" },





            };
        }

        public void Unload()
        {
        }
    }
}
