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


        public bool IsUnderAttack(Square targetSquare, Color color)
        {

            for (int file = 0; file < 8; file++)
            {
                for (int rank = 0; rank < 8; rank++)
                {
                    var piece = _board[file, rank].OccupyingPiece;

                    if (piece != null && piece.Color != color)
                    {
                        Console.WriteLine($"Checking threat on square {targetSquare.File},{targetSquare.Rank}");
                        Console.WriteLine($"Piece {piece.PieceType} at {file},{rank}");

                        int dx = targetSquare.File - file;
                        int dy = targetSquare.Rank - rank;

                        switch (piece)
                        {
                            case King:
                                if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1)
                                    return true;
                                break;

                            case Queen:
                                if ((dx == 0 || dy == 0 || Math.Abs(dx) == Math.Abs(dy)) &&
                                    Piece.CheckPath(_board[file, rank], targetSquare, this))
                                    return true;
                                break;

                            case Rook:
                                if ((dx == 0 || dy == 0) &&
                                    Piece.CheckPath(_board[file, rank], targetSquare, this))
                                    return true;
                                break;

                            case Bishop:
                                if (Math.Abs(dx) == Math.Abs(dy) &&
                                    Piece.CheckPath(_board[file, rank], targetSquare, this))
                                    return true;
                                break;

                            case Knight:
                                if ((Math.Abs(dx) == 2 && Math.Abs(dy) == 1) || (Math.Abs(dx) == 1 && Math.Abs(dy) == 2))
                                    return true;
                                break;

                            case Pawn:
                                int dir = (piece.Color == Color.White) ? -1 : 1;
                                if (dy == dir && Math.Abs(dx) == 1)
                                    return true;
                                break;
                        }
                    }
                }
            }
            return false;
        }


    }
}
