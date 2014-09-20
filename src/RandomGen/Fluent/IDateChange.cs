using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IDateChange : IFluentInterface
    {
        IDateChangeBy By(int value);
        DateTime By(TimeSpan value);
    }
}
