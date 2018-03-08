using UnityEngine;

namespace Uween
{
	public class TweenRZ : TweenVec1R
	{
		public static TweenRZ Add(GameObject g, float duration)
		{
			return Add<TweenRZ>(g, duration);
		}

		public static TweenRZ Add(GameObject g, float duration, float to)
		{
			return Add<TweenRZ>(g, duration, to);
		}

		override public float value {
			get {
				return vector.z;
			}
			set {
				Vector3 v = vector;
				v.z = value;
				vector = v;
			}
		}
	}
}
