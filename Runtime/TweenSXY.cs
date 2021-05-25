using UnityEngine;

namespace Uween
{
    public class TweenSXY : TweenVec2S
    {
        public static TweenSXY Add(GameObject g, float duration)
        {
            return Add<TweenSXY>(g, duration);
        }

        public static TweenSXY Add(GameObject g, float duration, Vector2 to)
        {
            return Add<TweenSXY>(g, duration, to);
        }

        public static TweenSXY Add(GameObject g, float duration, float toSX, float toSY)
        {
            return Add<TweenSXY>(g, duration, toSX, toSY);
        }

        public static TweenSXY Add(GameObject g, float duration, float toSXY)
        {
            return Add(g, duration, toSXY, toSXY);
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