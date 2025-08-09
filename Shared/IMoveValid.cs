using Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    internal interface IMoveValid
    {
        bool IsMoveValid(Square startSquare, Square endSquare, Board board);
    }
}
