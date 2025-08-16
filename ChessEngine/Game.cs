using ChessEngine.Entity;
using ChessEngine.Enums;

namespace ChessEngine;

public class Game
{
    private Board Board {get; set;}
    private IList<Move> Moves {get; set;}
    public Color NextTurn {get; private set;}
    private IList<string> FenData {get; set;}
    public bool IsOver {get; private set;}
    private int NextMoveNumber {get; set;}
    private CastlingRights CastlingRights {get; set;}
    private Square? EnPassant {get; set;}
    private int HalfMoveNumberAfterPawnMoveOrCapture {get; set;}
    private int FullMoveNumber {get; set;} // Note: it is incrementing after each Black move
    
    public Game()
    {
        IsOver = false;
        Moves = new List<Move>();
        ParseFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    }

    private void ParseFen(string fen)
    {
        FenData = fen.Split(" ").ToList();
        Board = new Board(FenData[0]);
        NextTurn = FenData[1] == "w"  ? Color.White : Color.Black;
        ParseCastling(FenData[2]);
        EnPassant = FenData[3] == "-" ? null : new Square(FenData[3]);
        HalfMoveNumberAfterPawnMoveOrCapture = int.Parse(FenData[4]);
        FullMoveNumber = int.Parse(FenData[5]);
    }

    private void ParseCastling(string castling)
    {
        CastlingRights castlingRights = new CastlingRights();
        castlingRights.WhiteKingKSide = castling.Contains('K');
        castlingRights.WhiteKingQSide = castling.Contains('Q');
        castlingRights.BlackKingKSide = castling.Contains('k');
        castlingRights.BlackKingQSide = castling.Contains('q');
        CastlingRights = castlingRights;
    }

    public string ToFen()
    {
        IList<string> fen = new List<string>();
        fen.Add(Board.ToFen());
        fen.Add(NextTurn == Color.White ? "w" : "b");
        fen.Add(CastlingRights.ToString());
        fen.Add(EnPassant == null ? "-" : EnPassant.ToString());
        fen.Add(HalfMoveNumberAfterPawnMoveOrCapture.ToString());
        fen.Add(FullMoveNumber.ToString());
        return string.Join(" ", fen);
    }
}