using Shared.Entity;

namespace Shared.Interfaces
{
    internal interface IMoveValid
    {
        bool IsMoveValid(Square startSquare, Square endSquare, Board board);
    }
}
