using UnityEngine;

namespace Uween
{
	public class TweenSXZ : TweenVec2S
	{
		public static TweenSXZ Add(GameObject g, float duration)
		{
			return Add<TweenSXZ>(g, duration);
		}

		public static TweenSXZ Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenSXZ>(g, duration, to);
		}

		public static TweenSXZ Add(GameObject g, float duration, float toSX, float toSZ)
		{
			return Add<TweenSXZ>(g, duration, toSX, toSZ);
		}

		public static TweenSXZ Add(GameObject g, float duration, float toSXZ)
		{
			return Add(g, duration, toSXZ, toSXZ);
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
