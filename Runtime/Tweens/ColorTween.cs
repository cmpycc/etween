using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class ColorTween : Tween<Color>
    {
        public ColorTween(object owner, Func<Color> getter, Action<Color> setter, Color endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Color Interpolate(float time)
        {
            return Color.LerpUnclamped(initialValue, endValue, time);
        }
    }
}
