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


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "套用 **垃圾管理** 的標準**推薦**數值。\n" +
                    "不會改動 **進階模式** 設定（兩者分開）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "將 **垃圾管理** 的滑桿恢復為 **vanilla 數值**。\n" +
                    "<不會> 改動 **進階模式** 設定。\n" +
                    "**Vanilla：**\n" +
                    "- 百分比滑桿會回到 **100%**。\n" +
                    "- Dispatch Request Threshold 會回到 **100 units**。\n" +
                    "- Pickup Threshold 會回到 **20 units**。\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "進階模式選項" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "可選進階設定\n" +
                    "<警告：並非必需>，照樣可以獲得良好服務；這是給想要試驗或更了解系統運作方式的玩家準備的。\n" +
                    "當 **OFF** 時，所有 **進階模式** 設定都會**保持 vanilla**。\n" +
                    "當 **ON** 時，會出現**進階滑桿**。\n\n" +
                    "<--- 滿意度範例 --->\n" +
                    " - <Vanilla> 100/65 = 第一次懲罰在 <165>。\n" +
                    " - 點擊 <推薦> 可使用 550/150 = 第一次懲罰在 <700>。\n" +
                    " - <非常寬鬆> 950/200 = 第一次垃圾懲罰在 <1150>。\n" +
                    "方便之處：當此選項為 OFF 時，滑桿上次的數值會被保存（以後想啟用時還能繼續用）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建築在建立或保留卡車調度請求前所需的垃圾量。**\n" +
                    "Vanilla = **100** units garbage.\n" +
                    "**100 units garbage = 0.1t**\n" +
                    "**1,000 units garbage = 1t**\n" +
                    "請保持此值等於或高於 Pickup Threshold。\n" +
                    "這通常會讓更多卡車處於使用中，而不是停放中。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**卡車可從建築收集垃圾前，建築至少需要達到的垃圾量。**\n" +
                    "Vanilla = **20** units garbage.\n" +
                    "拾取滑桿 <不能> 高於 Dispatch Request (DR)；系統會自動限制，以防邏輯出錯。\n" +
                    "如果卡車已經被派往某建築，而拾取值又高於 DR，那麼這輛卡車有時可能無法從該建築收集垃圾（垃圾累積速率也會影響這一點）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾滿意度基線" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建築垃圾量在開始造成健康 + 滿意度懲罰前的基準值。**\n" +
                    "**Vanilla = 100** units garbage.\n" +
                    "基線越高 = 建築在懲罰開始前能容納更多垃圾。\n" +
                    "100 units garbage = 0.1t\n" +
                    "概覽：\n" +
                    "- <Threshold> = 系統行為觸發點\n" +
                    "- <Baseline> = 懲罰公式的起點\n" +
                    "- <Step> = 公式中的增量大小，也就是懲罰開始後成長得有多快"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾滿意度步進" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超過基線後，開始觸發 -1 懲罰所需的額外垃圾量。**\n" +
                    "Vanilla = **65** units garbage.\n" +
                    "步進越高 = 懲罰成長越慢。\n" +
                    "遊戲會將垃圾懲罰上限限制為 **-10**。\n" +
                    "Vanilla 的第一次 <-1 penalty> 出現在 **165 garbage**（100 baseline + 65 step）\n" +
                    "調整閾值時，最好也一起平衡滿意度滑桿，否則懲罰可能會比正常更重。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "垃圾累積速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**縮放受支援建築的垃圾來源數值。**\n" +
                    "這是個很強的槓桿，改動這個速率會影響很多東西。\n" +
                    "就算不用它，也可以得到一個不錯的系統。\n\n" +
                    "**100% = vanilla** 累積速率。\n" +
                    "**20%** = 累積得慢很多。\n" +
                    "**200%** = 雙倍速率 - 垃圾會非常多。\n" +
                    "在 20% 下，所有 Cims 顯然都在堆肥，所以垃圾累積自然更低；)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "套用 **進階模式** 的**推薦**數值。\n" +
                    "會將 **進階模式** 設為 ON。\n" +
                    "第一次垃圾懲罰會從 **700** garbage 開始（550 baseline + 150 step）。\n" +
                    "除非手動更改，否則垃圾累積速率會保持 **100%** vanilla。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "將 **進階模式** 的數值恢復為 **vanilla**。\n" +
                    "會將 **進階模式** 設為 **OFF**。\n"
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
                    "遊戲中的全城垃圾滿意度簡易評分。\n" +
                    "**0 = 優秀**\n" +
                    "**-1 = 需要小調整** 遊戲經常會在 0 到 -1 之間波動，可以忽略。\n" +
                    "**-2 到 -4 = 有點臭**\n" +
                    "**-5 到 -10 = 垃圾問題嚴重**\n" +
                    "**間接調整：** 卡車/設施/閾值滑桿可以隨時間推移減少實際垃圾堆積，從而改善這個評分。\n" +
                    "**直接調整：** <垃圾滿意度基線> + <垃圾滿意度步進> 會改變市民在不滿前能容忍多少垃圾。\n" +
                    "**來源速率調整：** <垃圾累積速率> 會改變受支援建築產生垃圾的速度。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "顯示目前全城垃圾量與總垃圾處理速率。\n" +
                    "如果每月產生的垃圾遠高於處理量，就該提高處理能力。\n" +
                    "**Produced** 和 **Processed** 以每月噸數顯示。\n" +
                    "<更新時間 = 上次重新整理時間。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集請求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 目前尚未分配給卡車或路徑的活動收集請求。\n" +
                    "**Dispatched** = 已經分配出去的活動收集請求。\n" +
                    "**Total** = 目前 **active** 請求實體的數量（在 garbage 流程中）。\n\n" +
                    "技術說明：這和 <高於請求閾值> 不一樣。這裡統計的是 <請求>，不是建築。\n" +
                    "有些待處理請求稍後會被分配；如果 vanilla 重新驗證後認為目標已不再需要服務，有些請求也會在之後被清掉。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 目前持有任意垃圾的建築。\n" +
                    "**Total** = 城市中所有產生垃圾的建築。\n" +
                    "**高於請求閾值** = 目前擁有足夠垃圾、可產生收集請求的**建築**數量。\n" +
                    "在 vanilla 中，請求閾值是 **100** internal units garbage。\n" +
                    "**進階模式選項** 可以覆蓋請求閾值和拾取閾值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已統計垃圾設施的彙總。\n" +
                    "**設施** = 已統計的垃圾建築。\n" +
                    "**Garbage trucks** = 普通收集卡車。在工業廢棄物設施中，它們收集的是工業廢棄物，而不是普通垃圾。\n" +
                    "**Dump trucks** = 垃圾在設施之間的轉運卡車。\n" +
                    "**Max workers** = 這些設施的總工人容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 目前正在城裡行駛的卡車。\n" +
                    "**Returning** = 正在移動、且被標記為返回設施的那部分卡車。\n" +
                    "**Parked** = 停在設施內的卡車。\n" +
                    "**Total** = 全部 garbage trucks 的數量。"
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

                { "MG.Status.Row.GarbageServiceRating.Excellent", "優秀 ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "需要小調整 ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "有點臭 ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "垃圾問題嚴重 ({0:N0})" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed | 更新於 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高於請求閾值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 個設施 | {1:N0} garbage trucks | {2:N0} dump trucks | {3:N0} max workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "還沒有設施資料。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾狀態 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：終極魔法={0}，垃圾管理={1}" },
                { "MG.Status.Log.SettingsHeader", "目前模組設定" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "垃圾管理滑桿（已保存）：卡車載量={0:N0}% | 設施儲存量={1:N0}% | 設施處理速度={2:N0}% | 設施車隊={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "進階模式（已保存）：enabled={0} | request={1:N0} | pickup={2:N0} | 滿意度基線={3:N0} | 滿意度步進={4:N0} | 累積速率={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "圖例：\n" +
                    "- Produced/Processed 使用每月噸數。\n" +
                    "- 下方閾值使用的是 internal units garbage，不是噸。\n" +
                    "- 對玩家顯示時，遊戲會把 100 units = 0.1t，1,000 units = 1t。\n" +
                    "- 垃圾服務評分 = 遊戲中的城市垃圾滿意度係數。\n" +
                    "  - 0 = 優秀\n" +
                    "  - -1 = 需要小調整，或者也可以忽略\n" +
                    "  - -2 到 -4 = 有點臭\n" +
                    "  - -5 到 -10 = 垃圾問題嚴重\n" +
                    "閾值滑桿：\n" +
                    "  - Pickup threshold = 卡車可從建築收集前所需的最小垃圾量。\n" +
                    "  - Request threshold = 遊戲建立或保留收集請求前所需的最小垃圾量。\n" +
                    "- Warning icon = 會讓建築上方出現警告圖示的垃圾量。\n" +
                    "- Hard cap = 建築可累積的最大垃圾量。\n" +
                    "- Pending = 目前尚未分配給卡車或路徑的活動請求。\n" +
                    "- 有些待處理請求稍後會被分配；如果 vanilla 重驗證認為目標已不再需要服務，有些請求也會在之後被清掉。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "遊戲閾值（internal units garbage）：pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "閾值：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "Garbage：{0:N0} t/月 | Processing：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服務評分：{0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "收集請求：pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待處理目標中的最高垃圾量：{0:N0} ({1:N1}t) 於 {2}" },
                { "MG.Status.Log.PendingPeakNone", "待處理目標中的最高垃圾量：無" },
                { "MG.Status.Log.Producers", "建築：{0:N0} warning icons | {1:N0} total | {2:N0} 有垃圾 | {3:N0} 高於請求閾值 " },
                { "MG.Status.Log.ProducerGarbageStats", "建築垃圾（僅非零）：avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) 於 {6}" },
                { "MG.Status.Log.NearWarning75", "接近 warning icon 的建築（至少 {1:N0} units / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "設施：{0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Garbage trucks：{2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "設施彙總" },
                { "MG.Status.Log.FacilityLine", "- 設施 {0}：garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "優秀" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "需要小調整" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "有點臭" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾問題嚴重" },
            };
        }

        public void Unload()
        {
        }
    }
}
