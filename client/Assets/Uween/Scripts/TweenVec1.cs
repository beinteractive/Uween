using UnityEngine;
using System.Collections;

public abstract class TweenVec1 : Tween
{
    protected static T Add<T>(GameObject g, float duration, float to) where T : TweenVec1
    {
        var t = Tween.Get<T>(g, duration);
        t.to = to;
        return t;
    }

    public float from;
    public float to;

    public abstract Vector3 vector { get; set; }
    public abstract float value { get; set; }

    Transform t;

    protected Transform GetTransform()
    {
        if (t == null) {
            t = transform;
        }
        return t;
    }
    
    override protected void Reset()
    {
        base.Reset();
        from = value;
        to = value;
    }
    
    override protected void UpdateValue(float f)
    {
        value = from + (to - from) * f;
    }
}

public static class TweenVec1Extensions
{
    public static T From<T>(this T tween, float from) where T : TweenVec1
    {
        tween.from = from;
        tween.value = from;
        return tween;
    }
}