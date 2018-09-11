using IntervalsDBTypesLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;

namespace MDT6DbModel
{
    public class MDT6IntervalsSource : IntervalSource
    {
        private string _forObject;

        public MDT6IntervalsSource(string forObject)
        {
            _forObject = forObject;
        }
        public override IEnumerable<Interval> GetData(DateTime beginTime, DateTime endTime)
        {
            List<Interval> intervals = new List<Interval>();
            using (var mdt6Ctx = GetContext())
            {
                var mdt6Tubes = mdt6Ctx.Tubes.Where(t => t.tCreatedDate >= beginTime&&t.tCreatedDate<endTime).ToList();
                intervals.AddRange(mdt6Tubes.Select(t =>
                {
                    int level = 0;
                    if ((!String.IsNullOrWhiteSpace(t.note)) && (t.note.Trim() == "*")) level = 1;
                    if ((!String.IsNullOrWhiteSpace(t.note)) && (t.note.Trim() != "*")) level = 2;
                    return new Interval()
                    {
                        Object = _forObject,
                        StartTime = t.tCreatedDate,
                        SpecialLevel = level,
                        Duration = TimeSpan.FromSeconds(t.speedt != 0 ? (int)(t.lent * 10.0 / t.speedt) : 0)
                    };
                }));
            }

            return intervals;
        }

        private Dictionary<string, string> _dict = new Dictionary<string, string>
        {
            {"МДТ 6" ,  @"data source=MDT6\SQLEXPRESS;initial catalog=MDT6DB;persist security info=True;user id=unsknet;password=yhnbgt;MultipleActiveResultSets=True;App=EntityFramework"},
            {"МДТ 6.1" ,  @"data source=MDT61\SQLEXPRESS;initial catalog=MDT6DB;persist security info=True;user id=unsknet;password=yhnbgt;MultipleActiveResultSets=True;App=EntityFramework"},
            {"МДТ 6.2" ,  @"data source=MDT62\SQLEXPRESS;initial catalog=MDT6DB;persist security info=True;user id=unsknet;password=yhnbgt;MultipleActiveResultSets=True;App=EntityFramework"}
        };

        private MDT6DBEntities GetContext()
        {
            string efMetadata = "res://*/MDT6DbModel.csdl|res://*/MDT6DbModel.ssdl|res://*/MDT6DbModel.msl";
            EntityConnectionStringBuilder connStrB = new EntityConnectionStringBuilder();
            connStrB.ProviderConnectionString = _dict[_forObject];
            connStrB.Metadata = efMetadata;
            connStrB.Provider = "System.Data.SqlClient";
            return new MDT6DBEntities(connStrB.ConnectionString);
        }
    }
}
