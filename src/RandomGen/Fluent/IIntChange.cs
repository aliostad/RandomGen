using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IIntChange : IFluentInterface
    {
        IIntChangeBy By(int value);
    }
}
