using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class IntChangeByLink : IIntChangeBy
    {
        private readonly GenLink _gen;
        private readonly int _amount;
        private readonly int _value;

        internal IntChangeByLink(GenLink gen, int amount, int value)
        {
            this._gen = gen;
            this._amount = amount;
            this._value = value;
        }

        public int Percent()
        {
            var offset = _gen.Random.Numbers.Integers(_value * -1, _value)();

            return (int)Math.Round(this._amount + (this._amount * offset / 100.0));
            
        }

        public int Amount()
        {
            var offset = _gen.Random.Numbers.Integers(_value * -1, _value)();

            return this._amount + offset;
        }
    }
}
