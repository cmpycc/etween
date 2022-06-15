using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cmpy.Tween
{
    /// <summary>
    /// Singleton responsible for processing all of the tweens.
    /// </summary>
    /// <remarks>
    /// TweenEngine should initialize itself automatically.
    /// There should not be more than one instance of TweenEngine.
    /// </remarks>
    public class TweenEngine : MonoBehaviour
    {
        private List<ITween> activeTweens = new List<ITween>();

        /// <summary>
        /// Returns the current instance of TweenEngine.
        /// </summary>
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
                tween.Update(tween.ShouldUseUnscaledUpdate ? Time.unscaledDeltaTime : Time.deltaTime);
            }

            activeTweens.RemoveAll(tween => tween.Finished);
        }

        public void AddTween(ITween tween)
        {
            activeTweens.Add(tween);
        }
    }
}