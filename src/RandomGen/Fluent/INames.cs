using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    /// <summary>
    /// According to US Census Data
    /// http://www.census.gov/genealogy/www/data/1990surnames/names_files.html
    /// </summary>
    public interface INames : IFluentInterface
    {
        Func<string> Female();
        Func<string> Male();
        Func<string> First();
        Func<string> Surname();
        Func<string> Full();
    }
}
