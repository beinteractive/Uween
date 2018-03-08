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
            t.ToValue = to;
            return t;
        }

        public float FromValue;
        public float ToValue;

        protected abstract float Value { get; set; }

        protected override void Reset()
        {
            base.Reset();
            FromValue = Value;
            ToValue = Value;
        }

        protected override void UpdateValue(Easings e, float t, float d)
        {
            Value = e.Calculate(t, FromValue, ToValue - FromValue, d);
        }

        public TweenVec1 Relative()
        {
            ToValue += Value;
            return this;
        }

        public TweenVec1 FromRelative(float v)
        {
            FromValue = Value + v;
            Value = FromValue;
            return this;
        }

        public TweenVec1 By()
        {
            return Relative();
        }

        public TweenVec1 From(float v)
        {
            FromValue = v;
            Value = FromValue;
            return this;
        }

        public TweenVec1 FromBy(float v)
        {
            return FromRelative(v);
        }

        public TweenVec1 FromThat()
        {
            FromValue = ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }

        public TweenVec1 FromThatBy()
        {
            FromValue = Value + ToValue;
            ToValue = Value;
            Value = FromValue;
            return this;
        }
    }
}