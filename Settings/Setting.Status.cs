// <copyright file="Setting.Status.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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
