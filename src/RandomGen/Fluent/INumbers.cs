using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface INumbers : IFluentInterface
    {
        Func<int> Integers(int min = 0, int max = 100);
        Func<long> Longs(long min = 0, long max = 100);
        IDouble Doubles();
        Func<double> Doubles(double min, double max);
        Func<decimal> Decimals(decimal min = 0, decimal max = 1);
        Func<bool> Booleans();
    }
}
