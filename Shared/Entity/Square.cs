using Shared.Entity.Pieces;

namespace Shared.Entity
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Piece? OccupyingPiece { get; set; }
       
        public Square(int x, int y)
        {
            X = x;
            Y = y;
            OccupyingPiece = null;
        }
    }
}
