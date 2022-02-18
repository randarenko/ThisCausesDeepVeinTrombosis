using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class SoundManager : GameObject
	{
		public static SoundManager current;
		SoundChannel music;
		SoundChannel sfx;
		public SoundManager()
		{
			current = this;
		}
		public void PlayMusic()
		{
			music = new Sound("music.mp3", true, true).Play();
			music.Volume = 0.5f;
		}
		public void PlaySFX(int id)
		{
			if (id == 0)
			{
				sfx = new Sound("coin.mp3").Play();
			}
			else if(id == 1)
			{
				sfx = new Sound("pickup.mp3").Play();
			}
			else
			{
				sfx = new Sound("crash.mp3").Play();
			}
		}
	}
}
