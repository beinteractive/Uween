using UnityEngine;

namespace Uween
{
    public class TweenRXY : TweenVec2R
    {
        public static TweenRXY Add(GameObject g, float duration)
        {
            return Add<TweenRXY>(g, duration);
        }

        public static TweenRXY Add(GameObject g, float duration, Vector2 to)
        {
            return Add<TweenRXY>(g, duration, to);
        }

        public static TweenRXY Add(GameObject g, float duration, float toRX, float toRY)
        {
            return Add<TweenRXY>(g, duration, toRX, toRY);
        }

        public static TweenRXY Add(GameObject g, float duration, float toRXY)
        {
            return Add(g, duration, toRXY, toRXY);
        }

        protected override Vector2 Value
        {
            get { return new Vector2(Vector.x, Vector.y); }
            set
            {
                var v = Vector;
                v.x = value.x;
                v.y = value.y;
                Vector = v;
            }
        }
    }
}