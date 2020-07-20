using System;
using System.Collections.Generic;
using System.Text;

namespace GreenRedGame
{
    public struct Cell
    {
        /*
         * I have decided to use struct for Cell because when we copy the grid
         * the reference for each object in the private field stays the same
         * and we have to iterate through the array and create new objects.
         * 
         * Struct, being value type, is the perfect solution for us to avoid unnecessary iterations.
         */
        public Cell(int value)
        {
            this.Value = value;
        }
        public int Value { get; set; }
    }
}
