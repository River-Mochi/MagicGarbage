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

- **Truck load capacity** (**100–1000%**)
- **Facility storage** (**100–500%**)
- **Facility processing speed** (**100–500%**)
- **Facility fleet** (**100–400%**)

### Standard preset buttons

**Recommended**
- Truck load capacity: **200%**
- Facility storage: **150%**
- Facility processing speed: **250%**
- Facility fleet: **100%**
- Assigned-target protection: **15%**

**Game Defaults**
- Returns the standard Trash Boss sliders to vanilla values.
- Returns assigned-target protection to the game default.

---

## Assigned-target protection

Game 1.6.2 adds target-aware garbage-truck routing. Magic Garbage provides a safe control for that built-in behavior.

- **10%** is the game default
- **15%** is the Magic Garbage Recommended value
- The slider is limited to **10–25%**
- It makes trucks more selective about optional pickups before reaching the assigned building
- It is a soft protection margin, not guaranteed empty cargo space

Magic Garbage applies the value once after city load or a settings change, then stays idle. There is no Priority Assist scan and no Harmony patch.

## Status-only option

You can also leave **Total Magic OFF** and **Trash Boss OFF** if you only want the live **Status** report.

This is useful for checking garbage behavior without changing the simulation.

---

## Status panel

The **Status** section in Options shows a live garbage snapshot while the menu is open, including:

- **Garbage Service Rating**
- citywide garbage production vs processing capacity
- active collect requests
- buildings with garbage
- buildings at the 8t early-intervention level
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
- buildings at the 8t early-intervention level
- assigned-target protection value
- truck summary
- per-facility summary
- garbage transfer probe info

### Open Log

- **Open Log** opens `MagicGarbage.log` directly. If the file does not exist yet, it opens the Logs folder.

---

## Compatibility

- Works with new and existing saves
- Safe to disable or remove
- **No Harmony**
- Targets the game 1.6.2 garbage-service behavior
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
