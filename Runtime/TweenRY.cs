using UnityEngine;

namespace Uween
{
    public class TweenRY : TweenVec1R
    {
        public static TweenRY Add(GameObject g, float duration)
        {
            return Add<TweenRY>(g, duration);
        }

        public static TweenRY Add(GameObject g, float duration, float to)
        {
            return Add<TweenRY>(g, duration, to);
        }

        protected override float Value
        {
            get { return Vector.y; }
            set
            {
                var v = Vector;
                v.y = value;
                Vector = v;
            }
        }
    }
}