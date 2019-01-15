using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary
{
    public class BarChart : Chart
    {
        public BarChart(int height, int width, int margin, BarChartData barChartData) : base(height, width, margin)
        {
            AddElement(new BottomBorder(InnerArea));
            AddElement(new LeftBorder(InnerArea));
            Scale = new Scale(100, Width);
            SetData(barChartData);
        }



        private List<Bar> _bars = new List<Bar>();

        public IScale Scale { get; set; }
        
        public Bitmap Draw()
        {
            var bitmap = new Bitmap(Width, Height);
            
            Graphics gr = Graphics.FromImage(bitmap);
            Draw(gr);
            return bitmap;
        }

        public void SetActualHeight()
        {
            Height = _bars.Sum(b=>b.Height);
        }

        public void SetActualWidth()
        {
            Width = _bars.Max(b => b.Right)+Margin;
        }
        private void SetData(BarChartData barChartData)
        {
            Bar previousBar = null;         
            foreach (var barData in barChartData.Bars)
            {
                var bar = new BarWithCaption(InnerArea, Scale,previousBar, barData.Sections) { BarHeight = 40 };
                AddElement(bar);
                ((List<Bar>)_bars).Add(bar);
                bar.Caption.Text = barData.CaptionText;
                bar.Caption.Font = new Font(FontFamily.GenericSansSerif, 20);
                previousBar = bar;
            }
        }
    }
}
