using UnityEngine;
using System.Collections;

public abstract class TweenVec2P<T> : TweenVec2T<T>
{
    override public Vector3 vector
    {
        get
        {
            return GetTransform().localPosition;
        }
        set
        {
            GetTransform().localPosition = value;
        }
    }
}