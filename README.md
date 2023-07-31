# AR_Arcade_Classics

## Introduction
The classic arcade game Snake originated in the 1976 arcade game Blocade. Many versions of it were made, including the 1978 computer game version called Worm, and many versions that were put on Nokia cell phones after 1997. The basic concept of the game is that a snake is maneuvered around the screen, getting longer as it eats food. 

Marker-based Augmented Reality (AR) technology uses fiducial markers and image recognition to trigger an AR experience. This technology is frequently used for mobile games, such as Pokémon GO, utilizing the mobile device’s camera to trigger an experience when a particular image is found. 

Our project's goal was to combine the game Snake with Marker-based AR to create a mobile AR version of the game. Our application allows the user to play the classic arcade game in an immersive manner. We utilized Unity and Unity's AR Foundation to create an application that is cross-platform compatible and allows users to play on a variety of devices. Additionally, we designed our application with scalability in mind. While we only implemented Snake for our Minimum Viable Product, the design allows us to easily add additional games in the future simply by adding AR markers to the Reference Image Library, and adding corresponding scenes for each additional game.

## About Our Project
Our project is a cross-platform iOS and Android application that allows users to play the classic arcade game Snake in Augmented Reality. In order to play the game, the user can scan an image using their device’s camera in order to launch the game, and then when the start button is pressed the game board spawns in the user’s space through the camera. On-screen arrow buttons are used to move the snake around the board to direct it towards food, and the user can pan the camera to get a better view of the three-dimensional board. Our app lets users play a favorite classic game in an immersive way that brings a new perspective to what Snake can be. Our application also allows the user to choose which side of the screen the game controls are on, using the Settings menu.

## Android Installation Guide
1. Clone Repository (e.g. `git clone https://github.com/orngepeel/AR_Arcade_Classics.git`).
2. Install [Unity Hub](https://unity.com/download) and skip installing any editors.
3. In Unity Hub, press “Open” in the upper right corner, and select the project directory that was cloned (“AR_Arcade_Classics”).
4. A popup window will appear. If it doesn’t, attempt to open the newly added project. Press “Install Version 2021.3.24f1”.
5. Select “Android Build Support” in the “Add modules” pane, and press “Continue”.
6. [Ensure your OS has the prerequisites.](https://docs.unity3d.com/Manual/android-sdksetup.html)
7. [Enable USB debugging on your Android device.](https://developer.android.com/studio/debug/dev-options)
8. Connect your Android device to the computer running Unity Editor with a cable that supports data transfer.
9. Open the project, and click File > Build Settings to open the Build Settings window.
10. In the Build Settings window, make sure the Platform is Android, and press “Build And Run”.

## Development Tools
- Game Engine: Unity
- Language: C#
- Framework: Unity AR Foundation

  AR Foundation is a framework that allows you to create multi-platform AR experiences with Unity. Simply choose which AR features you want to use and add the manager components for those features to the scene. When the app is built, AR Foundation uses the platform-specific SDK to enable those features. Since we were developing for Android and iOS, AR Foundation allowed us to implement the application once, and build to both platforms without any changes.
- Package: Google ARCore XR Plug-in for Unity

  This package is required for Unity AR Foundation to be able to build for Android. This package is officially supported by Unity.
- Package: Apple ARKit XR Plug-in for Unity 

  This package is required for Unity AR Foundation to be able to build for iOS. This package is officially supported by Unity.
- Repository Host: GitHub
- Development Tools: Unity Editor 2021.3 LTS
- Development Tools: Unity Build Automation
