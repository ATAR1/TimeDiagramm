using System;
using System.Drawing;
using System.Linq;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary
{
    public class BarChartGenerator
    {
        private Chart _chart;

        public BarChartGenerator(SplittedGanttChartModel model)
        {
            _chart = new Chart(1000, 300, 50);
            _chart.AddElement(new BottomBorder(_chart.InnerArea));
            _chart.AddElement(new LeftBorder(_chart.InnerArea));
            var chartAreaSplitted = new ChartAreaSplitted(_chart.InnerArea);
            foreach (var chartStringModel in model.ChartStrings)
            {
                var chartString = chartAreaSplitted.CreateString(chartAreaSplitted.Height/model.ChartStrings.Count);
                _chart.AddElement(new BottomBorder(chartString));
                var captionY = new CaptionY(chartString) { Caption = chartStringModel.StartChartTime.Hour + " час." };
                _chart.AddElement(captionY);
                var en = model.Graphs.First().Intervals.Where(i => (i.StartTime >= chartStringModel.StartChartTime) && (i.StartTime <= chartStringModel.EndChartTime));
                var Model = new[]
                    {
                        new BarSectionData() { Name = "Труб",  Value = en.Where(i => i.Level == 0).Count() },
                        new BarSectionData() { Name = "Образцов",  Value = en.Where(i => i.Level == 1).Count() },
                        new BarSectionData() { Name = "Повторов",  Value = en.Where(i => i.Level == 2).Count() }
                    };
                var bar = new BarWithCaption(chartString, new Scale(70, chartString.Width), null, Model);
                var barCaption = new Caption();
                barCaption.Text = Model[0].Value.ToString() + '/' + Model.Sum(s => s.Value).ToString();
                _chart.AddElement(bar);
                _chart.AddElement(barCaption);
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
