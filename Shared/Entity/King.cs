using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity
{
    internal class King : Piece
    {
        public King(Color color, PieceType pieceType) : base(color, pieceType)
        {
        }


        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {


            int deltaX = Math.Abs(startCell.X - endCell.X);
            int deltaY = Math.Abs(startCell.Y- endCell.Y);

            if (deltaX <= 1 && deltaY <= 1)
            {
                if (board.IsUnderAttack(endCell ,this.color))
                {
                    return false;
                }

                if (board.dashBoard[endCell.X, endCell.Y].IsOccupied && board.dashBoard[endCell.X, endCell.Y].OccupyingPiece.color == this.color)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

      
    }
}

