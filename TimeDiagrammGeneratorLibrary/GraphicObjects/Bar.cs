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
        private Color _color = Color.Green;
        private IScale _scale;

        public Bar(ChartArea owner,IScale scale)
        {
            Owner = owner;
            _scale = scale;
        }
        
        public int Width { get; set; } = 10;

        public int Bottom => Owner.Bottom - Margin;//todo

        public float Top => Bottom-Width;

        public int Right => Values.Sum()*_scale.ValueOfDivision+Owner.Left;

        public int[] Values { get; set; }

        public int Margin { get; private set; } = 10;

        Brush[] Brushes => new Brush[]
                                {
                                    new SolidBrush(_color),
                                    new HatchBrush(HatchStyle.ForwardDiagonal, Color.Black, _color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.White, _color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Red, _color),
                                    new HatchBrush(HatchStyle.DiagonalCross, Color.Blue, _color),
                                };

        
        public override void Draw(Graphics gr)
        {
            var left = Owner.Left;
            for (int i = 0; i < Values.Length; i++)
            {
                var value = Values[i] * _scale.ValueOfDivision;
                gr.FillRectangle(Brushes[i], left, Top, value, Width);
                gr.DrawRectangle(new Pen(Color.Black), left, Top, value, Width);
                left += value;
            }
        }
    }
}
