using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class Vector3Tween : Tween<Vector3>
    {
        public Vector3Tween(object owner, Func<Vector3> getter, Action<Vector3> setter, Vector3 endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Vector3 Interpolate(float time)
        {
            return Vector3.LerpUnclamped(initialValue, endValue, time);
        }
    }
}