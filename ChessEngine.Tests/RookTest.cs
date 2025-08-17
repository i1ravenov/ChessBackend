
   using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;
using Xunit;

namespace ChessEngine.Tests
{
    public class RookTest
    {
        [Fact]
        public void Rook_CanMoveHorizontallyOrVertically()
        {
            var board = new Board();

            var whiteRook = new Rook(Color.White);
            board._board[0, 0].OccupyingPiece = whiteRook; // a1
            var blackRook = new Rook(Color.Black);
            board._board[7, 7].OccupyingPiece = blackRook; // h8

            Assert.True(whiteRook.IsMoveValid(board._board[0, 0], board._board[0, 5], board)); 
            Assert.True(whiteRook.IsMoveValid(board._board[0, 0], board._board[5, 0], board));
            Assert.True(blackRook.IsMoveValid(board._board[7, 7], board._board[3, 7], board)); 
        }

        [Fact]
        public void Rook_CannotMoveDiagonally()
        {
            var board = new Board();

            var rook = new Rook(Color.White);
            board._board[0, 0].OccupyingPiece = rook;

            Assert.False(rook.IsMoveValid(board._board[0, 0], board._board[3, 3], board));
        }

        [Fact]
        public void Rook_CanAttackEnemyPiece()
        {
            var board = new Board();

            var rook = new Rook(Color.White);
            board._board[0, 0].OccupyingPiece = rook;

            var enemy = new Pawn(Color.Black);
            board._board[0, 5].OccupyingPiece = enemy;

            Assert.True(rook.IsMoveValid(board._board[0, 0], board._board[0, 5], board));
        }

        [Fact]
        public void Rook_CannotAttackOwnPiece()
        {
            var board = new Board();

            var rook = new Rook(Color.White);
            board._board[0, 0].OccupyingPiece = rook;

            var ally = new Pawn(Color.White);
            board._board[0, 5].OccupyingPiece = ally;

            Assert.False(rook.IsMoveValid(board._board[0, 0], board._board[0, 5], board));
        }

        [Fact]
        public void Rook_CannotJumpOverPieces()
        {
            var board = new Board();

            var rook = new Rook(Color.White);
            board._board[0, 0].OccupyingPiece = rook;

            //blocking
            board._board[0, 3].OccupyingPiece = new Pawn(Color.White); 

            Assert.False(rook.IsMoveValid(board._board[0, 0], board._board[0, 5], board));
        }

        [Fact]
        public void Rook_CannotMoveOutOfBoard()
        {
            var board = new Board();

            var rook = new Rook(Color.White);
            board._board[0, 0].OccupyingPiece = rook;

            //outside of board
            var invalidTarget = new Square(0, 8); 

            Assert.False(rook.IsMoveValid(board._board[0, 0], invalidTarget, board));
        }
    }
}


