using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class Level : GameObject
    {
        ChunkController chunkController;
        RoadScroller raceScroller;
        CarSpawner carSpawner;
        Player player;
        SpeedController speedController;
        public Level()
        {
            setupLevel();
        }

        void setupLevel()
        {
            EventSystem es = new EventSystem();
            chunkController = new ChunkController();
            raceScroller = new RoadScroller(2);
            carSpawner = new CarSpawner();
            player = new Player();
            speedController = new SpeedController();
            AddChild(raceScroller);
            AddChild(chunkController);
            AddChild(player);
            AddChild(carSpawner);

        }
        void Update()
        {
            EventSystem.current.Update();
            if (Input.GetKeyDown(Key.A))
            {
                EventSystem.current.MagnetPickedUp(Time.time, 5000);
            }
        }
    }
}
