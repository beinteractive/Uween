using UnityEngine;

namespace Uween
{
    public class TweenYZ : TweenVec2P
    {
        public static TweenYZ Add(GameObject g, float duration)
        {
            return Add<TweenYZ>(g, duration);
        }

        public static TweenYZ Add(GameObject g, float duration, Vector2 to)
        {
            return Add<TweenYZ>(g, duration, to);
        }

        public static TweenYZ Add(GameObject g, float duration, float toY, float toZ)
        {
            return Add<TweenYZ>(g, duration, toY, toZ);
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