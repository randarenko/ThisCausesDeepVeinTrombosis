using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class Cone : AnimationSprite
	{
		public Cone() : base("cone.png",8,1)
		{
			SetOrigin(width/2,height/2);
			SetScaleXY(0.2f, 0.2f);
			_animationDelay = 20;
			EventSystem.current.onUpdate += Update;
		}
		void Update()
		{
			SetCycle(0,8);
			Animate();
		}
	}
}
