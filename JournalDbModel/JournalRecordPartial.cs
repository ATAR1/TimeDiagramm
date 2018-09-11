using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDbModel
{
    partial class  JournalRecord
    {
        public DateTime StartDate => Start<TimeSpan.FromHours(8) ? Date.AddDays(1) + Start : Date + Start;

        public DateTime EndDate => End <= TimeSpan.FromHours(8) ? Date.AddDays(1) + End : Date + End;

        public TimeSpan Duration => EndDate - StartDate;
    }
}
