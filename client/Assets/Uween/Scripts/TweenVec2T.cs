using UnityEngine;
using System.Collections;

public abstract class TweenVec2T<T> : TweenVec2<T>
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