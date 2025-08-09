using Shared.Enums;

namespace Shared.Entity.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Color color) : base(color, PieceType.Knight)
        {
        }

     

        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {

            if (!CheckBounds(endSquare)) return false;

            int moveX = Math.Abs(startSquare.X - endSquare.X);
            int moveY = Math.Abs(startSquare.Y - endSquare.Y);

           
            if ((moveX == 2 && moveY == 1) || (moveX == 1 && moveY == 2))
            {
                
                if (CanAttack(endSquare) || !endSquare.IsOccupied)
                {
                    return true;
                }
            }

            return false; 
        }

    }
 }

