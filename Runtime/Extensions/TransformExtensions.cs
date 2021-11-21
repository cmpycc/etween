using UnityEngine;
using System.Collections;

namespace cmpy.Tween
{
    public static class TransformExtensions
    {
        public static Vector3Tween TPosition(this Transform transform, Vector3 endValue, float duration)
        {
            Vector3Tween tween = new(
                transform,
                () => transform.position,
                (value) => transform.position = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static Vector3Tween TLocalPosition(this Transform transform, Vector3 endValue, float duration)
        {
            Vector3Tween tween = new(
                transform,
                () => transform.localPosition,
                (value) => transform.localPosition = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static QuaternionTween TRotation(this Transform transform, Quaternion endValue, float duration)
        {
            QuaternionTween tween = new(
                transform,
                () => transform.rotation,
                (value) => transform.rotation = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static QuaternionTween TLocalRotation(this Transform transform, Quaternion endValue, float duration)
        {
            QuaternionTween tween = new(
                transform,
                () => transform.localRotation,
                (value) => transform.localRotation = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static Vector3Tween TLocalScale(this Transform transform, Vector3 endValue, float duration)
        {
            Vector3Tween tween = new(
                transform,
                () => transform.localScale,
                (value) => transform.localScale = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }
    }
}