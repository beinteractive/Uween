using UnityEngine;

namespace Uween
{
	public class TweenSX : TweenVec1S
	{
		public static TweenSX Add(GameObject g, float duration)
		{
			return Add<TweenSX>(g, duration);
		}

		public static TweenSX Add(GameObject g, float duration, float to)
		{
			return Add<TweenSX>(g, duration, to);
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
