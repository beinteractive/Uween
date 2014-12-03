using UnityEngine;
using System.Collections;

public abstract class TweenVec2R : TweenVec2
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