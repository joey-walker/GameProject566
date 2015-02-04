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

		public Texture createPlayer (Device device9)
		{

			//Our texture
			return Texture.FromFile (device9, "..\\..\\sprites\\test1.png");

		}

        public Texture createMonster(Device device9)
        {

            //Our texture
            return Texture.FromFile(device9, "..\\..\\sprites\\test2.png");

        }


        //doesn't work. trying to make an array of tiles. will try again later
        /*public Texture drawTiles(Device device9)
        {
            //tiles
            Texture tile = Texture.FromFile(device9, "..\\..\\sprites\\tile1.png");
            Texture[,] tiles = new Texture[40,40];
            for (int x = 40; x > 0; x--)
            {
                for (int y = 40; y > 0; y--)
                {
                    tiles[x, y] = tile;
                }
            }

            return tiles[40,40];
        }*/

        public Texture drawTiles(Device device9)
        {
            return Texture.FromFile(device9, "..\\..\\sprites\\tile1.png");
        }
	}
}

