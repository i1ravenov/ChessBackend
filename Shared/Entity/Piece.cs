using Shared.Enums;

namespace Shared.Entity;

public abstract class Piece : IMoveValid
{
   public Color color {  get; set; }
   public PieceType pieceType {  get; set; }

    public Piece(Color color, PieceType pieceType)
    {
        this.color = color;
        this.pieceType = pieceType;
    }


    public abstract bool IsMoveValid(Cell startCell, Cell endCell, Board board);
    public bool IsMoveValid(Cell endCell, Board board)
    {
       return IsMoveValid(null, endCell, board);
    }

}