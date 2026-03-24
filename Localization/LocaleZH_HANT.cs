// File: Locale/LocaleZH_HANT.cs
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
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "狀態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用說明" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**啟用 [ ✓ ]** 後可讓整座城市保持乾淨。\n\n" +
                    "當 **Total Magic** 為 ON 時：\n" +
                    "- Trash Boss 會被強制設為 OFF。\n" +
                    "- Trash Boss 滑桿不會生效（數值仍會保存）。\n" +
                    "- 由於原版調度邏輯的時序影響，仍可能會有少量垃圾車繼續移動。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "在保留原版垃圾系統邏輯的同時，直接調整垃圾系統。\n\n" +
                    "- 當 **Trash Boss 為 ON [ ✓ ]** 時，Total Magic 會被強制設為 OFF。\n" +
                    "- 只有啟用 Trash Boss 時滑桿才會生效。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "垃圾車載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛垃圾車可運送的垃圾量。**\n" +
                    "100% = 遊戲預設值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**設施處理流入垃圾的速度。**\n" +
                    "100% = 原版速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "設施儲存容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**設施可儲存的垃圾量。**\n" +
                    "100% = 原版容量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "設施車隊" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個設施可派出的垃圾車數量。**\n" +
                    "100% = 原版車輛數。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "套用推薦的 Trash Boss 數值：\n" +
                    "- 垃圾車載量：**200%**\n" +
                    "- 處理速度：**200%**\n" +
                    "- 儲存容量：**160%**\n" +
                    "- 設施垃圾車數量：**140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "將所有滑桿恢復為 **100%**（原版數值）。"
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
                    "<自動清理模式>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * 垃圾幾乎會被立刻清除\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理模式>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 依喜好調整滑桿。\n" +
                    "  * 保留原版垃圾邏輯，同時更好地管理車輛/設施。\n" +
                    " <-------------------------------------->\n\n" +
                    "<一般原版模式>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 點擊 **[遊戲預設]**\n" +
                    "  * 所有滑桿恢復到 100%（原版）\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "顯示全城目前垃圾量與總處理速度。\n" +
                    "如果每月 Produced 遠高於 Processed，就應該提高處理能力。\n" +
                    "**Produced** 與 **Processed** 使用每月噸數。\n" +
                    "更新時間 = 上次重新整理時間。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集請求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 仍未分配垃圾車或路線的有效收集請求。\n" +
                    "**Dispatched** = 已經分配的有效收集請求。\n" +
                    "**Total** = 目前所有有效的垃圾收集請求。\n" +
                    "這個數字有時會暫時高於 **Above request threshold**，因為舊請求會在之後由遊戲重新驗證後清除。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建築" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 目前有垃圾的建築。\n" +
                    "**Total** = 城市中所有會產生垃圾的建築。\n" +
                    "**Above request threshold** = 垃圾量已達到可建立收集請求條件的建築。\n" +
                    "在原版中通常表示超過 <100> 垃圾單位。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "設施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已統計垃圾設施的彙總資訊。\n" +
                    "**Facilities** = 已統計的垃圾設施數量。\n" +
                    "**Trucks total** = 這些設施擁有的垃圾車總數。\n" +
                    "**Max workers** = 這些設施的最大員工容量總和。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 目前在城市中行駛的垃圾車。\n" +
                    "**Returning** = Moving 中正在返回設施的那部分車輛。\n" +
                    "**Parked** = 停在設施裡的垃圾車。\n" +
                    "**Total** = 垃圾車總數。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "將詳細狀態寫入日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "將更詳細的垃圾報告寫入 **Logs/MagicGarbage.log**。\n" +
                    "包括簡短說明、目前閾值、停用車輛以及每個設施的最大員工數。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "開啟日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "開啟 Logs/ 資料夾。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未載入城市。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} 噸已產生 | {1:N0} 噸已處理 | 更新於 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 待處理 | {2:N0} 已派送 | 總計 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 超過請求閾值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 個設施 | 垃圾車總計 {1:N0} | 最大員工 {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} 行駛中 ({3:N0} 返回中) | {2:N0} 停放中 | 總計 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "暫無設施資料。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾狀態 ({0})" },
                { "MG.Status.Log.City", "城市: {0}" },
                { "MG.Status.Log.Mode", "模式: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "說明:\n" +
                    "- Produced/Processed 使用每月噸數。\n" +
                    "- 下方閾值使用的是內部垃圾單位，不是噸。\n" +
                    "- 收集閾值 = 垃圾車會從建築收集垃圾所需的最低垃圾量。\n" +
                    "- 請求閾值 = 遊戲建立或保留收集請求所需的最低垃圾量。\n" +
                    "- 警告閾值 = 建築上方可能出現警告圖示的垃圾量。\n" +
                    "- 上限 = 建築可累積的最大垃圾量。\n" +
                    "- 返回中 = 行駛中的一部分車輛。\n" +
                    "- 有效請求數量有時會暫時高於超過請求閾值的建築數量，因為舊請求會在之後由原版重新驗證後清除。\n" +
                    "- 下方員工數字目前顯示的是每個設施的 **最大員工數**。"
                },
                { "MG.Status.Log.Thresholds",
                    "閾值 (內部垃圾單位): 收集={1:N0}, 請求={0:N0}, 警告={2:N0}, 上限={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "閾值: <GarbageParameterData 無法使用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾: {0:N0} 噸/月 | 處理: {1:N0} 噸/月" },
                { "MG.Status.Log.Requests", "收集請求: 待處理={1:N0}, 已派送={2:N0}, 總計={0:N0}" },
                { "MG.Status.Log.Producers", "建築: 總計={0:N0} | 有垃圾={1:N0} | 超過請求閾值={2:N0} | 警告等級={3:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "設施: 總計={0:N0} | 垃圾車總計={1:N0} | 最大員工={2:N0}" },
                { "MG.Status.Log.Trucks", "垃圾車: 行駛中={2:N0} ({3:N0} 返回中) | 停放中={1:N0} | 已停用={4:N0} | 總計={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "設施彙總" },
                { "MG.Status.Log.FacilityLine", "- 設施 {0}: 行駛中={2:N0}, 停放中={3:N0}, 總計={1:N0}, 最大員工={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
