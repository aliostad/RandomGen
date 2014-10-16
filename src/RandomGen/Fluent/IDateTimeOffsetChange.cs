using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IDateTimeOffsetChange : IFluentInterface
    {
        IDateTimeOffsetChangeBy By(int value);
        DateTimeOffset By(TimeSpan value);
    }
}
