using UnityEngine;
using UnityEngine.UI;

namespace Uween
{
	public class TweenCA : TweenVec4
	{
		public static TweenCA Add(GameObject g, float duration)
		{
			return Add<TweenCA>(g, duration);
		}

		public static TweenCA Add(GameObject g, float duration, Vector4 to)
		{
			return Add<TweenCA>(g, duration, to);
		}

		public static TweenCA Add(GameObject g, float duration, Color to)
		{
			return Add<TweenCA>(g, duration, (Vector4)to);
		}

		public static TweenCA Add(GameObject g, float duration, float toR, float toG, float toB, float toA)
		{
			return Add<TweenCA>(g, duration, toR, toG, toB, toA);
		}

		Graphic g;

		protected Graphic GetGraphic()
		{
			if (g == null) {
				g = GetComponent<Graphic>();
			}
			return g;
		}

		override public Vector4 value {
			get {
				return GetGraphic().color;
			}
			set {
				GetGraphic().color = value;
			}
		}
	}
}
