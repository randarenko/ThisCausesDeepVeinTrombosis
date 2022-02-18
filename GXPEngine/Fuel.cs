using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Fuel : Sprite
	{
		public Fuel() : base("boost.png")
		{
			SetOrigin(width / 2, height / 2);
			SetScaleXY(0.1f, 0.1f);
		}
		
	}
}
