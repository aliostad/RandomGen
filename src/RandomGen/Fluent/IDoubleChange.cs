using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IDoubleChange : IFluentInterface
    {
        IDoubleChangeBy By(double value);
    }
}
