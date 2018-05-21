using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScanerTubeInfoDbModel
{
    public class ScanerRepository
    {
        public ICollection<ScanerTubeInfo> GetAllRecords()
        {
            using (var ctx = new ScanerTubeInfoEntities())
            {
                return ctx.ScanerTubeInfoes.ToArray();
            }
        }
    }
}
