using System;


namespace GameProject566
{
	using NUnit;
	using NUnit.Framework;

	[TestFixture]
	public class WorldTest
	{
		[Test]
		public void WTest ()
		{
			World world = new World ();
			PlayerChar player = new PlayerChar ();
			Tile[,] tiles = world.makeStartingRoom (player);

			System.Console.Out.WriteLine (tiles[0,0].x);
			System.Console.Out.WriteLine (tiles[9,9].y);
			System.Console.Out.WriteLine ("end test");
		}
	}
}

