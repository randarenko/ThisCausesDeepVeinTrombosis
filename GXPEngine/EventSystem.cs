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
		public EventSystem()
		{
			current = this; //assigns current instance of class to variable
		}
		public void Update()
		{
			onUpdate?.Invoke(); //invokes an event is its isn't null
		}


		public static int TileSize { get; set; } = 100; //size of a tile accessible from anywhere
	}
}
