using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DoublesLink : IDouble
    {
        private readonly GenLink _gen;

        internal DoublesLink(GenLink gen)
        {
            this._gen = gen;
        }

        public Func<double> WithNormalDistribution(double mean, double standardDeviation)
        {
            //these are uniform(0,1) random doubles
            var factory = BetweenZeroAndOne();


            return () =>
            {
                double u1 = factory();
                double u2 = factory();

                double randStdNormal = Math.Sqrt(-2.0*Math.Log(u1))*
                                       Math.Sin(2.0*Math.PI*u2); //random normal(0,1)

                return mean + standardDeviation*randStdNormal; //random normal(mean,stdDev^2)
            };

        }

        public Func<double> BetweenZeroAndOne()
        {
            return _gen.Random.Numbers.Doubles(0, 1);
        }
    }
}
