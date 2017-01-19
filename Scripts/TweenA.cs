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

		Graphic g;

		protected Graphic GetGraphic()
		{
			if (g == null) {
				g = GetComponent<Graphic>();
			}
			return g;
		}

		override public float value {
			get {
				return GetGraphic().color.a;
			}
			set {
				Graphic g = GetGraphic();
				Color c = g.color;
				c.a = value;
				g.color = c;
			}
		}
	}
}
