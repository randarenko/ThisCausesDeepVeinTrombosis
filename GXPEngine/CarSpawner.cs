using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class CarSpawner : GameObject
	{
		List<Car> cars = new List<Car>();
		public CarSpawner()
		{
			EventSystem.current.onUpdate += Update; //subscribes method to event
		}
		void Update()
		{
			
		}
	}
}
