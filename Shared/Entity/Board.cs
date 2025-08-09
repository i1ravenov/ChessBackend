using Shared.Entity.Pieces;
using Shared.Enums;

namespace Shared.Entity
{
    public class Board
    {
        public Square[,] _board;

        public Board()
        {
            _board = new Square[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _board[i, j] = new Square(i, j);
                }
            }
        }

        public Board(string fendata) : this()
        {
            string[] lines = fendata.Split('/');
            for (int i = 0; i < 8; i++)
            {
                string line = lines[i];
                for (int j = 0; j < 8;)
                {
                    if (Char.IsDigit(line[j]))
                    {
                        j += int.Parse(line[j].ToString());
                        continue;
                    }
                    _board[i, j].OccupyingPiece = ParsePiece(line[j]);
                } 
            }
        }

        private Piece ParsePiece(char p)
        {
            Color color;
            if (Char.IsUpper(p))
            {
                color = Color.White;
            }
            else
            {
                color = Color.Black;
            }
            p = Char.ToLower(p);
            switch (p)
            {
                case 'p': return new Pawn(color);
                case 'r': return new Rook(color);
                case 'b': return new Bishop(color);
                case 'n': return new Knight(color);
                case 'k': return new King(color);
                case 'q': return new Queen(color);
            }
            throw new Exception($"Unknown piece: {p}");
        }

        private Square GetSquare(int x, int y)
        {
            return _board[x, y];
        }

        public List<Square> GetSquaresOfColor(Color color) =>
            _board
                .Cast<Square>()
                .Where(square => square.OccupyingPiece?.Color == color)
                .ToList();

        public bool IsUnderAttack(Square endSquare, Color playerColor)
        {
            foreach (var square in _board)
            {
                if (square.OccupyingPiece != null && square.OccupyingPiece.Color != playerColor)
                {
                    if (square.OccupyingPiece.IsMoveValid(square, endSquare, this))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
