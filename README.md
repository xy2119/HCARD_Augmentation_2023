# HCARD_Augmentation_2023
Welcome to the HCARD Augmentation 2023 repository! This repository contains the source code for an AI-driven motion tracking drawing application created as part of the Human Centered Design of Assistive and Rehabilitation Devices course at Imperial College London.

<!-- ABOUT THE PROJECT -->
## Project Overview

The HCARD Augmentation project is aimed at developing a drawing application that uses AI-driven motion tracking to assist users with limited mobility or dexterity in creating art. The application will track the user's movements and translate them into a digital medium, allowing them to create beautiful works of art without having to hold or manipulate traditional drawing tools.

https://user-images.githubusercontent.com/113228076/227746031-5bfbe697-b20e-497f-8b04-9bd313788bb0.MP4



![image](./img/UI_preview.PNG)

## Prerequisites

[![made-with-python](https://img.shields.io/badge/Made%20with-Python-1f425f.svg)](https://www.python.org/) <br>

<!--This project is written in Python programming language. <br>-->
The following are the major open source packages utilised in this project:

* Numpy
* Pandas
* OpenCV
* MediaPipe
* Imutils



## Project Structure

The project is structured as follows:

 ```
📦 
.DS_Store
├─ .ipynb_checkpoints
│  ├─ HCARD_hand_track-checkpoint.ipynb
│  └─ Track_Aruco_Tag-checkpoint.ipynb
├─ LICENSE
├─ README.md
├─ gripper_hardware
│  ├─ .DS_Store
│  ├─ README.md
│  └─ button_read.ino
├─ img
│  ├─ .DS_Store
│  ├─ HCARD_demo.mp4
│  └─ UI_preview.PNG
├─ motion_detection
│  ├─ .DS_Store
│  ├─ HCARD_hand_track.ipynb
│  ├─ README.md
│  ├─ Track_Aruco_Tag.ipynb
│  └─ my_aruco_tag.png
└─ unity_game
   ├─ .DS_Store
   ├─ .gitignore
   ├─ .vsconfig
   ├─ Assets
   │  ├─ Animation.meta
   │  ├─ Animation
   │  │  ├─ Canvas.controller
   │  │  ├─ Canvas.controller.meta
   │  │  ├─ GIF.controller
   │  │  ├─ GIF.controller.meta
   │  │  ├─ squeeze lemon.anim
   │  │  └─ squeeze lemon.anim.meta
   │  ├─ AutoSaveConfig.asset
   │  ├─ AutoSaveConfig.asset.meta
   │  ├─ ButtonClickDetector.cs
   │  ├─ ButtonClickDetector.cs.meta
   │  ├─ ClickDetector.cs
   │  ├─ ClickDetector.cs.meta
   │  ├─ ColorPicker.cs
   │  ├─ ColorPicker.cs.meta
   │  ├─ CustomInputModule.cs
   │  ├─ CustomInputModule.cs.meta
   │  ├─ DrawingController.cs
   │  ├─ DrawingController.cs.meta
   │  ├─ Editor.meta
   │  ├─ Editor
   │  │  ├─ AutoSaveConfig.cs
   │  │  ├─ AutoSaveConfig.cs.meta
   │  │  ├─ GameUI.colors
   │  │  ├─ GameUI.colors.meta
   │  │  ├─ TarodevAutoSave.cs
   │  │  └─ TarodevAutoSave.cs.meta
   │  ├─ Fonts.meta
   │  ├─ Fonts
   │  │  ├─ Hello Swashes SDF.asset
   │  │  ├─ Hello Swashes SDF.asset.meta
   │  │  ├─ Hello Swashes.ttf
   │  │  └─ Hello Swashes.ttf.meta
   │  ├─ GameManager.cs
   │  ├─ GameManager.cs.meta
   │  ├─ Materials.meta
   │  ├─ Materials
   │  │  ├─ DrawingViewTexture.renderTexture
   │  │  ├─ DrawingViewTexture.renderTexture.meta
   │  │  ├─ UIMaskEDMaterial.mat
   │  │  ├─ UIMaskEDMaterial.mat.meta
   │  │  ├─ UIMaskMaterial.mat
   │  │  ├─ UIMaskMaterial.mat.meta
   │  │  ├─ canvas texture.mat
   │  │  ├─ canvas texture.mat.meta
   │  │  ├─ red.mat
   │  │  └─ red.mat.meta
   │  ├─ Prefabs.meta
   │  ├─ Prefabs
   │  │  ├─ Canvas.prefab
   │  │  ├─ Canvas.prefab.meta
   │  │  ├─ Drawing Container.prefab
   │  │  ├─ Drawing Container.prefab.meta
   │  │  ├─ Test Virtual Mouse Canvas.prefab
   │  │  ├─ Test Virtual Mouse Canvas.prefab.meta
   │  │  ├─ brush texture.meta
   │  │  ├─ brush texture
   │  │  │  ├─ Eraser line.prefab
   │  │  │  ├─ Eraser line.prefab.meta
   │  │  │  ├─ Line.prefab
   │  │  │  ├─ Line.prefab.meta
   │  │  │  ├─ Med Brush.prefab
   │  │  │  ├─ Med Brush.prefab.meta
   │  │  │  ├─ Pencil.prefab
   │  │  │  ├─ Pencil.prefab.meta
   │  │  │  ├─ Small Brush.prefab
   │  │  │  └─ Small Brush.prefab.meta
   │  │  ├─ buttons.meta
   │  │  ├─ buttons
   │  │  │  ├─ Button - Exit.prefab
   │  │  │  ├─ Button - Exit.prefab.meta
   │  │  │  ├─ Button - Freeplay.prefab
   │  │  │  ├─ Button - Freeplay.prefab.meta
   │  │  │  ├─ Button - LineTrace.prefab
   │  │  │  ├─ Button - LineTrace.prefab.meta
   │  │  │  ├─ Button - MiniGame.prefab
   │  │  │  ├─ Button - MiniGame.prefab.meta
   │  │  │  ├─ Button - Recallibrate.prefab
   │  │  │  ├─ Button - Recallibrate.prefab.meta
   │  │  │  ├─ Button Home.prefab
   │  │  │  ├─ Button Home.prefab.meta
   │  │  │  ├─ Button Save.prefab
   │  │  │  └─ Button Save.prefab.meta
   │  │  ├─ drawing tools.meta
   │  │  ├─ drawing tools
   │  │  │  ├─ Button - Brush -M.prefab
   │  │  │  ├─ Button - Brush -M.prefab.meta
   │  │  │  ├─ Button - Brush -S.prefab
   │  │  │  ├─ Button - Brush -S.prefab.meta
   │  │  │  ├─ Button - Pencil.prefab
   │  │  │  ├─ Button - Pencil.prefab.meta
   │  │  │  ├─ Button - Rubber.prefab
   │  │  │  └─ Button - Rubber.prefab.meta
   │  │  ├─ sub-canvas.meta
   │  │  ├─ sub-canvas
   │  │  │  ├─ Force calibration.prefab
   │  │  │  ├─ Force calibration.prefab.meta
   │  │  │  ├─ FreeDraw.prefab
   │  │  │  ├─ FreeDraw.prefab.meta
   │  │  │  ├─ MainMenu.prefab
   │  │  │  └─ MainMenu.prefab.meta
   │  │  ├─ virtual cursor.prefab
   │  │  └─ virtual cursor.prefab.meta
   │  ├─ Samples.meta
   │  ├─ Samples
   │  │  ├─ extOSC.meta
   │  │  └─ extOSC
   │  │     ├─ 1.20.1.meta
   │  │     └─ 1.20.1
   │  │        ├─ Array.meta
   │  │        ├─ Array
   │  │        │  ├─ Array.unity
   │  │        │  ├─ Array.unity.meta
   │  │        │  ├─ Scripts.meta
   │  │        │  └─ Scripts
   │  │        │     ├─ ArrayExample.cs
   │  │        │     └─ ArrayExample.cs.meta
   │  │        ├─ Events And Informers.meta
   │  │        ├─ Events And Informers
   │  │        │  ├─ Events And Informers.unity
   │  │        │  └─ Events And Informers.unity.meta
   │  │        ├─ Events.meta
   │  │        ├─ Events
   │  │        │  ├─ Events.unity
   │  │        │  ├─ Events.unity.meta
   │  │        │  ├─ Scripts.meta
   │  │        │  └─ Scripts
   │  │        │     ├─ EventsExample.cs
   │  │        │     └─ EventsExample.cs.meta
   │  │        ├─ Informers.meta
   │  │        ├─ Informers
   │  │        │  ├─ Informers.unity
   │  │        │  ├─ Informers.unity.meta
   │  │        │  ├─ Scripts.meta
   │  │        │  └─ Scripts
   │  │        │     ├─ InformersExample.cs
   │  │        │     └─ InformersExample.cs.meta
   │  │        ├─ Mapping.meta
   │  │        ├─ Mapping
   │  │        │  ├─ Mapping Example.asset
   │  │        │  ├─ Mapping Example.asset.meta
   │  │        │  ├─ Mapping.unity
   │  │        │  ├─ Mapping.unity.meta
   │  │        │  ├─ Scripts.meta
   │  │        │  └─ Scripts
   │  │        │     ├─ MappingExample.cs
   │  │        │     └─ MappingExample.cs.meta
   │  │        ├─ Scripting.meta
   │  │        ├─ Scripting
   │  │        │  ├─ Scripting.unity
   │  │        │  ├─ Scripting.unity.meta
   │  │        │  ├─ Scripts.meta
   │  │        │  └─ Scripts
   │  │        │     ├─ ScriptingExample.cs
   │  │        │     └─ ScriptingExample.cs.meta
   │  │        ├─ UI.meta
   │  │        └─ UI
   │  │           ├─ UI.unity
   │  │           └─ UI.unity.meta
   │  ├─ Scenes.meta
   │  ├─ Scenes
   │  │  ├─ Calibration.unity
   │  │  ├─ Calibration.unity.meta
   │  │  ├─ Free play.unity
   │  │  ├─ Free play.unity.meta
   │  │  ├─ MAIN.unity
   │  │  ├─ MAIN.unity.meta
   │  │  ├─ Main Menu.unity
   │  │  ├─ Main Menu.unity.meta
   │  │  ├─ Tutorial.unity
   │  │  └─ Tutorial.unity.meta
   │  ├─ ScreenshotButton.cs
   │  ├─ ScreenshotButton.cs.meta
   │  ├─ Screenshots.meta
   │  ├─ Screenshots
   │  │  ├─ Screenshot_2023-03-19_22-08-34.png
   │  │  ├─ Screenshot_2023-03-19_22-08-34.png.meta
   │  │  └─ Screenshot_2023-03-19_22-09-49.png
   │  ├─ Scripts.meta
   │  ├─ Scripts
   │  │  ├─ ArduinoConnect.cs
   │  │  ├─ ArduinoConnect.cs.meta
   │  │  ├─ CanvasController.cs
   │  │  ├─ CanvasController.cs.meta
   │  │  ├─ CanvasManager.cs
   │  │  ├─ CanvasManager.cs.meta
   │  │  ├─ CanvasSwitcher.cs
   │  │  ├─ CanvasSwitcher.cs.meta
   │  │  ├─ ChangeCursor.cs
   │  │  ├─ ChangeCursor.cs.meta
   │  │  ├─ ClearDrawing.cs
   │  │  ├─ ClearDrawing.cs.meta
   │  │  ├─ DrawingBounds.cs
   │  │  ├─ DrawingBounds.cs.meta
   │  │  ├─ LineManager.cs
   │  │  ├─ LineManager.cs.meta
   │  │  ├─ MyVirtualCursor.cs
   │  │  ├─ MyVirtualCursor.cs.meta
   │  │  ├─ PenBrush.cs
   │  │  ├─ PenBrush.cs.meta
   │  │  ├─ PlayerController.cs
   │  │  ├─ PlayerController.cs.meta
   │  │  ├─ SerialConnection.cs
   │  │  ├─ SerialConnection.cs.meta
   │  │  ├─ Singleton.cs
   │  │  ├─ Singleton.cs.meta
   │  │  ├─ mouseCursor.cs
   │  │  ├─ mouseCursor.cs.meta
   │  │  ├─ onMouseHover.cs
   │  │  └─ onMouseHover.cs.meta
   │  ├─ Sounds.meta
   │  ├─ Sprites.meta
   │  ├─ Sprites
   │  │  ├─ Background.png
   │  │  ├─ Background.png.meta
   │  │  ├─ Follow the linbe - canvas card.png
   │  │  ├─ Follow the linbe - canvas card.png.meta
   │  │  ├─ Follow the line - finish button card.png
   │  │  ├─ Follow the line - finish button card.png.meta
   │  │  ├─ Follow the line - game card.png
   │  │  ├─ Follow the line - game card.png.meta
   │  │  ├─ Follow the line - home card.png
   │  │  ├─ Follow the line - home card.png.meta
   │  │  ├─ Free play - canvas card.png
   │  │  ├─ Free play - canvas card.png.meta
   │  │  ├─ Free play - colour select.png
   │  │  ├─ Free play - colour select.png.meta
   │  │  ├─ Free play - home card.png
   │  │  ├─ Free play - home card.png.meta
   │  │  ├─ Free play - large brush.png
   │  │  ├─ Free play - large brush.png.meta
   │  │  ├─ Free play - pencil.png
   │  │  ├─ Free play - pencil.png.meta
   │  │  ├─ Free play - rubber.png
   │  │  ├─ Free play - rubber.png.meta
   │  │  ├─ Free play - save card.png
   │  │  ├─ Free play - save card.png.meta
   │  │  ├─ Free play - small brush.png
   │  │  ├─ Free play - small brush.png.meta
   │  │  ├─ backAction.png
   │  │  ├─ backAction.png.meta
   │  │  ├─ black circle-pin.png
   │  │  ├─ black circle-pin.png.meta
   │  │  ├─ calibration.meta
   │  │  ├─ calibration
   │  │  │  ├─ Callibration screen - animation and bar card.png
   │  │  │  ├─ Callibration screen - animation and bar card.png.meta
   │  │  │  ├─ Callibration screen - instructions card.png
   │  │  │  ├─ Callibration screen - instructions card.png.meta
   │  │  │  ├─ Callibration screen - loading bar.png
   │  │  │  ├─ Callibration screen - loading bar.png.meta
   │  │  │  ├─ SqueezeLemon.png
   │  │  │  └─ SqueezeLemon.png.meta
   │  │  ├─ cursors.meta
   │  │  ├─ cursors
   │  │  │  ├─ brush-m.png
   │  │  │  ├─ brush-m.png.meta
   │  │  │  ├─ brush-s.png
   │  │  │  ├─ brush-s.png.meta
   │  │  │  ├─ cursor default.png
   │  │  │  ├─ cursor default.png.meta
   │  │  │  ├─ cursor hand point.png
   │  │  │  ├─ cursor hand point.png.meta
   │  │  │  ├─ cursor.png
   │  │  │  ├─ cursor.png.meta
   │  │  │  ├─ drop.png
   │  │  │  ├─ drop.png.meta
   │  │  │  ├─ eraser.png
   │  │  │  ├─ eraser.png.meta
   │  │  │  ├─ paint brush.png
   │  │  │  ├─ paint brush.png.meta
   │  │  │  ├─ pencil.png
   │  │  │  └─ pencil.png.meta
   │  │  ├─ forwardAction.png
   │  │  ├─ forwardAction.png.meta
   │  │  ├─ sound off.png
   │  │  ├─ sound off.png.meta
   │  │  ├─ sound on.png
   │  │  ├─ sound on.png.meta
   │  │  ├─ white circle-pin.png
   │  │  └─ white circle-pin.png.meta
   │  ├─ TestSimulatedMouseClick.cs
   │  ├─ TestSimulatedMouseClick.cs.meta
   │  ├─ TextMesh Pro.meta
   │  ├─ TextMesh Pro
   │  │  ├─ Documentation.meta
   │  │  ├─ Documentation
   │  │  │  ├─ TextMesh Pro User Guide 2016.pdf
   │  │  │  └─ TextMesh Pro User Guide 2016.pdf.meta
   │  │  ├─ Fonts.meta
   │  │  ├─ Fonts
   │  │  │  ├─ LiberationSans - OFL.txt
   │  │  │  ├─ LiberationSans - OFL.txt.meta
   │  │  │  ├─ LiberationSans.ttf
   │  │  │  └─ LiberationSans.ttf.meta
   │  │  ├─ Resources.meta
   │  │  ├─ Resources
   │  │  │  ├─ Fonts & Materials.meta
   │  │  │  ├─ Fonts & Materials
   │  │  │  │  ├─ LiberationSans SDF - Drop Shadow.mat
   │  │  │  │  ├─ LiberationSans SDF - Drop Shadow.mat.meta
   │  │  │  │  ├─ LiberationSans SDF - Fallback.asset
   │  │  │  │  ├─ LiberationSans SDF - Fallback.asset.meta
   │  │  │  │  ├─ LiberationSans SDF - Outline.mat
   │  │  │  │  ├─ LiberationSans SDF - Outline.mat.meta
   │  │  │  │  ├─ LiberationSans SDF.asset
   │  │  │  │  └─ LiberationSans SDF.asset.meta
   │  │  │  ├─ LineBreaking Following Characters.txt
   │  │  │  ├─ LineBreaking Following Characters.txt.meta
   │  │  │  ├─ LineBreaking Leading Characters.txt
   │  │  │  ├─ LineBreaking Leading Characters.txt.meta
   │  │  │  ├─ Sprite Assets.meta
   │  │  │  ├─ Sprite Assets
   │  │  │  │  ├─ EmojiOne.asset
   │  │  │  │  └─ EmojiOne.asset.meta
   │  │  │  ├─ Style Sheets.meta
   │  │  │  ├─ Style Sheets
   │  │  │  │  ├─ Default Style Sheet.asset
   │  │  │  │  └─ Default Style Sheet.asset.meta
   │  │  │  ├─ TMP Settings.asset
   │  │  │  └─ TMP Settings.asset.meta
   │  │  ├─ Shaders.meta
   │  │  ├─ Shaders
   │  │  │  ├─ TMP_Bitmap-Custom-Atlas.shader
   │  │  │  ├─ TMP_Bitmap-Custom-Atlas.shader.meta
   │  │  │  ├─ TMP_Bitmap-Mobile.shader
   │  │  │  ├─ TMP_Bitmap-Mobile.shader.meta
   │  │  │  ├─ TMP_Bitmap.shader
   │  │  │  ├─ TMP_Bitmap.shader.meta
   │  │  │  ├─ TMP_SDF Overlay.shader
   │  │  │  ├─ TMP_SDF Overlay.shader.meta
   │  │  │  ├─ TMP_SDF SSD.shader
   │  │  │  ├─ TMP_SDF SSD.shader.meta
   │  │  │  ├─ TMP_SDF-Mobile Masking.shader
   │  │  │  ├─ TMP_SDF-Mobile Masking.shader.meta
   │  │  │  ├─ TMP_SDF-Mobile Overlay.shader
   │  │  │  ├─ TMP_SDF-Mobile Overlay.shader.meta
   │  │  │  ├─ TMP_SDF-Mobile SSD.shader
   │  │  │  ├─ TMP_SDF-Mobile SSD.shader.meta
   │  │  │  ├─ TMP_SDF-Mobile.shader
   │  │  │  ├─ TMP_SDF-Mobile.shader.meta
   │  │  │  ├─ TMP_SDF-Surface-Mobile.shader
   │  │  │  ├─ TMP_SDF-Surface-Mobile.shader.meta
   │  │  │  ├─ TMP_SDF-Surface.shader
   │  │  │  ├─ TMP_SDF-Surface.shader.meta
   │  │  │  ├─ TMP_SDF.shader
   │  │  │  ├─ TMP_SDF.shader.meta
   │  │  │  ├─ TMP_Sprite.shader
   │  │  │  ├─ TMP_Sprite.shader.meta
   │  │  │  ├─ TMPro.cginc
   │  │  │  ├─ TMPro.cginc.meta
   │  │  │  ├─ TMPro_Mobile.cginc
   │  │  │  ├─ TMPro_Mobile.cginc.meta
   │  │  │  ├─ TMPro_Properties.cginc
   │  │  │  ├─ TMPro_Properties.cginc.meta
   │  │  │  ├─ TMPro_Surface.cginc
   │  │  │  └─ TMPro_Surface.cginc.meta
   │  │  ├─ Sprites.meta
   │  │  └─ Sprites
   │  │     ├─ EmojiOne Attribution.txt
   │  │     ├─ EmojiOne Attribution.txt.meta
   │  │     ├─ EmojiOne.json
   │  │     ├─ EmojiOne.json.meta
   │  │     ├─ EmojiOne.png
   │  │     └─ EmojiOne.png.meta
   │  ├─ VirtualCursor.cs
   │  └─ VirtualCursor.cs.meta
   ├─ Packages
   │  ├─ System.IO.Ports.7.0.0
   │  │  ├─ .signature.p7s
   │  │  ├─ Icon.png
   │  │  ├─ LICENSE.TXT
   │  │  ├─ System.IO.Ports.7.0.0.nupkg
   │  │  ├─ THIRD-PARTY-NOTICES.TXT
   │  │  ├─ buildTransitive
   │  │  │  ├─ net461
   │  │  │  │  └─ System.IO.Ports.targets
   │  │  │  ├─ net462
   │  │  │  │  └─ _._
   │  │  │  ├─ net6.0
   │  │  │  │  └─ _._
   │  │  │  └─ netcoreapp2.0
   │  │  │     └─ System.IO.Ports.targets
   │  │  ├─ lib
   │  │  │  ├─ net462
   │  │  │  │  ├─ System.IO.Ports.dll
   │  │  │  │  └─ System.IO.Ports.xml
   │  │  │  ├─ net6.0
   │  │  │  │  ├─ System.IO.Ports.dll
   │  │  │  │  └─ System.IO.Ports.xml
   │  │  │  ├─ net7.0
   │  │  │  │  ├─ System.IO.Ports.dll
   │  │  │  │  └─ System.IO.Ports.xml
   │  │  │  └─ netstandard2.0
   │  │  │     ├─ System.IO.Ports.dll
   │  │  │     └─ System.IO.Ports.xml
   │  │  ├─ runtimes
   │  │  │  ├─ unix
   │  │  │  │  └─ lib
   │  │  │  │     ├─ net6.0
   │  │  │  │     │  ├─ System.IO.Ports.dll
   │  │  │  │     │  └─ System.IO.Ports.xml
   │  │  │  │     └─ net7.0
   │  │  │  │        ├─ System.IO.Ports.dll
   │  │  │  │        └─ System.IO.Ports.xml
   │  │  │  └─ win
   │  │  │     └─ lib
   │  │  │        ├─ net6.0
   │  │  │        │  ├─ System.IO.Ports.dll
   │  │  │        │  └─ System.IO.Ports.xml
   │  │  │        └─ net7.0
   │  │  │           ├─ System.IO.Ports.dll
   │  │  │           └─ System.IO.Ports.xml
   │  │  └─ useSharedDesignerContext.txt
   │  ├─ manifest.json
   │  └─ packages-lock.json
   ├─ ProjectSettings
   │  ├─ AudioManager.asset
   │  ├─ ClusterInputManager.asset
   │  ├─ DynamicsManager.asset
   │  ├─ EditorBuildSettings.asset
   │  ├─ EditorSettings.asset
   │  ├─ GraphicsSettings.asset
   │  ├─ InputManager.asset
   │  ├─ MemorySettings.asset
   │  ├─ NavMeshAreas.asset
   │  ├─ NavMeshLayers.asset
   │  ├─ NetworkManager.asset
   │  ├─ PackageManagerSettings.asset
   │  ├─ Physics2DSettings.asset
   │  ├─ PresetManager.asset
   │  ├─ ProjectSettings.asset
   │  ├─ ProjectVersion.txt
   │  ├─ QualitySettings.asset
   │  ├─ SceneTemplateSettings.json
   │  ├─ TagManager.asset
   │  ├─ TimeManager.asset
   │  ├─ UnityConnectSettings.asset
   │  ├─ VFXManager.asset
   │  ├─ VersionControlSettings.asset
   │  ├─ XRSettings.asset
   │  └─ boot.config
   ├─ README.md
   ├─ app.config
   ├─ extOSC
   │  └─ logs.xml
   └─ packages.config


<h2 id="folder-structure"> Folder Structure</h2>

## 🎯 Getting Started
To get started with the HCARD Augmentation project, follow these steps:

Clone the repository to your local machine.
Install the necessary dependencies by running pip install -r requirements.txt.
Run the application by executing the python file in your terminal.

## Future Work

## Contributing

We welcome contributions from anyone interested in the HCARD Augmentation project. If you'd like to contribute, please fork the repository and create a pull request with your changes. Before submitting a pull request, please ensure that your changes are well-tested and conform to the project's code style and standards.

## Acknowledgements

We would like to express our sincere gratitude to Professor Etienne Burdet, our course instructor, and our Teaching Assistants, Dr Yanpei Huang, Lucille Cazenave, and Alexis Devillard, for their invaluable guidance, encouragement, and feedback throughout the development of this project. We would also like to extend our thanks to Paschal Egan for his support in Electronics Laboratory.

We are grateful to the Imperial College London BioEngineering department for their continued support of the HCARD program. 
