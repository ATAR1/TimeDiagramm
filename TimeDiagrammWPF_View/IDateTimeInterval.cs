using System;

namespace TimeDiagrammWPF_View
{
    public interface IDateTimeInterval
    {
        DateTime BeginTime { get; set; }

        DateTime EndTime { get; set; }

    }
}