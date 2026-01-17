// File: Localization/LocaleJA.cs
// Japanese (ja-JP)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "手動管理"      },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod情報"      },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使い方"       },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "トータル・マジック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** にすると、都市のゴミを即座に全消去します。\n\n" +

                    "**トータル・マジック** がONの間:\n" +
                    "- セミ・マジックは強制OFFになります。\n" +
                    "- セミ・マジックのスライダーは **適用されません**（値は後で使えるよう保存されます）。\n" +
                    "- ゲーム側の配車ロジックにより、少数のトラックが走ることがあります（たいてい空です）。"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "セミ・マジック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "ゴミ処理を直接調整します（バニラのゴミロジックは動いたまま）。\n\n" +
                    "- **セミ・マジック ON [ ✓ ]** にすると、トータル・マジックは自動でOFFになります。\n" +
                    "- スライダーはセミ・マジックがONのときだけ適用されます [ ✓ ]。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**1台が運べるゴミの量。**\n" +
                    "100% = 通常（ゲーム標準）。\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
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
                    "100% = バニラの容量。\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設のトラック数"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**施設が出せるトラック台数。**\n" +
                    "100% = バニラの台数。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "おすすめのセミ・マジック設定を適用:\n" +
                    "- トラック積載量: **200%**\n" +
                    "- 処理速度: **200%**\n" +
                    "- 保管容量: **160%**\n" +
                    "- 施設のトラック数: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "ゲーム標準" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "全スライダーを **100%**（バニラ値）に戻します。\n" +
                    "通常のゲーム挙動に戻します。"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "このModの表示名。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "現在のModバージョン。"
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "作者のMod一覧（**Paradox Mods**）を開きます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "CS2 Modding の **Discord** をブラウザで開きます。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * トータル・マジック ON = **[ ✓ ]**\n" +
                    "  * ゴミは即座に全消去\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理状態>\n" +
                    "  * セミ・マジック ON = **[ ✓ ]**\n" +
                    "  * スライダーは好きに調整。\n" +
                    "  * バニラのゴミロジック + 調整済みトラック/施設。\n" +
                    " <-------------------------------------->\n\n" +
                    "<通常のバニラ>\n" +
                    "  * セミ・マジック ON = **[ ✓ ]**\n" +
                    "  * **[ゲーム標準]** をクリック\n" +
                    "  * 全スライダー 100%（バニラ）\n"
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
