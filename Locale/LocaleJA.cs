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
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "情報" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "完全マジック" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "セミマジック" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod 情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用上の注意" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)), "マジック・ガーベジ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**有効 [X]** にすると、都市内のゴミが即座にすべて消去される。\n" +
                    "見た目目的を除き、ゴミ処理系の建物は不要となる。\n\n" +
                    "選択肢 1 の **完全マジック** か、\n" +
                    "選択肢 2 の **セミマジック** のどちらか一方を使用する（同時使用の追加効果はない）。"
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "ゴミ収集車の容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**セミマジック**：高容量トラックのモード。\n" +
                    "ガーベジを簡易化したいが完全削除はしない場合：\n" +
                    "- マジック・ガーベジを **無効** [ ] にする\n" +
                    "- スライダー **[100 >> 500]** でトラック容量を増やす\n\n" +
                    "**---------------------------------------**\n" +
                    " スライダーはバニラ値に対する倍率調整。\n" +
                    "**100% = トラック1台あたり 20 t**（バニラ）\n" +
                    "**500% = トラック1台あたり 100 t**\n\n" +
                    "**---------------------------------------**\n\n" +
                    "バニラ挙動に戻す場合は、マジック・ガーベジを [OFF]、スライダーを 100% に設定する。"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "この Mod の表示名。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の Mod バージョン。" },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "作者の Paradox Mods ページを開く。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "CS2 モッディング Discord をブラウザで開く。" },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<推奨デフォルト>\n" +
                    "  * 完全マジック = **[X]**\n" +
                    "  * スライダー = 100%\n" +
                    "  * すべてのゴミが即時に消去\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<セミマジック（高容量トラック）>\n" +
                    "  * マジック・ガーベジ = **[ ]**（無効）\n" +
                    "  * スライダーを 100–500% に設定し容量を拡大\n" +
                    "  * トラック数は少なめでも運用可能\n\n" +
                    " <-------------------------------------->\n\n" +
                    "<完全バニラ>\n" +
                    "  * マジック・ガーベジ = **[ ]**\n" +
                    "  * スライダー = 100%（バニラ）\n" +
                    "  * 標準のゲームプレイと同一。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },
            };
        }

        public void Unload()
        {
        }
    }
}
