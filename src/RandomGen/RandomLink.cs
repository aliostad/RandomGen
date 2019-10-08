using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class RandomLink : IRandom
    {
        private readonly GenLink _gen;

        public RandomLink(GenLink gen)
        {
            _gen = gen;
        }

        public INumbers Numbers { get { return new NumbersLink(_gen); } }
        public INames Names { get { return new NamesLink(this); } }
        public ITime Time { get { return new TimeLink(this); } }
        public IText Text { get { return new TextLink(this); } }
        public IInternet Internet { get { return new InternetLink(this); } }
        public IPhoneNumbers PhoneNumbers { get { return new PhoneNumbersLink(this); } }

        public Func<T> Items<T>(IEnumerable<T> items, IEnumerable<double> weights = null)
        {
            var copy = items.ToList();
            if (weights == null)
            {
                var factory = this.Numbers.Integers(0, copy.Count);
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

                var factory = this.Numbers.Doubles(0, cumSum.Last());
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

        public Func<T> Items<T>(ICollection<T> items, IEnumerable<double> weights = null)
            => this.Items((IEnumerable<T>)items, weights);

        public Func<T> Items<T>(IList<T> items, IEnumerable<double> weights = null)
            => this.Items((IEnumerable<T>)items, weights);

        public Func<T> Items<T>(IReadOnlyCollection<T> items, IEnumerable<double> weights = null)
            => this.Items((IEnumerable<T>)items, weights);

        public Func<T> Items<T>(IReadOnlyList<T> items, IEnumerable<double> weights = null)
            => this.Items((IEnumerable<T>)items, weights);

        public Func<T> Items<T>(T[] items, IEnumerable<double> weights = null)
            => this.Items((IEnumerable<T>)items, weights);

        public Func<T> Items<T>(params T[] items)
        {
            var factory = this.Numbers.Integers(0, items.Length);
            return () => items[factory()];
        }

        public Func<T> Enum<T>(IEnumerable<double> weights = null)
            where T : struct, IConvertible
        {
            var enumType = typeof(T);

            if (!enumType.IsEnum)
                throw new NotSupportedException(enumType.Name + " is not an enum");

            var values = (IEnumerable<T>)System.Enum.GetValues(enumType);

            return this.Items(values, weights);
        }

        public Func<string> Countries()
        {
            var data = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(culture => new RegionInfo(culture.LCID).EnglishName)
                .Distinct();

            return this.Items(data);
        }
    }
}
