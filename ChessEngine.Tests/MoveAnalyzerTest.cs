using ChessEngine.Enums;

namespace ChessEngine.Tests;

public class MoveAnalyzerTest
{
    [Fact]
    public void MoveAnalyzerSmokeTest()
    {
        Game game = new Game();

        IList<Move> validMoves = MoveAnalyzer.GetSafeMoves(game.Board, Color.White);
        
        Assert.Equal(20, validMoves.Count);
    }
}