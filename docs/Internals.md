## Internals.md systems & behaviour

| Area / Feature | What it does | Where |
|---|---|---|
| Total Magic toggle | Auto-clean mode. Turning it ON forces Trash Boss OFF. Both can also be OFF. | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Trash Boss toggle | Self-manage / enhanced-vanilla tuning. Turning it ON forces Total Magic OFF. Both can also be OFF. | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Total Magic cadence | Periodic sweep, not every frame. OFF = cheap early-return / sleep. | `TotalMagicSystem` |
| Total Magic sweep | Clears producer garbage and lets vanilla clean up stale request state afterward. | `TotalMagicSystem` |
| Standard Trash Boss tuning | Scales garbage truck capacity and facility storage / processing / fleet. | `GarbageTruckCapacitySystem`, `GarbageFacilityCapacitySystem` |
| Power User toggle | Enables advanced tuning. | `Setting.PowerUserOptions` |
| Power User sliders | Request threshold, pickup threshold, happiness baseline, happiness step, garbage accumulation rate. | `Setting`, threshold/accumulation tuning systems |
| Standard preset buttons | Standard Trash Boss Recommended / Game Defaults only affect the standard Trash Boss sliders. | `Setting.TrashBossRecommended`, `Setting.TrashBossDefaults` |
| Power User preset buttons | Power User Recommended / Game Defaults only affect advanced Power User values. | `Setting.PowerUserRecommended`, `Setting.PowerUserDefaults` |
| Pickup clamp rule | Pickup cannot be higher than Dispatch Request. | `Setting`, `GarbageThresholdSystem` |
| Tuning timing | Applies only on change, then sleeps. | capacity / threshold systems: wake → apply → `Enabled = false` |
| Status panel | Pull-refresh snapshot while Options is open. | `GarbageStatus`, `GarbageStatusSystem` |
| Status rows | Garbage Service Rating, garbage/mo., requests, buildings, facilities, trucks. | locales + `GarbageStatus` |
| Status log button | Writes a more detailed one-shot report to the mod log. | `GarbageStatus.RefreshNow(writeToLog: true)` |
| Open Log button | Opens the game log folder. | `Setting.OpenLog` |
| Options UI layout | Actions + About; Actions contains Auto Clean, Self Manage, Power User, Status. | `Setting` + locales |
| Logging | Mod log only; Status logs on button press. | `Mod.Log` |

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

## Status notes

- Status is valid even when **Total Magic** and **Trash Boss** are both OFF
- UI status is pull-refreshed while Options is open
- Detailed status logging is one-shot on button press
- Status reads live game values rather than hard-coded guessed defaults

## Implementation notes

- Trash Boss scaling should be based on cached/base values to avoid cumulative drift
- Power User should update the live `GarbageParameterData` singleton, not guessed defaults
- Status should read the live `GarbageParameterData` singleton rather than relying on decompiled defaults
- Invalid garbage requests are cleaned up by vanilla when target/handler validation fails
- Status-only mode is valid: both Total Magic and Trash Boss can be OFF while Status reporting still works


## Game logic
- truck AI appends extra pickups from connected buildings along the path, and it tracks them through `ServiceDispatch` plus `m_RequestCount/m_EstimatedGarbage`.
- there is no “save room" for the original requester (OR) rule, truck can absolutely fill from side pickups before it reaches the original requester.
- dispatch request has one original target `GarbageCollectorDispatchSystem` works from a `GarbageCollectionRequest`, and that request has a single `m_Target` building.
That is the original requester house. The request is only valid while that target is still **above** the request threshold (`m_RequestGarbageLimit`).
- truck path gets decorated with extra pickups: Oonce the truck AI takes that request, `GarbageTruckAISystem` does more than just drive to the (OR).

important path:

    ```SelectNextDispatch(...)
    PreAddCollectionRequests(...)
    AddPathElement(...)
    AddCollectionRequests(...)
    ```

Those functions walk the path and the road owners / sidewalks along it, then mark **connected** buildings for collection if they are **eligible**.
Truck thinks: this request’s main target is OR house; while going there, also collect from eligible connected buildings on the traversed edges / sidewalks

- outbound / active request route: opportunistically collects along the path
- if it is not full and currently Returning, call `SelectNextDispatch(...)` and leave the return path for a new job before unloading
- it can fill before reaching the original requester because collect action is just:
take `min(remaining capacity, building garbage)`
The code tracks:

`m_Garbage` = actual truck load
`m_EstimatedGarbage` = predicted route pickup load
`EstimatedFull` flag when actual + estimated reaches capacity

- `m_RequestCount` tracks number of queued dispatch requests associated with the truck. One request path can still involve many eligible buildings collected along the way.
- one Request can still mean MANY side-building pickups.

`GarbageAccumulationSystem` -> `GarbageCollectorDispatchSystem` -> `GarbageTruckAISystem` -> `AddCollectionRequests` / `TryCollectGarbage` / `ReturnToDepot`
