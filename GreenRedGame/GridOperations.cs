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

            //filling the grid
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
            //here comes the input for the size of the 2d grid
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
            //iterating
            while (iterations-- >= 0)
            {
                /*
                 * cloning the original 2d grid, since we must change all cells after
                 * each iteration we must clone each time the current grid and work on the
                 * newly created one because we will get the results wrong
                 */

                var newGrid = grid.Clone(); 
                    
                for (int row = 0; row < grid.Rows; row++)
                {
                    for (int col = 0; col < grid.Columns; col++)
                    {
                        //summing the surrounding cells
                        sumSurroundings = CellOperations.SumSurroundings(grid, row, col);
                        if (grid[row, col].Value == 0)
                        {
                            //chaning the color
                            CellOperations.RedChangeColor(newGrid, row, col, sumSurroundings);
                        }
                        else if (grid[row, col].Value == 1)
                        {
                            CellOperations.GreenChangeColor(newGrid, row, col, sumSurroundings);
                        }
                    }
                }
                //increasing the value of the variable if the wanted cell is 1
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
