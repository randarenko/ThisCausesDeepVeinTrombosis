using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class ChunkController : GameObject
	{
		int spawnY = 0; //y coord where new chunk will be spawned
		int yToSpawn = 0; //y after which we need to spawn new chunk so we don't run out of them
		List<Chunk> chunks = new List<Chunk>();
		public ChunkController()
		{
			EventSystem.current.onUpdate += Update;
			SpawnChunk();
		}
		void Update()
		{
			if(y > yToSpawn)
			{
				yToSpawn += EventSystem.TileSize * Chunk.ySize;
				SpawnChunk();
			}
			Move(0, 1 * EventSystem.speedMultiplier);
			EventSystem.score += Mathf.Round( 1 * EventSystem.speedMultiplier);
		}
		void SpawnChunk()
		{
			//takes random element of string array in ChunkLib and converts it to entity twodimensional array
			Chunk chunk = new Chunk(ParseChunk(ChunkLib.chunks[Utils.Random(0,1)]));
			AddChild(chunk);
			chunk.SetXY(chunk.x, spawnY);
			spawnY -= EventSystem.TileSize * Chunk.ySize;
			if (chunks.Count>3) // if there is too much chunks loaded, destroys first(and lowest) one
			{
				chunks.First().Destroy();
				chunks.RemoveAt(0);
			}
			chunks.Add(chunk);

		}
		Entity[,] ParseChunk(string chunk)
		{
			//parses chunk string to entity array to send to chunk object
			string[] entitiesId = chunk.Split(' ');
			Entity[,] entities = new Entity[Chunk.xSize, Chunk.ySize];
			for (int y = 0; y < Chunk.ySize; y++)
			{
				for (int x = 0; x < Chunk.xSize; x++)
				{
					entities[x, y] = new Entity();
					entities[x, y] = EntityConverter(int.Parse(entitiesId[y * Chunk.xSize + x]));
				}
			}
			return entities;
		}
		Entity EntityConverter(int id)
		{
			switch (id)
			{
				case 1:
					return Entity.CAR;
				case 2:
					return Entity.OIL;
				case 3:
					return Entity.CONES;
				case 4:
					return Entity.FUEL;
				case 5:
					return Entity.RAMP;
				case 6:
					return Entity.BOOSTER;
				case 7:
					return Entity.MAGNET;
				case 8:
					return Entity.COIN;
				default:
					break;
			}
			return Entity.NONE;
		}
	}
}
