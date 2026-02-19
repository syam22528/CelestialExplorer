# Celestial Explorer

An immersive **Unity XR space exploration project** built for Meta/Oculus devices.

**A multimodal XR journey** that combines scientific-themed worldbuilding with cinematic interaction design.

Celestial Explorer is designed as both an interactive prototype and a presentation-ready XR showcase. It investigates how movement modality, transition design, and environmental cues can improve user presence while maintaining clear navigation across multiple celestial scenes.

## Abstract

This project explores a mixed locomotion framework in virtual reality, combining controller-driven navigation with gesture-assisted interaction and gaze-aligned flight. The system integrates cinematic scene transitions (animation, warp effects, fade flash), contextual physics behavior (moon gravity), and spatial interaction patterns (ship entry/exit anchors, palm-linked UI). The resulting experience aims to balance user agency with structured pacing, creating a coherent exploration flow rather than disconnected scene hopping.

## Showcase Snapshot

- **Genre:** XR exploration / interactive simulation
- **Core Value:** Cinematic, embodied travel across planetary environments
- **Interaction Modes:** Controller input + hand/gesture workflows
- **Presentation Strength:** Distinct transition language (warp + flash + audio) with broad scene variety

## Highlights

- Multi-scene exploration of space-themed environments (Earth, Moon Surface, Mars, Jupiter, Saturn, Venus, Neptune, Black Hole)
- XR-focused locomotion options:
  - Joystick movement
  - Gesture-based flying and hand-pose recognition
- Spaceship interaction flow:
  - Explicit entry/exit anchor points for the camera rig
  - Palm-menu-linked UI interactions
- Cinematic scene switching pipeline:
  - Animation trigger
  - Warp VFX ramp up/down
  - Fade flash before scene load
- Environmental simulation touches (moon gravity override and orbital moon behavior)

## Research & Design Objectives

- Evaluate how **multimodal locomotion** affects comfort and exploratory behavior in XR
- Improve **spatial continuity** between scenes using transition choreography
- Support **interaction inclusivity** for both hand-tracking and controller-first users
- Maintain a clear implementation structure for iteration, analysis, and reporting

## Tech Stack

- **Engine:** Unity `2022.3.42f1`
- **Render Pipeline:** Universal Render Pipeline (URP)
- **XR / Platform:**
  - Meta XR SDK (`com.meta.xr.sdk.all` `69.0.1`)
  - XR Interaction Toolkit (`2.6.3`)
  - Oculus XR Plugin (`4.2.0`)
- **UI / Text:** uGUI + TextMeshPro

## Scenes (Build Settings)

Configured scenes include:

- `Assets/Scenes/start_Game.unity`
- `Assets/Scenes/Earth.unity`
- `Assets/Scenes/Moon Surface.unity`
- `Assets/Scenes/Mars.unity`
- `Assets/Scenes/Jupiter.unity`
- `Assets/Scenes/Saturn.unity`
- `Assets/Scenes/Venus.unity`
- `Assets/Scenes/Neptune.unity`
- `Assets/Scenes/Black Hole.unity`

## Core Gameplay Systems

- **Scene Transition Controller** (`Assets/SceneController.cs`)
  - Listens to scene toggles and orchestrates transition timing
  - Plays animation, activates warp VFX, and executes a fade flash
  - Loads selected scenes with Build Settings validation
- **Scene Toggle Mapping** (`Assets/SceneToggle.cs`)
  - Decouples UI toggle elements from explicit scene string wiring
- **Ship Interaction** (`Assets/ShipInteraction.cs`, `Assets/ShipMovement.cs`, `Assets/CabinCollider.cs`)
  - Handles enter/exit teleport anchors and in-cabin movement behavior
  - Constrains camera position to cabin collider bounds when required
- **Movement** (`Assets/joysticklocomotion.cs`, `Assets/GestureLocomotion.cs`)
  - Supports controller locomotion and gaze-direction flying
  - Includes runtime speed modulation for movement tuning
- **Gesture Recognition** (`Assets/HandPointFlyer.cs`)
  - Compares live finger-bone poses against saved gesture datasets
- **Audio** (`Assets/SoundManager.cs`)
  - Centralizes startup and UI interaction audio cues
- **Environment Systems** (`Assets/MoonGravity.cs`, `Assets/moonRevolve.cs`)
  - Applies scene-context gravity and orbital motion rules

## Implementation Notes

- Transition sequencing is coroutine-driven to enforce temporal order and pacing.
- Scene routing is decoupled from UI through explicit scene-name mapping.
- Gesture recognition relies on finger-bone pose comparison against saved samples.
- Handedness-aware menu filtering supports both dominant-hand and active-controller states.

## Getting Started

### Prerequisites

- Unity Hub
- Unity Editor `2022.3.42f1`
- A Meta/Oculus-compatible VR setup for full XR testing

### Open and Run

1. Clone this repository.
2. Open the project folder in Unity Hub.
3. Let Unity resolve packages from `Packages/manifest.json`.
4. Open a start scene (typically `Assets/Scenes/start_Game.unity`).
5. Press Play in Editor, or build to your target XR device.

## Controls & Interaction Notes

- **Controller locomotion:** right thumbstick-driven movement.
- **Gesture locomotion:** toggleable through events bound to `ActivateFlying()` and `DeactivateFlying()`.
- **Gesture authoring/debug:** `GestureDetector` supports saving gesture snapshots with **Space** in Editor debug mode.
- **UI handedness behavior:** palm menu visibility/filtering adapts to dominant hand or active controller.

## Portfolio Positioning

- Demonstrates practical XR integration across input, UI, VFX, and scene management.
- Shows applied interaction design thinking, not only asset assembly.
- Suitable as a capstone/demo piece for XR development, interaction design, or immersive systems portfolios.

## Project Structure

```text
CelestialExplorer/
├─ Assets/
│  ├─ Scenes/
│  ├─ XR/ XRI/ Oculus/
│  ├─ scripts (movement, interaction, scene, audio, environment)
│  └─ art/audio/VFX assets
├─ Packages/
│  ├─ manifest.json
│  └─ packages-lock.json
└─ ProjectSettings/
```