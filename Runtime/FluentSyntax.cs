using UnityEngine;

namespace Uween
{
    public static class FluentSyntax
    {
        public static T Delay<T>(this T tween, float delay) where T : Tween
        {
            tween.DelayTime = delay;
            return tween;
        }

        public static T Animate<T>(this T tween, bool animated) where T : Tween
        {
            if (!animated)
            {
                tween.Skip();
            }

            return tween;
        }

        public static T Then<T>(this T tween, Callback callback) where T : Tween
        {
            if (tween.Enabled || !tween.IsComplete)
            {
                tween.OnComplete += callback;
            }
            else
            {
                callback();
            }

            return tween;
        }

        public static void PauseTweens(this GameObject g)
        {
            PauseTweens<Tween>(g);
        }

        public static void PauseTweens<T>(this GameObject g) where T : Tween
        {
            if (Updater.Instance == null)
            {
                return;
            }
            
            foreach (var t in Updater.Instance.FindAll<T>(g))
            {
                if (!t.IsComplete)
                {
                    t.Enabled = false;
                }
            }
        }

        public static void ResumeTweens(this GameObject g)
        {
            ResumeTweens<Tween>(g);
        }

        public static void ResumeTweens<T>(this GameObject g) where T : Tween
        {
            if (Updater.Instance == null)
            {
                return;
            }
            
            foreach (var t in Updater.Instance.FindAll<T>(g))
            {
                if (!t.IsComplete)
                {
                    t.Enabled = true;
                }
            }
        }

        public static void SkipTweens(this GameObject g)
        {
            SkipTweens<Tween>(g);
        }

        public static void SkipTweens<T>(this GameObject g) where T : Tween
        {
            if (Updater.Instance == null)
            {
                return;
            }
            
            foreach (var t in Updater.Instance.FindAll<T>(g))
            {
                if (!t.IsComplete)
                {
                    t.Skip();
                }
            }
        }
    }
}