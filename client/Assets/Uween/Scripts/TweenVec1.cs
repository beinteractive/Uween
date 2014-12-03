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
