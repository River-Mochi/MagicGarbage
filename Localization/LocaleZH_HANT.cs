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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全自動清理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**啟用 [ ✓ ]** 後，整座城市都會保持乾淨。\n\n" +
                    "當 **完全自動清理** 為 ON 時：\n" +
                    "- 垃圾管理 會被強制設為 OFF。\n" +
                    "- 垃圾管理 的滑桿不會生效（數值會保留，之後還能繼續用）。\n" +
                    "- 由於 vanilla 的派車時機，一些卡車仍然可能繼續跑。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "垃圾管理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系統；vanilla 的垃圾邏輯仍會繼續運作。\n\n" +
                    "- 當 **垃圾管理 為 ON [ ✓ ]** 時，完全自動清理 會被強制設為 OFF。\n" +
                    "- 只有啟用 垃圾管理 時，這些滑桿才會生效。\n" +
                    "- 如果只想看 **狀態報告**，完全自動清理 和 垃圾管理 可以同時保持 **OFF**。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡車載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛卡車能運多少垃圾。**\n" +
                    "**100% = 遊戲預設** 數值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "設施儲量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**每個設施能儲存多少垃圾。**\n" +
                    "**100% = vanilla 儲量**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "設施處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**設施處理流入垃圾的速度。**\n" +
                    "**100% = vanilla 處理速度**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "設施車隊" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個設施可以派出的卡車數量。**\n" +
                    "**100% = vanilla 卡車數量**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "進階選項" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**可選的進階微調：閾值 + 垃圾對幸福感的影響。**\n" +
                    "當為 **OFF** 時，收集/請求閾值和垃圾幸福度 **保持 vanilla**。\n" +
                    "當為 **ON** 時，會顯示 **進階滑桿**。\n\n" +
                    "<--- 垃圾幸福度示例 --->\n" +
                    " - <Vanilla> 100/65 = 第 1 次懲罰在 <165>。\n" +
                    " - <推薦> 550/150 = 第 1 次懲罰在 <700>。\n" +
                    " - <非常寬鬆> 950/200 = 第 1 次垃圾懲罰在 <1150>。\n" +
                    "方便點：就算這個選項是 OFF，之前的滑桿數值也會保留。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "派車請求閾值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建築內垃圾達到這個量後，才會建立或保留卡車派遣請求。**\n" +
                    "Vanilla = **100** 垃圾單位。\n" +
                    "**100 垃圾單位 = 0.1t**\n" +
                    "**1,000 垃圾單位 = 1t**\n" +
                    "這個值請保持不低於收集閾值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "收集閾值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**建築內垃圾至少達到這個量後，卡車才會去收。**\n" +
                    "Vanilla = **20** 垃圾單位。\n" +
                    "收集閾值絕不能高於派車請求閾值。\n" +
                    "為了避免邏輯出問題，派車請求閾值應始終保持與有效收集值相同或更高；" +
                    " 如果卡車已經 dispatch 到建築，但收集值更高，它就可能收不到垃圾（累積速度也會影響）。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "套用 **推薦** 的 垃圾管理 標準數值。\n" +
                    "不會更改 進階選項 的設定。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "把 垃圾管理 滑桿恢復為 **vanilla 數值**。\n" +
                    "不會 <not> 更改 進階選項 的設定。\n" +
                    "**Vanilla：**\n" +
                    "- 百分比滑桿恢復到 **100%**。\n" +
                    "- 派車請求閾值恢復到 **100 units**。\n" +
                    "- 收集閾值恢復到 **20 units**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾幸福度基線" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建築內垃圾達到這個基線後，才會開始出現健康 + 幸福懲罰。**\n" +
                    "**Vanilla = 100** 垃圾單位。\n" +
                    "基線越高 = 建築在受到懲罰前能容忍更多垃圾。\n" +
                    "100 垃圾單位 = 0.1t\n" +
                    "說明：\n" +
                    "- <閾值> = 系統行為開始觸發的位置\n" +
                    "- <基線> = 懲罰公式開始計算的位置\n" +
                    "- <步長> = 公式每次增加的幅度，也就是懲罰成長速度"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾幸福度步長" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超過基線後的額外垃圾量，每達到一次就會觸發 -1 懲罰。**\n" +
                    "Vanilla = **65** 垃圾單位。\n" +
                    "步長越高 = 懲罰成長越慢。\n" +
                    "遊戲裡的垃圾懲罰上限是 **-10**。\n" +
                    "vanilla 的第一次 <-1 penalty> 出現在 **165 垃圾**（100 baseline + 65 step）\n" +
                    "如果提高了閾值，也要配合幸福度滑桿一起調，不然懲罰可能會比正常更重。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "套用 **推薦** 的 進階選項 數值。\n" +
                    "啟用 進階選項。\n" +
                    "第一次垃圾懲罰會從 **700 垃圾** 開始（550 baseline + 150 step）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "把 進階選項 的數值恢復為 **vanilla**。\n" +
                    "把 **進階選項 切到 OFF**。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "這個模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "目前模組版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "開啟 Paradox Mods 頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在瀏覽器中開啟 Discord 邀請連結。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動清理狀態>\n" +
                    "  * 完全自動清理 ON  = **[ ✓ ]**\n" +
                    "  * 垃圾會自動被清掉 - 完成。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理狀態>\n" +
                    "  * 垃圾管理 = **[ ✓ ]**\n" +
                    "  * 按自己想要的方式調滑桿。\n" +
                    "  * 可選：啟用 進階選項 來調閾值 + 垃圾幸福度。\n" +
                    "  * 仍然是遊戲原本的垃圾系統，只是卡車/設施更好控。\n" +
                    " <-------------------------------------->\n\n" +
                    "<狀態 / vanilla 狀態>\n" +
                    "  * 完全自動清理 = OFF\n" +
                    "  * 垃圾管理 = OFF\n" +
                    "  * 只看狀態報告。\n" +
                    "  * vanilla 垃圾系統保持不變。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "顯示目前全城垃圾量和總處理速度。\n" +
                    "如果每月產生的垃圾遠高於處理量，就該提高處理能力。\n" +
                    "**已產生** 和 **已處理** 以每月噸數顯示。\n" +
                    "<更新時間 = 上次重新整理時間。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集請求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**待處理** = 目前有效、但還沒分配給卡車或路線的收集請求。\n" +
                    "**已派出** = 目前有效、已經分配出去的收集請求。\n" +
                    "**總計** = 目前 **有效** 請求實體的數量（垃圾流程裡）。\n\n" +
                    "技術說明：這和 <高於請求閾值> 不一樣。這裡統計的是 <請求>，不是建築。\n" +
                    "有些待處理請求會稍後被分配；也有些會在 vanilla 重新校驗後被清掉，因為目標已經不再需要服務。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 目前內部有垃圾的建築。\n" +
                    "**總計** = 城裡所有會產生垃圾的建築。\n" +
                    "**高於請求閾值** = 目前垃圾多到足以建立收集請求的 **建築** 數量。\n" +
                    "在 vanilla 裡，請求閾值是 **100** 內部垃圾單位。\n" +
                    "進階選項 可以覆蓋請求閾值和收集閾值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已統計垃圾設施的摘要。\n" +
                    "**設施** = 被統計的垃圾建築。\n" +
                    "**垃圾車** = 普通收集卡車。在工業廢棄物設施裡，它們收集的是工業廢棄物而不是一般垃圾。\n" +
                    "**Dump trucks** = 設施之間的垃圾轉運。\n" +
                    "**最大員工數** = 這些設施的總員工容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**行駛中** = 目前正在城裡跑的卡車。\n" +
                    "**返回中** = 行駛中的卡車裡，正在回設施的那部分。\n" +
                    "**停放中** = 停在設施裡的卡車。\n" +
                    "**總計** = 所有垃圾車的數量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細狀態寫入日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "把更詳細的垃圾報告寫進 **Logs/MagicGarbage.log**。\n" +
                    "裡面會有簡短圖例、vanilla 參考值，以及很多城市目前垃圾統計。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "開啟遊戲的 Logs/.. 資料夾。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "還沒有載入城市。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 已產生 | {1:N0} t 已處理 | 更新於 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 待處理 | {2:N0} 已派出 | {0:N0} 總計" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高於請求閾值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 個設施 | {1:N0} 輛垃圾車 | {2:N0} dump trucks | {3:N0} 最大員工數" },
                { "MG.Status.Row.Trucks", "{1:N0} 行駛中 ({3:N0} 返回中) | {2:N0} 停放中 | {0:N0} 總計" },
                { "MG.Status.Row.FacilitiesNone", "還沒有設施資料。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾狀態 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：完全自動清理={0}，垃圾管理={1}" },
                { "MG.Status.Log.Legend",
                    "圖例：\n" +
                    "- 已產生/已處理 使用每月噸數。\n" +
                    "- 下方閾值使用的是內部垃圾單位，不是噸。\n" +
                    "- 玩家看到的換算大致是：100 單位 = 0.1t，1,000 單位 = 1t。\n" +
                    "閾值滑桿：\n" +
                    "  - 收集閾值 = 建築裡的垃圾至少達到多少，卡車才會去收。\n" +
                    "  - 請求閾值 = 垃圾至少達到多少，遊戲才會建立或保留收集請求。\n" +
                    "- 警告圖示 = 建築上方出現警告圖示所需的垃圾量。\n" +
                    "- 硬上限 = 建築最多能累積的垃圾量。\n" +
                    "- 待處理 = 目前有效、但還沒分配給卡車或路線的請求。\n" +
                    "- 有些待處理請求會稍後被分配；也有些會在 vanilla 重新校驗後被清掉，因為目標已經不再需要服務。\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "遊戲閾值（內部垃圾單位）：收集={1:N0}，請求={0:N0}，警告圖示={2:N0}，硬上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "閾值：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 處理：{1:N0} t/月" },
                { "MG.Status.Log.Requests", "收集請求：待處理={1:N0}，已派出={2:N0}，總計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "最高待處理目標：{0:N0} ({1:N1}t)，位置 {2}" },
                { "MG.Status.Log.Producers", "建築：{0:N0} 總計 | {1:N0} 有垃圾 | {2:N0} 高於請求閾值 | {3:N0} 達到警告等級" },
                { "MG.Status.Log.ProducerGarbageStats", "建築垃圾（僅統計非零）：平均={0:N0} ({1:N1}t) | 中位數={2:N0} ({3:N1}t) | 最大值={4:N0} ({5:N1}t)，位置 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告的建築（至少 {1:N0} 單位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "設施：{0:N0} 總計 | {1:N0} 輛垃圾車 | {2:N0} dump trucks ({3:N0} 行駛中) | {4:N0} 員工" },
                { "MG.Status.Log.Trucks", "垃圾車：{2:N0} 行駛中 ({3:N0} 返回中) | {1:N0} 停放中 | {4:N0} 已停用 | {0:N0} 總計" },
                { "MG.Status.Log.FacilitiesHeader", "設施摘要" },
                { "MG.Status.Log.FacilityLine", "- 設施 {0}：垃圾={1:N0}（{2:N0} 行駛中，{3:N0} 停放中） | dump={4:N0}（{5:N0} 行駛中） | 最大員工數={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
