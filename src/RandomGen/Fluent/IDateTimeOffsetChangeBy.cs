using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IDateTimeOffsetChangeBy : IFluentInterface
    {
        DateTimeOffset Minutes();
        DateTimeOffset Hours();
        DateTimeOffset Days();
        DateTimeOffset Months();
    }
}
