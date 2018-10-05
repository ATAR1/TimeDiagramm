using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class BarCaption : VisibleChartObject
    {
        private Bar _bar;
        private string _text;

        public BarCaption(ChartArea owner,Bar bar, string text)
        {
            this._bar = bar;
            Owner = owner;
            _text = text;
        }

        public Font Font { get; set; } = new Font(FontFamily.GenericSansSerif, 10);

        public override void Draw(Graphics gr)
        {
            var h= Font.GetHeight(gr);
            gr.DrawString(_text,Font, Brushes.Black, _bar.Right, _bar.Top-h);
        }
    }
}
