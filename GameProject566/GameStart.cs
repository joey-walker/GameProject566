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
        //static Sprite sprite3;
		//Our texture file
		//static Texture player1;
        //static Texture monster1;
        static Texture mainMenu;
        static Texture newGame;
        static Texture tutorial;
        static Texture quit;
        //tiles
        //static Texture tiles;

        //array of tiles
        static Texture[,] bgTiles = new Texture[15, 15];

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

        //location for main menu background and buttons
        static string menuBG = "..\\..\\sprites\\background.png";
        static string newGameButton = "..\\..\\sprites\\NewGAME.png";
        //static string newGameButton2 = "..\\..\\sprites\\NewGAME_2.png";
        static string quitButton = "..\\..\\sprites\\Quit.png";
        //static string quitButton2 = "..\\..\\sprites\\Quit_2.png";
        static string tutorialButton = "..\\..\\sprites\\Tutorial.png";
        //static string tutorialButton2 = "..\\..\\sprites\\Tutorial_2.png";

        //battlescreen texture
        static string battleScr = "..\\..\\sprites\\battlescreen_2.png";
        static Texture battleScreen;
        //fileLocation for tiles
        static string tiles = "..\\..\\sprites\\tile1.png";
        static string entryTile = "..\\..\\sprites\\entry.png";
        static string exitTile = "..\\..\\sprites\\exit.png";
        // Beginning location for monster
        static float monster1X = 300;
        static float monster1Y = 300;

        //object for player
        static PlayerChar player = new PlayerChar(null, characterX, characterY);
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
        static Monsterchar m1 = new Monsterchar(null, monster1X, monster1Y);
        //gets all the sprite location for the monster
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
        static Random rand = new Random();

        //object for graphics
        static Graphics graphics = new Graphics();

        //enum for status??
        
		static GameStatus status = GameStatus.mainMenu;

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

				var bitmap = new Bitmap("..\\..\\sprites\\KZ.png");
				var iconHandle = bitmap.GetHicon();
				var icon = System.Drawing.Icon.FromHandle(iconHandle);

				form.Icon = icon;

				//Create our device, textures and sprites

				device9 = graphics.initializeGraphics (form);

                //initialize player
				//player1 = graphics.createPlayer (pback, device9);
                player.charTexture = (graphics.createTexture(device9, pback));
                changePlayerBack = !changePlayerBack;
                //initialize monster
                //monster1 = graphics.createMonster(device9);
                m1.charTexture = (graphics.createTexture(device9, m1Front1));
                changeM1Front = !changeM1Front;
                //set initial health for player and monster
                m1.health = player.health = 100;
                //initialize tiles

                //fill the array with tiles
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 15; y++)
                    {
                        bgTiles[x, y] = graphics.createTexture(device9, tiles);
                    }
                }

                //background for map
                mapBg = graphics.createTexture(device9, bg);
				sprite = new Sprite (device9);
                sprite2 = new Sprite(device9);
                sprite3 = new Sprite(device9);
                sprite4 = new Sprite(device9);

                //Textures for main menu
                mainMenu = graphics.createTexture(device9, menuBG);
                newGame = graphics.createTexture(device9, newGameButton);
                tutorial = graphics.createTexture(device9, tutorialButton);
                quit = graphics.createTexture(device9, quitButton);
                battleScreen = graphics.createTexture(device9, battleScr);
				//Gimme da keyboards
				SlimDX.RawInput.Device.RegisterDevice (UsagePage.Generic, UsageId.Keyboard, SlimDX.RawInput.DeviceFlags.None);
				SlimDX.RawInput.Device.KeyboardInput += new EventHandler <KeyboardInputEventArgs> (Device_keyboardInput);

                //Mouse
                SlimDX.RawInput.Device.RegisterDevice(UsagePage.Generic, UsageId.Mouse, SlimDX.RawInput.DeviceFlags.None);
                SlimDX.RawInput.Device.MouseInput +=new EventHandler<MouseInputEventArgs>(Device_mouseInput);

				//SOUND STUFF/////////////////
				DirectSound directsound = new DirectSound();
				directsound.IsDefaultPool = false;
				directsound.SetCooperativeLevel (form.Handle, SlimDX.DirectSound.CooperativeLevel.Priority);
				WaveStream wave = new WaveStream("..\\..\\sprites\\music1.wav");

				SoundBufferDescription description = new SoundBufferDescription();
				description.Format = wave.Format;
				description.SizeInBytes = (int)wave.Length;
				description.Flags = BufferFlags.ControlVolume;

				// Create the buffer.
				music = new SecondarySoundBuffer(directsound, description);

				byte[] data = new byte[description.SizeInBytes];
				wave.Read(data, 0, (int)wave.Length);
				music.Write(data, 0,SlimDX.DirectSound.LockFlags.None);


				music.Volume = 0;

				music.Play(0, PlayFlags.Looping);

				////////////////////////////////////


				//Application loop

				MessagePump.Run (form, GameLoop);

				//Dispose no longer in use objects.
				Cleanup ();
			}
		}

        public static void Device_mouseInput(object sender, MouseInputEventArgs m)
        {
			//Coordinates of the mouse point
            int cursorX = form.PointToClient(RenderForm.MousePosition).X;
            int cursorY = form.PointToClient(RenderForm.MousePosition).Y;

			if (status == GameStatus.mainMenu) {

				//Button positions
				if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 200 && cursorX <= 1000 && cursorY <= 310) {
					Console.WriteLine ("X Position: " + cursorX + "Y Position: " + cursorY);
					//Switch to game map
					status = GameStatus.map;
				} else if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= 500 && cursorY >= 470 && cursorX <= 1000 && cursorY <= 580) {
					Console.WriteLine ("X Position: " + cursorX + " | Y Position: " + cursorY);
					//Exit the game
					Cleanup ();
				}	
			}
            if (status == GameStatus.battleScreen)
            {
                //Console.WriteLine("X Position: " + cursorX + "Y Position: " + cursorY);
                //Console.WriteLine("Monster Location: " + m1.xLocation + " , " + m1.yLocation);
                if (m.ButtonFlags == MouseButtonFlags.LeftDown && cursorX >= m1.xLocation && cursorX <= m1.xLocation + 60 && cursorY >= m1.yLocation && cursorY <= m1.yLocation + 60)
                {
                    
                    m1.health -= player.attack(rand);
                    player.health -= m1.attack(rand);
                    Console.WriteLine("Player: " + player.health + "\n" + "Monster: " + m1.health);
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
            //First checks if the monster and the player are on adjacent tiles before player moves
            if (m1.health > 0 && ((m1.xLocation == player.xLocation + 60f || m1.xLocation == player.xLocation - 60f) && m1.yLocation == player.yLocation) || ((m1.yLocation == player.yLocation + 60f || m1.yLocation == player.yLocation - 60f) && m1.xLocation == player.xLocation))
            {
                //Console.WriteLine("Monster Location: " + m1.xLocation + "," + m1.yLocation + "\t" + "Player Location: " + player.xLocation + "," + player.yLocation);
                if (m1.xLocation == player.xLocation) m1.xLocation -= 60f;
                else if (m1.yLocation == player.yLocation) m1.yLocation -= 60f;
                //save player's location
                characterX = player.xLocation;
                characterY = player.yLocation;
                player.charTexture = graphics.createTexture(device9, pright);
                m1.charTexture = graphics.createTexture(device9, m1Left);
                status = GameStatus.battleScreen;
            }
            if (status == GameStatus.map)
            {
                    if (e.State == KeyState.Pressed)
                    {
                        if (e.Key == Keys.Down && tileY2 > -300f)
                        {
                            //characterY = characterY + 60f;
                            //monster1Y -= 60f;
                            //m1.setYLocation(-60f);
                            if (m1.health > 0) m1.move(0, -60f);
                            tileY2 -= 60f;
                            if (changePlayerFront)
                                player.charTexture = (graphics.createTexture(device9, pfront1));
                            else
                                player.charTexture = (graphics.createTexture(device9, pfront));
                            changePlayerFront = !changePlayerFront;
                        }
                        else if (e.Key == Keys.Up && tileY2 < 240f)
                        {
                            //characterY = characterY - 60f;
                            //monster1Y += 60f;
                            //m1.setYLocation(60f);
                            if (m1.health > 0) m1.move(0, 60f);
                            tileY2 += 60f;
                            if (changePlayerBack)
                                player.charTexture = (graphics.createTexture(device9, pback1));
                            else
                                player.charTexture = (graphics.createTexture(device9, pback));
                            changePlayerBack = !changePlayerBack;
                        }
                        else if (e.Key == Keys.Left && tileX2 < 360f)
                        {

                            //monster1X += 60f;
                            //m1.setXLocation(60f);
                            if (m1.health > 0) m1.move(60f, 0);
                            tileX2 += 60f;
                            //characterX = characterX - 60f + tileX2;
                            if (changePlayerLeft)
                                player.charTexture = graphics.createTexture(device9, pleft1);
                            else
                                player.charTexture = (graphics.createTexture(device9, pleft));
                            changePlayerLeft = !changePlayerLeft;
                        }
                        else if (e.Key == Keys.Right && tileX2 > -180f)
                        {
                            //monster1X -= 60f;
                            //m1.setXLocation(-60f);
                            if (m1.health > 0) m1.move(-60f, 0);
                            tileX2 -= 60f;
                            //characterX = characterX + 60f - tileX2;
                            if (changePlayerRight)
                                player.charTexture = (graphics.createTexture(device9, pright1));
                            else
                                player.charTexture = graphics.createTexture(device9, pright);
                            changePlayerRight = !changePlayerRight;
                        }

                        //render battlescreen if player and monster are in adjacent tile after the player moves
                        if (m1.health > 0 && ((m1.xLocation == player.xLocation + 60f || m1.xLocation == player.xLocation - 60f) && m1.yLocation == player.yLocation) || ((m1.yLocation == player.yLocation + 60f || m1.yLocation == player.yLocation - 60f) && m1.xLocation == player.xLocation))
                        {
                            //Console.WriteLine("Monster Location: " + m1.xLocation + "," + m1.yLocation + "\t" + "Player Location: " + player.xLocation + "," + player.yLocation);
                            if (m1.xLocation == player.xLocation) m1.xLocation -= 60f;
                            else if (m1.yLocation == player.yLocation) m1.yLocation -= 60f;
                            //save player's location
                            characterX = player.xLocation;
                            characterY = player.yLocation;
                            player.charTexture = graphics.createTexture(device9, pright);
                            m1.charTexture = graphics.createTexture(device9, m1Left);
                            status = GameStatus.battleScreen;
                        }
                        if (arrowOrNot(e) && m1.health > 0)
                        {
                            int XorY = rand.Next(1, 3);
                            //Console.WriteLine(XorY);
                            if (XorY == 1)
                            {
                                if (m1.xLocation > player.xLocation)// && m1.getXLocation() <= (tileX + tileX2))//(monster1X > characterX && monster1X <= (tileX + tileX2))
                                {
                                    //monster1X -= 60f;
                                    //m1.setXLocation(-60f);
                                    m1.move(-60f, 0);

                                    //change monster Texture
                                    if (changeM1Left)
                                        m1.charTexture = (graphics.createTexture(device9, m1Left));
                                    else
                                        m1.charTexture = (graphics.createTexture(device9, m1Left1));

                                    changeM1Left = !changeM1Left;
                                    //Console.Out.WriteLine("C1: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                                }
                                else if (m1.xLocation < player.xLocation)// && m1.getXLocation() > (tileX + tileX2))//(monster1X < characterX && monster1X < (tileX + tileX2))
                                {
                                    //monster1X += 60f;
                                    //m1.setXLocation(60f);
                                    m1.move(60f, 0);

                                    //change monster texture
                                    if (changeM1Right)
                                        m1.charTexture = (graphics.createTexture(device9, m1Right));
                                    else
                                        m1.charTexture = (graphics.createTexture(device9, m1Right1));

                                    changeM1Right = !changeM1Right;
                                    //Console.Out.WriteLine("C2: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                                }
                                else
                                {
                                    if (m1.yLocation > player.yLocation)// && m1.getYLocation() <= (tileY + tileY2))//(monster1Y > characterY && monster1Y <= (tileY + tileY2))
                                    {
                                        // monster1Y -= 60f;
                                        //m1.setYLocation(-60f);
                                        m1.move(0, -60f);
                                        //change monster texture
                                        if (changeM1Back)
                                            m1.charTexture = (graphics.createTexture(device9, m1Back));
                                        else
                                            m1.charTexture = (graphics.createTexture(device9, m1Back1));

                                        changeM1Back = !changeM1Back;
                                        //Console.Out.WriteLine("C3: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                                    }
                                    else if (m1.yLocation < player.yLocation)// && m1.getYLocation() < (tileY + tileY2))//(monster1Y < characterY && monster1Y < (tileY + tileY2))
                                    {
                                        //monster1Y += 60f;
                                        //m1.setYLocation(60f);
                                        m1.move(0, 60f);
                                        //change monster texture
                                        if (changeM1Front)
                                            m1.charTexture = (graphics.createTexture(device9, m1Front));
                                        else
                                            m1.charTexture = (graphics.createTexture(device9, m1Front1));

                                        changeM1Front = !changeM1Front;
                                        //Console.Out.WriteLine("C4: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                                    }
                                }
                            }
                            else
                            {
                                if (m1.yLocation > player.yLocation)// && m1.getYLocation() <= (tileY + tileY2))//(monster1Y > characterY && monster1Y <= (tileY + tileY2))
                                {
                                    // monster1Y -= 60f;
                                    //m1.setYLocation(-60f);
                                    m1.move(0, -60f);
                                    //change monster texture
                                    if (changeM1Back)
                                        m1.charTexture = (graphics.createTexture(device9, m1Back));
                                    else
                                        m1.charTexture = (graphics.createTexture(device9, m1Back1));

                                    changeM1Back = !changeM1Back;
                                    //Console.Out.WriteLine("C5: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                                }
                                else if (m1.yLocation < player.yLocation)// && m1.getYLocation() < (tileY + tileY2))//(monster1Y < characterY && monster1Y < (tileY + tileY2))
                                {
                                    //monster1Y += 60f;
                                    //m1.setYLocation(60f);
                                    m1.move(0, 60f);
                                    //change monster texture
                                    if (changeM1Front)
                                        m1.charTexture = (graphics.createTexture(device9, m1Front));
                                    else
                                        m1.charTexture = (graphics.createTexture(device9, m1Front1));

                                    changeM1Front = !changeM1Front;
                                    //Console.Out.WriteLine("C6: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                                }
                                else
                                {
                                    if (m1.xLocation > player.xLocation)// && m1.getXLocation() <= (tileX + tileX2))//(monster1X > characterX && monster1X <= (tileX + tileX2))
                                    {
                                        //monster1X -= 60f;
                                        //m1.setXLocation(-60f);
                                        m1.move(-60f, 0);
                                        //change monster Texture
                                        if (changeM1Left)
                                            m1.charTexture = (graphics.createTexture(device9, m1Left));
                                        else
                                            m1.charTexture = (graphics.createTexture(device9, m1Left1));

                                        changeM1Left = !changeM1Left;
                                        //Console.Out.WriteLine("C7: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                                    }
                                    else if (m1.xLocation < player.xLocation)// && m1.getXLocation() < (tileX + tileX2))//(monster1X < characterX && monster1X < (tileX + tileX2))
                                    {
                                        //monster1X += 60f;
                                        //m1.setXLocation(60f);
                                        m1.move(60f, 0);
                                        //change monster texture
                                        if (changeM1Right)
                                            m1.charTexture = (graphics.createTexture(device9, m1Right));
                                        else
                                            m1.charTexture = (graphics.createTexture(device9, m1Right1));

                                        changeM1Right = !changeM1Right;
                                        //Console.Out.WriteLine("C8: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                                    }
                                }
                            }
                        }
                        /*
                        //Renders battle screen if player and monster are in adjacent position after monster moves
                        if (m1.health > 0 && ((m1.xLocation == player.xLocation + 60f || m1.xLocation == player.xLocation - 60f) && m1.yLocation == player.yLocation) || ((m1.yLocation == player.yLocation + 60f || m1.yLocation == player.yLocation - 60f) && m1.xLocation == player.xLocation))
                        {
                            //Console.WriteLine("Monster Location: " + m1.xLocation + "," + m1.yLocation + "\t" + "Player Location: " + player.xLocation + "," + player.yLocation);
                            if (m1.xLocation == player.xLocation) m1.xLocation -= 60f;
                            else if (m1.yLocation == player.yLocation) m1.yLocation -= 60f;
                         * //save player's location
                            characterX = player.xLocation;
                            characterY = player.yLocation;
                            status = GameStatus.battleScreen;
                        }*/
                    }

            }
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

            sprite.Begin(SpriteFlags.AlphaBlend);
            sprite2.Begin(SpriteFlags.AlphaBlend);
            sprite3.Begin(SpriteFlags.AlphaBlend);
            sprite4.Begin(SpriteFlags.AlphaBlend);

			//not sure why we need this yet...
			SlimDX.Color4 color = new SlimDX.Color4 (Color.White);

			if (status == GameStatus.mainMenu)
            {
                renderMainMenu(color);
            }

            //Console.WriteLine(status);
			if (status == GameStatus.map)
            {
				renderGameRoom(color);
            }

            //render battle screen. About to get serious now :O
            if (status == GameStatus.battleScreen)
            {
                renderBattleScreen(color);
            }
			//end render
			sprite.End ();
			sprite2.End ();
            sprite3.End();
            sprite4.End();
			// End the scene.
			device9.EndScene ();

			// Present the backbuffer contents to the screen.
			device9.Present ();

		}

        public static void renderMainMenu(SlimDX.Color4 color)
        {

            sprite.Transform = Matrix.Translation(0, 0, 0);
            sprite.Draw(mainMenu,color);

            sprite2.Transform = Matrix.Translation (500, 200, 0);
            sprite3.Transform = Matrix.Translation(500, 330, 0);
            sprite4.Transform = Matrix.Translation(500, 460, 0);

            sprite2.Draw(newGame, color);
            sprite3.Draw(tutorial, color);
            sprite4.Draw(quit, color);
        }

        public static void renderGameRoom(SlimDX.Color4 color)
        {
			status = GameStatus.map;
            //renders sprite for tile and player

            player.xLocation = characterX;
            player.yLocation = characterY;

            //render bg
            sprite.Transform = Matrix.Translation(0, 0, 0);
            sprite.Draw(mapBg, color);
            //renders tile texture
            makeTiles(sprite, color);

            //renders player texture
            sprite.Transform = Matrix.Translation(player.xLocation, player.yLocation, 0);
            sprite.Draw(player.charTexture, color);


            //renders monster sprite
            if (m1.health > 0)
            {
                sprite2.Transform = Matrix.Translation(m1.xLocation, m1.yLocation, 0);
                sprite2.Draw(m1.charTexture, color);
            }
            else
            {
                sprite2.Transform = Matrix.Translation(0, 0, 0);
            }

            //Translate the sprite with a 3d matrix with no z change.
            //return currStatus;
        }

        public static void renderBattleScreen(SlimDX.Color4 color)
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

            sprite.Transform = Matrix.Translation(0, 0, 0);
            sprite.Draw(battleScreen, color);
            sprite.Transform = Matrix.Translation(player.xLocation, player.yLocation, 0);
            sprite.Draw(player.charTexture, color);

            //m1.xLocation -= 60;
            sprite2.Transform = Matrix.Translation(m1.xLocation, m1.yLocation, 0);
            sprite2.Draw(m1.charTexture, color);
           // while (m1.xLocation != player.xLocation - 60)
            //{
            //    m1.move(-60,0);
            //}
        }
        private static void makeTiles(Sprite sprite, SlimDX.Color4 color)
        {

            tileX = 0;
            tileY = 0;
            for (int x = 0; x < 10 ; x++)
            {
                tileX += 60;
                tileY = 0;
                for (int y = 0; y < 10; y++)
                {
                    tileY += 60;
					sprite.Transform = Matrix.Translation(tileX + tileX2, tileY + tileY2, 0);
                    sprite.Draw(bgTiles[x,y], color);
                }
            }
            
           /* for (int x = 60; x < (form.Width - 60); x += 60)
            {
                for (int y = 60; y < (form.Height - 60); y += 60)
                {
                    sprite.Transform = Matrix.Translation((tileX + x), (tileY + y), 0);
                    sprite.Draw(tiles, color);
                }
            }*/
            //sprite.Transform = Matrix.Translation(tileX, tileY, 0);
            //sprite.Draw(tiles, color);
            
        }

		//Dispose unused
		private static void Cleanup ()
		{
			if (device9 != null)
				device9.Dispose ();

			sprite.Dispose ();
			sprite2.Dispose ();
            sprite3.Dispose();
            sprite4.Dispose();
			mainMenu.Dispose ();
			newGame.Dispose ();
			tutorial.Dispose ();
			quit.Dispose ();
			music.Dispose ();
			//player1.Dispose ();
            //monster1.Dispose();
            //tiles.Dispose();
			Application.Exit ();
		}

        public static Boolean arrowOrNot(KeyboardInputEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.Up: return true;
                case Keys.Down: return true;
                case Keys.Right: return true;
                case Keys.Left: return true;
            }
            return false;
        }
		
	}
}
