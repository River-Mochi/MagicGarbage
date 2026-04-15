# Internals.md

Developer reference for **Magic Garbage**.  
Keep this short, factual, and easy to scan.

---

## Quick mode summary

| Mode | What it does | Main code |
|---|---|---|
| **Total Magic ON** | Auto-clean garbage. Vanilla systems still exist, but garbage becomes mostly cosmetic. | `TotalMagicSystem` |
| **Trash Boss ON** | Keeps vanilla garbage gameplay running and applies standard tuning. | `GarbageTruckCapacitySystem`, `GarbageFacilityCapacitySystem` |
| **Priority System ON** | Lightweight Trash Boss assist. When any building reaches **7t** garbage, temporarily sets **Pickup = Dispatch Request**. | `GarbagePriorityAssistSystem` |
| **Power User ON** | Advanced threshold / happiness / accumulation tuning. | `GarbageThresholdSystem`, `GarbageAccumulationRateSystem` |
| **Both main toggles OFF** | Pure vanilla behavior, but **Status** still works. | `GarbageStatus`, `GarbageStatusSystem` |

---

## Current defaults

| Setting | Default |
|---|---|
| Total Magic | **ON** |
| Trash Boss | **OFF** |
| Priority Assist | **OFF** |
| Power User | **OFF** |

### Standard recommended preset
- Truck load: **250%**
- Facility storage: **150%**
- Facility processing: **250%**
- Facility fleet: **100%**

### Power User recommended preset
- Dispatch Request Threshold: **500**
- Pickup Threshold: **300**
- Garbage Happiness Baseline: **550**
- Garbage Happiness Step: **150**
- Garbage Accumulation Rate: **100%**

---

## Main systems and purpose

| Area / Feature | What it does | Where |
|---|---|---|
| Total Magic toggle | Auto-clean mode. Turning it ON forces Trash Boss OFF. Both can also be OFF. | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Trash Boss toggle | Self-manage / enhanced-vanilla tuning. Turning it ON forces Total Magic OFF. Both can also be OFF. | `Setting.TotalMagic`, `Setting.TrashBossEnabled` |
| Total Magic cadence | Periodic sweep, not every frame. OFF = cheap sleep. | `TotalMagicSystem` |
| Total Magic sweep | Clears producer garbage. Vanilla cleanup handles stale request state afterward. | `TotalMagicSystem` |
| Standard Trash Boss tuning | Scales garbage truck capacity and facility storage / processing / fleet. | `GarbageTruckCapacitySystem`, `GarbageFacilityCapacitySystem` |
| Priority System | Watches for critical buildings at **7t+** and temporarily lifts Pickup to the live Dispatch Request threshold. | `GarbagePriorityAssistSystem` |
| Power User toggle | Enables advanced tuning. | `Setting.PowerUserOptions` |
| Power User sliders | Dispatch threshold, pickup threshold, happiness baseline, happiness step, accumulation rate. | `Setting`, tuning systems |
| Pickup clamp rule | Pickup cannot be higher than Dispatch Request. | `Setting`, `GarbageThresholdSystem` |
| Standard preset buttons | Standard Trash Boss Recommended / Game Defaults affect only standard Trash Boss sliders. | `Setting.TrashBossRecommended`, `Setting.TrashBossDefaults` |
| Power User preset buttons | Power User Recommended / Game Defaults affect only Power User values. | `Setting.PowerUserRecommended`, `Setting.PowerUserDefaults` |
| Tuning timing | Slider systems wake on change, apply, then sleep. | capacity / threshold / accumulation systems |
| Status panel | Pull-refresh snapshot while Options is open. | `GarbageStatus`, `GarbageStatusSystem` |
| Status log button | Writes a one-shot detailed report to the mod log. | `GarbageStatus.RefreshNow(writeToLog: true)` |
| Open Log button | Opens the game log folder. | `Setting.OpenLog` |
| Transfer probe | Logs local + outside garbage transfer request state for facilities. Probe only, no tuning yet. | `GarbageTransferProbe.cs`, `GarbageStatus.cs` |
| Logging | Mod log only. No Player.log logging for mod status. | `Mod.Log` |

---

## Important implementation rules

### 1. Do not pre-delete garbage requests for Total Magic
A previous idea tried to suppress / cancel pending `GarbageCollectionRequest` entities before vanilla dispatch.  
Do **not** do that.

**Rule**
- Let Total Magic clear garbage.
- Let vanilla request validation clean up stale requests afterward.

### 2. Status must stay lightweight
- No constant in-city status panel work
- UI refresh is pull-based while Options is open
- Detailed report is one-shot on button press

### 3. Use live game values
- Read the live `GarbageParameterData` singleton for thresholds
- Do not rely on guessed or stale defaults in docs or code

### 4. Standard first, Power User second
For most players:
- standard Trash Boss + Priority System should be enough
- Power User is for advanced tuning / experiments

---

## Current status/log coverage

### Options UI rows
- Garbage Service Rating
- Produced / Processed
- Requests
- Buildings
- Critical Buildings
- Facilities
- Trucks

### Detailed log sections
- mode + settings
- live thresholds
- garbage service rating
- requests
- priority assist
- building garbage stats
- critical buildings over 7t
- facility summary
- local garbage transfer probe
- outside connection garbage transfer probe
- trucks

---

## Game logic notes

### Collector pipeline
`GarbageAccumulationSystem` -> `GarbageCollectorDispatchSystem` -> `GarbageTruckAISystem`

- Building garbage accumulates
- When garbage passes **Dispatch Request Threshold**, the game can create a `GarbageCollectionRequest`
- Truck AI can still collect from other eligible buildings along the path

### Important truck behavior
- A dispatch request has **one original target**
- Truck AI can append **extra pickups** from connected buildings along the route
- There is **no “save room for original requester” rule**
- A truck can fill before reaching the original requester
- One request can still mean **many** side-building pickups

### Threshold meanings
- **Dispatch Request Threshold**  
  Building garbage needed to create / keep a request
- **Pickup Threshold**  
  Building garbage needed before a truck may collect from it
- **Pickup < Dispatch Request** means trucks may collect from buildings that do not currently have their own request

### Priority Assist behavior
- Runs every **128** simulation frames
- Scans garbage-producing buildings
- If any building is **>= 7000 garbage (7t)**:
  - temporarily sets **Pickup = current Dispatch Request**
- Goal:
  - reduce side pickups
  - help badly overloaded buildings get reached sooner
- This is a **nudge**, not a hard route override

### Facility transfer behavior
- Inter-facility garbage transfer is separate from curbside garbage pickup
- Uses **`DeliveryTruck`**, not normal `GarbageTruck`
- Local facilities and outside connections can both participate
- Current probe exists to understand transfer behavior before adding any slider

---

## dnSpy / decompiled game reference map

Legend:
- **[NOW]** = directly relevant to current mod behavior
- **[REF]** = research / future-use reference

| Status | Game code | Why it matters |
|---|---|---|
| **[REF]** | `Game.Prefabs.GarbagePrefab` | Writes global `GarbageParameterData` thresholds + garbage happiness values |
| **[REF]** | `Game.Prefabs.GarbageTruck` | Authoring source for truck values before ECS runtime data exists |
| **[NOW]** | `Game.Prefabs.GarbageTruckData` | Runtime prefab component read by the simulation; standard Trash Boss scales this |
| **[REF]** | `Game.Prefabs.GarbageTruckSelectData` | Garbage truck selection logic |
| **[NOW]** | `Game.Prefabs.GarbageFacilityData` | Runtime prefab component for facility storage / processing / fleet / capacity |
| **[REF]** | `Game.Prefabs.DeliveryTruckData` | Relevant to dump-truck / transfer behavior |
| **[REF]** | `Game.Prefabs.VehicleCapacitySystem` | Builds delivery-truck selection data used by transfer systems |
| **[REF]** | `Game.Prefabs.DeliveryTruckSelectData` | Used in facility transfer logic for transfer truck capacity range |
| **[NOW]** | `Game.Simulation.GarbageCollectionRequest` + flags | Building pickup request schema |
| **[REF]** | `Game.Simulation.GarbageTransferRequest` + flags | Facility transfer/import/export request schema |
| **[REF]** | `Game.Simulation.GarbageFacilityAISystem` | Core garbage facility logic. Spawns `GarbageTruck` and `DeliveryTruck`, sets facility transfer priorities, creates garbage transfer requests |
| **[REF]** | `Game.Simulation.GarbageTransferDispatchSystem` | Dispatch path for garbage transfer requests; distinguishes outside connections |
| **[REF]** | `Game.Simulation.GarbageCollectorDispatchSystem` | Building pickup request dispatch / validation |
| **[REF]** | `Game.Simulation.GarbagePathfindSetup` | Path setup for collector + transfer flows |
| **[REF]** | `Game.Simulation.GarbageAccumulationSystem` | Accumulates producer garbage, clamps it, creates requests, adds warning state |
| **[REF]** | `Game.Simulation.GarbageTruckAISystem` | Pickup gate uses collection threshold; appends side pickups along the path |
| **[REF]** | `Game.Simulation.CitizenHappinessSystem` | Garbage happiness penalty uses baseline + step and caps at `-10` |
| **[REF]** | `Game.UI.InGame.GarbageVehicleSection` | Shows `GarbageTruck` as industrial waste truck when that flag is set |
| **[REF]** | `Game.UI.InGame.GarbageInfoviewUISystem` | Good reference for efficient garbage aggregation queries |
| **[REF]** | `Game.Debug.GarbageDebugSystem` | Debug visualization reference for garbage state |

---

## Short “future me” guidance

### If standard tuning is enough
Use:
- Trash Boss
- Priority System
- standard sliders only

Let the city run about **1 in-game month** before judging.

### If standard tuning is not enough
Then try:
- Power User thresholds
- Happiness baseline / step
- Accumulation rate

### If transfer behavior needs work later
Do not jump straight to sliders. First:
- use the transfer probe log
- verify whether local facilities, outside connections, or both are driving the transfer behavior

