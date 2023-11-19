Unity Engine to Godot Engine exporter
=======================================

This is a tool designed to convert 2D projects from Unity to Godot, based on [Zylann's unity_to_godot_converter](https://github.com/Zylann/unity_to_godot_converter).

I have just made some modifications to:

1. Properly restore the position of sprites in the scene.
2. Recreate the same parallax effect achieved in Unity by considering the sprite's z-axis position, utilizing CanvasLayer (see [Exporter.cs](https://github.com/pilorenzo/unity_to_godot_converter/blob/master/Exporter/Exporter.cs)).

Tested on Godot 4.1.3 (only sprites and empty objects)


How to install
---------------

Copy this repository in your Unity project, inside a folder named `Editor`, and you should see a new `Godot` menu with options in it.

Although it should not modify anything in the project, it's up to you to preserve your data if anything wrong happens :p
