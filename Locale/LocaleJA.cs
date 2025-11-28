// Locale/LocaleJA.cs
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
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "情報" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自動クリーン" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "セルフ管理"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod 情報"    },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク"      },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用ノート"  },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "トータルマジック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** にすると、街中のゴミが即座にすべて消えます。\n" +
                    "ゴミ処理施設やゴミ収集車は、ほぼ見た目用の飾りになります。\n\n" +

                    "**トータルマジック** が ON の間は:\n" +
                    "- セミマジックは自動的に OFF になります。\n" +
                    "- セミマジックのスライダーはすべて無視されます。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "セミマジック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "ゴミシステムを直接調整できます。バニラのシミュレーションはそのまま動きます。\n\n" +
                    "- **セミマジックが ON [ ✓ ]** のとき、トータルマジックは自動で OFF になります。\n" +
                    "- すべてのゴミ収集車と施設の性能を調整できます。\n" +
                    "- セミマジックが有効 [ ✓ ] のときだけ、スライダーが効果を持ちます。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるゴミの量。**\n" +
                    "100% = 通常のゲーム標準値。\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "施設からのトラック台数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**1つの施設から出せるトラックの台数。**\n" +
                    "100% = バニラの標準台数。\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設がゴミを処理する速さ。**\n" +
                    "100% = バニラの処理速度。\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "施設の保管容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるゴミの量。**\n" +
                    "100% = バニラの保管容量。\n" +
                    "値を上げると、より多くのゴミを貯められます。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "ゲーム標準に戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "すべてのスライダーを **100%**（バニラ値）にリセットします。\n" +
                    "通常のゲーム挙動に戻します。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "おすすめのセミマジック設定を適用します:\n" +
                    "- トラック積載量: **200%**\n" +
                    "- 施設トラック台数: **150%**\n" +
                    "- 処理速度: **200%**\n" +
                    "- 保管容量: **150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "この Mod の表示名。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "現在の Mod バージョン。"
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "**Paradox Mods** 上の作者の Mod ページを開きます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "ブラウザで **Discord**（CS2 Modding サーバー）を開きます。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * トータルマジック ON = **[ ✓ ]**\n" +
                    "  * すべてのゴミが即座に削除されます\n" +
                    " <-------------------------------------->\n\n" +
                    "<セルフ管理状態>\n" +
                    "  * セミマジックを有効にする = **[ ✓ ]**\n" +
                    "  * スライダー [100 >> 500] を好みに合わせて調整。\n" +
                    "  * バニラ風のゴミシミュレーション + 強化されたトラックと施設をチューニング。\n" +
                    " <-------------------------------------->\n\n" +
                    "<通常のバニラゲーム>\n" +
                    "  * セミマジック = **[ ✓ ]**\n" +
                    "  * **[ゲーム標準に戻す]** をクリック\n" +
                    "  * すべてのスライダーが 100%（バニラ）\n" +
                    "  * 完全に通常のゲームプレイ。\n"
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
