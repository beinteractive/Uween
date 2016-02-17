using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Uween
{
	[CustomEditor(typeof(Preview))]
	public class PreviewEditor : Editor
	{
		static Dictionary<object, PreviewPlayer> livePlayers = new Dictionary<object, PreviewPlayer>();

		PreviewPlayer player;

		void OnEnable()
		{
			livePlayers.TryGetValue(target, out player);
			RegisterPlayerEvents();
		}

		void OnDisable()
		{
			UnregisterPlayerEvents();
		}

		void OnDestroy()
		{
			UnregisterPlayerEvents();
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			using (new GUILayout.VerticalScope()) {

				GUILayout.Space(10);

				using (new EditorGUI.DisabledGroupScope(player != null)) {
					if (GUILayout.Button("Play")) {
						Play();
					}
				}

				GUILayout.Space(10);
			}

			serializedObject.ApplyModifiedProperties();
		}

		void Play()
		{
			EditorUpdate(() => {
				player = new PreviewPlayer(((Preview)target).gameObject);
				player.Play((g) => {
					TweenX.Add(g, 1f, 200f).EaseOutQuart();
				});
				RegisterPlayerEvents();
				livePlayers.Add(target, player);
			});
		}

		void RegisterPlayerEvents()
		{
			if (player != null) {
				player.OnStop += OnPlayerStop;
			}
		}

		void UnregisterPlayerEvents()
		{
			if (player != null) {
				player.OnStop -= OnPlayerStop;
			}
		}

		void OnPlayerStop()
		{
			EditorUpdate(() => {
				player = null;
				livePlayers.Remove(target);
			});
		}

		void EditorUpdate(System.Action f)
		{
			f();
			Repaint();
		}
	}

	internal class PreviewPlayer
	{
		public PreviewPlayer(GameObject g)
		{
			gameObject = g;
		}

		public GameObject gameObject { get; private set; }
		public bool isPlaying { get; private set; }
		public event Callback OnStop;
		
		double startTime;
		Tween[] tweens;

		Vector3 savedPosition;
		Vector3 savedScale;
		Quaternion savedRotation;

		public void Play(System.Action<GameObject> f)
		{
			isPlaying = true;
			Save(gameObject);
			f(gameObject);
			tweens = gameObject.GetComponentsInChildren<Tween>();
			startTime = EditorApplication.timeSinceStartup;
			EditorApplication.update += Update;
			Update();
		}

		public void Stop()
		{
			isPlaying = false;
			EditorApplication.update -= Update;
			foreach (var t in tweens) {
				Object.DestroyImmediate(t);
			}
			tweens = null;
			Restore(gameObject);
			if (OnStop != null) {
				var callback = OnStop;
				OnStop = null;
				callback();
			}
		}

		void Update()
		{
			var elapsed = (float)(EditorApplication.timeSinceStartup - startTime);
			var finished = true;
			foreach (var t in tweens) {
				if (t.enabled) {
					finished = false;
					t.Update(elapsed);
				}
			}
			if (finished) {
				Stop();
			}
		}

		void Save(GameObject g)
		{
			savedPosition = g.transform.localPosition;
			savedScale = g.transform.localScale;
			savedRotation = g.transform.localRotation;
		}

		void Restore(GameObject g)
		{
			g.transform.localPosition = savedPosition;
			g.transform.localScale = savedScale;
			g.transform.localRotation = savedRotation;
		}
	}
}