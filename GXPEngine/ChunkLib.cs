using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
	internal class ChunkLib
	{
		//every element in this array is a 3x15 chunk with entities/objects, no new lines
		//0 - NONE
		//1 - CAR,
		//2 - OIL,
		//3 - CONES,
		//4 - FUEL,
		//5 - RAMP,
		//6 - BOOSTER,
		//7 - MAGNET,
		//8 - COIN

		public static string[] chunks = new string[1]
		{
			"1 1 0 0 0 1 0 0 0 1 0 0 8 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 8 8 0 8 0 0 0 0 0 0"
		};
	}
}
