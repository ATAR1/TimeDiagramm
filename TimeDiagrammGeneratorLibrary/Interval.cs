using System;

namespace TimeDiagrammGeneratorLibrary
{
    public class Interval
    {
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Level { get; set; }

        public static Tuple<Interval, Interval> SplitInterval(Interval sourceInterval)
        {
            DateTime nxtH = new DateTime(sourceInterval.StartTime.Year, sourceInterval.StartTime.Month, sourceInterval.StartTime.Day, sourceInterval.StartTime.Hour, 0, 0).Add(new TimeSpan(1, 0, 0));
            Interval firstInterval = new Interval()
            {
                StartTime = sourceInterval.StartTime,
                Duration = nxtH.Add(TimeSpan.FromMilliseconds(-1)) - sourceInterval.StartTime,
                Level = sourceInterval.Level
            };
            Interval secondInterval = new Interval()
            {
                StartTime = nxtH,
                Duration = sourceInterval.Duration - firstInterval.Duration,
                Level = sourceInterval.Level
            };

            return new Tuple<Interval, Interval>(firstInterval, secondInterval);
        }
        
    }
}