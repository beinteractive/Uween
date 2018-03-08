using UnityEngine;
using UnityEngine.UI;

namespace Uween
{
    public class TweenA : TweenVec1
    {
        public static TweenA Add(GameObject g, float duration)
        {
            return Add<TweenA>(g, duration);
        }

        public static TweenA Add(GameObject g, float duration, float to)
        {
            return Add<TweenA>(g, duration, to);
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

        protected override float Value
        {
            get { return GetGraphic().color.a; }
            set
            {
                var g = GetGraphic();
                var c = g.color;
                c.a = value;
                g.color = c;
            }
        }
    }
}