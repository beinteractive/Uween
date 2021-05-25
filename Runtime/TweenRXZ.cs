using UnityEngine;

namespace Uween
{
    public class TweenRXZ : TweenVec2R
    {
        public static TweenRXZ Add(GameObject g, float duration)
        {
            return Add<TweenRXZ>(g, duration);
        }

        public static TweenRXZ Add(GameObject g, float duration, Vector2 to)
        {
            return Add<TweenRXZ>(g, duration, to);
        }

        public static TweenRXZ Add(GameObject g, float duration, float toRX, float toRZ)
        {
            return Add<TweenRXZ>(g, duration, toRX, toRZ);
        }

        public static TweenRXZ Add(GameObject g, float duration, float toRXZ)
        {
            return Add(g, duration, toRXZ, toRXZ);
        }

        protected override Vector2 Value
        {
            get { return new Vector2(Vector.x, Vector.z); }
            set
            {
                var v = Vector;
                v.x = value.x;
                v.z = value.y;
                Vector = v;
            }
        }
    }
}