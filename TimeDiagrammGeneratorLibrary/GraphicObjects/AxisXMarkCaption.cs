using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class AxisXMarkCaption : VisibleChartObject
    {
        private AxisXMark _axisMark;

        public AxisXMarkCaption(AxisXMark axisMark)
        {
            _axisMark = axisMark;
        }

        public Font Font { get; set; } = new Font(FontFamily.GenericSansSerif, 10);
        public string Text { get; set; }
        public Color Color { get; private set; } = Color.Black;
        public override void Draw(Graphics gr)
        {
            gr.DrawString(Text, this.Font, new SolidBrush(this.Color), _axisMark.Left - gr.MeasureString(Text, Font).Width / 2, _axisMark.Top + Font.Height);
        }
    }
}
