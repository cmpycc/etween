using System;
using UnityEngine;

namespace cmpy.Tween
{
    public class FloatTween : Tween<float>
    {
        public FloatTween(object owner, Func<float> getter, Action<float> setter, float endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override float Interpolate(float time)
        {
            return Mathf.LerpUnclamped(initialValue, endValue, time);
        }
    }
}