using UnityEngine;
using System.Collections;

public abstract class TweenVec1R<T> : TweenVec1T<T>
{
    override public Vector3 vector
    {
        get
        {
            return GetTransform().localRotation.eulerAngles;
        }
        set
        {
            GetTransform().localRotation = Quaternion.Euler(value);
        }
    }
}