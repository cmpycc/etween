using System;

using UnityEngine;
using UnityEngine.UI;

namespace cmpy.Tween
{
    public static class CanvasGroupExtensions
    {
        public static FloatTween TAlpha(this CanvasGroup canvasGroup, float endValue, float duration)
        {
            FloatTween tween = new FloatTween(
                canvasGroup,
                () => canvasGroup.alpha,
                (value) => canvasGroup.alpha = value,
                endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }
    }
}
