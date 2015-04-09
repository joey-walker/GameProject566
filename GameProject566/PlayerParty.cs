using System;
using SlimDX.Direct3D9;
using System.Collections.Generic;

namespace GameProject566
{
	public class PlayerParty
	{
		public Inventory inv { get; set; }
		public List <PlayerChar> party { get; set; }
		public int gold;
		public PlayerParty ()
		{
			this.inv = new Inventory ();
			this.gold = 0;
		}
	}
}

