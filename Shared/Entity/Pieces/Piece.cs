using Shared.Enums;
using Shared.Interfaces;

namespace Shared.Entity.Pieces;

public abstract class Piece : IMoveValid
{
   public Color Color {  get; set; }
   public PieceType PieceType {  get; set; }

    protected Piece(Color color, PieceType pieceType)
    {
        this.Color = color;
        this.PieceType = pieceType;
    }

    protected bool CheckBounds(Square endSquare)
    {
        if (endSquare.File < 0 || endSquare.File >= 8 || endSquare.Rank < 0 || endSquare.Rank >= 8)
        {
            return false; 
        }
        return true;
    }


    protected static bool CheckPath(Square startSquare, Square endSquare, Board board)
    {
        int xDirection = 0;
        int yDirection = 0;

        if (startSquare.File == endSquare.File)
        {
            yDirection = (endSquare.Rank > startSquare.Rank) ? 1 : -1;
        }
        else if (startSquare.Rank == endSquare.Rank)
        {
            xDirection = (endSquare.File > startSquare.File) ? 1 : -1;
        }
        else if (Math.Abs(startSquare.File - endSquare.File) == Math.Abs(startSquare.Rank - endSquare.Rank))
        {
            xDirection = (endSquare.File > startSquare.File) ? 1 : -1;
            yDirection = (endSquare.Rank > startSquare.Rank) ? 1 : -1;
        }

        int x = startSquare.File + xDirection;
        int y = startSquare.Rank + yDirection;

        while (x != endSquare.File || y != endSquare.Rank)
        {
            if (board._board[x, y].OccupyingPiece != null)
            {
                return false;
            }
            x += xDirection;
            y += yDirection;
        }

        return true;
    }
    
    protected bool CanAttack(Square endSquare)
    {
        return endSquare.OccupyingPiece != null && endSquare.OccupyingPiece.Color != this.Color;
    }

    public abstract bool IsMoveValid(Square startSquare, Square endSquare, Board board);
}
