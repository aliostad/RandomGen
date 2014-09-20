using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface ITime : IFluentInterface
    {
        Func<DateTime> Dates(DateTime? min = null, DateTime? max = null);
        Func<TimeSpan> Spans(TimeSpan? min = null, TimeSpan? max = null);
    }
}
