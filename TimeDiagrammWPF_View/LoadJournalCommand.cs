using IntervalsDBTypesLibrary;
using JournalDbModel;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class LoadJournalCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<Interval> intervals = new List<Interval>();
            var repository = new TestAndTunesUptimesRepository();
            foreach (var record in repository.GetRecord(new DateTime(2018, 5, 22)))
            {
                intervals.Add(new IntervalWithDescription()
                {
                    StartTime = record.StartDate
                    ,Duration = record.Duration
                    ,Object = record.Defectoscope
                    ,SpecialLevel = record.SpecialLevel
                    ,SpecialLevelDescription = record.SpecialLevelDescription
                });
            }

            using (var ctx = new IntervalsDBModelContainer())
            {
                ctx.Intervals.AddRange(intervals);
                ctx.SaveChanges();
            }
        }
    }
}