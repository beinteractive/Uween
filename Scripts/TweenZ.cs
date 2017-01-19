using UnityEngine;

namespace Uween
{
	public class TweenZ : TweenVec1P
	{
		public static TweenZ Add(GameObject g, float duration)
		{
			return Add<TweenZ>(g, duration);
		}

		public static TweenZ Add(GameObject g, float duration, float to)
		{
			return Add<TweenZ>(g, duration, to);
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
