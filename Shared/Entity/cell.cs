using Shared.Entity.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Boolean IsOccupied { get; set; }

        public Piece OccupyingPiece { get; set; }
       
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsOccupied = false;
        }


    }
}
