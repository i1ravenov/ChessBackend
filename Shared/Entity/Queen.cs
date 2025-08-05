using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity
{
    internal class Queen : Piece
    {
        public Queen(Color color, PieceType pieceType) : base(color, pieceType)
        {
        }


        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {
            throw new NotImplementedException();
        }

     
    }
}
