namespace Shared;

public class Game
{
    private List<Move> Moves;
    public Color NextTurn;
    private string FEN;
    public bool IsOver;

    public Game()
    {
        NextTurn = Color.White;
        IsOver = false;
        FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        Moves = new List<Move>();
    }

    
    
}