namespace Battleship.Engine
{
    public class ShipFactory
    {
        public Ship Create(int size)
        {
            var ship = new Ship(size);
            return ship;
        }
    }
}
