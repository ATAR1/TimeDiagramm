using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Caption : VisibleChartObject
    {        
        public string Text { get; set; }
        public Font Font { get; set; } = new Font(FontFamily.GenericSansSerif, 10);
        public int Height => (int)Graphics.FromImage(new Bitmap(1, 1)).MeasureString(Text, Font).Height;
        public int Left { get; internal set; }
        public int Bottom { get; internal set; }
        public int Width => (int)Graphics.FromImage(new Bitmap(1, 1)).MeasureString(Text,Font).Width;               
        public override void Draw(Graphics gr)
        {
            gr.DrawString(Text,Font, Brushes.Black, Left, Bottom-Height);
        }
    }
}
