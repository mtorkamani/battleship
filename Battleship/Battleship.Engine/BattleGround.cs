using System;

namespace Battleship.Engine
{
    public class BattleGround
    {
        private Coordinate[,] Coordinates { get; set; }

        public BattleGround(int size)
        {
            Coordinates = new Coordinate[size, size];
            Reset();
        }

        private void Reset()
        {
            for (int row = 0; row < Coordinates.GetLength(0); row++)
            {
                for (int col = 0; col < Coordinates.GetLength(1); col++)
                {
                    Coordinates[row, col] = new Coordinate(row, col);
                    Coordinates[row, col].Status = CoordinateStatus.Unknown;
                    Coordinates[row, col].Ship = null;
                }
            }
        }

        public void PlaceShip(Ship ship, int startRow, int startCol, Orientation orientation)
        {
            if (!IsFit(ship, startRow, startCol, orientation))
            {
                throw new ArgumentException("Ship does not fit with provided coordinate and orientation");
            }

            var coordinate = Coordinates[startRow, startCol];
            for (int i = 0; i < ship.Size; i++)
            {
                coordinate.Ship = ship;
                ship.CurrentCoordinates.Add(coordinate);
                coordinate = Neighbor(coordinate, orientation);
            }
        }

        public Coordinate Locate(int row, int col)
        {
            return Coordinates[row, col];
        }

        private bool IsFit(Ship ship, int row, int col, Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
            {
                return (col + ship.Size) <= Coordinates.GetLength(1);
            }
            return (row + ship.Size) <= Coordinates.GetLength(0);
        }

        private Coordinate Neighbor(Coordinate coordinate, Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
            {
                return Coordinates[coordinate.Row, coordinate.Col + 1];
            }
            return Coordinates[coordinate.Row + 1, coordinate.Col];
        }
    }
}
