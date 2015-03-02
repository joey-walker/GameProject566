/*
 * Base class for characters on the screen
 * will be used by player and monster class
 * two constructors, functions to set/get texture and character location on the grid
*/

using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;

namespace GameProject566
{
    public class WorldObject
    {
		public Texture charTexture {set; get;}
        public int health { set; get; }
		public float xLocation {set; get;}
		public float yLocation {set; get;}
		public bool canMove { set; get; }

        public WorldObject()
        { }
        public WorldObject (Texture charTexture, float xLocation, float yLocation)
        {
            this.charTexture = charTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
        }

        public void move(float x, float y)
        {
            this.xLocation += x;
            this.yLocation += y;
        }

        /*public void setCharTexture(Texture charTexture)
        {
            this.charTexture = charTexture;
        }

        public void setXLocation(float xLocation)
        {
            this.xLocation = xLocation;
        }

        public void setYLocation(float yLocation)
        {
            this.yLocation = yLocation;
        }

        public Texture getCharTexture()
        {
            return charTexture;
        }

        public float getXLocation()
        {
            return xLocation;
        }

        public float getYLocation()
        {
            return yLocation;
        }
        */
    }
}
