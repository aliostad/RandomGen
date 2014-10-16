using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IGen : IFluentInterface
    {
        IRandom Random { get; }

        IDateChange Change(DateTime date);
        IDateTimeOffsetChange Change(DateTimeOffset date);
        IDoubleChange Change(double amount);
        IDecimalChange Change(decimal amount);
        ILongChange Change(long amount);
        IIntChange Change(int amount);
    }
}
