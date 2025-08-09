using Shared.Enums;

namespace Shared.Entity.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Color color) : base(color, PieceType.Queen)
        {
        }


        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {
            if (!CheckBounds(endSquare))
                return false;

            return new Rook(this.color).IsMoveValid(startSquare, endSquare, board) ||
                new Bishop(this.color).IsMoveValid(startSquare, endSquare, board);
        }
    }
}
