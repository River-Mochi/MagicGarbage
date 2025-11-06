# Magic Garbage Truck [MGT]

## Two ways to handle garbage in **Cities: Skylines II**

## Option 1 Total Magic (recommended default)

- ✅ Magic Garbage on
- All city garbage is removed instantly.
- No garbage micromanagement. Just build your city and ignore garbage.
- Auto disables garbage warning icons because there is no garbage
- Garbage trucks and buildings are purely cosmetic.
- Closest to the classic defunct "Magical Garbage Truck" mod.

## Option 2 Semi-Magic (🚚 Super Trucks)
- Turn **Magic Garbage = OFF**.
- Use the **Garbage Truck Capacity** slider (**100–500%**) to make super-size trucks.
- Vanilla garbage simulation stays active.
  - Each truck carries more garbage so fewer trucks are needed.
  - Unload speed scales with capacity so depots don’t clog.

> 💡 Do Option 1 or 2 – not both.  
> Nothing breaks if you mix them, but you won’t gain anything extra.

## Compatibility
- Works with new and existing saves.
- Safe to remove or disable at any time; 
- This does not use Harmony or Reflection - lightweight and less likely to break with game updates.


---

## Credits

- **RiverMochi** – author and maintainer  
- Thanks to **Wayz** for inspiration on the original Magical Garbage mod  
- **Necko1996** – testing and feedback

---

### Internal systems & behaviour

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
| Mod bootstrap                      | Registers settings, locales, and schedules systems in the GameSimulation phase. | `Mod.OnLoad` wires `MagicGarbageSystem`, `GarbageNotificationRemoverSystem`, and `GarbageTruckCapacitySystem`. |
