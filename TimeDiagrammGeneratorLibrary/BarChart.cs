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
            _top = InnerArea.Bottom;
            Scale = new Scale(100, Width);
            
        }

        //private void AddBar(float[] values)
        //{
        //    var bar = new Bar(InnerArea,  new GraphParameters(_graphsCount++) { BarHeight = 40 }) { Scale = Scale, Values = values,   Bottom = _top };
        //    AddElement(bar);
        //    ((List<Bar>)Bars).Add(bar);
        //    var barCaption = new BarCaption(InnerArea, bar, bar.Values[0].ToString() + '/' + bar.Values.Sum().ToString());
        //    barCaption.Font = new Font(FontFamily.GenericSansSerif, 20);
        //    AddElement(barCaption);
        //    _top -= (bar.Height+ barCaption.Height);//todo
        //}

        int _top;

        int _graphsCount = 0;

        public IEnumerable<Bar> Bars { get; private set; } = new List<Bar>();

        public IScale Scale { get; set; }

        //public void SetData(float[][] value)
        //{
        //    RemoveAllBars();
        //    foreach (var diagramData in value)
        //    {
        //        AddBar(diagramData);
        //    }
        //}

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
            var bitmap = new Bitmap(Height, Width);
            
            Graphics gr = Graphics.FromImage(bitmap);
            Draw(gr);
            return bitmap;
        }

        public void SetData(BarChartData barChartData)
        {
            RemoveAllBars();
            foreach (var barData in barChartData.Bars)
            {
                AddBar(barData);
            }
        }

        private void AddBar(BarData barData)
        {
            var bar = new Bar(InnerArea, new GraphParameters(barData.BarNum) { BarHeight = 40 }) { Scale = Scale, Sections = barData.Sections, Bottom = _top };
            AddElement(bar);
            ((List<Bar>)Bars).Add(bar);
            var barCaption = new BarCaption(InnerArea, bar, barData.CaptionText);
            barCaption.Font = new Font(FontFamily.GenericSansSerif, 20);
            AddElement(barCaption);
            _top -= (bar.Height + barCaption.Height);//todo
        }
    }
}
