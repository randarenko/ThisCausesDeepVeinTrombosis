﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Car : Sprite
	{
		float speed;
		public Car() : base("Car.png")
		{
			SetOrigin(width/2, height/2);
			SetScaleXY(0.7f, 0.7f);
		}
	}
}
