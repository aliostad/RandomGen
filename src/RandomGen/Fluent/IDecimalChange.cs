using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IDecimalChange : IFluentInterface
    {
        IDecimalChangeBy By(decimal value);
    }
}
