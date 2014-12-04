using UnityEngine;
using System.Collections;

public abstract class TweenVec1P<T> : TweenVec1T<T>
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