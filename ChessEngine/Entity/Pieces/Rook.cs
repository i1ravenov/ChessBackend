using ChessEngine.Enums;

namespace ChessEngine.Entity.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color color) : base(color, PieceType.Rook)
        {
        }

        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {
            if (!CheckBounds(endSquare)) return false;

            if (startSquare.File != endSquare.File && startSquare.Rank != endSquare.Rank)
                return false;

            if (!CheckPath(startSquare, endSquare, board))
                return false;

            if (endSquare.OccupyingPiece == null || CanAttack(endSquare))
                return true;

            return false;
        }

    }

}