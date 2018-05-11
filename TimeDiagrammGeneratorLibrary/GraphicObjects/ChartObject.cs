using System.Drawing;

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
