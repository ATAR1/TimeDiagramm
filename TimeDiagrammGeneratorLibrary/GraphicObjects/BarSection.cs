using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class BarSection
    {
        private BarSectionData barSectionData;
        private IScale _scale;

        public BarSection(Bar bar, BarSectionData barSectionData, BarSection previous)
        {
            this.barSectionData = barSectionData;
            _previous = previous;
            _scale = bar.Scale;
            _bar = bar;
        }

        BarSection _previous;
        private Bar _bar;

        public int Left => _previous == null ? _bar.Left : _previous.Right;
        public int Length => (int) barSectionData.Value * _scale.DotsPerDivision;

        private int Right => Left + Length;

        public int Top => _bar.Bottom -_bar.Margin*2 - _bar.BarHeight;

        public int Height => _bar.BarHeight;       

        public int SectionNum => _previous == null ? 0 : _previous.SectionNum + 1;

        public int GraphNum => _bar.GraphNum;

        public void Draw(Graphics gr)
        {
            Color[] colors = new[]
                                {
                                    Color.Green,
                                    Color.Blue,
                                    Color.LightGreen,
                                    Color.LightBlue
                                };

            
            Color color = colors[GraphNum];

            Brush[] brushes = new Brush[]
                               {
                                    new SolidBrush(color),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Red, color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Blue, color),
                               };
            Brush Brush = brushes[SectionNum];
            gr.FillRectangle(Brush, Left, Top, Length, Height);
            gr.DrawRectangle(new Pen(Color.Black), Left, Top, Length, Height);
        }
    }
}