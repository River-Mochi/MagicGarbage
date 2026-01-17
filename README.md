# Magic Garbage Truck [MGT]

Two ways to handle garbage in **Cities: Skylines II**.

## Option 1 – Total Magic (Auto Clean)

- ✅ **Total Magic ON**
- All city garbage is removed almost instantly.
- Garbage warning icons are cleared because there is no garbage.
- Garbage trucks and buildings become mostly cosmetic.
- A few trucks may still drive around due to the game’s dispatch logic (usually empty).

Under the hood: a **Burst-compiled ECS job** runs periodically and clears garbage in chunks, so even huge cities stay smooth.

## Option 2 – Semi-Magic (Self-Manage)

- ✅ **Semi-Magic ON**, **Total Magic OFF**
- Vanilla garbage simulation stays active, but you control these stats:
  - **Truck load capacity** (100–500%)
  - **Facility truck count** (100–400%)
  - **Processing speed** (100–500%)
  - **Facility storage capacity** (100–500%)

### Preset buttons
- **Game Defaults** – sets all sliders to **100%** (pure vanilla behavior).
- **Recommended** – applies:
  - Truck load capacity: **200%**
  - Processing speed: **200%**
  - Storage capacity: **160%**
  - Facility truck count: **140%**

> 💡 Total Magic and Semi-Magic are mutually exclusive.  
> Your Semi-Magic slider values are saved even while Total Magic is ON.

## Compatibility

- Works with new and existing saves.
- Safe to disable or remove.
- Uses ECS + Burst and slider-driven tuning — **no Harmony**, **no reflection**.
- Designed to be lightweight and resilient to game updates.

## Credits

- RiverMochi: author
- Thanks to **Wayz** for the original “Magical Garbage Truck” idea
- yenyang: code review, tech advice
- Necko1996: testing and feedback
