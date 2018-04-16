using System;

namespace TimeDiagrammGeneratorLibrary
{
    public class Interval
    {
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Level { get; set; }

    }
}