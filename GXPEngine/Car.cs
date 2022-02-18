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
		public Car() : base("car1.png")
		{
			SetOrigin(width/2, height/2);
			SetScaleXY(0.15f, 0.15f);
		}
	}
}
