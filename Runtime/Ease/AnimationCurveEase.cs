using UnityEngine;

namespace cmpy.Tween
{
    public class AnimationCurveEase : Ease
    {
        public AnimationCurve curve;

        public AnimationCurveEase(AnimationCurve curve)
        {
            this.curve = curve;
        }

        public override float ComputeIn(float time)
        {
            return curve.Evaluate(time);
        }

        public override float ComputeInOut(float time)
        {
            return curve.Evaluate(time);
        }

        public override float ComputeOut(float time)
        {
            return curve.Evaluate(time);
        }
    }
}