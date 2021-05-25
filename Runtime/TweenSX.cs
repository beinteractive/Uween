using UnityEngine;

namespace Uween
{
    public class TweenSX : TweenVec1S
    {
        public static TweenSX Add(GameObject g, float duration)
        {
            return Add<TweenSX>(g, duration);
        }

        public static TweenSX Add(GameObject g, float duration, float to)
        {
            return Add<TweenSX>(g, duration, to);
        }

        protected override float Value
        {
            get { return Vector.x; }
            set
            {
                var v = Vector;
                v.x = value;
                Vector = v;
            }
        }
    }
}