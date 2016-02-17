using UnityEngine;
using System.Collections;

namespace Uween
{
	public class PreviewSetting : ScriptableObject
	{
		public float duration = 0.3f;
		public bool durationOverride = false;

		public EasingEnum easing = EasingEnum.LinearEaseNone;
		public bool easingOverride = false;

		public float x;

		public void Create(GameObject g, float d, EasingEnum e)
		{
			if (durationOverride) {
				d = duration;
			}
			if (easingOverride) {
				e = easing;
			}
			TweenX.Add(g, d, x).Easing = GetEasing(e);
		}

		Easings GetEasing(EasingEnum e)
		{
			return (Easings)System.Activator.CreateInstance(System.Reflection.Assembly.GetAssembly(typeof(Easings)).GetType("Uween." + e.ToString()));
		}
	}
}