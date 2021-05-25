using UnityEngine;

namespace Uween
{
    public abstract class TweenVec2T : TweenVec2
    {
        protected abstract Vector3 Vector { get; set; }

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

    public abstract class TweenVec2P : TweenVec2T
    {
        protected override Vector3 Vector
        {
            get { return GetTransform().localPosition; }
            set { GetTransform().localPosition = value; }
        }
    }

    public abstract class TweenVec2R : TweenVec2T
    {
        protected override Vector3 Vector
        {
            get { return GetTransform().localRotation.eulerAngles; }
            set { GetTransform().localRotation = Quaternion.Euler(value); }
        }
    }

    public abstract class TweenVec2S : TweenVec2T
    {
        protected override Vector3 Vector
        {
            get { return GetTransform().localScale; }
            set { GetTransform().localScale = value; }
        }
    }
}