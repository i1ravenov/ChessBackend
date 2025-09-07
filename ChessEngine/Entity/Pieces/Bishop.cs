﻿using ChessEngine.Enums;

namespace ChessEngine.Entity.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color) : base(color, Enums.PieceType.Bishop)
        {
        }

        public override Piece Clone() => new Bishop(this.Color);

        public override bool IsMoveValid(Square startSquare, Square endSquare, Board board)
        {
            
                if (!CheckBounds(endSquare)) return false;

                int moveX = Math.Abs(startSquare.File - endSquare.File);
                int moveY = Math.Abs(startSquare.Rank - endSquare.Rank);

                if (moveX == moveY)
                {
                    if (CheckPath(startSquare, endSquare, board))
                    {
                        if (CanAttack(endSquare) || endSquare.OccupyingPiece == null)
                        {
                            return true;
                        }
                    }
                }

                return false;
            

        }
    }


     
    }
