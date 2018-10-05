using IntervalsDBTypesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntervalDatasources
{
    public class ScanerWcfClientDatasource : IntervalSource
    {
        private string _forObject;

        public ScanerWcfClientDatasource(string forObject)
        {
            _forObject = forObject;
        }

        public override IEnumerable<Interval> GetData(DateTime beginTime, DateTime endTime)
        {
            using (ServiceReference1.DataSourceServiceClient cl = new ServiceReference1.DataSourceServiceClient())
            {
                return cl.GetRecordsForPeriod(beginTime, endTime).Select(r => new Interval() { Object = _forObject, Duration = TimeSpan.FromSeconds(r.Duration), StartTime = r.Start, SpecialLevel = r.Status });
            }

        }
    }
}
