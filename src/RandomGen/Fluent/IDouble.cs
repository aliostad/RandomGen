using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IDouble : IFluentInterface
    {
        /// <summary>
        /// Creates Normal Distribution according to Box Muller
        /// [Used impl according to http://stackoverflow.com/a/218600/440502]
        /// </summary>
        Func<double> WithNormalDistribution(double mean, double standardDeviation);

        Func<double> BetweenZeroAndOne();
    }
}
