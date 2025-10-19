using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;

namespace ChessEngine
{
    public static class MoveAnalyzer
    {
        public static IList<Move> GetSafeMoves(Board board, Color color)
        {
            var result = new List<Move>();

            var allSquares = board.GetSquaresOfColor(color);

            foreach (var from in allSquares)
            {
                var piece = from.OccupyingPiece;
                if (piece == null)
                    continue;

                for (int rank = 0; rank < 8; rank++)
                {
                    for (int file = 0; file < 8; file++)
                    {
                        var to = board._board[rank, file];

                        if (from == to) continue;

                     
                        if (piece.IsMoveValid(from, to, board) &&
                            !WouldLeaveKingInCheck(board, from, to, color))
                        {
                            result.Add(new Move(piece, from, to));
                        }
                    }
                }
            }

            return result;
        }

        private static bool WouldLeaveKingInCheck(Board board, Square from, Square to, Color color)
        {
            var simulated = board.Clone();
            var fromSim = simulated._board[from.Rank, from.File];
            var toSim = simulated._board[to.Rank, to.File];

            var piece = fromSim.OccupyingPiece;
            toSim.OccupyingPiece = piece;
            fromSim.OccupyingPiece = null;

            return simulated.IsUnderAttack(FindKing(simulated, color), color);
        }

        private static Square FindKing(Board board, Color color)
        {
            for (int rank = 0; rank < 8; rank++)
                for (int file = 0; file < 8; file++)
                {
                    var sq = board._board[rank, file];
                    if (sq.OccupyingPiece is King king && king.Color == color)
                        return sq;
                }

            throw new Exception("King not found on board.");
        }
    }


}
