using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DoubleChangeByLink : IDoubleChangeBy
    {
        private readonly RandomLink _random;
        private readonly double _amount;
        private readonly double _value;

        internal DoubleChangeByLink(RandomLink random, double amount, double value)
        {
            this._random = random;
            this._amount = amount;
            this._value = value;
        }

        public double Percent()
        {
            var offset = _random.Numbers.Doubles(_value * -1, _value)();

            return this._amount + (this._amount * offset / 100.0);
            
        }

        public double Amount()
        {
            var offset = _random.Numbers.Doubles(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
