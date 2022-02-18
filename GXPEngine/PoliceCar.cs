using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class PoliceCar : Sprite
	{
		float moveSpeed = 0.2f;
		int desiredLocation = 700;
		public PoliceCar() : base("police_car.png")
		{
			SetOrigin(width / 2, height / 2);
			SetScaleXY(0.18f, 0.18f);
			SetXY(1366/2, 700);
			EventSystem.current.onCarCollision += StartMove;
			EventSystem.current.onSpeedUp += Return;
		}
		public void Return()
		{
			desiredLocation += 100;
			EventSystem.current.onUpdate += MoveBackwards;
		}
		public void MoveBackwards()
		{
			Move(0, moveSpeed);
			if (y >= desiredLocation)
			{
				EventSystem.current.onUpdate -= MoveBackwards;
			}
		}
		public void StartMove()
		{
			desiredLocation -= 100;
			EventSystem.lives--;
			EventSystem.current.onUpdate += MoveForward;
		}
		public void MoveForward()
		{
			Move(0, -moveSpeed);
			if(y<= desiredLocation)
			{
				EventSystem.current.onUpdate -= MoveForward;
			}
		}
	}
}
