using ChessEngine.Enums;

namespace ChessEngine.Entity.Pieces
{

    internal class Pawn : Piece
    {
        public Pawn(Color color) : base(color, Enums.PieceType.Pawn) { }

          
        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {

            if (!CheckBounds(endSquare))        
                return false;
            


            int moveX  = Math.Abs(startSquare.File - endSquare.File);
            int moveY = Math.Abs(startSquare.Rank - endSquare.Rank);

            if (this.Color == Enums.Color.White)
            {
                //regular move
                if (startSquare.File == endSquare.File && moveY == 1 && endSquare.OccupyingPiece == null)
                {
                    return true;
                }

                //if first move and pawn moves 2 steps
                if (startSquare.File == endSquare.File && moveY == 2 && startSquare.Rank == 1 
                    && endSquare.OccupyingPiece == null && board._board[endSquare.File, endSquare.Rank - 1].OccupyingPiece == null)
                {
                    return true;
                }
            }

            //same logic for black one
            else if (this.Color == Enums.Color.Black)
            {
                if (startSquare.File == endSquare.File && moveY == 1 && endSquare.OccupyingPiece == null)
                {
                    return true;
                }

                if (startSquare.File == endSquare.File && moveY == 2 && startSquare.Rank == 6 
                    && endSquare.OccupyingPiece == null && board._board[endSquare.File, endSquare.Rank + 1].OccupyingPiece == null)
                {
                    return true;
                }              
            }

            //Is attacking 
            if (moveX == 1 && moveY == 1 && endSquare.OccupyingPiece != null && endSquare.OccupyingPiece.Color != this.Color)
            {
                return true;
            }


            //todo en Passant

            return false;
        }
    }
}
