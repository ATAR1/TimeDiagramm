using System.Collections.Generic;

namespace IntervalsDBTypesLibrary
{
    public interface IIntervalsRepository
    {
        void Save(IEnumerable<Interval> intervals);
    }
}