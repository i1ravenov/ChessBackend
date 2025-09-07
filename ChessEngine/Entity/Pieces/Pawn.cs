using ChessEngine.Enums;

namespace ChessEngine.Entity.Pieces
{

    public class Pawn : Piece
    {
        public override Piece Clone() => new Pawn(this.Color);
        public Pawn(Color color) : base(color, Enums.PieceType.Pawn) { }

        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {
            if (!CheckBounds(endSquare))
                return false;

            int moveX = Math.Abs(startSquare.File - endSquare.File);
            int direction = (this.Color == Enums.Color.White) ? 1 : -1;
            int deltaY = endSquare.Rank - startSquare.Rank;

            if (startSquare.File == endSquare.File && deltaY == direction && endSquare.OccupyingPiece == null)
                return true;

            if (startSquare.File == endSquare.File && deltaY == 2 * direction &&
                ((this.Color == Enums.Color.White && startSquare.Rank == 1) || (this.Color == Enums.Color.Black && startSquare.Rank == 6)) &&
                endSquare.OccupyingPiece == null &&
                board._board[endSquare.File, startSquare.Rank + direction].OccupyingPiece == null)
                return true;

            if (moveX == 1 && deltaY == direction && endSquare.OccupyingPiece != null && endSquare.OccupyingPiece.Color != this.Color)
                return true;

            return false;
        }
        
        
        
    }
}
