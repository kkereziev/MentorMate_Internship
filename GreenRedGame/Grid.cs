using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace GreenRedGame
{
    public class Grid
    {
        //class representing our 2d grid

        private Cell[,] cells; 
        private int count;
        
        public Grid(int row, int col)
        {
            this.cells = new Cell[row, col];
            this.count = row * col;
            this.Rows = row;
            this.Columns = col;
        }

        public Grid(Grid grid)
        {
            this.cells = grid.cells.Clone() as Cell[,];
            this.count = grid.count;
            this.Rows = grid.Rows;
            this.Columns = grid.Columns;
        }

        public int Rows { get; set; }
        public int Columns { get; set; }
        //property for indexing
        public Cell this[int row,int col]
        {
            get 
            {
                ValidateIndex(row, col);
                return this.cells[row,col]; 
            }
            set 
            {
                ValidateIndex(row, col);
                this.cells[row,col] = value; 
            }
        }
        //validation
        private void ValidateIndex(int row,int col)
        {
            if (row < 0 || col < 0 ||  row*col >= this.count)
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
        }
        //cloning objects
        public Grid Clone()
        {
            return new Grid(this);
        }
    }
}
