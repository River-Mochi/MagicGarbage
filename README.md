# Magic Garbage [MG]

Two main ways to handle garbage in **Cities: Skylines II**, plus a **Status-only** option.

All controls are in the **Options** menu.  
There is no in-city UI panel.

---

## Option 1 – Total Magic (Auto Clean)

- ✅ **Total Magic ON**
- Removes all city garbage automatically.
- Garbage warning icons clear because there is no garbage.
- Garbage trucks and garbage buildings become mostly cosmetic.
- Vanilla garbage logic still exists; cleanup is just very fast.

---

## Option 2 – Trash Boss (Self Manage)

- ✅ **Trash Boss ON**
- **Total Magic OFF**
- Keeps vanilla garbage simulation running, but lets key garbage values be tuned.

### Standard Trash Boss sliders

- **Truck load capacity** (**100–500%**)
- **Facility storage** (**100–500%**)
- **Facility processing speed** (**100–500%**)
- **Facility fleet** (**100–400%**)

### Standard preset buttons

**Recommended**
- Truck load capacity: **250%**
- Facility storage: **150%**
- Facility processing speed: **250%**
- Facility fleet: **100%**

**Game Defaults**
- Returns the standard Trash Boss sliders to vanilla values.

> Standard Trash Boss buttons do **not** change Power User settings.

---

## Priority System (lightweight)

When **Trash Boss** is enabled, **Priority Assist** is also available.

- Watches for buildings over **7t** garbage
- Temporarily raises **Pickup Threshold** to the current **Dispatch Request Threshold**
- Helps reduce extra side pickups so badly overloaded buildings get reached sooner

This is a **lightweight assist**, not a hard route override.

For most cities, **Trash Boss + Priority Assist** is enough.  
Let the city run for about **1 in-game month** before deciding whether more tuning is needed.

---

## Optional – Power User

Power User is a separate advanced section inside **Trash Boss**.

When **Power User** is enabled, these extra sliders appear:

- **Dispatch Request Threshold** (**100–2000**)
- **Pickup Threshold** (**20–1000**)
- **Garbage Happiness Baseline** (**100–2000**)
- **Garbage Happiness Step** (**65–1000**)
- **Garbage Accumulation Rate** (**20–200%**)

### Power User rules

- **Pickup** cannot be higher than **Dispatch Request**
- Power User values stay saved even when **Power User** is turned off
- Standard Trash Boss buttons do not overwrite Power User values

### Power User preset buttons

**Recommended**
- Turns **Power User ON**
- Dispatch Request Threshold: **500**
- Pickup Threshold: **300**
- Garbage Happiness Baseline: **550**
- Garbage Happiness Step: **150**
- Garbage Accumulation Rate: **100%**

**Game Defaults**
- Returns Power User values to vanilla
- Turns **Power User OFF**

### Should most players use Power User?

Usually, **no**.

Most cities work well with:
- **Trash Boss**
- **Priority Assist**
- standard slider tuning only

Power User is best for:
- advanced tuning
- experiments
- learning how the garbage systems behave

Let the city run for about **1 in-game month** before judging results.  
Changing Power User too aggressively can make garbage behavior/traffic worse instead of better.

rough conversion:
- **1,000 garbage units = 1t**

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
- critical buildings over **7t**
- garbage facilities
- garbage trucks and dump trucks
- max workers
- truck state summary

### Detailed Status to Log

The **Detailed Status to Log** button writes a larger report into:

`Logs/MagicGarbage.log`

This includes:

- current mode + settings
- live garbage thresholds
- garbage service rating
- pending vs dispatched requests
- building garbage stats
- critical buildings over **7t**
- priority assist summary
- truck summary
- per-facility summary
- garbage transfer probe info

### Open Log

- **Open Log** opens the game log folder.

---

## Compatibility

- Works with new and existing saves
- Safe to disable or remove
- **No Harmony**
- Designed to be lightweight
- Status refresh happens in the **Options** menu instead of a constant in-city panel

---

## Credits

- RiverMochi: author
- Thanks to **Wayz** for the original “Magical Garbage Truck” idea
- yenyang: code review, tech advice
- Necko1996: testing and feedback
- gagaxm: thumbnail image

---

## Languages

English, Français, Deutsch, Español, Italiano, 日本語, 한국어, Português do Brasil, Polski, 简体中文, 繁體中文

---

## Links

Discord: https://discord.gg/HTav7ARPs2  
Github: https://github.com/River-Mochi/MagicGarbage  
Forum: https://forum.paradoxplaza.com/forum/threads/magic-garbage-truck.1867844/
