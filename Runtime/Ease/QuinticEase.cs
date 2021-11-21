namespace cmpy.Tween
{
    public class QuinticEase : Ease
    {
        public override float ComputeIn(float time)
        {
            return time * time * time * time * time;
        }

        public override float ComputeOut(float time)
        {
            return 1.0f + ((time -= 1.0f) * time * time * time * time);
        }

        public override float ComputeInOut(float time)
        {
            if ((time *= 2.0f) < 1.0f) return 0.5f * time * time * time * time * time;
            else return 0.5f * ((time -= 2.0f) * time * time * time * time + 2.0f);
        }
    }
}