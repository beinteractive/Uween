using UnityEngine;

namespace Uween
{
	public class TweenY : TweenVec1P
	{
		public static TweenY Add(GameObject g, float duration)
		{
			return Add<TweenY>(g, duration);
		}

		public static TweenY Add(GameObject g, float duration, float to)
		{
			return Add<TweenY>(g, duration, to);
		}

		override public float value {
			get {
				return vector.y;
			}
			set {
				Vector3 v = vector;
				v.y = value;
				vector = v;
			}
		}
	}
}
