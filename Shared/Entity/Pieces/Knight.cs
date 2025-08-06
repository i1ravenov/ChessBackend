using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Color color, PieceType pieceType) : base(color, PieceType.Knight)
        {
        }

     

        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {

            if (!CheckBounds(endCell)) return false;

            int moveX = Math.Abs(startCell.X - endCell.X);
            int moveY = Math.Abs(startCell.Y - endCell.Y);

           
            if ((moveX == 2 && moveY == 1) || (moveX == 1 && moveY == 2))
            {
                
                if (CanAttack(endCell) || !endCell.IsOccupied)
                {
                    return true;
                }
            }

            return false; 
        }

    }
 }

