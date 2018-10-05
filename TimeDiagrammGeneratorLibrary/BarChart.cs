using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TimeDiagrammGeneratorLibrary.GraphicObjects;

namespace TimeDiagrammGeneratorLibrary
{
    public class BarChart : Chart, IScale
    {
        public BarChart(int height, int width, int margin) : base(height, width, margin)
        {
            AddElement(new BottomBorder(InnerArea));
            AddElement(new LeftBorder(InnerArea));
            
            
        }

        public void AddBar(int[] values)
        {
            var bar = new Bar(InnerArea, this) { Values = values, Width = 40 };
            AddElement(bar);
            var barCaption = new BarCaption(InnerArea, bar, bar.Values[0].ToString() + '/' + bar.Values.Sum().ToString());
            barCaption.Font = new Font(FontFamily.GenericSansSerif, 30);
            AddElement(barCaption);
        }

        public int MaxValue { get; set; } = 100;

        public int ValueOfDivision => Width / MaxValue;

        public Bitmap Draw()
        {
            var bitmap = new Bitmap(Height, Width);
            
            Graphics gr = Graphics.FromImage(bitmap);
            Draw(gr);
            return bitmap;
        }
    }
}
