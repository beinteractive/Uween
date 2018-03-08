using UnityEngine;

namespace Uween
{
    public class TweenRYZ : TweenVec2R
    {
        public static TweenRYZ Add(GameObject g, float duration)
        {
            return Add<TweenRYZ>(g, duration);
        }

        public static TweenRYZ Add(GameObject g, float duration, float toRY, float toRZ)
        {
            return Add<TweenRYZ>(g, duration, toRY, toRZ);
        }

        public static TweenRYZ Add(GameObject g, float duration, float toRYZ)
        {
            return Add(g, duration, toRYZ, toRYZ);
        }

        protected override Vector2 Value
        {
            get { return new Vector2(Vector.y, Vector.z); }
            set
            {
                var v = Vector;
                v.y = value.x;
                v.z = value.y;
                Vector = v;
            }
        }
    }
}