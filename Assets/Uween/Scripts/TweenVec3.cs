using UnityEngine;

namespace Uween
{
	public abstract class TweenVec3 : Tween
	{
		protected static T Add<T>(GameObject g, float duration) where T : TweenVec3
		{
			return Tween.Get<T>(g, duration);
		}

		protected static T Add<T>(GameObject g, float duration, Vector3 to) where T : TweenVec3
		{
			var t = Add<T>(g, duration);
			t.to = to;
			return t;
		}

		protected static T Add<T>(GameObject g, float duration, float x, float y, float z) where T : TweenVec3
		{
			return Add<T>(g, duration, new Vector3(x, y, z));
		}

		public Vector3 from;
		public Vector3 to;

		public abstract Vector3 value { get; set; }

		override protected void Reset()
		{
			base.Reset();
			from = value;
			to = value;
		}

		override protected void UpdateValue(Easings e, float t, float d)
		{
			var v = Vector3.zero;
			v.x = e.Calculate(t, from.x, to.x - from.x, d);
			v.y = e.Calculate(t, from.y, to.y - from.y, d);
			v.z = e.Calculate(t, from.z, to.z - from.z, d);
			value = v;
		}

		public TweenVec3 Relative()
		{
			to += value;
			return this;
		}

		public TweenVec3 By()
		{
			return Relative();
		}

		public TweenVec3 From(Vector3 v)
		{
			from = v;
			value = from;
			return this;
		}

		public TweenVec3 FromRelative(Vector3 v)
		{
			from = value + v;
			value = from;
			return this;
		}

		public TweenVec3 FromRelative(float x, float y, float z)
		{
			return FromRelative(new Vector3(x, y, z));
		}

		public TweenVec3 FromRelative(float v)
		{
			return FromRelative(v, v, v);
		}

		public TweenVec3 From(float x, float y, float z)
		{
			return From(new Vector3(x, y, z));
		}

		public TweenVec3 From(float v)
		{
			return From(v, v, v);
		}

		public TweenVec3 FromBy(Vector3 v)
		{
			return FromRelative(v);
		}

		public TweenVec3 FromBy(float x, float y, float z)
		{
			return FromRelative(x, y, z);
		}

		public TweenVec3 FromBy(float v)
		{
			return FromRelative(v);
		}

		public TweenVec3 FromThat()
		{
			from = to;
			to = value;
			value = from;
			return this;
		}

		public TweenVec3 FromThatBy()
		{
			from = value + to;
			to = value;
			value = from;
			return this;
		}
	}
}
