using UnityEngine;
using System.Collections;

namespace Uween
{
	public class PreviewSetting : ScriptableObject
	{
		public float duration = 0.3f;
		public bool durationOverride = false;

		public float x;

		public void Create(GameObject g, float d)
		{
			if (durationOverride) {
				d = duration;
			}
			TweenX.Add(g, d, x).EaseOutQuart();
		}
	}
}