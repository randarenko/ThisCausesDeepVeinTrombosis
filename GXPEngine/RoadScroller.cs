using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class RoadScroller
	{
		float scrollSpeed;
		float scaleFactor = 1;
		float totalMovement = 0;
		Sprite[] roadTiles = new Sprite[3] { new Sprite(@"C:\Users\mined\Pictures\LiftOff\road_left.png"), new Sprite(@"C:\Users\mined\Pictures\LiftOff\road_center.png"), new Sprite(@"C:\Users\mined\Pictures\LiftOff\road_right.png") };
		public Sprite[,] map = new Sprite[7, 10];
		public RoadScroller(float scrollSpeed)
		{
			this.scrollSpeed = scrollSpeed;
			Initialize();
		}
		void Initialize()
		{
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if(i == 7/2)
					{
						map[i,j] = new Sprite(roadTiles[1].name, false, false);
					}
					else if (i == 7/2-1)
					{
						map[i, j] = new Sprite(roadTiles[0].name, false, false);
					}
					else if(i == 7/2+1)
					{
						map[i, j] = new Sprite(roadTiles[2].name, false, false);
					}
					else
					{
						map[i, j] = new Sprite(@"C:\Users\mined\Pictures\LiftOff\grass.png");
					}
					map[i, j].SetScaleXY(scaleFactor, scaleFactor);
					map[i,j].SetXY(map[i,j].width*i, map[i,j].height*j- map[i, j].height);
				}
			}
		}
		public void MoveRoad()
		{
			totalMovement += scrollSpeed;
			if (totalMovement >= map[0,0].height)
			{
				totalMovement = totalMovement - map[0,0].height;
				foreach (var item in map)
				{
					item.SetXY(item.x, item.y - item.height + totalMovement);
				}
			}
			else
			{
				foreach (var item in map)
				{
					item.Move(0, scrollSpeed);
				}
			}
			
		}
	}
}
