using UnityEngine;

namespace Uween
{
    /// <summary>
    /// A base class for Uween's tweens.
    /// </summary>
    public abstract class Tween : MonoBehaviour
    {
        protected static T Get<T>(GameObject g, float duration) where T : Tween
        {
            T tween = g.GetComponent<T>();
            if (tween == null)
            {
                tween = g.AddComponent<T>();
            }

            tween.Reset();
            tween.duration = duration;
            tween.enabled = true;
            return tween;
        }

        protected float duration;
        protected float delayTime;
        protected float elapsedTime;
        protected Easings easing;

        /// <summary>
        /// Total duration of this tween (sec).
        /// </summary>
        /// <value>The duration.</value>
        public float Duration
        {
            get { return Mathf.Max(0f, duration); }
        }

        /// <summary>
        /// Current playing position (sec).
        /// </summary>
        /// <value>The position.</value>
        public float Position
        {
            get { return Mathf.Max(0f, elapsedTime - DelayTime); }
        }

        /// <summary>
        /// Delay for starting tween (sec).
        /// </summary>
        /// <value>The delay time.</value>
        public float DelayTime
        {
            get { return Mathf.Max(0f, delayTime); }
            set { delayTime = value; }
        }

        /// <summary>
        /// Easing that be used for calculating tweening value.
        /// </summary>
        /// <value>The easing.</value>
        public Easings Easing
        {
            get { return easing ?? Linear.EaseNone; }
            set { easing = value; }
        }

        /// <summary>
        /// Whether tween has been completed or not.
        /// </summary>
        /// <value><c>true</c> if this tween is complete; otherwise, <c>false</c>.</value>
        public bool IsComplete
        {
            get { return Position >= Duration; }
        }

        /// <summary>
        /// Occurs when on tween complete.
        /// </summary>
        public event Callback OnComplete;

        public void Skip()
        {
            elapsedTime = DelayTime + Duration;
            Update();
        }

        protected virtual void Reset()
        {
            duration = 0f;
            delayTime = 0f;
            elapsedTime = 0f;
            easing = null;
            OnComplete = null;
        }

        public virtual void Update()
        {
            Update(elapsedTime + Time.deltaTime);
        }

        public virtual void Update(float elapsed)
        {
            var delay = DelayTime;
            var duration = Duration;

            elapsedTime = elapsed;

            if (elapsedTime < delay)
            {
                return;
            }

            var t = elapsedTime - delay;

            if (t >= duration)
            {
                if (duration == 0f)
                {
                    t = duration = 1f;
                }
                else
                {
                    t = duration;
                }

                elapsedTime = delay + duration;
                enabled = false;
            }

            UpdateValue(Easing, t, duration);

            if (!enabled)
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