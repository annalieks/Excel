using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Excel.Tests
{
    [TestClass()]
    public class CellTests
    {
        [TestMethod()]
        public void CheckLoop_Itself_ReturnsTrue()
        {
            var grid = new DataGridView();
            var cellA0 = new Cell(grid, 0, 0);
            Assert.IsTrue(cellA0.CheckLoop(cellA0));
        }

        [TestMethod()]
        public void CheckLoop_CircularDependency_ReturnsTrue()
        {
            var grid = new DataGridView();
            var cellA0 = new Cell(grid, 0, 0);
            var cellB0 = new Cell(grid, 0, 1);
            cellA0.AddDependency(cellB0);
            Assert.IsTrue(cellB0.CheckLoop(cellA0));
        }
    }
}