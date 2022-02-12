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
		int carSpawnTime = 0;
		public CarSpawner()
		{
			EventSystem.current.onUpdate += Update; //subscribes method to event
		}
		void Update()
		{
			if (Time.time > carSpawnTime)
			{
				Car car = new Car(Utils.Random(0.8f, 1f), Utils.Random(0, 2));
				AddChild(car);
				cars.Add(car);
				carSpawnTime += Utils.Random(1500, 5000);
			}
			foreach (var car in cars)
			{
				car.Move();
			}
		}
	}
}
