using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary
{
    public class BarChartData
    {
        public BarData[] Bars { get; set; }
    }

    public class BarData
    {
        public string CaptionText { get; set; }
        public string Name { get; set;  }
        public BarSectionData[] Sections {get; set;}
    }

    public class BarSectionData
    {
        public string Name { get; set; }
        public float Value { get; set; }
    }
}
