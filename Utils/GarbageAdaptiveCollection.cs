// <copyright file="GarbageAdaptiveCollection.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Utils/GarbageAdaptiveCollection.cs
// Optional bridge to target-aware garbage routing in supported game versions.
// Reflection keeps one Magic Garbage binary compatible across the 1.6.x line.

namespace MagicGarbage
{
    using System;
    using System.Reflection;
    using CS2Shared.RiverMochi;
    using Game.Prefabs;

    internal static class GarbageAdaptiveCollection
    {
        private const string FieldName = "m_AdaptiveCollectionMargin";

        private static readonly FieldInfo? s_MarginField = typeof(GarbageParameterData).GetField(
            FieldName,
            BindingFlags.Instance | BindingFlags.Public);

        public static bool IsSupported => s_MarginField?.FieldType == typeof(float);

        public static bool TryGet(in GarbageParameterData data, out float margin)
        {
            FieldInfo? field = s_MarginField;
            if (field == null || field.FieldType != typeof(float))
            {
                margin = 0f;
                return false;
            }

            object boxed = data;
            object? value = field.GetValue(boxed);
            if (value is float result)
            {
                margin = result;
                return true;
            }

            margin = 0f;
            return false;
        }

        public static bool TrySet(ref GarbageParameterData data, float margin)
        {
            FieldInfo? field = s_MarginField;
            if (field == null || field.FieldType != typeof(float))
            {
                return false;
            }

            try
            {
                object boxed = data;
                field.SetValue(boxed, margin);
                data = (GarbageParameterData)boxed;
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.Warn($"{Mod.ModTag} Could not update {FieldName}: {ex.GetType().Name}: {ex.Message}");
                return false;
            }
        }
    }
}
