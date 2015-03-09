using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;

namespace GameProject566
{
    class Monsterchar : WorldObject
    {
        public Texture mTexture { get; set; }



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


        public int attack(Random rand)
        {
            return rand.Next(0, 5);
        }

    }
}
