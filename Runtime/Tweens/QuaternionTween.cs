using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class QuaternionTween : Tween<Quaternion>
    {
        public QuaternionTween(object owner, Func<Quaternion> getter, Action<Quaternion> setter, Quaternion endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Quaternion Interpolate(float time)
        {
            // TODO: Provide the option to use both Slerp and Lerp?
            return Quaternion.SlerpUnclamped(initialValue, endValue, time);
        }
    }
}
