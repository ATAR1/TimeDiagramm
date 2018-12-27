using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeDiagrammGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary.Tests
{
    [TestClass()]
    public class ScaleTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ScaleMustHavePositiveSize()
        {
            var scale = new Scale(-1, 1000);
        }

        [TestMethod()]
        public void ScaleMustKeepSize()
        {
            var size = 10;
            var scale = new Scale(size, 1000);
            Assert.AreEqual(size, scale.Size);
        }

        [TestMethod]
        public void ScaleMustProvideResolution()
        {
            var size = 10;
            var width = 130;
            var scale = new Scale(size, width);
            Assert.AreEqual(13, scale.DotsPerDivision);
        }
    }
}