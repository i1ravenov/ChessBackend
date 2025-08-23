namespace ChessEngine.Tests;

public class GameTest
{
    [Fact]
    public void GameToFenTest()
    {
        Game game = new Game();
        string newGameFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        Assert.Equal(newGameFen, game.ToFen());
    }
    
    [Fact]
    public void FenToGameTest()
    {
        Game game = new Game("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        string newGameFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        Assert.Equal(newGameFen, game.ToFen());
    }
}
