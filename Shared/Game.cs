using Shared.Enums;

namespace Shared;

public class Game
{
    private IList<Move> Moves {get; set;}
    public Color NextTurn {get; private set;}
    private string FEN {get; set;}
    public bool IsOver {get; private set;}
    private int NextMoveNumber {get; set;}
    
    public Game()
    {
        NextTurn = Color.White;
        IsOver = false;
        FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        Moves = new List<Move>();
        NextMoveNumber = 1;
    }

    private void ParseFEN(string fen)
    {
        
    }
}