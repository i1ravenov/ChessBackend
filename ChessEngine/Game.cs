using ChessEngine.Entity;
using ChessEngine.Entity.Pieces;
using ChessEngine.Enums;

namespace ChessEngine;

public class Game
{
    private Board Board { get; set; }
    private IList<Move> Moves { get; set; }
    public Color NextTurn { get; private set; }
    private IList<string> FENdata { get; set; }
    public bool IsOver { get; private set; }
    private int NextMoveNumber { get; set; }
    CastlingRights CastlingRights { get; set; }
    private Square? EnPassant { get; set; }
    private int HalfMoveNumberAfterPawnMoveOrCapture { get; set; }
    private int FullMoveNumber { get; set; } // Note: it is incrementing after each Black move

    public Game()
    {
        IsOver = false;
        Moves = new List<Move>();
        ParseFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    }

    public void ParseFEN(string fen)
    {
        FENdata = fen.Split(" ").ToList();
        Board = new Board(FENdata[0]);
        NextTurn = FENdata[1] == "w" ? Color.White : Color.Black;
        ParseCastling(FENdata[2]);
        EnPassant = FENdata[3] == "-" ? null : new Square(FENdata[3]);
        HalfMoveNumberAfterPawnMoveOrCapture = int.Parse(FENdata[4]);
        FullMoveNumber = int.Parse(FENdata[5]);
    }

    private void ParseCastling(string castling)
    {
        CastlingRights castlingRights = new CastlingRights();
        castlingRights.WhiteKingKSide = castling.Contains("K");
        castlingRights.WhiteKingQSide = castling.Contains("Q");
        castlingRights.BlackKingKSide = castling.Contains("k");
        castlingRights.BlackKingQSide = castling.Contains("q");
        CastlingRights = castlingRights;
    }

    public MoveResult MakeMove(Square from, Square to)
    {
        if (from.OccupyingPiece == null
            || (to.OccupyingPiece != null && to.OccupyingPiece.Color == from.OccupyingPiece.Color)
            || !from.OccupyingPiece.IsMoveValid(from, to, Board))
        {
            return MoveResult.Fail("Invalid move of missing piece");
        }
        Board.ApplyMove(from, to);
        return MoveResult.Ok();
    }
}