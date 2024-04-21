# 🖥️ Command Console

Old school console application that will support static fields that don't scroll and animation.
The functionality will run commands

## Overview

* Heavily uses `Console.Write()` and `Console.MoveBufferArea()` methods to "draw" text to the console.

## TODO

* Create an animation loop for the console screen.
* Create "Fields" that have velocity and color
* Create cursor menus for "input"
* Create mock commands to take time
* Create loop to issue commands at a predefined rate
* Create a rate limiter for commands