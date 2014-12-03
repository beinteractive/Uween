using UnityEngine;
using System.Collections;

public abstract class TweenVec1S : TweenVec1
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