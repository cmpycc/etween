using System;

namespace cmpy.Tween
{
    public class BackEase : Ease
    {
        // Where the hell do these numbers come from?
        private const float S = 1.70158f;
        private const float S2 = 2.5949095f;

        public override float ComputeIn(float time)
        {
            return time * time * ((S + 1f) * time - S);
        }

        public override float ComputeOut(float time)
        {
            return (time -= 1f) * time * ((S + 1f) * time + S) + 1f;
        }

        public override float ComputeInOut(float time)
        {
            if ((time *= 2f) < 1f) return 0.5f * (time * time * ((S2 + 1f) * time - S2));
            else return 0.5f * ((time -= 2f) * time * ((S2 + 1f) * time + S2) + 2f);
        }
    }
}