// Locale/LocaleES.cs

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Acerca de" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Magia total" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Modo semi-mágico" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Información del mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Enlaces" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Basura mágica"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Activado [x]** elimina al instante toda la basura de la ciudad.\n" +
                    "- Los edificios de gestión de residuos ya no son necesarios, a menos que te guste cómo se ven.\n\n" +

                    "Usa **Magia total** o la opción **Semi-mágica** de abajo, pero no ambas a la vez.\n" +
                    "- No pasa nada grave si activas las dos, pero no obtendrás ningún efecto extra."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacidad de los camiones de basura"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Modo **semi-mágico** con camiones súper potentes.\n" +
                    "- Si solo quieres que la basura sea más fácil de gestionar sin eliminarla:\n" +
                    "- Basura mágica = **[OFF]**\n" +
                    "- Luego usa este deslizador **[100 >> 500]** para aumentar la capacidad de los camiones.\n\n" +

                    "**---------------------------------------**\n" +
                    " El deslizador ajusta la capacidad en relación con el valor del juego base.\n" +
                    "**100 % = 20 toneladas por camión** — valor por defecto\n" +
                    "**500 % = 100 toneladas por camión**\n\n" +
                    " Extra: la velocidad de descarga escala con la capacidad, así que los camiones no tardan más en vaciarse en la planta de residuos.\n\n" +
                    "**---------------------------------------**\n\n" +
                    "Si quieres volver al juego vanilla, pon Basura mágica en [OFF] y el deslizador en 100 % para una partida normal."
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
                    "Nombre mostrado de este mod."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)),
                    "Versión"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Versión actual del mod."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Página de Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Abrir la página de Magic Garbage Truck en Paradox Mods."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abrir el Discord de modding de CS2 en el navegador."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado recomendado por defecto>\n" +
                    "  * Basura mágica = **[ON]**\n" +
                    "  * Deslizador = 100 %\n" +
                    "  * Toda la basura se elimina al instante\n\n" +

                    " <-------------------------------------->\n\n" +

                    "<Modo de camiones súper (semi-mágico)>\n" +
                    "  * Basura mágica = **[OFF]**\n" +
                    "  * Ajusta el deslizador entre 100 y 500 % para más capacidad.\n" +
                    "  * Simulación vanilla con menos camiones pero más fuertes.\n\n" +

                    " <-------------------------------------->\n\n" +

                    "<Juego completamente vanilla>\n" +
                    "  * Basura mágica = **[OFF]**\n" +
                    "  * Deslizador = 100 % (capacidad vanilla)\n" +
                    "  * Jugabilidad exactamente estándar.\n"
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
