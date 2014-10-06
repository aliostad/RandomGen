using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class NumbersLink : INumbers
    {
        private readonly RandomLink _randomLink;

        internal NumbersLink(RandomLink randomLink)
        {
            this._randomLink = randomLink;
        }

        public Func<int> Integers(int min = 0, int max = 100)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var random = Gen.CreateRandom();
            
            return () => random.Next(min, max);
        }

        public Func<long> Longs(long min = 0, long max = 100)
        {
            var gen = this.Doubles(min, max);

            return () => (long)gen();
        }

        public Func<bool> Booleans()
        {
            var factory = this.Integers(max: 2);
            
            return () => factory() % 2 == 0;
        }

        public IDouble Doubles()
        {
            return new DoublesLink(_randomLink);
        }

        public Func<double> Doubles(double min = 0, double max = 1)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var range = max - min;
            var random = Gen.CreateRandom();

            return () => min + (range * random.NextDouble());
        }

        public Func<decimal> Decimals(decimal min = 0, decimal max = 1)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var range = max - min;
            var random = Gen.CreateRandom();

            return () => min + (range * (decimal)random.NextDouble());
        }
    }
}
