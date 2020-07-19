using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenRedGame
{
    class CellOperations : ICellOperations
    {
        private int GetCellValue(int[,] grid, int row, int col)
        {
            int value = -1;
            try
            {
                value = grid[row, col];
            }
            catch (Exception)
            {
                return value;
            }

            return value;
        }

        public void GreenChangeColor(int[,] grid, int row, int col, int sum)
        {
            if (sum != 2 && sum != 3 && sum != 6)
            {
                grid[row, col] = 0;
            }
        }

        public void RedChangeColor(int[,] grid, int row, int col, int sum)
        {
            if (sum == 3 || sum == 6)
            {
                grid[row, col] = 1;
            }
        }

        public int SumSurroundings(int[,] grid, int row, int col)
        {
            var cells = new int[8];
            var sumResult = 0;
            //cellUp
            cells[0] = GetCellValue(grid, row - 1, col);
            //cellUpRight
            cells[1] = GetCellValue(grid, row - 1, col + 1);
            //cellRight
            cells[2] = GetCellValue(grid, row, col + 1);
            //cellDownRight
            cells[3] = GetCellValue(grid, row + 1, col + 1);
            //cellDown 
            cells[4] = GetCellValue(grid, row + 1, col);
            //cellDownLeft 
            cells[5] = GetCellValue(grid, row + 1, col - 1);
            //cellLeft 
            cells[6] = GetCellValue(grid, row, col - 1);
            //cellUpLeft
            cells[7] = GetCellValue(grid, row - 1, col - 1);
            
            sumResult = cells
                .Where(x => x > 0)
                .Sum();
            
            return sumResult;
        }
    }
}
