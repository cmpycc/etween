using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cmpy.Tween
{
    public class TweenEngine : MonoBehaviour
    {
        private List<ITween> activeTweens = new();

        public static TweenEngine Instance
        {
            get
            {
                TweenEngine found = FindObjectOfType<TweenEngine>();
                if (found) return found;

                GameObject engineObj = new GameObject("TweenEngine");
                TweenEngine engine = engineObj.AddComponent<TweenEngine>();
                DontDestroyOnLoad(engineObj);

                return engine;
            }
        }

        private void Update()
        {
            foreach (ITween tween in activeTweens)
            {
                tween.Update(Time.deltaTime);
            }

            activeTweens.RemoveAll(tween => tween.Finished);
        }

        public void AddTween(ITween tween)
        {
            activeTweens.Add(tween);
        }
    }
}