using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary
{
    public class HistogramGenerator
    {
        private Chart _chart;

        public HistogramGenerator(SplittedGanttChartModel model)
        {
            _chart = new Chart(1000, 300, 50);
            _chart.AddElement(new BottomBorder(_chart.InnerArea));
            _chart.AddElement(new LeftBorder(_chart.InnerArea));
            var chartAreaSplitted = new ChartAreaSplitted(_chart.InnerArea);
            Interval oldInterval = null;
            foreach (var chartString in model.ChartStrings)
            {
                var chartString1 = chartAreaSplitted.CreateString();
                _chart.AddElement(new BottomBorder(chartString1));
                var gantChartArea = new GanttChartArea(chartString1);
                var captionY = new CaptionY(chartString1) { Caption = chartString.StartChartTime.Hour + " час." };
                _chart.AddElement(captionY);
                
                foreach (var interval in model.Graphs.First().Intervals.Where(i=>(i.StartTime>=chartString.StartChartTime)&& (i.StartTime <= chartString.EndChartTime)).OrderBy(i=>i.StartTime))
                {
                    int value = (oldInterval == null) ? 0 : (int)(oldInterval.Duration.TotalSeconds/60 / (oldInterval.StartTime - interval.StartTime).TotalHours);
                    var bar = new VerticalBar(gantChartArea) { X = Convert.ToInt32(chartString.GetStartCoord(interval) * gantChartArea.PixelPerSecond), Value = value };
                    _chart.AddElement(bar);
                    oldInterval = interval;
                }                
                
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
