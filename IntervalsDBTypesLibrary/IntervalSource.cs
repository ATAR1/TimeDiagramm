using System;
using System.Collections.Generic;
using IntervalsDBTypesLibrary;

namespace IntervalsDBTypesLibrary
{
    public abstract class IntervalSource
    {
        public abstract IEnumerable<Interval> GetData(DateTime beginTime, DateTime endTime);
    }
}