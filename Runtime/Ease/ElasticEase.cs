using System;

namespace cmpy.Tween
{
    public class ElasticEase : Ease
    {
        public override float ComputeIn(float time)
        {
            if (time == 0.0f) return 0.0f;
            else if (time == 1.0f) return 1.0f;
            else return -MathF.Pow(2.0f, 10.0f * (time -= 1.0f)) * MathF.Sin((time - 0.1f) * (2.0f * MathF.PI) / 0.4f);
        }

        public override float ComputeOut(float time)
        {
            if (time == 0.0f) return 0.0f;
            else if (time == 1.0f) return 1.0f;
            else return MathF.Pow(2.0f, -10.0f * time) * MathF.Sin((time - 0.1f) * (2.0f * MathF.PI) / 0.4f) + 1.0f;
        }

        public override float ComputeInOut(float time)
        {
            if ((time *= 2.0f) < 1.0f) return -0.5f * MathF.Pow(2.0f, 10.0f * (time -= 1.0f)) * MathF.Sin((time - 0.1f) * (2.0f * MathF.PI) / 0.4f);
            return MathF.Pow(2.0f, -10.0f * (time -= 1.0f)) * MathF.Sin((time - 0.1f) * (2.0f * MathF.PI) / 0.4f) * 0.5f + 1.0f;
        }
    }
}