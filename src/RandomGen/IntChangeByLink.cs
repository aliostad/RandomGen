using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class IntChangeByLink : IIntChangeBy
    {
        private readonly RandomLink _random;
        private readonly int _amount;
        private readonly int _value;

        internal IntChangeByLink(RandomLink random, int amount, int value)
        {
            this._random = random;
            this._amount = amount;
            this._value = value;
        }

        public int Percent()
        {
            var offset = _random.Numbers.Integers(_value * -1, _value)();

            return (int)Math.Round(this._amount + (this._amount * offset / 100.0));
            
        }

        public int Amount()
        {
            var offset = _random.Numbers.Integers(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
