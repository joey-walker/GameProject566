using System;
using SlimDX.DirectInput;
using System.Security.Policy;

namespace GameProject566
{
	public class World
	{
		private Tile[,] worldTiles;

		private void intializeWorld(int size){
			worldTiles = new Tile[size,size];
		}
	}
}

