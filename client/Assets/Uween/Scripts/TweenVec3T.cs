using UnityEngine;
using System.Collections;

public abstract class TweenVec3T<T> : TweenVec3<T>
{
    public abstract Vector3 vector { get; set; }
    
    override public Vector3 value
    {
        get
        {
            return vector;
        }
        set
        {
            vector = value;
        }
    }

    Transform t;
    
    protected Transform GetTransform()
    {
        if (t == null) {
            t = transform;
        }
        return t;
    }
}

public abstract class TweenVec3P<T> : TweenVec3T<T>
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

public abstract class TweenVec3R<T> : TweenVec3T<T>
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

public abstract class TweenVec3S<T> : TweenVec3T<T>
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