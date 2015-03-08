using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Windows;
using SlimDX.Design;
using SlimDX.RawInput;
using SlimDX.Multimedia;
using SlimDX.DirectSound;

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

		static Sprite sprite4;

		//tiles
		//static Texture tiles;


        //menu background
        static string menuBG = "..\\..\\sprites\\background.png";
        //static Texture menuBGTex
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

		//object for player
		static PlayerChar player = new PlayerChar (null, characterX, characterY, 0, 0);

		//gets all the sprite location for the player
		static string pback = "..\\..\\sprites\\pback.png";
		static string pback1 = "..\\..\\sprites\\pback1.png";
		static string pfront = "..\\..\\sprites\\pfront.png";
		static string pfront1 = "..\\..\\sprites\\pfront1.png";
		static string pleft = "..\\..\\sprites\\pleft.png";
		static string pleft1 = "..\\..\\sprites\\pleft1.png";
		static string pright = "..\\..\\sprites\\pright.png";
		static string pright1 = "..\\..\\sprites\\pright1.png";
		static bool changePlayerBack = false;
		static bool changePlayerFront = false;
		static bool changePlayerLeft = false;
		static bool changePlayerRight = false;

		static SoundBuffer music;


		//object for monster
		static Monsterchar m1 = new Monsterchar (null, monster1X, monster1Y, 0, 0);
		//gets all the sprite location for the monster

		static string monsterCharSprite = "..\\..\\sprites\\monster.png";


		static string m1Front = "..\\..\\sprites\\PS_front.png";
		static string m1Front1 = "..\\..\\sprites\\PS_front2.png";
		static string m1Back = "..\\..\\sprites\\PS_back.png";
		static string m1Back1 = "..\\..\\sprites\\PS_back2.png";
		static string m1Right = "..\\..\\sprites\\PS_right.png";
		static string m1Right1 = "..\\..\\sprites\\PS_right2.png";
		static string m1Left = "..\\..\\sprites\\PS_left.png";
		static string m1Left1 = "..\\..\\sprites\\PS_left2.png";
		static bool changeM1Back = false;
		static bool changeM1Front = false;
		static bool changeM1Left = false;
		static bool changeM1Right = false;


		// create new form
		static RenderForm form;

		//Random Number Generator
		static Random rand = new Random ();

		//object for graphics
		static Graphics graphics = new Graphics ();

		//enum for status
		static GameStatus status = GameStatus.mainMenu;


		//grid
		static Tile[,] worldTiles;

		const int WORLDSIZE = 100;
		//<- Grid size




		//test color
		//static SlimDX.Color4 colorTest = new SlimDX.Color4 (Color.White);


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


				Icon icon = Graphics.createIcon ();

				//set the form's icon.
				form.Icon = icon;

				//Create our device, textures and sprites

				device9 = graphics.initializeGraphics (form);

				//initialize player
				//player1 = graphics.createPlayer (pback, device9);


				//player.pTexture = (Graphics.createTexture (device9, pback));
				//player.health = 10;
				//initialize monster
				//monster1 = graphics.createMonster(device9);
				//m1.texture = (Graphics.createTexture (device9, m1Front));
               // m1.health = 100;

				//Intialize the world
				World world = new World ();
				world.wall = Graphics.createTexture (device9, wall);
				world.tile = Graphics.createTexture (device9, tiles);


				//create world grid
				worldTiles = world.makeWorld (WORLDSIZE);

				player.xGridLocation = 6;
				player.yGridLocation = 5;



				//Make starting room.
				Tile[,] startingRoom = world.makeStartingRoom (player);





				//place the room on the world grid.
				worldTiles = world.PlaceRoomOnWorld (worldTiles, startingRoom, 30);

                //place monster
                m1.xGridLocation = player.xGridLocation + 5;
                m1.yGridLocation = player.yGridLocation + 5;
                //m1.xLocation = player.xLocation + 300;
                //m1.yLocation = player.yLocation + 300;
                //monster1X = m1.xLocation;
                //monster1Y = m1.yLocation;
                //m1.moveVisually(m1.xLocation, m1.yLocation);
                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;



				Tile[,] horizontalConnector = world.makeHorizontalConnector ();

				worldTiles = world.connectRoom (worldTiles, horizontalConnector, world.roomExit.Dequeue ());


				Tile[,] PlusSignRoom = world.makePlusSignRoom ();

				player.pTexture = (Graphics.createTexture (device9, pback));
				changePlayerBack = !changePlayerBack;
				//initialize monster
				//monster1 = graphics.createMonster(device9);
				m1.texture = (Graphics.createTexture (device9, m1Front1));
				changeM1Front = !changeM1Front;
				//set initial health for player and monster
				m1.health = player.health = 100;
				//initialize tiles

				worldTiles = world.connectRoom (worldTiles, PlusSignRoom, world.roomExit.Dequeue ());


				Tile[,] horizontalConnector2 = world.makeHorizontalConnector ();

				worldTiles = world.connectRoom (worldTiles, horizontalConnector2, world.roomExit.Dequeue ());


				Tile[,] square = world.makeSquareRoom ();

				worldTiles = world.connectRoom (worldTiles, square, world.roomExit.Dequeue ());


				//initialize tiles
						


				//background for map
				mapBg = Graphics.createTexture (device9, bg);

                //background for menu
                //menuBGTex = Graphics.createTexture(device9, menuBG)

				sprite = new Sprite (device9);
				sprite2 = new Sprite (device9);
				sprite3 = new Sprite (device9);
				sprite4 = new Sprite (device9);


				//Gimme da keyboards
				SlimDX.RawInput.Device.RegisterDevice (UsagePage.Generic, UsageId.Keyboard, SlimDX.RawInput.DeviceFlags.None);
				SlimDX.RawInput.Device.KeyboardInput += new EventHandler <KeyboardInputEventArgs> (Device_keyboardInput);

				//Mouse
				SlimDX.RawInput.Device.RegisterDevice (UsagePage.Generic, UsageId.Mouse, SlimDX.RawInput.DeviceFlags.None);
				SlimDX.RawInput.Device.MouseInput += new EventHandler<MouseInputEventArgs> (Device_mouseInput);



                playMusic();



				//create main menu textures

				Graphics.createMainMenuTextures (device9);

				//create tutorial textures

				Graphics.createTutorialTextures (device9);

                battleScreen = Graphics.createTexture(device9, battleScr);



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

			sprite.Begin (SpriteFlags.AlphaBlend);
			sprite2.Begin (SpriteFlags.AlphaBlend);
			sprite3.Begin (SpriteFlags.AlphaBlend);
			sprite4.Begin (SpriteFlags.AlphaBlend);

			//not sure why we need this yet...
			SlimDX.Color4 color = new SlimDX.Color4 (Color.White);

			if (status == GameStatus.mainMenu) {
				Graphics.renderMainMenu (color, device9, sprite);
			}

			//Console.WriteLine(status);
			if (status == GameStatus.map) {
				renderGameRoom (color);
			}

			if (status == GameStatus.tutorial) {
				Graphics.renderTutorial (color, device9, sprite);
			}

			//render battle screen. About to get serious now :O
			if (status == GameStatus.battleScreen) {
				renderBattleScreen (color);
			}


			//end render
			sprite.End ();
			sprite2.End ();
			sprite3.End ();
			sprite4.End ();

			// End the scene.
			device9.EndScene ();

			// Present the backbuffer contents to the screen.
			device9.Present ();

		}


		public static void renderGameRoom (SlimDX.Color4 color)
		{
			status = GameStatus.map;
			//renders sprite for tile and player

			player.xLocation = characterX;
			player.yLocation = characterY;

			//render bg
			sprite.Transform = Matrix.Translation (0, 0, 0);
			sprite.Draw (mapBg, color);
			//renders tile texture

			makeTiles (sprite, color);


			//renders player texture
			sprite.Transform = Matrix.Translation (player.xLocation, player.yLocation, 0);
			sprite.Draw (player.pTexture, color);


			//renders monster sprite

			if (m1.health > 0) {
				//sprite2.Transform = Matrix.Translation (m1.xLocation, m1.yLocation, 0);
				//sprite2.Draw (m1.texture, color);
			} else {
				//sprite2.Transform = Matrix.Translation (0, 0, 0);
                m1.texture = null;
			}

			//Translate the sprite with a 3d matrix with no z change.
			//return currStatus;
		}

    
		public static void renderBattleScreen (SlimDX.Color4 color)
		{
			/*
             * change the player's and monster position for the battle screen
             * save the previous screen
             * */
			status = GameStatus.battleScreen;
			//player.health = 100;
			//m1.health = 100;
			player.yLocation = 500;
			player.xLocation = 100;
			m1.yLocation = 500;
			m1.xLocation = 500;

			sprite.Transform = Matrix.Translation (0, 0, 0);
			sprite.Draw (battleScreen, color);
			sprite.Transform = Matrix.Translation (player.xLocation, player.yLocation, 0);
			sprite.Draw (player.pTexture, color);

			//m1.xLocation -= 60;
			sprite2.Transform = Matrix.Translation (m1.xLocation, m1.yLocation, 0);
			sprite2.Draw (m1.texture, color);
			// while (m1.xLocation != player.xLocation - 60)
			//{
			//    m1.move(-60,0);
			//}
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
						sprite.Transform = Matrix.Translation (worldTiles [x, y].xLocation + tileX2, worldTiles [x, y].yLocation + tileY2, 0);
						sprite.Draw (worldTiles [x, y].texture, color);

						//System.Console.Out.WriteLine (worldTiles [x, y].xLocation + " y: " + worldTiles [x, y].yLocation);
					}
					if (worldTiles [x, y].wObject != null) {
						if (worldTiles [x, y].wObject.texture != null && worldTiles [x, y].wObject.texture != player.pTexture) {
							sprite.Transform = Matrix.Translation (worldTiles [x, y].xLocation + tileX2, worldTiles [x, y].yLocation + tileY2, 0);
							sprite.Draw (worldTiles [x, y].wObject.texture, color);
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
					status = GameStatus.map;
				} else if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 470 && cursorX <= 1000 && cursorY <= 580) {
					Console.WriteLine ("X Position: " + cursorX + " | Y Position: " + cursorY);
					//Exit the game
					Cleanup ();
				} else if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 360 && cursorX <= 1000 && cursorY <= 430) {

					//start tutorial
					status = GameStatus.tutorial;

				}
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
				if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= m1.xLocation && cursorX <= m1.xLocation + 60 && cursorY >= m1.yLocation && cursorY <= m1.yLocation + 60) {

					m1.health -= player.attack (rand);
					player.health -= m1.attack (rand);
					Console.WriteLine ("Player: " + player.health + "\n" + "Monster: " + m1.health);
					if (player.health < 1)
						status = GameStatus.mainMenu;
					else if (m1.health < 1)
						status = GameStatus.map;
				}
			}


		}

		public static void  Device_keyboardInput (object sender, KeyboardInputEventArgs e)
		{
			//Runs twice for some reason....
			//Console.Out.WriteLine ("Key pressed: " + e.Key + ". x value: " + p1.getXLocation() + ". y value: " + p1.getYLocation());
			//First if is probably redundant but whatever
			//Everything else is self explainatory.

			//if (m1.health > 0 && (((m1.xGridLocation + 1 == player.xGridLocation) || (m1.xGridLocation - 1 == player.xGridLocation) && m1.yGridLocation == player.yGridLocation)
			  //  || ((m1.yGridLocation + 1 == player.yGridLocation) || (m1.yGridLocation - 1 == player.yGridLocation)) && m1.xGridLocation == player.xGridLocation)) {
				//Console.WriteLine("Monster Location: " + m1.xLocation + "," + m1.yLocation + "\t" + "Player Location: " + player.xLocation + "," + player.yLocation);
            if ((m1.health > 0 && status == GameStatus.map && isAdjacent(player.xGridLocation, player.yGridLocation,m1.xGridLocation,m1.yGridLocation)))//) && ((m1.xGridLocation == player.xGridLocation || m1.xGridLocation == player.xGridLocation + 1 || m1.xGridLocation == player.xGridLocation - 1) && ((m1.yGridLocation == player.yGridLocation + 1) || m1.yGridLocation == player.yGridLocation - 1) || ((m1.yGridLocation == player.yGridLocation || m1.yGridLocation == player.yGridLocation + 1 || m1.yGridLocation == player.yGridLocation - 1) && ((m1.xGridLocation == player.xGridLocation + 1) || (m1.xGridLocation == player.xGridLocation - 1)))))
            {
                /*if (m1.xLocation == player.xLocation)
					m1.xLocation -= 60f;
				else if (m1.yLocation == player.yLocation)
					m1.yLocation -= 60f;*/
				//save player's location
				characterX = player.xLocation;
				characterY = player.yLocation;
				player.pTexture = Graphics.createTexture (device9, pright);
				m1.texture = Graphics.createTexture (device9, m1Left);
				//if (m1.health > 0) 
                status = GameStatus.battleScreen;
			}

			if (e.State == KeyState.Pressed && status == GameStatus.map) {
                //Console.WriteLine("X: " + player.xGridLocation + " Y: " + player.yGridLocation);
				if (e.Key == Keys.Down && worldTiles [player.xGridLocation, player.yGridLocation - 1].wObject.texture == null
				    && worldTiles [player.xGridLocation, player.yGridLocation - 1].wObject != null) {
					//if (m1.health > 0) m1.moveVisually(0, -60f);
					//characterY = characterY + 60f;
					//monster1Y -= 60f;
					//m1.setYLocation(-60f);
					//monsterChar.move(0, -60f);

				    tileY2 -= 60f;
                    if (m1.health > 0) m1.moveVisually(0, -60f);

					if (changePlayerFront)
						player.pTexture = (Graphics.createTexture (device9, pfront1)); // MEMORY LEAK
					else
						player.pTexture = (Graphics.createTexture (device9, pfront));

					worldTiles [player.xGridLocation, player.yGridLocation].wObject = new WorldObject ();
					player.yGridLocation = worldTiles [player.xGridLocation, player.yGridLocation - 1].yGrid;
	
					worldTiles [player.xGridLocation, player.yGridLocation].wObject = player;

					changePlayerFront = !changePlayerFront;
				} else if (e.Key == Keys.Up && worldTiles [player.xGridLocation, player.yGridLocation + 1].wObject.texture == null
				         && worldTiles [player.xGridLocation, player.yGridLocation + 1].wObject != null) {
					//characterY = characterY - 60f;
					//monster1Y += 60f;
					//m1.setYLocation(60f);
					//	monsterChar.move(0, 60f);
					//if (m1.health > 0) m1.moveVisually(0, 60f);
					tileY2 += 60f;
                    if (m1.health > 0) m1.moveVisually(0, 60f);

					if (changePlayerBack)
						player.pTexture = (Graphics.createTexture (device9, pback1));
					else
						player.pTexture = (Graphics.createTexture (device9, pback));

					worldTiles [player.xGridLocation, player.yGridLocation].wObject = new WorldObject ();
					player.yGridLocation = worldTiles [player.xGridLocation, player.yGridLocation + 1].yGrid;

					worldTiles [player.xGridLocation, player.yGridLocation].wObject = player;


					changePlayerBack = !changePlayerBack;
				} else if (e.Key == Keys.Left && worldTiles [player.xGridLocation - 1, player.yGridLocation].wObject.texture == null
				         && worldTiles [player.xGridLocation - 1, player.yGridLocation].wObject != null) {

					//monster1X += 60f;
					//m1.setXLocation(60f);
					//	monsterChar.move(60f, 0);
					tileX2 += 60f;
                    if (m1.health > 0) m1.moveVisually(60f, 0);

					//if (m1.health > 0) m1.moveVisually(60f, 0);
					//characterX = characterX - 60f + tileX2;
					if (changePlayerLeft)
						player.pTexture = (Graphics.createTexture (device9, pleft1));
					else
						player.pTexture = (Graphics.createTexture (device9, pleft));
					changePlayerLeft = !changePlayerLeft;

					worldTiles [player.xGridLocation, player.yGridLocation].wObject = new WorldObject ();
					player.xGridLocation = worldTiles [player.xGridLocation - 1, player.yGridLocation].xGrid;

					worldTiles [player.xGridLocation, player.yGridLocation].wObject = player;

				} else if (e.Key == Keys.Right && worldTiles [player.xGridLocation + 1, player.yGridLocation].wObject.texture == null
				         && worldTiles [player.xGridLocation + 1, player.yGridLocation].wObject != null) {
					//monster1X -= 60f;
					//m1.setXLocation(-60f);
					//	monsterChar.move(-60f, 0);
					tileX2 -= 60f;
                    if (m1.health > 0) m1.moveVisually(-60f, 0);
					//if (m1.health > 0) m1.moveVisually(-60f, 0);
					//characterX = characterX + 60f - tileX2;
					if (changePlayerRight)
						player.pTexture = (Graphics.createTexture (device9, pright1));
					else
						player.pTexture = (Graphics.createTexture (device9, pright));
					changePlayerRight = !changePlayerRight;

					worldTiles [player.xGridLocation, player.yGridLocation].wObject = new WorldObject ();
					player.xGridLocation = worldTiles [player.xGridLocation + 1, player.yGridLocation].xGrid;

					worldTiles [player.xGridLocation, player.yGridLocation].wObject = player;

				}

                //if ((m1.health > 0 && status == GameStatus.map) && ((m1.xGridLocation == player.xGridLocation || m1.xGridLocation == player.xGridLocation + 1 || m1.xGridLocation == player.xGridLocation - 1) && ((m1.yGridLocation == player.yGridLocation + 1) || m1.yGridLocation == player.yGridLocation - 1) || ((m1.yGridLocation == player.yGridLocation || m1.yGridLocation == player.yGridLocation + 1 || m1.yGridLocation == player.yGridLocation - 1) && ((m1.xGridLocation == player.xGridLocation + 1) || (m1.xGridLocation == player.xGridLocation - 1)))))
                if ((m1.health > 0 && status == GameStatus.map && isAdjacent(player.xGridLocation, player.yGridLocation, m1.xGridLocation, m1.yGridLocation)))
                {
                    //Console.WriteLine("Monster Location: " + m1.xLocation + "," + m1.yLocation + "\t" + "Player Location: " + player.xLocation + "," + player.yLocation);
                    /*if (m1.xLocation == player.xLocation)
                        m1.xLocation -= 60f;
                    else if (m1.yLocation == player.yLocation)
                        m1.yLocation -= 60f;*/
                    //save player's location
                    characterX = player.xLocation;
                    characterY = player.yLocation;
                    player.pTexture = Graphics.createTexture (device9, pright);
                    m1.texture = Graphics.createTexture (device9, m1Left);
                    //if (m1.health > 0) 
                    status = GameStatus.battleScreen;
                }

				
				if (arrowOrNot (e) && m1.health > 0 && status == GameStatus.map) {
					int XorY = rand.Next (1, 3);
					//Console.WriteLine(XorY);
					if (XorY == 1) {
						if ((m1.xGridLocation > player.xGridLocation) && (worldTiles [m1.xGridLocation - 1, m1.yGridLocation].wObject.texture == null)) {// && m1.getXLocation() <= (tileX + tileX2))//(monster1X > characterX && monster1X <= (tileX + tileX2))
							//monster1X -= 60f;
							//m1.setXLocation(-60f);
						//	m1.moveOnGrid (m1.xGridLocation - 1, m1.yGridLocation);
							//m1.move(-60f, 0);

							//change monster Texture
							if (changeM1Left)
								m1.texture = (Graphics.createTexture (device9, m1Left));
							else
								m1.texture = (Graphics.createTexture (device9, m1Left1));

							changeM1Left = !changeM1Left;
                            /*m1.moveOnGrid(m1.xGridLocation - 1, m1.yGridLocation);
                            m1.xLocation -= 60;

                            m1.moveVisually(m1.xLocation, m1.yLocation);
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;*/
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                            m1.xGridLocation = worldTiles[m1.xGridLocation -1, m1.yGridLocation ].xGrid;

                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
							//Console.Out.WriteLine("C1: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
						} else if (m1.xGridLocation < player.xGridLocation && (worldTiles [m1.xGridLocation + 1, m1.yGridLocation].wObject.texture == null)) {// && m1.getXLocation() > (tileX + tileX2))//(monster1X < characterX && monster1X < (tileX + tileX2))
							//monster1X += 60f;
							//m1.setXLocation(60f);
						//	m1.moveOnGrid (m1.xGridLocation + 1, m1.yGridLocation);
							//m1.move(60f, 0);

							//change monster texture
							if (changeM1Right)
								m1.texture = (Graphics.createTexture (device9, m1Right));
							else
								m1.texture = (Graphics.createTexture (device9, m1Right1));

							changeM1Right = !changeM1Right;
                            /*m1.moveOnGrid(m1.xGridLocation - 1, m1.yGridLocation);
                            m1.xLocation -= 60;

                            m1.moveVisually(m1.xLocation, m1.yLocation);
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;*/

                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                            m1.xGridLocation = worldTiles[m1.xGridLocation + 1, m1.yGridLocation].xGrid;
                            
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
						} else {
							if (m1.yGridLocation > player.yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation - 1].wObject.texture == null)) {// && m1.getYLocation() <= (tileY + tileY2))//(monster1Y > characterY && monster1Y <= (tileY + tileY2))
								// monster1Y -= 60f;
								//m1.setYLocation(-60f);
								//m1.moveOnGrid (m1.xGridLocation, m1.yGridLocation - 1);
								//m1.move(0, -60f);
								//change monster texture
								if (changeM1Back)
									m1.texture = (Graphics.createTexture (device9, m1Back));
								else
									m1.texture = (Graphics.createTexture (device9, m1Back1));

								changeM1Back = !changeM1Back;
                                /*m1.moveOnGrid(m1.xGridLocation - 1, m1.yGridLocation);
                            m1.xLocation -= 60;

                            m1.moveVisually(m1.xLocation, m1.yLocation);
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;*/
                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                                m1.yGridLocation = worldTiles[m1.xGridLocation, m1.yGridLocation -1].yGrid;

                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
								//Console.Out.WriteLine("C3: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
							} else if (m1.yGridLocation < player.yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation + 1].wObject.texture == null)) {// && m1.getYLocation() < (tileY + tileY2))//(monster1Y < characterY && monster1Y < (tileY + tileY2))
								//monster1Y += 60f;
								//m1.setYLocation(60f);
								//m1.moveOnGrid (m1.xGridLocation, m1.yGridLocation + 1);
								//m1.move(0, 60f);
								//change monster texture
								if (changeM1Front)
									m1.texture = (Graphics.createTexture (device9, m1Front));
								else
									m1.texture = (Graphics.createTexture (device9, m1Front1));

								changeM1Front = !changeM1Front;
                                /*m1.moveOnGrid(m1.xGridLocation - 1, m1.yGridLocation);
                            m1.xLocation -= 60;

                            m1.moveVisually(m1.xLocation, m1.yLocation);
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;*/
                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                                m1.yGridLocation = worldTiles[m1.xGridLocation, m1.yGridLocation+1].yGrid;

                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
								//Console.Out.WriteLine("C4: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
							}
						}
					} else {
						if (m1.yGridLocation > player.yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation - 1].wObject.texture == null)) {// && m1.getYLocation() <= (tileY + tileY2))//(monster1Y > characterY && monster1Y <= (tileY + tileY2))
							// monster1Y -= 60f;
							//m1.setYLocation(-60f);
							//m1.moveOnGrid (m1.xGridLocation, m1.yGridLocation - 1);
							//m1.move(0, -60f);
							//change monster texture
							if (changeM1Back)
								m1.texture = (Graphics.createTexture (device9, m1Back));
							else
								m1.texture = (Graphics.createTexture (device9, m1Back1));

							changeM1Back = !changeM1Back;

                            /*m1.moveOnGrid(m1.xGridLocation - 1, m1.yGridLocation);
                            m1.xLocation -= 60;

                            m1.moveVisually(m1.xLocation, m1.yLocation);
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;*/
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                            m1.yGridLocation = worldTiles[m1.xGridLocation, m1.yGridLocation -1].yGrid;

                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
							//Console.Out.WriteLine("C5: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
						} else if (m1.yGridLocation < player.yGridLocation && (worldTiles [m1.xGridLocation, m1.yGridLocation + 1].wObject.texture == null)) {// && m1.getYLocation() < (tileY + tileY2))//(monster1Y < characterY && monster1Y < (tileY + tileY2))
							//monster1Y += 60f;
							//m1.setYLocation(60f);
							//m1.moveOnGrid (m1.xGridLocation, m1.yGridLocation + 1);
							//m1.move(0, 60f);
							//change monster texture
							if (changeM1Front)
								m1.texture = (Graphics.createTexture (device9, m1Front));
							else
								m1.texture = (Graphics.createTexture (device9, m1Front1));

							changeM1Front = !changeM1Front;
                            /*m1.moveOnGrid(m1.xGridLocation - 1, m1.yGridLocation);
                            m1.xLocation -= 60;

                            m1.moveVisually(m1.xLocation, m1.yLocation);
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;*/
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                            m1.yGridLocation = worldTiles[m1.xGridLocation , m1.yGridLocation + 1].yGrid;

                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
							//Console.Out.WriteLine("C6: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
						} else {
							if (m1.xGridLocation > player.xGridLocation && (worldTiles [m1.xGridLocation - 1, m1.yGridLocation].wObject.texture == null)) {// && m1.getXLocation() <= (tileX + tileX2))//(monster1X > characterX && monster1X <= (tileX + tileX2))
								//monster1X -= 60f;
								//m1.setXLocation(-60f);
								//m1.moveOnGrid (m1.xGridLocation - 1, m1.yGridLocation);
								//m1.move(-60f, 0);
								//change monster Texture
								if (changeM1Left)
									m1.texture = (Graphics.createTexture (device9, m1Left));
								else
									m1.texture = (Graphics.createTexture (device9, m1Left1));

								changeM1Left = !changeM1Left;
                                /*m1.moveOnGrid(m1.xGridLocation - 1, m1.yGridLocation);
                            m1.xLocation -= 60;

                            m1.moveVisually(m1.xLocation, m1.yLocation);
                            worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;*/
                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                                m1.xGridLocation = worldTiles[m1.xGridLocation - 1, m1.yGridLocation].xGrid;

                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
								//Console.Out.WriteLine("C7: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
							} else if (m1.xGridLocation < player.xGridLocation && (worldTiles [m1.xGridLocation + 1, m1.yGridLocation].wObject.texture == null)) {// && m1.getXLocation() < (tileX + tileX2))//(monster1X < characterX && monster1X < (tileX + tileX2))
								//monster1X += 60f;
								//m1.setXLocation(60f);
								//m1.moveOnGrid (m1.xGridLocation + 1, m1.yGridLocation);
								//m1.move(60f, 0);
								//change monster texture
								if (changeM1Right)
									m1.texture = (Graphics.createTexture (device9, m1Right));
								else
									m1.texture = (Graphics.createTexture (device9, m1Right1));

								changeM1Right = !changeM1Right;
                                
                                
                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = new WorldObject();
                                m1.xGridLocation = worldTiles[m1.xGridLocation + 1, m1.yGridLocation].xGrid;

                                worldTiles[m1.xGridLocation, m1.yGridLocation].wObject = m1;
								//Console.Out.WriteLine("C8: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
							}
						}
					}
				}

				/*Renders battle screen if player and monster are in adjacent position after monster moves
				if (m1.health > 0 && ((m1.xLocation == player.xLocation + 60f || m1.xLocation == player.xLocation - 60f) && m1.yLocation == player.yLocation) || ((m1.yLocation == player.yLocation + 60f || m1.yLocation == player.yLocation - 60f) && m1.xLocation == player.xLocation))
				{
					//Console.WriteLine("Monster Location: " + m1.xLocation + "," + m1.yLocation + "\t" + "Player Location: " + player.xLocation + "," + player.yLocation);
					if (m1.xLocation == player.xLocation) m1.xLocation -= 60f;
					else if (m1.yLocation == player.yLocation) m1.yLocation -= 60f;
					//save player's location
					characterX = player.xLocation;
					characterY = player.yLocation;
					player.pTexture = Graphics.createTexture(device9, pright);
					m1.texture = Graphics.createTexture(device9, m1Left);
					status = GameStatus.battleScreen;
				}*/
			}
		}

		//Dispose unused
		private static void Cleanup ()
		{
			if (device9 != null)
				device9.Dispose ();

			sprite.Dispose ();
			sprite2.Dispose ();
			sprite3.Dispose ();
			sprite4.Dispose ();

			Graphics.disposeMainMenu ();
			Graphics.disposeTutorial ();

			music.Dispose ();

			//player1.Dispose ();
			//monster1.Dispose();
			//tiles.Dispose();

			Application.Exit ();
		}
			
	}


}
