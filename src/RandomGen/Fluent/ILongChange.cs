using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface ILongChange : IFluentInterface
    {
        ILongChangeBy By(long value);
    }
}
