using IntervalsDBTypesLibrary;
using MDT6DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class LoadMDT6DataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<Interval> intervals = new List<Interval>();
            using (var mdt6Ctx = new MDT6DBEntities())
            {
                var mdt6Tubes = mdt6Ctx.Tubes.Where(t => t.tCreatedDate >= new DateTime(2018,5,1)).ToList();
                intervals.AddRange(mdt6Tubes.Select(t => new Interval() {
                    Object = "МДТ 6",
                    StartTime = t.tCreatedDate,
                    SpecialLevel = String.IsNullOrWhiteSpace( t.note ) ? 0 : 1,
                    Duration =TimeSpan.FromSeconds(  t.speedt != 0 ? (int)(t.lent * 10.0 / t.speedt) : 0)
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