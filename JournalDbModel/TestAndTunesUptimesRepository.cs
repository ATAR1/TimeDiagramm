using IntervalsDBTypesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JournalDbModel
{
    public class TestAndTunesUptimesRepository:IntervalSource
    {
        public override IEnumerable<Interval> GetData(DateTime beginTime, DateTime endTime)
        {
            using (var ctx = new JournalDbEntities())
            {
                var list = ctx.JournalRecords.Include("Operation.Work").Where(jr => jr.Date >= beginTime && jr.Date < endTime).ToList();
                return list.Select(jr =>
                { 
                    return new Interval()
                    {
                        Duration = jr.Duration,
                        Object = "УНСК." + jr.WorkArea + "." + jr.DefectoscopeName,
                        SpecialLevel = SpecialLevelDictionary.GetSpecialLevelByName(jr.Operation.Work.OperationGroup),
                        StartTime = jr.StartDate
                    };
                });
            }
        }
    }
}
