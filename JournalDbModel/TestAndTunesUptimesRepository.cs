using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JournalDbModel
{
    public class TestAndTunesUptimesRepository
    {
        public IEnumerable<TestAndTuneUptime> GetRecord(DateTime fromDate)
        {
            using (var ctx = new JournalDbEntities())
            {
                return ctx.JournalRecords.Include("Operation.Work").Where(jr => jr.Date >= fromDate).ToList()
                    .Select(jr =>
                    {
                        var startDate = jr.Start < TimeSpan.FromHours(8) ? jr.Date.AddDays(1) + jr.Start : jr.Date + jr.Start;
                        var endDate = jr.End <= TimeSpan.FromHours(8) ? jr.Date.AddDays(1) + jr.End : jr.Date + jr.End;
                        int specialLevel=-1;
                        switch(jr.Operation.Work.OperationGroup)
                        {
                            case ("Настройка"):
                                specialLevel = 0;
                                break;
                            case ("Проверка"):
                                specialLevel = 1;
                                break;
                            case ("Сопутствующие"):
                                specialLevel = 2;
                                break;
                            case ("Ремонт"):
                                specialLevel = 3;
                                break;
                            case ("Неисправность"):
                                specialLevel = 4;
                                break;
                        }
                        return new TestAndTuneUptime { StartDate = startDate, Duration = endDate-startDate, SpecialLevel = specialLevel, SpecialLevelDescription = jr.Operation.Work.OperationGroup, Defectoscope ="УНСК."+jr.WorkArea+"."+jr.DefectoscopeName };
                    });
            }
        }
    }

    public class TestAndTuneUptime
    {
        public string Defectoscope { get; set; }
        public DateTime StartDate { get; set; }

        public TimeSpan Duration { get; set; }

        public int SpecialLevel { get; set; }
        public string SpecialLevelDescription { get; internal set; }
    }
}
