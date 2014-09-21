using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class LongChangeByLink : ILongChangeBy
    {
        private readonly RandomLink _random;
        private readonly long _amount;
        private readonly long _value;

        internal LongChangeByLink(RandomLink random, long amount, long value)
        {
            this._random = random;
            this._amount = amount;
            this._value = value;
        }

        public long Percent()
        {
            var offset = _random.Numbers.Longs(_value * -1, _value)();

            return (long)Math.Round(this._amount + (this._amount * offset / 100.0));
            
        }

        public long Amount()
        {
            var offset = _random.Numbers.Longs(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
