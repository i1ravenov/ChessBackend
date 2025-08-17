using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;
using Xunit;

namespace ChessEngine.Tests
{
    public class KnightTest
    {
        [Fact]
        public void Knight_CanMoveInLShape()
        {
            var board = new Board();

            var whiteKnight = new Knight(Color.White);
            board._board[1, 0].OccupyingPiece = whiteKnight;
            var blackKnight = new Knight(Color.Black);
            board._board[6, 7].OccupyingPiece = blackKnight;

            var whiteTarget = board._board[2, 2];
            var whiteTarget2 = board._board[0, 2];
            var blackTarget = board._board[5, 5];
            var blackTarget2 = board._board[7, 5];

            Assert.True(whiteKnight.IsMoveValid(board._board[1, 0], whiteTarget, board));
            Assert.True(whiteKnight.IsMoveValid(board._board[1, 0], whiteTarget2, board));
            Assert.True(blackKnight.IsMoveValid(board._board[6, 7], blackTarget, board));
            Assert.True(blackKnight.IsMoveValid(board._board[6, 7], blackTarget2, board));
        }

        [Fact]
        public void Knight_CannotMoveInvalid()
        {
            var board = new Board();

            var whiteKnight = new Knight(Color.White);
            board._board[1, 0].OccupyingPiece = whiteKnight;
            var blackKnight = new Knight(Color.Black);
            board._board[6, 7].OccupyingPiece = blackKnight;

            var whiteTarget = board._board[1, 2];
            var blackTarget = board._board[6, 5];

            Assert.False(whiteKnight.IsMoveValid(board._board[1, 0], whiteTarget, board));
            Assert.False(blackKnight.IsMoveValid(board._board[6, 7], blackTarget, board));
        }

        [Fact]
        public void Knight_CanAttackEnemy()
        {
            var board = new Board();

            var whiteKnight = new Knight(Color.White);
            board._board[1, 0].OccupyingPiece = whiteKnight;
            var blackKnight = new Knight(Color.Black);
            board._board[6, 7].OccupyingPiece = blackKnight;

            board._board[2, 2].OccupyingPiece = new Pawn(Color.Black);
            board._board[5, 5].OccupyingPiece = new Pawn(Color.White);

            Assert.True(whiteKnight.IsMoveValid(board._board[1, 0], board._board[2, 2], board));
            Assert.True(blackKnight.IsMoveValid(board._board[6, 7], board._board[5, 5], board));
        }

        [Fact]
        public void Knight_CannotAttackOwnPiece()
        {
            var board = new Board();

            var whiteKnight = new Knight(Color.White);
            board._board[1, 0].OccupyingPiece = whiteKnight;
            var blackKnight = new Knight(Color.Black);
            board._board[6, 7].OccupyingPiece = blackKnight;

            board._board[2, 2].OccupyingPiece = new Pawn(Color.White);
            board._board[5, 5].OccupyingPiece = new Pawn(Color.Black);

            Assert.False(whiteKnight.IsMoveValid(board._board[1, 0], board._board[2, 2], board));
            Assert.False(blackKnight.IsMoveValid(board._board[6, 7], board._board[5, 5], board));
        }

        [Fact]
        public void Knight_CannotMoveOutOfBoard()
        {
            var board = new Board();

            var whiteKnight = new Knight(Color.White);
            board._board[0, 0].OccupyingPiece = whiteKnight;
            var blackKnight = new Knight(Color.Black);
            board._board[7, 7].OccupyingPiece = blackKnight;

            var whiteTarget = new Square(-1, -2);
            var blackTarget = new Square(8, 9);

            Assert.False(whiteKnight.IsMoveValid(board._board[0, 0], whiteTarget, board));
            Assert.False(blackKnight.IsMoveValid(board._board[7, 7], blackTarget, board));
        }
    }
}
