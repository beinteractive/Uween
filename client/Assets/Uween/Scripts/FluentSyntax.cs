using UnityEngine;
using System.Collections;
using Uween;

public static class FluentSyntax
{
    public static T Delay<T>(this T tween, float delay) where T : Tween
    {
        tween.DelayTime = delay;
        return tween;
    }

    public static T Animate<T>(this T tween, bool animated) where T : Tween
    {
        if (!animated) {
            tween.Skip();
        }
        return tween;
    }

    public static T Then<T>(this T tween, Callback callback) where T : Tween
    {
        if (tween.enabled || !tween.IsComplete) {
            tween.OnComplete += callback;
        }
        else {
            callback();
        }
        return tween;
    }
}
