using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class OilPool : GameObject
	{
		Sprite[] poolType = new Sprite[3]
		{
			new Sprite("Mocha1.png"),
			new Sprite("Mocha2.png"),
			new Sprite("Mocha3.png")
		};
		Sprite pool;
		public OilPool(int type)
		{
			if (type == 0)
				pool = new Sprite(poolType[2].name);
			else if (type == 1)
				pool = new Sprite(poolType[1].name);
			else if (type == 2)
				pool = new Sprite(poolType[0].name);
			pool.SetOrigin(pool.width / 2, pool.height / 2);
			AddChild(pool);
		}
	}
}
