using UnityEngine;

namespace Uween
{
	public class TweenRXY : TweenVec2R
	{
		public static TweenRXY Add(GameObject g, float duration)
		{
			return Add<TweenRXY>(g, duration);
		}

		public static TweenRXY Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenRXY>(g, duration, to);
		}

		public static TweenRXY Add(GameObject g, float duration, float toRX, float toRY)
		{
			return Add<TweenRXY>(g, duration, toRX, toRY);
		}

		public static TweenRXY Add(GameObject g, float duration, float toRXY)
		{
			return Add(g, duration, toRXY, toRXY);
		}

		override public Vector2 value {
			get {
				return new Vector2(vector.x, vector.y);
			}
			set {
				Vector3 v = vector;
				v.x = value.x;
				v.y = value.y;
				vector = v;
			}
		}
	}
}
