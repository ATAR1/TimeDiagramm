using System;
using System.Windows.Forms;
using System.IO;
using ScanerTubeInfoDbModel;

namespace TimeDiagrammWPF_View
{
    internal class DirectorySeeker : IDirectorySeeker
    {
        public string Path { get; private set; }

        public bool GetDirectoryPath()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog() { ShowNewFolderButton = false, Description = "Выберите папку с данными сканера." };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.Path = dlg.SelectedPath;
                return true;
            }
            return false;
        }
    }
}