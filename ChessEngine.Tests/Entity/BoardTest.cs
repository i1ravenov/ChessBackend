using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;

namespace ChessEngine.Tests.Entity;

public class BoardTest
{
    [Fact]
    public void CreateBoardTest()
    {
        Board board = new Board("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
        // for (int i = 0; i < 8; i++)
        // {
        //     for (int j = 0; j < 8; j++)
        //     {
        //         Console.Write(board._board[i, j]);
        //     }
        //     Console.WriteLine();
        // }
        Assert.True(board["e2"].OccupyingPiece.Equals(new Pawn(Color.White)));
    }

    [Fact]
    public void ApplyMoveTest()
    {
        Board board = new Board("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
        board.ApplyMove(board["e2"], board["e4"]);
        Assert.Null(board["e2"].OccupyingPiece);
        Assert.True(board["e4"].OccupyingPiece.Equals(new Pawn(Color.White)));
    }
}