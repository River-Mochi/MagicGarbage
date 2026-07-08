// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "自行管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "高級使用者" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "狀態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "用法" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**啟用 [ ✓ ]** 會保持整座城市干净。\n" +
                    "\n" +
                    "當 **Total Magic** 開啟時：\n" +
                    "- Trash Boss 會被強制關閉。\n" +
                    "- Trash Boss 滑桿不會套用（數值會保存以便之後使用）。\n" +
                    "- 由於 vanilla 调度邏輯的時机，少量卡車仍可能移動。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系統；vanilla 垃圾邏輯仍會運行。\n" +
                    "\n" +
                    "- 當 **Trash Boss 開啟 [ ✓ ]** 時，Total Magic 會被強制關閉。\n" +
                    "- 滑桿只在 Trash Boss 啟用時生效。\n" +
                    "- Total Magic + Trash Boss 都可以 **關閉** 以使用 vanilla 設定，\n" +
                    "  同時仍可查看 **狀態報告**；它只在進入選項菜單時更新（輕量）。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "優先協助" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "協助嚴重超載的垃圾目標（建築）。\n" +
                    "當 **開啟** 時，會检查是否有活動請求目標達到 **7000+**（**7t**）垃圾。\n" +
                    "目標：按需减少額外的顺路收集，让卡車更快到達嚴重目標。\n" +
                    "這是輕度辅助，不是對 vanilla 路線邏輯的強制完整覆盖。\n" +
                    "輕量，無 Harmony 補丁。"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡車載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛卡車能運多少垃圾。**\n" +
                    "**100% = 正常** 遊戲預設值 (20t)。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "設施儲存量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**設施可存放多少垃圾。**\n" +
                    "**100% = vanilla** 儲存量。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "設施處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**設施處理進入垃圾的速度。**\n" +
                    "**100% = vanilla** 處理速度。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "設施車队" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個設施可派出多少輛卡車。**\n" +
                    "**100% = vanilla** 卡車數量。\n" +
                    ""
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "套用 **推薦** 的標准 Trash Boss 數值。\n" +
                    "不會更改高級使用者設定（單獨設定）。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "遊戲預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "将 Trash Boss 滑桿恢复為 **vanilla 數值**。\n" +
                    "<不會> 更改高級使用者設定。\n" +
                    "**Vanilla:**\n" +
                    "- 百分比滑桿恢复為 **100%**。\n" +
                    "- Dispatch Request Threshold 恢复為 **100 units**。\n" +
                    "- Pickup Threshold 恢复為 **20 units**。\n" +
                    ""
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "高級使用者選項" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "可選高級設定\n" +
                    "<警告：良好服務不需要>；提供给想實驗或了解系統運作的玩家。\n" +
                    "當 **關閉** 時，高級使用者項目會像普通 **vanilla** 遊戲一样運行。\n" +
                    "當 **開啟** 時，高級 **滑桿會顯示**。\n" +
                    "\n" +
                    "<--- 幸福度示例 --->\n" +
                    " - <Vanilla> 100/65 = 第一次懲罰在 <165>。\n" +
                    " - 点击 <推薦>，550/150 = 第一次懲罰在 <700>。\n" +
                    " - <很宽松> 950/200 = 第一次垃圾懲罰在 <1150>。\n" +
                    "方便：關閉此選項時會保存最後的滑桿數值（方便之後再啟用）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建築在建立或保留卡車调度請求前所需的垃圾量。**\n" +
                    "Vanilla = **100** garbage units。\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "請保持等於或高於 Pickup Threshold。\n" +
                    "這通常會让更多卡車被使用，而不是停放。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**卡車可以從建築收集前所需的最低建築垃圾量。**\n" +
                    "Vanilla = **20** garbage units。\n" +
                    "Pickup 滑桿<不能>高於 Dispatch Request (DR)；會被限制以避免邏輯問題。\n" +
                    "如果卡車被派往建築，而 pickup 值高於 DR，卡車有時可能無法從该建築收集（accumulation rate 也會影响）。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾幸福度基線" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**開始造成健康 + 幸福度懲罰前的建築垃圾量。**\n" +
                    "**Vanilla = 100** garbage units。\n" +
                    "較高基線 = 建築可在懲罰開始前容纳更多垃圾。\n" +
                    "100 garbage units = 0.1t\n" +
                    "概覽：\n" +
                    "- <Threshold> = 系統行為觸發点\n" +
                    "- <Baseline> = 懲罰公式起点\n" +
                    "- <Step> = 公式中的增量大小，也就是懲罰開始後增长速度"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾幸福度步進" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超過基線後使 -1 懲罰開始的額外垃圾量。**\n" +
                    "Vanilla = **65** garbage units。\n" +
                    "Step 越高 = 懲罰增长越慢。\n" +
                    "遊戲把垃圾懲罰上限設為 **-10**。\n" +
                    "Vanilla 第一次 <-1 penalty> 出现在 **165 garbage**（100 baseline + 65 step）\n" +
                    "更改 threshold 時若不配合幸福度滑桿，可能會產生比正常更重的懲罰。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "累積率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**缩放受支持建築的垃圾来源值。**\n" +
                    "注意：這是強力杠杆，改變该比例會影响很多东西。\n" +
                    "不使用它也可以获得良好系統。\n" +
                    "\n" +
                    "**100% = vanilla** accumulation rate。\n" +
                    "**20%** = 積累慢很多。\n" +
                    "**200%** = 双倍速度——大量垃圾。\n" +
                    "20% 時，所有 Cims 顯然都在堆肥，所以垃圾累積率低得多 ;)\n" +
                    "\n" +
                    "技術說明：遊戲會在一天中逐步增加垃圾，不是一次性增加。"
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "套用 **推薦** 的高級使用者數值。\n" +
                    "開啟高級使用者。\n" +
                    "第一次垃圾懲罰從 **700** garbage（550 baseline + 150 step）開始。\n" +
                    "除非手動更改，Garbage Accumulation Rate 保持 **100%** vanilla。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "遊戲預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "将所有高級使用者數值 **恢复為 vanilla**。\n" +
                    "關閉 **高級使用者**。\n" +
                    ""
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模組的顯示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "目前模組版本。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "打開 Paradox Mods 頁面。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在瀏覽器中打開 Discord 邀請。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動清理狀態>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * 垃圾會自動移除 - 完成。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<自行管理狀態>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 按需要設定滑桿。\n" +
                    "  * 可選：開啟高級滑桿（非必需）。\n" +
                    "  * 同样的遊戲垃圾系統；更好地自行管理卡車/設施。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<狀態 / vanilla 狀態>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * 僅顯示狀態報告。\n" +
                    "  * Vanilla 垃圾遊戲不變。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "垃圾服務評分" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "来自遊戲的簡單垃圾幸福度評分。\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= 需要小幅调整。遊戲經常在 0 到 -1 之間，可以忽略（數值已四舍五入）。\n" +
                    "**-2 to -4** = 有点臭\n" +
                    "**-5 to -10** = 垃圾問題\n" +
                    "**間接调节：** 使用 <trash sliders> 随時間减少垃圾累積来改善。\n" +
                    "**直接调节：** Garbage Happiness Baseline + Garbage Happiness Step 會改變 Cims 不開心前<能容忍的量>。\n" +
                    "**Garbage Accumulation Rate**：改變受支持建築產生垃圾的速度。請谨慎使用，因為平衡很重要。多數玩家不需要调整。\n" +
                    "<Update time = 最後刷新時間。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "達到或超過 **7t / 7000** 垃圾的垃圾生產建築數量。\n" +
                    "這些是嚴重超載建築，啟用 [x] Priority Assist 可更好地優先處理。\n" +
                    "如果想查看 Entity ID 编号，請使用 Status to log 按鈕。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "顯示目前全城垃圾量和總垃圾處理率。\n" +
                    "如果每月產生的垃圾高出很多，請提高處理能力。\n" +
                    "**Produced** 和 **Processed** 使用吨/月。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集請求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 尚未分配给卡車或路徑的活動收集請求。\n" +
                    "**Dispatched** = 已分配的活動收集請求。\n" +
                    "**Total** = 目前垃圾流程中的 **active** request entity 數量。\n" +
                    "\n" +
                    "技術說明：這不同於 <Above request threshold>。這里統計 <requests>，不是建築。\n" +
                    "一些 pending requests 稍後會被分配；如果 vanilla 重新驗證認為目標不再需要服務，也可能稍後清除。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 目前持有任何垃圾的建築。\n" +
                    "**Total** = 城市中所有垃圾生產建築。\n" +
                    "**Above request threshold** = 目前有足够垃圾建立收集請求的 **buildings** 數量。\n" +
                    "Vanilla 中，request threshold 是 **100** internal garbage units。\n" +
                    "Power User Options 可覆盖 request 和 pickup thresholds。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已統計垃圾設施的摘要。\n" +
                    "**Facilities** = 統計到的垃圾建築。\n" +
                    "**Garbage trucks** = 普通收集卡車。在 Industrial Waste 設施中，它们收集工业廢物而不是垃圾。\n" +
                    "**Dump trucks** = 設施之間的垃圾轉運。\n" +
                    "**Max workers** = 這些相同設施的總工人容量。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾卡車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 目前在城市中行驶的卡車。\n" +
                    "**Returning** = moving trucks 中被標记返回設施的子集。\n" +
                    "**Parked** = 停在設施的卡車。\n" +
                    "**Total** = 所有垃圾卡車數量。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細狀態寫入記錄" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "将更詳細的垃圾報告寫入 **Logs/MagicGarbage.log**。\n" +
                    "包括整理好的城市垃圾統計"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟記錄" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "開啟遊戲 Logs/.. 資料夾。" },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未加載城市。" },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "需要小幅调整 ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "有点臭 ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "垃圾問題 ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 超過 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 設施 | {1:N0}/{2:N0} 垃圾/自卸卡車 | {3:N0} 工人" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "暂無設施數据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾狀態 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "目前模組設定" },
                { "MG.Status.Log.SettingsTrashBoss", "Trash Boss 滑桿（已儲存）：truck load={0:N0}% | facility storage={1:N0}% | facility process={2:N0}% | facility fleet={3:N0}%" },
                { "MG.Status.Log.SettingsPowerUser",
                    "高級使用者（已儲存）：enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "圖例：\n" +
                    "- Produced/Processed 使用吨/月。\n" +
                    "- 下面的 threshold 值使用 internal garbage units，不是吨。\n" +
                    "- 面向玩家顯示時，遊戲會把 100 units = 0.1t，1,000 units = 1t。\n" +
                    "- Garbage Service Rating = 遊戲城市垃圾幸福度系數。\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = 需要小幅调整，或可忽略\n" +
                    "  - -2 to -4 = 有点臭\n" +
                    "  - -5 to -10 = 垃圾問題\n" +
                    "Threshold sliders:\n" +
                    "  - Pickup threshold = 卡車從建築收集前所需的最低垃圾量。\n" +
                    "  - Request threshold = 遊戲建立或保留收集請求前所需的最低垃圾量。\n" +
                    "- Warning icon = 會在建築上方出现警告圖示的垃圾量。\n" +
                    "- Hard cap = 建築可累積的最大垃圾量。\n" +
                    "- Pending = 尚未分配给卡車或路徑的活動請求。\n" +
                    "- 一些 pending requests 稍後會被分配；如果 vanilla 重新驗證認為目標不再需要服務，也可能清除。\n" +
                    "-----------------------------------------------------------------------------\n" +
                    ""
                },

                { "MG.Status.Log.Thresholds", "遊戲 Thresholds (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 處理：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服務評分：{0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "收集請求：pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "最高 pending 目標垃圾：{0:N0} ({1:N1}t) 於 {2}" },
                { "MG.Status.Log.PendingPeakNone", "最高 pending 目標垃圾：無" },
                { "MG.Status.Log.Producers", "建築：{0:N0} warning icons | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold " },
                { "MG.Status.Log.ProducerGarbageStats", "建築垃圾（僅非零）：avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) 於 {6}" },
                { "MG.Status.Log.NearWarning75", "接近 warning icon 的建築（至少 {1:N0} units / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "設施：{0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "垃圾卡車：{2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "設施摘要" },
                { "MG.Status.Log.FacilityLine",
                    "- 設施 {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "需要小幅调整" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "有点臭" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾問題" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + 服務" },
                { "MG.Status.Log.RequestsHeader", "請求" },
                { "MG.Status.Log.BuildingsHeader", "建築" },

                { "MG.Status.Log.CriticalBuildingsHeader", "超過 7t 的嚴重建築" },
                { "MG.Status.Log.LocalTransferProbeHeader", "本地垃圾轉運探測" },
                { "MG.Status.Log.LocalTransferProbeNone", "找不到本地垃圾設施。" },
                { "MG.Status.Log.OutsideTransferProbeHeader", "外部連線垃圾轉運探測" },
                { "MG.Status.Log.OutsideTransferProbeNone", "找不到外部連線垃圾設施。" },

                { "MG.Status.Log.TransferProbeHeader", "垃圾轉運探測" },
                { "MG.Status.Log.TransferProbeNone", "找不到垃圾儲存-轉運設施。" },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accept={5:N2} | send={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "卡車" },
                { "MG.Status.Log.SettingsPriority", "優先系統（已儲存）：enabled={0} | trigger={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState", "優先協助 live={0} | interval={1:N0} frames | last scanned buildings={2:N0} | critical buildings={3:N0}" },
                { "MG.Status.Log.PriorityPeak", "最高嚴重建築：{0:N0} ({1:N1}t) | {2} | request={3}" },

                { "MG.Status.Log.PriorityHeader", "優先協助" },
                { "MG.Status.Log.PriorityPasses", "優先輪次：raised={0:N0} | normal={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "最高活動嚴重建築：無" },
                { "MG.Status.Log.PriorityPeakState.Pending", "pending" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "dispatched" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "優先協助上次掃描時間={0:N3} ms" },
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
