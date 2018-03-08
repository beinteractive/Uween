using UnityEngine;

namespace Uween
{
	public class TweenRYZ : TweenVec2R
	{
		public static TweenRYZ Add(GameObject g, float duration)
		{
			return Add<TweenRYZ>(g, duration);
		}

		public static TweenRYZ Add(GameObject g, float duration, float toRY, float toRZ)
		{
			return Add<TweenRYZ>(g, duration, toRY, toRZ);
		}

		public static TweenRYZ Add(GameObject g, float duration, float toRYZ)
		{
			return Add(g, duration, toRYZ, toRYZ);
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
