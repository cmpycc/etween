using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class Vector2Tween : Tween<Vector2>
    {
        public Vector2Tween(object owner, Func<Vector2> getter, Action<Vector2> setter, Vector2 endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Vector2 Interpolate(float time)
        {
            return Vector2.LerpUnclamped(initialValue, endValue, time);
        }
    }
}