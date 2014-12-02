using UnityEngine;
using System.Collections;

public abstract class TweenVec1P : TweenVec1
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