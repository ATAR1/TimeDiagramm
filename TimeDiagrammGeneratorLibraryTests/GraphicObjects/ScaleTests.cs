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
    public class ScaleTests
    {
        [TestMethod()]
        public void SplitTest()
        {
            Scale scale = new Scale(100, 1000);
            var marks = scale.DivideToEqualSegments(5);
            Assert.AreEqual(6, marks.Length);
            Assert.AreEqual(0, marks[0]);
            Assert.AreEqual(20, marks[1]);
            Assert.AreEqual(100, marks[5]);

        }

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

        [TestMethod()]
        public void DivideIntoSegmentsLengthOf40Test()
        {
            Scale scale = new Scale(100, 1000);
            var marks = scale.DivideIntoSegmentsLengthOf(40);
            Assert.AreEqual(3, marks.Length);
            Assert.AreEqual(0, marks[0]);
            Assert.AreEqual(40, marks[1]);
            Assert.AreEqual(80, marks[2]);
        }

        [TestMethod()]
        public void DivideIntoSegmentsLengthOf40StartFrom5Test()
        {
            Scale scale = new Scale(100, 1000);
            var marks = scale.DivideIntoSegmentsLengthOf(40,5);
            Assert.AreEqual(3, marks.Length);
            Assert.AreEqual(5, marks[0]);
            Assert.AreEqual(45, marks[1]);
            Assert.AreEqual(85, marks[2]);
        }
    }
}