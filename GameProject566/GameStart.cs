﻿using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Windows;
using SlimDX.Design;
using SlimDX.RawInput;
using SlimDX.Multimedia;

namespace GameProject566
{
	public class GameStart
	{

		//Our graphics device
		static SlimDX.Direct3D9.Device device9;

		//We use this to load sprites.
		static Sprite sprite;

		//Our texture file
		static Texture texture;

        //tiles
        static Texture tiles;

		//Absolute location start for sprite
		static float characterX = 512;
		static float characterY = 384;

        //beginning location for sprite
        static float tileX = 512;
        static float tileY = 384;
        // create new form
        static RenderForm form;

		//Intialize graphics
		/*  WILL BE REMOVED
		public static void initializeGraphics (RenderForm form)
		{

			//Device presentation paramaters
			PresentParameters presentParamaters = new PresentParameters ();
			//Windowed
			presentParamaters.Windowed = true;
			//Form's width
			presentParamaters.BackBufferWidth = form.ClientRectangle.Width;
			//Forms' height
			presentParamaters.BackBufferHeight = form.ClientRectangle.Height;


			//Acquire the sys int that the form is bound to.
			presentParamaters.DeviceWindowHandle = form.Handle;

			//Our device for graphics
			device9 = new SlimDX.Direct3D9.Device (new Direct3D (), 0, SlimDX.Direct3D9.DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, presentParamaters);



			//sprite based off device
			sprite = new Sprite (device9);

			//Our texture
			texture = Texture.FromFile (device9, "..\\..\\sprites\\test2.png");
		}
		*/

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
				//initializeGraphics (form);
				device9 = graphics.initializeGraphics (form);
				texture = graphics.createSprite (device9);
                tiles = graphics.drawTiles(device9);
				sprite = new Sprite (device9);

				//Gimme da keyboards
				SlimDX.RawInput.Device.RegisterDevice (UsagePage.Generic, UsageId.Keyboard, SlimDX.RawInput.DeviceFlags.None);
				SlimDX.RawInput.Device.KeyboardInput += new EventHandler <KeyboardInputEventArgs> (Device_keyboardInput);

				//SlimDX.RawInput.Device.KeyboardInput += Device_keyboardInput;


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
				} else if (e.Key == Keys.Up && characterY > (84 + 60f)){//(0 + 60f)) {
					characterY = characterY - 60f;
				} else if (e.Key == Keys.Left && characterX > (212 + 60f)){//(0 + 60f)) {
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

			//This is where would place game logic for a game
		}


		//Sprites and textures CANNOT be created here, as it must retrieve textures
		private static void RenderFrames ()
		{



			//Clear the whole screen
			device9.Clear (ClearFlags.Target, Color.AliceBlue, 1.0f, 0);

			//Render whole frame
			device9.BeginScene ();

			//not sure why we need this yet...
			SlimDX.Color4 color = new SlimDX.Color4 (Color.White);

			//being sprite render.
			sprite.Begin (SpriteFlags.AlphaBlend);

            sprite.Transform = Matrix.Translation (tileX,tileY,0);

            sprite.Draw(tiles, color);
			//Translate the sprite with a 3d matrix with no z change.
			sprite.Transform = Matrix.Translation (characterX, characterY, 0);

			//Render sprite.
			sprite.Draw (texture, color);

			//end render
			sprite.End ();

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
			texture.Dispose ();
		}
			
	}
}
