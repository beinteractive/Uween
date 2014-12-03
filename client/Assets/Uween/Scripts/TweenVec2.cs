using UnityEngine;
using System.Collections;

public abstract class TweenVec2 : TweenVec<Vector2>
{
    protected static T Add<T>(GameObject g, float duration, Vector2 to) where T : TweenVec2
    {
        return Add<T, Vector2>(g, duration, to);
    }

    protected static T Add<T>(GameObject g, float duration, float v1, float v2) where T : TweenVec2
    {
        return Add<T>(g, duration, new Vector2(v1, v2));
    }
    
    override protected void UpdateValue(float f)
    {
        value = from + (to - from) * f;
    }
}

public static class TweenVec2Extensions
{
    public static T By<T>(this T tween) where T : TweenVec2
    {
        tween.to += tween.value;
        return tween;
    }
    
    public static T FromThat<T>(this T tween) where T : TweenVec2
    {
        return tween.FromThat<T, Vector2>();
    }
    
    public static T FromThatBy<T>(this T tween) where T : TweenVec2
    {
        tween.from = tween.value + tween.to;
        tween.to = tween.value;
        return tween;
    }
}