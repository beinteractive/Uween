using UnityEngine;

namespace Uween
{
    public class TweenRZ : TweenVec1R
    {
        public static TweenRZ Add(GameObject g, float duration)
        {
            return Add<TweenRZ>(g, duration);
        }

        public static TweenRZ Add(GameObject g, float duration, float to)
        {
            return Add<TweenRZ>(g, duration, to);
        }

        protected override float Value
        {
            get { return Vector.z; }
            set
            {
                var v = Vector;
                v.z = value;
                Vector = v;
            }
        }
    }
}