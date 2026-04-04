// File: Localization/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全自动清理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**启用 [ ✓ ]** 后，整座城市都会保持干净。\n\n" +
                    "当 **完全自动清理** 为 ON 时：\n" +
                    "- 垃圾管理 会被强制设为 OFF。\n" +
                    "- 垃圾管理 的滑块不会生效（数值会保留，之后还能继续用）。\n" +
                    "- 由于 vanilla 的派车时机，一些卡车仍然可能继续跑。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "垃圾管理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系统；vanilla 的垃圾逻辑仍会继续运行。\n\n" +
                    "- 当 **垃圾管理 为 ON [ ✓ ]** 时，完全自动清理 会被强制设为 OFF。\n" +
                    "- 只有启用 垃圾管理 时，这些滑块才会生效。\n" +
                    "- 如果只想看 **状态报告**，完全自动清理 和 垃圾管理 可以同时保持 **OFF**。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡车载量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆卡车能运多少垃圾。**\n" +
                    "**100% = 游戏默认** 数值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "设施储量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**每个设施能储存多少垃圾。**\n" +
                    "**100% = vanilla 储量**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "设施处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**设施处理流入垃圾的速度。**\n" +
                    "**100% = vanilla 处理速度**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "设施车队" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每个设施可以派出的卡车数量。**\n" +
                    "**100% = vanilla 卡车数量**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "高级选项" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**可选的高级微调：阈值 + 垃圾对幸福感的影响。**\n" +
                    "当为 **OFF** 时，收集/请求阈值和垃圾幸福度 **保持 vanilla**。\n" +
                    "当为 **ON** 时，会显示 **高级滑块**。\n\n" +
                    "<--- 垃圾幸福度示例 --->\n" +
                    " - <Vanilla> 100/65 = 第 1 次惩罚在 <165>。\n" +
                    " - <推荐> 550/150 = 第 1 次惩罚在 <700>。\n" +
                    " - <非常宽松> 950/200 = 第 1 次垃圾惩罚在 <1150>。\n" +
                    "方便点：就算这个选项是 OFF，之前的滑块数值也会保留。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "派车请求阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建筑内垃圾达到这个量后，才会创建或保留卡车派遣请求。**\n" +
                    "Vanilla = **100** 垃圾单位。\n" +
                    "**100 垃圾单位 = 0.1t**\n" +
                    "**1,000 垃圾单位 = 1t**\n" +
                    "这个值请保持不低于收集阈值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "收集阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**建筑内垃圾至少达到这个量后，卡车才会去收。**\n" +
                    "Vanilla = **20** 垃圾单位。\n" +
                    "收集阈值绝不能高于派车请求阈值。\n" +
                    "为了避免逻辑出问题，派车请求阈值应始终保持与有效收集值相同或更高；" +
                    " 如果卡车已经 dispatch 到建筑，但收集值更高，它就可能收不到垃圾（积累速度也会影响）。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "应用 **推荐** 的 垃圾管理 标准数值。\n" +
                    "不会更改 高级选项 的设置。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "游戏默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "把 垃圾管理 滑块恢复为 **vanilla 数值**。\n" +
                    "不会 <not> 更改 高级选项 的设置。\n" +
                    "**Vanilla：**\n" +
                    "- 百分比滑块恢复到 **100%**。\n" +
                    "- 派车请求阈值恢复到 **100 units**。\n" +
                    "- 收集阈值恢复到 **20 units**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾幸福度基线" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建筑内垃圾达到这个基线后，才会开始出现健康 + 幸福惩罚。**\n" +
                    "**Vanilla = 100** 垃圾单位。\n" +
                    "基线越高 = 建筑在受到惩罚前能容忍更多垃圾。\n" +
                    "100 垃圾单位 = 0.1t\n" +
                    "说明：\n" +
                    "- <阈值> = 系统行为开始触发的位置\n" +
                    "- <基线> = 惩罚公式开始计算的位置\n" +
                    "- <步长> = 公式每次增加的幅度，也就是惩罚增长速度"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾幸福度步长" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超过基线后的额外垃圾量，每达到一次就会触发 -1 惩罚。**\n" +
                    "Vanilla = **65** 垃圾单位。\n" +
                    "步长越高 = 惩罚增长越慢。\n" +
                    "游戏里的垃圾惩罚上限是 **-10**。\n" +
                    "vanilla 的第一次 <-1 penalty> 出现在 **165 垃圾**（100 baseline + 65 step）\n" +
                    "如果提高了阈值，也要配合幸福度滑块一起调，不然惩罚可能会比正常更重。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "应用 **推荐** 的 高级选项 数值。\n" +
                    "启用 高级选项。\n" +
                    "第一次垃圾惩罚会从 **700 垃圾** 开始（550 baseline + 150 step）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "游戏默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "把 高级选项 的数值恢复为 **vanilla**。\n" +
                    "把 **高级选项 切到 OFF**。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "这个模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "当前模组版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "打开 Paradox Mods 页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在浏览器中打开 Discord 邀请链接。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自动清理状态>\n" +
                    "  * 完全自动清理 ON  = **[ ✓ ]**\n" +
                    "  * 垃圾会自动被清掉 - 完成。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手动管理状态>\n" +
                    "  * 垃圾管理 = **[ ✓ ]**\n" +
                    "  * 按自己想要的方式调滑块。\n" +
                    "  * 可选：启用 高级选项 来调阈值 + 垃圾幸福度。\n" +
                    "  * 还是游戏原本的垃圾系统，只是卡车/设施更好控。\n" +
                    " <-------------------------------------->\n\n" +
                    "<状态 / vanilla 状态>\n" +
                    "  * 完全自动清理 = OFF\n" +
                    "  * 垃圾管理 = OFF\n" +
                    "  * 只看状态报告。\n" +
                    "  * vanilla 垃圾系统保持不变。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "显示当前全城垃圾量和总处理速度。\n" +
                    "如果每月产生的垃圾远高于处理量，就该提高处理能力。\n" +
                    "**已产生** 和 **已处理** 以每月吨数显示。\n" +
                    "<更新时间 = 上次刷新时间。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集请求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**待处理** = 当前有效、但还没分配给卡车或路线的收集请求。\n" +
                    "**已派出** = 当前有效、已经分配出去的收集请求。\n" +
                    "**总计** = 当前 **有效** 请求实体的数量（垃圾流程里）。\n\n" +
                    "技术说明：这和 <高于请求阈值> 不一样。这里统计的是 <请求>，不是建筑。\n" +
                    "有些待处理请求会稍后被分配；也有些会在 vanilla 重新校验后被清掉，因为目标已经不再需要服务。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 当前内部有垃圾的建筑。\n" +
                    "**总计** = 城里所有会产生垃圾的建筑。\n" +
                    "**高于请求阈值** = 当前垃圾多到足以创建收集请求的 **建筑** 数量。\n" +
                    "在 vanilla 里，请求阈值是 **100** 内部垃圾单位。\n" +
                    "高级选项 可以覆盖请求阈值和收集阈值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已统计垃圾设施的摘要。\n" +
                    "**设施** = 被统计的垃圾建筑。\n" +
                    "**垃圾车** = 普通收集卡车。在工业废物设施里，它们收集的是工业废物而不是普通垃圾。\n" +
                    "**Dump trucks** = 设施之间的垃圾转运。\n" +
                    "**最大员工数** = 这些设施的总员工容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "卡车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**行驶中** = 当前正在城里跑的卡车。\n" +
                    "**返回中** = 行驶中的卡车里，正在回设施的那部分。\n" +
                    "**停放中** = 停在设施里的卡车。\n" +
                    "**总计** = 所有垃圾车的数量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "详细状态写入日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "把更详细的垃圾报告写进 **Logs/MagicGarbage.log**。\n" +
                    "里面会有简短图例、vanilla 参考值，以及很多城市当前垃圾统计。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "打开游戏的 Logs/.. 文件夹。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "还没有加载城市。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 已产生 | {1:N0} t 已处理 | 更新于 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 待处理 | {2:N0} 已派出 | {0:N0} 总计" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高于请求阈值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 个设施 | {1:N0} 辆垃圾车 | {2:N0} dump trucks | {3:N0} 最大员工数" },
                { "MG.Status.Row.Trucks", "{1:N0} 行驶中 ({3:N0} 返回中) | {2:N0} 停放中 | {0:N0} 总计" },
                { "MG.Status.Row.FacilitiesNone", "还没有设施数据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾状态 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：完全自动清理={0}，垃圾管理={1}" },
                { "MG.Status.Log.Legend",
                    "图例：\n" +
                    "- 已产生/已处理 使用每月吨数。\n" +
                    "- 下方阈值使用的是内部垃圾单位，不是吨。\n" +
                    "- 玩家看到的换算大致是：100 单位 = 0.1t，1,000 单位 = 1t。\n" +
                    "阈值滑块：\n" +
                    "  - 收集阈值 = 建筑里的垃圾至少达到多少，卡车才会去收。\n" +
                    "  - 请求阈值 = 垃圾至少达到多少，游戏才会创建或保留收集请求。\n" +
                    "- 警告图标 = 建筑上方出现警告图标所需的垃圾量。\n" +
                    "- 硬上限 = 建筑最多能累积的垃圾量。\n" +
                    "- 待处理 = 当前有效、但还没分配给卡车或路线的请求。\n" +
                    "- 有些待处理请求会稍后被分配；也有些会在 vanilla 重新校验后被清掉，因为目标已经不再需要服务。\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "游戏阈值（内部垃圾单位）：收集={1:N0}，请求={0:N0}，警告图标={2:N0}，硬上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "阈值：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 处理：{1:N0} t/月" },
                { "MG.Status.Log.Requests", "收集请求：待处理={1:N0}，已派出={2:N0}，总计={0:N0}" },
                { "MG.Status.Log.PendingPeak", "最高待处理目标：{0:N0} ({1:N1}t)，位置 {2}" },
                { "MG.Status.Log.Producers", "建筑：{0:N0} 总计 | {1:N0} 有垃圾 | {2:N0} 高于请求阈值 | {3:N0} 达到警告等级" },
                { "MG.Status.Log.ProducerGarbageStats", "建筑垃圾（仅统计非零）：平均={0:N0} ({1:N1}t) | 中位数={2:N0} ({3:N1}t) | 最大值={4:N0} ({5:N1}t)，位置 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告的建筑（至少 {1:N0} 单位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "设施：{0:N0} 总计 | {1:N0} 辆垃圾车 | {2:N0} dump trucks ({3:N0} 行驶中) | {4:N0} 员工" },
                { "MG.Status.Log.Trucks", "垃圾车：{2:N0} 行驶中 ({3:N0} 返回中) | {1:N0} 停放中 | {4:N0} 已禁用 | {0:N0} 总计" },
                { "MG.Status.Log.FacilitiesHeader", "设施摘要" },
                { "MG.Status.Log.FacilityLine", "- 设施 {0}：垃圾={1:N0}（{2:N0} 行驶中，{3:N0} 停放中） | dump={4:N0}（{5:N0} 行驶中） | 最大员工数={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
