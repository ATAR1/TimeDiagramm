﻿using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class AxisXMark : VisibleChartObject
    {
        private AxisX _axis;

        public AxisXMark(AxisX axis, int x)
        {
            this._axis = axis;
            this.X = x;
        }

        public int Left => _axis.Left + X * _axis.PixelsPerDegree;

        public int Length { get; set; } = 5;
        public Pen Pen { get; set; } = new Pen(Color.Black, 2);

        public int Top => _axis.Bottom;
        public int X { get; private set; }


        public override void Draw(Graphics gr)
        {
            gr.DrawLine(Pen, Left, Top, Left, Top + Length);
        }
    }
}
