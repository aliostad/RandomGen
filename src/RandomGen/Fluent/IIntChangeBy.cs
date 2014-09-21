using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IIntChangeBy : IFluentInterface
    {
        int Percent();
        int Amount();
    }
}
