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
            this._generate = this._random.Numbers.Integers(0, 10);
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
                case NumberFormat.UKLandLine:
                    return "01xxx xxxxxx";

                case NumberFormat.UKMobile:
                    return "07xxx xxxxxx";

                default:
                    throw new NotSupportedException(string.Format("Format {0} is not supported.", format));
            }            
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
            var randomFormats = this._random.Items((NumberFormat[])Enum.GetValues(typeof(NumberFormat)));

            return () => WithFormat(randomFormats())();
        }
    }
}
