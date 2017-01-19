using UnityEngine;

namespace Uween
{
	public class TweenRY : TweenVec1R
	{
		public static TweenRY Add(GameObject g, float duration)
		{
			return Add<TweenRY>(g, duration);
		}

		public static TweenRY Add(GameObject g, float duration, float to)
		{
			return Add<TweenRY>(g, duration, to);
		}

		override public float value {
			get {
				return vector.y;
			}
			set {
				Vector3 v = vector;
				v.y = value;
				vector = v;
			}
		}
	}
}
