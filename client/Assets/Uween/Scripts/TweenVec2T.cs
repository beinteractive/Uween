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

public abstract class TweenVec2R<T> : TweenVec2T<T>
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