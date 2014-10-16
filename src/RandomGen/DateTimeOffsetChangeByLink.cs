using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DateTimeOffsetChangeByLink : IDateTimeOffsetChangeBy
    {
        private readonly GenLink _gen;
        private readonly DateTimeOffset _date;
        private readonly int _value;

        internal DateTimeOffsetChangeByLink(GenLink gen, DateTimeOffset date, int value)
        {
            this._gen = gen;
            this._date = date;
            this._value = value;
        }

        public DateTimeOffset Minutes()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();
            
            return _date.AddMinutes(offset);
        }

        public DateTimeOffset Hours()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();

            return _date.AddHours(offset);
        }

        public DateTimeOffset Days()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();
            
            return _date.AddDays(offset);
        }

        public DateTimeOffset Months()
        {
            var offset = _gen.Random.Numbers.Doubles(_value * -1, _value)();
            
            return _date.AddDays(offset * 30);
        }
    }
}
