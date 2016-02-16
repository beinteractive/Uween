using UnityEngine;

namespace Uween
{
	public abstract class TweenVec1T : TweenVec1
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

	public abstract class TweenVec1P : TweenVec1T
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

	public abstract class TweenVec1R : TweenVec1T
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

	public abstract class TweenVec1S : TweenVec1T
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
