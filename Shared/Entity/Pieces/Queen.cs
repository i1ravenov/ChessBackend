using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Color color, PieceType pieceType) : base(color, PieceType.Queen)
        {
        }


        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {
            //toDo i create here new Instances. Fine?
            if (!CheckBounds(endCell))
                return false;

            if (new Rook(this.color , PieceType.Rook).IsMoveValid(startCell, endCell, board))
            {
                return true; 
            }

            
            if (new Bishop(this.color , PieceType.Bishop).IsMoveValid(startCell, endCell, board))
            {
                return true; 
            }

            return false; 
        }


    }
}
