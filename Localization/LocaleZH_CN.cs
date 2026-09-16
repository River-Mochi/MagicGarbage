// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_CN(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "关于" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自动清理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "自行管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "状态" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模组信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "链接" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用说明" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**启用 [ ✓ ]**后会保持整座城市清洁。\n" +
                    "\n" +
                    "当 **Total Magic** 开启时：\n" +
                    "- Trash Boss 会被强制关闭。\n" +
                    "- Trash Boss 滑块不会应用（数值会保存供以后使用）。\n" +
                    "- 由于原版调度逻辑的时序，少量车辆仍可能继续移动。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系统，同时保留原版垃圾逻辑运行。\n" +
                    "\n" +
                    "- 当 **Trash Boss 开启 [ ✓ ]**时，Total Magic 会被强制关闭。\n" +
                    "- 只有启用 Trash Boss 时滑块才会应用。\n" +
                    "- Total Magic 和 Trash Boss 都可以**关闭**以使用原版设置，\n" +
                    "  同时仍可查看**状态报告**；它只会在你进入“选项”菜单时更新（开销很低）。"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "垃圾车载量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆垃圾车可装载的垃圾量。**\n" +
                    "**100% = 原版**垃圾车容量（20t）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "设施存储量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**设施可存储的垃圾量。**\n" +
                    "**100% = 原版**存储量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "设施处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**设施处理进入垃圾的速度。**\n" +
                    "**100% = 原版**处理速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "设施车队" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每个设施可派出的车辆数量。**\n" +
                    "**100% = 原版**车辆数量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "目标预留" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**控制垃圾车在前往已分配建筑途中，多早开始对可选收集点进行筛选。**\n" +
                    "**10% 是 1.6.2 版本的原版数值。**\n" +
                    "以普通 20t 垃圾车为例：\n" +
                    "- 10% 会提前 2t 开始为分配目标保留空间。\n" +
                    "- 15% 会提前 3t。\n" +
                    "- 25% 会提前 5t。\n" +
                    "数值越高，安全余量越大。垃圾车会更早跳过小额收集，从而为已分配建筑留下更多空间。"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "为繁忙城市应用较均衡的数值。\n" +
                    "垃圾车载量 **200%** | 存储 **150%** | 处理 **250%**\n" +
                    "车队 **100%** | 目标预留 **15%**。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "重置滑块" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "重置标准 Trash Boss 滑块。\n" +
                    "- 百分比滑块恢复为 **100%**。\n" +
                    "- 目标预留恢复为**原版 10%**。\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "当前模组版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "打开 Paradox Mods 页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在浏览器中打开 Discord 邀请。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自动清理状态>\n" +
                    "  * Total Magic 开启 = **[ ✓ ]**\n" +
                    "  * 垃圾会自动清除 - 完成。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<自行管理状态>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 按需要调整滑块。\n" +
                    "  * 仍使用游戏原有垃圾系统，但更好地自行管理车辆/设施。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<状态 / 原版状态>\n" +
                    "  * Total Magic = 关闭\n" +
                    "  * Trash Boss = 关闭\n" +
                    "  * 仅显示状态报告。\n" +
                    "  * 原版垃圾系统保持不变。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使用说明" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "垃圾服务评分" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "游戏计算的全市平均垃圾幸福度影响。\n" +
                    "整体评分良好时仍可能有少数问题建筑，因此也请检查 **7t+ 建筑**。\n" +
                    "**0 = 整体优秀**\n" +
                    "**-1 = 需要小幅调整**\n" +
                    "**-2 到 -4 = 略有异味**\n" +
                    "**-5 或更低 = 垃圾问题**\n" +
                    "\n" +
                    "使用垃圾车和设施滑块改善服务，然后让城市运行一段时间再重新检查。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "垃圾量达到或超过 **7000 / 7t** 的垃圾产出建筑数量。\n" +
                    "这个固定的早期预警指标可帮助你在建筑达到游戏警告图标级别之前判断是否需要提高服务能力。\n" +
                    "使用“详细状态写入日志”可列出这些建筑的 Entity ID。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "显示全市垃圾产量、当前处理量以及设施可用处理能力。\n" +
                    "如果月度产量高于处理能力，请提高处理速度。\n" +
                    "所有数值均以吨/月为单位。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集请求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**待处理** = 当前尚未分配给垃圾车或路径的有效收集请求。\n" +
                    "**已调度** = 已经完成分配的有效收集请求。\n" +
                    "**总计** = 垃圾处理流程中当前所有**有效**请求。\n" +
                    "\n" +
                    "这与**高于请求阈值**不同，后者统计的是建筑而不是请求。\n" +
                    "部分待处理请求稍后会被分配；如果原版重新验证后认为目标不再需要服务，部分请求也可能随后被清除。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 当前存有任意垃圾的建筑。\n" +
                    "**总计** = 城市中所有会产生垃圾的建筑。\n" +
                    "**高于请求阈值** = 当前垃圾量足以创建收集请求的**建筑**数量。\n" +
                    "详细状态日志会显示游戏当前实时请求阈值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已统计垃圾设施的摘要。\n" +
                    "**设施** = 已统计的垃圾建筑。\n" +
                    "**垃圾车** = 普通收集车辆。在工业废物设施中，它们收集的是工业废物而不是普通垃圾。\n" +
                    "**自卸卡车** = 用于设施之间的垃圾转运。\n" +
                    "**最大工人数** = 这些设施的工人容量总和。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**行驶中** = 当前正在城市中运行的车辆。\n" +
                    "**返回中** = 行驶中且被标记返回所属设施的车辆子集。\n" +
                    "**已停放** = 停放在设施中的车辆。\n" +
                    "**总计** = 所有垃圾车数量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "详细状态写入日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "将更详细的垃圾报告写入 **Logs/MagicGarbage.log**。\n" +
                    "包含整理后的城市垃圾统计数据。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "打开 **MagicGarbage.log**。如果文件不存在或无法打开，则改为打开游戏的 Logs 文件夹。" },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未加载城市。" },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "整体优秀 ({0:N0}) | 更新于 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "需要小幅调整 ({0:N0}) | 更新于 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "略有异味 ({0:N0}) | 更新于 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "垃圾问题 ({0:N0}) | 更新于 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 个 7t+ 建筑" },

                { "MG.Status.Row.GarbageProcessing", "产生 {0:N0} t | 当前处理 {2:N0} t | 处理能力 {1:N0} t" },
                { "MG.Status.Row.Requests", "待处理 {1:N0} | 已调度 {2:N0} | 总计 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高于请求阈值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 个设施 | {1:N0}/{2:N0} 垃圾车/自卸卡车 | {3:N0} 名工人" },
                { "MG.Status.Row.Trucks", "行驶中 {1:N0}（返回中 {3:N0}）| 已停放 {2:N0} | 总计 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "尚无设施数据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾状态 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "当前模组设置" },
                { "MG.Status.Log.SettingsTrashBoss", "Trash Boss 滑块（已保存）：垃圾车载量={0:N0}% | 设施存储={1:N0}% | 设施处理={2:N0}% | 设施车队={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "图例：\n" +
                    "- 垃圾产量、当前处理量和处理能力均以吨/月为单位。\n" +
                    "- 以下阈值使用内部垃圾单位，而不是吨。\n" +
                    "- 面向玩家显示时，游戏换算为 100 单位 = 0.1t，1,000 单位 = 1t。\n" +
                    "- 垃圾服务评分 = 游戏中的城市垃圾幸福度系数。\n" +
                    "  - 0 = 整体优秀\n" +
                    "  - -1 = 需要小幅调整\n" +
                    "  - -2 到 -4 = 略有异味\n" +
                    "  - -5 到 -10 = 垃圾问题\n" +
                    "路径数值：\n" +
                    "  - 收集阈值是原版最低值；考虑目标的路径逻辑可以按每辆车提高该阈值，以保护前往目标所需的容量。\n" +
                    "  - 请求阈值是游戏创建或保留收集请求前所需的最低垃圾量。\n" +
                    "- 当建筑垃圾超过当前警告级别时会出现警告图标。\n" +
                    "- 硬上限 = 建筑可累积的最大垃圾量。\n" +
                    "- 待处理 = 当前尚未分配给垃圾车或路径的有效请求。\n" +
                    "- 部分待处理请求稍后会被分配；如果原版重新验证后认为目标不再需要服务，部分请求也可能随后被清除。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "游戏阈值（内部垃圾单位）：收集={1:N0}, 请求={0:N0}, 警告图标={2:N0}, 硬上限={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "阈值：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.AdaptiveMargin", "目标预留：{0:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "垃圾产量：{0:N0} t/月 | 当前处理：{2:N0} t/月 | 处理能力：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服务评分：{0} | 原始值={1:N2} | 舍入值={2:N0}" },
                { "MG.Status.Log.Requests", "收集请求：待处理={1:N0}, 已调度={2:N0}, 总计={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待处理目标中的最高垃圾量：{0:N0} ({1:N1}t)，位置 {2}" },
                { "MG.Status.Log.PendingPeakNone", "待处理目标中的最高垃圾量：无" },
                { "MG.Status.Log.Producers", "建筑：高于警告级别 {0:N0} | 总计 {1:N0} | 有垃圾 {2:N0} | 高于请求阈值 {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "建筑垃圾（仅非零）：平均={0:N0} ({1:N1}t) | 中位数={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t)，位置 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告图标的建筑（至少 {1:N0} 单位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "设施：总计 {0:N0} | 垃圾车 {1:N0} | 自卸卡车 {2:N0}（行驶中 {3:N0}）| 工人 {4:N0}" },
                { "MG.Status.Log.Trucks", "垃圾车：行驶中 {2:N0}（返回中 {3:N0}）| 已停放 {1:N0} | 已禁用 {4:N0} | 总计 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "设施摘要" },
                { "MG.Status.Log.FacilityLine", "- 设施 {0}：垃圾车={1:N0}（行驶中 {2:N0}, 已停放 {3:N0}）| 自卸卡车={4:N0}（行驶中 {5:N0}）| 最大工人数={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "整体优秀" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "需要小幅调整" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "略有异味" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾问题" },

                { "MG.Status.Log.ThresholdsHeader", "阈值 + 服务" },
                { "MG.Status.Log.RequestsHeader", "请求" },
                { "MG.Status.Log.BuildingsHeader", "建筑" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t+ 建筑" },
                { "MG.Status.Log.LocalTransferProbeHeader", "本地垃圾转运探针" },
                { "MG.Status.Log.LocalTransferProbeNone", "未找到本地垃圾设施。" },
                { "MG.Status.Log.OutsideTransferProbeHeader", "外部连接垃圾转运探针" },
                { "MG.Status.Log.OutsideTransferProbeNone", "未找到外部连接垃圾设施。" },

                { "MG.Status.Log.TransferProbeHeader", "垃圾转运探针" },
                { "MG.Status.Log.TransferProbeNone", "未找到垃圾存储-转运设施。" },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | 已存={1,7:N0} ({2,4:N1}t) / 容量={3,7:N0} ({4,4:N1}t) | 接收={5:N2} | 发送={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "车辆" },

                { "MG.Status.Log.CriticalBuildingsNone", "无" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
