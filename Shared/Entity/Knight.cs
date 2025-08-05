using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity
{
    internal class Knight : Piece, IMoveValid
    {
        public Knight(Color color, PieceType pieceType) : base(color, pieceType)
        {
        }

        public bool IsMoveValid()
        {
            throw new NotImplementedException();
        }
    }
}
