using System;
using System.Windows;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class CopyToClipBoardCommand : ICommand
    {
        private VM vM;

        public CopyToClipBoardCommand(VM vM)
        {
            this.vM = vM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Clipboard.Clear();
            IDataObject clips = new DataObject();
            clips.SetData(new[] { vM.Bitmap1 , vM.Bitmap2 , vM.Bitmap3 });
            Clipboard.SetDataObject(clips, true);
        }
    }
}