using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;

namespace GameProject566
{
    class Monsterchar : WorldObject
    {
        private Texture mTexture;
        new private float xLocation;
        new private float yLocation;

        public Monsterchar()
        { }
        public Monsterchar (Texture mTexture, float xLocation, float yLocation) : base (mTexture, xLocation, yLocation)
        {
            this.mTexture = mTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
        }

        public int attack(Random rand)
        {
            return rand.Next(0, 5);
        }
        /*
         public void move(float x, float y)
        {
            this.xLocation += x;
            this.yLocation += y;
        }
         */
    }
}
