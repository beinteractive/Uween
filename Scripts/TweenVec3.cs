using UnityEngine;

namespace Uween
{

public abstract class TweenVec3 : Tween
{
    public static T Add<T>(GameObject g, float duration, Vector3 to) where T : TweenVec3
    {
        var t = Tween.Get<T>(g, duration);
        t.to = to;
        return t;
    }
    
    protected static G Add<G>(GameObject g, float duration, float x, float y, float z) where G : TweenVec3
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
    
    public TweenVec3 By()
    {
        to += value;
        return this;
    }
    
    public TweenVec3 From(Vector3 v)
    {
        from = v;
        value = v;
        return this;
    }
    
    public TweenVec3 From(float x, float y, float z)
    {
        return From(new Vector3(x, y, z));
    }
    
    public TweenVec3 From(float v)
    {
        return From(v, v, v);
    }
    
    public TweenVec3 FromBy(Vector3 v)
    {
        from = value + v;
        value = from;
        return this;
    }
    
    public TweenVec3 FromBy(float x, float y, float z)
    {
        return FromBy(new Vector3(x, y, z));
    }
    
    public TweenVec3 FromBy(float v)
    {
        return FromBy(v, v, v);
    }

    public TweenVec3 FromThat()
    {
        from = to;
        to = value;
        return this;
    }
    
    public TweenVec3 FromThatBy()
    {
        from = value + to;
        to = value;
        return this;
    }
}

}
