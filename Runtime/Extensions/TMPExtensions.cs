#if TMP_INCLUDED
using System;
using TMPro;
using UnityEngine;

namespace cmpy.Tween
{
    public static class TMPExtensions
    {
        public static FloatTween TFontSize(this TMP_Text text, float endValue, float duration)
        {
            FloatTween tween = new(
                text,
                () => text.fontSize,
                (value) => text.fontSize = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static ColorTween TColor(this TMP_Text text, Color endValue, float duration)
        {
            ColorTween tween = new(
                text,
                () => text.color,
                (value) => text.color = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static VertexGradientTween TGradient(this TMP_Text text, VertexGradient endValue, float duration)
        {
            VertexGradientTween tween = new(
                text,
                () => text.colorGradient,
                (value) => text.colorGradient = value, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static FloatTween TAlpha(this TMP_Text text, float endValue, float duration)
        {
            FloatTween tween = new FloatTween(
                text,
                () => text.color.a,
                (value) =>
                {
                    Color color = text.color;
                    color.a = value;
                    text.color = color;
                }, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }
    }
}
#endif