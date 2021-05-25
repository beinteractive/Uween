using UnityEngine;

namespace Uween
{
    public class TweenY : TweenVec1P
    {
        public static TweenY Add(GameObject g, float duration)
        {
            return Add<TweenY>(g, duration);
        }

        public static TweenY Add(GameObject g, float duration, float to)
        {
            return Add<TweenY>(g, duration, to);
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