## Internal systems & behaviour

| Area / Feature                     | What it does                                                                                       | Implementation (high level) |
|------------------------------------|----------------------------------------------------------------------------------------------------|-----------------------------|
| Total Magic toggle                 | When ON, keeps the entire city garbage-free. Mutually exclusive with Semi-Magic.                  | `Setting.TotalMagic` / `Setting.SemiMagicEnabled` setters ensure only one mode can be ON; defaults start with Total Magic ON, Semi-Magic OFF. |
| Total Magic – cleanup pass         | Wipes garbage counters, requests, and warning flags on all garbage producers while enabled.       | `TotalMagicSystem` Burst `MagicJob` iterates `GarbageProducer` chunks and clears state **only when** `setting.TotalMagic` is true. |
| Total Magic – update timing        | Runs periodically instead of every tick; cleans the whole city in one Burst pass.                 | `TotalMagicSystem.GetUpdateInterval` returns `262144 / UpdatesPerDay` (default `UpdatesPerDay = 512` → 512 ticks), so the job runs ~512× per in-game day (~2.8 in-game minutes between sweeps). When Total Magic is OFF, `OnUpdate` returns early and no job is scheduled. |
| Total Magic – requests & flags     | Cancels collection requests and clears “garbage piling up” flags to prevent ongoing warnings.     | Job resets `m_Garbage`, `m_CollectionRequest`, `m_DispatchIndex`, and clears `GarbageProducerFlags.GarbagePilingUpWarning`. |
| Total Magic – world icons          | Removes garbage warning icons above buildings so the UI reflects the cleaned state.               | `IconCommandBuffer.Remove(building, m_GarbageParameters.m_GarbageNotificationPrefab)` per processed building. |
| Semi-Magic master toggle           | Enables “enhanced vanilla” mode using stronger trucks/facilities (instead of full magic).        | `Setting.SemiMagicEnabled` is exclusive with `TotalMagic`; turning one ON forces the other OFF. |
| Semi-Magic truck load slider       | Scales garbage truck **capacity** (100–500% of vanilla) and matching unload rate.                 | `GarbageTruckCapacitySystem` edits prefab `GarbageTruckData` (`m_GarbageCapacity`, `m_UnloadRate`). Uses cached base values to apply exact scaling (no rounding drift). |
| Semi-Magic facility tuning         | Scales facility **truck count**, **processing speed**, and **storage capacity** from sliders.     | `GarbageFacilityCapacitySystem` edits prefab `GarbageFacilityData` (`m_VehicleCapacity`, `m_ProcessingSpeed`, `m_GarbageCapacity`). Uses cached base values to apply exact scaling (no rounding drift). |
| Semi-Magic + Total Magic interaction | Switching to Total Magic immediately behaves like vanilla truck/facility stats, without losing saved Semi-Magic values. | Both capacity systems compute an *effective* target of **100%** whenever Total Magic is ON (or Semi-Magic is OFF), but they do not overwrite the saved slider values. |
| Semi-Magic update timing           | Only recalculates truck and facility stats when slider/toggle values actually change.              | Semi-Magic systems are woken by `Setting.Apply()`, run one pass, update cached “last targets”, then set `Enabled = false`. |
| Semi-Magic presets                 | “Game Defaults” restores pure vanilla; “Recommended” applies tuned values.                         | `Setting.SemiMagicDefaults` sets all sliders to 100%. `Setting.SemiMagicRecommended` applies: **200%** truck load, **200%** processing, **160%** storage, **140%** facility trucks. |
| Vanilla compatibility              | Player can always return to exact vanilla behaviour.                                               | Either: (A) Total Magic ON (effective 100% tuning + auto clean), or (B) Semi-Magic ON + “Game Defaults” (all multipliers = 100%). |
| Options UI – Actions tab           | Shows **Total Magic** toggle, **Semi-Magic** toggle, Semi-Magic sliders, and preset buttons.      | Defined in `Setting` via `[SettingsUISection]`, `[SettingsUISlider]`, `[SettingsUIButtonGroup]`, etc. |
| Options UI – slider visibility     | Hides all Semi-Magic sliders/buttons when Semi-Magic is disabled.                                  | `[SettingsUIHideByCondition(typeof(Setting), nameof(Setting.SemiMagicEnabled), true)]` on sliders/buttons. |
| Options UI – About tab             | Displays mod name + tag, version, Paradox Mods + Discord buttons, and usage notes.                | `Setting.AboutName` / `AboutVersion` plus locale entries; usage block via `[SettingsUIMultilineText]`. |
| Options UI – default values        | First launch: Total Magic ON, Semi-Magic OFF, all sliders at 100%.                                | `Setting.SetDefaults()` initializes backing fields and multipliers. |
| Mod bootstrap                      | Registers settings, locales, and hooks main systems into the GameSimulation phase.                | `Mod.OnLoad` adds locale sources, loads settings, registers Options UI, and schedules `TotalMagicSystem`, `GarbageTruckCapacitySystem`, `GarbageFacilityCapacitySystem`. |
| Settings persistence               | Player choices persist across sessions.                                                           | `AssetDatabase.global.LoadSettings("MagicGarbage", setting, new Setting(this));` |
| Localization                       | Uses English + translated locale sources; display name uses single source of truth.               | `LocaleEN` (and `LocaleXX`) implement `IDictionarySource` and build text from `Mod.ModName` / `Mod.ModTag`. |
| Logging                            | Minimal in release; debug builds can show load banner + optional sweep stats.                     | `Mod.Log` uses `SetShowsErrorsInUI` plus `#if DEBUG` info/debug messages. |

## Useful research

1. **Game.Prefabs.GarbagePrefab** → writes `GarbageParameterData`  
   - There’s a global parameter blob controlling request thresholds (`m_RequestGarbageLimit`, etc.). Potential lever for a future “even fewer trips” Total Magic branch.

2. **Game.Prefabs.GarbageTruck** (authoring `ComponentBase`)  
   - Authoring values (`m_GarbageCapacity`, `m_UnloadRate`) get written into ECS `GarbageTruckData` at initialize time.

3. **Game.Prefabs.GarbageTruckData**  
   - Runtime prefab component the sim reads. Scaling it changes what dispatch/selection sees (this is the main Semi-Magic “knob”).

4. **Game.Prefabs.GarbageTruckSelectData**  
   - Selection logic reads `GarbageTruckData` from prefab chunks to choose a suitable truck. Confirms scaling that component is the correct approach for Semi-Magic.

5. **Game.Simulation.GarbageCollectionRequest + GarbageCollectionRequestFlags**  
   - Request entity schema for building pickups; `GarbageProducer.m_DispatchIndex` suggests retries / repeated dispatch attempts.

6. **Game.Simulation.GarbageTransferRequest + GarbageTransferRequestFlags**  
   - Second request schema: facility-driven transfer/import/export can create trips even when producers are clean.

7. **Game.Simulation.GarbageTransferDispatchSystem**  
   - Transfer requests are actively dispatched via pathfinding and can create trips; updates facility request pointers (`m_GarbageDeliverRequest` / `m_GarbageReceiveRequest`).

8. **Game.Simulation.GarbageCollectorDispatchSystem**  
   - Building pickup dispatch is gated by `GarbageProducer.m_Garbage > RequestGarbageLimit` (from `GarbageParameterData`). If garbage spikes between cleanups, it can explain occasional “still moving” trucks.

9. **Game.Simulation.GarbagePathfindSetup**  
   - Pathfinding target setup pipeline. Helps the game decide “who should go where” once there are requests or dispatch buffers.  
   - `SetupGarbageCollectorsJob`: respects service districts + industrial waste flags; considers trucks already carrying queued requests (`ServiceDispatch`, `PathElement`, etc.).  
   - `SetupGarbageTransferJob`: picks facility targets for transfer/import/export behavior (ties directly to `GarbageTransferRequest`).  
   - `GarbageCollectorRequestsJob`: links collection requests to eligible services/trucks and feeds the target seeker.  
   - Bottom line: trucks can be “in motion” for reasons beyond “building has garbage right now”.

**Collector pipeline**: Building garbage crosses `RequestGarbageLimit` ⇒ `GarbageCollectionRequest` dispatches a truck.  
**Transfer pipeline**: Facilities create `GarbageTransferRequest` (deliver/receive/export/return) ⇒ trips can happen even if producers are clean.
