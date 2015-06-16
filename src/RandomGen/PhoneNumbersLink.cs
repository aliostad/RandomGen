using System;
using System.Collections.Generic;
using RandomGen.Fluent;

namespace RandomGen
{
    class PhoneNumbersLink : IPhoneNumbers
    {
        private readonly RandomLink _random;
        private readonly Func<int> _generate;

        internal PhoneNumbersLink(RandomLink random)
        {
            this._random = random;
            this._generate = this._random.Numbers.Integers(0, 9);
        }

        string MaskToString(string mask)
        {
            return string.Join("", MaskToEnumerable(mask));
        }

        IEnumerable<string> MaskToEnumerable(string mask)
        {
            foreach (var character in mask)
            {
                if (character == 'x')
                {
                    yield return this._generate().ToString();
                }
                else
                {
                    yield return character.ToString();
                }
            }
        }

        string NumberFormatToMask(NumberFormat format)
        {
            switch (format)
            {
                case NumberFormat.UKLandLine: return "01xxx xxxxxx";
                case NumberFormat.UKMobile: return "07xxx xxxxxx";
            }
            throw new NotSupportedException("format not supported");
        }

        public Func<string> FromMask(string mask)
        {
            return () => MaskToString(mask);
        }

        public Func<string> WithFormat(NumberFormat format)
        {
            return FromMask(NumberFormatToMask(format));
        }

        public Func<string> WithRandomFormat()
        {
            // work out the number of items in the enum, and select a random member 
            // (assuming the values in the enum are simple consecutive numbers)
            return WithFormat((NumberFormat)this._random.Numbers.Integers(0, (int)Enum.GetValues(typeof(NumberFormat)).Length -1)());
        }
    }
}
