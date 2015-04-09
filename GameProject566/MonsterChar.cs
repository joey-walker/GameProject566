using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;

namespace GameProject566
{
    public class Monsterchar : WorldObject
    {
		public int level { get; set; }
		public int strength { get; set; }
		public int agility { get; set; }

        public Monsterchar()
        { }

		public Monsterchar (Texture mTexture, float xLocation, float yLocation, int xGridLocation, int yGridLocation) : base (mTexture, xLocation, yLocation, xGridLocation,yGridLocation)
        {
            this.texture = mTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
			this.xGridLocation = xGridLocation;
			this.yGridLocation = yGridLocation;
			this.health = 100;
			this.strength = 1;
			this.agility = 1;
        }

		//Give experience amount on death
		public int giveExperience(){
			Random rand = new Random ();
			return this.level * rand.Next (this.level, this.level * 20);
		}

        public int attack(Random rand)
        {
            return rand.Next(this.strength, this.strength * 10);
        }

    }
}
