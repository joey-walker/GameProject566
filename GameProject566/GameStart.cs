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
		//Our texture file
		static Texture texture;

		//Absolute location start for sprite
		static float x = 200;
		static float y = 200;
		//static float z = 0;

		public static void Main ()
		{
			//using allows cleanup of form afterwards
			/* using -> New concept, Basically it creates objects that if disposable will
			* get rid of the object when no longer being managed.
			* The rest creates a standard windows form that we tell the application to run.
			*/
			using (RenderForm form = new RenderForm ("Dreadnought Kamzhor")) {
				Graphics graphics = new Graphics ();

				//Window resolution is 1024 x 728
				form.Width = 1024;
				form.Height = 728;
				//No resizing
				form.FormBorderStyle = FormBorderStyle.Fixed3D;
				form.MaximizeBox = false;

				//Create our device, textures and sprites
				//initializeGraphics (form);
				device9 = graphics.initializeGraphics (form);
				texture = graphics.createSprite (device9);
				sprite = new Sprite (device9);
				sprite2 = new Sprite (device9);

				//Get an icon from bitmap
				var bitmap = new Bitmap("..\\..\\sprites\\test2.png"); // or get it from resource
				var iconHandle = bitmap.GetHicon();
				var icon = System.Drawing.Icon.FromHandle(iconHandle);
				form.Icon = icon;



				//form.Icon = new Icon ("..\\..\\sprites\\test2.ico");
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
			Console.Out.WriteLine ("Key pressed: " + e.Key + ". x value: " + x + ". y value: " + y);

			//First if is probably redundant but whatever
			//Everything else is self explainatory.
			if (e.State == KeyState.Pressed) {
				if (e.Key == Keys.Down) {
					y = y + 20f;
				} else if (e.Key == Keys.Up) {
					y = y - 20f;
				} else if (e.Key == Keys.Left) {
					x = x - 20f;
				} else if (e.Key == Keys.Right) {
					x = x + 20f;
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

			//being sprite render.
			sprite.Begin (SpriteFlags.AlphaBlend);
			sprite2.Begin(SpriteFlags.AlphaBlend);
			//Translate the sprite with a 3d matrix with no z change.

			/*Matrix mat = Matrix.RotationZ (z); 
			mat *= Matrix.Translation (x, y, 0);
			sprite.Transform = mat;
			Rotation stuff ^
			*/
			sprite.Transform = Matrix.Translation (x, y, 0);
			sprite.Draw (texture, color);

			sprite2.Transform = Matrix.Translation (300, 300, 0);
			//Render sprite.

			sprite.Draw (texture, color);
			sprite2.Draw (texture, color);
			//end render
			sprite.End ();
			sprite2.End ();
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
			texture.Dispose ();
		}
			
		
	}
}
