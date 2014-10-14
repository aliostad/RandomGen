using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DateChangeLink : IDateChange
    {
        private readonly GenLink _gen;
        private readonly DateTime _date;

        internal DateChangeLink(GenLink gen, DateTime date)
        {
            this._gen = gen;
            this._date = date;
        }

        public IDateChangeBy By(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new DateChangeByLink(_gen, _date, value);
        }

        public DateTime By(TimeSpan value)
        {
            var offset = _gen.Random.Numbers.Longs(value.Ticks * -1, value.Ticks)();

            return _date.Add(TimeSpan.FromTicks(offset));       
        }
    }
}
