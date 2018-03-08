using UnityEngine;

namespace Uween
{
    public abstract class TweenVec3T : TweenVec3
    {
        protected abstract Vector3 Vector { get; set; }

        protected override Vector3 Value
        {
            get { return Vector; }
            set { Vector = value; }
        }

        private Transform T;

        protected Transform GetTransform()
        {
            if (T == null)
            {
                T = transform;
            }

            return T;
        }
    }

    public abstract class TweenVec3P : TweenVec3T
    {
        protected override Vector3 Vector
        {
            get { return GetTransform().localPosition; }
            set { GetTransform().localPosition = value; }
        }
    }

    public abstract class TweenVec3R : TweenVec3T
    {
        protected override Vector3 Vector
        {
            get { return GetTransform().localRotation.eulerAngles; }
            set { GetTransform().localRotation = Quaternion.Euler(value); }
        }
    }

    public abstract class TweenVec3S : TweenVec3T
    {
        protected override Vector3 Vector
        {
            get { return GetTransform().localScale; }
            set { GetTransform().localScale = value; }
        }
    }
}