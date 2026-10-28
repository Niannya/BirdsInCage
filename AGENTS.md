# BirdsInCage — Agent instructions

## Mission
Assist development of **BirdsInCage**, a narrative-focused 2D top-down horror/puzzle game. Current near-term goal: create a **playable vertical slice**, not the entire game.

## Context first
1. Read `Docs/DecisionLog.md` and `Docs/GameOverview.md` before planning.
2. Read the relevant other `Docs/*.md` before changing narrative, mechanics, rooms, or progression.
3. Treat **Confirmed** as established and **Open** as unresolved. Do not turn speculative examples into canon.
4. The documents are a handoff, not an inspection of the actual Unity project. Inspect the project before selecting frameworks, inputs, or scene structure.

## Narrative constraints
- Philomel's solitude is intentional: **do not add a servant** to the mansion.
- The mansion was magically restored after the fire and generally retains its original structure.
- Do not invent plot beats, room functions, characters, architectural era, or a final slice scope without checking with the user.
- Preserve the intentional player-facing mystery, especially the true witch core, fourth-wall puzzle, and ending conditions. Avoid automatically exposing spoilers in player-facing assets.
- If a source passage contradicts a more recent confirmed choice, flag the contradiction; do not silently rewrite the story.

## Unity development
- Work in the existing Unity project, in C#. Do not replace its structure with a new project.
- Preserve `.meta` files / GUID references; prefer working within Unity asset conventions.
- Do not commit generated `Library/`, `Temp/`, `Obj/`, `Logs/`, or build outputs.
- Make narrow, reviewable edits. Explain changes, affected files, and what was tested.
- Never assert Unity editor playtests were run if they were not.
- Before a destructive operation, broad refactor, dependency addition, or project setting change, explain the plan and seek confirmation.
- Prefer a small playable implementation of one core gameplay loop over speculative systems for the whole game.

## Collaboration
- For ambiguous design issues, propose options clearly marked as suggestions; never silently adopt one.
- Keep design docs and `Docs/DecisionLog.md` updated when the user approves a decision.
- Start by summarizing your understanding and listing questions; **do not edit on the first handoff task unless asked**.
