using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    class TextLink : IText
    {
        private static Lazy<string[]> _words = new Lazy<string[]>(GetWords);
        private readonly RandomLink _random;

        internal TextLink(RandomLink random)
        {
            this._random = random;
        }

        public Func<string> Words()
        {
            var length = _words.Value.Length;
            var factory = _random.Numbers.Integers(0, length);
            
            return () => _words.Value[factory()];
        }

        public Func<string> Short()
        {
            return this.Length(20);
        }

        public Func<string> Long()
        {
            return this.Length(50);
        }

        public Func<string> VeryLong()
        {
            return this.Length(200);
        }

        public Func<string> Length(int length)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException("length", "length must be a positive number");

            var factory = this.Words();

            return () =>
            {
                var builder = new StringBuilder(length + 20);

                while (builder.Length < length)
                    builder.Append(factory()).Append(" ");

                return builder.ToString().Substring(0, length);
            };
        }

        private static string[] GetWords()
        {
            return Gen.GetResourceStrings("dictionary.txt");
        }
    }
}
