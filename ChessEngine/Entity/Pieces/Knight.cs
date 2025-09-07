using ChessEngine.Enums;

namespace ChessEngine.Entity.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(color, Enums.PieceType.Knight)
        {
        }

        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {

            if (!CheckBounds(endSquare)) return false;

            int moveX = Math.Abs(startSquare.File - endSquare.File);
            int moveY = Math.Abs(startSquare.Rank - endSquare.Rank);

           
            if ((moveX == 2 && moveY == 1) || (moveX == 1 && moveY == 2))
            {
                
                if (CanAttack(endSquare) || endSquare.OccupyingPiece == null)
                {
                    return true;
                }
            }

            return false; 
        }

     public override Piece Clone() => new Knight(this.Color);
    }
 }

