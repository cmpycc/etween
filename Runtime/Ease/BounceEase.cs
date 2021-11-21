using System;

namespace cmpy.Tween
{
	public class BounceEase : Ease
	{
		public override float ComputeIn(float time)
		{
			return 1.0f - ComputeOut(1.0f - time);
		}

		public override float ComputeOut(float time)
		{
			if (time < (1f / 2.75f))
			{
				return 7.5625f * time * time;
			}
			else if (time < (2f / 2.75f))
			{
				return 7.5625f * (time -= (1.5f / 2.75f)) * time + 0.75f;
			}
			else if (time < (2.5f / 2.75f))
			{
				return 7.5625f * (time -= (2.25f / 2.75f)) * time + 0.9375f;
			}
			else
			{
				return 7.5625f * (time -= (2.625f / 2.75f)) * time + 0.984375f;
			}
		}

		public override float ComputeInOut(float time)
		{
			if (time < 0.5f) return ComputeIn(time * 2f) * 0.5f;
			return ComputeOut(time * 2f - 1f) * 0.5f + 0.5f;
		}
	}
}