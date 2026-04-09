// File: Settings/Setting.Status.cs
// Status-only members for Magic Garbage settings.

namespace MagicGarbage
{
    using Game.Settings;

    public sealed partial class Setting
    {
        // ------------------------------------------------------
        // STATUS (auto-refresh while Options is open)
        // ------------------------------------------------------

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusGarbageServiceRating
        {
            get
            {
                // Refresh on read so the Options panel stays lightweight outside the menu.
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiGarbageServiceRating();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusGarbageProcessing
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiGarbageProcessing();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusRequests
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiRequests();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusProducers
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiProducers();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusFacilities
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiFacilities();
            }
        }

        [SettingsUISection(ActionsTab, StatusGrp)]
        public string StatusTrucks
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiTrucks();
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(StatusButtonsRow)]
        [SettingsUISection(ActionsTab, StatusGrp)]
        public bool GarbageStatusLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

#if DEBUG
                Mod.Log.Info($"{Mod.ModTag} [DEBUG] GarbageStatusLog clicked");
#endif
                GarbageStatus.RefreshNow(writeToLog: true);
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup(StatusButtonsRow)]
        [SettingsUISection(ActionsTab, StatusGrp)]
        public bool OpenLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

                OpenLogFolder();
            }
        }
    }
}
