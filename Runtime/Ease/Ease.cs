using System;

namespace cmpy.Tween
{
    public abstract class Ease
    {
        public abstract float ComputeIn(float time);
        public abstract float ComputeOut(float time);
        public abstract float ComputeInOut(float time);

        public float Compute(EaseType type, float time)
        {
            return type switch
            {
                EaseType.In => ComputeIn(time),
                EaseType.Out => ComputeOut(time),
                EaseType.InOut => ComputeInOut(time),
                _ => throw new NotImplementedException(),
            };
        }
    }
}