// File: Localization/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT)

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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "進階模式" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "狀態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "用法" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "終極魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**已啟用 [ ✓ ]** 可讓整座城市保持清潔。\n\n" +
                    "當 **終極魔法** 為 ON 時：\n" +
                    "- **垃圾管理** 會被強制設為 OFF。\n" +
                    "- **垃圾管理** 的滑桿不會生效（數值會保留，供之後使用）。\n" +
                    "- 由於 vanilla 調度邏輯的時機問題，仍可能有少量卡車繼續移動。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "垃圾管理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系統；vanilla 的垃圾邏輯仍會繼續運行。\n\n" +
                    "- 當 **垃圾管理為 ON [ ✓ ]** 時，**終極魔法** 會被強制設為 OFF。\n" +
                    "- 只有啟用 **垃圾管理** 時，滑桿才會生效。\n" +
                    "- 如果只想看 **狀態報告**，**終極魔法** 和 **垃圾管理** 都可以保持 **OFF**。\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "優先協助" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                    "用於幫助嚴重過載的垃圾目標（建築）。\n" +
                    "**ON** 時，會檢查是否有活動請求目標達到 **7000+**（**7t**）垃圾。\n" +
                    "目標：在需要時減少額外的順路收集，讓卡車更快到達嚴重目標。\n" +
                    "這是輔助，不是對 vanilla 路線邏輯的強制完全覆蓋。\n" +
                    "輕量，無 Harmony 補丁。"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡車載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛卡車能運多少垃圾。**\n" +
                    "**100% = 正常** 遊戲預設值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "設施儲存量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**設施可存放多少垃圾。**\n" +
                    "**100% = vanilla** 儲存量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "設施處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**設施處理輸入垃圾的速度。**\n" +
                    "**100% = vanilla** 處理速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "設施車隊" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個設施能派出多少輛卡車。**\n" +
                    "**100% = vanilla** 卡車數量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "進階模式選項" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**可選的進階門檻 + 垃圾滿意度 + 累積率調整。**\n" +
                    "當 **關閉** 時，收集/請求門檻、垃圾滿意度和垃圾累積速率都會保持 **vanilla**。\n" +
                    "當 **開啟** 時，會顯示進階 **滑桿**。\n\n" +
                    "<--- 垃圾滿意度範例 --->\n" +
                    " - <Vanilla> 100/65 = 第 1 次懲罰在 <165>。\n" +
                    " - <推薦> 550/150 = 第 1 次懲罰在 <700>。\n" +
                    " - <非常寬鬆> 950/200 = 第 1 次垃圾懲罰在 <1150>。\n" +
                    "方便：即使此項關閉，最後使用的滑桿數值也會被保存（以後想啟用時還能用）。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "派車請求門檻" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建築在建立或保留卡車派車請求之前所需的垃圾量。**\n" +
                    "Vanilla = **100** 垃圾單位。\n" +
                    "**100 垃圾單位 = 0.1t**\n" +
                    "**1,000 垃圾單位 = 1t**\n" +
                    "請把它保持在不低於收集門檻。\n" +
                    "通常這會讓使用中的卡車變多，停著的卡車變少。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "收集門檻" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**卡車可以從建築收集垃圾之前所需的最小垃圾量。**\n" +
                    "Vanilla = **20** 垃圾單位。\n" +
                    "回收不能高於派車請求，超出時會被限制。\n" +
                    "請讓派車請求保持在可回收門檻或更高，以避免邏輯問題；" +
                    " 如果卡車已派往某建築而回收值更高，卡車可能無法回收該建築的垃圾（累積速率也會影響）。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "套用 **垃圾管理** 的標準**推薦**數值。\n" +
                    "不會改動 **進階模式** 設定（兩者分開）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "把 Trash Boss 滑桿恢復到 **vanilla 數值**。\n" +
                    "不會<改變>進階模式設定。\n" +
                    "**Vanilla:**\n" +
                    "- 百分比滑桿恢復到 **100%**。\n" +
                    "- 派車請求門檻恢復到 **100 單位**。\n" +
                    "- 收集門檻恢復到 **20 單位**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾滿意度基線" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建築開始受到健康 + 滿意度懲罰之前的垃圾水準。**\n" +
                    "**Vanilla = 100** 垃圾單位。\n" +
                    "基線越高 = 建築在懲罰開始前能容忍更多垃圾。\n" +
                    "100 垃圾單位 = 0.1t\n" +
                    "說明：\n" +
                    "- <門檻> = 觸發系統行為的點\n" +
                    "- <基線> = 懲罰公式的起點\n" +
                    "- <步長> = 公式中的增量大小，也就是懲罰開始後成長得有多快"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾滿意度步長" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超過基線後，觸發 -1 懲罰所需的額外垃圾量。**\n" +
                    "Vanilla = **65** 垃圾單位。\n" +
                    "步長越高 = 懲罰成長越慢。\n" +
                    "遊戲把垃圾懲罰上限設為 **-10**。\n" +
                    "vanilla 的第一次 <-1 懲罰> 出現在 **165 垃圾**（基線 100 + 步長 65）\n" +
                    "如果修改門檻，也要配合調整滿意度滑桿，否則懲罰可能會比正常更重。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "累積速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**縮放受支援建築的垃圾來源數值。**\n" +
                    "注意：這是個影響很強的調整項，改動這個速率會影響很多東西。\n" +
                    "即使不用它，也可以做出一個不錯的系統。\n\n" +
                    "**100% = vanilla** 累積率。\n" +
                    "**20%** = 累積慢很多。\n" +
                    "**200%** = 雙倍速度——垃圾會非常多。\n" +
                    "在 20% 時，市民顯然都在認真堆肥，所以垃圾累積率也低得多 ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "套用 **推薦** 的進階模式數值。\n" +
                    "會開啟進階模式。\n" +
                    "第一次垃圾懲罰會在 **700** 垃圾時開始（基線 550 + 步長 150）。\n" +
                    "除非手動修改，否則累積速率會保持 **100%** vanilla。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "把所有進階模式數值都恢復為 **vanilla**。\n" +
                    "會關閉 **進階模式**。\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "目前模組版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "開啟 Paradox Mods 頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在瀏覽器中開啟 Discord 邀請連結。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動清理狀態>\n" +
                    "  * 終極魔法 ON = **[ ✓ ]**\n" +
                    "  * 垃圾會被自動移除 - 完成。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理狀態>\n" +
                    "  * 垃圾管理 = **[ ✓ ]**\n" +
                    "  * 依需求調整滑桿。\n" +
                    "  * 可選：啟用進階滑桿（不是必需）。\n" +
                    "  * 還是同樣的遊戲垃圾系統；但卡車/設施可自行管理得更好。\n" +
                    " <-------------------------------------->\n\n" +
                    "<狀態 / vanilla 狀態>\n" +
                    "  * 終極魔法 = OFF\n" +
                    "  * 垃圾管理 = OFF\n" +
                    "  * 僅顯示狀態報告。\n" +
                    "  * 遊戲的 vanilla 垃圾系統不變。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "垃圾服務評分" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "遊戲裡的簡單城市垃圾滿意度評級。\n" +
                    "**0 = 優秀**\n" +
                    "**-1 = 需要稍微調一下** 遊戲經常會在 0 到 -1 之間波動，可以忽略。\n" +
                    "**-2 到 -4 = 有點臭**\n" +
                    "**-5 到 -10 = 垃圾問題**\n" +
                    "**間接調整：** 卡車/設施/門檻滑桿可以隨時間改善這一點，因為它們會減少實際垃圾堆積。\n" +
                    "**直接調整：** <垃圾滿意度基線> + <垃圾滿意度步長> 會改變市民在不高興之前能容忍多少垃圾。\n" +
                    "**來源速率調整：** <累積率> 會改變受支援建築產生垃圾的速度。"
                },



                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "達到或超過 **7t / 7000** 垃圾的產垃圾建築數量。\n" +
                    "這些建築已經嚴重過載，啟用 [x] 優先協助 可更好地優先處理它們。\n" +
                    "如果要查看實體 ID 編號進行檢查，請使用「將詳細狀態寫入日誌」按鈕。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "顯示目前全城垃圾量與總處理速率。\n" +
                    "如果每月產生的垃圾遠高於處理量，就該提高處理能力。\n" +
                    "**已產生** 和 **已處理** 使用每月噸數。\n" +
                    "<更新時間 = 上次重新整理。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集請求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**待處理** = 目前尚未分配給卡車或路徑的活動收集請求。\n" +
                    "**已派出** = 已經分配出去的活動收集請求。\n" +
                    "**總計** = 目前 **活動** 請求實體的數量（在垃圾流程中）。\n\n" +
                    "技術說明：這和 <高於請求門檻> 不一樣。這裡統計的是 <請求>，不是建築。\n" +
                    "有些待處理請求會在之後被分配；如果 vanilla 重新驗證後認為目標已不需要服務，它們也可能會被清掉。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 目前持有垃圾的建築。\n" +
                    "**總計** = 城市中所有產生垃圾的建築。\n" +
                    "**高於請求門檻** = 目前擁有足夠垃圾、可以建立收集請求的 **建築** 數量。\n" +
                    "在 vanilla 中，請求門檻是 **100** 內部垃圾單位。\n" +
                    "進階模式選項可以覆蓋請求門檻與收集門檻。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已統計垃圾設施的摘要。\n" +
                    "**設施** = 已統計的垃圾建築。\n" +
                    "**垃圾卡車** = 普通收集卡車。在工業廢棄物設施中，它們收集的是工業廢棄物，而不是普通垃圾。\n" +
                    "**Dump 卡車** = 設施之間轉運垃圾的卡車。\n" +
                    "**最大工人** = 這些設施的總工人容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**移動中** = 目前正在城裡行駛的卡車。\n" +
                    "**返回中** = 正在移動、且被標記為返回設施的那部分卡車。\n" +
                    "**停放中** = 停在設施內的卡車。\n" +
                    "**總計** = 全部垃圾卡車的數量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "將詳細狀態寫入日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "將更詳細的 garbage 報告寫入 **Logs/MagicGarbage.log**。\n" +
                    "包含簡短圖例、vanilla 參考值，以及很多額外的真實城市垃圾統計。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "開啟遊戲的 Logs/.. 資料夾。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "還沒有載入城市。" },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "優秀 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "稍微調一下會更好 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "有點臭 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "垃圾問題 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 超過 7t" },

                { "MG.Status.Row.GarbageProcessing", "已產生 {0:N0} t | 已處理 {1:N0} t" },
                { "MG.Status.Row.Requests", "{1:N0} 待處理 | {2:N0} 已派出 | {0:N0} 總計" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高於請求門檻" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 個設施 | {1:N0}/{2:N0} 垃圾/Dump卡車 | {3:N0} 工人" },
                { "MG.Status.Row.Trucks", "{1:N0} 移動中 ({3:N0} 返回中) | {2:N0} 停放中 | {0:N0} 總計" },
                { "MG.Status.Row.FacilitiesNone", "還沒有設施資料。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾狀態 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：終極魔法={0}，垃圾管理={1}" },
                { "MG.Status.Log.SettingsHeader", "目前模組設定" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash Boss 滑桿（已保存）：卡車載量={0:N0}% | 設施儲量={1:N0}% | 設施處理={2:N0}% | 設施車隊={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "進階模式選項（已保存）：啟用={0} | 請求={1:N0} | 收集={2:N0} | 滿意度基線={3:N0} | 滿意度步長={4:N0} | 累積速率={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "說明：\n" +
                    "- 已產生/已處理 使用每月噸數。\n" +
                    "- 下方門檻使用的是內部垃圾單位，不是噸。\n" +
                    "- 對玩家顯示時，遊戲會把 100 單位換算為 0.1t，把 1,000 單位換算為 1t。\n" +
                    "- 垃圾服務評級 = 遊戲中的城市垃圾滿意度係數。\n" +
                    "  - 0 = 優秀\n" +
                    "  - -1 = 需要稍微調一下，或者可以忽略\n" +
                    "  - -2 到 -4 = 有點臭\n" +
                    "  - -5 到 -10 = 垃圾問題\n" +
                    "門檻滑桿：\n" +
                    "  - 回收門檻 = 卡車能從建築回收垃圾之前所需的最小垃圾量。\n" +
                    "  - 請求門檻 = 遊戲建立或保留回收請求之前所需的最小垃圾量。\n" +
                    "- 警告圖示 = 會讓建築上方出現警告圖示的垃圾量。\n" +
                    "- 上限 = 建築可累積的最大垃圾量。\n" +
                    "- 待處理 = 目前尚未分配給卡車或路徑的活動請求。\n" +
                    "- 有些待處理請求會在之後被分配；如果 vanilla 重新驗證後認為目標已不需要服務，它們也可能會被清掉。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "遊戲門檻（內部垃圾單位）：收集={1:N0}，請求={0:N0}，警告圖示={2:N0}，上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "門檻：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 處理：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服務評級：{0} | 原始值={1:N2} | 四捨五入={2:N0}" },
                { "MG.Status.Log.Requests", "收集請求：待處理={1:N0}，已派出={2:N0}，總計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待處理目標中的最高垃圾量：{0:N0} ({1:N1}t) 位於 {2}" },
                { "MG.Status.Log.PendingPeakNone", "待處理目標中的最高垃圾量：無" },
                { "MG.Status.Log.Producers", "建築：{0:N0} 警告圖示 | {1:N0} 總計 | {2:N0} 有垃圾 | {3:N0} 高於請求門檻 " },
                { "MG.Status.Log.ProducerGarbageStats", "建築垃圾（僅非零值）：平均={0:N0} ({1:N1}t) | 中位數={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t) 位於 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告圖示的建築（至少 {1:N0} 單位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "設施：{0:N0} 總計 | {1:N0} 垃圾卡車 | {2:N0} Dump卡車 ({3:N0} 移動中) | {4:N0} 工人" },
                { "MG.Status.Log.Trucks", "垃圾卡車：{2:N0} 移動中 ({3:N0} 返回中) | {1:N0} 停放中 | {4:N0} 已停用 | {0:N0} 總計" },
                { "MG.Status.Log.FacilitiesHeader", "設施摘要" },
                { "MG.Status.Log.FacilityLine", "- 設施 {0}：垃圾卡車={1:N0} ({2:N0} 移動中，{3:N0} 停放中) | Dump卡車={4:N0} ({5:N0} 移動中) | 工人={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "優秀" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "稍微調一下會更好" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "有點臭" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾問題" },

                { "MG.Status.Log.ThresholdsHeader", "門檻 + 服務" },
                { "MG.Status.Log.RequestsHeader", "請求" },
                { "MG.Status.Log.BuildingsHeader", "建築" },

                { "MG.Status.Log.CriticalBuildingsHeader", "超過 7t 的嚴重建築" },

                { "MG.Status.Log.TransferProbeHeader", "垃圾轉運探針" },
                { "MG.Status.Log.TransferProbeNone", "未找到垃圾儲存轉運設施。" },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | 已存={1,7:N0} ({2,4:N1}t) | 容量={3,7:N0} ({4,4:N1}t) | 匯出={5,7:N0} ({6,4:N1}t) | 低位={7,7:N0} ({8,4:N1}t) | 最小={9,7:N0} ({10,4:N1}t) | 出/入={11,6:N0}/{12,6:N0} | 活動={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "卡車" },

                { "MG.Status.Log.SettingsPriority",
                    "優先協助（已保存）：啟用={0} | 觸發值={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "優先協助" },
                { "MG.Status.Log.PriorityState",
                    "優先協助即時={0} | 間隔={1:N0} 幀 | 上次掃描請求數={2:N0} | 活動嚴重請求目標={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "優先處理輪次：提升={0:N0} | 普通={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "最高的活動嚴重目標：無" },
                { "MG.Status.Log.PriorityPeak",
                    "最高的活動嚴重目標：{0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "待處理" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "已派出" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "優先協助上次掃描耗時={0:N3} ms" },
#endif

                { "MG.Status.Log.CriticalBuildingsNone", "無" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },
            };
        }

        public void Unload()
        {
        }
    }
}
