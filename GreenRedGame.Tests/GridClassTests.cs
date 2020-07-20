using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenRedGame.Tests
{
    [TestFixture]
    public class GridClassTests
    {

        [TestCase]
        public void TestRowPropertyOfClass()
        {
            var grid = new Grid(1, 1);
            Assert.AreEqual(1, grid.Row);
        }

        [TestCase]
        public void TestColumnPropertyOfClass()
        {
            var grid = new Grid(1, 1);
            Assert.AreEqual(1, grid.Column);
        }

        [TestCase]
        public void TestIndexingOfClass()
        {
            var grid = new Grid(1, 1);
            Exception coughtException = null;
            try
            {
                var value=grid[4, 4];
            }
            catch (Exception ex)
            {
                coughtException = ex;
            }
            Assert.AreEqual(coughtException.Message, "Out of range!");
        }

        [TestCase]
        public void TestIndexingOfClassWithNegativeNumber()
        {
            var grid = new Grid(1, 1);
            Exception coughtException = null;
            try
            {
                var value = grid[-1, 4];
            }
            catch (Exception ex)
            {
                coughtException = ex;
            }
            Assert.AreEqual(coughtException.Message, "Out of range!");
        }
    }
}
