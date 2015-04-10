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
		public bool isBoss { get; set; }

        public Monsterchar()
        { 
			this.health = 100;
			this.strength = 1 * (level*3);
			this.agility = 1 * (level*3);
			this.level = 1;
			this.isBoss = false;
			this.isExit = false;
			this.isShop = false;
		}

		public Monsterchar (Texture mTexture, float xLocation, float yLocation, int xGridLocation, int yGridLocation, int level) : base (mTexture, xLocation, yLocation, xGridLocation,yGridLocation)
        {
            this.texture = mTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
			this.xGridLocation = xGridLocation;
			this.yGridLocation = yGridLocation;
			this.health = 100;
			this.strength = 1 * (level*3);
			this.agility = 1 * (level*3);
			this.level = level;
			this.isBoss = false;
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

		public bool isPlayerNearMe(Tile[,] worldTiles){

			int range = 7;

			//search 7 tiles around me to see if player is there.
			for (int i = range; i > 0; i--) {
				for(int j = range; j > 0; j--){
					if (worldTiles [this.xGridLocation + i, this.yGridLocation + j].worldObject != null) {
						if (worldTiles [this.xGridLocation + i, this.yGridLocation + j].worldObject.isPlayer) {
							return true;
						}
					}
				}
			}

			for (int i = range; i > 0; i--) {
				for(int j = range; j > 0; j--){
					if (worldTiles [this.xGridLocation + i, this.yGridLocation - j].worldObject != null) {
						if (worldTiles [this.xGridLocation + i, this.yGridLocation - j].worldObject.isPlayer) {
							return true;
						}
					}
				}
			}

			for (int i = range; i > 0; i--) {
				for(int j = range; j > 0; j--){
					if (worldTiles [this.xGridLocation - i, this.yGridLocation + j].worldObject != null) {
						if (worldTiles [this.xGridLocation - i, this.yGridLocation + j].worldObject.isPlayer) {
							return true;
						}
					}
				}
			}

			for (int i = range; i > 0; i--) {
				for(int j = range; j > 0; j--){
					if (worldTiles [this.xGridLocation - i, this.yGridLocation - j].worldObject != null) {
						if (worldTiles [this.xGridLocation - i, this.yGridLocation - j].worldObject.isPlayer) {
							return true;
						}
					}
				}
			}

			return false;

		}


    }
}
