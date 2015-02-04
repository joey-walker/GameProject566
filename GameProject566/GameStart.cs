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
		static Texture player1;
        static Texture monster1;

        //tiles
        //static Texture [,] tiles = new Texture[40,40];
        static Texture tiles;

		//Absolute location start for player

		static float characterX = 512;
		static float characterY = 384;

        //beginning location for tile
        static float tileX = 512;
        static float tileY = 384;

        // Absolute location for monster
        static float monster1X = 300;
        static float monster1Y = 200;
        // create new form
        static RenderForm form;

		public static void Main ()
		{
			//using allows cleanup of form afterwards
			/* using -> New concept, Basically it creates objects that if disposable will
			* get rid of the object when no longer being managed.
			* The rest creates a standard windows form that we tell the application to run.
			*/
			using (form = new RenderForm ("Dreadnought Kamzhor")) {
				Graphics graphics = new Graphics ();

				//Window resolution is 1024 x 768
				form.Width = 1024;
				form.Height = 768;
				//No resizing
				form.FormBorderStyle = FormBorderStyle.Fixed3D;
				form.MaximizeBox = false;

				//Create our device, textures and sprites

				device9 = graphics.initializeGraphics (form);

                //initialize player
				player1 = graphics.createPlayer (device9);

                //initialize monster
                monster1 = graphics.createMonster(device9);

                //initialize tiles
                //tiles = graphics.drawTiles(device9); //doesn't work :x
                tiles = graphics.drawTiles(device9);

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
				WaveStream wave = new WaveStream("..\\..\\sprites\\jig.wav");

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
			Console.Out.WriteLine ("Key pressed: " + e.Key + ". x value: " + characterX + ". y value: " + characterY);

			//First if is probably redundant but whatever
			//Everything else is self explainatory.
			if (e.State == KeyState.Pressed) {
				if (e.Key == Keys.Down && characterY < (form.Height - 60f)) {
					characterY = characterY + 60f;
				} else if (e.Key == Keys.Up && characterY > (0 + 60f)){//(0 + 60f)) {
					characterY = characterY - 60f;
				} else if (e.Key == Keys.Left && characterX > (0 + 60f)){//(0 + 60f)) {
					characterX = characterX - 60f;
				} else if (e.Key == Keys.Right && characterX < (form.Width - 60f)) {
					characterX = characterX + 60f;
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
			device9.Clear (ClearFlags.Target, Color.AliceBlue, 1.0f, 0);

			//Render whole frame
			device9.BeginScene ();



			Console.Out.WriteLine("View: " +  device9.GetTransform (TransformState.View));


			Console.Out.WriteLine("World: " +  device9.GetTransform (TransformState.World));
			//not sure why we need this yet...
			SlimDX.Color4 color = new SlimDX.Color4 (Color.White);

            //renders sprite for tile and player
            sprite.Begin(SpriteFlags.AlphaBlend);

            //renders tile texture
            sprite.Transform = Matrix.Translation(tileX, tileY, 0);
            sprite.Draw(tiles, color);

			//renders player texture

            sprite.Transform = Matrix.Translation (characterX,characterY,0);
            sprite.Draw(player1, color);


            //renders monster sprite
            sprite2.Begin(SpriteFlags.AlphaBlend);
            sprite2.Transform = Matrix.Translation(monster1X, monster1Y, 0);
            sprite2.Draw(monster1, color);
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

		//Dispose unused
		private static void Cleanup ()
		{
			if (device9 != null)
				device9.Dispose ();

			sprite.Dispose ();
			sprite2.Dispose ();
            //sprite3.Dispose();
			player1.Dispose ();
            monster1.Dispose();
            tiles.Dispose();

		}
			
		
	}
}
