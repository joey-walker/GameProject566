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
		public float xLocation {set; get;}
		public float yLocation {set; get;}
		public Texture texture {set; get;}

		public WorldObject wObject {get; set;}

		public Tile(){
			this.xGrid = 0;
			this.yGrid = 0;
			this.xLocation = 0;
			this.yLocation = 0;
			this.wObject = null;
		}

	}
}

