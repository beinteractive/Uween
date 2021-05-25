using UnityEngine;

namespace Uween
{
    public class TweenRXYZ : TweenVec3R
    {
        public static TweenRXYZ Add(GameObject g, float duration)
        {
            return Add<TweenRXYZ>(g, duration);
        }

        public static TweenRXYZ Add(GameObject g, float duration, Vector3 to)
        {
            return Add<TweenRXYZ>(g, duration, to);
        }

        public static TweenRXYZ Add(GameObject g, float duration, float toRX, float toRY, float toRZ)
        {
            return Add<TweenRXYZ>(g, duration, toRX, toRY, toRZ);
        }

        public static TweenRXYZ Add(GameObject g, float duration, float toRXYZ)
        {
            return Add(g, duration, toRXYZ, toRXYZ, toRXYZ);
        }
    }
}