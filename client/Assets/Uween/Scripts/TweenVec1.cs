using UnityEngine;
using System.Collections;

public abstract class TweenVec1 : Tween
{
    public static T Add<T>(GameObject g, float duration, float to) where T : TweenVec1
    {
        var t = Tween.Get<T>(g, duration);
        t.to = to;
        return t;
    }
    
    public float from;
    public float to;
    
    public abstract float value { get; set; }

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

    public TweenVec1 By()
    {
        to += value;
        return this;
    }

    public TweenVec1 From(float v)
    {
        from = v;
        value = v;
        return this;
    }
    
    public TweenVec1 FromBy(float v)
    {
        from = value + v;
        return this;
    }
    
    public TweenVec1 FromThat()
    {
        from = to;
        to = value;
        return this;
    }
    
    public TweenVec1 FromThatBy()
    {
        from = value + to;
        to = value;
        return this;
    }
}
