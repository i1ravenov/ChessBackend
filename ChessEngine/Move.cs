using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;

namespace ChessEngine
{
    public class Move
    {
        private Piece Piece {get; set;}
        private Square From {get; set;}
        private Square To {get; set;}

        public Move(Piece piece, Square from, Square to)
        {
            if (from.OccupyingPiece != null && !from.OccupyingPiece.Equals(piece))
            {
                throw new ArgumentException("Square 'from' contains other instance of Piece than provided in argument");
            }
            Piece = piece;
            From = from;
            To = to;
        }
    }    
}
