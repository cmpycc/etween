using System;

namespace cmpy.Tween
{
    public class CubicEase : Ease
    {
        public override float ComputeIn(float time)
        {
            return time * time * time;
        }

        public override float ComputeOut(float time)
        {
            return 1f + ((time -= 1.0f) * time * time);
        }

        public override float ComputeInOut(float time)
        {
            if ((time *= 2.0f) < 1.0f) return 0.5f * time * time * time;
            else return 0.5f * ((time -= 2.0f) * time * time + 2.0f);
        }
    }
}