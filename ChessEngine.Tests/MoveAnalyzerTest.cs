using ChessEngine.Entity;
using ChessEngine.Enums;

namespace ChessEngine.Tests;

public class MoveAnalyzerTest
{
    [Fact]
    public void MoveAnalyzerSmokeTest()
    {
        Board  board = new Board();

        IList<Move> validMoves = MoveAnalyzer.GetSafeMoves(board, Color.White);
        
        Assert.Equal(2, validMoves.Count);
    }
}