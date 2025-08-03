namespace Shared;

public class Piece
{
    Color _color;
    PieceType _pieceType;

    public Piece(Color color, PieceType pieceType)
    {
        this._color = color;
        this._pieceType = pieceType;
    }
}