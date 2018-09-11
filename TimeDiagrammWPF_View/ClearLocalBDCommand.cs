using IntervalsDBTypesLibrary;
using System;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class ClearLocalBDCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public string DisplayName => "Очистить локалную БД";

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            using (var ctx = new IntervalsDBModelContainer())
            {
                ctx.Database.ExecuteSqlCommand("delete from IntervalSet \n dbcc checkident('IntervalSet', reseed, 0)");
            }
        }
    }
}