using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class AuxiliaryLine : VisibleChartObject
    {
        private AxisX _axis;
        private ChartArea _chartArea;

        public AuxiliaryLine(ChartArea chartArea,AxisX axis,int x)
        {
            _axis = axis;
            X = x;
            _chartArea = chartArea;
        }
        public int X { get; private set; }

        public Color Color { get;  set; } = Color.Black;
        public float Weight { get;  set; } = 1;
        public float[] DashPattern { get;  set; } = new float[] { 5, 10 };

        public override void Draw(Graphics gr)
        {            
            var left = _chartArea.Left+X * _axis.PixelsPerDegree;
            var pen = new Pen(this.Color, this.Weight) { DashPattern = this.DashPattern };
            gr.DrawLine(pen, left, _chartArea.Bottom, left, _chartArea.Top);
        }
    }

    

    

    

}