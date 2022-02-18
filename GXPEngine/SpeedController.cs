using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class SpeedController
	{
		float speedChangeTime = 0.3f;
		float from;
		float to;
		int startTime;
		bool slowing;
		public SpeedController()
		{
			EventSystem.current.onCarCollision += SlowDown;
			EventSystem.current.onSpeedUp += SpeedUp;
		}
		void SlowDown()
		{
			from = 1;
			to = 0.6f;
			speedChangeTime = 0.3f;
			slowing = true;
			startTime = Time.time;
			EventSystem.current.onUpdate += TweenSpeed;
		}
		void SpeedUp()
		{
			from = 0.6f;
			to = 1;
			speedChangeTime = 5f;
			startTime = Time.time;
			EventSystem.current.onUpdate += TweenSpeed;
		}
		void TweenSpeed()
		{
			float x = (Time.time-startTime)/(speedChangeTime*1000);
			float rawY = (float)Math.Pow(x - 1, 2);
			float y = map(rawY, 1, 0, from, to);
			if(rawY < 0.05f)
			{
				EventSystem.current.onUpdate -= TweenSpeed;
				if (slowing)
				{
					slowing = false;
					SpeedUp();
				}
			}
			EventSystem.speedMultiplier = y;
		}
		private float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
		{
			return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
		}
	}
}
