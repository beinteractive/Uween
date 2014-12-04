using UnityEngine;
using System.Collections;

public abstract class TweenVec2<T> : Tween
{
    protected static G Add<G>(GameObject g, float duration, Vector2 to) where G : TweenVec2<G>
    {
        var t = Tween.Get<G>(g, duration);
        t.to = to;
        return t;
    }
    
    protected static G Add<G>(GameObject g, float duration, float v1, float v2) where G : TweenVec2<G>
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
    
    public T By()
    {
        to += value;
        return (T)(object)this;
    }
    
    public T From(Vector2 v)
    {
        from = v;
        value = v;
        return (T)(object)this;
    }

    public T From(float v1, float v2)
    {
        return From(new Vector2(v1, v2));
    }

    public T From(float v)
    {
        return From(v, v);
    }
    
    public T FromBy(Vector2 v)
    {
        from = value + v;
        return (T)(object)this;
    }
    
    public T FromBy(float v1, float v2)
    {
        return FromBy(new Vector2(v1, v2));
    }
    
    public T FromBy(float v)
    {
        return FromBy(v, v);
    }

    public T FromThat()
    {
        from = to;
        to = value;
        return (T)(object)this;
    }
    
    public T FromThatBy()
    {
        from = value + to;
        to = value;
        return (T)(object)this;
    }
}
