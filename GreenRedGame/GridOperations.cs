using System;
using System.Linq;

namespace GreenRedGame
{
    public class GridOperations : IGridOperations
    {
        public int[,] FillGrid()
        {
            var grid = SizeOfGrid();

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col] = input[col] - '0';
                }
            }
            return grid;
        }

        private int[,] SizeOfGrid()
        {
            var gridSize = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int width = gridSize[0];
            int height = gridSize[1];
            var grid = new int[height, width];
            return grid;
        }

        public int IterateGrid(int[,] grid, int iterations, int rowWanted, int colWanted)
        {
            int wantedCellGreenCount = 0;
            var sumSurroundings = 0;
            while (iterations-- >= 0)
            {
                var newGrid = grid.Clone() as int[,];
                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    for (int col = 0; col < grid.GetLength(1); col++)
                    {
                        if (grid[row, col] == 0)
                        {
                            sumSurroundings = SumSurroundings(grid, row, col);
                            RedChangeColor(newGrid, row, col, sumSurroundings);
                        }
                        else if (grid[row, col] == 1)
                        {
                            sumSurroundings = SumSurroundings(grid, row, col);
                            GreenChangeColor(newGrid, row, col, sumSurroundings);
                        }
                    }
                }
                if (grid[rowWanted, colWanted] == 1)
                {
                    wantedCellGreenCount++;
                }
                grid = newGrid;
            }
            return wantedCellGreenCount;
        }

        private void GreenChangeColor(int[,] grid, int row, int col, int sumSurroundings)
        {
            if (sumSurroundings != 2 && sumSurroundings != 3 && sumSurroundings != 6)
            {
                grid[row, col] = 0;
            }
        }

        private void RedChangeColor(int[,] grid, int row, int col, int sum)
        {
            if (sum == 3 || sum == 6)
            {
                grid[row, col] = 1;
            }
        }

        private static int GetCell(int[,] grid,int row,int col)
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

        private static int SumSurroundings(int[,] grid, int row, int col)
        {
            var cells = new int[8];
            var sumResult = 0;
            //cellUp
            cells[0] = GetCell(grid, row - 1, col);
            //cellUpRight
            cells[1] = GetCell(grid, row - 1, col + 1);
            //cellRight
            cells[2] = GetCell(grid, row, col + 1);
            //cellDownRight
            cells[3] = GetCell(grid, row + 1, col + 1);
            //cellDown 
            cells[4] = GetCell(grid, row + 1, col);
            //cellDownLeft 
            cells[5] = GetCell(grid, row + 1, col - 1);
            //cellLeft 
            cells[6] = GetCell(grid, row, col - 1);
            //cellUpLeft
            cells[7] = GetCell(grid, row - 1, col - 1);
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] > 0)
                {
                    sumResult += cells[i];
                }
            }
            return sumResult;
        }
    }
}
