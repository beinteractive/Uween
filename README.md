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

### Fluent syntax

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

If you don't use uGUI (requires Unity >= 4.6), delete the following files:

 - `Uween/Scripts/TweenA.cs`
 - `Uween/Scripts/TweenC.cs`
 - `Uween/Scripts/TweenCA.cs`
 - `Uween/Scripts/TweenFillAmount.cs`

## Examples

Open a `Uween - Example/Scenes/Example.unity` scene.
All code is written in `Uween - Example/Scripts/Example.cs`.

* This example uses uGUI so you requires Unity version >= 4.6.

## Quick help

### Import

Add `using Uween;` in your script.

```C#
using UnityEngine;
using System.Collections;
using Uween;
```

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
  - `TweenYZ.Add(g, d, Vector2 yz)` - Move YZ to value `yz`.
  - `TweenYZ.Add(g, d, float y, float z)` - Move YZ to values `y` and `z`.
 - Scale 2 values
  - `TweenSXY.Add(g, d, Vector2 xy)` - Scale XY to value `xy`.
  - `TweenSXY.Add(g, d, float x, float y)` - Scale XY to values `x` and `y`.
  - `TweenSXY.Add(g, d, float v)` - Scale XY to value `v`.
  - `TweenSXZ.Add(g, d, Vector2 xz)` - Scale XZ to value `xz`.
  - `TweenSXZ.Add(g, d, float v)` - Scale XZ to value `v`.
  - `TweenSXZ.Add(g, d, float x, float z)` - Scale XZ to values `x` and `z`.
  - `TweenSYZ.Add(g, d, Vector2 yz)` - Scale YZ to value `yz`.
  - `TweenSYZ.Add(g, d, float y, float z)` - Scale XY to values `y` and `z`.
  - `TweenSYZ.Add(g, d, float v)` - Scale YZ to value `v`.
 - Rotate 2 values
  - `TweenRXY.Add(g, d, Vector2 xy)` - Rotate XY to value `xy`.
  - `TweenRXY.Add(g, d, float x, float y)` - Rotate XY to values `x` and `y`.
  - `TweenRXY.Add(g, d, float v)` - Rotate XY to value `v`.
  - `TweenRXZ.Add(g, d, Vector2 xz)` - Rotate XZ to value `xz`.
  - `TweenRXZ.Add(g, d, float v)` - Rotate XZ to value `v`.
  - `TweenRXZ.Add(g, d, float x, float z)` - Rotate XZ to values `x` and `z`.
  - `TweenRYZ.Add(g, d, Vector2 yz)` - Rotate YZ to value `yz`.
  - `TweenRYZ.Add(g, d, float y, float z)` - Rotate YZ to values `y` and `z`.
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
  - `TweenP` - Same as `TweenXY`.
  - `TweenS` - Same as `TweenSXY`.
  - `TweenR` - Same as `TweenRZ`.
 - Alias for 3D
  - `TweenP3` - Same as `TweenXYZ`.
  - `TweenS3` - Same as `TweenSXYZ`.
  - `TweenR3` - Same as `TweenRXYZ`.
 - uGUI
  - `TweenA.Add(g, d, float a)` - Change Alpha to value `a`.
  - `TweenC.Add(g, d, Color c)` - Change Color to value `c` (Alpha is ignored).
  - `TweenC.Add(g, d, Vector3 c)` - Change Color to value `c`.
  - `TweenC.Add(g, d, float r, float g, float b)` - Change Color to value `r`, `g` and `b`.
  - `TweenCA.Add(g, d, Color c)` - Change Color to value `c` (Alpha is not ignored).
  - `TweenCA.Add(g, d, Vector4 c)` - Change Color to value `c`.
  - `TweenCA.Add(g, d, float r, float g, float b, float a)` - Change Color to value `r`, `g`, `b` and `a`.
  - `TweenFillAmount.Add(g, d, float to)` - Change `Image#fillAmount` to value `to`.

Note: `g` is GameObject, `d` is duration.

### Fluent syntax

All the following feature can be called with fluent syntax.
(Fluent syntax is also known as method chain)

Like:

```C#
TweenX.Add(gameObject, 1f, 100f).EaseInOutSine().Delay(0.5f).Then(next_motion);
```

### Easings

You can use all of Robert Penner's easings:

 - Linear
  - It's default.
 - Back
  - `.EaseInBack()`
  - `.EaseInOutBack()`
  - `.EaseOutBack()`
  - `.EaseOutInBack()`
  - `.EaseInBackWith(float s)` - With the amount of overshoot `s`.
  - `.EaseInOutBackWith(float s)` - With the amount of overshoot `s`.
  - `.EaseOutBackWith(float s)` - With the amount of overshoot `s`.
  - `.EaseOutInBackWith(float s)` - With the amount of overshoot `s`.
 - Bounce
  - `.EaseInBounce()`
  - `.EaseInOutBounce()`
  - `.EaseOutBounce()`
  - `.EaseOutInBounce()`
 - Circular
  - `.EaseInCircular()`
  - `.EaseInOutCircular()`
  - `.EaseOutCircular()`
  - `.EaseOutInCircular()`
  - `.EaseInCirc()` - Alias
  - `.EaseInOutCirc()` - Alias
  - `.EaseOutCirc()` - Alias
  - `.EaseOutInCirc()` - Alias
 - Cubic
  - `.EaseInCubic()`
  - `.EaseInOutCubic()`
  - `.EaseOutCubic()`
  - `.EaseOutInCubic()`
 - Elastic
  - `.EaseInElastic()`
  - `.EaseInOutElastic()`
  - `.EaseOutElastic()`
  - `.EaseOutInElastic()`
  - `.EaseInElasticWith(float a, float p)` - With the the amplitude `a` of the sine wave and the period `p` of the sine wave.
  - `.EaseInOutElasticWith(float a, float p)` - With the the amplitude `a` of the sine wave and the period `p` of the sine wave.
  - `.EaseOutElasticWith(float a, float p)` - With the the amplitude `a` of the sine wave and the period `p` of the sine wave.
  - `.EaseOutInElasticWith(float a, float p)` - With the the amplitude `a` of the sine wave and the period `p` of the sine wave.
 - Exponential
  - `.EaseInExponential()`
  - `.EaseInOutExponential()`
  - `.EaseOutExponential()`
  - `.EaseOutInExponential()`
  - `.EaseInExpo()` - Alias
  - `.EaseInOutExpo()` - Alias
  - `.EaseOutExpo()` - Alias
  - `.EaseOutInExpo()` - Alias
 - Quadratic
  - `.EaseInQuadratic()`
  - `.EaseInOutQuadratic()`
  - `.EaseOutQuadratic()`
  - `.EaseOutInQuadratic()`
  - `.EaseInQuad()` - Alias
  - `.EaseInOutQuad()` - Alias
  - `.EaseOutQuad()` - Alias
  - `.EaseOutInQuad()` - Alias
 - Quartic
  - `.EaseInQuartic()`
  - `.EaseInOutQuartic()`
  - `.EaseOutQuartic()`
  - `.EaseOutInQuartic()`
  - `.EaseInQuart()` - Alias
  - `.EaseInOutQuart()` - Alias
  - `.EaseOutQuart()` - Alias
  - `.EaseOutInQuart()` - Alias
 - Quintic
  - `.EaseInQuintic()`
  - `.EaseInOutQuintic()`
  - `.EaseOutQuintic()`
  - `.EaseOutInQuintic()`
  - `.EaseInQuint()` - Alias
  - `.EaseInOutQuint()` - Alias
  - `.EaseOutQuint()` - Alias
  - `.EaseOutInQuint()` - Alias
 - Sine
  - `.EaseInSine()`
  - `.EaseInOutSine()`
  - `.EaseOutSine()`
  - `.EaseOutInSine()`

### Delay

You can insert a delay time before starting tween.

 - `.Delay(float)` - Set a delay time (sec).

### Callback

You can set to call method you like when tween completed.

 - `.Then(f)` - Set a complete callback. `f` is a no arg void method.

### Initial value

You can set a initial value. It will be apply immediately to GameObject (before delay).

 - `.From(v)` - Set a initial value to `v`.

### Relative value

You can set a destination or initial value relative from current value.

 - `.Relative()` - Set a destination value to a value relative from current value
 - `.FromRelative(v)` - Set a initial value to current value + `v`

### To current value

If you don't set a destination value, it will automatically set as a current value.

```C#
// From 100px to current position
TweenX.Add(gameObject, 1f).From(100f);
```

### Pause/Resume

You can pause/resume active tweens in a GameObject.

 - `g.PauseTweens()` - Pause active tweens in `g`.
 - `g.PauseTweens<T>()` - Pause active tweens of type `T` in `g`.
 - `g.ResumeTweens()` - Resume paused tweens in `g`.
 - `g.ResumeTweens<T>()` - Resume paused tweens of type `T` in `g`.

### TweenNull

TweenNull will not tween any value. You can use this class for wait, delayed callback, etc...

```C#
// Callback after 3sec.
TweenNull(g, 3f).Then(callback)
```

## License

Copyright 2014 Oink Games, Inc. and other contributors.

Code licensed under the MIT License: http://opensource.org/licenses/MIT
