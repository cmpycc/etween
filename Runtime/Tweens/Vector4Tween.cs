using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class Vector4Tween : Tween<Vector4>
    {
        public Vector4Tween(object owner, Func<Vector4> getter, Action<Vector4> setter, Vector4 endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Vector4 Interpolate(float time)
        {
            return Vector4.LerpUnclamped(initialValue, endValue, time);
        }
    }
}