using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class Vector3IntTween : Tween<Vector3Int>
    {
        public Vector3IntTween(object owner, Func<Vector3Int> getter, Action<Vector3Int> setter, Vector3Int endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Vector3Int Interpolate(float time)
        {
            return new Vector3Int(
                Mathf.RoundToInt(Mathf.LerpUnclamped(initialValue.x, endValue.x, time)),
                Mathf.RoundToInt(Mathf.LerpUnclamped(initialValue.y, endValue.y, time)),
                Mathf.RoundToInt(Mathf.LerpUnclamped(initialValue.z, endValue.z, time))
            );
        }
    }
}