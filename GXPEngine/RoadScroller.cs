using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class RoadScroller : GameObject
	{
		float scrollSpeed;
		float scaleFactor = 1;
		static int gridColumnCount = 7;
		static int lanes = 3;
		Sprite[] roadTiles = new Sprite[4] {
			new Sprite("road1.png"),
			new Sprite("road2.png"),
			new Sprite("road3.png"),
			new Sprite("grass.png")};
		public Sprite[,] map = new Sprite[gridColumnCount, 20];
		public RoadScroller(float scrollSpeed)
		{
			this.scrollSpeed = scrollSpeed;
			EventSystem.current.onUpdate += ScrollRoad;
			Initialize();
		}
		void Initialize()
		{
			float gridWidth = gridColumnCount * EventSystem.TileSize * scaleFactor;
			float tileSize = EventSystem.TileSize * scaleFactor;
			SetXY(1366 / 2 - gridWidth / 2, -tileSize); //centers grid on screen
			int offroadWidth = (gridColumnCount - lanes )/ 2; //how much env tiles will be on each side
			for (int i = 0; i < gridColumnCount; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					if (i < offroadWidth || i >= gridColumnCount - offroadWidth)
					{
						map[i, j] = new Sprite(roadTiles[3].name, false, false);
					}
					else if(i == offroadWidth)
					{
						map[i, j] = new Sprite(roadTiles[0].name, false, false);
					}
					else if(i == gridColumnCount - offroadWidth-1)
					{
						map[i, j] = new Sprite(roadTiles[2].name, false, false);
					}
					else
					{
						map[i, j] = new Sprite(roadTiles[1].name, false, false);
					}
					map[i,j].SetScaleXY(scaleFactor, scaleFactor);
					map[i, j].SetXY(i*tileSize, j*tileSize);
					AddChild(map[i, j]);	
				}
			}
		}
		
		public void ScrollRoad()
		{
			Move(0, scrollSpeed*EventSystem.speedMultiplier);
			if (y+EventSystem.TileSize>0)
			{
				SetXY(x, -EventSystem.TileSize*2);
			}
		}
	}
}
