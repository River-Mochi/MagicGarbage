// File: Locale/LocaleJA.cs
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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "情報" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自動クリーン" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "手動管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "ステータス" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使い方メモ" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** にすると街全体をきれいに保ちます。\n\n" +
                    "**Total Magic** が ON の間:\n" +
                    "- Trash Boss は強制的に OFF になります。\n" +
                    "- Trash Boss のスライダーは適用されません（値は保存されたままです）。\n"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "バニラのごみ処理ロジックを残したまま、ごみシステムを直接調整します。\n\n" +
                    "- **Trash Boss が ON [ ✓ ]** のとき、Total Magic は強制的に OFF になります。\n" +
                    "- スライダーは Trash Boss 有効時だけ適用されます。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるごみ量です。**\n" +
                    "100% = ゲーム標準値。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設が流入ごみを処理する速さです。**\n" +
                    "100% = バニラ速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "施設の保管容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるごみ量です。**\n" +
                    "100% = バニラ容量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設フリート" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設が出せるトラック数です。**\n" +
                    "100% = バニラ台数。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "おすすめの Trash Boss 値を適用します:\n" +
                    "- トラック積載量: **200%**\n" +
                    "- 処理速度: **200%**\n" +
                    "- 保管容量: **160%**\n" +
                    "- 施設トラック数: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "ゲーム標準" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "すべてのスライダーを **100%** に戻します（バニラ値）。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "このModの表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在のModバージョンです。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods のページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "ブラウザで Discord 招待を開きます。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * ごみをほぼ即時に除去\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理状態>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 好きなようにスライダー調整\n" +
                    "  * バニラのごみ処理を残しつつ、トラック/施設を強化\n" +
                    " <-------------------------------------->\n\n" +
                    "<普通のバニラ状態>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * **[ゲーム標準]** をクリック\n" +
                    "  * すべてのスライダーが 100%（バニラ）\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ごみ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "街全体の現在のごみ量と、合計処理量を表示します。\n" +
                    "月あたりの Produced が大きく上回るなら、処理能力を上げてください。\n" +
                    "**Produced** と **Processed** は月あたりトン数です。\n" +
                    "更新時刻 = 最後に更新した時刻。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収リクエスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = まだトラックや経路が割り当てられていない有効な回収リクエスト。\n" +
                    "**Dispatched** = すでに割り当て済みの有効な回収リクエスト。\n" +
                    "**Total** = 現在有効なごみ回収リクエスト総数。\n" +
                    "古いリクエストは後でゲーム側の再検証で消えるため、この数は一時的に **Above request threshold** より多くなる場合があります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 現在ごみを持っている建物。\n" +
                    "**Total** = 街の全ごみ発生建物。\n" +
                    "**Above request threshold** = 回収リクエスト作成に必要な量を超えている建物。\n" +
                    "バニラでは通常 <100> ごみユニット超です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "カウント対象のごみ施設の概要です。\n" +
                    "**Facilities** = カウントされたごみ施設数。\n" +
                    "**Trucks total** = その施設が所有するごみトラック総数。\n" +
                    "**Max workers** = 同じ施設群の総最大雇用数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "トラック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 現在街で稼働中のトラック。\n" +
                    "**Returning** = Moving のうち施設へ戻っているトラック。\n" +
                    "**Parked** = 施設に駐車中のトラック。\n" +
                    "**Total** = ごみトラック総数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細ステータスをログへ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "**Logs/MagicGarbage.log** に詳細なごみレポートを書き込みます。\n" +
                    "短い凡例、現在のしきい値、無効化トラック、施設ごとの最大作業員数を含みます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Logs/ フォルダを開きます。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "まだ都市が読み込まれていません。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 生成 | {1:N0} t 処理 | 更新 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 保留中 | {2:N0} 割当済み | 合計 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} がごみあり | {2:N0} がリクエストしきい値超え" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 施設 | トラック合計 {1:N0} | 最大作業員 {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} 稼働中 ({3:N0} 帰還中) | {2:N0} 駐車中 | 合計 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "施設データはまだありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ごみステータス ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "凡例:\n" +
                    "- Produced/Processed は月あたりトン数です。\n" +
                    "- 下のしきい値はトンではなく内部ごみユニットです。\n" +
                    "- 回収しきい値 = トラックが建物から回収を始める最低ごみ量。\n" +
                    "- リクエストしきい値 = ゲームが回収リクエストを作成/維持する最低ごみ量。\n" +
                    "- 警告しきい値 = 建物の上に警告アイコンが出る可能性があるごみ量。\n" +
                    "- 上限 = 建物が蓄積できる最大ごみ量。\n" +
                    "- 帰還中 = 稼働中トラックの一部です。\n" +
                    "- 有効リクエスト数は、古いリクエストが後でバニラ再検証で消えるため、一時的にリクエストしきい値超え建物数より多くなる場合があります。\n" +
                    "- 下の作業員数は現在、各施設の **最大作業員数** を表示しています。"
                },
                { "MG.Status.Log.Thresholds",
                    "しきい値 (内部ごみユニット): 回収={1:N0}, リクエスト={0:N0}, 警告={2:N0}, 上限={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "しきい値: <GarbageParameterData 利用不可>" },
                { "MG.Status.Log.GarbageProcessing", "ごみ: {0:N0} t/月 | 処理: {1:N0} t/月" },
                { "MG.Status.Log.Requests", "回収リクエスト: 保留中={1:N0}, 割当済み={2:N0}, 合計={0:N0}" },
                { "MG.Status.Log.Producers", "建物: 合計={0:N0} | ごみあり={1:N0} | リクエストしきい値超え={2:N0} | 警告レベル={3:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: 合計={0:N0} | トラック合計={1:N0} | 最大作業員={2:N0}" },
                { "MG.Status.Log.Trucks", "ごみトラック: 稼働中={2:N0} ({3:N0} 帰還中) | 駐車中={1:N0} | 無効={4:N0} | 合計={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "施設サマリー" },
                { "MG.Status.Log.FacilityLine", "- 施設 {0}: 稼働中={2:N0}, 駐車中={3:N0}, 合計={1:N0}, 最大作業員={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
