using UnityEngine;

namespace Uween
{
    public class TweenSXZ : TweenVec2S
    {
        public static TweenSXZ Add(GameObject g, float duration)
        {
            return Add<TweenSXZ>(g, duration);
        }

        public static TweenSXZ Add(GameObject g, float duration, Vector2 to)
        {
            return Add<TweenSXZ>(g, duration, to);
        }

        public static TweenSXZ Add(GameObject g, float duration, float toSX, float toSZ)
        {
            return Add<TweenSXZ>(g, duration, toSX, toSZ);
        }

        public static TweenSXZ Add(GameObject g, float duration, float toSXZ)
        {
            return Add(g, duration, toSXZ, toSXZ);
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