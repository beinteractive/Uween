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

todo

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

### Relative value

You can set a destination or initial value relative from current value.

 - `.By()` - Current Value -> Current Value + Destination Value
 - `.FromBy(v)` - Current Value + `v` -> Destination Value
 - `.FromThat()` - Destination Value -> Current Value
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
