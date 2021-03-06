﻿using System;
using SlimDX.DirectInput;
using System.Drawing.Text;
using NUnit.Framework;
using System.Windows.Forms;
using SlimDX.XACT3;
using SlimDX.Direct3D9;
using System.Dynamic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SlimDX.Direct2D;

namespace GameProject566
{
	public class World
	{
		
		public Texture tile { get; set; }
		public Texture wall { get; set; }
		public Texture exit { get; set; } 
		public Texture shop {get; set;}
		public Queue<RoomExit> roomExit { get; set;}
		//world sections

		public Random rand { get; set; }

		const int initialRoomSize = 13;




		//Make the whole world.
		public Tile[,] makeWorld(int size)
		{
			Tile[,] tiles = new Tile[size,size];

			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
				}
			}

			roomExit = new Queue<RoomExit> ();

			return tiles;
		}


		//Create the starting room for the map.
		public Tile[,] makeStartingRoom(PlayerChar player)
		{
			Tile[,] tiles = new Tile [initialRoomSize, initialRoomSize];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;
			int Tilex = 60;
			int Tiley = 600;

			for (int i = 0; i < initialRoomSize; i++) {

				for (int j = 0; j < initialRoomSize; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xVisualLocation = Tilex;
					tiles [i, j].yVisualLocation = Tiley;
					Tiley -= 60;

					if ((i == 0 || i == initialRoomSize - 1) || (j == 0 || j == initialRoomSize - 1)) 
					{
						if ( i != initialRoomSize - 1 || (j != 6 && j != 7)) { // exit
							tiles [i, j].worldObject = wall;
							tiles [i, j].texture = null;
						}


					}
				}
				Tiley = 600;
				Tilex += 60;
			}

			//Hold onto room exit tiles
			RoomExit exit = new RoomExit (tiles [initialRoomSize - 1, 5], false);
			roomExit.Enqueue(exit);


			tiles [player.xGridLocation, player.yGridLocation].worldObject = player;

			return tiles;
		}

		//Place the room onto the world grid.
		public Tile[,] PlaceRoomOnWorld(Tile[,] world, Tile[,] RoomToPlace, int startPositionx, int startPositiony){

			//Place room.  Start at a same x,y coord location.  Then increment down the column and right accross the row filling up the room.
			for (int i = 0; i < RoomToPlace.GetLength (0); i++) {

				for (int j = 0; j < RoomToPlace.GetLength (1); j++) {

					RoomToPlace [i, j].xGrid = world [startPositionx + i, startPositiony + j].xGrid;
					RoomToPlace [i, j].yGrid = world [startPositionx + i, startPositiony + j].yGrid;

					if(RoomToPlace[i,j].worldObject != null){
						RoomToPlace [i, j].worldObject.moveOnGrid (world [startPositionx + i, startPositiony + j].xGrid, world [startPositionx + i, startPositiony + j].yGrid);
					}
					
					world [startPositionx + i, startPositiony + j] = RoomToPlace [i, j];
				}
					
			}
			//Shop debug mode
			/*
			WorldObject shop = new WorldObject();
			shop.isShop = true;
			shop.texture = this.shop;

			world [startPositionx + 3, startPositiony + 3].worldObject = shop;
			*/

			return world;
		}

		//4x4
		public Tile[,] makeHorizontalConnector(){
			Tile[,] tiles = new Tile [4, 4];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			int Tilex = 0;
			int Tiley = 0;


			for (int i = 0; i < 4; i++) {

				for (int j = 0; j < 4; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xVisualLocation = Tilex;
					tiles [i, j].yVisualLocation = Tiley;

					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 0;

					if (j == 0 || j ==  3) 
					{
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
				}

			}



			RoomExit exit = new RoomExit (tiles [3, 0], false);
			roomExit.Enqueue(exit);


			return tiles;
		}


		public Tile[,] connectRoom(Tile[,] world, Tile[,] roomToConnect, RoomExit exit, bool isHorizontal, bool UporDown){


			//Check if any of the slots are filled in that area.
			if (isHorizontal) {
				for (int i = 0; i < roomToConnect.GetLength (0); i++) {

					for (int j = 0; j < roomToConnect.GetLength (1); j++) {

						if (world [exit.tileA.xGrid + 1 + i, exit.tileA.yGrid + j - roomToConnect [i, j].exitlocationy].worldObject != null) {
							return world;
						}

					}
				}

				//Place room.  Start at a same x,y coord location.  Then increment down the column and right accross the row filling up the room.
				//must also alter x location and ylocation

				for (int i = 0; i < roomToConnect.GetLength (0); i++) {

					for (int j = 0; j < roomToConnect.GetLength (1); j++) {


						roomToConnect [i, j].xGrid = world [exit.tileA.xGrid + 1 + i, exit.tileA.yGrid + j - roomToConnect [i, j].exitlocationy].xGrid;
						roomToConnect [i, j].yGrid = world [exit.tileA.xGrid + 1 + i, exit.tileA.yGrid + j - roomToConnect [i, j].exitlocationy].yGrid;

						roomToConnect [i, j].xVisualLocation = world [exit.tileA.xGrid, exit.tileA.yGrid].xVisualLocation + (60 * i) + 60;
						roomToConnect [i, j].yVisualLocation = world [exit.tileA.xGrid, exit.tileA.yGrid].yVisualLocation - (60 * (j - roomToConnect [i, j].exitlocationy));

						if (roomToConnect [i, j].worldObject.health != 0) {
							roomToConnect [i, j].worldObject.xGridLocation = roomToConnect [i, j].xGrid;
							roomToConnect [i, j].worldObject.yGridLocation = roomToConnect [i, j].yGrid;
						}

						world [exit.tileA.xGrid + 1 + i, exit.tileA.yGrid + j - roomToConnect [i, j].exitlocationy] = roomToConnect [i, j];

					}

				}

			} 
			else { //Vertical connect adjust for x
				for (int i = 0; i < roomToConnect.GetLength (0); i++) {

					for (int j = 0; j < roomToConnect.GetLength (1); j++) {

						if (world [exit.tileA.xGrid + 1 + i + roomToConnect[i,j].exitlocationx, exit.tileA.yGrid + j].worldObject != null) {
						//	return world;
						}

					}
				}

				//Place room.  Start at a same x,y coord location.  Then increment down the column and right accross the row filling up the room.
				//must also alter x location and ylocation

				for (int i = 0; i < roomToConnect.GetLength (0); i++) {

					for (int j = 0; j < roomToConnect.GetLength (1); j++) {
						if (UporDown) {
							roomToConnect [i, j].xGrid = world [exit.tileA.xGrid + i - roomToConnect [i, j].exitlocationx, exit.tileA.yGrid + j + 1].xGrid;
							roomToConnect [i, j].yGrid = world [exit.tileA.xGrid + i - roomToConnect [i, j].exitlocationx, exit.tileA.yGrid + j + 1].yGrid;

							roomToConnect [i, j].xVisualLocation = world [exit.tileA.xGrid, exit.tileA.yGrid].xVisualLocation + (60 * (i - roomToConnect [i, j].exitlocationx));
							roomToConnect [i, j].yVisualLocation = world [exit.tileA.xGrid, exit.tileA.yGrid].yVisualLocation - (60 * j) - 60;
						} else {
							roomToConnect [i, j].xGrid = world [exit.tileA.xGrid + i - roomToConnect [i, j].exitlocationx, exit.tileA.yGrid - j - 1].xGrid;
							roomToConnect [i, j].yGrid = world [exit.tileA.xGrid + i - roomToConnect [i, j].exitlocationx, exit.tileA.yGrid - j - 1].yGrid;

							roomToConnect [i, j].xVisualLocation = world [exit.tileA.xGrid, exit.tileA.yGrid].xVisualLocation + (60 * (i - roomToConnect [i, j].exitlocationx));
							roomToConnect [i, j].yVisualLocation = world [exit.tileA.xGrid, exit.tileA.yGrid].yVisualLocation + (60 * j) + 60;
						}

						if (roomToConnect [i, j].worldObject.health != 0) {
							roomToConnect [i, j].worldObject.xGridLocation = roomToConnect [i, j].xGrid;
							roomToConnect [i, j].worldObject.yGridLocation = roomToConnect [i, j].yGrid;
						}

						if (UporDown) {
							world [exit.tileA.xGrid + i - roomToConnect [i, j].exitlocationx, exit.tileA.yGrid + j + 1] = roomToConnect [i, j];
						} else {
							world [exit.tileA.xGrid + i - roomToConnect [i, j].exitlocationx, exit.tileA.yGrid - j - 1] = roomToConnect [i, j];
						}
					}

				}

			}

			return world;
		}


		public Tile[,] makePlusSignRoom(List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){
			Tile[,] tiles = new Tile [8, 7];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			int Tilex = 0;
			int Tiley = 0;


			for (int i = 0; i < 8; i++) {

				for (int j = 0; j < 7; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xVisualLocation = Tilex;
					tiles [i, j].yVisualLocation = Tiley;

					tiles [i, j].exitlocationx = 2;
					tiles [i, j].exitlocationy = 1;
				

					if((i==3 && j== 2) || (i==3 && j==4)){ //vertical centerpiece
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

					if ((i == 2 || i == 3 || i == 4 || i ==5) && j == 3) { //horizontal centerpiece
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

					if (i == 0 && !(j==2 || j==3)) { //left wall opening
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}


					if (i == 7 && !(j==2 || j==3)) { //right wall opening
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

					if (j == 6 && !(i==3 || i==4)) { //top wall
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

					if (j == 0 && !(i==3 || i==4)) { //bottom wall
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
				}
			}

			int xplace;
			int yplace;
			int limiter = 0; // guarantee while loop doesn't go on forever

			int determineWhichObjectIsPlaced = rand.Next (0, 10);

			do {
				xplace = rand.Next (0, 7);
				yplace = rand.Next (0, 6);
				limiter++;
			} while(tiles [xplace, yplace].texture == null && limiter < 20 && tiles [xplace, yplace].worldObject.health != 0);

			if (determineWhichObjectIsPlaced > 3) {
				Monsterchar selectType = monsterTypes.ElementAt (rand.Next (0, monsterTypes.Count));
				Monsterchar newMonster = new Monsterchar ();
				newMonster.level = selectType.level;
				newMonster.strength = selectType.strength;
				newMonster.att = selectType.att;
				newMonster.texture = selectType.texture;
				newMonster.back = selectType.back;
				newMonster.back2 = selectType.back2;
				newMonster.big = selectType.big;
				newMonster.front = selectType.front;
				newMonster.front2 = selectType.front2;
				newMonster.left = selectType.left;
				newMonster.left2 = selectType.left2;
				newMonster.right = selectType.right;
				newMonster.right2 = selectType.right2;
				newMonster.xGridLocation = xplace;
				newMonster.yGridLocation = yplace;

				tiles [xplace, yplace].worldObject = newMonster;

				monstersOnMap.Add (newMonster);
			} else if (determineWhichObjectIsPlaced < 1) {
				//place shop
				WorldObject shop = new WorldObject();
				shop.isShop = true;
				shop.texture = this.shop;
				tiles [xplace, yplace].worldObject = shop;
			}


			//TopExit
			RoomExit exit = new RoomExit (tiles [3,6], true);
			roomExit.Enqueue(exit);

			//bottom exit
			exit = new RoomExit (tiles [2,0], true);
			roomExit.Enqueue(exit);


			//Right exit
			exit = new RoomExit (tiles [7, 1], false);
			roomExit.Enqueue(exit);

			return tiles;
		}

		/////////////////////////////////////////////////////////
		//Square room 
		public Tile[,] makeSquareRoom(List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){
			Tile[,] tiles = new Tile [8, 8];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			for (int i = 0; i < 8; i++) {

				for (int j = 0; j < 8; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 2; // Always square right below lower most exit.


					if ((i == 0 || i == 7) && !(j== 3 || j== 4)) {
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
					if (j == 0 || j == 7) {
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}


				}




			}
				
			int xplace;
			int yplace;
			int limiter = 0; // guarantee while loop doesn't go on forever

			int determineWhichObjectIsPlaced = rand.Next (0, 10);

			do {
				xplace = rand.Next (0, 7);
				yplace = rand.Next (0, 7);
				limiter++;
			} while(tiles [xplace, yplace].texture == null && limiter < 20 && tiles [xplace, yplace].worldObject.health != 0);

			if (determineWhichObjectIsPlaced > 3) {
				Monsterchar selectType = monsterTypes.ElementAt (rand.Next (0, monsterTypes.Count));
				Monsterchar newMonster = new Monsterchar ();
				newMonster.level = selectType.level;
				newMonster.strength = selectType.strength;
				newMonster.att = selectType.att;
				newMonster.texture = selectType.texture;
				newMonster.back = selectType.back;
				newMonster.back2 = selectType.back2;
				newMonster.big = selectType.big;
				newMonster.front = selectType.front;
				newMonster.front2 = selectType.front2;
				newMonster.left = selectType.left;
				newMonster.left2 = selectType.left2;
				newMonster.right = selectType.right;
				newMonster.right2 = selectType.right2;
				newMonster.xGridLocation = xplace;
				newMonster.yGridLocation = yplace;

				tiles [xplace, yplace].worldObject = newMonster;

				monstersOnMap.Add (newMonster);
			} else if (determineWhichObjectIsPlaced < 1) {
				// place shop
				WorldObject shop = new WorldObject();
				shop.isShop = true;
				shop.texture = this.shop;
				tiles [xplace, yplace].worldObject = shop;
			}

			RoomExit exit = new RoomExit (tiles [7,2], false);
			roomExit.Enqueue(exit);


			return tiles;
		}


		/////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////
		//middledivider room 
		public Tile[,] makeMiddleDividerRoom(List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){
			Tile[,] tiles = new Tile [7, 11];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			for (int i = 0; i < 7; i++) {

				for (int j = 0; j < 11; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 2; // Always square right below lower most exit.

					//outside walls with exits
					if (((i == 0 && !(j==3 || j==4) || (i == 6 && !(j==7 || j==8))) || (j == 0 || j == 10))){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

					//middle divider
					if ((i == 3) && !(j == 1 || j == 9)) {
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}


				}

			}

			int xplace;
			int yplace;
			int limiter = 0; // guarantee while loop doesn't go on forever

			int determineWhichObjectIsPlaced = rand.Next (0, 10);


			do {
				xplace = rand.Next (0, 5);
				yplace = rand.Next (0, 9);
				limiter++;
			} while(tiles [xplace, yplace].texture == null && limiter < 20 && tiles [xplace, yplace].worldObject.health != 0);

			if (determineWhichObjectIsPlaced != 1 || determineWhichObjectIsPlaced != 2) {
				Monsterchar selectType = monsterTypes.ElementAt (rand.Next (0, monsterTypes.Count));
				Monsterchar newMonster = new Monsterchar ();
				newMonster.level = selectType.level;
				newMonster.strength = selectType.strength;
				newMonster.att = selectType.att;
				newMonster.texture = selectType.texture;
				newMonster.back = selectType.back;
				newMonster.back2 = selectType.back2;
				newMonster.big = selectType.big;
				newMonster.front = selectType.front;
				newMonster.front2 = selectType.front2;
				newMonster.left = selectType.left;
				newMonster.left2 = selectType.left2;
				newMonster.right = selectType.right;
				newMonster.right2 = selectType.right2;
				newMonster.xGridLocation = xplace;
				newMonster.yGridLocation = yplace;

				tiles [xplace, yplace].worldObject = newMonster;

				monstersOnMap.Add (newMonster);
			}

			RoomExit exit = new RoomExit (tiles [6,6], false);
			roomExit.Enqueue(exit);


			return tiles;
		}


		/////////////////////////////////////////////////////////


		/////////////////////////////////////////////////////////
		//X room 
		public Tile[,] makeXRoom(List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){
			Tile[,] tiles = new Tile [9, 9];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			for (int i = 0; i < 9; i++) {

				for (int j = 0; j < 9; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 1; // Always square right below lower most exit.

					//outside walls with exits
					if (((i == 0 || i==8) && !(j==2 || j==3)) || (j == 0 || j == 8)){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

					//Top segment of x
					if(i==2 && (j==2 || j==6)){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
					if(i==3 && (j==3 || j==5)){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
					if(i==4 && j==4){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
					if(i==5 && (j==3 || j==5)){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
					if(i==6 && (j==2 || j==6)){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}


				}

			}


			int xplace;
			int yplace;
			int limiter = 0; // guarantee while loop doesn't go on forever

			int determineWhichObjectIsPlaced = rand.Next (0, 10);

			do {
				xplace = rand.Next (0, 8);
				yplace = rand.Next (0, 8);
				limiter++;
			} while(tiles [xplace, yplace].texture == null && limiter < 20 && tiles [xplace, yplace].worldObject.health != 0);

			if (determineWhichObjectIsPlaced > 3) {
				Monsterchar selectType = monsterTypes.ElementAt (rand.Next (0, monsterTypes.Count));
				Monsterchar newMonster = new Monsterchar ();
				newMonster.level = selectType.level;
				newMonster.strength = selectType.strength;
				newMonster.att = selectType.att;
				newMonster.texture = selectType.texture;
				newMonster.back = selectType.back;
				newMonster.back2 = selectType.back2;
				newMonster.big = selectType.big;
				newMonster.front = selectType.front;
				newMonster.front2 = selectType.front2;
				newMonster.left = selectType.left;
				newMonster.left2 = selectType.left2;
				newMonster.right = selectType.right;
				newMonster.right2 = selectType.right2;
				newMonster.xGridLocation = xplace;
				newMonster.yGridLocation = yplace;

				tiles [xplace, yplace].worldObject = newMonster;

				monstersOnMap.Add (newMonster);
			} else if (determineWhichObjectIsPlaced < 1){
				//place shop
				WorldObject shop = new WorldObject();
				shop.isShop = true;
				shop.texture = this.shop;
				tiles [xplace, yplace].worldObject = shop;
			}


			RoomExit exit = new RoomExit (tiles [8,1], false);
			roomExit.Enqueue(exit);


			return tiles;
		}


		/////////////////////////////////////////////////////////
		/// 

		/////////////////////////////////////////////////////////
		//DeadEnd room 
		public Tile[,] makeHorizontalDeadEndRoom(){
			Tile[,] tiles = new Tile [8, 8];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			for (int i = 0; i < 8; i++) {

				for (int j = 0; j < 8; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 1; // Always square right below lower most exit.

					//outside walls with exits
					if (((i == 0 && !(j==2 || j==3)) || i== 7)  || (j == 0 || j == 7)){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

				}

			}

			RoomExit exit = new RoomExit (tiles [4,3], false);
			roomExit.Enqueue(exit);


			return tiles;
		}


		/////////////////////////////////////////////////////////
		/// Block room
		public Tile[,] makeBlockRoom(List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){
			Tile[,] tiles = new Tile [8, 8];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			for (int i = 0; i < 8; i++) {

				for (int j = 0; j < 8; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 2; // Always square right below lower most exit.

					//outside walls with exits
					if (((i == 0 && !(j==3 || j==4) || (i == 7 && !(j==3 || j==4))) || (j == 0 || j == 7))){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

					if ((i == 3 || i == 4) && (j==3 || j==4)) {
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}

				}

			}


			int xplace;
			int yplace;
			int limiter = 0; // guarantee while loop doesn't go on forever

			int determineWhichObjectIsPlaced = rand.Next (0, 10);

			do {
				xplace = rand.Next (0, 7);
				yplace = rand.Next (0, 7);
				limiter++;
			} while(tiles [xplace, yplace].texture == null && limiter < 20 && tiles [xplace, yplace].worldObject.health != 0);

			if (determineWhichObjectIsPlaced > 3) {
				Monsterchar selectType = monsterTypes.ElementAt (rand.Next (0, monsterTypes.Count));
				Monsterchar newMonster = new Monsterchar ();
				newMonster.level = selectType.level;
				newMonster.strength = selectType.strength;
				newMonster.att = selectType.att;
				newMonster.texture = selectType.texture;
				newMonster.back = selectType.back;
				newMonster.back2 = selectType.back2;
				newMonster.big = selectType.big;
				newMonster.front = selectType.front;
				newMonster.front2 = selectType.front2;
				newMonster.left = selectType.left;
				newMonster.left2 = selectType.left2;
				newMonster.right = selectType.right;
				newMonster.right2 = selectType.right2;
				newMonster.xGridLocation = xplace;
				newMonster.yGridLocation = yplace;

				tiles [xplace, yplace].worldObject = newMonster;

				monstersOnMap.Add (newMonster);
			} else if (determineWhichObjectIsPlaced < 1) {
				//place shop
				WorldObject shop = new WorldObject();
				shop.isShop = true;
				shop.texture = this.shop;
				tiles [xplace, yplace].worldObject = shop;
			}

			RoomExit exit = new RoomExit (tiles [7,2], false);
			roomExit.Enqueue(exit);


			return tiles;
		}


		/////////////////////////////////////////////////////////
		/// 
	

		//create the level
		public Tile[,] generateLevel(Tile[,] worldTiles,World world ,int roomCount, 
			List<Monsterchar> monsterTypes, List<Monsterchar> bosses, ref List<Monsterchar> monstersOnMap, int level){

			for (int i = 0; i < roomCount; i++) {

				Tile[,] horizontalconnector = makeHorizontalConnector ();

				worldTiles= connectRoom (worldTiles, horizontalconnector, world.roomExit.Dequeue(), true, false);


				if (i == roomCount - 1) {
					Tile[,] endRoom = makeHorizontalEndofLevel (bosses, level);
					worldTiles = connectRoom(worldTiles, endRoom, world.roomExit.Dequeue(), true, false);
					break;
				}


				switch (rand.Next(0,5)) {

				case 0: 
					Tile[,] plusRoom = makePlusSignRoom (monsterTypes, ref monstersOnMap);
					worldTiles = connectRoom (worldTiles, plusRoom, world.roomExit.Dequeue (), true, false);

					//Connect top segment
					Tile[,] VerticalDeadEnd = makeVerticalDeadEndWithExitDown ();
					worldTiles = connectRoom (worldTiles, VerticalDeadEnd, world.roomExit.Dequeue (), false, true);

					//Generate randomly downwards.
					worldTiles = generateDownwards (worldTiles, world, monsterTypes, ref monstersOnMap);
					break;

				case 1: 
					Tile[,] squareRoom = makeSquareRoom (monsterTypes, ref monstersOnMap);
					worldTiles= connectRoom (worldTiles, squareRoom, world.roomExit.Dequeue(), true, false);
					break;
				
				case 2: 
					Tile[,] middleDividerRoom = makeMiddleDividerRoom (monsterTypes, ref monstersOnMap);
					worldTiles= connectRoom (worldTiles, middleDividerRoom, world.roomExit.Dequeue(), true, false);
					break;

				case 3: 
					Tile[,] xRoom = makeXRoom (monsterTypes, ref monstersOnMap);
					worldTiles= connectRoom (worldTiles, xRoom, world.roomExit.Dequeue(), true , false);
					break;

				case 4: 
					Tile[,] blockRoom = makeBlockRoom (monsterTypes, ref monstersOnMap);
					worldTiles= connectRoom (worldTiles, blockRoom, world.roomExit.Dequeue(), true, false);
					break;

				default:
					break;
				}
			}

			return worldTiles;
		}


		public Tile[,] makeHorizontalEndofLevel(List<Monsterchar> listOfBosses, int whatLevelAreWeOn){

			Tile[,] tiles = new Tile [10, 10];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			for (int i = 0; i < 10; i++) {

				for (int j = 0; j < 10; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 3; // Always square right below lower most exit.

					//outside walls with exits
					if (((i == 0 && !(j==4 || j==5)) || (j == 0 || j == 9) || i == 9)){
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
						
				}

			}

			//place bosses and exit

			tiles[7,5].worldObject = listOfBosses.ElementAt (whatLevelAreWeOn - 1);
			tiles [7, 5].worldObject.isBoss = true;
				
			WorldObject levelExit = new WorldObject ();
			levelExit.isExit = true;
			levelExit.texture = exit;

			tiles [8, 5].worldObject = levelExit;
			//Block player entering from side.
			tiles [8, 4].worldObject = wall;
			tiles [8, 6].worldObject = wall;

			return tiles;
		}


		/*************************************************
		 *
		 *
		 * VERTICAL STUFF BELOW
		 * 
		 *
		 *************************************************/


		//4x4 connector going down.
		public Tile[,] makeVerticalConnector(){
			Tile[,] tiles = new Tile [4, 4];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			int Tilex = 0;
			int Tiley = 0;


			for (int i = 0; i < 4; i++) {

				for (int j = 0; j < 4; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xVisualLocation = Tilex;
					tiles [i, j].yVisualLocation = Tiley;

					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 0;

					if (i == 0 || i ==  3) 
					{
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
				}

			}

		

			RoomExit exit = new RoomExit (tiles [0, 3], false);
			roomExit.Enqueue (exit);					

			return tiles;
		}


		public Tile[,] makeVerticalDeadEndWithExitDown(){
			Tile[,] tiles = new Tile [4, 4];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			int Tilex = 0;
			int Tiley = 0;


			for (int i = 0; i < 4; i++) {

				for (int j = 0; j < 4; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xVisualLocation = Tilex;
					tiles [i, j].yVisualLocation = Tiley;

					tiles [i, j].exitlocationx = 1;
					tiles [i, j].exitlocationy = 0;

					if ((i == 0 || i ==  3) || (j==3)) 
					{
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
				}

			}
				
			return tiles;
		}

		public Tile[,] makeVerticalDeadEndWithExitUp(List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){
			Tile[,] tiles = new Tile [4, 4];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			int Tilex = 0;
			int Tiley = 0;


			for (int i = 0; i < 4; i++) {

				for (int j = 0; j < 4; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xVisualLocation = Tilex;
					tiles [i, j].yVisualLocation = Tiley;

					tiles [i, j].exitlocationx = 0;
					tiles [i, j].exitlocationy = 0;

					if ((i == 0 || i ==  3) || (j==3)) 
					{
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
				}

			}


			int xplace;
			int yplace;
			int limiter = 0; // guarantee while loop doesn't go on forever

			do {
				xplace = rand.Next (0, 4);
				yplace = rand.Next (0, 4);
				limiter++;
			} while(tiles [xplace, yplace].texture == null && limiter < 20 && tiles [xplace, yplace].worldObject.health != 0);

			Monsterchar selectType = monsterTypes.ElementAt(rand.Next (0, monsterTypes.Count));
			Monsterchar newMonster = new Monsterchar ();
			newMonster.level = selectType.level;
			newMonster.strength = selectType.strength;
			newMonster.att = selectType.att;
			newMonster.texture = selectType.texture;
			newMonster.back = selectType.back;
			newMonster.back2 = selectType.back2;
			newMonster.big = selectType.big;
			newMonster.front = selectType.front;
			newMonster.front2 = selectType.front2;
			newMonster.left = selectType.left;
			newMonster.left2 = selectType.left2;
			newMonster.right = selectType.right;
			newMonster.right2 = selectType.right2;
			newMonster.xGridLocation = xplace;
			newMonster.yGridLocation = yplace;

			tiles [xplace, yplace].worldObject = newMonster;

			monstersOnMap.Add (newMonster);


			return tiles;
		}

		public Tile[,] makeVerticalSquareroom(List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){
			Tile[,] tiles = new Tile [8, 8];
			WorldObject wall = new WorldObject ();
			wall.health = -1;
			wall.texture = this.wall;

			int Tilex = 0;
			int Tiley = 0;


			for (int i = 0; i < 8; i++) {

				for (int j = 0; j < 8; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].worldObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xVisualLocation = Tilex;
					tiles [i, j].yVisualLocation = Tiley;

					tiles [i, j].exitlocationx = 2;
					tiles [i, j].exitlocationy = 0;

					if ((i == 0 || i ==  7) || ((j==0 && !(i==3 || i==4))) || ((j==7 && !(i==3 || i==4))))
					{
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
				}

			}

			int xplace;
			int yplace;
			int limiter = 0; // guarantee while loop doesn't go on forever
			int determineWhichObjectIsPlaced = rand.Next (0, 10);

			do {
				xplace = rand.Next (0, 8);
				yplace = rand.Next (0, 8);
				limiter++;
			} while(tiles [xplace, yplace].texture == null && limiter < 20 && tiles [xplace, yplace].worldObject.health != 0);

			if (determineWhichObjectIsPlaced > 3) {
				Monsterchar selectType = monsterTypes.ElementAt (rand.Next (0, monsterTypes.Count));
				Monsterchar newMonster = new Monsterchar ();
				newMonster.level = selectType.level;
				newMonster.strength = selectType.strength;
				newMonster.att = selectType.att;
				newMonster.texture = selectType.texture;
				newMonster.back = selectType.back;
				newMonster.back2 = selectType.back2;
				newMonster.big = selectType.big;
				newMonster.front = selectType.front;
				newMonster.front2 = selectType.front2;
				newMonster.left = selectType.left;
				newMonster.left2 = selectType.left2;
				newMonster.right = selectType.right;
				newMonster.right2 = selectType.right2;
				newMonster.xGridLocation = xplace;
				newMonster.yGridLocation = yplace;

				tiles [xplace, yplace].worldObject = newMonster;

				monstersOnMap.Add (newMonster);
			} else if (determineWhichObjectIsPlaced < 1) {
				//place shop
				WorldObject shop = new WorldObject();
				shop.isShop = true;
				shop.texture = this.shop;
				tiles [xplace, yplace].worldObject = shop;
			}

			//enqueue
			RoomExit exit = new RoomExit (tiles [2,7], true);
			roomExit.Enqueue(exit);
			return tiles;
		}


		//create the level
		public Tile[,] generateDownwards(Tile[,] worldTiles,World world,List<Monsterchar> monsterTypes, ref List<Monsterchar> monstersOnMap){

			int verticalRoomCount = rand.Next (1, 5);

			Tile[,] verticalConnector = makeVerticalConnector ();


			worldTiles = connectRoom (worldTiles, verticalConnector, world.roomExit.Dequeue (), false, false);

			RoomExit tempexit = world.roomExit.Dequeue ();

			for (int i = 0; i < verticalRoomCount; i++) {

				if (i == verticalRoomCount - 1) {

					Tile[,] verticalDeadEnd = makeVerticalDeadEndWithExitUp (monsterTypes, ref monstersOnMap);
					worldTiles = connectRoom (worldTiles, verticalDeadEnd, world.roomExit.Dequeue (), false, false);
					break;
				}

				switch (rand.Next(0,2)) {

				case 1: 
					Tile[,] verticalSquare = makeVerticalSquareroom (monsterTypes, ref monstersOnMap);
					worldTiles = connectRoom (worldTiles, verticalSquare, world.roomExit.Dequeue (), false, false);
					break;

				default:
					break;
				}

				verticalConnector = makeVerticalConnector ();

				worldTiles = connectRoom (worldTiles, verticalConnector, world.roomExit.Dequeue (), false, false);

			}

			world.roomExit.Enqueue (tempexit);

			return worldTiles;
		}



	}

}

