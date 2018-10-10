using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class Bar : VisibleChartObject
    {
        private int _diagramNum;

        private GraphParameters _parameters;

        public Bar(ChartArea owner, GraphParameters parameters)
        {
            Owner = owner;
            _diagramNum = parameters.GraphNum;
            _parameters = parameters;
        }


        public IScale Scale { get; set; }

        public int Bottom { get; set; }

        public int Top => Bottom - Height;

        public int Right => (int)Math.Ceiling(Sections.Sum(s=>s.Value)*Scale.DotsPerDivision+Owner.Left);        

        Brush[] Brushes => new Brush[]//
                                {
                                    new SolidBrush(_colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, _colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, _colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Red, _colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Blue, _colors[_diagramNum]),
                                };

        public int Height => _parameters.BarHeight + _parameters.BarMargin * 2;

        public BarSectionData[] Sections { get; set; }

        Color[] _colors = new[]
        {
            Color.Green,
            Color.Blue,
            Color.LightGreen,
            Color.LightBlue
        };
        

        public override void Draw(Graphics gr)
        {
            var left = (float)Owner.Left;
            float barHeight = _parameters.BarHeight;
            float barTop = Bottom - _parameters.BarHeight - _parameters.BarMargin;
            for (int i = 0; i < Sections.Length; i++)
            {
                var barWidth = Sections[i].Value * Scale.DotsPerDivision;                
                gr.FillRectangle(Brushes[i], left, barTop, barWidth, barHeight);
                gr.DrawRectangle(new Pen(Color.Black), left, barTop, barWidth, barHeight);
                left += barWidth;
            }
        }
    }
}
