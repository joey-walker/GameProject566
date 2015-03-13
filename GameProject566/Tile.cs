using System;
using SlimDX.Direct3D9;
using System.Configuration;
using System.Drawing.Drawing2D;


namespace GameProject566
{
	public class Tile
	{
		//coordinates on map
		public int xGrid{ get; set;}
		public int yGrid { get; set;}


		//graphics
		public float xVisualLocation {set; get;}

		//the wall right below the entrance.
		public float yVisualLocation {set; get;}


		public Texture texture {set; get;}

		public int exitlocationx { set; get; }
		public int exitlocationy { set; get; }

		//World object that is on the tile
		public WorldObject worldObject {get; set;}

		public Tile(){
			this.xGrid = 0;
			this.yGrid = 0;
			this.xVisualLocation = 0;
			this.yVisualLocation = 0;
			this.worldObject = null;
		}

	}
}

