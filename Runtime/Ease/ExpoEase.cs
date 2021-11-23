using System;

#if NET_STANDARD_2_0
using MathF = UnityEngine.Mathf;
#endif

namespace cmpy.Tween
{
    public class ExpoEase : Ease
    {
        public override float ComputeIn(float time)
        {
            return time == 0.0f ? 0.0f : MathF.Pow(1024.0f, time - 1f);
        }

        public override float ComputeOut(float time)
        {
            return time == 1.0f ? 1.0f : 1.0f - MathF.Pow(2.0f, -10.0f * time);
        }

        public override float ComputeInOut(float time)
        {
            //return time == 0.0f ? 1.0f : 1.0f - Mathf.Pow(2.0f, -10.0f * time);
            if (time == 0.0f) return 0f;
            else if (time == 1.0f) return 1f;
            else if ((time *= 2.0f) < 1.0f) return 0.5f * MathF.Pow(1024.0f, time - 1.0f);
            else return 0.5f * (-MathF.Pow(2f, -10f * (time - 1.0f)) + 2.0f);
        }
    }
}