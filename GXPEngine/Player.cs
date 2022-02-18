using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Player : AnimationSprite
	{
		public static Player current;

		SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
		float speed = 0.2f;
		int control;
		bool onOil = false;
		bool wasOnOil = false;
		int previousInput = 0;
		List<int> controlHistory = new List<int>();
		int latency = 20;

		public Player() : base("spritesheet.png", 13, 1)
		{
			current = this;
			SetScaleXY(0.06f, 0.06f);
			SetXY(350, 300);
			EventSystem.current.onUpdate += Move;
			EventSystem.current.onUpdate += CollisionUpdate;
			_animationDelay = 50;
			port.Open();
		}
		public void Move()
		{
			port.DiscardInBuffer();
			string rawInput = port.ReadLine();
			rawInput = rawInput.Trim('\r');
				Console.WriteLine(onOil);
			int.TryParse(rawInput, out control);
			controlHistory.Add(control);
			if (onOil)
			{
				int currentControl;
				if (controlHistory.Count < latency)
					currentControl = controlHistory.First();
				else
					currentControl = controlHistory[controlHistory.Count - latency];
				Move(currentControl * speed, 0);
			}
			else
			{
				Move(control*0.7f, 0);
			}

			SetCycle(0, 13);
			Animate();
		}
		public void CollisionUpdate()
		{
			onOil = false;
			foreach (var item in GetCollisions())
			{
				if (item.parent is OilPool)
				{
					onOil = true;
				}
				else if(item is Coin)
				{
					EventSystem.coinsCollected++;
					Coin coin = (Coin)item;
					coin.LateDestroy();
					EventSystem.score += 1000;
					SoundManager.current.PlaySFX(0);
				}
				else if(item is Car)
				{
					EventSystem.current.CarCollision();
					item.Destroy();
					SoundManager.current.PlaySFX(2);
				}
				else if(item is Cone)
				{
					int r = Utils.Random(0, 2);
					if (r == 0)
						EventSystem.current.CarCollision();
					SoundManager.current.PlaySFX(2);
					item.Destroy();
				}
				else if(item is Fuel)
				{
					item.Destroy();
					EventSystem.current.SpeedUp();
					EventSystem.lives++;
					SoundManager.current.PlaySFX(1);
				}
			}
		}

	}
}
