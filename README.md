# BigfootXR
A quickstart beginner-targeted VR toolkit for Unity, based on Unity's built-in generic VR capabilities. It's either this or you start using a dozen different SDKs if you're doing multiplatform VR, basically.

Built in Unity 2018.3.6f1. Compatible with that version and newer. YMMV on older Unity versions. 
This will definitely NOT work on versions prior to Unity 2017.


## Current Features
- Headset tracking
- Controller & remote tracking
-- Automatic controller-specific detection & adjustments
- Simple "virtual joystick" movement
- Simple aim-and-shoot teleport functionality (straight line laser pointer)
- UI interactivity (straight line laser pointer)
- Grabbing & throwing


## Known Bugs
- Grabbing & throwing is also doable via the laser pointers via Unity's collision/hierarchy functionality
- Grabbing sometimes fails depending on how fast you move while carrying an object
- Teleporting sometimes happens on a specific button press, if previously-activated teleport buttons are deactivated in a specific order


## Getting Started & Installation

This toolkit includes scripts, prefabs, and project settings. 
The easiest way to set up this toolkit for your own project is to copy the Assets & Project Settings folders into your project directory.
If you need to be delicate, just copy the Assets folder & the InputManager.asset file from within Project Settings into your project. And then make sure you enable your relevant XR devices in your Player Settings.

The InputManager is premade to support the controllers for the HTC Vive, Oculus Rift, and Windows Mixed Reality headsets.
There is a "VRContainer" prefab in the included assets that has the basic setup ready to use for a VR game on any platform. Drop that prefab into your game and use that as your headset-and-controllers base, on mobile VR & most PC VR platforms.

### Prerequisites

This toolkit is built in Unity 2018.3.6f1. For smoothest operations, please use that version or newer.


## Change Log
- Updated to 2018.3.6f1. Also implemented OpenVR/Oculus SDKs via the Unity Package Manager - 15/05/19
- Renamed "BigfootVRToolkit" to BigfootXR - 12/03/18


## Roadmap
- COMING SOON
