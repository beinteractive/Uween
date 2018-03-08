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
            t.ToValue = to;
            return t;
        }

        protected static T Add<T>(GameObject g, float duration, float x, float y, float z) where T : TweenVec3
        {
            return Add<T>(g, duration, new Vector3(x, y, z));
        }

        public Vector3 FromValue;
        public Vector3 ToValue;

        protected abstract Vector3 Value { get; set; }

        protected override void Reset()
        {
            base.Reset();
            FromValue = Value;
            ToValue = Value;
        }

        protected override void UpdateValue(Easings e, float t, float d)
        {
            var v = Vector3.zero;
            v.x = e.Calculate(t, FromValue.x, ToValue.x - FromValue.x, d);
            v.y = e.Calculate(t, FromValue.y, ToValue.y - FromValue.y, d);
            v.z = e.Calculate(t, FromValue.z, ToValue.z - FromValue.z, d);
            Value = v;
        }

        public TweenVec3 Relative()
        {
            ToValue += Value;
            return this;
        }

        public TweenVec3 By()
        {
            return Relative();
        }

        public TweenVec3 From(Vector3 v)
        {
            FromValue = v;
            Value = FromValue;
            return this;
        }

        public TweenVec3 FromRelative(Vector3 v)
        {
            FromValue = Value + v;
            Value = FromValue;
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
            FromValue = ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }

        public TweenVec3 FromThatBy()
        {
            FromValue = Value + ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }
    }
}