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

		////////////////////////////////////////   Characters  /////////////////////////////////////////////////
		static string Character1Big = "..\\..\\sprites\\Characters\\Sprit1\\BIGONE.png";
		static string Character1Back = "..\\..\\sprites\\Characters\\Sprit1\\Back.png";
		static string Character1Front = "..\\..\\sprites\\Characters\\Sprit1\\Front.png";
        static string Character1Back2 = "..\\..\\sprites\\Characters\\Sprit1\\Back.png";
        static string Character1Front2 = "..\\..\\sprites\\Characters\\Sprit1\\Front.png";
		static string Character1Left = "..\\..\\sprites\\Characters\\Sprit1\\Left_1.png";
        static string Character1Left2 = "..\\..\\sprites\\Characters\\Sprit1\\Left_2.png";
		static string Character1Right = "..\\..\\sprites\\Characters\\Sprit1\\Right_1.png";
        static string Character1Right2 = "..\\..\\sprites\\Characters\\Sprit1\\Right_2.png";
        static string Character1att = "..\\..\\sprites\\Characters\\Sprit1\\char1att.png";

		static string Character2Big = "..\\..\\sprites\\Characters\\Sprit2\\BIGONE.png";
		static string Character2Back = "..\\..\\sprites\\Characters\\Sprit2\\F7.png";
        static string Character2Back2 = "..\\..\\sprites\\Characters\\Sprit2\\F8.png";
		static string Character2Front = "..\\..\\sprites\\Characters\\Sprit2\\F5.png";
        static string Character2Front2 = "..\\..\\sprites\\Characters\\Sprit2\\F6.png";
		static string Character2Left = "..\\..\\sprites\\Characters\\Sprit2\\F1.png";
        static string Character2Left2 = "..\\..\\sprites\\Characters\\Sprit2\\F2.png";
		static string Character2Right = "..\\..\\sprites\\Characters\\Sprit2\\F3.png";
        static string Character2Right2 = "..\\..\\sprites\\Characters\\Sprit2\\F4.png";
        static string Character2att = "..\\..\\sprites\\Characters\\Sprit2\\char2att.png";

		static string Character3Big = "..\\..\\sprites\\Characters\\Sprit3\\BIGONE.png";
		static string Character3Back = "..\\..\\sprites\\Characters\\Sprit3\\F7.png";
        static string Character3Back2 = "..\\..\\sprites\\Characters\\Sprit3\\F8.png";
		static string Character3Front = "..\\..\\sprites\\Characters\\Sprit3\\F5.png";
        static string Character3Front2 = "..\\..\\sprites\\Characters\\Sprit3\\F6.png";
		static string Character3Left = "..\\..\\sprites\\Characters\\Sprit3\\F1.png";
        static string Character3Left2 = "..\\..\\sprites\\Characters\\Sprit3\\F2.png";
		static string Character3Right = "..\\..\\sprites\\Characters\\Sprit3\\F3.png";
        static string Character3Right2 = "..\\..\\sprites\\Characters\\Sprit3\\F4.png";
        static string Character3att = "..\\..\\sprites\\Characters\\Sprit3\\char3att.png";

		static string Character4Big = "..\\..\\sprites\\Characters\\Sprit4\\BIGONE.png";
		static string Character4Back = "..\\..\\sprites\\Characters\\Sprit4\\F7.png";
		static string Character4Front = "..\\..\\sprites\\Characters\\Sprit4\\F5.png";
		static string Character4Left = "..\\..\\sprites\\Characters\\Sprit4\\F1.png";
		static string Character4Right = "..\\..\\sprites\\Characters\\Sprit4\\F3.png";
        static string Character4Back2 = "..\\..\\sprites\\Characters\\Sprit4\\F8.png";
        static string Character4Front2 = "..\\..\\sprites\\Characters\\Sprit4\\F6.png";
        static string Character4Left2 = "..\\..\\sprites\\Characters\\Sprit4\\F2.png";
        static string Character4Right2 = "..\\..\\sprites\\Characters\\Sprit4\\F4.png";
        static string Character4att = "..\\..\\sprites\\Characters\\Sprit4\\char4att.png";

		static string Character5Big = "..\\..\\sprites\\Characters\\Sprit5\\BIGONE.png";
		static string Character5Back = "..\\..\\sprites\\Characters\\Sprit5\\F7.png";
		static string Character5Front = "..\\..\\sprites\\Characters\\Sprit5\\F5.png";
		static string Character5Left = "..\\..\\sprites\\Characters\\Sprit5\\F1.png";
		static string Character5Right = "..\\..\\sprites\\Characters\\Sprit5\\F3.png";
        static string Character5Back2 = "..\\..\\sprites\\Characters\\Sprit5\\F8.png";
        static string Character5Front2 = "..\\..\\sprites\\Characters\\Sprit5\\F6.png";
        static string Character5Left2 = "..\\..\\sprites\\Characters\\Sprit5\\F2.png";
        static string Character5Right2 = "..\\..\\sprites\\Characters\\Sprit5\\F4.png";
        static string Character5att = "..\\..\\sprites\\Characters\\Sprit5\\char5att.png";

		static string Character6Big = "..\\..\\sprites\\Characters\\Sprit6\\BIGONE.png";
		static string Character6Back = "..\\..\\sprites\\Characters\\Sprit6\\F7.png";
		static string Character6Front = "..\\..\\sprites\\Characters\\Sprit6\\F5.png";
		static string Character6Left = "..\\..\\sprites\\Characters\\Sprit6\\F1.png";
		static string Character6Right = "..\\..\\sprites\\Characters\\Sprit6\\F3.png";
        static string Character6Back2 = "..\\..\\sprites\\Characters\\Sprit6\\F8.png";
        static string Character6Front2 = "..\\..\\sprites\\Characters\\Sprit6\\F6.png";
        static string Character6Left2 = "..\\..\\sprites\\Characters\\Sprit6\\F2.png";
        static string Character6Right2 = "..\\..\\sprites\\Characters\\Sprit6\\F4.png";
        static string Character6att = "..\\..\\sprites\\Characters\\Sprit6\\char6att.png";

		static string Character7Big = "..\\..\\sprites\\Characters\\Sprit7\\BIGONE.png";
		static string Character7Back = "..\\..\\sprites\\Characters\\Sprit7\\F7.png";
		static string Character7Front = "..\\..\\sprites\\Characters\\Sprit7\\F5.png";
		static string Character7Left = "..\\..\\sprites\\Characters\\Sprit7\\F1.png";
		static string Character7Right = "..\\..\\sprites\\Characters\\Sprit7\\F3.png";
        static string Character7Back2 = "..\\..\\sprites\\Characters\\Sprit7\\F8.png";
        static string Character7Front2 = "..\\..\\sprites\\Characters\\Sprit7\\F6.png";
        static string Character7Left2 = "..\\..\\sprites\\Characters\\Sprit7\\F2.png";
        static string Character7Right2 = "..\\..\\sprites\\Characters\\Sprit7\\F4.png";
        static string Character7att = "..\\..\\sprites\\Characters\\Sprit7\\char7att.png";

		static string Character8Big = "..\\..\\sprites\\Characters\\Sprit8\\BIGONE.png";
		static string Character8Back = "..\\..\\sprites\\Characters\\Sprit8\\F7.png";
		static string Character8Front = "..\\..\\sprites\\Characters\\Sprit8\\F5.png";
		static string Character8Left = "..\\..\\sprites\\Characters\\Sprit8\\F1.png";
		static string Character8Right = "..\\..\\sprites\\Characters\\Sprit8\\F3.png";
        static string Character8Back2 = "..\\..\\sprites\\Characters\\Sprit8\\F8.png";
        static string Character8Front2 = "..\\..\\sprites\\Characters\\Sprit8\\F6.png";
        static string Character8Left2 = "..\\..\\sprites\\Characters\\Sprit8\\F2.png";
        static string Character8Right2 = "..\\..\\sprites\\Characters\\Sprit8\\F4.png";
        static string Character8att = "..\\..\\sprites\\Characters\\Sprit8\\char8att.png";

		/*static Texture TCharacter1Big;
		static Texture TCharacter1Front;
		static Texture TCharacter1Back;
		static Texture TCharacter1Left;
		static Texture TCharacter1Right;
        static Texture TCharacter1Front2;
        static Texture TCharacter1Back2;
        static Texture TCharacter1Left2;
        static Texture TCharacter1Right2;
        static Texture Tchar1Att;
        static Texture Tchar1Display;

		static Texture TCharacter2Big;
		static Texture TCharacter2Front;
		static Texture TCharacter2Back;
		static Texture TCharacter2Left;
		static Texture TCharacter2Right;
        static Texture TCharacter2Front2;
        static Texture TCharacter2Back2;
        static Texture TCharacter2Left2;
        static Texture TCharacter2Right2;
        static Texture Tchar2Att;
        static Texture Tchar2Display;

		static Texture TCharacter3Big;
		static Texture TCharacter3Front;
		static Texture TCharacter3Back;
		static Texture TCharacter3Left;
		static Texture TCharacter3Right;
        static Texture TCharacter3Front2;
        static Texture TCharacter3Back2;
        static Texture TCharacter3Left2;
        static Texture TCharacter3Right2;
        static Texture Tchar3Att;
        static Texture Tchar3Display;

		static Texture TCharacter4Big;
		static Texture TCharacter4Front;
		static Texture TCharacter4Back;
		static Texture TCharacter4Left;
		static Texture TCharacter4Right;
        static Texture TCharacter4Front2;
        static Texture TCharacter4Back2;
        static Texture TCharacter4Left2;
        static Texture TCharacter4Right2;
        static Texture Tchar4Att;
        static Texture Tchar4Display;

		static Texture TCharacter5Big;
		static Texture TCharacter5Front;
		static Texture TCharacter5Back;
		static Texture TCharacter5Left;
		static Texture TCharacter5Right;
        static Texture TCharacter5Front2;
        static Texture TCharacter5Back2;
        static Texture TCharacter5Left2;
        static Texture TCharacter5Right2;
        static Texture Tchar5Att;
        static Texture Tchar5Display;

		static Texture TCharacter6Big;
		static Texture TCharacter6Front;
		static Texture TCharacter6Back;
		static Texture TCharacter6Left;
		static Texture TCharacter6Right;
        static Texture TCharacter6Front2;
        static Texture TCharacter6Back2;
        static Texture TCharacter6Left2;
        static Texture TCharacter6Right2;
        static Texture Tchar6Att;
        static Texture Tchar6Display;

		static Texture TCharacter7Big;
		static Texture TCharacter7Front;
		static Texture TCharacter7Back;
		static Texture TCharacter7Left;
		static Texture TCharacter7Right;
        static Texture TCharacter7Front2;
        static Texture TCharacter7Back2;
        static Texture TCharacter7Left2;
        static Texture TCharacter7Right2;
        static Texture Tchar7Att;
        static Texture Tchar7Display;

		static Texture TCharacter8Big;
		static Texture TCharacter8Front;
		static Texture TCharacter8Back;
		static Texture TCharacter8Left;
		static Texture TCharacter8Right;
        static Texture TCharacter8Front2;
        static Texture TCharacter8Back2;
        static Texture TCharacter8Left2;
        static Texture TCharacter8Right2;
        static Texture Tchar8Att;
        static Texture Tchar8Display;*/
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
                //character.texture = character.right;
                character.xLocation = partyXlocation;
                character.yLocation = partyYlocation;
                partyYlocation += 100;
                sprite.Transform = Matrix.Translation(character.xLocation, character.yLocation, 0);
                sprite.Draw(character.texture, color);
                //character.texture = character.right;
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

        public static Texture switchBattleCharTexture(bool a, PlayerChar c)
        {
            if (a)
                return c.att;
            else
                return c.right;
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

        public static void switchCharacter(bool change, string status, ref PlayerChar character)
        { 
            //return character.texture;
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
			device9.Clear (ClearFlags.Target, Color.Black, 1.0f, 0);
			System.Drawing.Font font = new System.Drawing.Font (FontFamily.GenericSansSerif, 20);

			SlimDX.Direct3D9.Font textDrawing = new SlimDX.Direct3D9.Font (device9,font);

			sprite.Transform = Matrix.Translation(10, 10, 0);
			textDrawing.DrawString (sprite, "Hello world", 0, 0, color);

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

		public static List<PlayerChar> createCharacterTextures(Device device9, List<PlayerChar> characters){
			
			//TCharacter1Big = createTexture (device9, Character1Big);
            //characters[0].texture = createTexture(device9, Character1Back);
            characters[0].big = createTexture(device9, Character1Big);
            characters[0].front = createTexture(device9, Character1Front);
            characters[0].back = createTexture(device9, Character1Back);
            characters[0].left = createTexture(device9, Character1Left);
            characters[0].right2 = createTexture(device9, Character1Right);
            characters[0].front2 = createTexture(device9, Character1Front2);
            characters[0].back2 = createTexture(device9, Character1Back2);
            characters[0].left2 = createTexture(device9, Character1Left2);
            characters[0].right = createTexture(device9, Character1Right2);
            characters[0].att = createTexture(device9, Character1att);
            characters[0].texture = characters[0].back;

            characters[1].big = createTexture(device9, Character2Big);
            characters[1].front = createTexture(device9, Character2Front);
            characters[1].back = createTexture(device9, Character2Back);
            characters[1].left = createTexture(device9, Character2Left);
            characters[1].right = createTexture(device9, Character2Right);
            characters[1].front2 = createTexture(device9, Character2Front2);
            characters[1].back2 = createTexture(device9, Character2Back2);
            characters[1].left2 = createTexture(device9, Character2Left2);
            characters[1].right2 = createTexture(device9, Character2Right2);
            characters[1].att = createTexture(device9, Character2att);
            characters[1].texture = characters[1].back;

            characters[2].big = createTexture(device9, Character3Big);
            characters[2].front = createTexture(device9, Character3Front);
            characters[2].back = createTexture(device9, Character3Back);
            characters[2].left = createTexture(device9, Character3Left);
            characters[2].right = createTexture(device9, Character3Right);
            characters[2].front2 = createTexture(device9, Character3Front2);
            characters[2].back2 = createTexture(device9, Character3Back2);
            characters[2].left2 = createTexture(device9, Character3Left2);
            characters[2].right2 = createTexture(device9, Character3Right2);
            characters[2].att = createTexture(device9, Character3att);
            characters[2].texture = characters[2].back;

            characters[3].big = createTexture(device9, Character4Big);
            characters[3].front = createTexture(device9, Character4Front);
            characters[3].back = createTexture(device9, Character4Back);
            characters[3].left = createTexture(device9, Character4Left);
            characters[3].right = createTexture(device9, Character4Right);
            characters[3].front2 = createTexture(device9, Character4Front2);
            characters[3].back2 = createTexture(device9, Character4Back2);
            characters[3].left2 = createTexture(device9, Character4Left2);
            characters[3].right2 = createTexture(device9, Character4Right2);
            characters[3].att = createTexture(device9, Character4att);
            characters[3].texture = characters[3].back;

            characters[4].big = createTexture(device9, Character5Big);
            characters[4].front = createTexture(device9, Character5Front);
            characters[4].back = createTexture(device9, Character5Back);
            characters[4].left = createTexture(device9, Character5Left);
            characters[4].right = createTexture(device9, Character5Right);
            characters[4].front2 = createTexture(device9, Character5Front2);
            characters[4].back2 = createTexture(device9, Character5Back2);
            characters[4].left2 = createTexture(device9, Character5Left2);
            characters[4].right2 = createTexture(device9, Character5Right2);
            characters[4].att = createTexture(device9, Character5att);
            characters[4].texture = characters[4].back;

            characters[5].big = createTexture(device9, Character6Big);
            characters[5].front = createTexture(device9, Character6Front);
            characters[5].back = createTexture(device9, Character6Back);
            characters[5].left = createTexture(device9, Character6Left);
            characters[5].right = createTexture(device9, Character6Right);
            characters[5].front2 = createTexture(device9, Character6Front2);
            characters[5].back2 = createTexture(device9, Character6Back2);
            characters[5].left2 = createTexture(device9, Character6Left2);
            characters[5].right2 = createTexture(device9, Character6Right2);
            characters[5].att = createTexture(device9, Character6att);
            characters[5].texture = characters[5].back;

            characters[6].big = createTexture(device9, Character7Big);
            characters[6].front = createTexture(device9, Character7Front);
            characters[6].back = createTexture(device9, Character7Back);
            characters[6].left = createTexture(device9, Character7Left);
            characters[6].right = createTexture(device9, Character7Right);
            characters[6].front2 = createTexture(device9, Character7Front2);
            characters[6].back2 = createTexture(device9, Character7Back2);
            characters[6].left2 = createTexture(device9, Character7Left2);
            characters[6].right2 = createTexture(device9, Character7Right2);
            characters[6].att = createTexture(device9, Character7att);
            characters[6].texture = characters[6].back;

            characters[7].big = createTexture(device9, Character8Big);
            characters[7].front = createTexture(device9, Character8Front);
            characters[7].back = createTexture(device9, Character8Back);
            characters[7].left = createTexture(device9, Character8Left);
            characters[7].right = createTexture(device9, Character8Right);
            characters[7].front2 = createTexture(device9, Character8Front2);
            characters[7].back2 = createTexture(device9, Character8Back2);
            characters[7].left2 = createTexture(device9, Character8Left2);
            characters[7].right2 = createTexture(device9, Character8Right2);
            characters[7].att = createTexture(device9, Character8att);
            characters[7].texture = characters[7].back;

            return characters;
		}

		public static void disposeCharacterTextures(){
            /*TCharacter1Big.Dispose();
			TCharacter1Front.Dispose ();
			TCharacter1Back.Dispose();
			TCharacter1Left.Dispose();
			TCharacter1Right.Dispose();
            TCharacter1Front2.Dispose();
            TCharacter1Back2.Dispose();
            TCharacter1Left2.Dispose();
            TCharacter1Right2.Dispose();

            TCharacter2Big.Dispose();
			TCharacter2Front.Dispose ();
			TCharacter2Back.Dispose();
			TCharacter2Left.Dispose();
			TCharacter2Right.Dispose();
            TCharacter2Front2.Dispose();
            TCharacter2Back2.Dispose();
            TCharacter2Left2.Dispose();
            TCharacter2Right2.Dispose();

            TCharacter3Big.Dispose();
			TCharacter3Front.Dispose ();
			TCharacter3Back.Dispose();
			TCharacter3Left.Dispose();
			TCharacter3Right.Dispose();
            TCharacter3Front2.Dispose();
            TCharacter3Back2.Dispose();
            TCharacter3Left2.Dispose();
            TCharacter3Right2.Dispose();

            TCharacter4Big.Dispose();
			TCharacter4Front.Dispose ();
			TCharacter4Back.Dispose();
			TCharacter4Left.Dispose();
			TCharacter4Right.Dispose();
            TCharacter4Front2.Dispose();
            TCharacter4Back2.Dispose();
            TCharacter4Left2.Dispose();
            TCharacter4Right2.Dispose();

            TCharacter5Big.Dispose();
			TCharacter5Front.Dispose();
			TCharacter5Back.Dispose();
			TCharacter5Left.Dispose();
			TCharacter5Right.Dispose();
            TCharacter5Front2.Dispose();
            TCharacter5Back2.Dispose();
            TCharacter5Left2.Dispose();
            TCharacter5Right2.Dispose();

            TCharacter6Big.Dispose();
			TCharacter6Front.Dispose();
			TCharacter6Back.Dispose();
			TCharacter6Left.Dispose();
			TCharacter6Right.Dispose();
            TCharacter6Front2.Dispose();
            TCharacter6Back2.Dispose();
            TCharacter6Left2.Dispose();
            TCharacter6Right2.Dispose();

            TCharacter7Big.Dispose();
			TCharacter7Front.Dispose();
			TCharacter7Back.Dispose();
			TCharacter7Left.Dispose();
			TCharacter7Right.Dispose();
            TCharacter7Front2.Dispose();
            TCharacter7Back2.Dispose();
            TCharacter7Left2.Dispose();
            TCharacter7Right2.Dispose();

            TCharacter8Big.Dispose();
			TCharacter8Front.Dispose();
			TCharacter8Back.Dispose();
			TCharacter8Left.Dispose();
			TCharacter8Right.Dispose();
            TCharacter8Front2.Dispose();
            TCharacter8Back2.Dispose();
            TCharacter8Left2.Dispose();
            TCharacter8Right2.Dispose();*/
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

