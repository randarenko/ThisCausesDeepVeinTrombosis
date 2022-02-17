using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    internal class Menu : GameObject
    {
        Button _button;
        int Timer;
        public Menu ()
        {
            Button button = new Button();
            AddChild(button);
            button.x = (game.width - button.width) / 2;
            button.y = (game.height - button.height) / 2;
        }

        void Update()
        {
            
            if(Input.GetKey(Key.SPACE))
            {
                Timer++;
                Console.WriteLine(Timer);
                if (Timer > 180)
                {
                    startGame();
                }
            }
            else
            {
                Timer = 0;
            }
        }

        void startGame()
        {
            Level level = new Level();
            AddChild(level);
        }
    }
}
