# Magic Garbage Truck [MGT]

## Two ways to handle garbage in **Cities: Skylines II**

## Option 1 – Total Magic (Auto Clean)

- ✅ **Total Magic ON**
- All city garbage is removed almost instantly.
- No garbage micromanagement – just build your city.
- Garbage warning icons are cleared because there is no garbage.
- Garbage trucks and buildings become mostly cosmetic.
- Under the hood: a **Burst-compiled ECS job** runs roughly every few in-game minutes
  and sweeps all garbage producers in chunks, so even huge cities stay smooth.

## Option 2 – Semi-Magic (Self-Manage)

- ✅ **Self-Manage ON**, **Total Magic OFF**.
- Vanilla garbage simulation stays active, but you control all stats:
  - **Truck load capacity** (100–500%)
  - **Facility truck count** (100–400%)
  - **Processing speed** (100–500%)
  - **Facility storage capacity** (100–500%)
- Two helper buttons:
  - **Game Defaults** – puts everything back to **100%** (pure vanilla behaviour).
  - **Recommended** – 200% truck load, 150% truck count, 200% processing speed, 150% storage.

> 💡 Choose **Total Magic** *or* **Self-Manage**.  
> You can swap between them any time; the UI makes it clear what’s active.

## Compatibility

- Works with new and existing saves.
- Safe to remove or disable at any time.
- Uses a **Burst-optimized ECS job** and slider-driven prefab tuning — no Harmony, no reflection.
- Designed to be lightweight and resilient to game updates.

---

## Credits

- RiverMochi: author 
- Thanks to **Wayz** for the original “Magical Garbage Truck” idea  
- yenyang: code review, tech advice
- Necko1996: testing and feedback

