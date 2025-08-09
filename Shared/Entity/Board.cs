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

        private Square GetCell(int x, int y)
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
