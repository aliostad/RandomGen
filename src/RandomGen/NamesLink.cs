using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class NamesLink : INames
    {
        private static readonly Lazy<string[]> _maleNames = new Lazy<string[]>(GetMaleNames);
        private static readonly Lazy<string[]> _femaleNames = new Lazy<string[]>(GetFemaleNames);
        private static readonly Lazy<string[]> _surnames = new Lazy<string[]>(GetSurnames);
        private readonly RandomLink _random;

        internal NamesLink(RandomLink random)
        {
            this._random = random;
        }

        public Func<string> Female()
        {
            var length = _femaleNames.Value.Length;
            var factory = _random.Numbers.Integers(0, length);

            return () => _femaleNames.Value[factory()];
        }

        public Func<string> Male()
        {
            var length = _maleNames.Value.Length;
            var factory = _random.Numbers.Integers(0, length);

            return () => _maleNames.Value[factory()];
        }

        public Func<string> First()
        {
            var sources = new[] { this.Male(), this.Female() };
            var factory = _random.Numbers.Integers(max: sources.Length);

            return () => sources[factory()]();
        }

        public Func<string> Surname()
        {
            var length = _surnames.Value.Length;
            var factory = _random.Numbers.Integers(0, length);

            return () => _surnames.Value[factory()];
        }

        public Func<string> Full()
        {
            var firstNamesFactory = _random.Names.First();
            var surnameFactory = _random.Names.Surname();

            return () => string.Concat(firstNamesFactory(), " ", surnameFactory());
        }

        private static string[] GetMaleNames()
        {
            return Gen.GetResourceStrings("dist.male.first.txt");
        }

        private static string[] GetFemaleNames()
        {
            return Gen.GetResourceStrings("dist.female.first.txt");
        }

        private static string[] GetSurnames()
        {
            return Gen.GetResourceStrings("dist.all.last.txt");
        }
    }
}
