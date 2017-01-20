using UnityEngine;

namespace Uween
{
	public abstract class TweenVec4 : Tween
	{
		protected static T Add<T>(GameObject g, float duration) where T : TweenVec4
		{
			return Tween.Get<T>(g, duration);
		}

		protected static T Add<T>(GameObject g, float duration, Vector4 to) where T : TweenVec4
		{
			var t = Add<T>(g, duration);
			t.to = to;
			return t;
		}

		protected static T Add<T>(GameObject g, float duration, float x, float y, float z, float w) where T : TweenVec4
		{
			return Add<T>(g, duration, new Vector4(x, y, z, w));
		}

		public Vector4 from;
		public Vector4 to;

		public abstract Vector4 value { get; set; }

		override protected void Reset()
		{
			base.Reset();
			from = value;
			to = value;
		}

		override protected void UpdateValue(Easings e, float t, float d)
		{
			var v = Vector4.zero;
			v.x = e.Calculate(t, from.x, to.x - from.x, d);
			v.y = e.Calculate(t, from.y, to.y - from.y, d);
			v.z = e.Calculate(t, from.z, to.z - from.z, d);
			v.w = e.Calculate(t, from.w, to.w - from.w, d);
			value = v;
		}

		public TweenVec4 Relative()
		{
			to += value;
			return this;
		}

		public TweenVec4 FromRelative(Vector4 v)
		{
			from = value + v;
			value = from;
			return this;
		}

		public TweenVec4 FromRelative(float x, float y, float z, float w)
		{
			return FromRelative(new Vector4(x, y, z, w));
		}

		public TweenVec4 FromRelative(float v)
		{
			return FromRelative(v, v, v, v);
		}

		public TweenVec4 By()
		{
			return Relative();
		}

		public TweenVec4 From(Vector4 v)
		{
			from = v;
			value = from;
			return this;
		}

		public TweenVec4 From(float x, float y, float z, float w)
		{
			return From(new Vector4(x, y, z, w));
		}

		public TweenVec4 From(float v)
		{
			return From(v, v, v, v);
		}

		public TweenVec4 FromBy(Vector4 v)
		{
			return FromRelative(v);
		}

		public TweenVec4 FromBy(float x, float y, float z, float w)
		{
			return FromRelative(x, y, z, w);
		}

		public TweenVec4 FromBy(float v)
		{
			return FromRelative(v);
		}

		public TweenVec4 FromThat()
		{
			from = to;
			to = value;
			value = from;
			return this;
		}

		public TweenVec4 FromThatBy()
		{
			from = value + to;
			to = value;
			value = from;
			return this;
		}
	}
}
