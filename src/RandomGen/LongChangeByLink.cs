using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class LongChangeByLink : ILongChangeBy
    {
        private readonly GenLink _gen;
        private readonly long _amount;
        private readonly long _value;

        internal LongChangeByLink(GenLink gen, long amount, long value)
        {
            this._gen = gen;
            this._amount = amount;
            this._value = value;
        }

        public long Percent()
        {
            var offset = _gen.Random.Numbers.Longs(_value * -1, _value)();

            return (long)Math.Round(this._amount + (this._amount * offset / 100.0));
            
        }

        public long Amount()
        {
            var offset = _gen.Random.Numbers.Longs(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
