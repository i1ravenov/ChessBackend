using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;
using Xunit;

    namespace ChessEngine.Tests
    {
        public class KingTest
        {
            [Fact]
            public void King_MoveValidation_Correct()
            {
                var board = new Board();
                var whiteKing = new King(Color.White);
                board._board[4, 4].OccupyingPiece = whiteKing;
                var blackRook = new Rook(Color.Black);
                board._board[4, 7].OccupyingPiece = blackRook;

                var validMoves = new[]
                {
                board._board[3, 3],
                board._board[3, 4],
                board._board[3, 5],
                board._board[5, 3],
                board._board[5, 4],
                board._board[5, 5]
            };

                var underAttackSquares = new[]
                {
                board._board[4, 3],
                board._board[4, 5],
                board._board[4, 6]
            };

                foreach (var sq in validMoves)
                    Assert.True(whiteKing.IsMoveValid(board._board[4, 4], sq, board));

                foreach (var sq in underAttackSquares)
                    Assert.False(whiteKing.IsMoveValid(board._board[4, 4], sq, board));

                var outOfBoardSquares = new[]
                {
                new Square(-1, 4),
                new Square(4, -1),
                new Square(8, 4),
                new Square(4, 8)
            };

                foreach (var sq in outOfBoardSquares)
                    Assert.False(whiteKing.IsMoveValid(board._board[4, 4], sq, board));
            }
        }
    }

