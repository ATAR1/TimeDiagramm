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
    public class BarTests
    {
        [TestMethod()]
        public void BarBottomMustBeTopOfPreviousBar()
        {
            Bar bar = new BarMock();
            Bar bar2 = new Bar(new EmptyArea(), new Scale(10, 100), bar);
            Assert.IsTrue(bar.Top == bar2.Bottom);
            Assert.AreEqual(134, bar2.Bottom);
        }        
    }

    public class BarMock : Bar
    {
        public BarMock() : base(null, null, null)
        {
        }

        public override int Top => 134;
    }

    public class EmptyArea : ChartArea
    {
        public EmptyArea() : base(Empty)
        {
        }
    }

}