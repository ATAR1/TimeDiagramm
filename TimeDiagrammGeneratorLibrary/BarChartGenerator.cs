﻿using System;
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
            _chart = new Chart() { Height = 1000, Width = 300, Margin = 50 };
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
                var scale = new Scale(70, chartString.Width);
                var bar = new BarWithCaption(chartString, scale, null);
                bar.AddSection("Труб").Value = en.Where(i => i.Level == 0).Count();
                bar.AddSection("Образцов").Value = en.Where(i => i.Level == 1).Count();
                bar.AddSection("Повторов").Value = en.Where(i => i.Level == 2).Count();
                bar.Caption.Text = bar.Sections.ToArray()[0].Value.ToString() + '/' + bar.Sections.ToArray().Sum(s => s.Value).ToString();
                _chart.AddElement(bar);
                en = model.Graphs.ToArray()[1].Intervals.Where(i => (i.StartTime >= chartStringModel.StartChartTime) && (i.StartTime <= chartStringModel.EndChartTime));
                bar = new BarWithCaption(chartString, scale, bar) { ColorNum = 1};
                bar.AddSection("Труб").Value = en.Where(i => i.Level == 0).Count();
                bar.AddSection("Образцов").Value = en.Where(i => i.Level == 1).Count();
                bar.AddSection("Повторов").Value = en.Where(i => i.Level == 2).Count();
                bar.Caption.Text = bar.Sections.ToArray()[0].Value.ToString() + '/' + bar.Sections.ToArray().Sum(s => s.Value).ToString();
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
