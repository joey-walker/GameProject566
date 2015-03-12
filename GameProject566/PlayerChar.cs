using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;
namespace GameProject566
{
    public class PlayerChar : WorldObject
    {
        public PlayerChar()
        { }
		public PlayerChar (Texture pTexture, float xLocation, float yLocation,int xGridLocation, int yGridLocation) : base (pTexture, xLocation, yLocation, xGridLocation,yGridLocation)
        {
			this.texture = pTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
			this.xGridLocation = xGridLocation;
			this.yGridLocation = yGridLocation;
        }


        public int attack(Random rand)
        {
            return rand.Next(5, 10);
        }

    }
}
