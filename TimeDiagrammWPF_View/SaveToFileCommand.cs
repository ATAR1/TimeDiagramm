using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

namespace TimeDiagrammWPF_View
{
    internal class SaveToFileCommand : ICommand
    {
        private readonly VM _vM;

        public SaveToFileCommand(VM vM)
        {
            this._vM = vM;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog() {Description = "Выберите папку в которую будут сохранены файлы.", ShowNewFolderButton = true };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileStream = File.Create(dlg.SelectedPath+"\\1.bmp");
                var InputStream = _vM.Diagramm;
                InputStream.Seek(0, SeekOrigin.Begin);
                InputStream.CopyTo(fileStream);
                fileStream.Close();

                fileStream = File.Create(dlg.SelectedPath + "\\2.bmp");
                InputStream = _vM.Diagramm2;
                InputStream.Seek(0, SeekOrigin.Begin);
                InputStream.CopyTo(fileStream);
                fileStream.Close();

                fileStream = File.Create(dlg.SelectedPath + "\\3.bmp");
                InputStream = _vM.Diagramm3;
                InputStream.Seek(0, SeekOrigin.Begin);
                InputStream.CopyTo(fileStream);
                fileStream.Close();
            }
            

        }
    }
}