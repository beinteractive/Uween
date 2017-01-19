using UnityEngine;

namespace Uween
{
	public class TweenSXY : TweenVec2S
	{
		public static TweenSXY Add(GameObject g, float duration)
		{
			return Add<TweenSXY>(g, duration);
		}

		public static TweenSXY Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenSXY>(g, duration, to);
		}

		public static TweenSXY Add(GameObject g, float duration, float toSX, float toSY)
		{
			return Add<TweenSXY>(g, duration, toSX, toSY);
		}

		public static TweenSXY Add(GameObject g, float duration, float toSXY)
		{
			return Add(g, duration, toSXY, toSXY);
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
