using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeDiagrammGeneratorLibrary
{
    public class ChartString:GanttChartModel
    {
        public ChartString(DateTime startTime, DateTime endTime, int num):base(startTime,endTime)
        {
            Num = num;
        }
        
        public int Num { get; private set; }        

    }
}