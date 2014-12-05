using UnityEngine;
using System.Collections;
using Uween;

/// <summary>
/// A base class for Uween's tweens.
/// </summary>
public abstract class Tween : MonoBehaviour
{
    protected static T Get<T>(GameObject g, float duration) where T : Tween
    {
        T tween = g.GetComponent<T>();
        if (tween == null) {
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
    public float Duration { get { return Mathf.Max(0f, duration); } }

    /// <summary>
    /// Current playing position (sec).
    /// </summary>
    /// <value>The position.</value>
    public float Position { get { return Mathf.Max(0f, elapsedTime - DelayTime); } }

    /// <summary>
    /// Delay for starting tween (sec).
    /// </summary>
    /// <value>The delay time.</value>
    public float DelayTime { get { return Mathf.Max(0f, delayTime); } set { delayTime = value; } }

    /// <summary>
    /// Easing that be used for calculating tweening value.
    /// </summary>
    /// <value>The easing.</value>
    public Easings Easing { get { return easing ?? Linear.EaseNone; } set { easing = value; } }

    /// <summary>
    /// Whether tween has been completed or not.
    /// </summary>
    /// <value><c>true</c> if this tween is complete; otherwise, <c>false</c>.</value>
    public bool IsComplete { get { return Position >= Duration; } }

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
        if (OnComplete != null) {
            foreach (System.Delegate d in OnComplete.GetInvocationList()) {
                OnComplete -= (Callback)d;
            }
        }
    }

    protected virtual void Update()
    {
        float delay = DelayTime;
        float duration = Duration;

        elapsedTime += Time.deltaTime;

        if (elapsedTime < delay) {
            return;
        }

        float t = elapsedTime - delay;
        float f = 1f;

        if (t >= duration) {
            t = duration;
            elapsedTime = delay + duration;
            enabled = false;
        }
        else {
            f = Easing.Calculate(t, 0f, 1f, duration);
        }

        UpdateValue(f);

        if (!enabled) {
            if (OnComplete != null) {
                var oldCallbacks = OnComplete.GetInvocationList();
                OnComplete();
                foreach (System.Delegate d in oldCallbacks) {
                    OnComplete -= (Callback)d;
                }
            }
        }
    }

    protected abstract void UpdateValue(float f);
}
