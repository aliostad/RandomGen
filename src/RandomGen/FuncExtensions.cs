using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen
{
    public static class FuncExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this Func<T> gen)
        {
            while (true)
            {
                yield return gen();
            }
        }
    }
}
