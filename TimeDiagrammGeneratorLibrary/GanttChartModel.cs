using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDiagrammGeneratorLibrary
{
    public class GanttChartModel
    {
        private ICollection<GraphModel> _graphs = new List<GraphModel>();

        public GanttChartModel(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime.AddMilliseconds(-1);
        }

        public IReadOnlyCollection<GraphModel> Graphs => _graphs.ToArray();
        
        public DateTime StartTime { get; private set; }
                
        public DateTime EndTime { get; private set; }

        public DateTime StartChartTime => new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, StartTime.Hour, 0, 0);

        public DateTime EndChartTime => new DateTime(EndTime.Year, EndTime.Month, EndTime.Day, EndTime.Hour, 59, 59, 999);


        public void AddGraph(string name, Interval[] intervals)
        {
            var intervals2 = intervals.RemoveIntervalsOutside(StartTime,EndTime);            
            var newGraph = new GraphModel(name, intervals2, Graphs.Count);
            _graphs.Add(newGraph);
        }

        public int GetStartCoord(Interval interval)
        {
            return (int)(interval.StartTime - StartChartTime).TotalSeconds;
        }

        internal int GetEndCoord(Interval interval)
        {
            return (int)(GetStartCoord(interval) + interval.Duration.TotalSeconds);
        }
    }

    public static class IntervalsUtils
    {
        public static IEnumerable<Interval> ToSplitBoundaryIntervals(this IEnumerable<Interval>  incomingSet)
        {
            var outcomingSet = new List<Interval>();
            foreach (var interval in incomingSet)
            {
                if (interval.StartTime.Hour != (interval.StartTime + interval.Duration).Hour)
                {
                    Tuple<Interval, Interval> pair = Interval.SplitInterval(interval);
                    outcomingSet.Add(pair.Item1);
                    outcomingSet.Add(pair.Item2);
                }
                else
                {
                    outcomingSet.Add(interval);
                }
            }
            return outcomingSet;
        }

        public static IEnumerable<Interval> RemoveIntervalsOutside(this IEnumerable<Interval> incomingSet, DateTime startTime, DateTime endTime)
        {
            return incomingSet.Where(i => i.StartTime >= startTime && i.StartTime < endTime);
        }
    }
}
