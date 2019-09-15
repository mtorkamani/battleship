using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Battleship.Engine
{
    public class Game
    {
        private const int BattleGroundSize = 10;
        private BattleGround BattleGround { get; set; }
        private Collection<Ship> Ships { get; set; }
        private Action OnOver { get; set; }

        public void Setup()
        {
            BattleGround = new BattleGround(BattleGroundSize);
            Ships = new Collection<Ship>();
        }

        public void PlaceShip(Ship ship, int startRow, int startCol, Orientation orientation)
        {
            BattleGround.PlaceShip(ship, startRow, startCol, orientation);
            Ships.Add(ship);
        }

        public void Hit(int row, int col)
        {
            var coordinate = BattleGround.Locate(row, col);
            coordinate.Hit();
            if (OnOver != null && IsOver())
            {
                OnOver();
            }
        }

        public bool IsOver()
        {
            return Ships.All(s => s.IsSunk());
        }
    }
}
