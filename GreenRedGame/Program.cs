using System;
using System.Linq;

namespace GreenRedGame
{
    class Program
    {
        public static void Run()
        {
            
            //this is the entry point of our program
            //first we populate the grid
            var grid = GridOperations.FillGrid();

            //we take the rest of the user input
            var input = CoordinatesAndNumberOfIterations();
            //reversing row,col ordering because of grid
            var rowWanted = input[1];
            var colWanted = input[0];
            var iterations = input[2];

            Console.WriteLine(GridOperations.IterateGrid(grid,iterations,rowWanted,colWanted));
        }

        private static int[] CoordinatesAndNumberOfIterations()
        {
            //input for coordinates of the wanted cell and number of iterations
            var input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            return input;
        }
    }
}
