using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    /// <summary>
    /// Based on 350,000 English words taken from
    /// http://www.math.sjsu.edu/~foster/dictionary.txt
    /// </summary>
    public interface IText : IFluentInterface
    {
        Func<string> Words();
        Func<string> Short();
        Func<string> Long();
        Func<string> VeryLong();
        Func<string> Length(int length);

        /// <summary>
        /// Based on the Big List of Naughty Strings taken from
        /// https://github.com/minimaxir/big-list-of-naughty-strings
        /// </summary>
        Func<string> Naughty();
    }
}
