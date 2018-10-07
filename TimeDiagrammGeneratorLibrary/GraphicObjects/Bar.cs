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
        private IScale _scale;

        public Bar(ChartArea owner,IScale scale, int bottom, int diagramNum)
        {
            Owner = owner;
            _scale = scale;
            Bottom = bottom - Margin;
            _diagramNum = diagramNum;
        }
        
        public int BarHeight { get; set; } = 10;

        public int Bottom { get; set; }

        public float Top => Bottom-BarHeight;

        public int Right => Values.Sum()*_scale.ValueOfDivision+Owner.Left;

        public int[] Values { get; set; }

        public int Margin { get; private set; } = 5;

        Brush[] Brushes => new Brush[]
                                {
                                    new SolidBrush(_colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, _colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, _colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Red, _colors[_diagramNum]),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Blue, _colors[_diagramNum]),
                                };

        public int Height => BarHeight + Margin * 2;

        Color[] _colors = new[]
        {
            Color.Green,
            Color.Blue,
            Color.LightGreen,
            Color.LightBlue
        };


        public override void Draw(Graphics gr)
        {
            var left = Owner.Left;
            for (int i = 0; i < Values.Length; i++)
            {
                var value = Values[i] * _scale.ValueOfDivision;
                gr.FillRectangle(Brushes[i], left, Top, value, BarHeight);
                gr.DrawRectangle(new Pen(Color.Black), left, Top, value, BarHeight);
                left += value;
            }
        }
    }
}
