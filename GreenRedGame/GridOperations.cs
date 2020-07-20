using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GreenRedGame
{
    public static class GridOperations 
    {
        
        public static Grid FillGrid()
        {
            var grid = SizeOfGrid();

            for (int row = 0; row < grid.Rows; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < grid.Columns; col++)
                {
                    grid[row, col] = new Cell(input[col] - '0');
                }
            }
            return grid;
        }

        private static Grid SizeOfGrid()
        {
            var gridSize = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int width = gridSize[0];
            int height = gridSize[1];
            
            var grid = new Grid(height,width);
            return grid;
        }

        public static int IterateGrid(Grid grid, int iterations, int rowWanted, int colWanted)
        {
            int wantedCellGreenCount = 0;
            var sumSurroundings = 0;
            while (iterations-- >= 0)
            {
                var newGrid = grid.Clone(); 
                    
                for (int row = 0; row < grid.Rows; row++)
                {
                    for (int col = 0; col < grid.Columns; col++)
                    {
                        if (grid[row, col].Value == 0)
                        {
                            sumSurroundings = CellOperations.SumSurroundings(grid, row, col);
                            CellOperations.RedChangeColor(newGrid, row, col, sumSurroundings);
                        }
                        else if (grid[row, col].Value == 1)
                        {
                            sumSurroundings = CellOperations.SumSurroundings(grid, row, col);
                            CellOperations.GreenChangeColor(newGrid, row, col, sumSurroundings);
                        }
                    }
                }
                if (grid[rowWanted, colWanted].Value == 1)
                {
                    wantedCellGreenCount++;
                }

                grid = newGrid;
            }
            return wantedCellGreenCount;
        }    
    }
}
