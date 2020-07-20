using System;
using System.Linq;

namespace GreenRedGame
{
    public static class CellOperations
    {
        private static int GetCellValue(Grid grid, int row, int col)
        {
            //getting cell, try catch is in use in order to not use if-else blocks
            //that way if there is IndexOutOfRangeException we will simply return -1
            int value = -1;
            try
            {
                value =  grid[row, col].Value;
            }
            catch (Exception)
            {
                return value;
            }

            return value;
        }

        public static void GreenChangeColor(Grid grid, int row, int col, int sum)
        {
            //chaning color
            if (sum != 2 && sum != 3 && sum != 6)
            {
                grid[row, col] = new Cell(0);
            }
        }

        public static void RedChangeColor(Grid cells, int row, int col, int sum)
        {
            //chaning color
            if (sum == 3 || sum == 6)
            {
                cells[row, col] = new Cell(1);
            }
        }

        public static int SumSurroundings(Grid grid, int row, int col)
        {
            //getting surroundings of current cell and summing them
            var cells = new int[8];
            var sumResult = 0;
            //cellUp
            cells[0] = GetCellValue(grid,row - 1, col);
            //cellUpRight
            cells[1] = GetCellValue(grid,row - 1, col + 1);
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
