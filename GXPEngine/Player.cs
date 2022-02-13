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
<<<<<<< Updated upstream
		int leftBound = 200, rightBound = 500;
		float speed = 0.1f;
=======
		SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
		float speed = 0.5f;
>>>>>>> Stashed changes
		int control;
		EasyDraw overCar;
		public Player() : base("player.png")
		{
			SetScaleXY(0.5f, 0.5f);
			SetXY(350, 300);
			EventSystem.current.onUpdate += Move;
<<<<<<< Updated upstream
=======
			port.Open();
			overCar = new EasyDraw(200,200);
			AddChild(overCar);
>>>>>>> Stashed changes
		}
		public void Move()
		{
			//controlRaw = controlRaw.Trim('\r');
			//control = int.Parse(controlRaw);
			//Console.WriteLine(control + " " + controlRaw);
			Move(speed * control,0);
		}
		void OnCollision(GameObject other)
		{
			if (other is Car)
			{
				overCar.Text("Player is collided with car");
				overCar.SetOrigin(100, 100);
				overCar.SetXY(100, 100);
			}
/*			if (other is Car)
			{
				Car car = other as Car;
			} */
		}

	}
}
