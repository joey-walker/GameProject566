using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Windows;
using SlimDX.Design;
using SlimDX.RawInput;
using SlimDX.Multimedia;
using SlimDX.DirectSound;


using System.Text;
using System.Collections.Generic;
//using SlimDX.DirectInput;
using SlimDX.XInput;
using SlimDX.DirectInput;

namespace GameProject566
{

	public class GameStart
	{

		//Our graphics device
		static SlimDX.Direct3D9.Device device9;

		//We use this to load sprites.
		static Sprite sprite;
		static Sprite sprite2;
		static Sprite sprite3;
	

		//tiles
		//static Texture tiles;


		//background for map
		static string bg = "..\\..\\sprites\\bg.png";
		static Texture mapBg;
		//Absolute starting location for player

		static float characterX = 420;
		static float characterY = 300;


		//static float savePlayerLocation = 0.0f;


		//Beginning location for tile
		static float tileX = 0;
		static float tileY = 0;

		static float tileX2 = 0;
		static float tileY2 = 0;


		//battlescreen texture
		static string battleScr = "..\\..\\sprites\\battlescreen_2.png";
		static Texture battleScreen;


		//fileLocation for tiles
		static string tiles = "..\\..\\sprites\\tile1.png";
		static string wall = "..\\..\\sprites\\Wall.png";
		static string entryTile = "..\\..\\sprites\\entry.png";
		static string exitTile = "..\\..\\sprites\\exit.png";
		// Beginning location for monster
		static float monster1X = 300;
		static float monster1Y = 240;

		//object representing the player on the grid
		static PlayerChar player = new PlayerChar (null, characterX, characterY, 0, 0);

        //characters from player's party
        static PlayerChar char1 = new PlayerChar(null, characterX, characterY, 0, 0);
        static PlayerChar char2 = new PlayerChar(null, characterX, characterY, 0, 0);
        static PlayerChar char3 = new PlayerChar(null, characterX, characterY, 0, 0);
        static PlayerChar char4 = new PlayerChar(null, characterX, characterY, 0, 0);
        static PlayerChar char5 = new PlayerChar(null, characterX, characterY, 0, 0);
        static PlayerChar char6 = new PlayerChar(null, characterX, characterY, 0, 0);
        static PlayerChar char7 = new PlayerChar(null, characterX, characterY, 0, 0);
        static PlayerChar char8 = new PlayerChar(null, characterX, characterY, 0, 0);

        //arraylist for all the characters
        static List<PlayerChar> characters = new List<PlayerChar>();

		//arraylist for player's party
        static List <PlayerChar> party = new List<PlayerChar>();

		static PlayerParty playerparty;



        //boolean to check health
        static bool isEveryoneDead = false;

        //x and y grid Location
        static int charXGridLocation = 6;
        static int charYGridLocation = 5;
        
        //gets all the sprite file locations for the player
		static string pback = "..\\..\\sprites\\pback.png";
		static string pback1 = "..\\..\\sprites\\pback1.png";
		static string pfront = "..\\..\\sprites\\pfront.png";
		static string pfront1 = "..\\..\\sprites\\pfront1.png";
		static string pleft = "..\\..\\sprites\\pleft.png";
		static string pleft1 = "..\\..\\sprites\\pleft1.png";
		static string pright = "..\\..\\sprites\\pright.png";
		static string pright1 = "..\\..\\sprites\\pright1.png";
		//Determines which way the player is facing.
		static bool changePlayerBack = false;
		static bool changePlayerFront = false;
		static bool changePlayerLeft = false;
		static bool changePlayerRight = false;

        //textures for player's characters
        static string char1Texture1 = "..\\..\\sprites\\char2r2.png";
        //static string char1Texture2 = "..\\..\\sprites\\char2att.png";
        static string char2Texture1 = "..\\..\\sprites\\char3r2.png";
        static string char3Texture1 = "..\\..\\sprites\\char4r2.png";
        static string char4Texture1 = "..\\..\\sprites\\char5r2.png";
        static string char5Texture1 = "..\\..\\sprites\\char6r2.png";
        static string char6Texture1 = "..\\..\\sprites\\char7r2.png";
        static string char7Texture1 = "..\\..\\sprites\\char8r2.png";
        //static string char2Texture2 = "..\\..\\sprites\\char3att.png";

		//Sound buffer to hold onto the music.
		static SoundBuffer music;


		//object represenitng the monster
		static Monsterchar m1 = new Monsterchar (null, monster1X, monster1Y, 0, 0);


		//gets all the sprite file locations for the monster

		//static string monsterCharSprite = "..\\..\\sprites\\monster.png";

		static string m1Front = "..\\..\\sprites\\PS_front.png";
		static string m1Front1 = "..\\..\\sprites\\PS_front2.png";
		static string m1Back = "..\\..\\sprites\\PS_back.png";
		static string m1Back1 = "..\\..\\sprites\\PS_back2.png";
		static string m1Right = "..\\..\\sprites\\PS_right.png";
		static string m1Right1 = "..\\..\\sprites\\PS_right2.png";
		static string m1Left = "..\\..\\sprites\\PS_left.png";
		static string m1Left1 = "..\\..\\sprites\\PS_left2.png";
		//Determines which way the monster is facing.
		static bool changeM1Back = false;
		static bool changeM1Front = false;
		static bool changeM1Left = false;
		static bool changeM1Right = false;


		// create new form to hold onto our game
		static RenderForm form;

		//Random Number Generator
		static Random rand = new Random ();

		//object for graphics
		static Graphics graphics = new Graphics ();

		//enum for status, default is main menu.
		static GameStatus status = GameStatus.mainMenu;


		//grid
		static Tile[,] worldTiles;

		//grid size
		const int WORLDSIZE = 160;

		//number of rooms we will have, allot enough grid size to ensure no out of index errors.
		const int MAXROOMS = 10;


		//Character creation to determine the current selection. Max 4
		static int[] CurrentDisplayCharacter = new int[4] {1, 1, 1, 1};
		static int currentCharacter = 1;
		static int[] pointsRemainingforCharacter = new int[4] {10, 10, 10, 10};
		//
		//Universal string builder
		static StringBuilder builder = new StringBuilder ();

		public static void Main ()
		{
			//using allows cleanup of form afterwards
			/* using -> New concept, Basically it creates objects that if disposable will
			* get rid of the object when no longer being managed.
			* The rest creates a standard windows form that we tell the application to run.
			*/
			using (form = new RenderForm ("Dreadnought KamZhor")) {

				//Window resolution is 1024 x 768
				form.Width = 1024;
				form.Height = 768;

				//No resizing
				form.FormBorderStyle = FormBorderStyle.Fixed3D;
				form.MaximizeBox = false;

				//Create our icon
				Icon icon = Graphics.createIcon ();

				//set the form's icon.
				form.Icon = icon;

				//Create our device, textures and sprites
				device9 = graphics.initializeGraphics (form);

                //add all the characters to the character list
                characters.Add(char1);
                characters.Add(char2);
                characters.Add(char3);
                characters.Add(char4);
                characters.Add(char5);
                characters.Add(char6);
                characters.Add(char7);
                characters.Add(char8);
                //initialize all the character's texture
                characters = Graphics.createCharacterTextures(device9, characters);

                //initialize character screen textures
                Graphics.createCharacterScreenTextures(device9);
                //background for map
                mapBg = Graphics.createTexture(device9, bg);

                //background for menu
                //menuBGTex = Graphics.createTexture(device9, menuBG)

                sprite = new Sprite(device9);
                sprite2 = new Sprite(device9);
                sprite3 = new Sprite(device9);

                //play music
                playMusic();



                //create main menu textures

                Graphics.createMainMenuTextures(device9);

                //create tutorial textures

                Graphics.createTutorialTextures(device9);

                //create message textures
                Graphics.createMessageScreenTexture(device9);

                reset();

               

				//Gimme da keyboards
				SlimDX.RawInput.Device.RegisterDevice (UsagePage.Generic, UsageId.Keyboard, SlimDX.RawInput.DeviceFlags.None);
				SlimDX.RawInput.Device.KeyboardInput += new EventHandler <KeyboardInputEventArgs> (Device_keyboardInput);

				//Mouse initializaton
				SlimDX.RawInput.Device.RegisterDevice (UsagePage.Generic, UsageId.Mouse, SlimDX.RawInput.DeviceFlags.None);
				SlimDX.RawInput.Device.MouseInput += new EventHandler<MouseInputEventArgs> (Device_mouseInput);



				//Create character's textures
				//Graphics.createCharacterTextures(device9);

				//Create characterScreen textures
				Graphics.createCharacterScreenTextures(device9);

				//Application loop

				MessagePump.Run (form, GameLoop);

				//Dispose no longer in use objects.
				Cleanup ();
			}
		}

        public static void playMusic()
        {
            //SOUND STUFF/////////////////
            DirectSound directsound = new DirectSound();
            directsound.IsDefaultPool = false;
            directsound.SetCooperativeLevel(form.Handle, SlimDX.DirectSound.CooperativeLevel.Priority);
            WaveStream wave = new WaveStream("..\\..\\sprites\\music1.wav");

            SoundBufferDescription description = new SoundBufferDescription();
            description.Format = wave.Format;
            description.SizeInBytes = (int)wave.Length;
            description.Flags = BufferFlags.ControlVolume;

            // Create the buffer.
            music = new SecondarySoundBuffer(directsound, description);

            byte[] data = new byte[description.SizeInBytes];
            wave.Read(data, 0, (int)wave.Length);
            music.Write(data, 0, SlimDX.DirectSound.LockFlags.None);


            //music.Volume = 0;
            music.Play(0, PlayFlags.Looping);

            ////////////////////////////////////
        }

		private static void GameLoop ()
		{

			//Logic then render then loop
			GameLogic ();
			RenderFrames ();

			//Example change to offset to move picture accross

		}


		private static void GameLogic ()
		{
			//z += 0.0001f;
			//This is where would place game logic for a game
		}


		//Sprites and textures CANNOT be created here, as it must retrieve textures
		private static void RenderFrames ()
		{
		
			//Clear the whole screen
			device9.Clear (ClearFlags.Target, Color.GhostWhite, 1.0f, 0);

			//Render whole frame
			device9.BeginScene ();

			//hold onto our sprites
			sprite.Begin (SpriteFlags.AlphaBlend);
			sprite2.Begin (SpriteFlags.AlphaBlend);
			sprite3.Begin (SpriteFlags.AlphaBlend);

			SlimDX.Color4 color = new SlimDX.Color4 (Color.White);

			//Change to Main Menu
			if (status == GameStatus.mainMenu) {
                //reset();
				Graphics.renderMainMenu (color, device9, sprite);
			}

            //change to party screen
            if (status == GameStatus.createCharacter)
            {
				Graphics.renderCharacterCreationWindow(color, device9, sprite,
					CurrentDisplayCharacter[currentCharacter-1],currentCharacter,pointsRemainingforCharacter[currentCharacter-1], party.ElementAt(currentCharacter-1));
            }

			//Change to the game map.
			if (status == GameStatus.map) {
				renderGameRoom (color);
			}

			//Change to the tutorial screen.
			if (status == GameStatus.tutorial) {
				Graphics.renderTutorial (color, device9, sprite);
			}


			//render battle screen. About to get serious now :O
			if (status == GameStatus.battleScreen) {
				//renderBattleScreen (color);
                Graphics.renderBattleScreen(color, device9, sprite, 1, party, m1);
			}

            //render final message screen. At this point the game is over
            if (status == GameStatus.win || status == GameStatus.lose)
            {
                Graphics.renderMessage(color, device9, sprite, status);
            }
			//end render
			sprite.End ();
			sprite2.End ();
			sprite3.End ();


			// End the scene.
			device9.EndScene ();

			// Present the backbuffer contents to the screen.
			device9.Present ();

		}

		public static void renderGameRoom (SlimDX.Color4 color)
		{
			//
			status = GameStatus.map;
			//renders sprite for tile and player

			//player.xLocation = characterX;
			//player.yLocation = characterY;

            party[0].xLocation = characterX;
            party[0].yLocation = characterY;

			//render bg
			sprite.Transform = Matrix.Translation (0, 0, 0);
			sprite.Draw (mapBg, color);
			//renders tile texture

			makeTiles (sprite, color);


			//renders player texture
			sprite.Transform = Matrix.Translation (party[0].xLocation, party[0].yLocation, 0);
			sprite.Draw (party[0].texture, color);


			//should monster
			if (m1.health <= 0) {
				worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject();
			}
	
		}

		private static void makeTiles (Sprite sprite, SlimDX.Color4 color)
		{

			tileX = 0;
			tileY = 0;
			for (int x = 0; x < WORLDSIZE; x++) {
				tileX += 60;
				tileY = 0;
				for (int y = 0; y < WORLDSIZE; y++) {
					tileY += 60;

					if (worldTiles [x, y].texture != null) {
						sprite.Transform = Matrix.Translation (worldTiles [x, y].xVisualLocation + tileX2, worldTiles [x, y].yVisualLocation + tileY2, 0);
						sprite.Draw (worldTiles [x, y].texture, color);

						//System.Console.Out.WriteLine (worldTiles [x, y].xLocation + " y: " + worldTiles [x, y].yLocation);
					}
					if (worldTiles [x, y].worldObject != null) {
						if (worldTiles [x, y].worldObject.texture != null && worldTiles [x, y].worldObject.texture != player.texture) {
							sprite.Transform = Matrix.Translation (worldTiles [x, y].xVisualLocation + tileX2, worldTiles [x, y].yVisualLocation + tileY2, 0);
							sprite.Draw (worldTiles [x, y].worldObject.texture, color);
						}
					}
				}
			}
            
		}

		public static Boolean arrowOrNot (KeyboardInputEventArgs e)
		{
			switch (e.Key) {
			case Keys.Up:
				return true;
			case Keys.Down:
				return true;
			case Keys.Right:
				return true;
			case Keys.Left:
				return true;
			}
			return false;
		}

        private static Boolean isAdjacent(int playerX, int playerY, int monsterX, int monsterY)
        {
            if ((playerX == monsterX || playerX - 1 == monsterX || playerX + 1 == monsterX) && (playerY == monsterY || playerY - 1 == monsterY || playerY + 1 == monsterY))
                return true;

            return false;
        }

		public static void Device_mouseInput (object sender, MouseInputEventArgs m)
		{
			//Coordinates of the mouse point
			int cursorX = form.PointToClient (RenderForm.MousePosition).X;
			int cursorY = form.PointToClient (RenderForm.MousePosition).Y;

			if (status == GameStatus.mainMenu) {

				//Button positions
				if (cursorX >= 500 && cursorY >= 200 && cursorX <= 1000 && cursorY <= 310) {
					Graphics.switchNewGameButton (true);
				} else {
					Graphics.switchNewGameButton (false);
				}

				if (cursorX >= 500 && cursorY >= 360 && cursorX <= 1000 && cursorY <= 430) {
					Graphics.switchTutorialButton (true);
				} else {
					Graphics.switchTutorialButton (false);
				}

				if (cursorX >= 500 && cursorY >= 470 && cursorX <= 1000 && cursorY <= 580) {
					Graphics.switchQuitButton (true);
				} else {
					Graphics.switchQuitButton (false);
				}

				if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 200 && cursorX <= 1000 && cursorY <= 310) {
					Console.WriteLine ("X Position: " + cursorX + "Y Position: " + cursorY);
					//Switch to game map
					status = GameStatus.createCharacter;
				} else if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 470 && cursorX <= 1000 && cursorY <= 580) {
					Console.WriteLine ("X Position: " + cursorX + " | Y Position: " + cursorY);
					//Exit the game
					Cleanup ();
				} else if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 360 && cursorX <= 1000 && cursorY <= 430) {

					//start tutorial
					status = GameStatus.tutorial;

				}
			}

            if (status == GameStatus.createCharacter)
            {
				

				//CREATECHAR
<<<<<<< HEAD
                //if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 470 && cursorX <= 1000 && cursorY <= 580)
                //{
                  
                    
                //}
=======
				foreach(PlayerChar character in party){
					if (character.big == null) {
						character.big = characters [0].big;
					}
				}




				switch(CurrentDisplayCharacter[currentCharacter-1]){
				case 1:
					party.ElementAt (currentCharacter-1).att = characters [0].att;
					party.ElementAt (currentCharacter-1).back = characters [0].back;
					party.ElementAt (currentCharacter-1).back2 = characters [0].back2;
					party.ElementAt (currentCharacter-1).big = characters [0].big;
					party.ElementAt (currentCharacter-1).front = characters [0].front;
					party.ElementAt (currentCharacter-1).front2 = characters [0].front2;
					party.ElementAt (currentCharacter-1).left = characters [0].left;
					party.ElementAt (currentCharacter-1).left2 = characters [0].left2;
					party.ElementAt (currentCharacter-1).right = characters [0].right;
					party.ElementAt (currentCharacter-1).right2 = characters [0].right2;
					party.ElementAt (currentCharacter-1).texture = characters [0].back;
					break;

					case 2:
					party.ElementAt (currentCharacter-1).att = characters [1].att;
					party.ElementAt (currentCharacter-1).back = characters [1].back;
					party.ElementAt (currentCharacter-1).back2 = characters [1].back2;
					party.ElementAt (currentCharacter-1).big = characters [1].big;
					party.ElementAt (currentCharacter-1).front = characters [1].front;
					party.ElementAt (currentCharacter-1).front2 = characters [1].front2;
					party.ElementAt (currentCharacter-1).left = characters [1].left;
					party.ElementAt (currentCharacter-1).left2 = characters [1].left2;
					party.ElementAt (currentCharacter-1).right = characters [1].right;
					party.ElementAt (currentCharacter-1).right2 = characters [1].right2;
					party.ElementAt (currentCharacter-1).texture = characters [1].back;
					break;

					case 3:
					party.ElementAt (currentCharacter-1).att = characters [2].att;
					party.ElementAt (currentCharacter-1).back = characters [2].back;
					party.ElementAt (currentCharacter-1).back2 = characters [2].back2;
					party.ElementAt (currentCharacter-1).big = characters [2].big;
					party.ElementAt (currentCharacter-1).front = characters [2].front;
					party.ElementAt (currentCharacter-1).front2 = characters [2].front2;
					party.ElementAt (currentCharacter-1).left = characters [2].left;
					party.ElementAt (currentCharacter-1).left2 = characters [2].left2;
					party.ElementAt (currentCharacter-1).right = characters [2].right;
					party.ElementAt (currentCharacter-1).right2 = characters [2].right2;
					party.ElementAt (currentCharacter-1).texture = characters [2].back;
					break;

					case 4:
					party.ElementAt (currentCharacter-1).att = characters [3].att;
					party.ElementAt (currentCharacter-1).back = characters [3].back;
					party.ElementAt (currentCharacter-1).back2 = characters [3].back2;
					party.ElementAt (currentCharacter-1).big = characters [3].big;
					party.ElementAt (currentCharacter-1).front = characters [3].front;
					party.ElementAt (currentCharacter-1).front2 = characters [3].front2;
					party.ElementAt (currentCharacter-1).left = characters [3].left;
					party.ElementAt (currentCharacter-1).left2 = characters [3].left2;
					party.ElementAt (currentCharacter-1).right = characters [3].right;
					party.ElementAt (currentCharacter-1).right2 = characters [3].right2;
					party.ElementAt (currentCharacter-1).texture = characters [3].back;
					break;

					case 5:
					party.ElementAt (currentCharacter-1).att = characters [4].att;
					party.ElementAt (currentCharacter-1).back = characters [4].back;
					party.ElementAt (currentCharacter-1).back2 = characters [4].back2;
					party.ElementAt (currentCharacter-1).big = characters [4].big;
					party.ElementAt (currentCharacter-1).front = characters [4].front;
					party.ElementAt (currentCharacter-1).front2 = characters [4].front2;
					party.ElementAt (currentCharacter-1).left = characters [4].left;
					party.ElementAt (currentCharacter-1).left2 = characters [4].left2;
					party.ElementAt (currentCharacter-1).right = characters [4].right;
					party.ElementAt (currentCharacter-1).right2 = characters [4].right2;
					party.ElementAt (currentCharacter-1).texture = characters [4].back;
					break;

					case 6:
					party.ElementAt (currentCharacter-1).att = characters [5].att;
					party.ElementAt (currentCharacter-1).back = characters [5].back;
					party.ElementAt (currentCharacter-1).back2 = characters [5].back2;
					party.ElementAt (currentCharacter-1).big = characters [5].big;
					party.ElementAt (currentCharacter-1).front = characters[5].front;
					party.ElementAt (currentCharacter-1).front2 = characters [5].front2;
					party.ElementAt (currentCharacter-1).left = characters [5].left;
					party.ElementAt (currentCharacter-1).left2 = characters [5].left2;
					party.ElementAt (currentCharacter-1).right = characters [5].right;
					party.ElementAt (currentCharacter-1).right2 = characters [5].right2;
					party.ElementAt (currentCharacter-1).texture = characters [5].back;
					break;

					case 7:
					party.ElementAt (currentCharacter-1).att = characters [6].att;
					party.ElementAt (currentCharacter-1).back = characters [6].back;
					party.ElementAt (currentCharacter-1).back2 = characters [6].back2;
					party.ElementAt (currentCharacter-1).big = characters [6].big;
					party.ElementAt (currentCharacter-1).front = characters[6].front;
					party.ElementAt (currentCharacter-1).front2 = characters [6].front2;
					party.ElementAt (currentCharacter-1).left = characters [6].left;
					party.ElementAt (currentCharacter-1).left2 = characters [6].left2;
					party.ElementAt (currentCharacter-1).right = characters [6].right;
					party.ElementAt (currentCharacter-1).right2 = characters [6].right2;
					party.ElementAt (currentCharacter-1).texture = characters [6].back;
					break;

					case 8:
					party.ElementAt (currentCharacter-1).att = characters [7].att;
					party.ElementAt (currentCharacter-1).back = characters [7].back;
					party.ElementAt (currentCharacter-1).back2 = characters [7].back2;
					party.ElementAt (currentCharacter-1).big = characters [7].big;
					party.ElementAt (currentCharacter-1).front = characters[7].front;
					party.ElementAt (currentCharacter-1).front2 = characters [7].front2;
					party.ElementAt (currentCharacter-1).left = characters [7].left;
					party.ElementAt (currentCharacter-1).left2 = characters [7].left2;
					party.ElementAt (currentCharacter-1).right = characters [7].right;
					party.ElementAt (currentCharacter-1).right2 = characters [7].right2;
					party.ElementAt (currentCharacter-1).texture = characters [7].back;
					break;
				}

				if (m.ButtonFlags == MouseButtonFlags.LeftDown) {
					Console.WriteLine ("X Position: " + cursorX + " | Y Position: " + cursorY);
				}



				if (m.ButtonFlags == MouseButtonFlags.LeftDown) {
					//display of character
					//Left arrow
					if ((cursorX >= 39 && cursorX <= 115) && (cursorY >= 240 && cursorY <= 288) && CurrentDisplayCharacter[currentCharacter-1] > 1) {
						CurrentDisplayCharacter[currentCharacter-1]--;
					}
					//Right arrow
					if ((cursorX >= 160 && cursorX <= 225) && (cursorY >= 240 && cursorY <= 288) && CurrentDisplayCharacter[currentCharacter-1] < 8) {
						CurrentDisplayCharacter[currentCharacter-1]++;
					}

					//currently selected character
					//Left arrow
					if ((cursorX >= 10 && cursorX <= 129) && (cursorY >= 620 && cursorY <= 700) && currentCharacter > 1) {
						currentCharacter--;
					}
						
					//Right arrow
					if ((cursorX >= 870 && cursorX <= 1000) && (cursorY >= 620 && cursorY <= 700)) {
						//Add class points
						if (currentCharacter == 4) {
							foreach (PlayerChar character in party) {
								switch (character.characterClass) {
								case "Warrior":
									character.strength += 5;
									break;
								case "Rogue":
									character.agility += 5;
									break;

								case "Wizard":
									character.wisdom += 3;
									character.intelligence += 3;
									break;
								}
							}
							//switch to game map
							status = GameStatus.map;
						} else {
							party.ElementAt (currentCharacter - 1).big = characters [0].big;
							currentCharacter++;
						}
					}

					//Class selection
					//left arrow
					if ((cursorX >= 37 && cursorX <= 110) && (cursorY >= 463 && cursorY <= 515) && !(party.ElementAt (currentCharacter - 1).characterClass.Equals("Warrior"))) {
						if(party.ElementAt (currentCharacter - 1).characterClass.Equals("Rogue")){
							party.ElementAt (currentCharacter - 1).characterClass = "Warrior";
						}else{
							party.ElementAt (currentCharacter - 1).characterClass = "Rogue";
						}
					}

					//Right arrow
					if ((cursorX >= 250 && cursorX <= 335) && (cursorY >= 463 && cursorY <= 515) && !(party.ElementAt (currentCharacter - 1).characterClass.Equals("Wizard"))) {
						if(party.ElementAt (currentCharacter - 1).characterClass.Equals("Rogue")){
							party.ElementAt (currentCharacter - 1).characterClass = "Wizard";
						}else{
							party.ElementAt (currentCharacter - 1).characterClass = "Rogue";
						}
					}

					//strength +

					if ((cursorX >= 700 && cursorX <= 715) && (cursorY >= 259 && cursorY <= 272) && (pointsRemainingforCharacter[(currentCharacter - 1)] > 0)) {
						party.ElementAt (currentCharacter - 1).strength++;
						pointsRemainingforCharacter[currentCharacter-1]--;
					}
					//Strength -

					if ((cursorX >= 745 && cursorX <= 752) && (cursorY >= 264 && cursorY <= 272) && party.ElementAt (currentCharacter - 1).strength > 1) {
						party.ElementAt (currentCharacter - 1).strength--;
						pointsRemainingforCharacter[currentCharacter-1]++;
					}

					//intelligence +

					if ((cursorX >= 700 && cursorX <= 715) && (cursorY >= 310 && cursorY <= 322) && (pointsRemainingforCharacter[(currentCharacter - 1)] > 0)) {
						party.ElementAt (currentCharacter - 1).intelligence++;
						pointsRemainingforCharacter[currentCharacter-1]--;
					}
					//intelligence -

					if ((cursorX >= 745 && cursorX <= 752) && (cursorY >= 310 && cursorY <= 322) && party.ElementAt (currentCharacter - 1).intelligence > 1) {
						party.ElementAt (currentCharacter - 1).intelligence--;
						pointsRemainingforCharacter[currentCharacter-1]++;
					}

					//Agility +

					if ((cursorX >= 700 && cursorX <= 715) && (cursorY >= 357 && cursorY <= 372) && (pointsRemainingforCharacter[(currentCharacter - 1)] > 0)) {
						party.ElementAt (currentCharacter - 1).agility++;
						pointsRemainingforCharacter[currentCharacter-1]--;
					}
					//Agility -

					if ((cursorX >= 745 && cursorX <= 752) && (cursorY >= 357 && cursorY <= 372) && party.ElementAt (currentCharacter - 1).agility > 1) {
						party.ElementAt (currentCharacter - 1).agility--;
						pointsRemainingforCharacter[currentCharacter-1]++;
					}

					//Wisdom +

					if ((cursorX >= 700 && cursorX <= 715) && (cursorY >= 411 && cursorY <= 423) && (pointsRemainingforCharacter[(currentCharacter - 1)] > 0)) {
						party.ElementAt (currentCharacter - 1).wisdom++;
						pointsRemainingforCharacter[currentCharacter-1]--;
					}
					//Wisdom -

					if ((cursorX >= 745 && cursorX <= 752) && (cursorY >= 411 && cursorY <= 423) && party.ElementAt (currentCharacter - 1).wisdom > 1) {
						party.ElementAt (currentCharacter - 1).wisdom--;
						pointsRemainingforCharacter[currentCharacter-1]++;
					}
						
				}


					
>>>>>>> dev/development
            }

			if (status == GameStatus.tutorial) {

				if (m.ButtonFlags == MouseButtonFlags.LeftDown) {
					Console.WriteLine ("X Position: " + cursorX + " | Y Position: " + cursorY);
				}

				if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 840 && cursorY >= 610 && cursorX <= 1000 && cursorY <= 700) {
					Graphics.switchTutorialScreen (true);
				} else if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 60 && cursorY >= 610 && cursorX <= 180 && cursorY <= 700) {
					Graphics.switchTutorialScreen (false);
				} else if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 460 && cursorY >= 650 && cursorX <= 550 && cursorY <= 730) {
					Graphics.switchTutorialScreen (false);
					status = GameStatus.mainMenu;
				}

			}

			if (status == GameStatus.battleScreen) {
				//Console.WriteLine("X Position: " + cursorX + "Y Position: " + cursorY);
				//Console.WriteLine("Monster Location: " + m1.xLocation + " , " + m1.yLocation);
				if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorX <= 560 && cursorY >= 500 && cursorY <= 560) {

                    int choseChar = rand.Next(party.Count);

                    //party[choseChar].texture = party[choseChar].att;
                    party[choseChar].health -= m1.attack(rand);
                    //party[0].health -= 10;
                    foreach (PlayerChar p in party)
                    {
                        if (p == party[choseChar]) party[choseChar].texture = Graphics.switchBattleCharTexture(true, party[choseChar]);
                        else p.texture = Graphics.switchBattleCharTexture(false, p);
                    }
                    
                    //assigning experience to character
                    party[choseChar].experience += (int)(m1.health*1.5);
                    
                    //attack monster
                    m1.health -= party[choseChar].attack(rand);

                    //assign experience to character
                    party[choseChar].experience -= (int)(m1.health*1.5);
                    

                    if (party[choseChar].health < 1)
                    {
                        if (party[choseChar] == party[0])
                        {
                            party[choseChar + 1].xGridLocation = party[choseChar].xGridLocation;
                            party[choseChar + 1].yGridLocation = party[choseChar].yGridLocation;
                        }
                        party.Remove(party[choseChar]);
                    }

                    //Console.WriteLine("Player: " + party[0].health + "\n" + "Monster: " + m1.health + "\nChar1: " + party[1].health + "\nChar2: " + party[2].health + "\nChar3: " + party[3].health);
                    int i = 1;
                    foreach (PlayerChar alive in party)
                    {
                        Console.WriteLine("Character " + i + ": " + alive.experience);
                        i++;
                    }
                    //Console.WriteLine("Monster: " + m1.health + "\n");*/
                    if (party.Count == 0)
                        isEveryoneDead = true;

                    if (isEveryoneDead)
                        status = GameStatus.lose;
                    else if (m1.health < 1)
                    {
                        //party[0].texture = party[0].back;
                        status = GameStatus.map;
                        //status = GameStatus.win;
                    }
				}
			}

            if (status == GameStatus.lose || status == GameStatus.win)
            {
                //win lose messages go here 
                //if (m.ButtonFlags == MouseButtonFlags.LeftDown)
                    //Console.Write (cursorX + "," + cursorY);
                if (cursorX >= 200 && cursorX <= 450 && cursorY >= 525 && cursorY <= 620)
                {
                    Graphics.switchMenuButton(true);
                    if (m.ButtonFlags == MouseButtonFlags.LeftDown)
                    {
                        status = GameStatus.mainMenu;
                        reset();
                    }
                }
                else 
                {
                    Graphics.switchMenuButton(false);
                }

                if (cursorX >= 550 && cursorX <= 770 && cursorY >= 525 && cursorY <= 620)
                {
                    Graphics.switchMQuitButton(true);
                    if (m.ButtonFlags == MouseButtonFlags.LeftDown)
                    {
                        Cleanup();
                    }
                }
                else
                {
                    Graphics.switchMQuitButton(false);
                }
            }


		}

		public static void  Device_keyboardInput (object sender, KeyboardInputEventArgs e)
		{
			//Runs twice for some reason....
			//Console.Out.WriteLine ("Key pressed: " + e.Key + ". x value: " + p1.getXLocation() + ". y value: " + p1.getYLocation());
			//First if is probably redundant but whatever
			//Everything else is self explainatory.

			if ((m1.health > 0 && status == GameStatus.map && isAdjacent (party [0].xGridLocation, party [0].yGridLocation, m1.xGridLocation, m1.yGridLocation))) {
				//save player's location
				characterX = party [0].xLocation;
				characterY = party [0].yLocation;
				//player.texture = Graphics.createTexture (device9, pright);
				//m1.texture = Graphics.createTexture (device9, m1Left);

                  
				status = GameStatus.battleScreen;
			}

			if (e.State == KeyState.Pressed && status == GameStatus.map) {
				//Console.WriteLine("X: " + party[0].xGridLocation + " Y: " + party[0].yGridLocation);
				if (e.Key == Keys.Down && worldTiles [party [0].xGridLocation, party [0].yGridLocation - 1].worldObject.texture == null
				    && worldTiles [party [0].xGridLocation, party [0].yGridLocation - 1].worldObject != null) {

					tileY2 -= 60f;
					if (m1.health > 0)
						m1.moveVisually (0, -60f);

					if (changePlayerFront)
                        //party[0].texture = (Graphics.createTexture (device9, pfront1)); // MEMORY LEAK
                        party [0].texture = party [0].front2;
					else
                        //party[0].texture = (Graphics.createTexture(device9, pfront));
                        party [0].texture = party [0].front;

					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = new WorldObject ();
					party [0].yGridLocation = worldTiles [party [0].xGridLocation, party [0].yGridLocation - 1].yGrid;
	
					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = party [0];

					changePlayerFront = !changePlayerFront;
				} else if (e.Key == Keys.Up && worldTiles [party [0].xGridLocation, party [0].yGridLocation + 1].worldObject.texture == null
				           && worldTiles [party [0].xGridLocation, party [0].yGridLocation + 1].worldObject != null) {

					tileY2 += 60f;
					if (m1.health > 0)
						m1.moveVisually (0, 60f);

					if (changePlayerBack)
						party [0].texture = party [0].back2; //(Graphics.createTexture (device9, pback1));
                    else
						party [0].texture = party [0].back; //(Graphics.createTexture(device9, pback));

					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = new WorldObject ();
					party [0].yGridLocation = worldTiles [party [0].xGridLocation, party [0].yGridLocation + 1].yGrid;

					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = party [0];


					changePlayerBack = !changePlayerBack;
				} else if (e.Key == Keys.Left && worldTiles [party [0].xGridLocation - 1, party [0].yGridLocation].worldObject.texture == null
				           && worldTiles [party [0].xGridLocation - 1, party [0].yGridLocation].worldObject != null) {

				
					tileX2 += 60f;
					if (m1.health > 0)
						m1.moveVisually (60f, 0);

					if (changePlayerLeft)
						party [0].texture = party [0].left2; //(Graphics.createTexture (device9, pleft1));
					else
						party [0].texture = party [0].left; // (Graphics.createTexture(device9, pleft));
					changePlayerLeft = !changePlayerLeft;

					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = new WorldObject ();
					party [0].xGridLocation = worldTiles [party [0].xGridLocation - 1, party [0].yGridLocation].xGrid;

					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = party [0];

				} else if (e.Key == Keys.Right && worldTiles [party [0].xGridLocation + 1, party [0].yGridLocation].worldObject.texture == null
				           && worldTiles [party [0].xGridLocation + 1, party [0].yGridLocation].worldObject != null) {

					tileX2 -= 60f;
					if (m1.health > 0)
						m1.moveVisually (-60f, 0);

					if (changePlayerRight)
						party [0].texture = party [0].right2; //(Graphics.createTexture (device9, pright1));
                    else
						party [0].texture = party [0].right; //(Graphics.createTexture(device9, pright));
					changePlayerRight = !changePlayerRight;

					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = new WorldObject ();
					party [0].xGridLocation = worldTiles [party [0].xGridLocation + 1, party [0].yGridLocation].xGrid;

					worldTiles [party [0].xGridLocation, party [0].yGridLocation].worldObject = party [0];

				}
					
				if ((m1.health > 0 && status == GameStatus.map && isAdjacent (party [0].xGridLocation, party [0].yGridLocation, m1.xGridLocation, m1.yGridLocation))) {
					//save party[0]'s location
					characterX = party [0].xLocation;
					characterY = party [0].yLocation;
					//party[0].texture = Graphics.createTexture (device9, pright);
					//m1.texture = Graphics.createTexture (device9, m1Left);
                   
					status = GameStatus.battleScreen;
				}

				
				if (arrowOrNot (e) && m1.health > 0 && status == GameStatus.map) {
					int XorY = rand.Next (1, 3);
					//Console.WriteLine(XorY);
					if (XorY == 1) {
						if ((m1.xGridLocation > party [0].xGridLocation) && (worldTiles [m1.xGridLocation - 1, m1.yGridLocation].worldObject.texture == null)) {

							//change monster Texture
							if (changeM1Left)
								m1.texture = (Graphics.createTexture (device9, m1Left));
							else
								m1.texture = (Graphics.createTexture (device9, m1Left1));

							changeM1Left = !changeM1Left;
							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
							m1.xGridLocation = worldTiles [m1.xGridLocation - 1, m1.yGridLocation].xGrid;

							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;

						} else if (m1.xGridLocation < party [0].xGridLocation && (worldTiles [m1.xGridLocation + 1, m1.yGridLocation].worldObject.texture == null)) {

							//change monster texture
							if (changeM1Right)
								m1.texture = (Graphics.createTexture (device9, m1Right));
							else
								m1.texture = (Graphics.createTexture (device9, m1Right1));

							changeM1Right = !changeM1Right;

							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
							m1.xGridLocation = worldTiles [m1.xGridLocation + 1, m1.yGridLocation].xGrid;
                            
							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;
						} else {
							if (m1.yGridLocation > party [0].yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation - 1].worldObject.texture == null)) {
								if (changeM1Back)
									m1.texture = (Graphics.createTexture (device9, m1Front));
								else
									m1.texture = (Graphics.createTexture (device9, m1Front1));

								changeM1Back = !changeM1Back;
								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
								m1.yGridLocation = worldTiles [m1.xGridLocation, m1.yGridLocation - 1].yGrid;

								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;
							} else if (m1.yGridLocation < party [0].yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation + 1].worldObject.texture == null)) {
								//change monster texture
								if (changeM1Front)
									m1.texture = (Graphics.createTexture (device9, m1Back));
								else
									m1.texture = (Graphics.createTexture (device9, m1Back1));

								changeM1Front = !changeM1Front;

								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
								m1.yGridLocation = worldTiles [m1.xGridLocation, m1.yGridLocation + 1].yGrid;

								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;
								//Console.Out.WriteLine("C4: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
							}
						}
					} else {
						if (m1.yGridLocation > party [0].yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation - 1].worldObject.texture == null)) {
							//change monster texture
							if (changeM1Back)
								m1.texture = (Graphics.createTexture (device9, m1Front));
							else
								m1.texture = (Graphics.createTexture (device9, m1Front1));

							changeM1Back = !changeM1Back;

							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
							m1.yGridLocation = worldTiles [m1.xGridLocation, m1.yGridLocation - 1].yGrid;

							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;
							//Console.Out.WriteLine("C5: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
						} else if (m1.yGridLocation < party [0].yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation + 1].worldObject.texture == null)) {
							//change monster texture
							if (changeM1Front)
								m1.texture = (Graphics.createTexture (device9, m1Back));
							else
								m1.texture = (Graphics.createTexture (device9, m1Back1));

							changeM1Front = !changeM1Front;
							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
							m1.yGridLocation = worldTiles [m1.xGridLocation, m1.yGridLocation + 1].yGrid;

							worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;
							//Console.Out.WriteLine("C6: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
						} else {
							if (m1.xGridLocation > party [0].xGridLocation && (worldTiles [m1.xGridLocation - 1, m1.yGridLocation].worldObject.texture == null)) {

								//change monster Texture
								if (changeM1Left)
									m1.texture = (Graphics.createTexture (device9, m1Left));
								else
									m1.texture = (Graphics.createTexture (device9, m1Left1));

								changeM1Left = !changeM1Left;
								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
								m1.xGridLocation = worldTiles [m1.xGridLocation - 1, m1.yGridLocation].xGrid;

								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;
								//Console.Out.WriteLine("C7: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
							} else if (m1.xGridLocation < party [0].xGridLocation && (worldTiles [m1.xGridLocation + 1, m1.yGridLocation].worldObject.texture == null)) {

								//change monster texture
								if (changeM1Right)
									m1.texture = (Graphics.createTexture (device9, m1Right));
								else
									m1.texture = (Graphics.createTexture (device9, m1Right1));

								changeM1Right = !changeM1Right;
                                
                                
								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = new WorldObject ();
								m1.xGridLocation = worldTiles [m1.xGridLocation + 1, m1.yGridLocation].xGrid;

								worldTiles [m1.xGridLocation, m1.yGridLocation].worldObject = m1;
								//Console.Out.WriteLine("C8: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
							}
						}
					}
				}
			}

			if (status == GameStatus.createCharacter) {

				//name input
				if(e.State == KeyState.Pressed ){

					if ((e.Key == Keys.Back) && party.ElementAt (currentCharacter - 1).name.Length != 0) {
						party.ElementAt (currentCharacter - 1).name = party.ElementAt (currentCharacter - 1).name.Substring (0, party.ElementAt (currentCharacter - 1).name.Length - 1);
					}
					if (!(e.Key == Keys.Back) && !(e.Key == Keys.ShiftKey) && (party.ElementAt (currentCharacter - 1).name.Length <= 10)) {
						builder.Append (party.ElementAt (currentCharacter - 1).name);
						builder.Append (e.Key);
						party.ElementAt (currentCharacter - 1).name = builder.ToString();
						builder.Clear ();
					}

				}

			}
		}

		//reset health and position for player
        public static void reset()
        {
            //reset monster and character location
            monster1X = 300;
            monster1Y = 240;
            characterX = 420;
            characterY = 300;

            tileX = 0;
            tileY = 0;

            tileX2 = 0;
            tileY2 = 0;

            //reset the party
            //characters.Clear();
            party.Clear();



            //add members to the party
            //party.Add(player);
            /*party.Add(characters[0]);
            party.Add(characters[1]);
            party.Add(characters[2]);
            party.Add(characters[3]);*/

			party.Add(new PlayerChar());
			party.Add(new PlayerChar());
			party.Add(new PlayerChar());
			party.Add(new PlayerChar());
            //Intialize the world
            World world = new World();
            world.wall = Graphics.createTexture(device9, wall);
            world.tile = Graphics.createTexture(device9, tiles);


            //create world grid
            worldTiles = world.makeWorld(WORLDSIZE);

            //Player's initial position on the grid.

            party[0].xGridLocation = 6;
            party[0].yGridLocation = 5;



            //Make starting room.
            Tile[,] startingRoom = world.makeStartingRoom(party[0]);

            //place the room on the world grid.
            worldTiles = world.PlaceRoomOnWorld(worldTiles, startingRoom, 15, 50);

            //place initial monster on the grid
            m1.xGridLocation = party[0].xGridLocation + 5;
            m1.yGridLocation = party[0].yGridLocation + 5;
            worldTiles[m1.xGridLocation, m1.yGridLocation].worldObject = m1;



            worldTiles = world.generateLevel(worldTiles, world, MAXROOMS);



            //player.texture = characters[0].back; //Graphics.createTexture(device9, pback);
            //player.right = characters[0].right;//Graphics.createTexture(device9, pright);
            changePlayerBack = !changePlayerBack;
            //initialize monster

            m1.texture = Graphics.createTexture(device9, m1Front1);
            changeM1Front = !changeM1Front;

            //char1.texture = Graphics.createTexture(device9, char1Texture1);
            //char2.texture = Graphics.createTexture(device9, char2Texture1);
            //char3.texture = Graphics.createTexture(device9, char3Texture1);
            //set initial health for player and monster and it's party
            m1.health = 100; //player.health = char1.health = char2.health = char3.health = 100;
            foreach (PlayerChar member in party)
            {
                member.texture = member.right;
                member.health = 100;
            }


            battleScreen = Graphics.createTexture(device9, battleScr);

            //create battlescreen textures
            Graphics.createBattleScreenTextures(device9);


        }

        //Dispose unused
		private static void Cleanup ()
		{

			sprite.Dispose ();
			sprite2.Dispose ();
			sprite3.Dispose ();

			Graphics.disposeMainMenu ();
			Graphics.disposeTutorial ();
            Graphics.disposeMessageScreen();

            Graphics.disposebattle();
			Graphics.disposeCharacterScreenTextures ();

            party = Graphics.disposeCharacterTextures(party);
			characters = Graphics.disposeCharacterTextures (characters);

            Graphics.disposeCharacterScreenTextures();

			music.Dispose ();

                Application.Exit();
                if (device9 != null)
                    device9.Dispose();
		}
			
	}


}
