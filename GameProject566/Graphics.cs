using System;
using SlimDX.Direct3D9;
using System.Windows.Forms;
using SlimDX;
using System.Drawing;
using System.Collections.Generic;

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



		//background for map
		//static string bg = "..\\..\\sprites\\bg.png";
		//static Texture mapBg;


		//textures to hold onto.
		static Texture mainMenu;
		static Texture CurrentNewGame;
		static Texture newGame;
		static Texture newGame2;
		static Texture CurrentTutorial;
		static Texture tutorial;
		static Texture tutorial2;
		static Texture CurrentQuit;
		static Texture quit;
		static Texture quit2;
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	

		////////////////////////////////////////////    TUTORIAL STUFF  //////////////////////////////////////////////////


		//location for tutorial screens and buttons
		static string tutorialPicture1Location = "..\\..\\sprites\\Screen1.png";
		static string tutorialPicture2Location = "..\\..\\sprites\\Screen2.png";

		static string tutorialHomeButton = "..\\..\\sprites\\home_mainmenu.png";
		static string tutorialNextButton = "..\\..\\sprites\\next.png";
		static string tutorialBackButton = "..\\..\\sprites\\back.png";

		static Texture tutorialPicture1;
		static Texture tutorialPicture;
		static Texture tutorialPicture2;
		static Texture tutorialHome;
		static Texture tutorialNext;
		static Texture tutorialBack;

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////   Final Message Screen   /////////////////////////////////////////////////
        static string winSprite = "..\\..\\sprites\\Winner.png";
        static string loseSprite = "..\\..\\sprites\\Loser.png";
        static string menuButton1 = "..\\..\\sprites\\MAIN.png";
        static string menuButton2 = "..\\..\\sprites\\MAIN_2.png";
        static string mquit1 = "..\\..\\sprites\\mQuit.png";
        static string mquit2 = "..\\..\\sprites\\mQuit_2.png";

        static Texture winMessage;
        static Texture loseMessage;
        static Texture menuButtonT1;
        static Texture menuButtonT2;
        static Texture menuButtonT;
        static Texture mquitT;
        static Texture mquitT1;
        static Texture mquitT2;
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////    Battle Screen  //////////////////////////////////////////////////////
        static string char1Texture1 = "..\\..\\sprites\\char2r2.png";
        static string char1Texture2 = "..\\..\\sprites\\char2att.png";
        static string char2Texture1 = "..\\..\\sprites\\char3r2.png";
        static string char2Texture2 = "..\\..\\sprites\\char3att.png";
        static string char3Texture1 = "..\\..\\sprites\\char4r2.png";
        static string char3Texture2 = "..\\..\\sprites\\char4att.png";
        static string char4Texture1 = "..\\..\\sprites\\char5r2.png";
        static string char4Texture2 = "..\\..\\sprites\\char5att.png";
        static string char5Texture1 = "..\\..\\sprites\\char6r2.png";
        static string char5Texture2 = "..\\..\\sprites\\char6att.png";
        static string char6Texture1 = "..\\..\\sprites\\char7r2.png";
        static string char6Texture2 = "..\\..\\sprites\\char7att.png";
        static string char7Texture1 = "..\\..\\sprites\\char8r2.png";
        static string char7Texture2 = "..\\..\\sprites\\char8att.png";

        static string monster = "..\\..\\sprites\\PS_left.png";
        static Texture monsterT;

        static string battlebg = "..\\..\\sprites\\battlescreen.png";
        static string battlebg2 = "..\\..\\sprites\\battlescreen_2.png";
        static string battlebg3 = "..\\..\\sprites\\battlescreen_3.png";
        static string battlebg4 = "..\\..\\sprites\\battlescreen_4.png";

        static Texture battlebgT;
        static Texture battlebgT2;
        static Texture battlebgT3;
        static Texture battlebgT4;


        //static Texture char1T;
        static Texture char1T1;
        static Texture char1T2;

        //static Texture char2T;
        static Texture char2T1;
        static Texture char2T2;

        //static Texture char3T;
        static Texture char3T1;
        static Texture char3T2;

        //static Texture char4T;
        static Texture char4T1;
        static Texture char4T2;

        //static Texture char5T;
        static Texture char5T1;
        static Texture char5T2;

        //static Texture char6T;
        static Texture char6T1;
        static Texture char6T2;

        //static Texture char7T;
        static Texture char7T1;
        static Texture char7T2;

        static int partyXlocation;
        static int partyYlocation;

        static int monsterXlocation = 500;
        static int monsterYlocation = 500;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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


			//Paint the background of the main menu
			sprite.Transform = Matrix.Translation(0, 0, 0);
			sprite.Draw(mainMenu,color);

			//Create the new game button and move it into spot.
			sprite.Transform = Matrix.Translation (500, 200, 0);
			sprite.Draw (CurrentNewGame, color);

			//Create the tutorial button and move it into spot.
			sprite.Transform = Matrix.Translation(500, 330, 0);
			sprite.Draw (CurrentTutorial, color);

			//create the quit button and move it into spot.
			sprite.Transform = Matrix.Translation(500, 460, 0);
			sprite.Draw (CurrentQuit, color);
		}

		public static void createMainMenuTextures(Device device9){
			//Sprite sprite = new Sprite (device9);
			//Create the texture and place them into these objects to be held onto.

			mainMenu = createTexture(device9, menuBG);

			newGame = createTexture(device9, newGameButton);
			CurrentNewGame = newGame;
			newGame2 = createTexture (device9, newGameButton2);

			tutorial = createTexture(device9, tutorialButton);
			CurrentTutorial = tutorial;
			tutorial2 = createTexture(device9, tutorialButton2);

			quit = createTexture(device9, quitButton);
			CurrentQuit = quit;
			quit2 = createTexture(device9, quitButton2);
		}

        public static void renderBattleScreen(SlimDX.Color4 color, Device device9, Sprite sprite, int level, List<PlayerChar>party)
        {
            /*
             * change the player's and monster position for the battle screen
             * save the previous screen
             * */
            //status = GameStatus.battleScreen;

            // move characters to appropriate location on battle screen.
            partyXlocation = 100;
            partyYlocation = 300;


            sprite.Transform = Matrix.Translation(0, 0, 0);
            switch (level)
            {
                case 1: 
                    sprite.Draw(battlebgT, color);
                    break;
                case 2:
                    sprite.Draw(battlebgT2, color);
                    break;
                case 3:
                    sprite.Draw(battlebgT3, color);
                    break;
                case 4:
                    sprite.Draw(battlebgT4, color);
                    break;
            }

            foreach (PlayerChar character in party)
            {
                character.xLocation = partyXlocation;
                character.yLocation = partyYlocation;
                partyYlocation += 100;
                sprite.Transform = Matrix.Translation(character.xLocation, character.yLocation, 0);
                sprite.Draw(character.texture, color);
            }


            sprite.Transform = Matrix.Translation(monsterXlocation, monsterYlocation, 0);
            sprite.Draw(monsterT, color);


        }

        public static void createBattleScreenTextures(Device device9)
        {
            char1T1 = createTexture(device9, char1Texture1);
            //char1T = char1T1;
            char1T2 = createTexture(device9, char1Texture2);

            char2T1 = createTexture(device9, char2Texture1);
            //char2T = char2T1;
            char2T2 = createTexture(device9, char2Texture2);

            char3T1 = createTexture(device9, char3Texture1);
            //char3T = char3T1;
            char3T2 = createTexture(device9, char3Texture2);

            char4T1 = createTexture(device9, char4Texture1);
            //char4T = char4T1;
            char4T2 = createTexture(device9, char4Texture2);

            char5T1 = createTexture(device9, char5Texture1);
            //char5T = char5T1;
            char5T2 = createTexture(device9, char5Texture2);

            char6T1 = createTexture(device9, char6Texture1);
            //char6T = char6T1;
            char6T2 = createTexture(device9, char6Texture2);

            char7T1 = createTexture(device9, char7Texture1);
            //char7T = char7T1;
            char7T2 = createTexture(device9, char7Texture2);


            monsterT = createTexture(device9, monster);

            battlebgT = createTexture(device9, battlebg);
            battlebgT2 = createTexture(device9, battlebg2);
            battlebgT3 = createTexture(device9, battlebg3);
            battlebgT4 = createTexture(device9, battlebg4);
        }
        public static Texture switchChar1T(bool a , PlayerChar c)
        {
            if (a)
                c.texture = char1T2;
            else
                c.texture = char1T1;

            return c.texture;
        }

        public static Texture switchChar2T(bool a, PlayerChar c)
        {
            if (a)
                c.texture = char2T2;
            else
                c.texture = char2T1;

            return c.texture;
        }

        public static Texture switchChar3T(bool a, PlayerChar c)
        {
            if (a)
                c.texture = char3T2;
            else
                c.texture = char3T1;

            return c.texture;
        }

        public static Texture switchChar4T(bool a, PlayerChar c)
        {
            if (a)
                c.texture = char4T2;
            else
                c.texture = char4T1;

            return c.texture;
        }

        public static Texture switchChar5T(bool a, PlayerChar c)
        {
            if (a)
                c.texture = char5T2;
            else
                c.texture = char5T1;

            return c.texture;
        }

        public static Texture switchChar6T(bool a, PlayerChar c)
        {
            if (a)
                c.texture = char6T2;
            else
                c.texture = char6T1;

            return c.texture;
        }

        public static Texture switchChar7T(bool a, PlayerChar c)
        {
            if (a)
                c.texture = char7T2;
            else
                c.texture = char7T1;

            return c.texture;
        }

       

		public static void createTutorialTextures(Device device9){
			//Sprite sprite = new Sprite (device9);
			//Create the texture and place them into these objects to be held onto.

			tutorialPicture1 = createTexture (device9, tutorialPicture1Location);
			tutorialPicture = tutorialPicture1;
			tutorialPicture2 = createTexture (device9, tutorialPicture2Location);

			tutorialBack = createTexture (device9, tutorialBackButton);
			tutorialNext = createTexture (device9, tutorialNextButton);
			tutorialHome = createTexture (device9, tutorialHomeButton);
	
		}
			
		public static void renderTutorial(SlimDX.Color4 color, Device device9, Sprite sprite)
		{

			//Paint the background of the main menu
			sprite.Transform = Matrix.Translation(0, 0, 0);
			sprite.Transform = Matrix.Scaling(1,.75f,1);
			sprite.Draw(tutorialPicture,color);

			//Create the new game button and move it into spot.
			sprite.Transform = Matrix.Translation (850, 600, 0);
			sprite.Draw (tutorialNext, color);

			//Create the tutorial button and move it into spot.
			sprite.Transform = Matrix.Translation(50, 600, 0);
			sprite.Draw (tutorialBack, color);

			//create the quit button and move it into spot.
			sprite.Transform = Matrix.Translation(450, 650, 0);
			sprite.Draw (tutorialHome, color);

		}

		public static void switchTutorialScreen(bool a){
			if (a) {
				tutorialPicture = tutorialPicture2;
			} else{
				tutorialPicture = tutorialPicture1;
			}
		}

		public static void switchNewGameButton(bool a){
			if (a) {
				CurrentNewGame = newGame2;
			} else {
				CurrentNewGame = newGame;
			}
		}

		public static void switchTutorialButton(bool a){
			if (a) {
				CurrentTutorial = tutorial2;
			} else {
				CurrentTutorial = tutorial;
			}
		}

		public static void switchQuitButton(bool a){
			if (a) {
				CurrentQuit = quit2;
			} else {
				CurrentQuit = quit;
			}
		}

        public static void switchMenuButton(bool a)
        {
            if (a)
                menuButtonT = menuButtonT2;
            else
                menuButtonT = menuButtonT1;
        }

        public static void switchMQuitButton(bool a)
        {
            if (a)
                mquitT = mquitT2;
            else
                mquitT = mquitT1;
        }
        //Render Message Screen
        public static void renderMessage(SlimDX.Color4 color, Device device9, Sprite sprite, GameStatus status)
        {
            sprite.Transform = Matrix.Translation(0, 0, 0);
            if (status == GameStatus.win)
                sprite.Draw(winMessage, color);
            else if (status == GameStatus.lose)
                sprite.Draw(loseMessage, color);

            //create quit button
            sprite.Transform = Matrix.Translation(550, 460, 0);
            sprite.Draw(mquitT, color);

            //create menu button
            sprite.Transform = Matrix.Translation(200, 460, 0);
            sprite.Draw(menuButtonT, color);
        }

        public static void createMessageScreenTexture(Device device9)
        {
            winMessage = createTexture(device9, winSprite);
            loseMessage = createTexture(device9, loseSprite);

            mquitT1 = createTexture(device9, mquit1);
            mquitT = mquitT1;
            mquitT2 = createTexture(device9, mquit2);

            menuButtonT1 = createTexture(device9, menuButton1);
            menuButtonT = menuButtonT1;
            menuButtonT2 = createTexture(device9, menuButton2);
        }

        public static void renderPartyWindow(SlimDX.Color4 color, Device device9, Sprite sprite)
        {
            sprite.Transform = Matrix.Translation(0, 0, 0);
            sprite.Draw (mainMenu,color);
        }

        public static void disposeParty()
        {
            //mainMenu.Dispose(); //don't think this is necessary because main menu is already disposed
        }
        //  Create texture object and return it.
        public static Texture createTexture(Device device9, string textureLocation)
        {
            //Our texture
            return Texture.FromFile(device9, textureLocation);
        }

        //dispose battleScreen
        public static void disposebattle()
        {
            //char1T.Dispose();
            char1T1.Dispose();
            char1T2.Dispose();
            //char2T.Dispose();
            char2T1.Dispose();
            char2T2.Dispose();
            //char3T.Dispose();
            char3T1.Dispose();
            char3T2.Dispose();
            //char4T.Dispose();
            char4T1.Dispose();
            char4T2.Dispose();
            //char5T.Dispose();
            char5T1.Dispose();
            char5T2.Dispose();
            //char6T.Dispose();
            char6T1.Dispose();
            char6T2.Dispose();
            //char7T.Dispose();
            char7T1.Dispose();
            char7T2.Dispose();

            battlebgT.Dispose();
            battlebgT2.Dispose();
            battlebgT3.Dispose();
            battlebgT4.Dispose();

            monsterT.Dispose();
        }
        
        //dispose message screen
        public static void disposeMessageScreen()
        {
            winMessage.Dispose();
            loseMessage.Dispose();
            mquitT.Dispose();
            mquitT1.Dispose();
            mquitT2.Dispose();
            menuButtonT.Dispose();
            menuButtonT1.Dispose();
            menuButtonT2.Dispose();
        }

		//Dispose main menu textures to free up the memory.
		public static void disposeMainMenu(){
			mainMenu.Dispose ();
			newGame.Dispose ();
			CurrentNewGame.Dispose ();
			newGame2.Dispose ();
			tutorial.Dispose ();
			CurrentTutorial.Dispose ();
			tutorial2.Dispose ();
			quit.Dispose ();
			quit2.Dispose ();
			CurrentQuit.Dispose ();
		}

		public static void disposeTutorial(){
			tutorialPicture1.Dispose();
			tutorialPicture2.Dispose();
			tutorialBack.Dispose ();
			tutorialNext.Dispose ();
			tutorialHome.Dispose ();
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

