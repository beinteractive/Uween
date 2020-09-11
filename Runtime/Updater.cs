using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Uween
{
    [ExecuteInEditMode]
    public class Updater : MonoBehaviour
    {
        public static Updater Instance { get; private set; }

        public static Updater Ensure()
        {
            if (Instance == null)
            {
                var g = new GameObject("Uween Updater");
                Instance = g.AddComponent<Updater>();
#if UNITY_EDITOR
                g.hideFlags = HideFlags.HideAndDontSave;
#else
                DontDestroyOnLoad(g);
#endif
            }
            
            return Instance;
        }

        private Tween First;

        public T Find<T>(GameObject g) where T : Tween
        {
            var t = First;

            while (t != null)
            {
                if (t.Object == g && t is T found)
                {
                    return found;
                }
                t = t.Next;
            }

            return null;
        }

        public IEnumerable<T> FindAll<T>(GameObject g) where T : Tween
        {
            var t = First;

            while (t != null)
            {
                if (t.Object == g && t is T found)
                {
                    yield return found;
                }
                t = t.Next;
            }
        }

        public T Create<T>(GameObject g) where T : Tween, new()
        {
            var t = new T { Object = g, Next = First };
            First = t;
            return t;
        }
        
#if UNITY_EDITOR

        private double LastTime;
        
        private void OnEnable()
        {
            EditorApplication.update += DoUpdate;
            LastTime = EditorApplication.timeSinceStartup;
        }

        private void OnDisable()
        {
            EditorApplication.update -= DoUpdate;
        }
#else
        private void Update()
        {
            DoUpdate();
        }
#endif

        private void DoUpdate()
        {
            var t = First;
            var prev = (Tween) null;
            var dt = Time.deltaTime;

#if UNITY_EDITOR
            var time = EditorApplication.timeSinceStartup;
            dt = (float)(time - LastTime);
            LastTime = time;
#endif

            while (t != null)
            {
                if (t.Object == null)
                {
                    if (prev == null)
                    {
                        First = t.Next;
                    }
                    else
                    {
                        prev.Next = t.Next;
                    }
                }
                else
                {
                    if (t.Object.activeInHierarchy && t.Enabled)
                    {
                        t.Update(dt);
                    }
                }

                prev = t;
                t = t.Next;
            }

#if UNITY_EDITOR
            SceneView.RepaintAll();
#endif
        }
    }
}