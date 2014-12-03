using UnityEngine;
using System.Collections;

public abstract class TweenVec<V> : Tween
{
    protected static T Add<T, TV>(GameObject g, float duration, TV to) where T : TweenVec<TV>
    {
        var t = Tween.Get<T>(g, duration);
        t.to = to;
        return t;
    }
    
    public V from;
    public V to;
    
    public abstract Vector3 vector { get; set; }
    public abstract V value { get; set; }
    
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
}

public static class TweenVecExtensions
{
    public static T From<T, V>(this T tween, V from) where T : TweenVec<V>
    {
        tween.from = from;
        tween.value = from;
        return tween;
    }

    public static T FromThat<T, V>(this T tween) where T : TweenVec<V>
    {
        tween.from = tween.to;
        tween.to = tween.value;
        return tween;
    }
}