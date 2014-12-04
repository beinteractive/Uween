using UnityEngine;
using System.Collections;

public abstract class TweenVec1<T> : Tween
{
    protected static G Add<G>(GameObject g, float duration, float to) where G : TweenVec1<G>
    {
        var t = Tween.Get<G>(g, duration);
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

    public T By()
    {
        to += value;
        return (T)(object)this;
    }

    public T From(float v)
    {
        from = v;
        value = v;
        return (T)(object)this;
    }
    
    public T FromBy(float v)
    {
        from = value + v;
        return (T)(object)this;
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
