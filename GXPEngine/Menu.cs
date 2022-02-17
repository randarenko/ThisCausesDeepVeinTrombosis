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
        public Menu ()
        {
            Button button = new Button();
            AddChild(button);
            button.x = (game.width - button.width) / 2;
            button.y = (game.height - button.height) / 2;
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                //if(_button.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    startGame();
                }
            }
        }

        void startGame()
        {
            Level level = new Level();
            AddChild(level);
        }
    }
}
