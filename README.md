# Ultra Lightweight Tweening Engine for Unity (Uween)

Uween is a simple tween library for Unity.

## Features

### Simple & Lightweight

Uween is super simple. Core system (`Tween.cs`) is about 100 lines code. Simple is powerful.

### Easy to use

```C#
// Go to x:100 in 1 second.
TweenX.Add(gameObject, 1f, 100f);
```

That's all.

### Fluent sytanx

```C#
// Go to x:100 in 1 second with in-out-sine easing and 5 sec delay.
// Then do a next motion.
TweenX.Add(gameObject, 1f, 100f).EaseInOutSine().Delay(0.5f).Then(next_motion);
```

### Unity friendly

Uween's design is completely focusing on Unity.
It works as a simple Unity component and follows a Unity execution flow.

## Setup

Simply copy a `Uween` directory to your Unity project.
`Uween - Example` directory is not needed.

## Examples

Open a `Uween - Example/Scenes/Example.unity` scene.
All code is written in `Uween - Example/Scripts/Example.cs`.

* This example uses uGUI so you requires Unity version >= 4.6.

## Quick help

### Starting tween

Call a tween class's `Add` method.

```C#
TweenX.Add(g, 0.3f, 120f);
TweenY.Add(g, 0.5f, 240f);
```

At least `Add` method has two parameters:

 1. GameObject - Tweening target.
 1. float - Tweening duration (sec).

and has more extra parameters depending on tween classes.
For example, TweenX has a destination x value as 3rd parameter.

### Tween classes

 - Move 1 value
  - `TweenX.Add(g, d, float x)` - Move X to value `x`.
  - `TweenY.Add(g, d, float y)` - Move Y to value `y`.
  - `TweenZ.Add(g, d, float z)` - Move Z to value `z`.
 - Scale 1 value
  - `TweenSX.Add(g, d, float sx)` - Scale X to value `sx`.
  - `TweenSY.Add(g, d, float sy)` - Scale Y to value `sy`.
  - `TweenSZ.Add(g, d, float sz)` - Scale Z to value `sz`.
 - Rotate 1 value
  - `TweenRX.Add(g, d, float rx)` - Rotate X to value `rx`. `rx` is a euler angle.
  - `TweenRY.Add(g, d, float ry)` - Rotate Y to value `ry`. `ry` is a euler angle.
  - `TweenRZ.Add(g, d, float rz)` - Rotate Z to value `rz`. `rz` is a euler angle.
 - Move 2 values
  - `TweenXY.Add(g, d, Vector2 xy)` - Move XY to value `xy`.
  - `TweenXY.Add(g, d, float x, float y)` - Move XY to values `x` and `y`.
  - `TweenXZ.Add(g, d, Vector2 xz)` - Move XZ to value `xz`.
  - `TweenXZ.Add(g, d, float x, float z)` - Move XZ to values `x` and `z`.
  - `TweenYZ.Add(g, d, Vector2 yz)` - Move XY to value `yz`.
  - `TweenYZ.Add(g, d, float y, float z)` - Move XY to values `y` and `z`.
 - Scale 2 values
  - `TweenSXY.Add(g, d, Vector2 xy)` - Scale XY to value `xy`.
  - `TweenSXY.Add(g, d, float x, float y)` - Scale XY to values `x` and `y`.
  - `TweenSXY.Add(g, d, float v)` - Scale XY to value `v`.
  - `TweenSXZ.Add(g, d, Vector2 xz)` - Scale XZ to value `xz`.
  - `TweenSXZ.Add(g, d, float v)` - Scale XZ to value `v`.
  - `TweenSXZ.Add(g, d, float x, float z)` - Scale XZ to values `x` and `z`.
  - `TweenSYZ.Add(g, d, Vector2 yz)` - Scale XY to value `yz`.
  - `TweenSYZ.Add(g, d, float y, float z)` - Scale XY to values `y` and `z`.
  - `TweenSYZ.Add(g, d, float v)` - Scale YZ to value `v`.
 - Rotate 2 values
  - `TweenRXY.Add(g, d, Vector2 xy)` - Rotate XY to value `xy`.
  - `TweenRXY.Add(g, d, float x, float y)` - Rotate XY to values `x` and `y`.
  - `TweenRXY.Add(g, d, float v)` - Rotate XY to value `v`.
  - `TweenRXZ.Add(g, d, Vector2 xz)` - Rotate XZ to value `xz`.
  - `TweenRXZ.Add(g, d, float v)` - Rotate XZ to value `v`.
  - `TweenRXZ.Add(g, d, float x, float z)` - Rotate XZ to values `x` and `z`.
  - `TweenRYZ.Add(g, d, Vector2 yz)` - Rotate XY to value `yz`.
  - `TweenRYZ.Add(g, d, float y, float z)` - Rotate XY to values `y` and `z`.
  - `TweenRYZ.Add(g, d, float v)` - Rotate YZ to value `v`.
 - Move 3 values
  - `TweenXYZ.Add(g, d, Vector3 xyz)` - Move XYZ to value `xyz`.
  - `TweenXYZ.Add(g, d, float x, float y, float z)` - Move XYZ to values `x`, `y` and `z`.
 - Scale 3 values
  - `TweenSXYZ.Add(g, d, Vector2 xyz)` - Scale XYZ to value `xyz`.
  - `TweenSXYZ.Add(g, d, float x, float y, float z)` - Scale XYZ to values `x`, `y` and `z`.
  - `TweenSXYZ.Add(g, d, float v)` - Scale XYZ to value `v`.
 - Rotate 3 values
  - `TweenRXYZ.Add(g, d, Vector2 xyz)` - Rotate XYZ to value `xy`.
  - `TweenRXYZ.Add(g, d, float x, float y, float z)` - Rotate XYZ to values `x`, `y` and `z`.
  - `TweenRXYZ.Add(g, d, float v)` - Rotate XYZ to value `v`.
 - Alias for 2D
  - `TweenP.Add(g, d, Vector2 xy)` - Same as `TweenXY.Add(g, d, Vector2 xy)`.
  - `TweenP.Add(g, d, float x, float y)` - Same as `TweenXY.Add(g, d, float x, float y)`.
  - `TweenS.Add(g, d, Vector2 xy)` - Same as `TweenSXY.Add(g, d, Vector2 xy)`.
  - `TweenS.Add(g, d, float x, float y)` - Same as `TweenSXY.Add(g, d, float x, float y)`.
  - `TweenS.Add(g, d, float v)` - Same as `TweenSXY.Add(g, d, float v)`.
  - `TweenR.Add(g, d, float rz)` - Same as `TweenRZ.Add(g, d, float rz)`.
 - Alias for 3D
  - `TweenP3.Add(g, d, Vector3 xyz)` - Same as `TweenXYZ.Add(g, d, Vector3 xyz)`.
  - `TweenP3.Add(g, d, float x, float y, float z)` - Same as `TweenXYZ.Add(g, d, float x, float y, float z)`.
  - `TweenS3.Add(g, d, Vector2 xyz)` - Same as `TweenSXYZ.Add(g, d, Vector2 xyz)`.
  - `TweenS3.Add(g, d, float x, float y, float z)` - Same as `TweenSXYZ.Add(g, d, float x, float y, float z)`.
  - `TweenS3.Add(g, d, float v)` - Same as `TweenSXYZ.Add(g, d, float v)`.
  - `TweenR3.Add(g, d, Vector2 xyz)` - Same as `TweenRXYZ.Add(g, d, Vector2 xyz)`.
  - `TweenR3.Add(g, d, float x, float y, float z)` - Same as `TweenRXYZ.Add(g, d, float x, float y, float z)`.
  - `TweenR3.Add(g, d, float v)` - Same as `TweenRXYZ.Add(g, d, float v)`.

Note: `g` is GameObject, `d` is duration.

### Fluent sytanx

All the following feature can be called with fluent sytanx.
(Fluent sytanx is also known as method chain)

Like:

```C#
TweenX.Add(gameObject, 1f, 100f).EaseInOutSine().Delay(0.5f).Then(next_motion);
```

### Easings

You can use all of Robert Penner's easings:

todo

and also some special easings:

todo

### Delay

You can insert a delay time before starting tween.

 - `.Delay(float)` - Set a delay time (sec).

### Callback

You can set to call method you like when tween completed.

 - `.Then(f)` - Set a complete callback. `f` is a no arg void method.

### Initial value

You can set a initial value. It will be apply immediately to GameObject (before delay).

 - `.From(v)` - Set a initial value to `v`.
 - `.FromThat()` - Set a initial value to destination Value and destination value to current Value.

### Relative value

You can set a destination or initial value relative from current value.

 - `.By()` - Current Value -> Current Value + Destination Value
 - `.FromBy(v)` - Current Value + `v` -> Destination Value
 - `.FromThatBy()` - Current Value + Destination Value -> Current Value

ref. Normal tween is: Current Value -> Destination Value

### TweenNull

TweenNull will not tween any value. You can use this class for wait, delayed callback, etc...

```C#
// Callback after 3sec.
TweenNull(g, 3f).Then(callback)
```

## License

Copyright 2014 Oink Games, Inc. and other contributors.

Code licensed under the MIT License: http://opensource.org/licenses/MIT
