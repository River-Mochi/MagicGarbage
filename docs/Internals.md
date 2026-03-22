## Internal systems & behaviour

| Area / Feature | What it does | Where |
|---|---|---|
| Total Magic toggle | Auto-clean mode; exclusive with Semi Magic | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Total Magic cadence | Periodic sweep (not every frame). OFF = cheap early-return | `TotalMagicSystem.GetUpdateInterval`, `OnUpdate` gates |
| Total Magic sweep | Clears producer garbage + request + warning; removes icon | `TotalMagicSystem.MagicJob` + `IconCommandSystem` |
| Semi Magic master | “Enhanced vanilla” tuning; exclusive with Total Magic | `Setting` toggle setters |
| Semi truck tuning | Scales truck prefab capacity + unload | `GarbageTruckCapacitySystem` (prefab `GarbageTruckData`) |
| Semi facility tuning | Scales facility trucks + processing + storage | `GarbageFacilityCapacitySystem` (prefab `GarbageFacilityData`) |
| Semi tuning timing | Applies only on change; then sleeps | capacity systems: wake → apply → `Enabled=false` |
| Status button | One-shot snapshot: producers + trucks + dispatched requests | `GarbageStatusSystem` (runs only when enabled) |
| Options UI layout | Actions + About | `Setting` + locales |
| Logging | Mod log only; Status logs once per press | `Mod.Log` |

## dnSpy research

Legend: **[NOW]** used directly by this mod today. **[REF]** useful reference / future work.

1. **Game.Prefabs.GarbagePrefab** → writes `GarbageParameterData` **[REF]**  
   - Global thresholds (`m_RequestGarbageLimit`, etc.). Potential lever for “even fewer trips” later.

2. **Game.Prefabs.GarbageTruck** (authoring `ComponentBase`) **[REF]**  
   - Authoring values flow into ECS `GarbageTruckData` at init.

3. **Game.Prefabs.GarbageTruckData** **[NOW]**  
   - Runtime prefab component the sim reads. Semi Magic scales this.

4. **Game.Prefabs.GarbageTruckSelectData** **[REF]**  
   - Truck selection logic reads `GarbageTruckData` from prefab chunks.

5. **Game.Simulation.GarbageCollectionRequest + Flags** **[NOW]**  
   - Building pickup request schema; shows how dispatch chains exist (`Dispatched`, handlers).

6. **Game.Simulation.GarbageTransferRequest + Flags** **[REF]**  
   - Facility transfer/import/export request schema (can create trips even when producers are clean).

7. **Game.Simulation.GarbageTransferDispatchSystem** **[REF]**  
   - Dispatch pipeline for transfer requests; updates facility request pointers.

8. **Game.Simulation.GarbageCollectorDispatchSystem** **[REF]**  
   - Building pickup dispatch gated by `GarbageProducer.m_Garbage > RequestGarbageLimit`.

9. **Game.Simulation.GarbagePathfindSetup** **[REF]**  
   - Pathfinding setup for collectors + transfer. Explains “moving trucks” even if producers are clean.

10. **Game.Debug.GarbageDebugSystem** **[REF]**  
   - Debug gizmo renderer (wire cubes for accumulated/produced garbage). Visualization reference.

11. **Game.UI.InGame.GarbageInfoviewUISystem** **[REF]**  
   - Aggregates garbage totals efficiently when infoview is active. Good query patterns for future Status expansions.

12. **Game.Prefabs.Modes.GarbageFacilityMode**  
   - Mode system applies multipliers to runtime `GarbageFacilityData` (`m_GarbageCapacity`, `m_ProcessingSpeed`) per-mode.

13. **Game.Prefabs.Modes.GarbageParametersMode**  
   - Mode system applies runtime `GarbageParameterData` values (`m_RequestGarbageLimit`, `m_CollectionGarbageLimit`, `m_WarningGarbageLimit`, `m_MaxGarbageAccumulation`, etc.).  
   - Confirms: **reading live singleton values in Status is the right way** (decompile defaults may not match runtime).

14. **GarbageAccumulationSystem** creates `GarbageCollectionRequest` when `GarbageProducer.m_Garbage > GarbageParameterData.m_RequestGarbageLimit`.
   - Requests are created via EndFrameBarrier ECB with archetype: ServiceRequest + GarbageCollectionRequest + RequestGroup(32).
   - Warnings/icons are added when m_Garbage > m_WarningGarbageLimit; garbage is clamped to m_MaxGarbageAccumulation.	

a collection request is only considered valid if the producer’s garbage is ABOVE `m_RequestGarbageLimit`.
Then, in Execute(...), when validation fails, the vanilla system does:
`m_CommandBuffer.DestroyEntity(unfilteredChunkIndex, entity);`
if TM clears garbage to 0, any pending request that gets re-checked will self-destruct the next time this dispatch system touches it.


GarbageFacilityMode shows vanilla applies multipliers to runtime 
GarbageFacilityData and restores from prefab defaults;
our slider multipliers should be computed from base values to avoid cumulative drift.

GarbageParametersMode can overwrite runtime GarbageParameterData (request/warning/max thresholds etc.), 
so Status should read the live singleton to see the real in-city values (DnSpy defaults may differ).

14. Game.Simulation.GarbageAccumulationSystem

Accumulates GarbageProducer.m_Garbage in 16 update frames/day (kUpdatesPerDay = 16) and clamps to GarbageParameterData.m_MaxGarbageAccumulation.
Creates a GarbageCollectionRequest (ECB) when m_Garbage > m_RequestGarbageLimit via RequestCollectionIfNeeded(...).
Adds warning icon + flag when m_Garbage > m_WarningGarbageLimit.
Updates building efficiency factor (Garbage penalty) based on garbage amount vs warning/max thresholds.
15. Game.Simulation.GarbageCollectorDispatchSystem

Dispatch/validation gate: request target must have GarbageProducer and m_Garbage > GarbageParameterData.m_RequestGarbageLimit (ValidateTarget).
Invalid requests are cleaned up by vanilla (DestroyEntity via ECB) when target/handler validation fails.
Runs frequently (GetUpdateInterval returns 16) and uses UpdateFrame slicing for request processing.

### Pipeline notes (why trucks can still move)

- **Collector pipeline:** producers cross threshold ⇒ `GarbageCollectionRequest` ⇒ truck dispatched.
- **Transfer pipeline:** facilities create `GarbageTransferRequest` (deliver/receive/export/return) ⇒ trips can happen even if producers are clean.
