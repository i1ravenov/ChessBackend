using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Color color, PieceType pieceType) : base(color, PieceType.Rook) { }


        public override bool IsMoveValid(Cell startCell, Cell endCell, Board board)
        {

            {
                if (!CheckBounds(endCell)) return false;

                if (startCell.X == endCell.X || startCell.Y == endCell.Y)
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

