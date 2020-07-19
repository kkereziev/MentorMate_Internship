using System;
using System.Linq;

namespace GreenRedGame
{
    public class GridOperations : IGridOperations
    {
        CellOperations cellOperations = new CellOperations();
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
                            sumSurroundings = cellOperations.SumSurroundings(grid, row, col);
                            cellOperations.RedChangeColor(newGrid, row, col, sumSurroundings);
                        }
                        else if (grid[row, col] == 1)
                        {
                            sumSurroundings = cellOperations.SumSurroundings(grid, row, col);
                            cellOperations.GreenChangeColor(newGrid, row, col, sumSurroundings);
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
    }
}
