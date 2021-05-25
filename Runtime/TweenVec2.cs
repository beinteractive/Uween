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
            t.ToValue = to;
            return t;
        }

        protected static T Add<T>(GameObject g, float duration, float v1, float v2) where T : TweenVec2
        {
            return Add<T>(g, duration, new Vector2(v1, v2));
        }

        public Vector2 FromValue;
        public Vector2 ToValue;

        protected abstract Vector2 Value { get; set; }

        protected override void Reset()
        {
            base.Reset();
            FromValue = Value;
            ToValue = Value;
        }

        protected override void UpdateValue(Easings e, float t, float d)
        {
            var v = Vector2.zero;
            v.x = e.Calculate(t, FromValue.x, ToValue.x - FromValue.x, d);
            v.y = e.Calculate(t, FromValue.y, ToValue.y - FromValue.y, d);
            Value = v;
        }

        public TweenVec2 Relative()
        {
            ToValue += Value;
            return this;
        }

        public TweenVec2 FromRelative(Vector2 v)
        {
            FromValue = Value + v;
            Value = FromValue;
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
            FromValue = v;
            Value = FromValue;
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
            FromValue = ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }

        public TweenVec2 FromThatBy()
        {
            FromValue = Value + ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }
    }
}