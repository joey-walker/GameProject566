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

        /////////////////////////////////////////    Battle Screen  //////////////////////////////////////////////////////

        //static string monster = "..\\..\\sprites\\PS_left.png";
        //static Texture monsterT;

        static string battlebg = "..\\..\\sprites\\battlescreen.png";
        static string battlebg2 = "..\\..\\sprites\\battlescreen_2.png";
        static string battlebg3 = "..\\..\\sprites\\battlescreen_3.png";
        static string battlebg4 = "..\\..\\sprites\\battlescreen_4.png";

        static Texture battlebgT;
        static Texture battlebgT2;
        static Texture battlebgT3;
        static Texture battlebgT4;


        static int partyXlocation;
        static int partyYlocation;

        static int monsterXlocation = 500;
        static int monsterYlocation = 500;

        //device9.Clear (ClearFlags.Target, Color.Black, 1.0f, 0);
		static System.Drawing.Font BattleScreenfont = new System.Drawing.Font (FontFamily.GenericSansSerif, 12);

		static SlimDX.Direct3D9.Font BattleTextDrawing; //= new SlimDX.Direct3D9.Font (device9,font);

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

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		////////////////////////////////////////   Character Creation Screen   /////////////////////////////////////////////////
		static string CharacterDisplayBox = "..\\..\\sprites\\party_screen\\CharacterScreen.png";
		static string TextBox = "..\\..\\sprites\\party_screen\\TextBox.png";
		static string CharacterCreationLeftArrow = "..\\..\\sprites\\party_screen\\Left_2.png";
		static string CharacterCreationLeftArrowDimmed = "..\\..\\sprites\\party_screen\\Left_1.png";
		static string CharacterCreationRightArrow = "..\\..\\sprites\\party_screen\\Right_2.png";
		static string CharacterCreationRightArrowDimmed = "..\\..\\sprites\\party_screen\\Right_1.png";

		static Texture TCharacterDisplayBox;
		static Texture TCharacterAppearance; //Texture for showing appearance.
		//static Texture TGrayTextBox;
		static Texture TCharacterCreationLeftArrow;
		static Texture TCharacterCreationLeftArrowDimmed;
		static Texture TCharacterCreationRightArrow;
		static Texture TCharacterCreationRightArrowDimmed;


		//Do not touch/alter in any way shape or form.
		static Texture TCharacter1Display;
		static Texture TCharacter2Display;
		static Texture TCharacter3Display;
		static Texture TCharacter4Display;
		static Texture TCharacter5Display;
		static Texture TCharacter6Display;
		static Texture TCharacter7Display;
		static Texture TCharacter8Display;
		static Texture TTextBox;
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////       MONSTERS SPRITES      ///////////////////////////////////////////
        static string m1Front = "..\\..\\sprites\\PS_front.png";
        static string m1Front1 = "..\\..\\sprites\\PS_front2.png";
        static string m1Back = "..\\..\\sprites\\PS_back.png";
        static string m1Back1 = "..\\..\\sprites\\PS_back2.png";
        static string m1Right = "..\\..\\sprites\\PS_right.png";
        static string m1Right1 = "..\\..\\sprites\\PS_right2.png";
        static string m1Left = "..\\..\\sprites\\PS_left.png";
        static string m1Left1 = "..\\..\\sprites\\PS_left2.png";

        static string m2Front = "..\\..\\sprites\\TV_front.png";
        static string m2Front1 = "..\\..\\sprites\\TV_front2.png";
        static string m2Back = "..\\..\\sprites\\TV_back.png";
        static string m2Back1 = "..\\..\\sprites\\TV_back2.png";
        static string m2Right = "..\\..\\sprites\\TV_right.png";
        static string m2Right1 = "..\\..\\sprites\\TV_right2.png";
        static string m2Left = "..\\..\\sprites\\TV_left.png";
        static string m2Left1 = "..\\..\\sprites\\TV_left2.png";

        static string m3Front = "..\\..\\sprites\\BB_front.png";
        static string m3Front1 = "..\\..\\sprites\\BB_front2.png";
        static string m3Back = "..\\..\\sprites\\BB_back.png";
        static string m3Back1 = "..\\..\\sprites\\BB_back2.png";
        static string m3Right = "..\\..\\sprites\\BB_right.png";
        static string m3Right1 = "..\\..\\sprites\\BB_right2.png";
        static string m3Left = "..\\..\\sprites\\BB_left.png";
        static string m3Left1 = "..\\..\\sprites\\BB_left2.png";

        static string m4Front = "..\\..\\sprites\\C_front.png";
        static string m4Front1 = "..\\..\\sprites\\C_front2.png";
        static string m4Back = "..\\..\\sprites\\C_back.png";
        static string m4Back1 = "..\\..\\sprites\\C_back2.png";
        static string m4Right = "..\\..\\sprites\\C_right.png";
        static string m4Right1 = "..\\..\\sprites\\C_right2.png";
        static string m4Left = "..\\..\\sprites\\C_left.png";
        static string m4Left1 = "..\\..\\sprites\\C_left2.png";

        static string boss1 = "..\\..\\sprites\\Sub_boss_1.png";
        static string boss2 = "..\\..\\sprites\\Sub_boss_2.png";
        static string boss3 = "..\\..\\sprites\\FinalBoss.png";
        //static string boss4;
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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

        public static void renderBattleScreen(SlimDX.Color4 color, Device device9, Sprite sprite, int level, List<PlayerChar>party, Monsterchar monster)
        {
            /*
             * change the player's and monster position for the battle screen
             * save the previous screen
             * */
            //status = GameStatus.battleScreen;

            // move characters to appropriate location on battle screen.
            partyXlocation = 100;
            partyYlocation = 400;


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
                partyYlocation += 80;
                sprite.Transform = Matrix.Translation(character.xLocation, character.yLocation, 0);
                sprite.Draw(character.texture, color);
                sprite.Transform = Matrix.Translation(character.xLocation, character.yLocation - 20, 0);
                BattleTextDrawing.DrawString(sprite, "Health: " + character.health, 0, 0, color);
                //character.texture = character.right;
            }
            

            sprite.Transform = Matrix.Translation(monsterXlocation, monsterYlocation, 0);
            sprite.Draw(monster.left, color);

            //device9.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);


            sprite.Transform = Matrix.Translation(monsterXlocation, monsterYlocation - 20, 0);
            BattleTextDrawing.DrawString(sprite, "Health: " + monster.health, 0, 0, color);


        }

        public static void createBattleScreenTextures(Device device9)
        {
            //monsterT = createTexture(device9, monster);

            battlebgT = createTexture(device9, battlebg);
            battlebgT2 = createTexture(device9, battlebg2);
            battlebgT3 = createTexture(device9, battlebg3);
            battlebgT4 = createTexture(device9, battlebg4);
            device9.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);

            BattleTextDrawing = new SlimDX.Direct3D9.Font(device9, BattleScreenfont);

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


		public static void createCharacterScreenTextures(Device device9){

			TCharacterDisplayBox = createTexture(device9, CharacterDisplayBox);

			//static Texture TGrayTextBox;
			TCharacterCreationLeftArrow = createTexture(device9, CharacterCreationLeftArrow);
			TCharacterCreationLeftArrowDimmed = createTexture(device9, CharacterCreationLeftArrowDimmed);
			TCharacterCreationRightArrow = createTexture(device9, CharacterCreationRightArrow);
			TCharacterCreationRightArrowDimmed = createTexture(device9, CharacterCreationRightArrowDimmed);
			System.Drawing.Font font = new System.Drawing.Font (FontFamily.GenericSansSerif, 20);
			textDrawing = new SlimDX.Direct3D9.Font (device9,font);

			TCharacter1Display = createTexture(device9, Character1Big);
			TCharacter2Display = createTexture(device9, Character2Big);
			TCharacter3Display = createTexture(device9, Character3Big);
			TCharacter4Display = createTexture(device9, Character4Big);
			TCharacter5Display = createTexture(device9, Character5Big);
			TCharacter6Display = createTexture(device9, Character6Big);
			TCharacter7Display = createTexture(device9, Character7Big);
			TCharacter8Display = createTexture(device9, Character8Big);
			TTextBox = createTexture (device9, TextBox);

			TCharacterAppearance = TCharacter1Display;

		}

		public static void disposeCharacterScreenTextures(){
			TCharacterCreationLeftArrow.Dispose ();
			TCharacterCreationLeftArrowDimmed.Dispose ();
			TCharacterCreationRightArrow.Dispose ();
			TCharacterCreationRightArrowDimmed.Dispose ();

			TCharacter1Display.Dispose ();
			TCharacter2Display.Dispose ();
			TCharacter3Display.Dispose ();
			TCharacter4Display.Dispose ();
			TCharacter5Display.Dispose ();
			TCharacter6Display.Dispose ();
			TCharacter7Display.Dispose ();
			TCharacter8Display.Dispose ();
			TTextBox.Dispose ();
			textDrawing.Dispose ();
		}

		public static void renderCharacterCreationWindow(SlimDX.Color4 color, Device device9, Sprite sprite,
			int currentSelectedCharacterAppearence, int currentCharacterNumber, int pointsRemaining, PlayerChar currentCharacter)
        {
			device9.Clear (ClearFlags.Target, Color.Black, 1.0f, 0);


			sprite.Transform = Matrix.Translation(62, 10, 0);

			//Character Appearence stuff
			textDrawing.DrawString (sprite, "Appearance", 0, 0, color);

			sprite.Transform = Matrix.Scaling(.01f,.01f,0) + Matrix.Translation(10, 100, 0);
			sprite.Draw (TCharacterDisplayBox, color);

			// Current appearence

			sprite.Transform = Matrix.Scaling(.8f,.8f,0) + Matrix.Translation(150, 140, 0);
			sprite.Draw (currentCharacter.big, color);

			//Which Selected character appearence you are on
			sprite.Transform = Matrix.Translation(110, 200, 0);
			textDrawing.DrawString (sprite, currentSelectedCharacterAppearence + "/8", 0, 0, color);

			//Which Selected character  you are on
			sprite.Transform = Matrix.Scaling(2f,2f,0) + Matrix.Translation(720, 1280, 0);
			textDrawing.DrawString (sprite, "Character " + currentCharacterNumber + " of 4", 0, 0, color);


			///Visually change selected character
			if (currentSelectedCharacterAppearence > 1) {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (5, 450, 0);
				sprite.Draw (TCharacterCreationLeftArrow, color);
			} else {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (5, 450, 0);
				sprite.Draw (TCharacterCreationLeftArrowDimmed, color);
			}

			if (currentSelectedCharacterAppearence < 8) {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (200, 450, 0);
				sprite.Draw (TCharacterCreationRightArrow, color);
			} else {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (200, 450, 0);
				sprite.Draw (TCharacterCreationRightArrowDimmed, color);
			}

			////

			//Move between characters
			if (currentCharacterNumber > 1) {
				sprite.Transform = Matrix.Translation (-50, 600, 0);
				sprite.Draw (TCharacterCreationLeftArrow, color);
			} else {
				sprite.Transform = Matrix.Translation (-50, 600, 0);
				sprite.Draw (TCharacterCreationLeftArrowDimmed, color);
			}
				
				sprite.Transform = Matrix.Translation (800, 600, 0);
				sprite.Draw (TCharacterCreationRightArrow, color);

			//Draw name text and box
			/// 
			sprite.Transform = Matrix.Translation(400, 50, 0);
			textDrawing.DrawString (sprite, "Character Name:", 0, 0, color);

			sprite.Transform = Matrix.Scaling (3f, 3f, 0) + Matrix.Translation(1250, 70, 0);
			sprite.Draw (TTextBox, color);

			//draw name
			sprite.Transform = Matrix.Translation(650, 50, 0);
			textDrawing.DrawString (sprite, currentCharacter.name, 0, 0, color);


			//Draw remaining points:
			sprite.Transform = Matrix.Translation(500, 150, 0);
			textDrawing.DrawString (sprite, "Remaining Points:" + pointsRemaining, 0, 0, color);

			//Draw attributes:
			if(currentCharacter.characterClass.Equals("Warrior")){
				sprite.Transform = Matrix.Translation(500, 250, 0);
				textDrawing.DrawString (sprite, "Strength: " + (currentCharacter.strength+5), 0, 0, color);
			}
			else{
				sprite.Transform = Matrix.Translation(500, 250, 0);
				textDrawing.DrawString (sprite, "Strength: " + currentCharacter.strength, 0, 0, color);
			}

			sprite.Transform = Matrix.Translation(700, 250, 0);
			textDrawing.DrawString (sprite,"+    -", 0, 0, color);
				

			if (currentCharacter.characterClass.Equals ("Wizard")) {
				sprite.Transform = Matrix.Translation (500, 300, 0);
				textDrawing.DrawString (sprite, "Intelligence: " + (currentCharacter.intelligence+3), 0, 0, color);

				sprite.Transform = Matrix.Translation(500, 400, 0); 
				textDrawing.DrawString (sprite, "Wisdom: " + (currentCharacter.wisdom+3), 0, 0, color);

			} 
			else {
				sprite.Transform = Matrix.Translation (500, 300, 0);
				textDrawing.DrawString (sprite, "Intelligence: " + currentCharacter.intelligence, 0, 0, color);

				sprite.Transform = Matrix.Translation(500, 400, 0); 
				textDrawing.DrawString (sprite, "Wisdom: " + currentCharacter.wisdom, 0, 0, color);
			}

			sprite.Transform = Matrix.Translation(700, 300, 0);
			textDrawing.DrawString (sprite,"+    -", 0, 0, color);


			sprite.Transform = Matrix.Translation(700, 400, 0);
			textDrawing.DrawString (sprite,"+    -", 0, 0, color);


				
			if (currentCharacter.characterClass.Equals ("Rogue")) {
				sprite.Transform = Matrix.Translation (500, 350, 0);
				textDrawing.DrawString (sprite, "Agility : " + (currentCharacter.agility+5), 0, 0, color);
			} else {
				sprite.Transform = Matrix.Translation (500, 350, 0);
				textDrawing.DrawString (sprite, "Agility : " + currentCharacter.agility, 0, 0, color);
			}

			sprite.Transform = Matrix.Translation(700, 350, 0);
			textDrawing.DrawString (sprite,"+    -", 0, 0, color);

			//Draw character class
			sprite.Transform = Matrix.Scaling (3.6f, 3.5f, 0) + Matrix.Translation(80, 750, 0);
			sprite.Draw (TTextBox, color);

			sprite.Transform = Matrix.Translation(50, 395, 0);
			textDrawing.DrawString (sprite, "Current Class: " + currentCharacter.characterClass,0,0,color);

			if (currentCharacter.characterClass.Equals("Warrior")) {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (0, 900, 0);
				sprite.Draw (TCharacterCreationLeftArrowDimmed, color);
			} else {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (0, 900, 0);
				sprite.Draw (TCharacterCreationLeftArrow, color);
			}
			if (currentCharacter.characterClass.Equals("Wizard")) {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (420, 900, 0);
				sprite.Draw (TCharacterCreationRightArrowDimmed, color);
			} else {
				sprite.Transform = Matrix.Scaling (0.25f, 0.25f, 0) + Matrix.Translation (420, 900, 0);
				sprite.Draw (TCharacterCreationRightArrow, color);
			}




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

            battlebgT.Dispose();
            battlebgT2.Dispose();
            battlebgT3.Dispose();
            battlebgT4.Dispose();

            //monsterT.Dispose();

            BattleScreenfont.Dispose();
            BattleTextDrawing.Dispose();
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
            characters[0].texture = characters[0].right;

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
            characters[1].texture = characters[1].right;

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
            characters[2].texture = characters[2].right;

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
            characters[3].texture = characters[3].right;

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
            characters[4].texture = characters[4].right;

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
            characters[7].texture = characters[7].right;

            return characters;
		}

        public static List<Monsterchar> createMonsters(Device device9, List<Monsterchar> monsters)
        {
            monsters[0].front = createTexture(device9, m1Front);
            monsters[0].back = createTexture(device9, m1Back);
            monsters[0].left = createTexture(device9, m1Left);
            monsters[0].right = createTexture(device9, m1Right);
            monsters[0].front2 = createTexture(device9, m1Front1);
            monsters[0].back2 = createTexture(device9, m1Back1);
            monsters[0].left2 = createTexture(device9, m1Left1);
            monsters[0].right2 = createTexture(device9, m1Right1);
            monsters[0].texture = monsters[0].left;

            monsters[1].front = createTexture(device9, m2Front);
            monsters[1].back = createTexture(device9, m2Back);
            monsters[1].left = createTexture(device9, m2Left);
            monsters[1].right = createTexture(device9, m2Right);
            monsters[1].front2 = createTexture(device9, m2Front1);
            monsters[1].back2 = createTexture(device9, m2Back1);
            monsters[1].left2 = createTexture(device9, m2Left1);
            monsters[1].right2 = createTexture(device9, m2Right1);
            monsters[1].texture = monsters[1].left;

            monsters[2].front = createTexture(device9, m3Front);
            monsters[2].back = createTexture(device9, m3Back);
            monsters[2].left = createTexture(device9, m3Left);
            monsters[2].right = createTexture(device9, m3Right);
            monsters[2].front2 = createTexture(device9, m3Front1);
            monsters[2].back2 = createTexture(device9, m3Back1);
            monsters[2].left2 = createTexture(device9, m3Left1);
            monsters[2].right2 = createTexture(device9, m3Right1);
            monsters[2].texture = monsters[2].left;

            monsters[3].front = createTexture(device9, m4Front);
            monsters[3].back = createTexture(device9, m4Back);
            monsters[3].left = createTexture(device9, m4Left);
            monsters[3].right = createTexture(device9, m4Right);
            monsters[3].front2 = createTexture(device9, m4Front1);
            monsters[3].back2 = createTexture(device9, m4Back1);
            monsters[3].left2 = createTexture(device9, m4Left1);
            monsters[3].right2 = createTexture(device9, m4Right1);
            monsters[3].texture = monsters[0].left;
            return monsters;
        }

        public static List<Monsterchar> createBosses(Device device9, List<Monsterchar> bosses)
        {
            bosses[0].texture= createTexture(device9, boss1);
            bosses[1].texture = createTexture(device9, boss2);
            bosses[2].texture = createTexture(device9, boss3);

            return bosses;
        }

		public static List<PlayerChar> disposeCharacterTextures(List<PlayerChar> party){
			
            foreach (PlayerChar character in party)
            {
				//if (character.front == null) {
				//	return party;
				//}
                if (character.big != null) character.big.Dispose();
                if (character.front != null) character.front.Dispose();
                if (character.back != null) character.back.Dispose();
                if (character.left != null) character.left.Dispose();
                if (character.right != null) character.right.Dispose();
                if (character.front2 != null) character.front2.Dispose();
                if (character.back2 != null) character.back2.Dispose();
                if (character.left2 != null) character.left2.Dispose();
                if (character.right2 != null) character.right2.Dispose();
                if (character.att != null) character.att.Dispose();
                if (character.texture != null) character.texture.Dispose();
            }
            return party;
		}

        public static List<Monsterchar> disposeCharacterTextures(List<Monsterchar> party)
        {

            foreach (Monsterchar character in party)
            {
                //if (character.front == null) {
                //	return party;
                //}
                if (character.big != null) character.big.Dispose();
                if (character.front != null) character.front.Dispose();
                if (character.back != null) character.back.Dispose();
                if (character.left != null) character.left.Dispose();
                if (character.right != null) character.right.Dispose();
                if (character.front2 != null) character.front2.Dispose();
                if (character.back2 != null) character.back2.Dispose();
                if (character.left2 != null) character.left2.Dispose();
                if (character.right2 != null) character.right2.Dispose();
                if (character.att != null) character.att.Dispose();
                if (character.texture != null) character.texture.Dispose();
            }
            return party;
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

