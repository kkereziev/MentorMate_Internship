using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GreenRedGame
{
    public class Grid
    {
        private object[,] list;
        private int count;
        public Grid(int row, int col)
        {
            this.list = new object[row, col];
            this.count = row * col;
            this.Row = row;
            this.Column = col;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public object this[int row,int col]
        {
            get 
            {
                ValidateIndex(row, col);
                return this.list[row,col]; 
            }
            set 
            {
                ValidateIndex(row, col);
                this.list[row,col] = value; 
            }
        }

        private void ValidateIndex(int row,int col)
        {
            if (row < 0 || col < 0 ||  row*col >= this.count)
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
        }
    }
}
