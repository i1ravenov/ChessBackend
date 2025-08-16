namespace ChessEngine.Tests;

public class GameTest
{
    [Fact]
    public void GameToFenAndBackTest()
    {
        Game game = new Game();
        string newGameFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        Assert.Equal(newGameFen, game.ToFen());
    }
}
