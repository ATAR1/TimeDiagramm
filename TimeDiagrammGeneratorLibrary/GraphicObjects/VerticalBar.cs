using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class VerticalBar : VisibleChartObject
    {
        public VerticalBar(ChartArea owner)
        {
            this.Owner = owner;
        }

        public int Value { get;  set; }
        public int X { get;  set; }

        public override void Draw(Graphics gr)
        {
            gr.DrawLine(new Pen(Color.Green,2),Owner.Left + X, Owner.Bottom, Owner.Left + X, Owner.Bottom + Value);
        }
    }
}
