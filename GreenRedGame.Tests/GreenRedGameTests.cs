using NUnit.Framework;

namespace GreenRedGame.Tests
{
    [TestFixture]
    public class GreenRedGameTests
    {

        [TestCase]
        public void FirstInputShouldWork()
        {
            int[,] input =
            {
                {0,0,0 },
                {1,1,1 },
                {0,0,0 }
            };
            
            var grid = new Grid(3, 3);
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Columns; col++)
                {
                    grid[row, col] = new Cell(input[row, col]);
                }
            }
            Assert.AreEqual(5, GridOperations.IterateGrid(grid, 10, 0, 1));
        }

        [TestCase]
        public void SecondInputShouldWork()
        {
            int[,] input =
            {
                {1,0,0,1 },
                {1,1,1,1 },
                {0,1,0,0 },
                {1,0,1,0 },
            };

            var grid = new Grid(4, 4);
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Columns; col++)
                {
                    grid[row, col] = new Cell(input[row, col]);
                }
            }
            Assert.AreEqual(14, GridOperations.IterateGrid(grid, 15, 2, 2));
        }

        [TestCase]
        public void ThirdInputShouldWork()
        {

            int[,] input =
            {
                {0,0,0 },
                {1,1,1},
                {0,0,0},
                {1,1,1},
            };
            var grid = new Grid(4, 3);
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Columns; col++)
                {
                    grid[row, col] = new Cell(input[row, col]);
                }
            }
            Assert.AreEqual(5, GridOperations.IterateGrid(grid, 5, 1, 0));
        }
        [TestCase]
        public void FourthInputShouldWork()
        {

            int[,] input =
            {
                {0,0,0},
                {0,0,0},
                {0,0,0},
                {0,0,0},
            };
            var grid = new Grid(4, 3);
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Columns; col++)
                {
                    grid[row, col] = new Cell(input[row, col]);
                }
            }
            Assert.AreEqual(0, GridOperations.IterateGrid(grid, 5, 1, 0));
        }

        [TestCase]
        public void FifthInputShouldWork()
        {

            int[,] input =
            {
                {1,1,1},
                {1,1,1},
                {1,1,1},
                {1,1,1},
            };
            var grid = new Grid(4, 3);
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Columns; col++)
                {
                    grid[row, col] = new Cell(input[row, col]);
                }
            }
            Assert.AreEqual(1, GridOperations.IterateGrid(grid, 5, 1, 0));
        }
    }
}
