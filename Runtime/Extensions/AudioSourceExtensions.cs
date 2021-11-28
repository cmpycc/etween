using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace cmpy.Tween
{
    public static class AudioSourceExtensions
    {
        public static FloatTween TVolume(this AudioSource audioSource, float endValue, float duration)
        {
            FloatTween tween = new FloatTween(
                audioSource,
                () => audioSource.volume,
                (value) => audioSource.volume = value,
                endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static FloatTween TPitch(this AudioSource audioSource, float endValue, float duration)
        {
            FloatTween tween = new FloatTween(
                audioSource,
                () => audioSource.pitch,
                (value) => audioSource.pitch = value,
                endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static FloatTween TStereoPan(this AudioSource audioSource, float endValue, float duration)
        {
            FloatTween tween = new FloatTween(
                audioSource,
                () => audioSource.panStereo,
                (value) => audioSource.panStereo = value,
                endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static FloatTween TSpatialBlend(this AudioSource audioSource, float endValue, float duration)
        {
            FloatTween tween = new FloatTween(
                audioSource,
                () => audioSource.spatialBlend,
                (value) => audioSource.spatialBlend = value,
                endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }
    }
}
