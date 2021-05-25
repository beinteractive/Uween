using UnityEngine;

namespace Uween
{
    public class TweenXY : TweenVec2P
    {
        public static TweenXY Add(GameObject g, float duration)
        {
            return Add<TweenXY>(g, duration);
        }

        public static TweenXY Add(GameObject g, float duration, Vector2 to)
        {
            return Add<TweenXY>(g, duration, to);
        }

        public static TweenXY Add(GameObject g, float duration, float toX, float toY)
        {
            return Add<TweenXY>(g, duration, toX, toY);
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