## Internals.md systems & behaviour

| Area / Feature | What it does | Where |
|---|---|---|
| Total Magic toggle | Auto-clean mode. Turning it ON forces Trash Boss OFF. Both can also be OFF. | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Trash Boss toggle | “Enhanced vanilla” tuning. Turning it ON forces Total Magic OFF. Both can also be OFF. | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Total Magic cadence | Periodic sweep (not every frame). OFF = cheap early-return | `TotalMagicSystem.GetUpdateInterval`, `OnUpdate` gates |
| Total Magic sweep | Clears producer garbage + request + warning; removes icon | `TotalMagicSystem.MagicJob` + `IconCommandSystem` |
| Standard Trash Boss tuning | Scales garbage truck capacity and facility storage / processing / fleet | `GarbageTruckCapacitySystem`, `GarbageFacilityCapacitySystem` |
| Power User toggle | Enables advanced thresholds + garbage happiness tuning | `Setting.PowerUserOptions` |
| Power User sliders | Request threshold, pickup threshold, happiness baseline, happiness step | `Setting`, `GarbageThresholdSystem` |
| Power User button visibility | Power User buttons/sliders only show when Trash Boss ON + Power User ON | `ShowPowerUserThresholdSliders` |
| Standard preset buttons | Standard Trash Boss Recommended / Game Defaults only affect the standard Trash Boss sliders | `Setting.TrashBossRecommended`, `Setting.TrashBossDefaults` |
| Power User preset buttons | Power User Recommended / Game Defaults only affect advanced Power User values | `Setting.PowerUserRecommended`, `Setting.PowerUserDefaults` |
| Tuning timing | Applies only on change; then sleeps | capacity / threshold systems: wake → apply → `Enabled=false` |
| Status panel | Pull-refresh snapshot while Options is open | `GarbageStatus`, `GarbageStatusSystem` |
| Status log button | Writes a more detailed one-shot report to mod log | `GarbageStatus.RefreshNow(writeToLog: true)` |
| Options UI layout | Actions + About; Actions contains Auto Clean, Self Manage, Power User, Status | `Setting` + locales |
| Logging | Mod log only; Status logs on button press | `Mod.Log` |

## dnSpy research

Legend: **[NOW]** used directly by this mod today. **[REF]** useful reference / future work.

### Important Total Magic rule

Do **not** add a pre-dispatch garbage request suppression step for Total Magic.

A previous attempt deleted/cancelled pending `GarbageCollectionRequest` entities before vanilla garbage dispatch.  
That is not needed: Total Magic already clears producer garbage, and vanilla request validation cleans up stale requests afterward.

That approach caused severe `Player.log` spam:

- `UpdateFrame added to unsupported type`

### Rule

- Do not intercept, cancel, or destroy garbage request entities as a pre-dispatch optimization for Total Magic.
- Let vanilla request cleanup handle stale requests after Total Magic clears garbage.

---

1. **Game.Prefabs.GarbagePrefab** → writes `GarbageParameterData` **[REF]**  
   - Global thresholds (`m_RequestGarbageLimit`, `m_CollectionGarbageLimit`, `m_WarningGarbageLimit`, `m_MaxGarbageAccumulation`)
   - Garbage happiness values (`m_HappinessEffectBaseline`, `m_HappinessEffectStep`)

2. **Game.Prefabs.GarbageTruck** (authoring `ComponentBase`) **[REF]**  
   - Authoring values flow into ECS `GarbageTruckData` at init

3. **Game.Prefabs.GarbageTruckData** **[NOW]**  
   - Runtime prefab component the sim reads
   - Standard Trash Boss scales this

4. **Game.Prefabs.GarbageTruckSelectData** **[REF]**  
   - Garbage truck selection logic reads `GarbageTruckData` from prefab chunks

5. **Game.Prefabs.GarbageFacilityData** **[NOW]**  
   - Runtime prefab component for garbage facilities
   - Standard Trash Boss scales storage / processing / fleet

6. **Game.Prefabs.DeliveryTruckData** **[REF]**  
   - Runtime prefab component for delivery / transfer trucks
   - Relevant for dump-truck transfer behaviour

7. **Game.Prefabs.VehicleCapacitySystem** **[REF]**  
   - Builds delivery-truck selection data
   - Important for transfer-truck capacity investigation

8. **Game.Prefabs.DeliveryTruckSelectData** **[REF]**  
   - Used by facility transfer logic to choose transfer trucks and determine min/max transfer load

9. **Game.Simulation.GarbageCollectionRequest + Flags** **[NOW]**  
   - Building pickup request schema; shows how dispatch chains exist (`Dispatched`, handlers)
   - Includes industrial-waste collection flagging

10. **Game.Simulation.GarbageTransferRequest + Flags** **[REF]**  
    - Facility transfer/import/export request schema
    - Can create trips even when producers are already clean

11. **Game.Simulation.GarbageFacilityAISystem** **[REF]**  
    - Core garbage facility logic
    - Spawns `GarbageTruck` for collection-side work
    - Spawns `DeliveryTruck` for facility-transfer work
    - Sets facility priorities and transfer request amounts

12. **Game.Simulation.GarbageTransferDispatchSystem** **[REF]**  
    - Dispatch pipeline for transfer requests
    - Updates facility request pointers

13. **Game.Simulation.GarbageCollectorDispatchSystem** **[REF]**  
    - Building pickup dispatch/validation
    - Gated by `GarbageProducer.m_Garbage > RequestGarbageLimit`

14. **Game.Simulation.GarbagePathfindSetup** **[REF]**  
    - Pathfinding setup for collector + transfer flows
    - Useful for industrial-waste matching and transfer behaviour

15. **Game.Simulation.GarbageAccumulationSystem** **[REF]**  
    - Accumulates `GarbageProducer.m_Garbage`
    - Clamps to `m_MaxGarbageAccumulation`
    - Creates `GarbageCollectionRequest` when `m_Garbage > m_RequestGarbageLimit`
    - Adds warning icon + flag when `m_Garbage > m_WarningGarbageLimit`

16. **Game.Simulation.GarbageTruckAISystem** **[REF]**  
    - Truck pickup gate uses `m_CollectionGarbageLimit`
    - This is why a truck can still collect from a building before that building is high enough to create a full request

17. **Game.Simulation.CitizenHappinessSystem** **[REF]**  
    - Garbage happiness penalty uses:
      - `m_HappinessEffectBaseline`
      - `m_HappinessEffectStep`
    - Penalty starts after `baseline + step`
    - Penalty ramps by step and caps at `-10`

18. **Game.UI.InGame.GarbageVehicleSection** **[REF]**  
    - UI labels `GarbageTruck` as `IndustrialWasteTruck` when `GarbageTruckFlags.IndustrialWasteOnly` is set

19. **Game.UI.InGame.GarbageInfoviewUISystem** **[REF]**  
    - Aggregates garbage totals efficiently when infoview is active
    - Good query patterns for future Status expansions

20. **Game.Debug.GarbageDebugSystem** **[REF]**  
    - Debug gizmo renderer (wire cubes for accumulated/produced garbage)
    - Useful visualization reference

## Pipeline notes

### Collector pipeline

- Building garbage accumulates
- When garbage passes request threshold, the game can create a `GarbageCollectionRequest`
- `GarbageTruck` handles building pickup work

### Pickup threshold

- Truck AI can still collect from buildings above collection threshold, even if no active request exists yet

### Transfer pipeline

- Facilities can create `GarbageTransferRequest` trips
- `DeliveryTruck` handles inter-facility garbage transfers

### Industrial waste

- Industrial-waste collection is on the **`GarbageTruck`** side
- Inter-facility garbage transfer is on the **`DeliveryTruck`** side
- These are related garbage systems, but not the same live truck path

## Implementation notes

- Trash Boss scaling should be based on cached/base values to avoid cumulative drift
- Power User should update the live `GarbageParameterData` singleton, not guessed defaults
- Status should read the live `GarbageParameterData` singleton rather than relying on decompiled defaults
- Invalid garbage requests are cleaned up by vanilla when target/handler validation fails
- Status-only mode is valid: both Total Magic and Trash Boss can be OFF while Status reporting still works
