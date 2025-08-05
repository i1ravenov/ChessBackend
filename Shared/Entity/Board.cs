using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity
{
    public class Board
    {
        public Cell[,] dashBoard;

        public Board()
        {
            dashBoard = new Cell[8, 8];
            CreateBoard();
        }

        private void CreateBoard()
        {
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {

                    dashBoard[i, j] = new Cell(i, j);


                }
            }

        }

        private Cell GetCell(int x, int y)
        {

            return dashBoard[x, y];
        }


        private List<Cell> GetOpponentCells(Piece piece)
        {

            List<Cell> opponentsCells = new List<Cell>();
            //toDo
            foreach (Cell cell in dashBoard)
            {

                if (cell.IsOccupied && cell.OccupyingPiece.color != piece.color)
                {
                    opponentsCells.Add(cell);
                }
            }
            return opponentsCells;
        }


        public bool IsUnderAttack(Cell endCell, Color playerColor)
        {
            foreach (var cell in dashBoard)
            {
                if (cell.IsOccupied && cell.OccupyingPiece.color != playerColor)
                {

                    if (cell.OccupyingPiece.IsMoveValid(cell, this))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
 }
