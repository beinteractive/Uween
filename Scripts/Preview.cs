using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

		public bool hasSettings { get { return settings != null && settings.Count > 0; } }

		[SerializeField]
		public float cooldown = 0.5f;

		[SerializeField]
		public List<Preview> link = new List<Preview>();

		public bool hasLink { get { return linkEnabled && link != null && link.Count > 0; } }

		[SerializeField]
		public bool linkEnabled = true;

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

		public List<Tween> CreateTweens(GameObject g)
		{
			var result = new List<Tween>();
			if (settings != null) {
				foreach (var s in settings) {
					var t = s.Create(g, this);
					if (t != null) {
						result.Add(t);
					}
				}
			}
			return result;
		}

		public string GenerateScript(string name)
		{
			return GenerateScript(name, "");
		}

		public string GenerateScript(string name, string indent)
		{
			var s = "";
			var settings = new List<PreviewSetting>(this.settings.Where((e) => e.enabled));
			settings.Sort((a, b) => (int)(a.GetTotalDuration(delay, duration) - b.GetTotalDuration(delay, duration)));
			for (var i = 0; i < settings.Count; ++i) {
				var setting = settings[i];
				var type = setting.type;
				s += indent;
				s += type.ToString();
				s += string.Format(".Add({0}, {1}f", name, setting.GetDuration(duration));
				if (setting.toEnabled) {
					s += ", ";
					s += VectorToString(type, setting.to);
					s += ")";
					if (setting.toRelative) {
						s += ".Relative()";
					}
				} else {
					s += ")";
				}
				if (setting.fromEnabled) {
					if (setting.fromRelative) {
						s += ".FromRelative(" + VectorToString(type, setting.from) + ")";
					} else {
						s += ".From(" + VectorToString(type, setting.from) + ")";
					}
				}
				var delay = setting.GetDelay(this.delay);
				if (delay > 0f) {
					s += string.Format(".Delay({0}f)", delay);
				}
				var e = setting.GetEasing(easing);
				if (e != EasingEnum.LinearEaseNone) {
					s += "." + e.ToString() + "()";
				}
				if (i == settings.Count - 1 && hasNext) {
					s += ".Then(() => {\n";
					foreach (var n in next) {
						s += n.GenerateScript(name, indent + "\t");
					}
					s += "})";
				}
				s += ";\n";
			}
			if (hasLink) {
				foreach (var l in link) {
					s += l.GenerateScript(name, indent);
				}
			}
			return s;
		}

		string VectorToString(TweenTypeEnum type, Vector4 v)
		{
			if (type.IsTweenVec1()) {
				return string.Format("{0}f", v.x);
			}
			if (type.IsTweenVec2()) {
				if (v.x == v.y) {
					return string.Format("{0}f", v.x);
				} else {
					return string.Format("{0}f, {1}f", v.x, v.y);
				}
			}
			if (type.IsTweenVec3()) {
				if (v.x == v.y && v.y == v.z) {
					return string.Format("{0}f", v.x);
				} else {
					return string.Format("{0}f, {1}f, {2}f", v.x, v.y, v.z);
				}
			}
			if (type.IsTweenVec4()) {
				if (v.x == v.y && v.y == v.z && v.z == v.w) {
					return string.Format("{0}f", v.x);
				} else {
					return string.Format("{0}f, {1}f, {2}f, {3}f", v.x, v.y, v.z, v.w);
				}
			}
			return "";
		}
	}

	public enum EasingEnum
	{
		LinearEaseNone,
		EaseInBack,
		EaseInOutBack,
		EaseOutBack,
		EaseOutInBack,
		EaseInBounce,
		EaseInOutBounce,
		EaseOutBounce,
		EaseOutInBounce,
		EaseInCircular,
		EaseInOutCircular,
		EaseOutCircular,
		EaseOutInCircular,
		EaseInCubic,
		EaseInOutCubic,
		EaseOutCubic,
		EaseOutInCubic,
		EaseInElastic,
		EaseInOutElastic,
		EaseOutElastic,
		EaseOutInElastic,
		EaseInExponential,
		EaseInOutExponential,
		EaseOutExponential,
		EaseOutInExponential,
		EaseInQuadratic,
		EaseInOutQuadratic,
		EaseOutQuadratic,
		EaseOutInQuadratic,
		EaseInQuartic,
		EaseInOutQuartic,
		EaseOutQuartic,
		EaseOutInQuartic,
		EaseInQuintic,
		EaseInOutQuintic,
		EaseOutQuintic,
		EaseOutInQuintic,
		EaseInSine,
		EaseInOutSine,
		EaseOutSine,
		EaseOutInSine,
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
			case TweenTypeEnum.TweenA:
				return typeof(TweenA);
			case TweenTypeEnum.TweenC:
				return typeof(TweenC);
			case TweenTypeEnum.TweenCA:
				return typeof(TweenCA);
			case TweenTypeEnum.TweenFillAmount:
				return typeof(TweenFillAmount);
			case TweenTypeEnum.TweenP:
				return typeof(TweenP);
			case TweenTypeEnum.TweenP3:
				return typeof(TweenP3);
			case TweenTypeEnum.TweenR:
				return typeof(TweenR);
			case TweenTypeEnum.TweenR3:
				return typeof(TweenR3);
			case TweenTypeEnum.TweenRX:
				return typeof(TweenRX);
			case TweenTypeEnum.TweenRXY:
				return typeof(TweenRXY);
			case TweenTypeEnum.TweenRXYZ:
				return typeof(TweenRXYZ);
			case TweenTypeEnum.TweenRXZ:
				return typeof(TweenRXZ);
			case TweenTypeEnum.TweenRY:
				return typeof(TweenRY);
			case TweenTypeEnum.TweenRYZ:
				return typeof(TweenRYZ);
			case TweenTypeEnum.TweenRZ:
				return typeof(TweenRZ);
			case TweenTypeEnum.TweenS:
				return typeof(TweenS);
			case TweenTypeEnum.TweenS3:
				return typeof(TweenS3);
			case TweenTypeEnum.TweenSX:
				return typeof(TweenSX);
			case TweenTypeEnum.TweenSXY:
				return typeof(TweenSXY);
			case TweenTypeEnum.TweenSXYZ:
				return typeof(TweenSXYZ);
			case TweenTypeEnum.TweenSXZ:
				return typeof(TweenSXZ);
			case TweenTypeEnum.TweenSY:
				return typeof(TweenSY);
			case TweenTypeEnum.TweenSYZ:
				return typeof(TweenSYZ);
			case TweenTypeEnum.TweenSZ:
				return typeof(TweenSZ);
			case TweenTypeEnum.TweenX:
				return typeof(TweenX);
			case TweenTypeEnum.TweenXY:
				return typeof(TweenXY);
			case TweenTypeEnum.TweenXYZ:
				return typeof(TweenXYZ);
			case TweenTypeEnum.TweenXZ:
				return typeof(TweenXZ);
			case TweenTypeEnum.TweenY:
				return typeof(TweenY);
			case TweenTypeEnum.TweenYZ:
				return typeof(TweenYZ);
			case TweenTypeEnum.TweenZ:
				return typeof(TweenZ);
			}
			return null;
		}
	}
}