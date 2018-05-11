using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class BarCaption : VisibleChartObject
    {
        private Bar _bar;

        public BarCaption(ChartArea owner,Bar bar)
        {
            this._bar = bar;
            Owner = owner;
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawString(_bar.A1.ToString()+'/'+ _bar.A.ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, Owner.Left+_bar.A*3, _bar.Top-4);
        }
    }
}
