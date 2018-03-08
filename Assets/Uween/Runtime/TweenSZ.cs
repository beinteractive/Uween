using UnityEngine;

namespace Uween
{
    public class TweenSZ : TweenVec1S
    {
        public static TweenSZ Add(GameObject g, float duration)
        {
            return Add<TweenSZ>(g, duration);
        }

        public static TweenSZ Add(GameObject g, float duration, float to)
        {
            return Add<TweenSZ>(g, duration, to);
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