using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Player : Sprite
	{
		int leftBound = 200, rightBound = 500;
		float speed = 0.1f;
		int control;
		public Player() : base(@"C:\Users\mined\Pictures\LiftOff\player.png")
		{
			SetScaleXY(0.5f, 0.5f);
			SetXY(350, 300);
			EventSystem.current.onUpdate += Move;
		}
		public void Move()
		{
			//controlRaw = controlRaw.Trim('\r');
			//control = int.Parse(controlRaw);
			//Console.WriteLine(control + " " + controlRaw);
			Move(speed * control,0);
		}

	}
}
