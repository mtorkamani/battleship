namespace Battleship.Engine
{
    public class Coordinate
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public CoordinateStatus Status { get; set; }
        public Ship Ship { get; set; }

        public Coordinate(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void Hit()
        {
            if (Ship != null)
            {
                Status = CoordinateStatus.Hit;
            }
            else
            {
                Status = CoordinateStatus.Missed;
            }
        }
    }
}
