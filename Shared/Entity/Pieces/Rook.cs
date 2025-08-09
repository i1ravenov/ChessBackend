using Shared.Enums;

namespace Shared.Entity.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Color color) : base(color, PieceType.Rook)
        {
        }

        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {
            if (!CheckBounds(endSquare)) return false;

            if (startSquare.X != endSquare.X && startSquare.Y != endSquare.Y)
            {
                return false;
            }
            if (!CheckPath(startSquare, endSquare, board))
            {
                return false;
            }

            // TODO: to be tested
            return CanAttack(endSquare) || (endSquare.OccupyingPiece != null && endSquare.OccupyingPiece.Color != Color);
        }
    }
}
