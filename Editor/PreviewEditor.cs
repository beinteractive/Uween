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
			Undo.undoRedoPerformed += OnUndoRedo;
			livePlayers.TryGetValue(target, out player);
			RegisterPlayerEvents();
		}

		void OnDisable()
		{
			Undo.undoRedoPerformed -= OnUndoRedo;
			UnregisterPlayerEvents();
		}

		void OnDestroy()
		{
			Undo.undoRedoPerformed -= OnUndoRedo;
			UnregisterPlayerEvents();
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			using (new GUILayout.VerticalScope()) {
				EditorGUILayout.Space();
				DrawSettings();
				EditorGUILayout.Space();
				EditorGUILayout.Space();
				DrawControls();
				EditorGUILayout.Space();
			}

			serializedObject.ApplyModifiedProperties();
		}

		void DrawSettings()
		{
			var p = (Preview)target;
			DrawPreviewSetting(p);
			EditorGUILayout.Space();
			DrawPreviewSettings(p);
		}

		void DrawPreviewSetting(Preview p)
		{
			using (new GUILayout.HorizontalScope()) {
				EditorGUILayout.PrefixLabel("Duration");
				var d = p.duration;
				EditScope(p,
					() => {
						d = EditorGUILayout.FloatField(d);
					},
					() => {
						p.duration = d;
					}
				);
			}
			using (new GUILayout.HorizontalScope()) {
				EditorGUILayout.PrefixLabel("Easing");
				var e = p.easing;
				EditScope(p,
					() => {
						e = (EasingEnum)EditorGUILayout.EnumPopup(e);
					},
					() => {
						p.easing = e;
					}
				);
			}
		}

		void DrawPreviewSettings(Preview p)
		{
			EditorGUILayout.LabelField("Tweens");
			var settings = p.settings;
			if (settings != null) {
				var isEmpty = settings.Count == 0;
				for (var i = 0; i <= settings.Count; ++i) {
					if (i < settings.Count) {
						DrawSettingElement(settings[i]);
					}
					if (i < settings.Count || isEmpty) {
						DrawSettingControl(settings, ref i, isEmpty);
					}
				}
			}
		}

		void DrawSettingElement(PreviewSetting s)
		{
			using (new GUILayout.HorizontalScope()) {
				var b = s.durationOverride;
				var d = s.duration;
				EditorGUILayout.PrefixLabel("Duration");
				EditScope(s,
					() => {
						b = EditorGUILayout.Toggle(b);
						using (new EditorGUI.DisabledGroupScope(!b)) {
							d = EditorGUILayout.FloatField(d);
						}
					},
					() => {
						s.durationOverride = b;
						s.duration = d;
					}
				);
			}
			using (new GUILayout.HorizontalScope()) {
				var b = s.easingOverride;
				var e = s.easing;
				EditorGUILayout.PrefixLabel("Easing");
				EditScope(s,
					() => {
						b = EditorGUILayout.Toggle(b);
						using (new EditorGUI.DisabledGroupScope(!b)) {
							e = (EasingEnum)EditorGUILayout.EnumPopup(e);
						}
					},
					() => {
						s.easingOverride = b;
						s.easing = e;
					}
				);
			}
			using (new GUILayout.HorizontalScope()) {
				var x = s.x;
				EditorGUILayout.PrefixLabel("X");
				EditScope(s,
					() => {
						x = EditorGUILayout.FloatField(s.x);
					},
					() => {
						s.x = x;
					}
				);
			}
		}

		void DrawSettingControl(List<PreviewSetting> settings, ref int i, bool isEmpty)
		{
			using (new GUILayout.HorizontalScope()) {
				EditorGUILayout.Space();
				if (GUILayout.Button("+")) {
					Undo.RecordObject(target, "Add Setting");
					settings.Insert(i, ScriptableObject.CreateInstance<PreviewSetting>());
					EditorUtility.SetDirty(target);
				}
				using (new EditorGUI.DisabledGroupScope(isEmpty)) {
					if (GUILayout.Button("-")) {
						Undo.RecordObject(target, "Remove Setting");
						settings.RemoveAt(i);
						--i;
						EditorUtility.SetDirty(target);
					}
				}
			}
		}

		void EditScope(Object o, System.Action f, System.Action apply)
		{
			EditScope(o, "Modify Setting", f, apply);
		}

		void EditScope(Object o, string name, System.Action f, System.Action apply)
		{
			EditorGUI.BeginChangeCheck();
			f();
			if (EditorGUI.EndChangeCheck()) {
				Undo.RecordObject(o, name);
				apply();
				EditorUtility.SetDirty(o);
			}
		}

		void DrawControls()
		{
			var p = (Preview)target;
			var settings = p.settings;

			using (new GUILayout.HorizontalScope()) {
				if (player == null) {
					using (new EditorGUI.DisabledGroupScope(settings == null || settings.Count == 0)) {
						if (GUILayout.Button("Play")) {
							Play();
						}
					}
				} else {
					if (player.isPlaying) {
						if (GUILayout.Button("Pause")) {
							player.Pause();
						}
					} else {
						if (GUILayout.Button("Resume")) {
							player.Resume();
						}
					}
				}
				using (new EditorGUI.DisabledGroupScope(player == null)) {
					if (GUILayout.Button("Stop")) {
						player.Skip();
					}
				}
			}

			using (new GUILayout.HorizontalScope()) {
				EditorGUILayout.PrefixLabel("Elapsed Time");
				EditorGUILayout.LabelField(string.Format("{0:###0.00}", player != null ? player.elapsedTime : 0f));
			}
		}

		void CreateTweens(GameObject g)
		{
			var p = (Preview)target;
			var settings = p.settings;
			if (settings != null) {
				foreach (var s in settings) {
					s.Create(g, p.duration, p.easing);
				}
			}
		}

		void Play()
		{
			EditorUpdate(() => {
				player = new PreviewPlayer(((Preview)target).gameObject);
				player.Play((g) => {
					CreateTweens(g);
				});
				RegisterPlayerEvents();
				livePlayers.Add(target, player);
			});
		}

		void RegisterPlayerEvents()
		{
			if (player != null) {
				player.OnUpdate += OnPlayerUpdate;
				player.OnStop += OnPlayerStop;
			}
		}

		void UnregisterPlayerEvents()
		{
			if (player != null) {
				player.OnUpdate -= OnPlayerUpdate;
				player.OnStop -= OnPlayerStop;
			}
		}

		void OnPlayerUpdate()
		{
			EditorUpdate(() => {
			});
		}

		void OnPlayerStop()
		{
			EditorUpdate(() => {
				UnregisterPlayerEvents();
				livePlayers.Remove(target);
				player = null;
			});
		}

		void OnUndoRedo()
		{
			EditorUpdate(() => {
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

		public float elapsedTime { get; private set; }

		public event Callback OnUpdate;
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
			foreach (var t in tweens) {
				t.hideFlags = HideFlags.HideAndDontSave;
			}
			startTime = EditorApplication.timeSinceStartup;
			EditorApplication.update += Update;
			Update();
		}

		public void Pause()
		{
			isPlaying = false;
		}

		public void Resume()
		{
			isPlaying = true;
			startTime = EditorApplication.timeSinceStartup - elapsedTime;
		}

		public void Skip()
		{
			Resume();
			startTime = 0f;
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
			OnUpdate = null;
			if (OnStop != null) {
				var callback = OnStop;
				OnStop = null;
				callback();
			}
		}

		void Update()
		{
			if (isPlaying) {
				elapsedTime = (float)(EditorApplication.timeSinceStartup - startTime);
				var finished = true;
				foreach (var t in tweens) {
					if (t.enabled) {
						finished = false;
						t.Update(elapsedTime);
					}
				}
				if (OnUpdate != null) {
					OnUpdate();
				}
				if (finished) {
					Stop();
				}
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