using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cmpy.Tween
{
    public static class RectTransformExtensions
    {
        public static Vector2Tween TAnchoredPosition(this RectTransform transform, Vector2 endValue, float duration)
        {
            Vector2Tween tween = new Vector2Tween(
                transform,
                () => transform.anchoredPosition,
                (value) => transform.anchoredPosition = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static Vector3Tween TAnchoredPosition3D(this RectTransform transform, Vector3 endValue, float duration)
        {
            Vector3Tween tween = new Vector3Tween(
                transform,
                () => transform.anchoredPosition3D,
                (value) => transform.anchoredPosition3D = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static Vector2Tween TSizeDelta(this RectTransform transform, Vector2 endValue, float duration)
        {
            Vector2Tween tween = new Vector2Tween(
                transform,
                () => transform.sizeDelta,
                (value) => transform.sizeDelta = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }
    }
}