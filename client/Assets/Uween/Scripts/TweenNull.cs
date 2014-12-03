using UnityEngine;
using System.Collections;

public class TweenNull : Tween
{
    public static TweenNull Add(GameObject g, float duration)
    {
        return Get<TweenNull>(g, duration);
    }

    override protected void UpdateValue(float f)
    {
    }
}