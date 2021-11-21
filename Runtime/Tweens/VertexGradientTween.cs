#if TMP_INCLUDED
using System;
using TMPro;
using UnityEngine;

namespace cmpy.Tween
{
    public class VertexGradientTween : Tween<VertexGradient>
    {
        public VertexGradientTween(object owner, Func<VertexGradient> getter, Action<VertexGradient> setter, VertexGradient endValue, float duration) : base(owner, getter, setter, endValue, duration)
        {
        }

        protected override VertexGradient Interpolate(float time)
        {
            return new VertexGradient(
                Color.LerpUnclamped(initialValue.topLeft, endValue.topLeft, time),
                Color.LerpUnclamped(initialValue.topRight, endValue.topRight, time),
                Color.LerpUnclamped(initialValue.bottomLeft, endValue.bottomLeft, time),
                Color.LerpUnclamped(initialValue.bottomRight, endValue.bottomRight, time)
            );
        }
    }
}
#endif