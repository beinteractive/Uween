using UnityEngine;

namespace Uween
{
	public class TweenXY : TweenVec2P
	{
		public static TweenXY Add(GameObject g, float duration)
		{
			return Add<TweenXY>(g, duration);
		}

		public static TweenXY Add(GameObject g, float duration, Vector2 to)
		{
			return Add<TweenXY>(g, duration, to);
		}

		public static TweenXY Add(GameObject g, float duration, float toX, float toY)
		{
			return Add<TweenXY>(g, duration, toX, toY);
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
