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
                    _board[j, i] = new Square(i, j);
                }
            }
        }

        public Board(string fendata) : this()
        {
            string[] lines = fendata.Split('/').Reverse().ToArray();
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
            Color color = Char.IsUpper(p) ? Color.White : Color.Black;
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
                        // TODO: add logger to the project
                        Console.WriteLine($"Checking threat on square {targetSquare.File},{targetSquare.Rank}");
                        Console.WriteLine($"Piece {piece.PieceType} at {file},{rank}");

                        int dx = targetSquare.File - file;
                        int dy = targetSquare.Rank - rank;

                        switch (piece)
                        {
                            case King:
                                return Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1;

                            case Queen:
                                return (dx == 0 || dy == 0 || Math.Abs(dx) == Math.Abs(dy)) &&
                                    Piece.CheckPath(_board[file, rank], targetSquare, this);

                            case Rook:
                                return (dx == 0 || dy == 0) &&
                                    Piece.CheckPath(_board[file, rank], targetSquare, this);

                            case Bishop:
                                return Math.Abs(dx) == Math.Abs(dy) &&
                                    Piece.CheckPath(_board[file, rank], targetSquare, this);

                            case Knight:
                                return (Math.Abs(dx) == 2 && Math.Abs(dy) == 1) || (Math.Abs(dx) == 1 && Math.Abs(dy) == 2);

                            case Pawn:
                                var dir = (piece.Color == Color.White) ? -1 : 1;
                                return dy == dir && Math.Abs(dx) == 1;
                        }
                    }
                }
            }
            throw new ArgumentException($"Unknown piece");
        }
        
        public void ApplyMove(Square from, Square to)
        {
            _board[to.Rank, to.File].OccupyingPiece = from.OccupyingPiece;
            _board[from.Rank, to.File].OccupyingPiece = null;
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
        
        public Square this[string pos]
        {
            get
            {
                Square square = new Square(pos);
                return _board[square.Rank, square.File];
            }
        }
    }
}
