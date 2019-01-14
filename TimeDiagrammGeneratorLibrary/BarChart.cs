using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary
{
    public class BarChart : Chart
    {
        public BarChart(int height, int width, int margin) : base(height, width, margin)
        {
            AddElement(new BottomBorder(InnerArea));
            AddElement(new LeftBorder(InnerArea));
            Scale = new Scale(100, Width);
            
        }



        public IEnumerable<Bar> Bars { get; private set; } = new List<Bar>();

        public IScale Scale { get; set; }
        
        private void RemoveAllBars()
        {
            foreach (var bar in Bars)
            {
                RemoveElement(bar);
            }
            ((List<Bar>)Bars).Clear();
        }

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(Width, Height);
            
            Graphics gr = Graphics.FromImage(bitmap);
            Draw(gr);
            return bitmap;
        }

        public void SetActualHeight()
        {
            Height = Bars.Sum(b=>b.Height);
        }

        public void SetActualWidth()
        {
            Width = Bars.Max(b => b.Right);
        }
        public void SetData(BarChartData barChartData)
        {
            RemoveAllBars();
            Bar previousBar = null;         
            foreach (var barData in barChartData.Bars)
            {
                var bar = new BarWithCaption(InnerArea, Scale,previousBar) { GraphNum = Bars.Count(), Sections = barData.Sections, BarHeight = 40 };
                AddElement(bar);
                ((List<Bar>)Bars).Add(bar);
                bar.Caption.Text = barData.CaptionText;
                bar.Caption.Font = new Font(FontFamily.GenericSansSerif, 20);
                previousBar = bar;
            }
        }
    }
}
