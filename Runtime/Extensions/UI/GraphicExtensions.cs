using System;
using UnityEngine;
using UnityEngine.UI;

namespace cmpy.Tween {
    public static class GraphicsExtensions
    {
        public static ColorTween TColor(this Graphic image, Color endValue, float duration)
        {
            ColorTween tween = new(
                image,
                () => image.color,
                (value) => image.color = value,
                endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }

        public static FloatTween TAlpha(this Graphic graphic, float endValue, float duration)
        {
            FloatTween tween = new(
                graphic,
                () => graphic.color.a,
                (value) =>
                {
                    Color color = graphic.color;
                    color.a = value;
                    graphic.color = color;
                }, endValue, duration);
            TweenEngine.Instance.AddTween(tween);
            return tween;
        }
    }
}

