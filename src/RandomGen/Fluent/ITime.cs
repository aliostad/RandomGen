using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface ITime : IFluentInterface
    {
        Func<DateTime> Dates(DateTime? min = null, DateTime? max = null);
        Func<DateTimeOffset> Dates(DateTimeOffset? min = null, DateTimeOffset? max = null);
        Func<TimeSpan> Spans(TimeSpan? min = null, TimeSpan? max = null);

        // TODO:
        //Func<DateTime> Times(DateTime? min = null, DateTime? max = null);
        //Func<DateTime> DateTimes(DateTime? min = null, DateTime? max = null);
    }
}
