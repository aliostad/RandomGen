using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DecimalChangeLink : IDecimalChange
    {
        private readonly GenLink _gen;
        private readonly decimal _amount;

        internal DecimalChangeLink(GenLink gen, decimal amount)
        {
            this._gen = gen;
            this._amount = amount;
        }

        public IDecimalChangeBy By(decimal value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new DecimalChangeByLink(_gen, _amount, value);
        }
    }
}
