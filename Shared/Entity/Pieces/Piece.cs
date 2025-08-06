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

    protected bool CheckBounds(Cell endCell)
    {
        if (endCell.X < 0 || endCell.X >= 8 || endCell.Y < 0 || endCell.Y >= 8)
        {
            return false; 
        }
        return true;
    }


    protected bool CheckPath(Cell startCell, Cell endCell, Board board)
    {
        int xDirection = 0;
        int yDirection = 0;

        if (startCell.X == endCell.X)
        {
            yDirection = (endCell.Y > startCell.Y) ? 1 : -1;
        }
        else if (startCell.Y == endCell.Y)
        {
            xDirection = (endCell.X > startCell.X) ? 1 : -1;
        }
        else if (Math.Abs(startCell.X - endCell.X) == Math.Abs(startCell.Y - endCell.Y))
        {
            xDirection = (endCell.X > startCell.X) ? 1 : -1;
            yDirection = (endCell.Y > startCell.Y) ? 1 : -1;
        }

        int x = startCell.X + xDirection;
        int y = startCell.Y + yDirection;

        while (x != endCell.X || y != endCell.Y)
        {
            if (board.dashBoard[x, y].IsOccupied)
            {
                return false;
            }
            x += xDirection;
            y += yDirection;
        }

        return true;
    }


    protected bool CanAttack(Cell endCell)
    {
        if (endCell.IsOccupied && endCell.OccupyingPiece.color != this.color)
        {
            return true; 
        }
        return false; 
    }

    public abstract bool IsMoveValid(Cell startCell, Cell endCell, Board board);
    public bool IsMoveValid(Cell endCell, Board board)
    {
       return IsMoveValid(null, endCell, board);
    }

}