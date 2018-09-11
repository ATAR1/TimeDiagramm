using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalsDBTypesLibrary
{
    public class IntervalsRepository : IIntervalsRepository
    {
        public void Save(IEnumerable<Interval> intervals)
        {
            using (var ctx = new IntervalsDBModelContainer())
            {
                ctx.Intervals.AddRange(intervals);
                ctx.SaveChanges();
            }
        }
    }
}
