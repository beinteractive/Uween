using UnityEngine;

namespace Uween
{
	public class TweenYZ : TweenVec2P
	{
		public static TweenYZ Add(GameObject g, float duration)
		{
			return Add<TweenYZ>(g, duration);
		}

		public static TweenYZ Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenYZ>(g, duration, to);
		}

		public static TweenYZ Add(GameObject g, float duration, float toY, float toZ)
		{
			return Add<TweenYZ>(g, duration, toY, toZ);
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
