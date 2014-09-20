using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IDateChangeBy : IFluentInterface
    {
        DateTime Minutes();
        DateTime Hours();
        DateTime Days();
        DateTime Months();
    }
}
