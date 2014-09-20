using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DecimalChangeByLink : IDecimalChangeBy
    {
        private readonly RandomLink _random;
        private readonly decimal _amount;
        private readonly decimal _value;

        internal DecimalChangeByLink(RandomLink random, decimal amount, decimal value)
        {
            this._random = random;
            this._amount = amount;
            this._value = value;
        }

        public decimal Percent()
        {
            var offset = _random.Numbers.Decimals(_value * -1, _value)();

            return this._amount + (this._amount * offset / 100M);
            
        }

        public decimal Amount()
        {
            var offset = _random.Numbers.Decimals(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
