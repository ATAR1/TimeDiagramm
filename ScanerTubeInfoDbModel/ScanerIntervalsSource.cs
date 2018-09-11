using IntervalsDBTypesLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SQLite;
using System.Linq;

namespace ScanerTubeInfoDbModel
{
    public class ScanerIntervalsSource : IntervalSource
    {
        private IFileSeeker _fileSeeker;
        private string _forObject;

        public ScanerIntervalsSource(IFileSeeker fileSeeker, string forObject)
        {
            _fileSeeker = fileSeeker;
            _forObject = forObject;
        }
        public override IEnumerable<Interval> GetData(DateTime beginTime, DateTime endTime)
        {
            List<Interval> intervals = new List<Interval>();
            using (var scanerCtx = GetContext(_fileSeeker.GetFileName(_forObject)))
            {
                var scanerTubes = scanerCtx.ScanerTubeInfoes.Where(t => t.Date >= beginTime&&t.Date<endTime).ToList();
                intervals.AddRange(scanerTubes.Select(t => new Interval()
                {
                    Object = _forObject,
                    StartTime = t.Date,
                    SpecialLevel = (int)t.TubeStatus,
                    Duration = TimeSpan.FromSeconds(t.Speed != 0 ? (int)(t.Length * 1.0 / t.Speed) : 0)
                }));
            }
            return intervals;
        }

        private ScanerTubeInfoEntities GetContext(string fileName)
        {
            string efMetadata = "res://*/ScanerTubeInfoDbModel.csdl|res://*/ScanerTubeInfoDbModel.ssdl|res://*/ScanerTubeInfoDbModel.msl";
            var csb = new SQLiteConnectionStringBuilder();
            csb.DataSource = fileName;
            EntityConnectionStringBuilder connStrB = new EntityConnectionStringBuilder();
            connStrB.ProviderConnectionString = csb.ToString();
            connStrB.Metadata = efMetadata;
            connStrB.Provider = "System.Data.SQLite.EF6";
            return new ScanerTubeInfoEntities(connStrB.ConnectionString);
        }
    }
}
