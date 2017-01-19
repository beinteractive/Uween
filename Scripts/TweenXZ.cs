using UnityEngine;

namespace Uween
{
	public class TweenXZ : TweenVec2P
	{
		public static TweenXZ Add(GameObject g, float duration)
		{
			return Add<TweenXZ>(g, duration);
		}

		public static TweenXZ Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenXZ>(g, duration, to);
		}

		public static TweenXZ Add(GameObject g, float duration, float toX, float toZ)
		{
			return Add<TweenXZ>(g, duration, toX, toZ);
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
