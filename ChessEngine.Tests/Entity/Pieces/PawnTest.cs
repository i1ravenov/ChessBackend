using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;

namespace ChessEngine.Tests.Entity.Pieces;

public class PawnTest
{
    [Fact]
    public void Test1()
    {

    }

    [Fact]
    public void Pawn_CanMoveTwoStepsFromStart()
    {
        var board = new Board();

        var whitePawn = new Pawn(Color.White);
        board._board[3, 1].OccupyingPiece = whitePawn;
        var blackPawn = new Pawn(Color.Black);
        board._board[4, 6].OccupyingPiece = blackPawn;

        var whiteTarget = board._board[3, 3];
        var blackTarget = board._board[4, 4];

        Assert.True(whitePawn.IsMoveValid(board._board[3, 1], whiteTarget, board));
        Assert.True(blackPawn.IsMoveValid(board._board[4, 6], blackTarget, board));
    }

    [Fact]
    public void Pawn_CannotMoveIfBlocked()
    {
        var board = new Board();

        var whitePawn = new Pawn(Color.White);
        board._board[4, 1].OccupyingPiece = whitePawn;
        board._board[4, 2].OccupyingPiece = new Pawn(Color.White);

        var blackPawn = new Pawn(Color.Black);
        board._board[5, 6].OccupyingPiece = blackPawn;
        board._board[5, 5].OccupyingPiece = new Pawn(Color.Black);

        var whiteTarget = board._board[4, 3];
        var blackTarget = board._board[5, 4];

        Assert.False(whitePawn.IsMoveValid(board._board[4, 1], whiteTarget, board));
        Assert.False(blackPawn.IsMoveValid(board._board[5, 6], blackTarget, board));
    }

    [Fact]
    public void Pawn_CanAttackDiagonally()
    {
        var board = new Board();

        var whitePawn = new Pawn(Color.White);
        board._board[2, 4].OccupyingPiece = whitePawn;
        var blackPawn = new Pawn(Color.Black);
        board._board[5, 3].OccupyingPiece = blackPawn;

        board._board[3, 5].OccupyingPiece = new Pawn(Color.Black);
        board._board[4, 2].OccupyingPiece = new Pawn(Color.White);

        Assert.True(whitePawn.IsMoveValid(board._board[2, 4], board._board[3, 5], board));
        Assert.True(blackPawn.IsMoveValid(board._board[5, 3], board._board[4, 2], board));
    }

    [Fact]
    public void Pawn_CannotAttackOwnPiece()
    {
        var board = new Board();

        var whitePawn = new Pawn(Color.White);
        board._board[2, 4].OccupyingPiece = whitePawn;
        var blackPawn = new Pawn(Color.Black);
        board._board[5, 3].OccupyingPiece = blackPawn;

        board._board[3, 5].OccupyingPiece = new Pawn(Color.White);
        board._board[4, 2].OccupyingPiece = new Pawn(Color.Black);

        Assert.False(whitePawn.IsMoveValid(board._board[2, 4], board._board[3, 5], board));
        Assert.False(blackPawn.IsMoveValid(board._board[5, 3], board._board[4, 2], board));
    }

    [Fact]
    public void Pawn_CannotMoveBackward()
    {
        var board = new Board();

        var whitePawn = new Pawn(Color.White);
        board._board[1, 3].OccupyingPiece = whitePawn;
        var blackPawn = new Pawn(Color.Black);
        board._board[4, 4].OccupyingPiece = blackPawn;

        var whiteTarget = board._board[1, 2];
        var blackTarget = board._board[4, 5];

        Assert.False(whitePawn.IsMoveValid(board._board[1, 3], whiteTarget, board));
        Assert.False(blackPawn.IsMoveValid(board._board[4, 4], blackTarget, board));
    }

    [Fact]
    public void Pawn_CannotMoveOutOfBoard()
    {
        var board = new Board();

        var whitePawn = new Pawn(Color.White);
        board._board[0, 7].OccupyingPiece = whitePawn;
        var blackPawn = new Pawn(Color.Black);
        board._board[7, 0].OccupyingPiece = blackPawn;

        var whiteTarget = new Square(-1, 8);
        var blackTarget = new Square(8, -1);

        Assert.False(whitePawn.IsMoveValid(board._board[0, 7], whiteTarget, board));
        Assert.False(blackPawn.IsMoveValid(board._board[7, 0], blackTarget, board));
    }
}



    

