using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class EventSystem
	{
		public static EventSystem current; // creates static object of current class accessible from anywhere
		public event Action onUpdate; //event which will be triggered on every update and can be subscribed to
		public event Action onCarCollision;
		public event Action onSpeedUp;
		public event Action<int,int> onMagnetPickedUp;
		public EventSystem()
		{
			current = this; //assigns current instance of class to variable
		}
		public void Update()
		{
			onUpdate?.Invoke(); //invokes an event is its isn't null
		}
		public void CarCollision()
		{
			onCarCollision?.Invoke();
		}
		public void MagnetPickedUp(int startTime, int totalTime)
		{
			onMagnetPickedUp?.Invoke(startTime, totalTime);
		}
		public void SpeedUp()
		{
			onSpeedUp?.Invoke();
		}


		public static int TileSize { get; set; } = 100; //size of a tile accessible from anywhere
		public static float speedMultiplier = 1;
		public static int coinsCollected = 0;
		public static int lives = 3;
		public static float score = 0;
	}
}
