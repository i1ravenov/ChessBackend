using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;

namespace ChessEngine.Tests.Entity.Pieces
{
    public class QueenTest
    {

        [Fact]
        public void Queen_CannotMoveInvalid()
        {
            var board = new Board();

            var whiteQueen = new Queen(Color.White);
            board._board[3, 3].OccupyingPiece = whiteQueen;
            var blackQueen = new Queen(Color.Black);
            board._board[4, 4].OccupyingPiece = blackQueen;

            var whiteTarget = board._board[5, 6];
            var blackTarget = board._board[2, 5];

            Assert.False(whiteQueen.IsMoveValid(board._board[3, 3], whiteTarget, board));
            Assert.False(blackQueen.IsMoveValid(board._board[4, 4], blackTarget, board));
        }

        [Fact]
        public void Queen_CanAttackEnemy()
        {
            var board = new Board();

            var whiteQueen = new Queen(Color.White);
            board._board[3, 3].OccupyingPiece = whiteQueen;
            var blackQueen = new Queen(Color.Black);
            board._board[4, 4].OccupyingPiece = blackQueen;

            board._board[3, 0].OccupyingPiece = new Pawn(Color.Black);
            board._board[7, 4].OccupyingPiece = new Pawn(Color.White);

            Assert.True(whiteQueen.IsMoveValid(board._board[3, 3], board._board[3, 0], board));
            Assert.True(blackQueen.IsMoveValid(board._board[4, 4], board._board[7, 4], board));
        }

        [Fact]
        public void Queen_CannotAttackOwnPiece()
        {
            var board = new Board();

            var whiteQueen = new Queen(Color.White);
            board._board[3, 3].OccupyingPiece = whiteQueen;
            var blackQueen = new Queen(Color.Black);
            board._board[4, 4].OccupyingPiece = blackQueen;

            board._board[3, 0].OccupyingPiece = new Pawn(Color.White);
            board._board[7, 4].OccupyingPiece = new Pawn(Color.Black);

            Assert.False(whiteQueen.IsMoveValid(board._board[3, 3], board._board[3, 0], board));
            Assert.False(blackQueen.IsMoveValid(board._board[4, 4], board._board[7, 4], board));
        }

        [Fact]
        public void Queen_CannotMoveOutOfBoard()
        {
            var board = new Board();

            var whiteQueen = new Queen(Color.White);
            board._board[0, 0].OccupyingPiece = whiteQueen;
            var blackQueen = new Queen(Color.Black);
            board._board[7, 7].OccupyingPiece = blackQueen;

            var whiteTarget = new Square(-1, 0);
            var blackTarget = new Square(7, 8);

            Assert.False(whiteQueen.IsMoveValid(board._board[0, 0], whiteTarget, board));
            Assert.False(blackQueen.IsMoveValid(board._board[7, 7], blackTarget, board));
        }
    }
}
