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
    public class BarChartTests
    {
        [TestMethod()]
        public void BarChartTest()
        {
            BarChart chart = new BarChart(new Scale(1,1));
            chart.AddBar("first bar");
            chart.AddBar("Second Bar");
            chart.AddCategory("first category");
            chart.AddCategory("second category");
            chart.AddCategory("thrird category");
            chart.Bars["first bar"].Sections["thrird category"].Value = 30;
            Assert.AreEqual(30, chart.Bars["first bar"].Sections["thrird category"].Value);


        }

        [TestMethod()]
        public void SetDataTest()
        {
            const int grapfsCount = 2;
            const int sectionsCount = 3;
            var graphNames = new string[grapfsCount] { "МДТ6", "Сканер" };
            var sectionNames = new string[sectionsCount] { "Прошло труб", "Повторы", "Образцы" };
            var values = new int[grapfsCount][] { new int[sectionsCount] { 10, 20, 5 }, new int[sectionsCount] { 10, 3, 8 } };
            BarChart chart = new BarChart(new Scale(1,1));
            chart.SetData(graphNames, sectionNames,  values);
            Assert.AreEqual(8, chart.Bars["Сканер"].Sections["Образцы"].Value);
        }
    }
}