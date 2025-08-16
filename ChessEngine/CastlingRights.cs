namespace ChessEngine;

public class CastlingRights
{
    public bool WhiteKingQSide {get; set;}
    public bool WhiteKingKSide {get; set;}
    public bool BlackKingQSide {get; set;}
    public bool BlackKingKSide {get; set;}

    public override string ToString()
    {
        return (WhiteKingKSide ? "K" : "") + 
               (WhiteKingQSide ? "Q" : "") + 
               (BlackKingKSide ? "k" : "") + 
               (BlackKingQSide ? "q" : "");
    }
}