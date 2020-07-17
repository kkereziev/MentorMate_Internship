using System;
using System.Collections.Generic;
using System.Text;

namespace GreenRedGame
{
    interface IGridOperations
    {
        int[,] FillGrid();

        int IterateGrid(int[,] grid, int iterations, int rowWanted, int colWanted);


    }
}
