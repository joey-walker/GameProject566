using System;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Direct3D9;
using SlimDX.Direct2D;


namespace GameProject566
{
    public class PlayerChar : WorldObject
    {
        
		public int level { get; set; }
		public int experience { get; set; }
		public int strength { get; set; }
		public int intelligence { get; set; }
		public int wisdom {get; set;}
		public int agility { get; set; }
		public String characterClass {get; set;}

		public String name { get; set; }

        public PlayerChar()
        { 
			this.level = 1;
			this.experience = 1;
			this.strength = 1;
			this.intelligence = 1;
			this.wisdom = 1;
			this.health = 100;
			this.agility = 1;
			this.characterClass = "Warrior";
			this.name = " ";
			this.isPlayer = true;
		}

		public PlayerChar(bool isPlayer)
		{ 
			this.level = 1;
			this.experience = 1;
			this.strength = 1;
			this.intelligence = 1;
			this.wisdom = 1;
			this.health = 100;
			this.agility = 1;
			this.characterClass = "Warrior";
			this.name = " ";
		}


		public PlayerChar (Texture pTexture, float xLocation, float yLocation,int xGridLocation, int yGridLocation) : base (pTexture, xLocation, yLocation, xGridLocation,yGridLocation)
        {
			this.texture = pTexture;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
			this.xGridLocation = xGridLocation;
			this.yGridLocation = yGridLocation;
			this.level = 1;
			this.experience = 1;
			this.strength = 1;
			this.intelligence = 1;
			this.wisdom = 1;
			this.health = 100;
			this.agility = 1;
			this.characterClass = "Warrior";
        }


        public int attack(Random rand)
        {
            if (this.characterClass.Equals("Warrior"))
                return rand.Next(this.strength, this.strength + 10);
            else if (this.characterClass.Equals("Rogue"))
                return rand.Next(this.agility, this.agility + 10);
            else if (this.characterClass.Equals("Wizard"))
                return rand.Next(this.wisdom, this.wisdom + 10);
            else
                return rand.Next(0, 10);
        }

		//determine if we should level up
		public void LevelUp(){

			Random rand = new Random ();

			if (this.experience >= this.level * 100) {
				this.level++;
				//stat increases here
				this.strength = this.strength + rand.Next(2, 2 + this.level*3);
				this.intelligence = this.intelligence + rand.Next(2, 2+ this.level*3);
				this.agility = this.agility + rand.Next(2, 2 + this.level*3);
				this.wisdom = this.wisdom + rand.Next(2, 2 + this.level*3);
				this.health = this.health + rand.Next(2, 2 + this.level*3);
				//

				this.experience -= this.level * 100;
			}

		}

    }
}
