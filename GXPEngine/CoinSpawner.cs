using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class CoinSpawner : GameObject
	{
		List<Coin> coin = new List<Coin>();
		public CoinSpawner()
		{
			EventSystem.current.onUpdate += Update; //subscribes method to event
		}
		void Update()
		{

		}
	}
}
