using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Coin : Sprite
	{
		float speed = 0.02f;
		public Coin() : base("coin.png")
		{
			SetOrigin(width / 2, height / 2);
			EventSystem.current.onMagnetPickedUp += EnableMagnetism;
		}
		void EnableMagnetism(int startTime, int totalTime)
		{
			EventSystem.current.onUpdate += AttractToPlayer;
		}
		void AttractToPlayer()
		{
			float x = parent.parent.x - Player.current.x;
			float y = parent.parent.y - Player.current.y;
			Move(x*speed, y*speed);
		}
		public void PreDestroy()
		{
			EventSystem.current.onUpdate -= AttractToPlayer;
			EventSystem.current.onMagnetPickedUp -= EnableMagnetism;
		}
	}
}
