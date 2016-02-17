using UnityEngine;

namespace Uween
{
	public class TweenRXZ : TweenVec2R
	{
		public static TweenRXZ Add(GameObject g, float duration)
		{
			return Add<TweenRXZ>(g, duration);
		}

		public static TweenRXZ Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenRXZ>(g, duration, to);
		}

		public static TweenRXZ Add(GameObject g, float duration, float toRX, float toRZ)
		{
			return Add<TweenRXZ>(g, duration, toRX, toRZ);
		}

		public static TweenRXZ Add(GameObject g, float duration, float toRXZ)
		{
			return Add(g, duration, toRXZ, toRXZ);
		}

		override public Vector2 value {
			get {
				return new Vector2(vector.x, vector.z);
			}
			set {
				Vector3 v = vector;
				v.x = value.x;
				v.z = value.y;
				vector = v;
			}
		}
	}
}
