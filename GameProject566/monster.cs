﻿using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;

namespace GameProject566
{
    class Monster : WorldObject
    {
        private Texture mTexture;
        private float xLocation;
        private float yLocation;

        public Monster()
        { }
        public Monster (Texture mTexture, float xLocation, float yLocation) : base (mTexture, xLocation, yLocation)
        {
            this.mTexture = mTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
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
