using System;

#if NET_STANDARD_2_0
using MathF = UnityEngine.Mathf;
#endif

namespace cmpy.Tween
{
    public class CircularEase : Ease
    {
        public override float ComputeIn(float time)
        {
            return 1f - MathF.Sqrt(1.0f - time * time);
        }

        public override float ComputeOut(float time)
        {
            return MathF.Sqrt(1.0f - ((time -= 1.0f) * time));
        }

        public override float ComputeInOut(float time)
        {
            if ((time *= 2.0f) < 1.0f) return -0.5f * (MathF.Sqrt(1.0f - time * time) - 1.0f);
            else return 0.5f * (MathF.Sqrt(1.0f - (time -= 2.0f) * time) + 1.0f);
        }
    }
}