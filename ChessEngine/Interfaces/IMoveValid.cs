using ChessEngine.Entity;

namespace ChessEngine.Interfaces
{
    internal interface IMoveValid
    {
        bool IsMoveValid(Square startSquare, Square endSquare, Board board);
    }
}
