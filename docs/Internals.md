## Internal systems & behaviour

| Area / Feature | What it does | Where |
|---|---|---|
| Total Magic toggle | Auto-clean mode; exclusive with Trash Boss | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Total Magic cadence | Periodic sweep (not every frame). OFF = cheap early-return | `TotalMagicSystem.GetUpdateInterval`, `OnUpdate` gates |
| Total Magic sweep | Clears producer garbage + request + warning; removes icon | `TotalMagicSystem.MagicJob` + `IconCommandSystem` |
| Trash Boss master | “Enhanced vanilla” tuning; exclusive with Total Magic | `Setting` toggle setters |
| Truck tuning | Scales truck prefab capacity + unload | `GarbageTruckCapacitySystem` (prefab `GarbageTruckData`) |
| Facility tuning | Scales facility trucks + processing + storage | `GarbageFacilityCapacitySystem` (prefab `GarbageFacilityData`) |
| Tuning timing | Applies only on change; then sleeps | capacity systems: wake → apply → `Enabled=false` |
| Status panel | Pull-refresh snapshot while Options is open | `GarbageStatus`, `GarbageStatusSystem` |
| Status log button | Writes a more detailed one-shot report to mod log | `GarbageStatus.RefreshNow(writeToLog: true)` |
| Options UI layout | Actions + About | `Setting` + locales |
| Logging | Mod log only; Status logs on button press | `Mod.Log` |

## dnSpy research

Legend: **[NOW]** used directly by this mod today. **[REF]** useful reference / future work.

1. **Game.Prefabs.GarbagePrefab** → writes `GarbageParameterData` **[REF]**  
   - Global thresholds (`m_RequestGarbageLimit`, `m_CollectionGarbageLimit`, `m_WarningGarbageLimit`, `m_MaxGarbageAccumulation`).

2. **Game.Prefabs.GarbageTruck** (authoring `ComponentBase`) **[REF]**  
   - Authoring values flow into ECS `GarbageTruckData` at init.

3. **Game.Prefabs.GarbageTruckData** **[NOW]**  
   - Runtime prefab component the sim reads. Trash Boss scales this.

4. **Game.Prefabs.GarbageTruckSelectData** **[REF]**  
   - Truck selection logic reads `GarbageTruckData` from prefab chunks.

5. **Game.Simulation.GarbageCollectionRequest + Flags** **[NOW]**  
   - Building pickup request schema; shows how dispatch chains exist (`Dispatched`, handlers).

6. **Game.Simulation.GarbageTransferRequest + Flags** **[REF]**  
   - Facility transfer/import/export request schema; can create trips even when producers are clean.

7. **Game.Simulation.GarbageTransferDispatchSystem** **[REF]**  
   - Dispatch pipeline for transfer requests; updates facility request pointers.

8. **Game.Simulation.GarbageCollectorDispatchSystem** **[REF]**  
   - Building pickup dispatch/validation gated by `GarbageProducer.m_Garbage > RequestGarbageLimit`.

9. **Game.Simulation.GarbagePathfindSetup** **[REF]**  
   - Pathfinding setup for collectors + transfer. Explains why trucks can still move even when producers are clean.

10. **Game.Debug.GarbageDebugSystem** **[REF]**  
   - Debug gizmo renderer (wire cubes for accumulated/produced garbage). Useful visualization reference.

11. **Game.UI.InGame.GarbageInfoviewUISystem** **[REF]**  
   - Aggregates garbage totals efficiently when infoview is active. Good query patterns for future Status expansions.

12. **Game.Prefabs.Modes.GarbageFacilityMode** **[REF]**  
   - Mode system applies multipliers to runtime `GarbageFacilityData` (`m_GarbageCapacity`, `m_ProcessingSpeed`).

13. **Game.Prefabs.Modes.GarbageParametersMode** **[REF]**  
   - Mode system applies runtime `GarbageParameterData` values (`m_RequestGarbageLimit`, `m_CollectionGarbageLimit`, `m_WarningGarbageLimit`, `m_MaxGarbageAccumulation`, etc.).

14. **Game.Simulation.GarbageAccumulationSystem** **[REF]**  
   - Accumulates `GarbageProducer.m_Garbage` and clamps to `m_MaxGarbageAccumulation`.
   - Creates `GarbageCollectionRequest` when `m_Garbage > m_RequestGarbageLimit`.
   - Adds warning icon + flag when `m_Garbage > m_WarningGarbageLimit`.

15. **Game.Simulation.GarbageTruckAISystem** **[REF]**  
   - Truck pickup gate uses `m_CollectionGarbageLimit`.
   - This is why a truck can still collect from a building before that building is high enough to create a full request.

## Pipeline notes

- **Collector pipeline:** producer crosses request threshold ⇒ `GarbageCollectionRequest` ⇒ truck dispatched.
- **Pickup threshold:** truck AI can still collect from buildings above collection threshold, even if no active request exists yet.
- **Transfer pipeline:** facilities can create `GarbageTransferRequest` trips, so trucks may still move even when producers are already clean.

## Implementation notes

- Trash Boss scaling should is based on cached/base values to avoid cumulative drift.
- Status should read the live `GarbageParameterData` singleton rather than relying on decompiled defaults.
- Invalid garbage requests are cleaned up by vanilla when target/handler validation fails.
