using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public abstract class ChartObject
    {   
        protected ChartArea Owner { get; set; }
        
    }

    public abstract class VisibleChartObject : ChartObject
    {
        public abstract void Draw(Graphics gr);

    }
}
