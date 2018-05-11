﻿using System;
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

        public Bar(ChartArea owner)
        {
            Owner = owner;
        }

        public int[] Values { get; set; }

        Brush[] Brushes => new Brush[]
        {
            new SolidBrush(_color),
            new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Black, _color),
            new HatchBrush(HatchStyle.Cross, Color.White, _color)
        };
        public override void Draw(Graphics gr)
        {
            var left = Owner.Left;
            for (int i = 0; i < Values.Length; i++)
            {
                var value = Values[i] * 3;
                gr.FillRectangle(Brushes[i], left, Owner.Bottom - 15, value, 10);
                gr.DrawRectangle(new Pen(Color.Black), left, Owner.Bottom - 15, value, 10);
                left += value;
            }
        }
    }
}