using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class IntChangeLink : IIntChange
    {
        private readonly GenLink _gen;
        private readonly int _amount;

        internal IntChangeLink(GenLink gen, int amount)
        {
            this._gen = gen;
            this._amount = amount;
        }

        public IIntChangeBy By(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new IntChangeByLink(_gen, _amount, value);
        }
    }
}
