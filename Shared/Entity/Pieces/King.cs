using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Pieces
{
    internal class King : Piece
    {
        public King(Color color, PieceType pieceType) : base(color, PieceType.King)
        {
        }


        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {
            if(!CheckBounds(endCell))
                return false;

            int moveX = Math.Abs(startCell.X - endCell.X);
            int moveY = Math.Abs(startCell.Y- endCell.Y);

            if (moveX <= 1 && moveY <= 1)
            {
                if (board.IsUnderAttack(endCell , color))
                {
                    return false;
                }

                if (endCell.IsOccupied && endCell.OccupyingPiece.color == this.color)
                {
                    return false;
                }

                ////can attack
                //else if (endCell.IsOccupied && endCell.OccupyingPiece.color != this.color)
                //{
                //    return true;
                //}

                return true;
            }

         
          

            return false;
        }

      
    }
}

