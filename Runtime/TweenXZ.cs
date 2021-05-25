using UnityEngine;

namespace Uween
{
    public class TweenXZ : TweenVec2P
    {
        public static TweenXZ Add(GameObject g, float duration)
        {
            return Add<TweenXZ>(g, duration);
        }

        public static TweenXZ Add(GameObject g, float duration, Vector2 to)
        {
            return Add<TweenXZ>(g, duration, to);
        }

        public static TweenXZ Add(GameObject g, float duration, float toX, float toZ)
        {
            return Add<TweenXZ>(g, duration, toX, toZ);
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