# Magic Garbage Truck [MGT] – Internal Notes

## Internal systems & behaviour

| Area / Feature                     | What it does                                                                 | Implementation (high level)                                      |
|------------------------------------|------------------------------------------------------------------------------|------------------------------------------------------------------|
| Total Magic toggle                 | When ON, removes all garbage city-wide every simulation frame.              | `MagicGarbageSystem` Burst job clears `GarbageProducer` data.    |
| Total Magic – requests & flags     | Cancels garbage collection requests and clears “piling up” flags.           | Resets `m_CollectionRequest`, `m_DispatchIndex`, and flags.      |
| Total Magic – world icons          | Removes garbage warning icons above buildings.                               | `IconCommandBuffer.Remove` per building in `MagicJob`.           |
| Total Magic – prefab visibility    | Prevents new garbage icons from spawning while magic is ON.                  | `GarbageNotificationRemoverSystem` disables `NotificationIconDisplayData` on the garbage icon prefab and calls `IconClusterSystem.RecalculateClusters()`. |
| Semi-Magic capacity slider         | Scales garbage truck **capacity** (100–500% of vanilla).                     | `GarbageTruckCapacitySystem` multiplies `m_GarbageCapacity`.     |
| Semi-Magic unload scaling          | Keeps unload time roughly constant as capacity increases.                     | Same system scales `m_UnloadRate` by the same factor.            |
| Semi-Magic update timing           | Only recalculates when the slider value actually changes.                    | `GarbageTruckCapacitySystem` runs once when `Setting.Apply()` enables it, then disables itself again. |
| Vanilla compatibility              | With Total Magic OFF and slider at 100%, behaviour matches the base game.    | Systems early-out when settings are at vanilla values.           |
| Options UI – Actions tab           | Main controls: **Total Magic** checkbox and **Garbage Truck Capacity** slider. | `Setting` + `LocaleEN` define the “Actions” tab and group labels. |
| Options UI – About tab             | Displays mod name, version, Paradox + Discord buttons, and usage notes.      | Implemented via `[SettingsUIMultilineText]` and button groups.   |
| Options UI – default values        | Magic Garbage = ON, slider = 100%                                            | `Setting.SetDefaults()` initializes startup defaults.            |
| Mod bootstrap                      | Registers settings, locales, and schedules systems in the GameSimulation phase. | `Mod.OnLoad` wires `MagicGarbageSystem`, `GarbageNotificationRemoverSystem`, and `GarbageTruckCapacitySystem`. |
| Settings persistence               | Player choices persist between sessions.                                    | Uses `AssetDatabase.global.LoadSettings()` for save/load.        |
| Localization                       | English and translated locale sources.                                       | Each `LocaleXX` implements `IDictionarySource`.                  |
| Logging                            | Minimal in release; debug builds show system load order and OnDispose.       | Conditional `#if DEBUG` blocks in `Mod.cs`.                      |
