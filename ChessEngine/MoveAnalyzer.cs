using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessEngine
{



    public static class MoveAnalyzer
    {
        public static List<(Piece Piece, Square From, Square To)> GetSafeMoves(Board board, Enums.Color color)
        {
            var result = new List<(Piece, Square, Square)>();

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

                     
                        if (piece.IsMoveValid( from, to, board) &&
                            !WouldLeaveKingInCheck(board, from, to, color))
                        {
                            result.Add((piece, from, to));
                        }
                    }
                }
            }

            return result;
        }

        private static bool WouldLeaveKingInCheck(Board board, Square from, Square to, Enums.Color color)
        {
            var simulated = board.Clone();
            var fromSim = simulated._board[from.Rank, from.File];
            var toSim = simulated._board[to.Rank, to.File];

            var piece = fromSim.OccupyingPiece;
            toSim.OccupyingPiece = piece;
            fromSim.OccupyingPiece = null;

            return simulated.IsUnderAttack(FindKing(simulated, color), color);
        }

        private static Square FindKing(Board board, Enums.Color color)
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
