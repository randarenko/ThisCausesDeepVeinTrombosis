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
		SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
		float speed = 0.1f;
		int control;
		public Player() : base("player.png")
		{
			SetScaleXY(0.5f, 0.5f);
			SetXY(350, 300);
			EventSystem.current.onUpdate += Move;
			port.Open();
		}
		public void Move()
		{
			port.DiscardInBuffer();
			string rawInput = port.ReadLine();
			rawInput = rawInput.Trim('\r');
			int.TryParse(rawInput, out control);
			Move(speed * control,0);
		}

	}
}
