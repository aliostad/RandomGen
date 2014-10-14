using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DoubleChangeByLink : IDoubleChangeBy
    {
        private readonly GenLink _gen;
        private readonly double _amount;
        private readonly double _value;

        internal DoubleChangeByLink(GenLink gen, double amount, double value)
        {
            this._gen = gen;
            this._amount = amount;
            this._value = value;
        }

        public double Percent()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();

            return this._amount + (this._amount * offset / 100.0);
            
        }

        public double Amount()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
