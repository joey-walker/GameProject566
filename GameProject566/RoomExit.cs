using System;

namespace GameProject566
{
	public class RoomExit
	{
		public Tile tileA { get ; set; }
		//attaching to an exit that is vertical.
		public bool isVertical { get; set; }
		//The start position to start placing tiles.
		public int ConnectorStart { get ; set; }


		public RoomExit (Tile a, bool isVertical, int ConnectorStart){
			this.tileA = a;
			this.isVertical = isVertical;
			this.ConnectorStart = ConnectorStart;
		}

	}
}

