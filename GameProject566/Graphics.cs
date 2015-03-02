using System;
using SlimDX.Direct3D9;
using System.Windows.Forms;
using SlimDX;
using System.Drawing;

namespace GameProject566
{
	public class Graphics
	{

		////////////////////////////////////////////    MAIN MENU STUFF  //////////////////////////////////////////////////
		//location for main menu background and buttons
		static string menuBG = "..\\..\\sprites\\background.png";
		static string newGameButton = "..\\..\\sprites\\NewGAME.png";
		static string newGameButton2 = "..\\..\\sprites\\NewGAME_2.png";
		static string quitButton = "..\\..\\sprites\\Quit.png";
		static string quitButton2 = "..\\..\\sprites\\Quit_2.png";
		static string tutorialButton = "..\\..\\sprites\\Tutorial.png";
		static string tutorialButton2 = "..\\..\\sprites\\Tutorial_2.png";

		//textures to hold onto.
		static Texture mainMenu;
		static Texture newGame;
		static Texture tutorial;
		static Texture quit;

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////





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

		/**
		 *  Render the main menu
		 */
		public static void renderMainMenu(SlimDX.Color4 color, Device device9, Sprite sprite)
		{
			//Sprite sprite = new Sprite (device9);
			//Create the texture and place them into these objects to be held onto.
			mainMenu = createTexture(device9, menuBG);
			newGame = createTexture(device9, newGameButton);
			tutorial = createTexture(device9, tutorialButton);
			quit = createTexture(device9, quitButton);

			//Paint the background of the main menu
			sprite.Transform = Matrix.Translation(0, 0, 0);
			sprite.Draw(mainMenu,color);

			//Create the new game button and move it into spot.
			sprite.Transform = Matrix.Translation (500, 200, 0);
			sprite.Draw (newGame, color);

			//Create the tutorial button and move it into spot.
			sprite.Transform = Matrix.Translation(500, 330, 0);
			sprite.Draw (tutorial, color);

			//create the quit button and move it into spot.
			sprite.Transform = Matrix.Translation(500, 460, 0);
			sprite.Draw (quit, color);
		}


        /*public Texture createPlayer(Device device9, string pTexture)
		{

			//Our texture
			return Texture.FromFile (device9, pTexture);

		}

        public Texture createMonster(Device device9, string mTexture)
        {

            //Our texture
            return Texture.FromFile(device9, mTexture);

        }


        //doesn't work. trying to make an array of tiles. will try again later
        //public Texture drawTiles(Device device9)
        //{
        //    //tiles
        //    Texture tile = Texture.FromFile(device9, "..\\..\\sprites\\tile1.png");
        //    Texture[,] tiles = new Texture[40,40];
        //    for (int x = 40; x > 0; x--)
        //    {
        //        for (int y = 40; y > 0; y--)
        //        {
        //            tiles[x, y] = tile;
        //        }
        //    }
        //
        //    return tiles[40,40];
        //}

        public Texture drawTiles(Device device9)
        {
            return Texture.FromFile(device9, "..\\..\\sprites\\tile1.png");
        }
        */

		//  Create texture object and return it.
        public static Texture createTexture(Device device9, string textureLocation)
        {
            //Our texture
            return Texture.FromFile(device9, textureLocation);
        }

		//Dispose main menu textures to free up the memory.
		public static void disposeMainMenu(){
			mainMenu.Dispose ();
			newGame.Dispose ();
			tutorial.Dispose ();
			quit.Dispose ();
		}

		//Method to create an icon.
		public static Icon createIcon(){

			//Create bitmap 
			var bitmap = new Bitmap("..\\..\\sprites\\KZ.png");
			var iconHandle = bitmap.GetHicon();

			//Return our icon
			return Icon.FromHandle(iconHandle);

		}


	}
}

