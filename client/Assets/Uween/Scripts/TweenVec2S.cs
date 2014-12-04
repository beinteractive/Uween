using UnityEngine;
using System.Collections;

public abstract class TweenVec2S<T> : TweenVec2T<T>
{
    override public Vector3 vector
    {
        get
        {
            return GetTransform().localScale;
        }
        set
        {
            GetTransform().localScale = value;
        }
    }
}