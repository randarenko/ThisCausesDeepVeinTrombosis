﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Coin : Sprite
	{
		float speed = 0.05f;
		public Coin() : base("coin.png")
		{
			SetOrigin(width / 2, height / 2);
			SetScaleXY(0.7f, 0.7f);
		}
	}
}
