// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT)

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
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "狀態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用說明" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "全城魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**啟用 [ ✓ ]**後會保持整座城市清潔。\n" +
                    "\n" +
                    "當**全城魔法**開啟時：\n" +
                    "- 垃圾主管會被強制關閉。\n" +
                    "- 垃圾主管滑桿不會套用（數值會保存供之後使用）。\n" +
                    "- 由於原版派遣邏輯的時序，少量車輛仍可能繼續移動。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "垃圾主管" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系統，同時保留原版垃圾邏輯運作。\n" +
                    "\n" +
                    "- 當**垃圾主管開啟 [ ✓ ]**時，全城魔法會被強制關閉。\n" +
                    "- 只有啟用垃圾主管時滑桿才會套用。\n" +
                    "- 全城魔法與垃圾主管都可以**關閉**以使用原版設定，\n" +
                    "  同時仍可查看**狀態報告**；它只會在你進入「選項」選單時更新（負擔很低）。"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "垃圾車載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛垃圾車可裝載的垃圾量。**\n" +
                    "**100% = 原版**垃圾車容量（20t）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "設施儲存量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**設施可儲存的垃圾量。**\n" +
                    "**100% = 原版**儲存量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "設施處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**設施處理垃圾的速度。**\n" +
                    "**100% = 原版**處理速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "設施車隊" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個設施可派出的車輛數量。**\n" +
                    "**100% = 原版**車輛數量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "目標預留" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**控制垃圾車在前往已指派建築途中，多早開始對可選收集點進行篩選。**\n" +
                    "**10% 是 1.6.2 版本的原版數值。**\n" +
                    "以一般 20t 垃圾車為例：\n" +
                    "- 10% 會提前 2t 開始為指派目標保留空間。\n" +
                    "- 15% 會提前 3t。\n" +
                    "- 25% 會提前 5t。\n" +
                    "數值越高，安全餘量越大。垃圾車會更早略過小額收集，讓指派建築保有更多空間。"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "建議" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "為繁忙城市套用較均衡的數值。\n" +
                    "垃圾車載量 **200%** | 儲存 **150%** | 處理 **250%**\n" +
                    "車隊 **100%** | 目標預留 **15%**。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "重設滑桿" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "重設標準垃圾主管滑桿。\n" +
                    "- 百分比滑桿恢復為 **100%**。\n" +
                    "- 目標預留恢復為**原版 10%**。\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "目前模組版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "開啟 Paradox Mods 頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在瀏覽器中開啟 Discord 邀請。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動清理狀態>\n" +
                    "  * 全城魔法開啟 = **[ ✓ ]**\n" +
                    "  * 垃圾會自動清除 - 完成。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<自行管理狀態>\n" +
                    "  * 垃圾主管 = **[ ✓ ]**\n" +
                    "  * 依需要調整滑桿。\n" +
                    "  * 仍使用遊戲原有垃圾系統，但更好地自行管理車輛/設施。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<狀態 / 原版狀態>\n" +
                    "  * 全城魔法 = 關閉\n" +
                    "  * 垃圾主管 = 關閉\n" +
                    "  * 僅顯示狀態報告。\n" +
                    "  * 原版垃圾系統保持不變。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使用說明" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "垃圾服務評分" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "遊戲計算的全市平均垃圾幸福度影響。\n" +
                    "整體評分良好時仍可能有少數問題建築，因此也請檢查 **7t+ 建築**。\n" +
                    "**0 = 整體優秀**\n" +
                    "**-1 = 需要小幅調整**\n" +
                    "**-2 到 -4 = 略有異味**\n" +
                    "**-5 或更低 = 垃圾問題**\n" +
                    "\n" +
                    "使用垃圾車與設施滑桿改善服務，然後讓城市運行一段時間再重新檢查。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "垃圾量達到或超過 **7000 / 7t** 的垃圾產出建築數量。\n" +
                    "這個固定的早期預警指標可協助你在建築達到遊戲警告圖示級別之前判斷是否需要提高服務能力。\n" +
                    "使用「詳細狀態寫入日誌」可列出這些建築的 Entity ID。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "顯示全市垃圾產量、目前處理量以及設施可用處理能力。\n" +
                    "如果每月產量高於處理能力，請提高處理速度。\n" +
                    "所有數值皆以噸/月為單位。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集請求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**待處理** = 目前尚未指派給垃圾車或路徑的有效收集請求。\n" +
                    "**已派遣** = 已完成指派的有效收集請求。\n" +
                    "**總計** = 垃圾處理流程中目前所有**有效**請求。\n" +
                    "\n" +
                    "這與**高於請求門檻**不同，後者統計的是建築而不是請求。\n" +
                    "部分待處理請求稍後會被指派；如果原版重新驗證後認為目標不再需要服務，部分請求也可能之後被清除。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 目前存有任意垃圾的建築。\n" +
                    "**總計** = 城市中所有會產生垃圾的建築。\n" +
                    "**高於請求門檻** = 目前垃圾量足以建立收集請求的**建築**數量。\n" +
                    "詳細狀態日誌會顯示遊戲目前即時請求門檻。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已統計垃圾設施的摘要。\n" +
                    "**設施** = 已統計的垃圾建築。\n" +
                    "**垃圾車** = 一般收集車輛。在工業廢棄物設施中，它們收集的是工業廢棄物而不是一般垃圾。\n" +
                    "**傾卸車** = 用於設施之間的垃圾轉運。\n" +
                    "**最大工人數** = 這些設施的工人容量總和。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**行駛中** = 目前正在城市中運行的車輛。\n" +
                    "**返回中** = 行駛中且被標記返回所屬設施的車輛子集。\n" +
                    "**已停放** = 停放在設施中的車輛。\n" +
                    "**總計** = 所有垃圾車數量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細狀態寫入日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "將更詳細的垃圾報告寫入 **Logs/MagicGarbage.log**。\n" +
                    "包含整理後的城市垃圾統計資料。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "開啟 **MagicGarbage.log**。如果檔案不存在或無法開啟，則改為開啟遊戲的 Logs 資料夾。" },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未載入城市。" },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "整體優秀 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "需要小幅調整 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "略有異味 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "垃圾問題 ({0:N0}) | 更新於 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 個 7t+ 建築" },

                { "MG.Status.Row.GarbageProcessing", "產生 {0:N0} t | 目前處理 {2:N0} t | 處理能力 {1:N0} t" },
                { "MG.Status.Row.Requests", "待處理 {1:N0} | 已派遣 {2:N0} | 總計 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高於請求門檻" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 個設施 | {1:N0}/{2:N0} 垃圾車/傾卸車 | {3:N0} 名工人" },
                { "MG.Status.Row.Trucks", "行駛中 {1:N0}（返回中 {3:N0}）| 已停放 {2:N0} | 總計 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "尚無設施資料。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾狀態 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：全城魔法={0}, 垃圾主管={1}" },
                { "MG.Status.Log.SettingsHeader", "目前模組設定" },
                { "MG.Status.Log.SettingsTrashBoss", "垃圾主管滑桿（已保存）：垃圾車載量={0:N0}% | 設施儲存={1:N0}% | 設施處理={2:N0}% | 設施車隊={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "圖例：\n" +
                    "- 垃圾產量、目前處理量與處理能力皆以噸/月為單位。\n" +
                    "- 以下門檻值使用內部垃圾單位，而不是噸。\n" +
                    "- 面向玩家顯示時，遊戲換算為 100 單位 = 0.1t，1,000 單位 = 1t。\n" +
                    "- 垃圾服務評分 = 遊戲中的城市垃圾幸福度係數。\n" +
                    "  - 0 = 整體優秀\n" +
                    "  - -1 = 需要小幅調整\n" +
                    "  - -2 到 -4 = 略有異味\n" +
                    "  - -5 到 -10 = 垃圾問題\n" +
                    "路徑數值：\n" +
                    "  - 收集門檻是原版最低值；考慮目標的路徑邏輯可依每輛車提高此門檻，以保護前往目標所需的容量。\n" +
                    "  - 請求門檻是遊戲建立或保留收集請求前所需的最低垃圾量。\n" +
                    "- 當建築垃圾超過目前警告級別時會出現警告圖示。\n" +
                    "- 硬上限 = 建築可累積的最大垃圾量。\n" +
                    "- 待處理 = 目前尚未指派給垃圾車或路徑的有效請求。\n" +
                    "- 部分待處理請求稍後會被指派；如果原版重新驗證後認為目標不再需要服務，部分請求也可能之後被清除。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "遊戲門檻（內部垃圾單位）：收集={1:N0}, 請求={0:N0}, 警告圖示={2:N0}, 硬上限={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "門檻：<GarbageParameterData 無法使用>" },
                { "MG.Status.Log.AdaptiveMargin", "目標預留：{0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "目標預留：目前={0:N0}% | 遊戲載入時基準值={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "垃圾產量：{0:N0} t/月 | 目前處理：{2:N0} t/月 | 處理能力：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服務評分：{0} | 原始值={1:N2} | 四捨五入={2:N0}" },
                { "MG.Status.Log.Requests", "收集請求：待處理={1:N0}, 已派遣={2:N0}, 總計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待處理目標中的最高垃圾量：{0:N0} ({1:N1}t)，位置 {2}" },
                { "MG.Status.Log.PendingPeakNone", "待處理目標中的最高垃圾量：無" },
                { "MG.Status.Log.Producers", "建築：高於警告級別 {0:N0} | 總計 {1:N0} | 有垃圾 {2:N0} | 高於請求門檻 {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "建築垃圾（僅非零）：平均={0:N0} ({1:N1}t) | 中位數={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t)，位置 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告圖示的建築（至少 {1:N0} 單位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "設施：總計 {0:N0} | 垃圾車 {1:N0} | 傾卸車 {2:N0}（行駛中 {3:N0}）| 工人 {4:N0}" },
                { "MG.Status.Log.Trucks", "垃圾車：行駛中 {2:N0}（返回中 {3:N0}）| 已停放 {1:N0} | 已停用 {4:N0} | 總計 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "設施摘要" },
                { "MG.Status.Log.FacilityLine", "- 設施 {0}：垃圾車={1:N0}（行駛中 {2:N0}, 已停放 {3:N0}）| 傾卸車={4:N0}（行駛中 {5:N0}）| 最大工人數={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "整體優秀" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "需要小幅調整" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "略有異味" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾問題" },

                { "MG.Status.Log.ThresholdsHeader", "門檻 + 服務" },
                { "MG.Status.Log.RequestsHeader", "請求" },
                { "MG.Status.Log.BuildingsHeader", "建築" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t+ 建築" },
                { "MG.Status.Log.LocalTransferProbeHeader", "本地垃圾轉運探針" },
                { "MG.Status.Log.LocalTransferProbeNone", "未找到本地垃圾設施。" },
                { "MG.Status.Log.OutsideTransferProbeHeader", "外部連線垃圾轉運探針" },
                { "MG.Status.Log.OutsideTransferProbeNone", "未找到外部連線垃圾設施。" },

                { "MG.Status.Log.TransferProbeHeader", "垃圾轉運探針" },
                { "MG.Status.Log.TransferProbeNone", "未找到垃圾儲存-轉運設施。" },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | 已存={1,7:N0} ({2,4:N1}t) / 容量={3,7:N0} ({4,4:N1}t) | 接收={5:N2} | 傳送={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "車輛" },

                { "MG.Status.Log.CriticalBuildingsNone", "無" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
