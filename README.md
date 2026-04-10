# Magic Garbage [MG]

Two main ways to handle garbage in **Cities: Skylines II**, plus a **Status-only** option.

All controls are in the **Options** menu.  
There is **no in-city UI panel** and **no Harmony**.

---

## Option 1 – Total Magic (Auto Clean)

- ✅ **Total Magic ON**
- All city garbage is removed automatically.
- Garbage warning icons clear because there is no garbage.
- Garbage trucks and garbage buildings become mostly cosmetic.
- A few trucks may still move due to vanilla dispatch timing.

---

## Option 2 – Trash Boss (Self Manage)

- ✅ **Trash Boss ON**
- **Total Magic OFF**
- Vanilla garbage simulation stays active, but these standard values can be tuned:

  - **Truck load capacity** (**100–500%**)
  - **Facility storage** (**100–500%**)
  - **Facility processing speed** (**100–500%**)
  - **Facility fleet** (**100–400%**)

### Standard preset buttons

- **Recommended**
  - Truck load capacity: **200%**
  - Facility processing speed: **200%**
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
- **Garbage Accumulation Rate**

### What they do

- **Dispatch Request Threshold**  
  Building garbage needed before a truck dispatch request is created or kept.

- **Pickup Threshold**  
  Minimum building garbage before a truck can collect from it.

- **Garbage Happiness Baseline**  
  Building garbage level before it starts causing health + happiness penalty.

- **Garbage Happiness Step**  
  Extra garbage over baseline amount that causes each additional `-1` garbage penalty.

- **Garbage Accumulation Rate**  
  Scales supported building garbage source values.

### Power User rules

- **Pickup** cannot be higher than **Dispatch Request**
- Power User values are saved even when **Power User** is turned off
- Standard Trash Boss buttons do not overwrite Power User values

### Power User preset buttons

- **Recommended**
  - Turns **Power User ON**
  - Garbage Happiness Baseline: **550**
  - Garbage Happiness Step: **150**
  - First garbage penalty starts at **700**
  - **Garbage Accumulation Rate** stays at **100%** unless changed manually

- **Game Defaults**
  - Returns Power User values to vanilla
  - Turns **Power User OFF**

### Why use Power User?

Most players do **not** need Power User.

It is there for players who want to experiment with advanced garbage tuning, reduce truck traffic further, or better understand how the garbage systems behave.

As a rough player-facing conversion:

- **100 garbage units = 0.1t**
- **1,000 garbage units = 1t**

### Happiness examples

- **Vanilla:** `100 / 65` → first penalty at **165**
- **Recommended button:** `550 / 150` → first penalty at **700**
- **Very soft:** `950 / 200` → first penalty at **1150**

---

## Status-only option

You can also leave **Total Magic OFF** and **Trash Boss OFF** if you only want the live **Status** report.

This is useful for checking garbage behavior without changing the simulation.

---

## Status panel

The **Status** section in Options shows a live garbage snapshot while the menu is open, including:

- **Garbage Service Rating**
- citywide garbage produced vs processed
- active collect requests
- buildings with garbage
- buildings above request threshold
- garbage facilities
- garbage trucks and dump trucks
- max workers
- truck state summary

### Detailed Status to Log

The **Detailed Status to Log** button writes a larger report into:

`Logs/MagicGarbage.log`

This includes things like:

- live game garbage thresholds
- current mod settings
- garbage service rating
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
- **No Harmony**
- Designed to be lightweight
- Status refresh happens in the **Options** menu instead of running as a constant in-city panel

---

## Credits

- RiverMochi: author
- Thanks to **Wayz** for the original “Magical Garbage Truck” idea
- yenyang: code review, tech advice
- Necko1996: testing and feedback
- gagaxm: thumbnail image

---

## Languages

- English
- Français
- Deutsch
- Español
- Italiano
- 日本語
- 한국어
- Português do Brasil
- Polski
- 简体中文
- 繁體中文


## Links
Discord https://discord.gg/HTav7ARPs2
Github https://github.com/River-Mochi/MagicGarbage
Forum: https://forum.paradoxplaza.com/forum/threads/magic-garbage-truck.1867844/
