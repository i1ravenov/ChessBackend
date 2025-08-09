using Shared.Entity;
using Shared.Enums;

namespace Shared;

public class Game
{
    private Board Board {get; set;}
    private IList<Move> Moves {get; set;}
    public Color NextTurn {get; private set;}
    private IList<string> FENdata {get; set;}
    public bool IsOver {get; private set;}
    private int NextMoveNumber {get; set;}
    private Square? EnPassant {get; set;}
    
    public Game()
    {
        IsOver = false;
        Moves = new List<Move>();
        ParseFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    }

    public void ParseFEN(string fen)
    {
        FENdata = fen.Split(" ").ToList();
        NextMoveNumber = 1;
        Board = new Board(FENdata[0]);
        NextTurn = FENdata[1] == "w"  ? Color.White : Color.Black;
    }
}