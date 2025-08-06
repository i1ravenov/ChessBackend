using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, PieceType pieceType) : base(color, PieceType.Bishop)
        {
        }



        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {
            {
                if (!CheckBounds(endCell)) return false;

                int moveX = Math.Abs(startCell.X - endCell.X);
                int moveY = Math.Abs(startCell.Y - endCell.Y);

                if (moveX == moveY)
                {
                    if (CheckPath(startCell, endCell, board))
                    {
                        if (CanAttack(endCell) || !endCell.IsOccupied)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

        }
    }
}
