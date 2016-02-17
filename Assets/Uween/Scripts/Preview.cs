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
		public List<PreviewSetting> settings = new List<PreviewSetting>();
	}
}