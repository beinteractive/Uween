using UnityEngine;
using System.Collections;

public abstract class TweenVec2 : Tween
{
    public static T Add<T>(GameObject g, float duration, Vector2 to) where T : TweenVec2
    {
        var t = Tween.Get<T>(g, duration);
        t.to = to;
        return t;
    }
    
    protected static G Add<G>(GameObject g, float duration, float v1, float v2) where G : TweenVec2
    {
        return Add<G>(g, duration, new Vector2(v1, v2));
    }
    
    public Vector2 from;
    public Vector2 to;
    
    public abstract Vector2 value { get; set; }
    
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
    
    public TweenVec2 By()
    {
        to += value;
        return this;
    }
    
    public TweenVec2 From(Vector2 v)
    {
        from = v;
        value = v;
        return this;
    }

    public TweenVec2 From(float v1, float v2)
    {
        return From(new Vector2(v1, v2));
    }

    public TweenVec2 From(float v)
    {
        return From(v, v);
    }
    
    public TweenVec2 FromBy(Vector2 v)
    {
        from = value + v;
        return this;
    }
    
    public TweenVec2 FromBy(float v1, float v2)
    {
        return FromBy(new Vector2(v1, v2));
    }
    
    public TweenVec2 FromBy(float v)
    {
        return FromBy(v, v);
    }

    public TweenVec2 FromThat()
    {
        from = to;
        to = value;
        return this;
    }
    
    public TweenVec2 FromThatBy()
    {
        from = value + to;
        to = value;
        return this;
    }
}
