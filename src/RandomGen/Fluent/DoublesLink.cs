using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    class DoublesLink : IDouble
    {
        private readonly RandomLink _randomLink;

        internal DoublesLink(RandomLink randomLink)
        {
            this._randomLink = randomLink;
        }

        public Func<double> WithNormalDistribution(double mean, double standardDeviation)
        {
            double u1 = _randomLink.Random.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = _randomLink.Random.NextDouble();

            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)

            return () => mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)
        }

        public Func<double> BetweenZeroAndOne()
        {
            return _randomLink.Numbers.Doubles(0, 1);
        }
    }
}
