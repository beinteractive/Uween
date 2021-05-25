using UnityEngine;

namespace Uween
{
    public class TweenXYZ : TweenVec3P
    {
        public static TweenXYZ Add(GameObject g, float duration)
        {
            return Add<TweenXYZ>(g, duration);
        }

        public static TweenXYZ Add(GameObject g, float duration, Vector3 to)
        {
            return Add<TweenXYZ>(g, duration, to);
        }

        public static TweenXYZ Add(GameObject g, float duration, float toX, float toY, float toZ)
        {
            return Add<TweenXYZ>(g, duration, toX, toY, toZ);
        }

        protected override Vector3 Value
        {
            get { return Vector; }
            set { Vector = value; }
        }
    }
}