using UnityEngine;
using UnityEngine.UI;

namespace Uween
{
    public class TweenC : TweenVec3
    {
        public static TweenC Add(GameObject g, float duration)
        {
            return Add<TweenC>(g, duration);
        }

        public static TweenC Add(GameObject g, float duration, Vector3 to)
        {
            return Add<TweenC>(g, duration, to);
        }

        public static TweenC Add(GameObject g, float duration, Color to)
        {
            return Add<TweenC>(g, duration, to.r, to.g, to.b);
        }

        public static TweenC Add(GameObject g, float duration, float toR, float toG, float toB)
        {
            return Add<TweenC>(g, duration, toR, toG, toB);
        }

        private Graphic G;

        protected Graphic GetGraphic()
        {
            if (G == null)
            {
                G = GetComponent<Graphic>();
            }

            return G;
        }

        protected override Vector3 Value
        {
            get
            {
                var c = GetGraphic().color;
                return new Vector3(c.r, c.g, c.b);
            }
            set
            {
                var c = GetGraphic().color;
                c.r = value.x;
                c.g = value.y;
                c.b = value.z;
                GetGraphic().color = c;
            }
        }
    }
}