using Microsoft.Win32;
using ScanerTubeInfoDbModel;
using System;

namespace TimeDiagrammWPF_View
{
    public class FileSeeker : IFileSeeker
    {    
        public string GetFileName(string forObject)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = forObject;
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }
    }
}