using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Uween
{
	public class Preview : MonoBehaviour
	{
		[SerializeField]
		public float delay = 0f;

		[SerializeField]
		public float duration = 0.3f;

		[SerializeField]
		public EasingEnum easing = EasingEnum.LinearEaseNone;

		[SerializeField]
		public List<PreviewSetting> settings = new List<PreviewSetting>();

		[SerializeField]
		public float cooldown = 0.5f;

		[SerializeField]
		public List<Preview> next = new List<Preview>();
		public bool hasNext { get { return nextEnabled && next != null && next.Count > 0; } }

		[SerializeField]
		public bool nextEnabled = true;

		[SerializeField]
		public bool commonFoldout = true;
		[SerializeField]
		public bool settingsFoldout = true;
		[SerializeField]
		public bool controlsFoldout = true;

		public void CreateTweens(GameObject g)
		{
			if (settings != null) {
				foreach (var s in settings) {
					s.Create(g, this);
				}
			}
		}
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

	public enum TweenTypeEnum
	{
		TweenP,
		TweenP3,
		TweenX,
		TweenXY,
		TweenXYZ,
		TweenXZ,
		TweenY,
		TweenYZ,
		TweenZ,
		TweenS,
		TweenS3,
		TweenSX,
		TweenSXY,
		TweenSXYZ,
		TweenSXZ,
		TweenSY,
		TweenSYZ,
		TweenSZ,
		TweenR,
		TweenR3,
		TweenRX,
		TweenRXY,
		TweenRXYZ,
		TweenRXZ,
		TweenRY,
		TweenRYZ,
		TweenRZ,
		TweenA,
		TweenC,
		TweenCA,
		TweenFillAmount,
	}

	public static class TweenTypeEnumExtension
	{
		public static bool IsTweenVec1(this TweenTypeEnum type)
		{
			return type.AsType().IsSubclassOf(typeof(TweenVec1));
		}

		public static bool IsTweenVec2(this TweenTypeEnum type)
		{
			return type.AsType().IsSubclassOf(typeof(TweenVec2));
		}

		public static bool IsTweenVec3(this TweenTypeEnum type)
		{
			return type.AsType().IsSubclassOf(typeof(TweenVec3));
		}

		public static bool IsTweenVec4(this TweenTypeEnum type)
		{
			return type.AsType().IsSubclassOf(typeof(TweenVec4));
		}

		public static System.Type AsType(this TweenTypeEnum type)
		{
			switch (type) {
			case TweenTypeEnum.TweenA: return typeof(TweenA);
			case TweenTypeEnum.TweenC: return typeof(TweenC);
			case TweenTypeEnum.TweenCA: return typeof(TweenCA);
			case TweenTypeEnum.TweenFillAmount: return typeof(TweenFillAmount);
			case TweenTypeEnum.TweenP: return typeof(TweenP);
			case TweenTypeEnum.TweenP3: return typeof(TweenP3);
			case TweenTypeEnum.TweenR: return typeof(TweenR);
			case TweenTypeEnum.TweenR3: return typeof(TweenR3);
			case TweenTypeEnum.TweenRX: return typeof(TweenRX);
			case TweenTypeEnum.TweenRXY: return typeof(TweenRXY);
			case TweenTypeEnum.TweenRXYZ: return typeof(TweenRXYZ);
			case TweenTypeEnum.TweenRXZ: return typeof(TweenRXZ);
			case TweenTypeEnum.TweenRY: return typeof(TweenRY);
			case TweenTypeEnum.TweenRYZ: return typeof(TweenRYZ);
			case TweenTypeEnum.TweenRZ: return typeof(TweenRZ);
			case TweenTypeEnum.TweenS: return typeof(TweenS);
			case TweenTypeEnum.TweenS3: return typeof(TweenS3);
			case TweenTypeEnum.TweenSX: return typeof(TweenSX);
			case TweenTypeEnum.TweenSXY: return typeof(TweenSXY);
			case TweenTypeEnum.TweenSXYZ: return typeof(TweenSXYZ);
			case TweenTypeEnum.TweenSXZ: return typeof(TweenSXZ);
			case TweenTypeEnum.TweenSY: return typeof(TweenSY);
			case TweenTypeEnum.TweenSYZ: return typeof(TweenSYZ);
			case TweenTypeEnum.TweenSZ: return typeof(TweenSZ);
			case TweenTypeEnum.TweenX: return typeof(TweenX);
			case TweenTypeEnum.TweenXY: return typeof(TweenXY);
			case TweenTypeEnum.TweenXYZ: return typeof(TweenXYZ);
			case TweenTypeEnum.TweenXZ: return typeof(TweenXZ);
			case TweenTypeEnum.TweenY: return typeof(TweenY);
			case TweenTypeEnum.TweenYZ: return typeof(TweenYZ);
			case TweenTypeEnum.TweenZ: return typeof(TweenZ);
			}
			return null;
		}
	}
}