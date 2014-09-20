using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DecimalChangeLink : IDecimalChange
    {
        private readonly RandomLink _random;
        private readonly decimal _amount;

        internal DecimalChangeLink(RandomLink random, decimal amount)
        {
            this._random = random;
            this._amount = amount;
        }

        public IDecimalChangeBy By(decimal value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new DecimalChangeByLink(_random, _amount, value);
        }
    }
}
