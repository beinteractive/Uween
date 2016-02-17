using UnityEngine;

namespace Uween
{
	public abstract class TweenVec1 : Tween
	{
		protected static T Add<T>(GameObject g, float duration) where T : TweenVec1
		{
			return Tween.Get<T>(g, duration);
		}

		protected static T Add<T>(GameObject g, float duration, float to) where T : TweenVec1
		{
			var t = Add<T>(g, duration);
			t.to = to;
			return t;
		}

		public float from;
		public float to;

		public abstract float value { get; set; }

		override protected void Reset()
		{
			base.Reset();
			from = value;
			to = value;
		}

		override protected void UpdateValue(Easings e, float t, float d)
		{
			value = e.Calculate(t, from, to - from, d);
		}

		public TweenVec1 Relative()
		{
			to += value;
			return this;
		}

		public TweenVec1 FromRelative(float v)
		{
			from = value + v;
			value = from;
			return this;
		}

		public TweenVec1 By()
		{
			return Relative();
		}

		public TweenVec1 From(float v)
		{
			from = v;
			value = from;
			return this;
		}

		public TweenVec1 FromBy(float v)
		{
			return FromRelative(v);
		}

		public TweenVec1 FromThat()
		{
			from = to;
			to = value;
			value = from;
			return this;
		}

		public TweenVec1 FromThatBy()
		{
			from = value + to;
			to = value;
			value = from;
			return this;
		}
	}
}
