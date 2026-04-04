# Magic Garbage [MG]

Two main ways to handle garbage in **Cities: Skylines II**, plus a **Status-only** option.

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

- ✅ **Trash Boss ON**
- **Total Magic OFF**
- Vanilla garbage simulation stays active, but these standard values can be tuned:

  - **Truck load capacity** (**100–500%**)
  - **Facility storage** (**100–500%**)
  - **Facility process speed** (**100–500%**)
  - **Facility fleet** (**100–400%**)

### Standard preset buttons

- **Recommended**
  - Truck load capacity: **200%**
  - Facility process speed: **200%**
  - Facility storage: **150%**
  - Facility fleet: **140%**

- **Game Defaults**
  - Returns the standard Trash Boss sliders to vanilla values
  - Percent sliders back to **100%**

> These standard buttons do **not** change Power User settings.

---

## Optional – Power User

Power User is a separate advanced section inside **Trash Boss**.

When **Power User** is enabled, these extra sliders appear:

- **Dispatch Request Threshold** (**100–3000**)
- **Pickup Threshold** (**20–1000**)
- **Garbage Happiness Baseline** (**100–3000**)
- **Garbage Happiness Step** (**65–500**)

### What they do

- **Dispatch Request Threshold**  
  Building garbage needed before a truck dispatch request is created or kept.

- **Pickup Threshold**  
  Minimum building garbage before a truck can collect from it.

- **Garbage Happiness Baseline**  
  Building garbage level before it starts causing health + happiness penalty.

- **Garbage Happiness Step**  
  Extra garbage over baseline amount that causes each additional `-1` garbage penalty.

### Power User rules

- **Pickup Threshold** can never be higher than **Dispatch Request Threshold**
- Power User slider values are saved even when **Power User** is turned off
- Standard Trash Boss buttons do not overwrite Power User values

### Power User preset buttons

- **Recommended**
  - Dispatch Request Threshold: **1000**
  - Pickup Threshold: **200**
  - Garbage Happiness Baseline: **550**
  - Garbage Happiness Step: **150**

- **Game Defaults**
  - Dispatch Request Threshold: **100**
  - Pickup Threshold: **20**
  - Garbage Happiness Baseline: **100**
  - Garbage Happiness Step: **65**
  - Turns **Power User** back off

### Why use Power User?

Higher request/pickup thresholds can reduce garbage truck traffic, but setting them too high can also reduce pickup frequency too much.

Most players do **not** need Power User.  
It is mainly there for testing and for players who want to experiment with advanced garbage tuning.

As a rough player-facing conversion:

- **100 garbage units = 0.1t**
- **1,000 garbage units = 1t**

---

## Status-only option

You can also leave **Total Magic OFF** and **Trash Boss OFF** if you only want the live **Status** report.

This is useful for checking garbage behavior without changing the simulation.

---

## Status panel

The **Status** section in Options shows a live garbage snapshot while the menu is open, including:

- citywide garbage produced vs processed
- active collect requests
- buildings with garbage
- buildings above request threshold
- garbage facilities, trucks, dump trucks, and max workers
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
- Thanks to **Wayz** for the original “Magical Garbage Truck” idea. It has evolved a lot since then.
- yenyang: code review, tech advice
- Necko1996: testing and feedback
- gagaxm: thumbnail image

---

## Garbage happiness penalty comparison

**Formula used by the game**

- Penalty starts after: `baseline + step`
- Penalty value: `-floor((garbage - baseline) / step)`
- Capped at **-10**

### Presets compared

- **Vanilla:** baseline **100**, step **65** → first `-1` at **165**
- **Recommended:** baseline **550**, step **150** → first `-1` at **700**
- **Very soft:** baseline **950**, step **200** → first `-1` at **1150**

| Garbage in Building | Vanilla<br>`100 / 65` | Recommended<br>`550 / 150` | Very soft<br>`950 / 200` |
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

This keeps some garbage-related happiness pressure in the game, but is much less harsh than vanilla.
- At 1,000 garbage units (1t), the vanilla penalty is already at `-10`, while the recommended is still at `-3` and the very soft preset is still at `0`.
