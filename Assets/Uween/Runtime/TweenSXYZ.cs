using UnityEngine;

namespace Uween
{
    public class TweenSXYZ : TweenVec3S
    {
        public static TweenSXYZ Add(GameObject g, float duration)
        {
            return Add<TweenSXYZ>(g, duration);
        }

        public static TweenSXYZ Add(GameObject g, float duration, Vector3 to)
        {
            return Add<TweenSXYZ>(g, duration, to);
        }

        public static TweenSXYZ Add(GameObject g, float duration, float toSX, float toSY, float toSZ)
        {
            return Add<TweenSXYZ>(g, duration, toSX, toSY, toSZ);
        }

        public static TweenSXYZ Add(GameObject g, float duration, float toSXYZ)
        {
            return Add(g, duration, toSXYZ, toSXYZ, toSXYZ);
        }
    }
}