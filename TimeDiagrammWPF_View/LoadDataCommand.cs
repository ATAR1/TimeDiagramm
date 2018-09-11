using IntervalsDBTypesLibrary;
using System;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    public class LoadDataCommand : ICommand
    {
        private IntervalSource _source;
        private IDateTimeInterval _dateTimeIntervalContainer;
        private IIntervalsRepository _intervalsRepository = new IntervalsRepository();

        public LoadDataCommand(string commandDisplayName, IntervalSource source, IDateTimeInterval dateTimeIntervalContainer, IIntervalsRepository intervalsRepository = null)
        {
            if(intervalsRepository!=null) _intervalsRepository = intervalsRepository;
            _source = source;
            _dateTimeIntervalContainer = dateTimeIntervalContainer;            
            DisplayName = commandDisplayName;
        }

        public event EventHandler CanExecuteChanged;

        public DateTime BeginTime => _dateTimeIntervalContainer.BeginTime;

        public DateTime EndTime => _dateTimeIntervalContainer.EndTime;

        public string DisplayName { get; set; }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var intervals = _source.GetData(BeginTime, EndTime);

            _intervalsRepository.Save(intervals);
        }
    }
}
