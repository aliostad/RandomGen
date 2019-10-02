using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class NumbersLink : INumbers
    {
        private readonly GenLink _genLink;

        internal NumbersLink(GenLink randomLink)
        {
            this._genLink = randomLink;
        }

        public Func<byte> Bytes(byte min = 0, byte max = 100)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var random = this._genLink.CreateRandom();

            return () => (byte)random.Next(min, max);
        }

        public Func<int> Integers(int min = 0, int max = 100)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var random = this._genLink.CreateRandom();

            return () => random.Next(min, max);
        }

        public Func<uint> UnsignedIntegers(uint min = 0, uint max = 100)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var range = max - min;
            var random = this._genLink.CreateRandom();

            return () => Convert.ToUInt32(min + (range * random.NextDouble()));
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
            return new DoublesLink(_genLink);
        }

        public Func<double> Doubles(double min = 0, double max = 1)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var range = max - min;
            var random = this._genLink.CreateRandom();

            return () => min + (range * random.NextDouble());
        }

        public Func<decimal> Decimals(decimal min = 0, decimal max = 1)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var range = max - min;
            var random = this._genLink.CreateRandom();

            return () => min + (range * (decimal)random.NextDouble());
        }
    }
}
