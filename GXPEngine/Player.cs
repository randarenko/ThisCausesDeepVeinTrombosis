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
		public static Player current;

		SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
		float speed = 0.1f;
		int control;
		bool onOil = false;
		bool wasOnOil = false;
		int previousInput = 0;

		public Player() : base("player.png")
		{
			current = this;
			SetScaleXY(0.5f, 0.5f);
			SetXY(350, 300);
			EventSystem.current.onUpdate += Move;
			EventSystem.current.onUpdate += CollisionUpdate;
			port.Open();
		}
		public void Move()
		{
			port.DiscardInBuffer();
			string rawInput = port.ReadLine();
			rawInput = rawInput.Trim('\r');
				Console.WriteLine(onOil);
			int.TryParse(rawInput, out control);
			if (!onOil)
			{
				wasOnOil = false;
				Move(speed * control,0);
				previousInput = control;
			}
			else if(onOil&&!wasOnOil)
			{
				Move(speed * control, 0);
				previousInput = control;
			}
			else if(onOil&&wasOnOil)
			{
				wasOnOil = true;
				Move(-speed * control,0);
			}
			if (onOil && control == 0&&!wasOnOil)
			{
				wasOnOil = true;
			}

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
					coin.PreDestroy();
					coin.Destroy();
				}
			}
		}

	}
}
