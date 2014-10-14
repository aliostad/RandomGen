using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DateChangeByLink : IDateChangeBy
    {
        private readonly GenLink _gen;
        private readonly DateTime _date;
        private readonly int _value;

        internal DateChangeByLink(GenLink gen, DateTime date, int value)
        {
            this._gen = gen;
            this._date = date;
            this._value = value;
        }

        public DateTime Minutes()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();
            
            return _date.AddMinutes(offset);
        }

        public DateTime Hours()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();

            return _date.AddHours(offset);
        }

        public DateTime Days()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();
            
            return _date.AddDays(offset);
        }

        public DateTime Months()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();
            
            return _date.AddDays(offset * 30);
        }
    }
}
