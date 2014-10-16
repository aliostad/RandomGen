using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DateTimeOffsetChangeLink : IDateTimeOffsetChange
    {
        private readonly GenLink _gen;
        private readonly DateTimeOffset _date;

        internal DateTimeOffsetChangeLink(GenLink gen, DateTimeOffset date)
        {
            this._gen = gen;
            this._date = date;
        }

        public IDateTimeOffsetChangeBy By(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new DateTimeOffsetChangeByLink(_gen, _date, value);
        }

        public DateTimeOffset By(TimeSpan value)
        {
            var offset = _gen.Random.Numbers.Longs(value.Ticks * -1, value.Ticks)();

            return _date.Add(TimeSpan.FromTicks(offset));       
        }
    }
}
