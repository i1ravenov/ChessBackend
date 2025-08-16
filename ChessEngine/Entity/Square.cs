using ChessEngine.Entity.Pieces;

namespace ChessEngine.Entity
{
    public class Square
    {
        public int File { get; set; } // Note: 0 = a, 7 = h
        public int Rank { get; set; } // Note: 0 = 1, 7 = 8
        public Piece? OccupyingPiece { get; set; }
       
        public Square(int file, int rank)
        {
            File = file;
            Rank = rank;
            OccupyingPiece = null;
        }

        public Square(string pos)
        {
            if (pos.Length != 2)
            {
                throw new ArgumentException("Square pos must be 2 characters long, e.g. 'c3'");
            }
            File = pos[0] - 'a';
            Rank = pos[1] - 1;
        }

        public override string ToString()
        {
            return $"{Char.ConvertFromUtf32('a' + File)}{Rank + 1}";
        }
    }
}
