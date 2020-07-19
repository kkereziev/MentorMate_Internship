using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenRedGame.Tests
{
    [TestFixture]
    public class GreenRedGameTests
    {
        GridOperations gridOperations = new GridOperations();

        [TestCase]
        public void FirstInputShouldWork()
        {
            
            int[,] grid =
            {
                {0,0,0 },
                {1,1,1 },
                {0,0,0 }
            };
            Assert.AreEqual(5, gridOperations.IterateGrid(grid, 10, 0, 1));
        }

        [TestCase]
        public void SecondInputShouldWork()
        {

            int[,] grid =
            {
                {1,0,0,1 },
                {1,1,1,1 },
                {0,1,0,0 },
                {1,0,1,0 },
            };
            Assert.AreEqual(14, gridOperations.IterateGrid(grid, 15, 2, 2));
        }

        [TestCase]
        public void ThirdInputShouldWork()
        {

            int[,] grid =
            {
                {0,0,0 },
                {1,1,1},
                {0,0,0},
                {1,1,1},
            };
            Assert.AreEqual(5, gridOperations.IterateGrid(grid, 5, 1, 0));
        }
        [TestCase]
        public void FourthInputShouldWork()
        {

            int[,] grid =
            {
                {0,0,0},
                {0,0,0},
                {0,0,0},
                {0,0,0},
            };
            Assert.AreEqual(0, gridOperations.IterateGrid(grid, 5, 1, 0));
        }

        [TestCase]
        public void FifthInputShouldWork()
        {

            int[,] grid =
            {
                {1,1,1},
                {1,1,1},
                {1,1,1},
                {1,1,1},
            };
            Assert.AreEqual(5, gridOperations.IterateGrid(grid, 5, 1, 0));
        }
    }
}
