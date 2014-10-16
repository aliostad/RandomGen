using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class GenLink : IGen
    {
        private readonly int _seed;

        public GenLink(int? seed = null)
        {
            this._seed = seed ?? Gen.CreateRandomSeed();
        }

        public IRandom Random
        {
            get { return new RandomLink(this); }
        }

        public IDateChange Change(DateTime date)
        {
            return new DateChangeLink(this, date);
        }

        public IDateTimeOffsetChange Change(DateTimeOffset date)
        {
            return new DateTimeOffsetChangeLink(this, date);
        }

        public IDoubleChange Change(double amount)
        {
            return new DoubleChangeLink(this, amount);
        }

        public IDecimalChange Change(decimal amount)
        {
            return new DecimalChangeLink(this, amount);
        }

        public ILongChange Change(long amount)
        {
            return new LongChangeLink(this, amount);
        }

        public IIntChange Change(int amount)
        {
            return new IntChangeLink(this, amount);
        }

        public Func<T> Items<T>(IEnumerable<T> items, IEnumerable<double> weights = null)
        {
            var copy = items.ToList();
            if (weights == null)
            {
                var factory = this.Random.Numbers.Integers(0, copy.Count);
                return () => copy[factory()];
            }
            else
            {
                var weightsCopy = weights.ToList();
                if (weightsCopy.Count != copy.Count)
                    throw new ArgumentException("Weights must have the same number of items as items.");

                var cumSum = new double[weightsCopy.Count];
                cumSum[0] = weightsCopy[0];
                Enumerable.Range(1, weightsCopy.Count - 1)
                    .ToList()
                    .ForEach(i => cumSum[i] = cumSum[i - 1] + weightsCopy[i]);

                var factory = this.Random.Numbers.Doubles(0, cumSum.Last());
                return () =>
                {
                    var r = factory();
                    for (int i = 0; i < cumSum.Length; i++)
                    {
                        if (cumSum[i] > r)
                            return copy[i];
                    }
                    return copy.Last();
                };
            }
        }

        public Func<string> Countries()
        {
            var data = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(culture => new RegionInfo(culture.LCID).EnglishName)
                .Distinct();

            return this.Items(data);
        }

        internal Random CreateRandom()
        {
            return new Random(_seed);
        }
    }
}
