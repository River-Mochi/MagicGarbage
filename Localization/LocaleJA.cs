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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "アクション" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "詳細" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自動クリーン" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "手動管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "状態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使い方" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** にすると街全体を常にきれいに保ちます。\n\n" +
                    "**Total Magic** が ON の間:\n" +
                    "- Trash Boss は OFF に固定されます。\n" +
                    "- Trash Boss のスライダーは適用されません（値はあとで使うため保存されます）。\n" +
                    "- バニラの配車タイミングの都合で、一部のトラックはまだ動くことがあります。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "ごみシステムを直接管理します。バニラのごみロジックはそのまま動きます。\n\n" +
                    "- **Trash Boss が ON [ ✓ ]** のとき、Total Magic は OFF に固定されます。\n" +
                    "- スライダーは Trash Boss 有効時のみ適用されます。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるごみの量。**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "施設保管容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるごみの量。**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "施設処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設が流入ごみを処理する速さ。**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設フリート" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設が出せるトラックの台数。**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "建物しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "任意設定：建物がごみ回収を受けるために必要な**しきい値**を引き上げます。 \n" +
                    "これを上げるとごみ収集車の交通量を減らせることがありますが、上げすぎると回収回数が減ります。\n" +
                    "ほとんどの人はこれを調整する必要は<ありません>。このオプション追加前から Mod は普通に動いており、これは実験用のおまけです。\n"+
                    "--------------------------------\n" +
                    "- **配車要求しきい値 (R)** = <トラック配車要求> を出すのに必要な建物ごみ量。\n" +
                    "- **回収しきい値 (P)** = トラックがその建物から回収できる最小ごみ量。\n" +
                    "**1x** = バニラ (R 100、P 20)。注：**1,000** ごみユニットは通常 **1t** です。\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "スライダーを **20x** にすると、その建物の **R** はトラックが <配車要求> を受ける前に **2,000 (2t)** ユニット以上に達する必要があります。\n" +
                    "バニラでは、トラックが空でない場合、<dispatch> 建物への往復中にほかの建物でも停止します。20x では、ルート上の建物は **400** を超えるごみが必要です（20 x バニラ P = 20）。\n" +
                    "バランス調整のコツ：これを調整するときは、詳細ログレポートのボタンをこまめに確認してください。\n" +
                    "しきい値を高くすると、家がトラックを呼ぶまでごみを長く抱えるので、トラック容量も上げたほうがよい場合があります。"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "おすすめの Trash Boss 値を適用:\n" +
                    "- トラック積載量: **200%**\n" +
                    "- 配車しきい値: **5x**\n" +
                    "- 処理速度: **200%**\n" +
                    "- 保管容量: **150%**\n" +
                    "- 施設トラック数: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "ゲーム標準" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "すべての Trash Boss スライダーをバニラ値に戻します。\n" +
                    "- パーセント系スライダーは **100%** に戻ります。\n" +
                    "- 配車しきい値は **1x** に戻ります。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "この Mod の表示名。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の Mod バージョン。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods ページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "ブラウザで Discord 招待を開きます。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * ごみは自動で削除 - 完了。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理状態>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 好きなようにスライダー調整。\n" +
                    "  * ごみの仕組み自体は同じ。自己管理向けにトラック/施設が改善。\n" +
                    " <-------------------------------------->\n\n" +
                    "<通常のバニラゲーム>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * すべてのスライダーがバニラ値\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使い方" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ごみ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "現在の都市全体のごみ量と総処理量を表示します。\n" +
                    "月間生産量がかなり多いなら処理量を増やしてください。\n" +
                    "**Produced** と **Processed** は月あたりトンです。\n" +
                    "<更新時刻 = 最終更新。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収要求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 現在トラックや経路に割り当てられていない有効な回収要求。\n" +
                    "**Dispatched** = すでに割り当て済みの有効な回収要求。\n" +
                    "**Total** = 現在の**有効な**要求エンティティ数（ごみパイプライン内）。\n\n" +
                    "技術メモ：これは <要求しきい値超え> とは別です。ここでは建物ではなく <要求> を数えます。\n" +
                    "Pending の一部はあとで割り当てられます。バニラ再検証で対象が不要と判断されれば、あとで消えるものもあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**ごみあり** = 現在ごみを保持している建物。\n" +
                    "**Total** = 都市内のすべてのごみ発生建物。\n" +
                    "**要求しきい値超え** = 回収要求を作れるだけのごみを持つ**建物**の現在数。\n" +
                    "バニラの要求しきい値は内部ごみユニット **100** です。\n" +
                    "Trash Boss の **配車しきい値** は回収しきい値と要求しきい値を一緒に上げます。\n" +
                    "これにより <要求しきい値超え> 建物数と <配車済み> 総数が減り、ごみ収集車の交通量が下がります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "数えたごみ施設の概要。\n" +
                    "**Facilities** = 数えたごみ建物。\n" +
                    "**Trucks total** = それら施設が所有するごみトラック数。\n" +
                    "**Max workers** = 同じ施設群の合計最大労働者数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "トラック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 現在市内を走っているトラック。\n" +
                    "**Returning** = 施設へ戻るフラグ付きの走行中トラック。\n" +
                    "**Parked** = 施設に駐車中のトラック。\n" +
                    "**Total** = すべてのごみトラック数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細状態をログへ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "より詳細なごみレポートを **Logs/MagicGarbage.log** に送ります。\n" +
                    "短い凡例、バニラ基準値、現在の都市ごみ統計を多数含みます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "ゲームの Logs/.. フォルダを開きます。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "まだ都市が読み込まれていません。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 生成 | {1:N0} t 処理 | 更新 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 件保留 | {2:N0} 件配車済み | 合計 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} がごみあり | {2:N0} が要請しきい値超え" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 施設 | トラック合計 {1:N0} | 最大従業員 {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} 台走行中 ({3:N0} 台帰投中) | {2:N0} 台駐車中 | 合計 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "施設データはまだありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ごみ状況 ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "凡例:\n" +
                    "- 生成/処理 は月あたりのトン数です。\n" +
                    "- 下のしきい値はトンではなく、内部ごみユニットです。\n" +
                    "- プレイヤー向け表示では、ゲームは 1,000 ユニット = 1t に換算します。\n" +
                    "配車しきい値スライダー:\n" +
                    "  - 回収しきい値 = トラックが建物から回収できる最小ごみ量。\n" +
                    "  - 要請しきい値 = ゲームが回収要請を作成または維持する最小ごみ量。\n" +
                    "- 警告アイコン = 建物の上に警告アイコンが出るごみ量。\n" +
                    "- 上限 = 建物が蓄積できるごみの最大量。\n" +
                    "- 保留 = 現在トラックや経路に割り当てられていない有効な要請。\n" +
                    "- 一部の保留要請は後で割り当てられます。また、vanilla の再検証で対象にサービス不要と判断された場合、後で消えることもあります。\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "ゲームしきい値 (内部ごみユニット): 回収={1:N0}, 要請={0:N0}, 警告アイコン={2:N0}, 上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "しきい値: <GarbageParameterData を利用できません>" },
                { "MG.Status.Log.GarbageProcessing", "ごみ: {0:N0} t/月 | 処理: {1:N0} t/月" },
                { "MG.Status.Log.Requests", "回収要請: 保留={1:N0}, 配車済み={2:N0}, 合計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "保留中の最大対象ごみ: {0:N0} ({1:N1}t) 場所 {2}" },
                { "MG.Status.Log.Producers", "建物: 合計 {0:N0} | ごみあり {1:N0} | 要請しきい値超え {2:N0} | 警告レベル {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "建物ごみ (0 以外のみ): 平均={0:N0} ({1:N1}t) | 中央値={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t) 場所 {6}" },
                { "MG.Status.Log.NearWarning75", "警告付近の建物 (>= {1:N0} ユニット / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: 合計 {0:N0} | トラック合計 {1:N0} | 最大従業員 {2:N0}" },
                { "MG.Status.Log.Trucks", "ごみトラック: 走行中 {2:N0} ({3:N0} 帰投中) | 駐車中 {1:N0} | 無効 {4:N0} | 合計 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "施設概要" },
                { "MG.Status.Log.FacilityLine", "- 施設 {0}: 走行中={2:N0}, 駐車中={3:N0}, 合計={1:N0}, 最大従業員={4:N0}" },

            };
        }

        public void Unload()
        {
        }
    }
}
