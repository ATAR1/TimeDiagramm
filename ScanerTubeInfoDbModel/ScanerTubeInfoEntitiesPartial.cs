using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanerTubeInfoDbModel
{
    partial class ScanerTubeInfoEntities
    {
        

        public ScanerTubeInfoEntities(string connStr):base(connStr)
        {
            
        }
    }
    
}
