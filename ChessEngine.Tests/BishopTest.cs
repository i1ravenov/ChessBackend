using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;
using Xunit;

namespace ChessEngine.Tests
{
    public class BishopTest
    {
        [Fact]
        public void Bishop_CanMoveDiagonally()
        {
            var board = new Board();

            var whiteBishop = new Bishop(Color.White);
            board._board[2, 0].OccupyingPiece = whiteBishop; // c1
            var blackBishop = new Bishop(Color.Black);
            board._board[5, 7].OccupyingPiece = blackBishop; // f8

            var whiteTarget = board._board[5, 3]; // f4
            var blackTarget = board._board[2, 4]; // c5

            Assert.True(whiteBishop.IsMoveValid(board._board[2, 0], whiteTarget, board));
            Assert.True(blackBishop.IsMoveValid(board._board[5, 7], blackTarget, board));
        }

        [Fact]
        public void Bishop_CannotMoveThroughOtherPieces()
        {
            var board = new Board();

            var whiteBishop = new Bishop(Color.White);
            board._board[2, 0].OccupyingPiece = whiteBishop; // c1
            var blackBishop = new Bishop(Color.Black);
            board._board[5, 7].OccupyingPiece = blackBishop; // f8

            board._board[3, 1].OccupyingPiece = new Pawn(Color.White); 
            board._board[4, 6].OccupyingPiece = new Pawn(Color.Black); 

            var whiteTarget = board._board[5, 3]; // f4
            var blackTarget = board._board[2, 4]; // c5

            Assert.False(whiteBishop.IsMoveValid(board._board[2, 0], whiteTarget, board));
            Assert.False(blackBishop.IsMoveValid(board._board[5, 7], blackTarget, board));
        }

        [Fact]
        public void Bishop_CanAttackEnemyPiece()
        {
            var board = new Board();

            var whiteBishop = new Bishop(Color.White);
            board._board[2, 0].OccupyingPiece = whiteBishop; // c1
            var blackBishop = new Bishop(Color.Black);
            board._board[5, 7].OccupyingPiece = blackBishop; // f8

            //opposite piece
            board._board[5, 3].OccupyingPiece = new Pawn(Color.Black); 
            board._board[2, 4].OccupyingPiece = new Pawn(Color.White); 

            Assert.True(whiteBishop.IsMoveValid(board._board[2, 0], board._board[5, 3], board));
            Assert.True(blackBishop.IsMoveValid(board._board[5, 7], board._board[2, 4], board));
        }

        [Fact]
        public void Bishop_CannotAttackOwnPiece()
        {
            var board = new Board();

            var whiteBishop = new Bishop(Color.White);
            board._board[2, 0].OccupyingPiece = whiteBishop; // c1
            var blackBishop = new Bishop(Color.Black);
            board._board[5, 7].OccupyingPiece = blackBishop; // f8

            board._board[5, 3].OccupyingPiece = new Pawn(Color.White); 
            board._board[2, 4].OccupyingPiece = new Pawn(Color.Black); 

            Assert.False(whiteBishop.IsMoveValid(board._board[2, 0], board._board[5, 3], board));
            Assert.False(blackBishop.IsMoveValid(board._board[5, 7], board._board[2, 4], board));
        }

        [Fact]
        public void Bishop_CannotMoveNonDiagonal()
        {
            var board = new Board();

            var whiteBishop = new Bishop(Color.White);
            board._board[2, 0].OccupyingPiece = whiteBishop; // c1
            var blackBishop = new Bishop(Color.Black);
            board._board[5, 7].OccupyingPiece = blackBishop; // f8

            var whiteTarget = board._board[2, 3]; // c4 
            var blackTarget = board._board[7, 7]; // h8 

            Assert.False(whiteBishop.IsMoveValid(board._board[2, 0], whiteTarget, board));
            Assert.False(blackBishop.IsMoveValid(board._board[5, 7], blackTarget, board));
        }

        [Fact]
        public void Bishop_CannotMoveOutOfBoard()
        {
            var board = new Board();

            var whiteBishop = new Bishop(Color.White);
            board._board[2, 0].OccupyingPiece = whiteBishop; // c1
            var blackBishop = new Bishop(Color.Black);
            board._board[5, 7].OccupyingPiece = blackBishop; // f8

            //out of board
            var whiteTarget = new Square(-1, 1);
            var blackTarget = new Square(8, 7); 

            Assert.False(whiteBishop.IsMoveValid(board._board[2, 0], whiteTarget, board));
            Assert.False(blackBishop.IsMoveValid(board._board[5, 7], blackTarget, board));
        }
    }
}
