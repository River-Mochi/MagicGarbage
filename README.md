# Magic Garbage [MG]

Two ways to handle garbage in **Cities: Skylines II**.

All controls are in the **Options** menu.  
There is **no in-city UI panel** and **no Harmony**.

## Option 1 – Total Magic (Auto Clean)

- ✅ **Total Magic ON**
- All city garbage is removed almost instantly.
- Garbage warning icons are cleared because there is no garbage.
- Garbage trucks and garbage buildings become mostly cosmetic.
- A few trucks may still drive around due to vanilla dispatch timing.

Under the hood: a **Burst-compiled ECS job** runs periodically and clears garbage in chunks, so even huge cities stay smooth.

---

## Option 2 – Trash Boss (Self Manage)

- ✅ **Trash Boss ON**, **Total Magic OFF**
- Vanilla garbage simulation stays active, but these values can be tuned:

  - **Truck load capacity** (**100–500%**)
  - **Facility storage** (**100–500%**)
  - **Facility process speed** (**100–500%**)
  - **Facility fleet** (**100–400%**)
  - **Building thresholds** (**1x–30x**) *(optional)*

### Building thresholds
This optional slider raises both of these together:

- **Dispatch Request threshold**
- **Pickup threshold**

Higher values can reduce garbage truck traffic, but setting it too high can also reduce pickup frequency too much.

- **1x** = vanilla
- vanilla thresholds are **100 request** and **20 pickup**
- as a rough player-facing conversion, **1,000 garbage units ≈ 1t**

Most players do **not** need to change this slider.  
It is mainly there for testing and for players who want to experiment with reducing garbage truck traffic further.

### Preset buttons
- **Game Defaults** – returns all Trash Boss sliders to vanilla values
  - Percent sliders back to **100%**
  - Building thresholds back to **1x**

- **Recommended** – applies:
  - Truck load capacity: **200%**
  - Building thresholds: **5x**
  - Facility process speed: **200%**
  - Facility storage: **150%**
  - Facility fleet: **140%**

> 💡 **Total Magic** and **Trash Boss** can both be off if only Status report desired.  
> Trash Boss slider values are saved even while **Total Magic** is ON.

---

## Status panel

The **Status** section in Options shows a live garbage snapshot while the menu is open, including:

- citywide garbage produced vs processed
- active collect requests
- buildings with garbage
- buildings above request threshold
- garbage facilities, trucks, and max workers
- truck state summary

### Detailed Status to Log
The **Detailed Status to Log** button writes a larger report into:

`Logs/MagicGarbage.log`

This includes things like:

- current live game garbage thresholds
- pending vs dispatched requests
- building garbage stats
- highest pending target garbage
- near-warning building counts
- truck summary
- per-facility summary

### Open Log
- **Open Log** opens the game log folder.

---

## Compatibility

- Works with new and existing saves
- Safe to disable or remove
- Uses **ECS + Burst** and slider-driven tuning
- **No Harmony**
- Designed to be lightweight and resilient to game updates

---

## Credits

- RiverMochi: author
- Thanks to **Wayz** for the original “Magical Garbage Truck” idea
- yenyang: code review, tech advice
- Necko1996: testing and feedback
- gagaxm: thumbnail image


---

### Garbage happiness penalty comparison

**Formula used by the game**

- Penalty starts after: `baseline + step`
- Penalty value: `-floor((garbage - baseline) / step)`
- Capped at **-10**

### Presets compared

- **Vanilla:** baseline **100**, step **65** → first `-1` at **165**
- **Compromise:** baseline **550**, step **150** → first `-1` at **700**
- **Very soft:** baseline **950**, step **200** → first `-1` at **1150**

| Garbage in Building | Vanilla<br>`100 / 65` | Compromise<br>`550 / 150` | Very soft<br>`950 / 200` |
|---:|---:|---:|---:|
| 100  | 0   | 0   | 0   |
| 165  | -1  | 0   | 0   |
| 300  | -3  | 0   | 0   |
| 600  | -7  | 0   | 0   |
| 700  | -9  | -1  | 0   |
| 850  | -10 | -2  | 0   |
| 1000 | -10 | -3  | 0   |
| 1150 | -10 | -4  | -1  |
| 1400 | -10 | -5  | -2  |
| 2000 | -10 | -10 | -5  |

### Suggested preset

- **Dispatch Request Threshold:** `1000`
- **Pickup Threshold:** `200`
- **Garbage Happiness Baseline:** `550`
- **Garbage Happiness Step:** `150`

This keeps some garbage-related happiness pressure in the game, but is much less harsh than vanilla.
