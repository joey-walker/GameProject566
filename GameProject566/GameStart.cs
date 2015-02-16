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

namespace GameProject566
{

	public class GameStart
	{

		//Our graphics device
		static SlimDX.Direct3D9.Device device9;

		//We use this to load sprites.
		static Sprite sprite;
		static Sprite sprite2;
        //static Sprite sprite3;
		//Our texture file
		//static Texture player1;
        //static Texture monster1;

        //tiles
        static Texture tiles;

        //array of tiles
        static Texture[,] bgTiles = new Texture[15, 15];

		//Absolute starting location for player

		static float characterX = 420;
		static float characterY = 300;


        //Beginning location for tile
        static float tileX = 0;
        static float tileY = 0;

		static float tileX2 = 0;
		static float tileY2 = 0;

        // Beginning location for monster
        static float monster1X = 300;
        static float monster1Y = 300;

        //object for player
        static player p1 = new player(null, characterX, characterY);
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
        //object for monster
        static monster m1 = new monster(null, monster1X, monster1Y);
        //gets all the sprite location for the monster
        static string m1Sprite = "..\\..\\sprites\\test2.png";

        // create new form
        static RenderForm form;

        //Random Number Generator
        static Random rand = new Random();

        //object for graphics
        static Graphics graphics = new Graphics();

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
                p1.setCharTexture(graphics.createPlayer(device9, pback));

                //initialize monster
                //monster1 = graphics.createMonster(device9);
                m1.setCharTexture (graphics.createMonster(device9, m1Sprite));
                //initialize tiles
                //tiles = graphics.drawTiles(device9); //doesn't work :x
                tiles = graphics.drawTiles(device9);

                //fill the array with tiles
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 15; y++)
                    {
                        bgTiles[x, y] = graphics.drawTiles(device9);
                    }
                }

				sprite = new Sprite (device9);
				sprite2 = new Sprite (device9);
                //sprite3 = new Sprite(device9);



				//Gimme da keyboards
				SlimDX.RawInput.Device.RegisterDevice (UsagePage.Generic, UsageId.Keyboard, SlimDX.RawInput.DeviceFlags.None);
				SlimDX.RawInput.Device.KeyboardInput += new EventHandler <KeyboardInputEventArgs> (Device_keyboardInput);

				//SlimDX.RawInput.Device.KeyboardInput += Device_keyboardInput;

				//SOUND STUFF
				DirectSound a = new DirectSound();
				a.IsDefaultPool = false;
				a.SetCooperativeLevel (form.Handle, CooperativeLevel.Priority);
				WaveStream wave = new WaveStream("..\\..\\sprites\\music1.wav");

				SoundBuffer b;

				SoundBufferDescription description = new SoundBufferDescription();
				description.Format = wave.Format;
				description.SizeInBytes = (int)wave.Length;
				description.Flags = BufferFlags.ControlVolume;

				// Create the buffer.
				b = new SecondarySoundBuffer(a, description);

				byte[] data = new byte[description.SizeInBytes];
				wave.Read(data, 0, (int)wave.Length);
				b.Write(data, 0,SlimDX.DirectSound.LockFlags.None);


				b.Volume = 0;
				b.Play(0, PlayFlags.Looping);


				//device9.SetTransform (TransformState.Projection, Matrix.PerspectiveFovLH ((float)Math.PI / 4, 1024f / 728f, 1f, 50f));



				//Application loop

				MessagePump.Run (form, GameLoop);

				//Dispose no longer in use objects.
				Cleanup ();
			}
		}


		public static void  Device_keyboardInput (object sender, KeyboardInputEventArgs e)
		{
			//Runs twice for some reason....
			//Console.Out.WriteLine ("Key pressed: " + e.Key + ". x value: " + p1.getXLocation() + ". y value: " + p1.getYLocation());
			//First if is probably redundant but whatever
			//Everything else is self explainatory.
            if (e.State == KeyState.Pressed)
            {
                if (e.Key == Keys.Down && tileY2 > -300f)
                {
                    //characterY = characterY + 60f;
                    //monster1Y -= 60f;
                    //m1.setYLocation(-60f);
                    m1.move(0, -60f);
                    tileY2 -= 60f;
                    if (changePlayerFront)
                        p1.setCharTexture(graphics.createPlayer(device9, pfront1));
                    else
                        p1.setCharTexture(graphics.createPlayer(device9, pfront));
                    changePlayerFront = !changePlayerFront;
                }
                else if (e.Key == Keys.Up && tileY2 < 240f)
                {
                    //characterY = characterY - 60f;
                    //monster1Y += 60f;
                    //m1.setYLocation(60f);
                    m1.move(0, 60f);
                    tileY2 += 60f;
                    if (changePlayerBack)
                        p1.setCharTexture(graphics.createPlayer(device9, pback1));
                    else
                        p1.setCharTexture(graphics.createPlayer(device9, pback));
                    changePlayerBack = !changePlayerBack;
                }
                else if (e.Key == Keys.Left && tileX2 < 360f)
                {

                    //monster1X += 60f;
                    //m1.setXLocation(60f);
                    m1.move(60f, 0);
                    tileX2 += 60f;
                    //characterX = characterX - 60f + tileX2;
                    if (changePlayerLeft)
                        p1.setCharTexture(graphics.createPlayer(device9, pleft1));
                    else
                        p1.setCharTexture(graphics.createPlayer(device9, pleft));
                    changePlayerLeft = !changePlayerLeft;
                }
                else if (e.Key == Keys.Right && tileX2 > -180f)
                {
                    //monster1X -= 60f;
                    //m1.setXLocation(-60f);
                    m1.move(-60f, 0);
                    tileX2 -= 60f;
                    //characterX = characterX + 60f - tileX2;
                    if (changePlayerRight)
                        p1.setCharTexture(graphics.createPlayer(device9, pright1));
                    else
                        p1.setCharTexture(graphics.createPlayer(device9, pright));
                    changePlayerRight = !changePlayerRight;
                }

                if (arrowOrNot(e))
                {
                    int XorY = rand.Next(1, 3);
                    //Console.WriteLine(XorY);
                    if (XorY == 1)
                    {
                        if (m1.getXLocation() > p1.getXLocation())// && m1.getXLocation() <= (tileX + tileX2))//(monster1X > characterX && monster1X <= (tileX + tileX2))
                        {
                            //monster1X -= 60f;
                            //m1.setXLocation(-60f);
                            m1.move(-60f, 0);
                            Console.Out.WriteLine("C1: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                        }
                        else if (m1.getXLocation() < p1.getXLocation())// && m1.getXLocation() > (tileX + tileX2))//(monster1X < characterX && monster1X < (tileX + tileX2))
                        {
                            //monster1X += 60f;
                            //m1.setXLocation(60f);
                            m1.move(60f, 0);
                            Console.Out.WriteLine("C2: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                        }
                        else
                        {
                            if (m1.getYLocation() > p1.getYLocation())// && m1.getYLocation() <= (tileY + tileY2))//(monster1Y > characterY && monster1Y <= (tileY + tileY2))
                            {
                                // monster1Y -= 60f;
                                //m1.setYLocation(-60f);
                                m1.move(0, -60f);
                                Console.Out.WriteLine("C3: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                            }
                            else if (m1.getYLocation() < p1.getYLocation())// && m1.getYLocation() < (tileY + tileY2))//(monster1Y < characterY && monster1Y < (tileY + tileY2))
                            {
                                //monster1Y += 60f;
                                //m1.setYLocation(60f);
                                m1.move(0, 60f);
                                Console.Out.WriteLine("C4: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                            }
                        }
                    }
                    else
                    {
                        if (m1.getYLocation() > p1.getYLocation())// && m1.getYLocation() <= (tileY + tileY2))//(monster1Y > characterY && monster1Y <= (tileY + tileY2))
                        {
                            // monster1Y -= 60f;
                            //m1.setYLocation(-60f);
                            m1.move(0, -60f);
                            Console.Out.WriteLine("C5: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                        }
                        else if (m1.getYLocation() < p1.getYLocation())// && m1.getYLocation() < (tileY + tileY2))//(monster1Y < characterY && monster1Y < (tileY + tileY2))
                        {
                            //monster1Y += 60f;
                            //m1.setYLocation(60f);
                            m1.move(0, 60f);
                            Console.Out.WriteLine("C6: XorY: " + XorY + ". y value: " + m1.getYLocation() + ". Tile Y + Y2: " + (tileY + tileY2));
                        }
                        else
                        {
                            if (m1.getXLocation() > p1.getXLocation())// && m1.getXLocation() <= (tileX + tileX2))//(monster1X > characterX && monster1X <= (tileX + tileX2))
                            {
                                //monster1X -= 60f;
                                //m1.setXLocation(-60f);
                                m1.move(-60f, 0);
                                Console.Out.WriteLine("C7: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                            }
                            else if (m1.getXLocation() < p1.getXLocation())// && m1.getXLocation() < (tileX + tileX2))//(monster1X < characterX && monster1X < (tileX + tileX2))
                            {
                                //monster1X += 60f;
                                //m1.setXLocation(60f);
                                m1.move(60f, 0);
                                Console.Out.WriteLine("C8: XorY: " + XorY + ". x value: " + m1.getXLocation() + ". Tile X + X2: " + (tileX + tileX2));
                            }
                        }
                    }
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



			//Console.Out.WriteLine("View: " +  device9.GetTransform (TransformState.View));


			//Console.Out.WriteLine("World: " +  device9.GetTransform (TransformState.World));

			//not sure why we need this yet...
			SlimDX.Color4 color = new SlimDX.Color4 (Color.White);

            //renders sprite for tile and player
            sprite.Begin(SpriteFlags.AlphaBlend);

            //renders tile texture
            makeTiles(sprite, color);

			//renders player texture

            sprite.Transform = Matrix.Translation (p1.getXLocation(),p1.getYLocation(),0);
            sprite.Draw(p1.getCharTexture(), color);


            //renders monster sprite
            sprite2.Begin(SpriteFlags.AlphaBlend);
            sprite2.Transform = Matrix.Translation(m1.getXLocation(), m1.getYLocation(), 0);
            sprite2.Draw(m1.getCharTexture(), color);
			//Translate the sprite with a 3d matrix with no z change.

			//end render
			sprite.End ();
			sprite2.End ();
            //sprite3.End();
			// End the scene.
			device9.EndScene ();

			// Present the backbuffer contents to the screen.
			device9.Present ();

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
            //sprite3.Dispose();
			//player1.Dispose ();
            //monster1.Dispose();
            tiles.Dispose();
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
