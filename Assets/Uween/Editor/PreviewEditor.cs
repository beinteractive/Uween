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
			if ((p.commonFoldout = EditorGUILayout.Foldout(p.commonFoldout, "Common"))) {
				{
					var d = p.delay;
					EditScope(p,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Delay");
								d = EditorGUILayout.FloatField(d);
							}
						},
						() => {
							p.delay = d;
						}
					);
				}
				{
					var d = p.duration;
					EditScope(p,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Duration");
								d = EditorGUILayout.FloatField(d);
							}
						},
						() => {
							p.duration = d;
						}
					);
				}
				{
					var e = p.easing;
					EditScope(p,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Easing");
								e = (EasingEnum)EditorGUILayout.EnumPopup(e);
							}
						},
						() => {
							p.easing = e;
						}
					);
				}
			}
		}

		void DrawPreviewSettings(Preview p)
		{
			if ((p.settingsFoldout = EditorGUILayout.Foldout(p.settingsFoldout, "Tweens"))) {
				var settings = p.settings;
				if (settings != null) {
					var isEmpty = settings.Count == 0;
					for (var i = 0; i <= settings.Count; ++i) {
						if (i < settings.Count) {
							DrawSettingElement(settings[i], i);
						}
						if (i < settings.Count || isEmpty) {
							DrawSettingControl(settings, ref i, isEmpty);
						}
						if (i < settings.Count - 1 || isEmpty) {
							EditorGUILayout.Space();
							EditorGUILayout.Space();
						}
					}
				}
			}
		}

		void DrawSettingElement(PreviewSetting s, int i)
		{
			{
				var b = s.enabled;
				var t = s.type;
				EditScope(s,
					() => {
						using (new GUILayout.HorizontalScope()) {
							EditorGUILayout.PrefixLabel(string.Format("Tween #{0} Type", i + 1));
							b = EditorGUILayout.Toggle(b);
							using (new EditorGUI.DisabledGroupScope(!b)) {
								t = (TweenTypeEnum)EditorGUILayout.EnumPopup(t);
							}
						}
					},
					() => {
						s.enabled = b;
						s.type = t;
					}
				);
			}
			using (new EditorGUI.DisabledGroupScope(!s.enabled)) {
				{
					var b = s.delayOverride;
					var d = s.delay;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Delay");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									d = EditorGUILayout.FloatField(d);
								}
							}
						},
						() => {
							s.delayOverride = b;
							s.delay = d;
						}
					);
				}
				{
					var b = s.durationOverride;
					var d = s.duration;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Duration");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									d = EditorGUILayout.FloatField(d);
								}
							}
						},
						() => {
							s.durationOverride = b;
							s.duration = d;
						}
					);
				}
				{
					var b = s.easingOverride;
					var e = s.easing;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Easing");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									e = (EasingEnum)EditorGUILayout.EnumPopup(e);
								}
							}
						},
						() => {
							s.easingOverride = b;
							s.easing = e;
						}
					);
				}
				if (s.type.IsTweenVec1()) {
					var b = s.toEnabled;
					var x = s.to.x;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("To");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									x = EditorGUILayout.FloatField(x);
								}
							}
						},
						() => {
							s.toEnabled = b;
							s.to.x = x;
						}
					);
				}
				if (s.type.IsTweenVec2()) {
					var b = s.toEnabled;
					var x = s.to.x;
					var y = s.to.y;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("To");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									using (new EditorGUILayout.HorizontalScope()) {
										x = EditorGUILayout.FloatField(x);
										y = EditorGUILayout.FloatField(y);
									}
								}
							}
						},
						() => {
							s.toEnabled = b;
							s.to.x = x;
							s.to.y = y;
						}
					);
				}
				if (s.type.IsTweenVec3()) {
					var b = s.toEnabled;
					var x = s.to.x;
					var y = s.to.y;
					var z = s.to.z;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("To");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									using (new EditorGUILayout.HorizontalScope()) {
										x = EditorGUILayout.FloatField(x);
										y = EditorGUILayout.FloatField(y);
										z = EditorGUILayout.FloatField(z);
									}
								}
							}
						},
						() => {
							s.toEnabled = b;
							s.to.x = x;
							s.to.y = y;
							s.to.z = z;
						}
					);
				}
				if (s.type.IsTweenVec4()) {
					var b = s.toEnabled;
					var x = s.to.x;
					var y = s.to.y;
					var z = s.to.z;
					var w = s.to.w;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("To");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									using (new EditorGUILayout.HorizontalScope()) {
										x = EditorGUILayout.FloatField(x);
										y = EditorGUILayout.FloatField(y);
										z = EditorGUILayout.FloatField(z);
										w = EditorGUILayout.FloatField(w);
									}
								}
							}
						},
						() => {
							s.toEnabled = b;
							s.to.x = x;
							s.to.y = y;
							s.to.z = z;
							s.to.w = w;
						}
					);
				}
				{
					var b = s.toRelative;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("To Relative");
								b = EditorGUILayout.Toggle(b);
							}
						},
						() => {
							s.toRelative = b;
						}
					);
				}
				if (s.type.IsTweenVec1()) {
					var b = s.fromEnabled;
					var x = s.from.x;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("From");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									x = EditorGUILayout.FloatField(x);
								}
							}
						},
						() => {
							s.fromEnabled = b;
							s.from.x = x;
						}
					);
				}
				if (s.type.IsTweenVec2()) {
					var b = s.fromEnabled;
					var x = s.from.x;
					var y = s.from.y;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("From");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									x = EditorGUILayout.FloatField(x);
									y = EditorGUILayout.FloatField(y);
								}
							}
						},
						() => {
							s.fromEnabled = b;
							s.from.x = x;
							s.from.y = y;
						}
					);
				}
				if (s.type.IsTweenVec3()) {
					var b = s.fromEnabled;
					var x = s.from.x;
					var y = s.from.y;
					var z = s.from.z;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("From");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									x = EditorGUILayout.FloatField(x);
									y = EditorGUILayout.FloatField(y);
									z = EditorGUILayout.FloatField(z);
								}
							}
						},
						() => {
							s.fromEnabled = b;
							s.from.x = x;
							s.from.y = y;
							s.from.z = z;
						}
					);
				}
				if (s.type.IsTweenVec4()) {
					var b = s.fromEnabled;
					var x = s.from.x;
					var y = s.from.y;
					var z = s.from.z;
					var w = s.from.w;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("From");
								b = EditorGUILayout.Toggle(b);
								using (new EditorGUI.DisabledGroupScope(!b)) {
									x = EditorGUILayout.FloatField(x);
									y = EditorGUILayout.FloatField(y);
									z = EditorGUILayout.FloatField(z);
									w = EditorGUILayout.FloatField(w);
								}
							}
						},
						() => {
							s.fromEnabled = b;
							s.from.x = x;
							s.from.y = y;
							s.from.z = z;
							s.from.w = w;
						}
					);
				}
				{
					var b = s.fromRelative;
					EditScope(s,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("From Relative");
								b = EditorGUILayout.Toggle(b);
							}
						},
						() => {
							s.fromRelative = b;
						}
					);
				}
			}
		}

		void DrawSettingControl(List<PreviewSetting> settings, ref int i, bool isEmpty)
		{
			using (new GUILayout.HorizontalScope()) {
				EditorGUILayout.Space();
				if (GUILayout.Button("+")) {
					Undo.RecordObject(target, "Add Setting");
					settings.Insert(isEmpty ? 0 : i + 1, ScriptableObject.CreateInstance<PreviewSetting>());
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

			if ((p.controlsFoldout = EditorGUILayout.Foldout(p.controlsFoldout, "Control"))) {
				
				using (new GUILayout.HorizontalScope()) {
					if (player == null) {
						using (new EditorGUI.DisabledGroupScope(!p.hasSettings)) {
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

				{
					var c = p.cooldown;
					EditScope(p,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Cooldown");
								c = EditorGUILayout.FloatField(c);
							}
						},
						() => {
							p.cooldown = c;
						}
					);
				}
				{
					var b = p.nextEnabled;
					EditScope(p,
						() => {
							using (new GUILayout.HorizontalScope()) {
								EditorGUILayout.PrefixLabel("Next Enabled");
								b = EditorGUILayout.Toggle(b);
							}
						},
						() => {
							p.nextEnabled = b;
						}
					);
				}
				using (new EditorGUI.DisabledGroupScope(!p.nextEnabled)) {
					using (new GUILayout.HorizontalScope()) {
						EditorGUILayout.PropertyField(serializedObject.FindProperty("next"), true);
					}
				}
			}

			EditorGUILayout.Space();

			using (new EditorGUI.DisabledGroupScope(!p.hasSettings)) {
				if (GUILayout.Button("Copy Script")) {
					EditorGUIUtility.systemCopyBuffer = p.GenerateScript(p.gameObject.name);
				}
			}
		}

		void Play()
		{
			Play(null);
		}

		void Play(PreviewPlayer parent)
		{
			EditorUpdate(() => {
				var p = (Preview)target;
				player = new PreviewPlayer(p.gameObject);
				player.parent = parent;
				player.cooldown = p.hasNext ? 0f : p.cooldown;
				player.Play((g) => {
					p.CreateTweens(g);
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

		void OnPlayerStop(bool finished)
		{
			var p = (Preview)target;
			if (finished && p.hasNext) {
				foreach (var next in p.next) {
					var editor = (Editor)null;
					Editor.CreateCachedEditor(next, typeof(PreviewEditor), ref editor);
					if (editor != null) {
						((PreviewEditor)editor).Play(player);
					}
				}
			} else {
				if (player != null) {
					player.Cleanup();
				}
			}
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

		public float cooldown { get; set; }

		public PreviewPlayer parent { get; set; }

		public event System.Action OnUpdate;
		public event System.Action<bool> OnStop;

		double startTime;
		double finishTime;
		Tween[] tweens;

		int playingChildren;

		Vector3 savedPosition;
		Vector3 savedScale;
		Quaternion savedRotation;

		public void Play(System.Action<GameObject> f)
		{
			isPlaying = true;
			if (parent != null) {
				parent.ChildStart();
			}
			Save(gameObject);
			f(gameObject);
			tweens = gameObject.GetComponentsInChildren<Tween>();
			foreach (var t in tweens) {
				t.hideFlags = HideFlags.HideAndDontSave;
			}
			startTime = EditorApplication.timeSinceStartup;
			finishTime = 0.0;
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
			finishTime = 0.0;
			EditorApplication.update -= Update;
			foreach (var t in tweens) {
				Object.DestroyImmediate(t);
			}
			tweens = null;
			OnUpdate = null;
			if (OnStop != null) {
				var callback = OnStop;
				OnStop = null;
				callback(startTime != 0f);
			}
			if (parent != null) {
				parent.ChildStop();
			}
		}

		public void Cleanup()
		{
			Restore(gameObject);
		}

		void Update()
		{
			if (finishTime > 0.0) {
				if (EditorApplication.timeSinceStartup >= finishTime) {
					Stop();
				}
			} else {
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
						finishTime = EditorApplication.timeSinceStartup + (double)cooldown;
					}
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

		void ChildStart()
		{
			++playingChildren;
		}

		void ChildStop()
		{
			if (--playingChildren <= 0) {
				Cleanup();
			}
		}
	}
}