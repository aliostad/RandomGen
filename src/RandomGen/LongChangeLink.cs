using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class LongChangeLink : ILongChange
    {
        private readonly RandomLink _random;
        private readonly long _amount;

        internal LongChangeLink(RandomLink random, long amount)
        {
            this._random = random;
            this._amount = amount;
        }

        public ILongChangeBy By(long value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new LongChangeByLink(_random, _amount, value);
        }
    }
}
