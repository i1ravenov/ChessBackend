using Shared.Enums;

namespace Shared.Entity.Pieces
{
    internal class King : Piece
    {
        public King(Color color) : base(color, PieceType.King)
        {
        }
        
        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {
            if(!CheckBounds(endSquare))
                return false;

            int moveX = Math.Abs(startSquare.X - endSquare.X);
            int moveY = Math.Abs(startSquare.Y- endSquare.Y);

            if (moveX <= 1 && moveY <= 1)
            {
                if (board.IsUnderAttack(endSquare , Color))
                {
                    return false;
                }

                if (endSquare.OccupyingPiece != null && endSquare.OccupyingPiece.Color == this.Color)
                {
                    return false;
                }

                ////can attack
                //else if (endCell.IsOccupied && endCell.OccupyingPiece.color != this.color)
                //{
                //    return true;
                //}

                return true;
            }
            
            return false;
        }
    }
}
