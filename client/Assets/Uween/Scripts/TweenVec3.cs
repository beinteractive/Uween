using UnityEngine;
using System.Collections;

public abstract class TweenVec3<T> : Tween
{
    protected static G Add<G>(GameObject g, float duration, Vector3 to) where G : TweenVec3<G>
    {
        var t = Tween.Get<G>(g, duration);
        t.to = to;
        return t;
    }
    
    protected static G Add<G>(GameObject g, float duration, float x, float y, float z) where G : TweenVec3<G>
    {
        return Add<G>(g, duration, new Vector3(x, y, z));
    }
    
    public Vector3 from;
    public Vector3 to;
    
    public abstract Vector3 value { get; set; }
    
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
    
    public T From(Vector3 v)
    {
        from = v;
        value = v;
        return (T)(object)this;
    }
    
    public T From(float x, float y, float z)
    {
        return From(new Vector3(x, y, z));
    }
    
    public T From(float v)
    {
        return From(v, v, v);
    }
    
    public T FromBy(Vector3 v)
    {
        from = value + v;
        return (T)(object)this;
    }
    
    public T FromBy(float x, float y, float z)
    {
        return FromBy(new Vector3(x, y, z));
    }
    
    public T FromBy(float v)
    {
        return FromBy(v, v, v);
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
