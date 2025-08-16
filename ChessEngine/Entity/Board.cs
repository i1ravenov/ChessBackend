using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;

namespace ChessEngine.Entity
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
                    j++;
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
        
        public string ToFen()
        {
            var fenRows = new List<string>();

            for (int i = 0; i < 8; i++) // Ranks
            {
                int emptyCount = 0;
                string row = "";
                for (int j = 0; j < 8; j++) // Files
                {
                    var piece = _board[i, j].OccupyingPiece;

                    if (piece == null)
                    {
                        emptyCount++;
                    }
                    else
                    {
                        if (emptyCount > 0)
                        {
                            row += emptyCount.ToString();
                            emptyCount = 0;
                        }

                        char symbol = piece switch
                        {
                            Pawn => 'p',
                            Rook => 'r',
                            Knight => 'n',
                            Bishop => 'b',
                            Queen => 'q',
                            King => 'k',
                            _ => throw new Exception("Unknown piece type")
                        };

                        if (piece.Color == Color.White)
                            symbol = Char.ToUpper(symbol);

                        row += symbol;
                    }
                }

                if (emptyCount > 0)
                    row += emptyCount.ToString();

                fenRows.Add(row);
            }

            return string.Join("/", fenRows);
        }
    }
}
