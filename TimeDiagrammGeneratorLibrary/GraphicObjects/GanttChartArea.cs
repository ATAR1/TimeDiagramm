using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class GanttChartArea : ChartArea
    {
        public GanttChartArea(ChartArea owner):base(owner)
        {
        }     
        public double PixelPerSecond => Width *1.0/ 3600;

        public int StartHour { get; set; } 
    }

    


}
