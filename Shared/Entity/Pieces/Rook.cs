using Shared.Enums;

namespace Shared.Entity.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Color color) : base(color, PieceType.Rook) { }


        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {

            {
                if (!CheckBounds(endSquare)) return false;

                if (startSquare.X == endSquare.X || startSquare.Y == endSquare.Y)
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

 }

