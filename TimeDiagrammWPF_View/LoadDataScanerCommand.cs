using IntervalsDBTypesLibrary;
using ScanerTubeInfoDbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class LoadDataScanerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<Interval> intervals = new List<Interval>();
            using (var scanerCtx = new ScanerTubeInfoEntities())
            {
                var scanerTubes = scanerCtx.ScanerTubeInfoes.Where(t => t.Date >= new DateTime(2018, 5, 1)).ToList();
                intervals.AddRange(scanerTubes.Select(t => new Interval()
                {
                    Object = "Сканер",
                    StartTime = t.Date+TimeSpan.FromMinutes(5),
                    SpecialLevel = (int)t.TubeStatus,
                    Duration = TimeSpan.FromSeconds(t.Speed != 0 ? (int)(t.Length * 1.0 / t.Speed) : 0)
                }));
            }

            using (var ctx = new IntervalsDBModelContainer())
            {
                ctx.Intervals.AddRange(intervals);
                ctx.SaveChanges();
            }
        }
    }
}