// Locale/LocaleTR.cs

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleTR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "İşlemler" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Hakkında" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Tam Sihir" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Yarı-Sihir" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod bilgisi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Bağlantılar" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "KULLANIM NOTLARI" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Sihirli Çöp"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Etkin [X]** şehirdeki tüm çöpleri anında temizler.\n" +
                    "- Çöp binaları artık gerekli değildir, görünümlerini sevmiyorsanız.\n\n" +

                    "Ya bu **Tam Sihir** seçeneğini ya da aşağıdaki **Yarı-Sihir** seçeneğini kullanın — ikisini birden değil.\n" +
                    "- Zarar vermez ama ekstra bir şey de olmaz."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Çöp Kamyonu Kapasitesi"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Yarı-Sihir** süper kamyon modu.\n" +
                    "- Eğer çöpleri tamamen ortadan kaldırmak yerine sadece kolaylaştırmak istiyorsanız:\n" +
                    "- Sihirli Çöp = **[KAPALI]**\n" +
                    "- Ardından bu kaydırıcıyı **[100 >> 500]** kullanarak kamyon taşıma kapasitesini artırın.\n\n" +

                    "**---------------------------------------**\n" +
                    " Kaydırıcı, kapasiteyi oyunun varsayılan değerine göre ayarlar.\n" +
                    "**%100 = Kamyon başına 20 ton** — varsayılan değer\n" +
                    "**%500 = Kamyon başına 100 ton**\n\n" +
                    " Ekstra: Boşaltma hızı kapasite ile ölçeklenir, böylece kamyonlar tesiste çok beklemez.\n\n" +
                    "**---------------------------------------**\n\n" +
                    "Tamamen vanilla oyuna dönmek istiyorsanız, Sihirli Çöp [KAPALI] ve kaydırıcı %100 yapın."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),
                    "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Bu modun görünen adı."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)),
                    "Sürüm"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Mevcut mod sürümü."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Paradox Mods Sayfası"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Magic Garbage Truck'ın Paradox Mods sayfasını açar."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "CS2 modlama Discord'unu tarayıcıda açar."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Önerilen varsayılan durum>\n" +
                    "  * Tam Sihirli Çöp = **[AÇIK]**\n" +
                    "  * Kaydırıcı = %100\n" +
                    "  * Tüm çöpler anında temizlenir\n\n" +

                    " <-------------------------------------->\n\n" +

                    "<Yarı-Sihir süper kamyon durumu>\n" +
                    "  * Sihirli Çöp = **[KAPALI]**\n" +
                    "  * Kaydırıcıyı 100-500 arasında ayarlayarak ekstra kapasite elde edin.\n" +
                    "  * Vanilla çöp simülasyonu, daha az ama daha güçlü kamyonlarla.\n\n" +

                    " <-------------------------------------->\n\n" +

                    "<Tamamen vanilla oyun>\n" +
                    "  * Sihirli Çöp = **[KAPALI]**\n" +
                    "  * Kaydırıcı = %100 (vanilla kapasite)\n" +
                    "  * Tam standart oyun davranışı.\n"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)),
                    string.Empty
                },
            };
        }

        public void Unload()
        {
        }
    }
}
