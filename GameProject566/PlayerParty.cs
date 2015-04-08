using System;
using SlimDX.Direct3D9;

namespace GameProject566
{
	public class PlayerParty
	{
		public inventory inv { get; set; }
		public PlayerChar[] party { get; set; }
		public int gold;
		public PlayerParty ()
		{
		}
	}
}

