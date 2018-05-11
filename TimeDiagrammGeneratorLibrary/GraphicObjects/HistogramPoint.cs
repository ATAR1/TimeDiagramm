using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class HistogramPoint : VisibleChartObject
    {

        public HistogramPoint(TimeChartArea timeChartArea)
        {
            Owner = timeChartArea;
        }

        public int Value { get;  set; }
        public int X { get;  set; }

        public override void Draw(Graphics gr)
        {
            gr.FillRectangle(Brushes.Red, Owner.Left + X - 1, Owner.Bottom - Value, 2, 2);
        }
    }
}
