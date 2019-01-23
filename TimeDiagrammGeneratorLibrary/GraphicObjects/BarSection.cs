using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class BarSection
    {
        private IScale _scale;

        public BarSection(Bar bar, BarSection previous, int brushNum, int colorNum)
        {
            _previous = previous;
            _scale = bar.Scale;
            _bar = bar;
            BrushNum = brushNum;
            ColorNum = colorNum;
        }

        BarSection _previous;
        private Bar _bar;

        public int Left => _previous == null ? _bar.Left : _previous.Right;
        public int Length => (int) Value * _scale.DotsPerDivision;

        private int Right => Left + Length;

        public int Top => _bar.Bottom -_bar.Margin*2 - _bar.BarHeight;

        public int Height => _bar.BarHeight;
        
        public int Value { get; set; }
        public int BrushNum { get; private set; }
        public int ColorNum { get; private set; }

        public void Draw(Graphics gr)
        {
            Color[] colors = new[]
                                {
                                    Color.Green,
                                    Color.Blue,
                                    Color.LightGreen,
                                    Color.LightBlue
                                };

            Color color = colors[ColorNum];

            Brush[] brushes = new Brush[]
                               {
                                    new SolidBrush(color),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Red, color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Blue, color),
                               };
            Brush Brush = brushes[BrushNum];
            gr.FillRectangle(Brush, Left, Top, Length, Height);
            gr.DrawRectangle(new Pen(Color.Black), Left, Top, Length, Height);
        }
    }
}