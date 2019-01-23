using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeDiagrammGeneratorLibrary.GraphicObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects.Tests
{
    [TestClass()]
    public class BarStackTests
    {
        [TestMethod()]
        public void AddBarTest()
        {
            BarStack bars = new BarStack();
            Assert.AreEqual(0, bars.ToArray().Length);
            bars.AddBar("first chart",null,null, new string[0]);
            Assert.AreEqual(1, bars.ToArray().Length);
        }
    }
}