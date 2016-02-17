using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Uween
{
	public class Preview : MonoBehaviour
	{
		[SerializeField]
		public float duration = 0.3f;

		[SerializeField]
		public EasingEnum easing = EasingEnum.LinearEaseNone;

		[SerializeField]
		public List<PreviewSetting> settings = new List<PreviewSetting>();
	}

	public enum EasingEnum
	{
		LinearEaseNone,
		BackEaseIn,
		BackEaseInOut,
		BackEaseOut,
		BackEaseOutIn,
		BounceEaseIn,
		BounceEaseInOut,
		BounceEaseOut,
		BounceEaseOutIn,
		CircularEaseIn,
		CircularEaseInOut,
		CircularEaseOut,
		CircularEaseOutIn,
		CubicEaseIn,
		CubicEaseInOut,
		CubicEaseOut,
		CubicEaseOutIn,
		ElasticEaseIn,
		ElasticEaseInOut,
		ElasticEaseOut,
		ElasticEaseOutIn,
		ExponentialEaseIn,
		ExponentialEaseInOut,
		ExponentialEaseOut,
		ExponentialEaseOutIn,
		QuadraticEaseIn,
		QuadraticEaseInOut,
		QuadraticEaseOut,
		QuadraticEaseOutIn,
		QuarticEaseIn,
		QuarticEaseInOut,
		QuarticEaseOut,
		QuarticEaseOutIn,
		QuinticEaseIn,
		QuinticEaseInOut,
		QuinticEaseOut,
		QuinticEaseOutIn,
		SineEaseIn,
		SineEaseInOut,
		SineEaseOut,
		SineEaseOutIn,
	}
}