// LocaleJA.cs
// Japanese (ja-JP)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "情報" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "トータルマジック" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "セミマジック"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod 情報"         },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク"           },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用メモ"         },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "トータルマジック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [X]** にすると、街中のゴミが即座に消えます。\n" +
                    "ゴミ施設やゴミ収集車は、ほぼ見た目だけの存在になります。\n\n" +

                    "**トータルマジック** が ON の間は:\n" +
                    "- セミマジックは自動的に OFF になります。\n" +
                    "- セミマジックのスライダー設定はすべて無視されます。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "セミマジック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "通常のゴミゲームプレイを保ちつつ、少し強化された設定にします。\n" +
                    "- 完全な魔法ではなく、強力なトラックと施設で対応します。\n" +
                    "- セミマジックが ON のとき、トータルマジックは自動的に OFF になります。\n" +
                    "- 下のスライダーは、セミマジックが有効なときだけ効果があります。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**1 台のトラックが運べるゴミの量。**\n" +
                    "- 100% = バニラの積載量。\n" +
                    "- 高くするほど、必要な往復回数が減ります。\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "施設トラック数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設から出せるトラックの台数。**\n" +
                    "- 100% = バニラの台数。\n" +
                    "- 最大 400% = トラック数を最大 +300% 増やせます。\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**ゴミ処理施設がゴミを処理する速さ。**\n" +
                    "- 100% = バニラの処理速度。\n" +
                    "- 高くするほど、ゴミがより早く焼却 / リサイクルされます。\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "施設の保管容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が満杯になる前に保管できるゴミの量。**\n" +
                    "- 100% = バニラの容量。\n" +
                    "- 高くするほど、「満杯」表示が出るまで余裕が増えます。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "ゲーム標準に戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "すべてのセミマジックスライダーを **100%**（バニラ値）にリセットします。\n" +
                    "Mod を入れたまま、ゴミサービスの数値を変えたくない場合に使ってください。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "おすすめ設定" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "おすすめのセミマジック値を適用します:\n" +
                    "- トラック積載量: **200%**\n" +
                    "- 施設トラック数: **150%**\n" +
                    "- 処理速度: **200%**\n" +
                    "- 保管容量: **200%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "この Mod の表示名です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の Mod バージョン。" },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "作者の Mod 一覧の Paradox Mods ページを開きます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "ブラウザで CS2 Modding Discord を開きます。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<おすすめ初期状態>\n" +
                    "  * トータルマジック ON = **[X]**\n" +
                    "  * 街中のゴミがすべて即座に消えます\n" +
                    " <-------------------------------------->\n\n" +
                    "<セミマジック・スーパー収集車モード>\n" +
                    "  * トータルマジック OFF = **[ ]**\n" +
                    "  * セミマジック ON = **[X]** にして、[100 >> 500] / [100 >> 400] で好みに調整。\n" +
                    "  * バニラ風ゲームプレイ＋強力なトラックと施設。\n" +
                    " <-------------------------------------->\n\n" +
                    "<完全バニラ状態>\n" +
                    "  * トータルマジック OFF = **[ ]**\n" +
                    "  * セミマジック = **[X]**（「ゲーム標準に戻す」をクリック）\n" +
                    "  * すべてのスライダーが 100%（バニラ上限）\n" +
                    "  * まったくの標準ゲームプレイ。\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)),
                    string.Empty
                },
            };
        }

        public void Unload()
        {
        }
    }
}
