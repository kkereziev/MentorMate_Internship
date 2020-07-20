using System;
using System.Collections.Generic;
using System.Text;

namespace GreenRedGame
{
    public class Cell
    {
        /*
         * I was thinking about adding 2 more properties about position of the cell
         * however I believe that will be redundant because we dont need to track 
         * the coordinates of each cell and we already have the indexing of Cell 
         */
        public Cell(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
    }
}
