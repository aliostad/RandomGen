using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DoubleChangeLink : IDoubleChange
    {
        private readonly GenLink _gen;
        private readonly double _amount;

        internal DoubleChangeLink(GenLink gen, double amount)
        {
            this._gen = gen;
            this._amount = amount;
        }

        public IDoubleChangeBy By(double value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new DoubleChangeByLink(_gen, _amount, value);
        }
    }
}
