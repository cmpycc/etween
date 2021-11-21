using UnityEngine;
using System.Collections;
using System;

namespace cmpy.Tween
{
    public class Vector2IntTween : Tween<Vector2Int>
    {
        public Vector2IntTween(object owner, Func<Vector2Int> getter, Action<Vector2Int> setter, Vector2Int endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override Vector2Int Interpolate(float time)
        {
            return new Vector2Int(
                Mathf.RoundToInt(Mathf.LerpUnclamped(initialValue.x, endValue.x, time)),
                Mathf.RoundToInt(Mathf.LerpUnclamped(initialValue.y, endValue.y, time))
            );
        }
    }
}