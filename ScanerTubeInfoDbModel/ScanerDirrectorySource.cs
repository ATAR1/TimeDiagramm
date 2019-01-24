using IntervalsDBTypesLibrary;
using Scaner.DataDirectoryReaderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScanerTubeInfoDbModel
{
    public class ScanerDirrectorySource : IntervalSource
    {
        public ScanerDirrectorySource(IDirectorySeeker dirrectorySeeker, string name)
        {
            _dirrectorySeeker = dirrectorySeeker;
            _objectName = name;
        }

        IDirectorySeeker _dirrectorySeeker;
        private string _objectName;

        public override IEnumerable<Interval> GetData(DateTime beginTime, DateTime endTime)
        {
            if(!_dirrectorySeeker.GetDirectoryPath())
                return new Interval[0];
            DirectoryTreeReader reader = new DirectoryTreeReader();

            var tubes = reader.Read(_dirrectorySeeker.Path).ToList().Select(f => f.Read());
            return tubes.Where(ti=>ti.Date>=beginTime&&ti.Date<endTime).Select(ti => new Interval() {StartTime = ti.Date, Duration = TimeSpan.FromSeconds( ti.Duration), SpecialLevel = ti.TubeStatus, Object = _objectName } );
        }
    }
}
