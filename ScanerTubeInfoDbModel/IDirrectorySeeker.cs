using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanerTubeInfoDbModel
{
    public interface IDirectorySeeker
    {
        string Path { get; }
        bool GetDirectoryPath();
    }
}
