// <copyright file="Setting.Status.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Settings/Setting.Status.cs
// Status-only members for Magic Garbage settings.

namespace MagicGarbage
{
    using CS2Shared.RiverMochi; // LogUtils
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
        public string StatusCriticalBuildings
        {
            get
            {
                GarbageStatus.RefreshIfNeeded();
                return GarbageStatus.GetUiCriticalBuildings();
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
                LogUtils.Info($"{Mod.ModTag} [DEBUG] GarbageStatusLog clicked");
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
