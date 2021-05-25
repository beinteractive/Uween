using UnityEngine;
using UnityEngine.UI;

namespace Uween
{
    public class TweenFillAmount : TweenVec1
    {
        public static TweenFillAmount Add(GameObject g, float duration)
        {
            return Add<TweenFillAmount>(g, duration);
        }

        public static TweenFillAmount Add(GameObject g, float duration, float to)
        {
            return Add<TweenFillAmount>(g, duration, to);
        }

        private Image Im;

        protected Image GetImage()
        {
            if (Im == null)
            {
                Im = GetComponent<Image>();
            }

            return Im;
        }

        protected override float Value
        {
            get { return GetImage().fillAmount; }
            set { GetImage().fillAmount = value; }
        }
    }
}