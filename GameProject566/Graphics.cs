﻿using System;
using SlimDX.Direct3D9;
using System.Windows.Forms;
using SlimDX;
using System.Drawing;

namespace GameProject566
{
	public class Graphics
	{

		static SlimDX.Direct3D9.Font textDrawing;

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

		////////////////////////////////////////   Characters  /////////////////////////////////////////////////
		/// 
		static string Character1Display = "..\\..\\sprites\\Characters\\Sprit1\\BIGONE.png";
		static string Character1Back = "..\\..\\sprites\\Characters\\Sprit1\\Back.png";
		static string Character1Front = "..\\..\\sprites\\Characters\\Sprit1\\Front.png";
		static string Character1Left = "..\\..\\sprites\\Characters\\Sprit1\\Left_1.png";
		static string Character1Right = "..\\..\\sprites\\Characters\\Sprit1\\Right_1.png";

		static string Character2Display = "..\\..\\sprites\\Characters\\Sprit2\\BIGONE.png";
		static string Character2Back = "..\\..\\sprites\\Characters\\Sprit2\\F7.png";
		static string Character2Front = "..\\..\\sprites\\Characters\\Sprit2\\F5.png";
		static string Character2Left = "..\\..\\sprites\\Characters\\Sprit2\\F1.png";
		static string Character2Right = "..\\..\\sprites\\Characters\\Sprit2\\F3.png";

		static string Character3Display = "..\\..\\sprites\\Characters\\Sprit3\\BIGONE.png";
		static string Character3Back = "..\\..\\sprites\\Characters\\Sprit3\\F7.png";
		static string Character3Front = "..\\..\\sprites\\Characters\\Sprit3\\F5.png";
		static string Character3Left = "..\\..\\sprites\\Characters\\Sprit3\\F1.png";
		static string Character3Right = "..\\..\\sprites\\Characters\\Sprit3\\F3.png";

		static string Character4Display = "..\\..\\sprites\\Characters\\Sprit4\\BIGONE.png";
		static string Character4Back = "..\\..\\sprites\\Characters\\Sprit4\\F7.png";
		static string Character4Front = "..\\..\\sprites\\Characters\\Sprit4\\F5.png";
		static string Character4Left = "..\\..\\sprites\\Characters\\Sprit4\\F1.png";
		static string Character4Right = "..\\..\\sprites\\Characters\\Sprit4\\F3.png";

		static string Character5Display = "..\\..\\sprites\\Characters\\Sprit5\\BIGONE.png";
		static string Character5Back = "..\\..\\sprites\\Characters\\Sprit5\\F7.png";
		static string Character5Front = "..\\..\\sprites\\Characters\\Sprit5\\F5.png";
		static string Character5Left = "..\\..\\sprites\\Characters\\Sprit5\\F1.png";
		static string Character5Right = "..\\..\\sprites\\Characters\\Sprit5\\F3.png";

		static string Character6Display = "..\\..\\sprites\\Characters\\Sprit6\\BIGONE.png";
		static string Character6Back = "..\\..\\sprites\\Characters\\Sprit6\\F7.png";
		static string Character6Front = "..\\..\\sprites\\Characters\\Sprit6\\F5.png";
		static string Character6Left = "..\\..\\sprites\\Characters\\Sprit6\\F1.png";
		static string Character6Right = "..\\..\\sprites\\Characters\\Sprit6\\F3.png";

		static string Character7Display = "..\\..\\sprites\\Characters\\Sprit7\\BIGONE.png";
		static string Character7Back = "..\\..\\sprites\\Characters\\Sprit7\\F7.png";
		static string Character7Front = "..\\..\\sprites\\Characters\\Sprit7\\F5.png";
		static string Character7Left = "..\\..\\sprites\\Characters\\Sprit7\\F1.png";
		static string Character7Right = "..\\..\\sprites\\Characters\\Sprit7\\F3.png";

		static string Character8Display = "..\\..\\sprites\\Characters\\Sprit8\\BIGONE.png";
		static string Character8Back = "..\\..\\sprites\\Characters\\Sprit8\\F7.png";
		static string Character8Front = "..\\..\\sprites\\Characters\\Sprit8\\F5.png";
		static string Character8Left = "..\\..\\sprites\\Characters\\Sprit8\\F1.png";
		static string Character8Right = "..\\..\\sprites\\Characters\\Sprit8\\F3.png";

		static Texture TCharacter1Display;
		static Texture TCharacter1Front;
		static Texture TCharacter1Back;
		static Texture TCharacter1Left;
		static Texture TCharacter1Right;

		static Texture TCharacter2Display;
		static Texture TCharacter2Front;
		static Texture TCharacter2Back;
		static Texture TCharacter2Left;
		static Texture TCharacter2Right;

		static Texture TCharacter3Display;
		static Texture TCharacter3Front;
		static Texture TCharacter3Back;
		static Texture TCharacter3Left;
		static Texture TCharacter3Right;

		static Texture TCharacter4Display;
		static Texture TCharacter4Front;
		static Texture TCharacter4Back;
		static Texture TCharacter4Left;
		static Texture TCharacter4Right;

		static Texture TCharacter5Display;
		static Texture TCharacter5Front;
		static Texture TCharacter5Back;
		static Texture TCharacter5Left;
		static Texture TCharacter5Right;

		static Texture TCharacter6Display;
		static Texture TCharacter6Front;
		static Texture TCharacter6Back;
		static Texture TCharacter6Left;
		static Texture TCharacter6Right;

		static Texture TCharacter7Display;
		static Texture TCharacter7Front;
		static Texture TCharacter7Back;
		static Texture TCharacter7Left;
		static Texture TCharacter7Right;

		static Texture TCharacter8Display;
		static Texture TCharacter8Front;
		static Texture TCharacter8Back;
		static Texture TCharacter8Left;
		static Texture TCharacter8Right;

		static Texture TCharacterDisplay;
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		////////////////////////////////////////   Character Creation Screen   /////////////////////////////////////////////////
		static string CharacterDisplayBox = "..\\..\\sprites\\party_screen\\CharacterScreen.png";
		//static string GrayTextBox = "..\\..\\sprites\\party_screen\\...png";
		static string CharacterCreationLeftArrow = "..\\..\\sprites\\party_screen\\Left_1.png";
		static string CharacterCreationLeftArrowDimmed = "..\\..\\sprites\\party_screen\\Left_2.png";
		static string CharacterCreationRightArrow = "..\\..\\sprites\\party_screen\\Right_1.png";
		static string CharacterCreationRightArrowDimmed = "..\\..\\sprites\\party_screen\\Right_2.png";

		static Texture TCharacterDisplayBox;
		//static Texture TGrayTextBox;
		static Texture TCharacterCreationLeftArrow;
		static Texture TCharacterCreationLeftArrowDimmed;
		static Texture TCharacterCreationRightArrow;
		static Texture TCharacterCreationRightArrowDimmed;

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


		public static void createCharacterScreenTextures(Device device9){

			TCharacterDisplayBox = createTexture(device9, CharacterDisplayBox);
			//static Texture TGrayTextBox;
			TCharacterCreationLeftArrow = createTexture(device9, CharacterCreationLeftArrow);
			TCharacterCreationLeftArrowDimmed = createTexture(device9, CharacterCreationLeftArrowDimmed);
			TCharacterCreationRightArrow = createTexture(device9, CharacterCreationRightArrow);
			TCharacterCreationRightArrowDimmed = createTexture(device9, CharacterCreationRightArrowDimmed);
			System.Drawing.Font font = new System.Drawing.Font (FontFamily.GenericSansSerif, 20);
			textDrawing = new SlimDX.Direct3D9.Font (device9,font);

		}

		public static void disposeCharacterScreenTextures(){
			TCharacterCreationLeftArrow.Dispose ();
			TCharacterCreationLeftArrowDimmed.Dispose ();
			TCharacterCreationRightArrow.Dispose ();
			TCharacterCreationRightArrowDimmed.Dispose ();
		}

        public static void renderPartyWindow(SlimDX.Color4 color, Device device9, Sprite sprite)
        {
			device9.Clear (ClearFlags.Target, Color.Black, 1.0f, 0);


			TCharacterDisplay = TCharacter1Display;

			sprite.Transform = Matrix.Translation(10, 10, 0);

			textDrawing.DrawString (sprite, "Appearance:", 0, 0, color);

		
			sprite.Transform = Matrix.Scaling(.01f,.01f,0) + Matrix.Translation(10, 100, 0);
			sprite.Draw (TCharacterDisplayBox, color);
			sprite.Transform = Matrix.Scaling(.8f,.8f,0) + Matrix.Translation(150, 140, 0);
			sprite.Draw (TCharacterDisplay, color);


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

		//Dispose tutorial
		public static void disposeTutorial(){
			tutorialPicture1.Dispose();
			tutorialPicture2.Dispose();
			tutorialBack.Dispose ();
			tutorialNext.Dispose ();
			tutorialHome.Dispose ();
		}

		//Create character Textures for characters on map
		public static void createCharacterTextures(Device device9){
			
			TCharacter1Display = createTexture (device9, Character1Display);
			TCharacter1Front = createTexture (device9, Character1Front);
			TCharacter1Back = createTexture (device9, Character1Back);
			TCharacter1Left = createTexture (device9, Character1Left);
			TCharacter1Right = createTexture (device9, Character1Right);

			TCharacter2Display = createTexture (device9, Character2Display);
			TCharacter2Front = createTexture (device9, Character2Front);
			TCharacter2Back = createTexture (device9, Character2Back);
			TCharacter2Left = createTexture (device9, Character2Left);
			TCharacter2Right = createTexture (device9, Character2Right);

			TCharacter3Display = createTexture (device9, Character3Display);
			TCharacter3Front = createTexture (device9, Character3Front);
			TCharacter3Back = createTexture (device9, Character3Back);
			TCharacter3Left = createTexture (device9, Character3Left);
			TCharacter3Right = createTexture (device9, Character3Right);

			TCharacter4Display = createTexture (device9, Character4Display);
			TCharacter4Front = createTexture (device9, Character4Front);
			TCharacter4Back = createTexture (device9, Character4Back);
			TCharacter4Left = createTexture (device9, Character4Left);
			TCharacter4Right = createTexture (device9, Character4Right);

			TCharacter5Display = createTexture (device9, Character5Display);
			TCharacter5Front = createTexture (device9, Character5Front);
			TCharacter5Back = createTexture (device9, Character5Back);
			TCharacter5Left = createTexture (device9, Character5Left);
			TCharacter5Right = createTexture (device9, Character5Right);

			TCharacter6Display = createTexture (device9, Character6Display);
			TCharacter6Front = createTexture (device9, Character6Front);
			TCharacter6Back = createTexture (device9, Character6Back);
			TCharacter6Left = createTexture (device9, Character6Left);
			TCharacter6Right = createTexture (device9, Character6Right);

			TCharacter7Display = createTexture (device9, Character7Display);
			TCharacter7Front = createTexture (device9, Character7Front);
			TCharacter7Back = createTexture (device9, Character7Back);
			TCharacter7Left = createTexture (device9, Character7Left);
			TCharacter7Right = createTexture (device9, Character7Right);

			TCharacter8Display = createTexture (device9, Character8Display);
			TCharacter8Front = createTexture (device9, Character8Front);
			TCharacter8Back = createTexture (device9, Character8Back);
			TCharacter8Left = createTexture (device9, Character8Left);
			TCharacter8Right = createTexture (device9, Character8Right);
		}
			
		//Dispose Character textures
		public static void disposeCharacterTextures(){
			TCharacter1Display.Dispose();
			TCharacter1Front.Dispose ();
			TCharacter1Back.Dispose();
			TCharacter1Left.Dispose();
			TCharacter1Right.Dispose();

			TCharacter2Display.Dispose();
			TCharacter2Front.Dispose ();
			TCharacter2Back.Dispose();
			TCharacter2Left.Dispose();
			TCharacter2Right.Dispose();

			TCharacter3Display.Dispose();
			TCharacter3Front.Dispose ();
			TCharacter3Back.Dispose();
			TCharacter3Left.Dispose();
			TCharacter3Right.Dispose();

			TCharacter4Display.Dispose();
			TCharacter4Front.Dispose ();
			TCharacter4Back.Dispose();
			TCharacter4Left.Dispose();
			TCharacter4Right.Dispose();

			TCharacter5Display.Dispose();
			TCharacter5Front.Dispose ();
			TCharacter5Back.Dispose();
			TCharacter5Left.Dispose();
			TCharacter5Right.Dispose();

			TCharacter6Display.Dispose();
			TCharacter6Front.Dispose ();
			TCharacter6Back.Dispose();
			TCharacter6Left.Dispose();
			TCharacter6Right.Dispose();

			TCharacter7Display.Dispose();
			TCharacter7Front.Dispose ();
			TCharacter7Back.Dispose();
			TCharacter7Left.Dispose();
			TCharacter7Right.Dispose();

			TCharacter8Display.Dispose();
			TCharacter8Front.Dispose ();
			TCharacter8Back.Dispose();
			TCharacter8Left.Dispose();
			TCharacter8Right.Dispose();

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

