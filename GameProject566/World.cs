using System;
using SlimDX.DirectInput;
using System.Drawing.Text;
using NUnit.Framework;
using System.Windows.Forms;
using SlimDX.XACT3;
using SlimDX.Direct3D9;

namespace GameProject566
{
	public class World
	{

		public Texture tile { get; set; }
		public Texture wall { get; set; }

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
			int Tiley = 60;


			for (int i = 0; i < initialRoomSize; i++) {

				for (int j = 0; j < initialRoomSize; j++) {
					tiles [i, j] = new Tile ();
					tiles [i, j].xGrid = i;
					tiles [i, j].yGrid = j;
					tiles [i, j].wObject = new WorldObject(); // create empty world object.
					tiles [i, j].texture = this.tile;
					tiles [i, j].xLocation = Tilex;
					tiles [i, j].yLocation = Tiley;
					Tiley += 60;

					if ((i == 0 || i == initialRoomSize - 1) || (j == 0 || j == initialRoomSize - 1)) 
					{
						tiles [i, j].wObject = wall;
						tiles [i, j].texture = null;
					}
				}
				Tiley = 60;
				Tilex += 60;
			}

			tiles [player.xGridLocation, player.yGridLocation].wObject = player;


			return tiles;
		}

		//Place the room onto the world grid.
		public Tile[,] PlaceRoomOnWorld(Tile[,] world, Tile[,] RoomToPlace, int startPosition){


			//Check if any of the slots are filled in that area.
			for (int i = 0; i < RoomToPlace.GetLength (0); i++) {

				for (int j = 0; j < RoomToPlace.GetLength (1); j++) {
				
					if (world [startPosition + i, startPosition + j].wObject != null) {
						return world;
					}
				}

			}
				
			//Place room.  Start at a same x,y coord location.  Then increment down the column and right accross the row filling up the room.
			for (int i = 0; i < RoomToPlace.GetLength (0); i++) {

				for (int j = 0; j < RoomToPlace.GetLength (1); j++) {

					RoomToPlace [i, j].xGrid = world [startPosition + i, startPosition + j].xGrid;
					RoomToPlace [i, j].yGrid = world [startPosition + i, startPosition + j].yGrid;

					if(RoomToPlace[i,j].wObject != null){
						RoomToPlace [i, j].wObject.xGridLocation = world [startPosition + i, startPosition + j].xGrid;
						RoomToPlace [i, j].wObject.yGridLocation = world [startPosition + i, startPosition + j].yGrid;
					}
					
					world [startPosition + i, startPosition + j] = RoomToPlace [i, j];




				}
					
			}

			return world;
		}


		/*//Horizontal connector
		public Tile[,] createHorizontalConnector ()
		{
			//Tile[,] connector = new Tile[1,2]();


			//return connector;
		}*/


	}
}

