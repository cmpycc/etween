using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class Color32Tween : Tween<Color32>
    {
        public Color32Tween(object owner, Func<Color32> getter, Action<Color32> setter, Color32 endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Color32 Interpolate(float time)
        {
            return Color32.LerpUnclamped(initialValue, endValue, time);
        }
    }
}
