using UnityEngine;

namespace Uween
{
	public class TweenSYZ : TweenVec2S
	{
		public static TweenSYZ Add(GameObject g, float duration)
		{
			return Add<TweenSYZ>(g, duration);
		}

		public static TweenSYZ Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenSYZ>(g, duration, to);
		}

		public static TweenSYZ Add(GameObject g, float duration, float toSY, float toSZ)
		{
			return Add<TweenSYZ>(g, duration, toSY, toSZ);
		}

		public static TweenSYZ Add(GameObject g, float duration, float toSYZ)
		{
			return Add(g, duration, toSYZ, toSYZ);
		}

		override public Vector2 value {
			get {
				return new Vector2(vector.y, vector.z);
			}
			set {
				Vector3 v = vector;
				v.y = value.x;
				v.z = value.y;
				vector = v;
			}
		}
	}
}
