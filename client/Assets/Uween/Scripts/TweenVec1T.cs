using UnityEngine;
using System.Collections;

public abstract class TweenVec1T<T> : TweenVec1<T>
{
    public abstract Vector3 vector { get; set; }
    
    Transform t;
    
    protected Transform GetTransform()
    {
        if (t == null) {
            t = transform;
        }
        return t;
    }
}