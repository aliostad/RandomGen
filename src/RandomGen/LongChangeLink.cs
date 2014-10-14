using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class LongChangeLink : ILongChange
    {
        private readonly GenLink _gen;
        private readonly long _amount;

        internal LongChangeLink(GenLink gen, long amount)
        {
            this._gen = gen;
            this._amount = amount;
        }

        public ILongChangeBy By(long value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new LongChangeByLink(_gen, _amount, value);
        }
    }
}
