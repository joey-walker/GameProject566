using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;
namespace GameProject566
{
    class PlayerChar : WorldObject
    {
        private Texture pTexture;
        new private float xLocation;
        new private float yLocation;

        public PlayerChar()
        { }
        public PlayerChar (Texture pTexture, float xLocation, float yLocation) : base (pTexture, xLocation, yLocation)
        {
            this.pTexture = pTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
        }

        public int attack(Random rand)
        {
            return rand.Next(5, 10);
        }
        /*public void move(float x, float y)
        {
            this.xLocation += x;
            this.yLocation += y;
        }*/

    }
}
