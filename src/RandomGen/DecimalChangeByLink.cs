using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DecimalChangeByLink : IDecimalChangeBy
    {
        private readonly GenLink _gen;
        private readonly decimal _amount;
        private readonly decimal _value;

        internal DecimalChangeByLink(GenLink gen, decimal amount, decimal value)
        {
            this._gen = gen;
            this._amount = amount;
            this._value = value;
        }

        public decimal Percent()
        {
            var offset = _gen.Random.Numbers.Decimals(_value * -1, _value)();

            return this._amount + (this._amount * offset / 100M);
            
        }

        public decimal Amount()
        {
            var offset = _gen.Random.Numbers.Decimals(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
