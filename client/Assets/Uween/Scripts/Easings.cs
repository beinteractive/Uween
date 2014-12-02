using UnityEngine;
using System.Collections;

public abstract class Easings
{
    /// <summary>
    /// Calculate Robert Penner's easing.
    /// </summary>
    /// <param name="t">Time.</param>
    /// <param name="b">Beginning value.</param>
    /// <param name="c">Value delta.</param>
    /// <param name="d">Duration.</param>
    public abstract float Calculate(float t, float b, float c, float d);
}

public static class Linear
{
    public static readonly Easings EaseNone = new LinearEaseNone();
}
public static class Sine
{
    public static readonly Easings EaseIn = new SineEaseIn();
    public static readonly Easings EaseInOut = new SineEaseInOut();
    public static readonly Easings EaseOut = new SineEaseOut();
    public static readonly Easings EaseOutIn = new SineEaseOutIn();

    public static T EaseInSine<T>(this T tween) where T : Tween
    {
        tween.Easing = EaseIn;
        return tween;
    }
    public static T EaseInOutSine<T>(this T tween) where T : Tween
    {
        tween.Easing = EaseInOut;
        return tween;
    }
    public static T EaseOutSine<T>(this T tween) where T : Tween
    {
        tween.Easing = EaseOut;
        return tween;
    }
    public static T EaseOutInSine<T>(this T tween) where T : Tween
    {
        tween.Easing = EaseOutIn;
        return tween;
    }
}

public class LinearEaseNone : Easings
{
    override public float Calculate(float t, float b, float c, float d)
    {
        return c * t / d + b;
    }
}

public class SineEaseIn : Easings
{
    override public float Calculate(float t, float b, float c, float d)
    {
        return -c * Mathf.Cos(t / d * (Mathf.PI / 2f)) + c + b;
    }
}
public class SineEaseInOut : Easings
{
    override public float Calculate(float t, float b, float c, float d)
    {
        return -c / 2f * (Mathf.Cos(Mathf.PI * t / d) - 1f) + b;
    }
}
public class SineEaseOut : Easings
{
    override public float Calculate(float t, float b, float c, float d)
    {
        return c * Mathf.Sin(t / d * (Mathf.PI / 2f)) + b;
    }
}
public class SineEaseOutIn : Easings
{
    override public float Calculate(float t, float b, float c, float d)
    {
        if (t < d / 2f) {
            return (c / 2f) * Mathf.Sin((t * 2f) / d * (Mathf.PI / 2f)) + b;
        }
        return -(c / 2f) * Mathf.Cos((t * 2f - d) / d * (Mathf.PI / 2f)) + (c / 2f) + (b + c / 2f);
    }
}
