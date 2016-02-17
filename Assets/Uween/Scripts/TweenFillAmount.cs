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

		Image im;

		protected Image GetImage()
		{
			if (im == null) {
				im = GetComponent<Image>();
			}
			return im;
		}

		override public float value {
			get {
				return GetImage().fillAmount;
			}
			set {
				GetImage().fillAmount = value;
			}
		}
	}
}
