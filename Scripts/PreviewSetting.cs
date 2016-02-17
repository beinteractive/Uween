using UnityEngine;
using System.Collections;

namespace Uween
{
	public class PreviewSetting : ScriptableObject
	{
		public float x;

		public void Create(GameObject g, float duration)
		{
			TweenX.Add(g, duration, x).EaseOutQuart();
		}
	}
}