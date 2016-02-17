using UnityEngine;
using System.Collections;

namespace Uween
{
	public class PreviewSetting : ScriptableObject
	{
		public float delay = 0f;
		public bool delayOverride = false;

		public float duration = 0.3f;
		public bool durationOverride = false;

		public EasingEnum easing = EasingEnum.LinearEaseNone;
		public bool easingOverride = false;

		public float x;

		public void Create(GameObject g, Preview p)
		{
			var delay = delayOverride ? this.delay : p.delay;
			var duration = durationOverride ? this.duration : p.duration;
			var easing = easingOverride ? this.easing : p.easing;

			TweenX.Add(g, duration, x).Delay(delay).Easing = GetEasing(easing);
		}

		Easings GetEasing(EasingEnum e)
		{
			return (Easings)System.Activator.CreateInstance(System.Reflection.Assembly.GetAssembly(typeof(Easings)).GetType("Uween." + e.ToString()));
		}
	}
}