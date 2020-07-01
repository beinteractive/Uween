using UnityEngine;

namespace Uween
{
    /// <summary>
    /// A base class for Uween's tweens.
    /// </summary>
    public abstract class Tween
    {
        protected static T Get<T>(GameObject g, float duration) where T : Tween, new()
        {
            var updater = Updater.Ensure();
            var tween = updater.Find<T>(g) ?? updater.Create<T>(g);

            tween.Reset();
            tween.duration = duration;
            tween.Enabled = true;
            return tween;
        }

        protected float duration;
        protected float delayTime;
        protected float elapsedTime;
        protected Easings easing;

        public GameObject Object { get; internal set; }
        public bool Enabled;
        internal Tween Next;

        /// <summary>
        /// Total duration of this tween (sec).
        /// </summary>
        /// <value>The duration.</value>
        public float Duration => Mathf.Max(0f, duration);

        /// <summary>
        /// Current playing position (sec).
        /// </summary>
        /// <value>The position.</value>
        public float Position => Mathf.Max(0f, elapsedTime - DelayTime);

        /// <summary>
        /// Delay for starting tween (sec).
        /// </summary>
        /// <value>The delay time.</value>
        public float DelayTime
        {
            get => Mathf.Max(0f, delayTime);
            set => delayTime = value;
        }

        /// <summary>
        /// Easing that be used for calculating tweening value.
        /// </summary>
        /// <value>The easing.</value>
        public Easings Easing
        {
            get => easing ?? Linear.EaseNone;
            set => easing = value;
        }

        /// <summary>
        /// Whether tween has been completed or not.
        /// </summary>
        /// <value><c>true</c> if this tween is complete; otherwise, <c>false</c>.</value>
        public bool IsComplete => Position >= Duration;

        /// <summary>
        /// Occurs when on tween complete.
        /// </summary>
        public event Callback OnComplete;

        public void Skip()
        {
            elapsedTime = DelayTime + Duration;
            Update(0f);
        }

        protected virtual void Reset()
        {
            duration = 0f;
            delayTime = 0f;
            elapsedTime = 0f;
            easing = null;
            OnComplete = null;
        }

        internal virtual void Update(float dt)
        {
            var elapsed = elapsedTime + dt;
            var delay = DelayTime;
            var d = Duration;

            elapsedTime = elapsed;

            if (elapsedTime < delay)
            {
                return;
            }

            var t = elapsedTime - delay;

            if (t >= d)
            {
                if (d == 0f)
                {
                    t = d = 1f;
                }
                else
                {
                    t = d;
                }

                elapsedTime = delay + d;
                Enabled = false;
            }

            UpdateValue(Easing, t, d);

            if (!Enabled)
            {
                if (OnComplete != null)
                {
                    var callback = OnComplete;
                    OnComplete = null;
                    callback();
                }
            }
        }

        protected abstract void UpdateValue(Easings e, float t, float d);
    }
}