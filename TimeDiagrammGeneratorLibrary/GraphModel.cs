using System.Collections.Generic;

namespace TimeDiagrammGeneratorLibrary
{
    public class GraphModel
    {
        public GraphModel(string name, IEnumerable<Interval> intervals, int num)
        {
            Name = name;
            Intervals = intervals;
            Num = num;
        }

        public string Name { get; private set; }

        public IEnumerable<Interval> Intervals { get; private set; }
        public int Num { get; private set; }
    }
}