using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class DateChangeLink : IDateChange
    {
        private readonly RandomLink _random;
        private readonly DateTime _date;

        internal DateChangeLink(RandomLink random, DateTime date)
        {
            this._random = random;
            this._date = date;
        }

        public IDateChangeBy By(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");

            return new DateChangeByLink(_random, _date, value);
        }

        public DateTime By(TimeSpan value)
        {
            var offset = _random.Numbers.Longs(value.Ticks * -1, value.Ticks)();

            return _date.Add(TimeSpan.FromTicks(offset));       
        }
    }
}
