using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary
{
    public class SplittedGanttChartModel:GanttChartModel
    {

        public SplittedGanttChartModel(DateTime startTime, DateTime endTime) : base(startTime, endTime)
        {
            
        }

        private IReadOnlyCollection<ChartString> SplitOnLines(GanttChartModel model)
        {
            var result = new List<ChartString>();
            int i = 0;
            for (DateTime startTime = model.StartChartTime; startTime < model.EndChartTime; startTime = startTime.AddHours(1))
            {
                var chartString = new ChartString(startTime, startTime.AddMilliseconds(3599999), i++);
                foreach (var graph in model.Graphs)
                {
                    chartString.AddGraph(graph.Name, graph.Intervals.ToSplitBoundaryIntervals().ToArray());
                }
                result.Add(chartString);
            }
            return result;
        }

        public IReadOnlyCollection<ChartString> ChartStrings => SplitOnLines(this);
    }
}
