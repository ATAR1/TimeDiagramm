using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary
{
    public class BarChartGenerator
    {
        private Chart _chart;

        public BarChartGenerator(SplittedGanttChartModel model)
        {
            _chart = new Chart(1000, 300, 50);
            _chart.AddElement(new SeparatorY(_chart.InnerArea));
            _chart.AddElement(new SeparatorX(_chart.InnerArea));
            var chartAreaSplitted = new ChartAreaSplitted(_chart.InnerArea);
            foreach (var chartString in model.ChartStrings)
            {
                var chartString1 = chartAreaSplitted.CreateString();
                _chart.AddElement(new SeparatorY(chartString1));
                var captionY = new CaptionY(chartString1) { Caption = chartString.StartChartTime.Hour + " час." };
                _chart.AddElement(captionY);
                var bar = new Bar(chartString1)
                {
                    Values = new int[]
                    {
                        chartString.Graphs.First().Intervals.Where(i=>i.Level==1).Count()
                        ,chartString.Graphs.First().Intervals.Where(i => i.Level == 0).Count()
                        ,chartString.Graphs.First().Intervals.Where(i => i.Level == 2).Count()
                    }
                };
                _chart.AddElement(bar);
            }

        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(300, 1000);
            Graphics gr = Graphics.FromImage(bitmap);
            _chart.Draw(gr);
            return bitmap;
        }
    }
}
