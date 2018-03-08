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

		override public float value {
			get {
				return vector.x;
			}
			set {
				Vector3 v = vector;
				v.x = value;
				vector = v;
			}
		}
	}
}
