using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Chunk : GameObject
	{
		public static int xSize = 3;
		public static int ySize = 15;
		int tileSize = EventSystem.TileSize;
		Entity[,] entities = new Entity[xSize, ySize];	
		public Chunk(Entity[,] entities)
		{
			this.entities = entities;
			int xPos = 1366 / 2 - xSize * tileSize / 2; //places chunk on the center of the screen
			SetXY(xPos, 0);
			InitializeChunk();
		}
		void InitializeChunk()
		{
			for (int i = 0; i < xSize; i++)
			{
				for (int j = 0; j < ySize; j++)
				{
					//template which will work for any entity-------------------------------------
					if (entities[i,j] == Entity.CAR)
					{
						Car car = new Car();
						Vector2 center = CellCenter(i, j); // get current cell center coords
						car.SetXY(center.x, center.y); //entity object's origin should be centered for this to work correctly
						AddChild(car);
					}
					//-----------------------------------------------------------------------------
					else if(entities[i,j] == Entity.OIL)
					{
						int type = 1;
						if (j == 0 || entities[i, j - 1] != Entity.OIL)
							type = 0;
						else if (j == 14 || entities[i, j + 1] != Entity.OIL)
							type = 2;
						OilPool oil = new OilPool(type);
						Vector2 center = CellCenter(i,j);
						oil.SetXY(center.x, center.y);
						AddChild(oil);
					}
					else if(entities[i,j] == Entity.COIN)
					{
						Coin coin = new Coin();
						Vector2 center = CellCenter(i, j);
						coin.SetXY(center.x,center.y);
						AddChild(coin);
					}
				}
			}
		}
		//method for adding entity to a chunk dynamically WIP
		public void AddEntity(int x, int y, Entity entity)
		{
			entities[x, y] = entity;
		}
		//same for removing entities
		public void RemoveEntity(int x, int y)
		{
			entities[x, y] = Entity.NONE;
		}
		//returns cell center
		Vector2 CellCenter(int x, int y)
		{
			return new Vector2(x * tileSize + tileSize / 2, y * tileSize + tileSize / 2);
		}
	}
}
