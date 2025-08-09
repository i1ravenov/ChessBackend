using Shared.Enums;

namespace Shared.Entity.Pieces
{

    internal class Pawn : Piece
    {
        public Pawn(Color color) : base(color, PieceType.Pawn) { }

          
        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {

            if (!CheckBounds(endSquare))        
                return false;
            


            int moveX  = Math.Abs(startSquare.X - endSquare.X);
            int moveY = Math.Abs(startSquare.Y - endSquare.Y);

            if (this.color == Color.White)
            {
                //regular move
                if (startSquare.X == endSquare.X && moveY == 1 && !endSquare.IsOccupied)
                {
                    return true;
                }

                //if first move and pawn moves 2 steps
                if (startSquare.X == endSquare.X && moveY == 2 && startSquare.Y == 1 
                    && !endSquare.IsOccupied && !board._board[endSquare.X, endSquare.Y - 1].IsOccupied)
                {
                    return true;
                }
            }

            //same logic for black one
            else if (this.color == Color.Black)
            {
                if (startSquare.X == endSquare.X && moveY == 1 && !endSquare.IsOccupied)
                {
                    return true;
                }

                if (startSquare.X == endSquare.X && moveY == 2 && startSquare.Y == 6 
                    && !endSquare.IsOccupied && !board._board[endSquare.X, endSquare.Y + 1].IsOccupied)
                {
                    return true;
                }              
            }

            //Is attacking 
            if (moveX == 1 && moveY == 1 && endSquare.IsOccupied && endSquare.OccupyingPiece.color != this.color)
            {
                return true;
            }


            //todo en Passant

            return false;
        }
    }
}
