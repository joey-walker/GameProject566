using System;
using SlimDX.Direct3D9;
using System.Windows.Forms;

namespace GameProject566
{
	public class Graphics
	{
		public Device initializeGraphics (Form form)
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
			return new Device (new Direct3D (), 0, SlimDX.Direct3D9.DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, presentParamaters);

		}

		public Texture createSprite (Device device9)
		{

			//Our texture
			return Texture.FromFile (device9, "..\\..\\sprites\\test2.png");

		}

        public Texture drawTiles(Device device9)
        {
            //tiles
            return Texture.FromFile(device9, "..\\..\\sprites\\tile1.png");
        }
	}
}

