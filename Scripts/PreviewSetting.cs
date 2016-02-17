using UnityEngine;
using System.Collections;

namespace Uween
{
	public class PreviewSetting : ScriptableObject
	{
		public float x;

		public void Create(GameObject g)
		{
			TweenX.Add(g, 2f, x).EaseOutQuart();
		}
	}
}