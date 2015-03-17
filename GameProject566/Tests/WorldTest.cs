using System;


namespace GameProject566
{
	using NUnit;
	using NUnit.Framework;

	[TestFixture]
	public class WorldTest
	{
		//Standard generate level 
		[Test]
		public void WTest ()
		{
			World world = new World ();
			PlayerChar player = new PlayerChar ();
			Tile[,] worldTiles = world.makeWorld (150);
			Tile[,] startingTiles = world.makeStartingRoom (player);
			worldTiles =  world.PlaceRoomOnWorld (worldTiles, startingTiles, 10, 10);

			worldTiles = world.generateLevel (worldTiles, world, 8);
		}
	}
}

