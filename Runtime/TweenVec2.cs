using UnityEngine;

namespace Uween
{
	public abstract class TweenVec2 : Tween
	{
		protected static T Add<T>(GameObject g, float duration) where T : TweenVec2
		{
			return Tween.Get<T>(g, duration);
		}

		protected static T Add<T>(GameObject g, float duration, Vector2 to) where T : TweenVec2
		{
			var t = Add<T>(g, duration);
			t.to = to;
			return t;
		}

		protected static T Add<T>(GameObject g, float duration, float v1, float v2) where T : TweenVec2
		{
			return Add<T>(g, duration, new Vector2(v1, v2));
		}

		public Vector2 from;
		public Vector2 to;

		public abstract Vector2 value { get; set; }

		override protected void Reset()
		{
			base.Reset();
			from = value;
			to = value;
		}

		override protected void UpdateValue(Easings e, float t, float d)
		{
			var v = Vector2.zero;
			v.x = e.Calculate(t, from.x, to.x - from.x, d);
			v.y = e.Calculate(t, from.y, to.y - from.y, d);
			value = v;
		}

		public TweenVec2 Relative()
		{
			to += value;
			return this;
		}

		public TweenVec2 FromRelative(Vector2 v)
		{
			from = value + v;
			value = from;
			return this;
		}

		public TweenVec2 FromRelative(float v1, float v2)
		{
			return FromRelative(new Vector2(v1, v2));
		}

		public TweenVec2 FromRelative(float v)
		{
			return FromRelative(v, v);
		}

		public TweenVec2 By()
		{
			return Relative();
		}

		public TweenVec2 From(Vector2 v)
		{
			from = v;
			value = from;
			return this;
		}

		public TweenVec2 From(float v1, float v2)
		{
			return From(new Vector2(v1, v2));
		}

		public TweenVec2 From(float v)
		{
			return From(v, v);
		}

		public TweenVec2 FromBy(Vector2 v)
		{
			return FromRelative(v);
		}

		public TweenVec2 FromBy(float v1, float v2)
		{
			return FromRelative(v1, v2);
		}

		public TweenVec2 FromBy(float v)
		{
			return FromRelative(v);
		}

		public TweenVec2 FromThat()
		{
			from = to;
			to = value;
			value = from;
			return this;
		}

		public TweenVec2 FromThatBy()
		{
			from = value + to;
			to = value;
			value = from;
			return this;
		}
	}
}
