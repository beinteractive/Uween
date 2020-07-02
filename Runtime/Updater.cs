using System.Collections.Generic;
using UnityEngine;

namespace Uween
{
    public class Updater : MonoBehaviour
    {
        public static Updater Instance { get; private set; }

        public static Updater Ensure()
        {
            if (Instance == null)
            {
                var g = new GameObject("Uween Updater");
                Instance = g.AddComponent<Updater>();
                DontDestroyOnLoad(g);
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

        private void Update()
        {
            var t = First;
            var prev = (Tween) null;
            var dt = Time.deltaTime;

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
        }
    }
}