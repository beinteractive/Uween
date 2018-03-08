using UnityEngine;

namespace Uween
{
    public class TweenX : TweenVec1P
    {
        public static TweenX Add(GameObject g, float duration)
        {
            return Add<TweenX>(g, duration);
        }

        public static TweenX Add(GameObject g, float duration, float to)
        {
            return Add<TweenX>(g, duration, to);
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