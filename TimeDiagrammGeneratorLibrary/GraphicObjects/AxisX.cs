using System.Collections.Generic;
using System.Linq;

namespace TimeDiagrammGeneratorLibrary.GraphicObjects
{
    public class AxisX:ChartArea
    {

        public AxisX(Scale scale,ChartArea owner):base(owner)
        {            
            Scale = scale;            
        }
                        
        public IEnumerable<AxisXMark> Marks { get; set; }
        public IScale Scale { get; }      
        
    }
}