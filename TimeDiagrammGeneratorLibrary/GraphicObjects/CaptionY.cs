using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class CaptionY : VisibleChartObject
    {

        public CaptionY(ChartArea ganttChartArea)
        {
            Owner = ganttChartArea;
        }

        public string Caption { get; set; }
        public Font Font { get;  set; } = new Font(FontFamily.GenericSansSerif, 10);

        public override void Draw(Graphics gr)
        {
            var stringSize = gr.MeasureString(Caption, Font);
            gr.DrawString(Caption, Font, Brushes.Black, Owner.Left - stringSize.Width, Owner.Bottom - Font.Height / 2);
        }
    }
}
