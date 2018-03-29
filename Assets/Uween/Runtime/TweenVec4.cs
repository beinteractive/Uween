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
            t.ToValue = to;
            return t;
        }

        protected static T Add<T>(GameObject g, float duration, float x, float y, float z, float w) where T : TweenVec4
        {
            return Add<T>(g, duration, new Vector4(x, y, z, w));
        }

        public Vector4 FromValue;
        public Vector4 ToValue;

        protected abstract Vector4 Value { get; set; }

        protected override void Reset()
        {
            base.Reset();
            FromValue = Value;
            ToValue = Value;
        }

        protected override void UpdateValue(Easings e, float t, float d)
        {
            var v = Vector4.zero;
            v.x = e.Calculate(t, FromValue.x, ToValue.x - FromValue.x, d);
            v.y = e.Calculate(t, FromValue.y, ToValue.y - FromValue.y, d);
            v.z = e.Calculate(t, FromValue.z, ToValue.z - FromValue.z, d);
            v.w = e.Calculate(t, FromValue.w, ToValue.w - FromValue.w, d);
            Value = v;
        }

        public TweenVec4 Relative()
        {
            ToValue += Value;
            return this;
        }

        public TweenVec4 FromRelative(Vector4 v)
        {
            FromValue = Value + v;
            Value = FromValue;
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
            FromValue = v;
            Value = FromValue;
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
            FromValue = ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }

        public TweenVec4 FromThatBy()
        {
            FromValue = Value + ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }
    }
}