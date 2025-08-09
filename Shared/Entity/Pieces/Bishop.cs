using Shared.Enums;

namespace Shared.Entity.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color) : base(color, PieceType.Bishop)
        {
        }

        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {
            
                if (!CheckBounds(endSquare)) return false;

                int moveX = Math.Abs(startSquare.X - endSquare.X);
                int moveY = Math.Abs(startSquare.Y - endSquare.Y);

                if (moveX == moveY)
                {
                    if (CheckPath(startSquare, endSquare, board))
                    {
                        if (CanAttack(endSquare) || !endSquare.IsOccupied)
                        {
                            return true;
                        }
                    }
                }

                return false;
            

        }
    }
}
