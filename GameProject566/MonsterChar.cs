using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;

namespace GameProject566
{
    class Monsterchar : WorldObject
    {
		private Texture mTexture{ get; set; }
		/*
		new private float xLocation{ get; set; }
		new private float yLocation{ get; set; }
		private int xGridLocation{ get; set; }
		private int yGridLocation{ get; set; }
*/

        public Monsterchar()
        { }


		public Monsterchar (Texture mTexture, float xLocation, float yLocation, int xGridLocation, int yGridLocation) : base (mTexture, xLocation, yLocation, xGridLocation,yGridLocation)
        {
            this.mTexture = mTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
			this.xGridLocation = xGridLocation;
			this.yGridLocation = yGridLocation;
        }



    }
}
