/*
 * Base class for characters on the screen
 * will be used by player and monster class
 * two constructors, functions to set/get texture and character location on the grid
*/

using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;
using System.Configuration;

namespace GameProject566
{
    public class WorldObject
    {
		public Texture texture {set; get;}
        public int health { set; get; }
		public float xLocation {set; get;}
		public float yLocation {set; get;}
		//Grid placement
		public int xGridLocation { set; get;}
		public int yGridLocation { set; get;}

        //texture location
        //public string textureLocation { set; get; }

        //all textures
        public Texture right { set; get; }
        public Texture left { set; get; }
        public Texture front { set; get; }
        public Texture back { set; get; }
        public Texture right2 { set; get; }
        public Texture left2 { set; get; }
        public Texture front2 { set; get; }
        public Texture back2 { set; get; }
        public Texture att { set; get; }
        public Texture big { set; get; }

		public bool isExit { set; get; }
		public bool isShop { set; get; }
		public bool isPlayer { set; get; }
		public bool isBoss { get; set; }

        public WorldObject()
        { 
			this.isExit = false;
			this.isShop = false;
			this.isPlayer = false;
			this.isBoss = false;
		}

		public WorldObject (Texture charTexture, float xLocation, float yLocation, int xGridLocation, int yGridLocation)
        {
            this.texture = charTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
			this.xGridLocation = xGridLocation;
			this.yGridLocation = yGridLocation;
        }

        public void moveVisually(float x, float y)
        {
            this.xLocation += x;
            this.yLocation += y;
        }

		public void moveOnGrid(int x, int y)
		{
			this.xGridLocation = x;
			this.yGridLocation = y;
		}


    }
}
