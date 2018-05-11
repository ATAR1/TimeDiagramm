using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary
{
    public class IntervalDefectoscope:Interval
    {
        public int Speed { get; set; }

        public double? TubeLength { get; set; }

        public int TubeDiameter { get; set; }

        public int TubeThickness { get; set; }

        public int EstimatedSpeed { get; set; }

    }
}
