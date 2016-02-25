using UnityEngine;
using System.Collections;

namespace Uween
{
	public class PreviewSetting : ScriptableObject
	{
		public TweenTypeEnum type = TweenTypeEnum.TweenP;
		public bool enabled = true;

		public float delay = 0f;
		public bool delayOverride = false;

		public float duration = 0.3f;
		public bool durationOverride = false;

		public EasingEnum easing = EasingEnum.LinearEaseNone;
		public bool easingOverride = false;

		public Vector4 to;
		public bool toEnabled = true;
		public bool toRelative = false;

		public Vector4 from;
		public bool fromEnabled = false;
		public bool fromRelative = false;

		public float GetDelay(float d)
		{
			return delayOverride ? delay : d;
		}

		public float GetDuration(float d)
		{
			return durationOverride ? duration : d;
		}

		public float GetTotalDuration(float delay, float duration)
		{
			return GetDelay(delay) + GetDuration(duration);
		}

		public EasingEnum GetEasing(EasingEnum e)
		{
			return easingOverride ? easing : e;
		}

		public Tween Create(GameObject g, Preview p)
		{
			if (!enabled) {
				return null;
			}

			var delay = GetDelay(p.delay);
			var duration = GetDuration(p.duration);
			var easing = GetEasing(p.easing);

			var tween = Add(g, duration, type);
			{
				var tv1 = tween as TweenVec1;
				if (tv1 != null) {
					if (toEnabled) {
						tv1.to = to.x;
						if (toRelative) {
							tv1.Relative();
						}
					}
					if (fromEnabled) {
						if (fromRelative) {
							tv1.FromRelative(from.x);
						} else {
							tv1.From(from.x);
						}
					}
				}
				var tv2 = tween as TweenVec2;
				if (tv2 != null) {
					if (toEnabled) {
						tv2.to = (Vector2)to;
						if (toRelative) {
							tv2.Relative();
						}
					}
					if (fromEnabled) {
						if (fromRelative) {
							tv2.FromRelative((Vector2)from);
						} else {
							tv2.From((Vector2)from);
						}
					}
				}
				var tv3 = tween as TweenVec3;
				if (tv3 != null) {
					if (toEnabled) {
						tv3.to = (Vector3)to;
						if (toRelative) {
							tv3.Relative();
						}
					}
					if (fromEnabled) {
						if (fromRelative) {
							tv3.FromRelative((Vector3)from);
						} else {
							tv3.From((Vector3)from);
						}
					}
				}
				var tv4 = tween as TweenVec4;
				if (tv4 != null) {
					if (toEnabled) {
						tv4.to = to;
						if (toRelative) {
							tv4.Relative();
						}
					}
					if (fromEnabled) {
						if (fromRelative) {
							tv4.FromRelative(from);
						} else {
							tv4.From(from);
						}
					}
				}
			}
			tween.DelayTime = delay;
			tween.Easing = GetEasingClass(easing);
			return tween;
		}

		Tween Add(GameObject g, float d, TweenTypeEnum type)
		{
			var add = (System.Reflection.MethodInfo)null;
			for (var t = type.AsType(); t != null; t = t.BaseType) {
				add = t.GetMethod("Add", new System.Type[] { typeof(GameObject), typeof(float) });
				if (add != null) {
					break;
				}
			}
			return (Tween)add.Invoke(null, new object[] { g, d });
		}

		Easings GetEasingClass(EasingEnum e)
		{
			return (Easings)System.Activator.CreateInstance(System.Reflection.Assembly.GetAssembly(typeof(Easings)).GetType("Uween." + e.ToString()));
		}
	}
}