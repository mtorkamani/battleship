using System.Collections.Generic;
using System.Linq;

namespace Battleship.Engine
{
    public class Ship
    {
        public int Size { get; set; }
        public List<Coordinate> CurrentCoordinates { get; set; }

        public Ship(int size)
        {
            Size = size;
            CurrentCoordinates = new List<Coordinate>();
        }

        public bool IsSunk()
        {
            return CurrentCoordinates.All(c => c.Status == CoordinateStatus.Hit);
        }
    }
}
