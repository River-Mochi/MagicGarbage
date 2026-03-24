// File: Utils/LogUtil.cs
// Shared version 0.3.1
// Purpose: Logging patterns not provided by CO API:
// - WarnOnce: prevents repeated WARN spam in hot paths
// - TryLog: lazy message construction inside try/catch

namespace CS2HonuShared
{
    using Colossal.Logging;
    using System;
    using System.Collections.Generic;

    public static class LogUtil
    {
        private static readonly object s_WarnOnceLock = new object();

        // Single set is fine because each mod is a separate assembly.
        // Prefix keys with log.name to avoid accidental collisions.
        private static readonly HashSet<string> s_WarnOnceKeys =
            new HashSet<string>(StringComparer.Ordinal);

        // Safety valve: don’t let a bad key strategy grow unbounded.
        private const int MaxWarnOnceKeys = 2048;

        public static bool WarnOnce(ILog log, string key, Func<string> messageFactory, Exception? exception = null)
        {
            if (log == null || string.IsNullOrEmpty(key) || messageFactory == null)
            {
                return false;
            }

            // Avoid even locking if WARN is filtered out.
            if (!log.isLevelEnabled(Level.Warn))
            {
                return false;
            }

            string fullKey = log.name + "|" + key;

            lock (s_WarnOnceLock)
            {
                if (s_WarnOnceKeys.Count > MaxWarnOnceKeys)
                {
                    s_WarnOnceKeys.Clear();
                }

                if (!s_WarnOnceKeys.Add(fullKey))
                {
                    return false;
                }
            }

            TryLog(log, Level.Warn, messageFactory, exception);
            return true;
        }

        public static void TryLog(ILog log, Level level, Func<string> messageFactory, Exception? exception = null)
        {
            if (log == null || messageFactory == null)
            {
                return;
            }

            // Keep heavy work cold.
            if (!log.isLevelEnabled(level))
            {
                return;
            }

            string message;
            try
            {
                message = messageFactory() ?? string.Empty;
            }
            catch (Exception ex)
            {
                // Best effort: report that the message factory itself threw.
                try
                {
                    if (log.isLevelEnabled(Level.Error))
                    {
                        log.Log(Level.Error, "Log message factory threw: " + ex.GetType().Name + ": " + ex.Message, ex);
                    }
                }
                catch
                {
                }
                return;
            }

            try
            {
                // CO ILog expects an Exception argument; allow "no exception" without nullable warnings.
                log.Log(level, message, exception ?? null!);
            }
            catch
            {
                // Logging must never throw back into gameplay/mod loading.
            }
        }
    }
}
