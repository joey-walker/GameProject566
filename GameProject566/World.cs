using System;
using SlimDX.DirectInput;
using System.Drawing.Text;
using NUnit.Framework;
using System.Windows.Forms;
using SlimDX.XACT3;
using SlimDX.Direct3D9;
using System.Dynamic;
using System.Collections.Generic;
using System.ComponentModel;

namespace GameProject566
{
	public class World
	{

		public Texture tile { get; set; }
		public Texture wall { get; set; }
		public Queue<RoomExit> roomExit { get; set;}
		//world sections

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
			RoomExit exit = new RoomExit (tiles [initialRoomSize - 1, 6], false, 1);
			roomExit.Enqueue(exit);


			tiles [player.xGridLocation, player.yGridLocation].worldObject = player;

			return tiles;
		}

		//Place the room onto the world grid.
		public Tile[,] PlaceRoomOnWorld(Tile[,] world, Tile[,] RoomToPlace, int startPosition){



			//Place room.  Start at a same x,y coord location.  Then increment down the column and right accross the row filling up the room.
			for (int i = 0; i < RoomToPlace.GetLength (0); i++) {

				for (int j = 0; j < RoomToPlace.GetLength (1); j++) {

					RoomToPlace [i, j].xGrid = world [startPosition + i, startPosition + j].xGrid;
					RoomToPlace [i, j].yGrid = world [startPosition + i, startPosition + j].yGrid;

					if(RoomToPlace[i,j].worldObject != null){
						RoomToPlace [i, j].worldObject.moveOnGrid (world [startPosition + i, startPosition + j].xGrid, world [startPosition + i, startPosition + j].yGrid);
					}
					
					world [startPosition + i, startPosition + j] = RoomToPlace [i, j];
				}
					
			}



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


					if (j == 0 || j ==  3) 
					{
						tiles [i, j].worldObject = wall;
						tiles [i, j].texture = null;
					}
				}

			}



			RoomExit exit = new RoomExit (tiles [3, 3], false, 4);
			roomExit.Enqueue(exit);


			return tiles;
		}


		public Tile[,] connectRoom(Tile[,] world, Tile[,] roomToConnect, RoomExit exit){


			//Check if any of the slots are filled in that area.
			for (int i = 0; i < roomToConnect.GetLength (0); i++) {

				for (int j = 0; j < roomToConnect.GetLength (1); j++) {

					if (world [exit.tileA.xGrid+ 1 + i, exit.tileA.yGrid + j - exit.ConnectorStart].worldObject != null) {
						return world;
					}
					if (roomToConnect [i, j].entranceOffset != 0) {
						exit.ConnectorStart = roomToConnect [i, j].entranceOffset;
					}

				}
			}



			//Place room.  Start at a same x,y coord location.  Then increment down the column and right accross the row filling up the room.
			//must also alter x location and ylocation
			for (int i = 0; i < roomToConnect.GetLength(0); i++) {

				for (int j = 0; j < roomToConnect.GetLength(1); j++) {

					roomToConnect [i, j].xGrid = world[exit.tileA.xGrid+ 1 + i, exit.tileA.yGrid + j - exit.ConnectorStart].xGrid;
					roomToConnect [i, j].yGrid = world[exit.tileA.xGrid+ 1 + i, exit.tileA.yGrid + j - exit.ConnectorStart].yGrid;

					roomToConnect [i, j].xVisualLocation = world[exit.tileA.xGrid, exit.tileA.yGrid].xVisualLocation+(60*i)+60;
					roomToConnect [i, j].yVisualLocation = world[exit.tileA.xGrid, exit.tileA.yGrid].yVisualLocation-(60*j)+(60*(exit.ConnectorStart));

					if(roomToConnect[i,j].worldObject.texture != null){
					/*	roomToConnect [i, j].wObject.moveOnGrid (world[a.tileA.xGrid+ 1 + i, a.tileA.yGrid + j - a.ConnectorStart].xGrid,
							world[a.tileA.xGrid+ 1 + i, a.tileA.yGrid + j - a.ConnectorStart].yGrid);

						roomToConnect [i, j].wObject.moveVisually (world[a.tileA.xGrid+ 1 + i, a.tileA.yGrid + j - a.ConnectorStart].xLocation+60,
							world[a.tileA.xGrid+ 1 + i, a.tileA.yGrid + j - a.ConnectorStart].yLocation-60);*/
					}

					world[exit.tileA.xGrid+ 1 + i, exit.tileA.yGrid + j - exit.ConnectorStart]= roomToConnect [i, j];

				}

			}


			return world;
		}


		public Tile[,] makePlusSignRoom(){
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


			RoomExit exit = new RoomExit (tiles [7, 2], false, 1);
			roomExit.Enqueue(exit);


			return tiles;
		}

		public Tile[,] makeSquareRoom(){
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

					tiles [i, j].entranceOffset = 5;
					//Tiley -= 60;

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


			RoomExit exit = new RoomExit (tiles [1,3], false, 2);
			roomExit.Enqueue(exit);


			return tiles;
		}

	}
}

