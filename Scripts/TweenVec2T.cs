using UnityEngine;

namespace Uween
{
	public abstract class TweenVec2T : TweenVec2
	{
		public abstract Vector3 vector { get; set; }

		Transform t;

		protected Transform GetTransform()
		{
			if (t == null) {
				t = transform;
			}
			return t;
		}
	}

	public abstract class TweenVec2P : TweenVec2T
	{
		override public Vector3 vector {
			get {
				return GetTransform().localPosition;
			}
			set {
				GetTransform().localPosition = value;
			}
		}
	}

	public abstract class TweenVec2R : TweenVec2T
	{
		override public Vector3 vector {
			get {
				return GetTransform().localRotation.eulerAngles;
			}
			set {
				GetTransform().localRotation = Quaternion.Euler(value);
			}
		}
	}

	public abstract class TweenVec2S : TweenVec2T
	{
		override public Vector3 vector {
			get {
				return GetTransform().localScale;
			}
			set {
				GetTransform().localScale = value;
			}
		}
	}
}
