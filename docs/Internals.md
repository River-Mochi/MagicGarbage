## Internal systems & behaviour

| Area / Feature                     | What it does                                                                                     | Implementation (high level)                                                                             |
|------------------------------------|--------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------|
| Total Magic toggle                 | When ON, keeps the entire city garbage-free. Mutually exclusive with Semi-Magic.                | `Setting.TotalMagic` / `Setting.SemiMagicEnabled` setters ensure they can’t both be ON at once; defaults start with Total Magic ON, Semi-Magic OFF. |
| Total Magic – cleanup pass         | Wipes garbage counters, requests, and warning flags on all garbage producers while enabled.     | `MagicGarbageSystem` Burst `MagicJob` iterates `GarbageProducer` chunks and clears state each run **only when** `setting.TotalMagic` is true. |
| Total Magic – update timing        | Runs periodically instead of every tick; cleans the whole city in one Burst pass.               | `MagicGarbageSystem.GetUpdateInterval` returns `262144 / UpdatesPerDay` (default `UpdatesPerDay = 512` → 512 ticks), so the job runs ~512× per in-game day (~2.8 in-game minutes between sweeps). When Total Magic is OFF, `OnUpdate` returns early and no job is scheduled. |
| Total Magic – requests & flags     | Cancels collection requests and clears “garbage piling up” flags to prevent new issues.          | Job resets `m_Garbage`, `m_CollectionRequest`, `m_DispatchIndex`, and clears `GarbageProducerFlags.GarbagePilingUpWarning`. |
| Total Magic – world icons          | Removes garbage warning icons above buildings so the UI reflects the cleaned state.              | `IconCommandBuffer.Remove(building, m_GarbageParameters.m_GarbageNotificationPrefab)` for each processed building. |
| Semi-Magic master toggle           | Enables “enhanced vanilla” mode using stronger trucks/facilities instead of full magic.          | `Setting.SemiMagicEnabled` is exclusive with `TotalMagic`; turning one ON forces the other OFF.        |
| Semi-Magic truck load slider       | Scales garbage truck **capacity** (100–500% of vanilla) and matching unload rate.                | `GarbageTruckCapacitySystem` uses `SystemAPI.Query<RefRW<GarbageTruckData>>()` to scale capacity + unload rate. |
| Semi-Magic facility tuning         | Scales facility **truck count**, **processing speed**, and **storage capacity** from sliders.    | `GarbageFacilityCapacitySystem` scales `m_VehicleCapacity`, `m_ProcessingSpeed`, and `m_GarbageCapacity`. |
| Semi-Magic update timing           | Only recalculates truck and facility stats when slider/toggle values actually change.            | Both Semi-Magic systems are enabled by `Setting.Apply()`, run one pass, update cached multipliers, then set `Enabled = false`. |
| Semi-Magic presets                 | “Game Defaults” restores pure vanilla; “Recommended” applies tuned values (200/150/200/150).     | `Setting.SemiMagicDefaults` and `Setting.SemiMagicRecommended` set slider fields and call `Apply()`.   |
| Vanilla compatibility              | Player can always return to exact vanilla behaviour.                                             | Total Magic OFF + Semi-Magic ON + “Game Defaults” → all multipliers = 100%, Semi-Magic systems early-out. |
| Options UI – Actions tab           | Shows **Total Magic** toggle, **Semi-Magic** toggle, all Semi-Magic sliders, and preset buttons. | Defined in `Setting` via `[SettingsUISection]`, `[SettingsUISlider]`, `[SettingsUIButtonGroup]`, etc.  |
| Options UI – slider visibility     | Hides all Semi-Magic sliders/buttons when Semi-Magic is disabled.                                | `[SettingsUIHideByCondition(typeof(Setting), nameof(Setting.SemiMagicEnabled), true)]` on sliders/buttons. |
| Options UI – About tab             | Displays mod name + tag, version, Paradox Mods + Discord buttons, and usage notes.              | `Setting.AboutName` / `AboutVersion` plus locale entries; usage block via `[SettingsUIMultilineText]`. |
| Options UI – default values        | First launch: Total Magic ON, Semi-Magic OFF, all sliders at 100%.                              | `Setting.SetDefaults()` initializes backing fields and multipliers.                                    |
| Mod bootstrap                      | Registers settings, locales, and hooks main systems into the GameSimulation phase.               | `Mod.OnLoad` calls `RegisterInOptionsUI()`, adds locales, and schedules `MagicGarbageSystem`, `GarbageTruckCapacitySystem`, and `GarbageFacilityCapacitySystem`. |
| Settings persistence               | Player choices persist across sessions.                                                          | `AssetDatabase.global.LoadSettings("MagicGarbage", setting, new Setting(this));`.                      |
| Localization                       | Uses English + translated locale sources; display name uses single source of truth.              | `LocaleEN` (and `LocaleXX`) implement `IDictionarySource` and build text from `Mod.ModName` / `Mod.ModTag`. |
| Logging                            | Minimal in release; debug builds can show load banner + optional sweep stats.                    | `Mod.Log` logger configured with `SetShowsErrorsInUI` and `#if DEBUG` info/debug messages.             |



## Useful research

1. Game.Prefabs.GarbagePrefab → writes GarbageParameterData

    - Tells us: there’s a global parameter blob controlling request thresholds (m_RequestGarbageLimit, etc.). Potential lever for Total Magic later.

2. Game.Prefabs.GarbageTruck (authoring ComponentBase)

    - Tells us: authoring values (m_GarbageCapacity, m_UnloadRate) get written into ECS GarbageTruckData at initialize time.

3. Game.Prefabs.GarbageTruckData

    - Tells us: this is the runtime prefab component the sim uses and it’s serializable. When it is scaled, it changes what dispatch/selection sees.

4. Game.Prefabs.GarbageTruckSelectData

    - Tells us: the selection logic reads GarbageTruckData from prefab chunks to choose a suitable truck. Confirms scaling that component is the “right” knob for Semi-Magic.

5. Game.Simulation.GarbageCollectionRequest + GarbageCollectionRequestFlags

    - Tells us: the request entity schema for building pickups and that there’s a retry mechanism via m_DispatchIndex.

6. Game.Simulation.GarbageTransferRequest + GarbageTransferRequestFlags

    - Tells us: a second request schema that could explain facility-driven trips even without building garbage.

7. Game.Simulation.GarbageTransferDispatchSystem

    - Tells us: transfer requests are actively dispatched via pathfinding and can create trips, and it updates facility request pointers (m_GarbageDeliverRequest / m_GarbageReceiveRequest).

8. Game.Simulation.GarbageCollectorDispatchSystem

    - Tells us: building pickup dispatch is gated by GarbageProducer.m_Garbage > RequestGarbageLimit (from GarbageParameterData). Could be why a few trucks still run on Total-magic if garbage occasionally spikes between cleanups.

9. Game.Simulation.GarbagePathfindSetup
    - Tells us: pathfinding target setup pipeline. It helps the game decide “who should go where” once there are requests or dispatch buffers.
    - SetupGarbageCollectorsJob: helps facilities/trucks choose targets, respects service districts + industrial waste flags, 
      and considers trucks already carrying request queues (ServiceDispatch, PathElement, etc.).
    - SetupGarbageTransferJob: picks facility targets for transfer/import/export behavior (ties directly to GarbageTransferRequest stuff).
    - GarbageCollectorRequestsJob: links collection requests to eligible services/trucks and feeds the target seeker.
    - trucks can be “in motion” for reasons beyond “building has garbage right now”
 
 **Collector pipeline**: Building garbage crosses RequestGarbageLimit ⇒ GarbageCollectionRequest dispatches a truck.
 **Transfer pipeline**: Facilities create GarbageTransferRequest for deliver/receive/export/return behavior ⇒ trips happen even if producers are clean.