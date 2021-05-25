using UnityEngine;

namespace Uween
{
    public class TweenZ : TweenVec1P
    {
        public static TweenZ Add(GameObject g, float duration)
        {
            return Add<TweenZ>(g, duration);
        }

        public static TweenZ Add(GameObject g, float duration, float to)
        {
            return Add<TweenZ>(g, duration, to);
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