namespace cmpy.Tween
{
    public class QuadraticEase : Ease
    {
        public override float ComputeIn(float time)
        {
            return time * time;
        }

        public override float ComputeOut(float time)
        {
            return time * (2.0f - time);
        }

        public override float ComputeInOut(float time)
        {
            if ((time *= 2.0f) < 1.0f) return 0.5f * time * time;
            else return -0.5f * ((time -= 1.0f) * (time - 2.0f) - 1.0f);
        }
    }
}