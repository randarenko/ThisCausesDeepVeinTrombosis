using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Car : Sprite
	{
		float speed;
		public Car(float speed, int lane) : base(@"C:\Users\mined\Pictures\LiftOff\car.png")
		{
			this.speed = speed;
			SetScaleXY(0.7f, 0.7f);
			SetXY(200 + 100 * lane, -200);
		}
		public void Move()
		{
			Move(0, speed);
		}
	}
}
