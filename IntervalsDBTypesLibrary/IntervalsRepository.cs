using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                try
                {


                    ctx.Intervals.AddRange(intervals);
                    ctx.SaveChanges();
                }
                catch(DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
