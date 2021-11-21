namespace cmpy.Tween
{
    public class LinearEase : Ease
    {
        public override float ComputeIn(float time)
        {
            return time;
        }

        public override float ComputeInOut(float time)
        {
            return time;
        }

        public override float ComputeOut(float time)
        {
            return time;
        }
    }
}