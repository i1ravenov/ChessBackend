using Shared.Enums;

namespace Shared.Entity.Pieces;

public abstract class Piece : IMoveValid
{
   public Color color {  get; set; }
   public PieceType pieceType {  get; set; }

    public Piece(Color color, PieceType pieceType)
    {
        this.color = color;
        this.pieceType = pieceType;
    }

    protected bool CheckBounds(Square endSquare)
    {
        if (endSquare.X < 0 || endSquare.X >= 8 || endSquare.Y < 0 || endSquare.Y >= 8)
        {
            return false; 
        }
        return true;
    }


    protected bool CheckPath(Square startSquare, Square endSquare, Board board)
    {
        int xDirection = 0;
        int yDirection = 0;

        if (startSquare.X == endSquare.X)
        {
            yDirection = (endSquare.Y > startSquare.Y) ? 1 : -1;
        }
        else if (startSquare.Y == endSquare.Y)
        {
            xDirection = (endSquare.X > startSquare.X) ? 1 : -1;
        }
        else if (Math.Abs(startSquare.X - endSquare.X) == Math.Abs(startSquare.Y - endSquare.Y))
        {
            xDirection = (endSquare.X > startSquare.X) ? 1 : -1;
            yDirection = (endSquare.Y > startSquare.Y) ? 1 : -1;
        }

        int x = startSquare.X + xDirection;
        int y = startSquare.Y + yDirection;

        while (x != endSquare.X || y != endSquare.Y)
        {
            if (board._board[x, y].IsOccupied)
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
        if (endSquare.IsOccupied && endSquare.OccupyingPiece.color != this.color)
        {
            return true; 
        }
        return false; 
    }

    public abstract bool IsMoveValid(Square startSquare, Square endSquare, Board board);
    public bool IsMoveValid(Square endSquare, Board board)
    {
       return IsMoveValid(null, endSquare, board);
    }

}