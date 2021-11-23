using System;

#if NET_STANDARD_2_0
using MathF = UnityEngine.Mathf;
#endif

namespace cmpy.Tween
{
    public class SineEase : Ease
    {
        public override float ComputeIn(float time)
        {
            return 1.0f - MathF.Cos(time * MathF.PI / 2.0f);
        }

        public override float ComputeOut(float time)
        {
            return MathF.Sin(time * MathF.PI / 2.0f);
        }

        public override float ComputeInOut(float time)
        {
            return 0.5f * (1.0f - MathF.Cos(MathF.PI * time));
        }
    }
}