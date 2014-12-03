using UnityEngine;
using System.Collections;

public abstract class TweenVec1 : TweenVec<float>
{
    protected static T Add<T>(GameObject g, float duration, float to) where T : TweenVec1
    {
        return Add<T, float>(g, duration, to);
    }

    override protected void UpdateValue(float f)
    {
        value = from + (to - from) * f;
    }
}

public static class TweenVec1Extensions
{
    public static T FromThat<T>(this T tween) where T : TweenVec1
    {
        return tween.FromThat<T, float>();
    }
}