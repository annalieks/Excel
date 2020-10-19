using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Excel.Tests
{
    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void ExtractRefs_CheckExtraction_ExtractsAllRefs()
        {
            var grid = new DataGridView();
            var table = new Table(grid);
            var expected = new List<Position> { new Position("A0"), new Position("A4") };
            string expression = "A0+A4/32";
            var extracted = table.ExtractRefs(expression);
            Assert.AreEqual(expected.Count, extracted.Count);
            for(int i = 0; i < extracted.Count; i++)
            {
                Assert.AreEqual(expected[i].Name, extracted[i].Name);
                Assert.AreEqual(expected[i].Row, extracted[i].Row);
                Assert.AreEqual(expected[i].Column, extracted[i].Column);
            }
        }
    }
}