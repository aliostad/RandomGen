using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface ILongChangeBy : IFluentInterface
    {
        long Percent();
        long Amount();
    }
}
