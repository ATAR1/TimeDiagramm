using IntervalsDBTypesLibrary;
using System;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class ClearLocalBDCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            using (var ctx = new IntervalsDBModelContainer())
            {
                ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE IntervalSet");
            }
        }
    }
}