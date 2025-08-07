using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Pieces
{

    internal class Pawn : Piece
    {
        public Pawn(Color color) : base(color, PieceType.Pawn) { }

          
        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {

            if (!CheckBounds(endCell))        
                return false;
            


            int moveX  = Math.Abs(startCell.X - endCell.X);
            int moveY = Math.Abs(startCell.Y - endCell.Y);

            if (this.color == Color.White)
            {
                //regular move
                if (startCell.X == endCell.X && moveY == 1 && !endCell.IsOccupied)
                {
                    return true;
                }

                //if first move and pawn moves 2 steps
                if (startCell.X == endCell.X && moveY == 2 && startCell.Y == 1 
                    && !endCell.IsOccupied && !board.dashBoard[endCell.X, endCell.Y - 1].IsOccupied)
                {
                    return true;
                }
            }

            //same logic for black one
            else if (this.color == Color.Black)
            {
                if (startCell.X == endCell.X && moveY == 1 && !endCell.IsOccupied)
                {
                    return true;
                }

                if (startCell.X == endCell.X && moveY == 2 && startCell.Y == 6 
                    && !endCell.IsOccupied && !board.dashBoard[endCell.X, endCell.Y + 1].IsOccupied)
                {
                    return true;
                }              
            }

            //Is attacking 
            if (moveX == 1 && moveY == 1 && endCell.IsOccupied && endCell.OccupyingPiece.color != this.color)
            {
                return true;
            }


            //todo en Passant

            return false;
        }
    }
}
